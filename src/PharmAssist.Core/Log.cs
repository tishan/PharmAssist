using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Web;

namespace PharmAssist.Core
{
	/// <summary>
	/// Logs debug and error information using the enterprise library .
	/// </summary>
	public static class Log
	{
		private const string DebugCategory = "DEBUG";
		private const string ErrorCategory = "ERROR";
		private const string WarnCategory = "WARN";
		private const string InformationCategory = "INFORMATION";

		/// <summary>
		/// Writes a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Debug(string message)
		{
			WriteDebugMessage(message);
		}

		/// <summary>
		/// Writes a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The args.</param>
		public static void Debug(string message, params object[] args)
		{
			WriteDebugMessage(string.Format(CultureInfo.InvariantCulture, message, args));
		}

		/// <summary>
		/// Write a warning message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Warn(string message)
		{
			WriteWarnMessage(message);
		}

		/// <summary>
		/// Writes a warning message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The args.</param>
		public static void Warn(string message, params object[] args)
		{
			WriteWarnMessage(string.Format(CultureInfo.InvariantCulture, message, args));
		}

		/// <summary>
		/// Writes an error message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Error(string message)
		{
			WriteErrorMessage(message);
		}

		/// <summary>
		/// Errors the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="args">The args.</param>
		public static void Error(string message, params object[] args)
		{
			WriteErrorMessage(string.Format(CultureInfo.InvariantCulture, message, args));
		}

		/// <summary>
		/// Log errors for specified exception.
		/// </summary>
		/// <param name="ex">The exception.</param>
		public static void Error(Exception ex)
		{
			WriteErrorMessage(ex.ToString());
		}

		/// <summary>
		/// Log Errors for specified exception and given message.
		/// </summary>
		/// <param name="ex">The exception.</param>
		/// <param name="message">The message.</param>
		public static void Error(Exception ex, string message)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(ex.ToString());
			sb.AppendLine();
			sb.Append(message);
			WriteErrorMessage(sb.ToString());
		}

		/// <summary>
		/// Logs the specified info.
		/// </summary>
		/// <param name="info">The info.</param>
		public static void Information(string info)
		{
			WriteInformation(info);
		}

		/// <summary>
		/// Writes the debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		private static void WriteDebugMessage(string message)
		{
			LogEntry entry = new LogEntry();
			entry.Severity = TraceEventType.Verbose;
			entry.Categories.Add(DebugCategory);
			entry.Message = message;
			if (Logger.ShouldLog(entry))
			{
				StackFrame stackFrame = new StackFrame(2);
				MethodBase method = stackFrame.GetMethod();
				entry.Title = method.DeclaringType.FullName + "." + method.Name;
				Logger.Write(entry);
			}
		}

		/// <summary>
		/// Writes the warn message.
		/// </summary>
		/// <param name="message">The message.</param>
		private static void WriteWarnMessage(string message)
		{
			LogEntry entry = new LogEntry();
			entry.Severity = TraceEventType.Warning;
			entry.Categories.Add(WarnCategory);
			SetMessage(entry, message);
			if (Logger.ShouldLog(entry))
			{
				StackFrame stackFrame = new StackFrame(2);
				MethodBase method = stackFrame.GetMethod();
				entry.Title = method.DeclaringType.FullName + "." + method.Name;
				Logger.Write(entry);
			}
		}

		/// <summary>
		/// Writes the error message.
		/// </summary>
		/// <param name="message">The message.</param>
		private static void WriteErrorMessage(string message)
		{
			LogEntry entry = new LogEntry();
			entry.Severity = TraceEventType.Error;
			entry.Categories.Add(ErrorCategory);
			SetMessage(entry, message);
			if (Logger.ShouldLog(entry))
			{
				StackFrame stackFrame = new StackFrame(2);
				MethodBase method = stackFrame.GetMethod();
				entry.Title = method.DeclaringType.FullName + "." + method.Name;
				Logger.Write(entry);
			}
		}

		/// <summary>
		/// Writes the information.
		/// </summary>
		/// <param name="info">The info.</param>
		private static void WriteInformation(string info)
		{
			LogEntry entry = new LogEntry();
			entry.Severity = TraceEventType.Information;
			entry.Categories.Add(InformationCategory);
			entry.Message = info;
			if (Logger.ShouldLog(entry))
			{
				StackFrame stackFrame = new StackFrame(2);
				MethodBase method = stackFrame.GetMethod();
				entry.Title = method.DeclaringType.FullName + "." + method.Name;
				Logger.Write(entry);
			}
		}

		/// <summary>
		/// Sets the specified message and custom messages to log entry.
		/// </summary>
		/// <param name="entry">The log entry instance.</param>
		/// <param name="info">The message information.</param>
		private static void SetMessage(LogEntry entry, string info)
		{
			StringBuilder messageBuilder = new StringBuilder(info);
			// The unique key is used to identify an error.
			// If we generate the unique key here, we cannot display it to the web users.
			// So for a web request, unique key is generated in application_beginrequest in global.asax
			// If the http context is null dummy key is added to avoid any errors in logging framework.
			string uniquekey = "UniqueKey";
			if (HttpContext.Current != null)
			{
				messageBuilder.AppendLine();
				messageBuilder.AppendLine(string.Concat("Raw Url : ", HttpContext.Current.Request.RawUrl));

				messageBuilder.AppendLine();
				messageBuilder.Append(string.Concat("Absolute Url : ",
						HttpContext.Current.Request.Url.AbsoluteUri));

				entry.ExtendedProperties.Add(uniquekey, HttpContext.Current.Items["UniqueKey"]);
			}
			else
			{
				entry.ExtendedProperties.Add(uniquekey, "No extended properties found to log(not an error)");
			}

			entry.Message = messageBuilder.ToString();
		}
	}
}
