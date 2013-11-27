using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Text;

namespace PharmAssist.AdminWeb
{/// <summary>
	/// The base class for all popup dialogs in the VP admin application.
	/// </summary>
	public abstract class DialogBase : UserControl
	{
		/// <summary>
		/// The url the parent page will be redirected to.
		/// </summary>
		private string parentRedirectUrl = string.Empty;

		/// <summary>
		/// Occurs when save button is clicked in a dialog.
		/// </summary>
		public event EventHandler<DialogEventArgs> DialogEvent;

		/// <summary>
		/// Saves the dialog data. deriving classes should override this method to perform the actual save
		/// operation.
		/// </summary>
		public virtual void OnSave()
		{
		}

		/// <summary>
		/// Called when Ok button is clicked.
		/// </summary>
		public virtual void OnOk()
		{
		}

		/// <summary>
		/// Called when Save and Continue button is clicked.
		/// </summary>
		public virtual void OnSaveAndContinue()
		{
		}

		/// <summary>
		/// Raises a dialog event for the provided data.
		/// </summary>
		/// <param name="sender">The event initializer.</param>
		/// <param name="result">The event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="closeDialog">if set to <c>true</c> closes the dialog.</param>
		public void OnDialogEvent(object sender, DialogEventResult result, string message
				, bool closeDialog)
		{
			DialogEvent(sender, new DialogEventArgs(result, message, closeDialog));
		}

		/// <summary>
		/// Raises a dialog event for the provided data.
		/// </summary>
		/// <param name="sender">The event initializer.</param>
		/// <param name="result">The event type.</param>
		/// <param name="message">The event message.</param>
		public void OnDialogEvent(object sender, DialogEventResult result, string message)
		{
			DialogEvent(sender, new DialogEventArgs(result, message, false));
		}

		/// <summary>
		/// Performs validation and calls saves the data. Dialog host should call this method to save data.
		/// </summary>
		public void SaveData()
		{
			if (Validate())
			{
				OnSave();
			}
		}

		/// <summary>
		/// Performs validation and calls for Save and continue data. Dialog host should call this method 
		/// to save data and continue.
		/// </summary>
		public void SaveAndContinue()
		{
			if (Validate())
			{
				OnSaveAndContinue();
			}
		}

		/// <summary>
		/// Validates the data on the dialog before saving.
		/// </summary>
		/// <returns>Is validated</returns>
		public virtual bool Validate()
		{
			return true;
		}

		/// <summary>
		/// Gets the dialog title.
		/// </summary>
		/// <value>The dialog title.</value>
		public abstract string Title
		{
			get;
		}

		/// <summary>
		/// Gets a value indicating whether the parent page should be refreshed on dialog closing.
		/// </summary>
		/// <value>
		/// true,if parend page should be refreshed; otherwise,false.
		/// </value>
		public virtual bool RefreshParentOnClose
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets or sets the redirect URL for the parent page when the dialog is closed.
		/// </summary>
		/// <value>The redirect URL.</value>
		public string ParentRedirectUrl
		{
			get
			{
				return parentRedirectUrl;
			}

			set
			{
				parentRedirectUrl = value;
			}
		}

		/// <summary>
		/// Gets the buttons that should be displayed in the dialog.
		/// </summary>
		/// <value>The buttons that should be displayed.</value>
		public virtual DialogButtons Buttons
		{
			get
			{
				return DialogButtons.Save | DialogButtons.Cancel;
			}
		}

		/// <summary>
		/// Registers the client call back function..
		/// </summary>
		/// <param name="callbackFunction">The callback function.</param>
		/// <param name="arguments">The arguments.</param>
		public void RegisterClientCallbackFunction(string callbackFunction,
				NameValueCollection arguments)
		{
			if (!string.IsNullOrEmpty(callbackFunction))
			{
				StringBuilder callbackArguments = new StringBuilder();
				callbackArguments.Append("{");
				foreach (string key in arguments.Keys)
				{
					callbackArguments.Append(key + ":'" + arguments[key] + "'");
				}

				callbackArguments.Append("}");

				Page.ClientScript.RegisterStartupScript(typeof(Page), "SetCallBackFunction",
						"parent.$.popupDialog.callback = parent." + callbackFunction + ";" +
						"parent.$.popupDialog.callbackArguments = " + callbackArguments + ";",
						true);
			}
		}

		/// <summary>
		/// Registers the client call back function on dialog close.
		/// </summary>
		public virtual void RegisterClientCallbackFunctionOnDialogClose()
		{

		}

		/// <summary>
		/// Gets the Save and continue button caption.
		/// </summary>
		/// <value>The Save and continue button caption.</value>
		public virtual string SaveAndContinueButtonCaption
		{
			get
			{
				return "Save and Continue";
			}
		}

		/// <summary>
		/// Gets the save button caption.
		/// </summary>
		/// <value>The save button caption.</value>
		public virtual string SaveButtonCaption
		{
			get
			{
				return "Save";
			}
		}

		/// <summary>
		/// Gets the dialog container css class.
		/// </summary>
		/// <value>The dialog container css class.</value>
		public virtual string DialogContainerCssClass
		{
			get
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Gets a value indicating whether clicking on ok button causes client side validation.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if clicking on the ok button causes validation; otherwise, <c>false</c>.
		/// </value>
		public virtual bool CausesValidationOnOkButtonClick
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets a value indicating whether clcking on save and continue button causes clinet side validation.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if clcking on save and continue button causes validation; otherwise, <c>false</c>.
		/// </value>
		public virtual bool CausesValidationOnSaveAndContinueButtonClick
		{
			get
			{
				return true;
			}
		}
	}
}