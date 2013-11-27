using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.AdminWeb.Helpers;
using System.Globalization;

namespace PharmAssist.AdminWeb
{
	/// <summary>
	/// Page that hosts all popup dialogs.
	/// </summary>
	public partial class DialogHost : System.Web.UI.Page
	{
		/// <summary>
		/// The dialog hosted by this page.
		/// </summary>
		private DialogBase _dialog;

		/// <summary>
		/// Flag indicating if the dialog is going to close;
		/// </summary>
		private bool _dialogClosing;

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Page.PreInit"/> event at the beginning of page initialization.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			_dialog = LoadDialog();
			DialogButtons buttons = _dialog.Buttons;

			if ((buttons & DialogButtons.Cancel) > 0)
			{
				btnCancel.Visible = true;
			}

			if ((buttons & DialogButtons.Close) > 0)
			{
				btnClose.Visible = true;
			}

			if ((buttons & DialogButtons.Ok) > 0)
			{
				btnOk.Visible = true;
				btnOk.CausesValidation = _dialog.CausesValidationOnOkButtonClick;
			}

			if ((buttons & DialogButtons.Save) > 0)
			{
				btnSave.Visible = true;
				btnSave.Text = _dialog.SaveButtonCaption;
			}

			if ((buttons & DialogButtons.SaveAndContinue) > 0)
			{
				btnSaveAndContinue.Visible = true;
				btnSaveAndContinue.Text = _dialog.SaveAndContinueButtonCaption;
				btnSaveAndContinue.CausesValidation = _dialog.CausesValidationOnSaveAndContinueButtonClick;
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (!_dialogClosing)
			{
				if (NotifyHelper.HasMessage())
				{
					if (!Page.ClientScript.IsStartupScriptRegistered("NotifyMessageScript"))
					{
						Page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page),
							"NotifyMessageScript",
							NotifyHelper.GetMessageScript(), true);
					}

					NotifyHelper.ClearMessage();
				}
			}
			else
			{
				if (!_dialog.RefreshParentOnClose)
				{
					if (NotifyHelper.HasMessage())
					{
						if (!Page.ClientScript.IsStartupScriptRegistered("NotifyMessageScript"))
						{
							Page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page),
								"NotifyMessageScript",
								NotifyHelper.GetParentMessageScript(), true);
						}
					}

					NotifyHelper.ClearMessage();
				}
			}

			ltlTitle.Text = _dialog.Title;

			if (!Page.ClientScript.IsStartupScriptRegistered(typeof(System.Web.UI.Page),
				"SetDialogProperties"))
			{
				string script = "parent.$.popupDialog.refreshAfterClose = " +
						_dialog.RefreshParentOnClose.ToString(CultureInfo.InvariantCulture).ToLower(
						CultureInfo.InvariantCulture) + ";" +
						"parent.$.popupDialog.redirectUrl = \"" +
						ResolveUrl(_dialog.ParentRedirectUrl.ToString(
						CultureInfo.InvariantCulture).ToLowerInvariant()) + "\";";

				Page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page),
						"SetDialogProperties",
						script, true);
			}

			SetDialogContainerCssClass();
		}

		/// <summary>
		/// Sets the dialog container css class.
		/// </summary>
		private void SetDialogContainerCssClass()
		{
			if (!string.IsNullOrEmpty(_dialog.DialogContainerCssClass))
			{
				string currentCssClass = dialogContainer.Attributes["class"];
				string newCssClass = currentCssClass + " " + _dialog.DialogContainerCssClass;
				dialogContainer.Attributes["class"] = newCssClass;
			}
		}

		/// <summary>
		/// Loads the control.
		/// </summary>
		/// <returns>The base control.</returns>
		private DialogBase LoadDialog()
		{
			PopupControl popup =
					(PopupControl)int.Parse(Request.QueryString[QueryStringParameters.PopupControlId],
					CultureInfo.InvariantCulture);
			string controlPath = PopupControlPath.GetControlPath(popup);

			Control control = LoadControl(controlPath);

			if (control != null)
			{
				//control.ID = "PopupControl";
				//DialogSettingBase settingBase = control as DialogSettingBase;
				//if (settingBase != null)
				//{
				//    settingBase.ModuleInstanceId = int.Parse(
				//            Request.QueryString[QueryStringParameters.ModuleInstanceId],
				//            CultureInfo.InvariantCulture);
				//}

				phPopupContainer.Controls.Clear();
				phPopupContainer.Controls.Add(control);
			}

			DialogBase dialogBase = (DialogBase)control;
			dialogBase.DialogEvent += new EventHandler<DialogEventArgs>(DialogEvent_Raised);
			return dialogBase;
		}

		/// <summary>
		/// Handles the Raised event of the DialogEvent control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="VerticalPlatform.Admin.Web.UI.DialogEventArgs"/> 
		/// instance containing the event data.</param>
		protected void DialogEvent_Raised(object sender, DialogEventArgs e)
		{
			string messageType = NotifyHelper.Ok;
			switch (e.Result)
			{
				case DialogEventResult.Successful:
				case DialogEventResult.Close:
					messageType = NotifyHelper.Ok;
					break;
				case DialogEventResult.Failed:
					messageType = NotifyHelper.Error;
					break;
				case DialogEventResult.Warning:
					messageType = NotifyHelper.Warning;
					break;
			}

			if (e.CloseDialog)
			{
				_dialogClosing = true;
				RegisterCloseDialogScript();
			}

			NotifyHelper.SetMessage(e.Message, messageType);
		}

		/// <summary>
		/// Registers the close dialog script.
		/// </summary>
		private void RegisterCloseDialogScript()
		{
			_dialog.RegisterClientCallbackFunctionOnDialogClose();
			Page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "CloseDialog",
					"parent.$.popupDialog.close();", true);
		}

		/// <summary>
		/// Handles the Click event of the btnSave control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnSave_Click(object sender, EventArgs e)
		{
			_dialog.SaveData();
		}

		/// <summary>
		/// Handles the Click event of the btnOk control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnOk_Click(object sender, EventArgs e)
		{
			_dialog.OnOk();
		}

		/// <summary>
		/// Handles the Click event of the btnSaveAndContinue control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnSaveAndContinue_Click(object sender, EventArgs e)
		{
			_dialog.SaveAndContinue();
		}
	}
}