using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssist.AdminWeb
{
	/// <summary>
	/// Provides data for the dialog events.
	/// </summary>
	public class DialogEventArgs : EventArgs
	{
		/// <summary>
		/// Contains any message that should be displayed.
		/// </summary>
		private string _message;

		/// <summary>
		/// Contains the dialog result.
		/// </summary>
		private DialogEventResult _result;

		/// <summary>
		/// Boolean value indicating whether the dialog should be closed. 
		/// </summary>
		private bool _closeDialog;

		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message
		{
			get
			{
				return _message;
			}
		}

		/// <summary>
		/// Gets the dialog event result.
		/// </summary>
		/// <value>The result.</value>
		public DialogEventResult Result
		{
			get
			{
				return _result;
			}
		}

		/// <summary>
		/// Boolean value indicating whether the dialog should be closed. 
		/// </summary>
		public bool CloseDialog
		{
			get
			{
				return _closeDialog;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DialogEventArgs"/> class.
		/// </summary>
		/// <param name="result">A <see cref="DialogEventResult"/> representing the result.</param>
		/// <param name="message">The message that should be displayed to the user.</param>
		/// <param name="closeDialog">if set to <c>true</c> closes the dialog</param>
		public DialogEventArgs(DialogEventResult result, string message, bool closeDialog)
		{
			_result = result;
			_message = message;
			_closeDialog = closeDialog;
		}
	}
}