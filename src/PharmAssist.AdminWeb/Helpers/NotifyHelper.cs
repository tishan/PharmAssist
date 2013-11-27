using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Globalization;
using PharmAssist.Core.Helpers;

namespace PharmAssist.AdminWeb.Helpers
{
	/// <summary>
	/// Helper class for displaying notification messages.
	/// </summary>
	public static class NotifyHelper
	{
		/// <summary>
		/// Messge type of error messages.
		/// </summary>
		public const string Error = "error";

		/// <summary>
		/// Message type of warning messages.
		/// </summary>
		public const string Warning = "warning";

		/// <summary>
		/// Message type of success messages.
		/// </summary>
		public const string Ok = "ok";

		/// <summary>
		/// Message type of informational messages.
		/// </summary>
		public const string Information = "info";

		/// <summary>
		/// Session key for message.
		/// </summary>
		private const string NotifyMessageKey = "NotifyMessage";

		/// <summary>
		/// Session key for message type.
		/// </summary>
		private const string NotifyTypeKey = "NotifyType";

		/// <summary>
		/// Determines whether there is a message stored for display.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if there is a message; otherwise, <c>false</c>.
		/// </returns>
		public static bool HasMessage()
		{
			bool result = false;
			object message = HttpContext.Current.Session[NotifyMessageKey];
			if (message != null)
			{
				result = !string.IsNullOrEmpty(message.ToString());
			}

			return result;
		}

		/// <summary>
		/// Sets a message to be displayed in next page load.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="type">The message type.</param>
		public static void SetMessage(string message, string type)
		{
			HttpSessionState session = HttpContext.Current.Session;
			if (HttpContext.Current != null && type == NotifyHelper.Error)
			{
				message = message + " Error code - " + HttpContext.Current.Items["UniqueKey"] + ".";
			}

			session[NotifyMessageKey] = message;
			session[NotifyTypeKey] = type;
		}

		/// <summary>
		/// Gets the message script to be added to the page.
		/// </summary>
		/// <returns>A string containing the JavaScript that displayes the message.</returns>
		public static string GetMessageScript()
		{
			HttpSessionState session = HttpContext.Current.Session;
			return string.Format(CultureInfo.InvariantCulture,
					"$.notify.startup = {{ message: {0}, type : \"{1}\" }};",
					StringHelper.EncodeJSString(session[NotifyMessageKey].ToString()), session[NotifyTypeKey]);
		}

		/// <summary>
		/// Gets the message script to be added to the page.
		/// </summary>
		/// <returns>A string containing the JavaScript that displayes the message in parent page.</returns>
		public static string GetParentMessageScript()
		{
			HttpSessionState session = HttpContext.Current.Session;
			return string.Format(CultureInfo.InvariantCulture,
					"$.notify({{ message: \"{0}\",  type : \"{1}\" }});",
					session[NotifyMessageKey], session[NotifyTypeKey]);
		}

		/// <summary>
		/// Clears the message stored for display.
		/// </summary>
		public static void ClearMessage()
		{
			HttpSessionState session = HttpContext.Current.Session;
			session[NotifyMessageKey] = null;
			session[NotifyTypeKey] = null;
		}
	}
}