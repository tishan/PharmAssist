using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssist.AdminWeb
{
	public static class PopupControlPath
	{
		/// <summary>
		/// Gets the control path.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>path of the control</returns>
		public static string GetControlPath(PopupControl control)
		{
			string controlPath = string.Empty;

			switch (control)
			{
				case PopupControl.AddCustomer:
					controlPath = "~/ModuleAdmin/Customer/AddCustomer.ascx";
					break;
				case PopupControl.AddInvoice:
					controlPath = "~/ModuleAdmin/Invoice/AddInvoice.ascx";
					break;
				case PopupControl.AddInvoiceSettlement:
					controlPath = "~/ModuleAdmin/InvoiceSettlement/AddInvoiceSettlement.ascx";
					break;
			}

			return controlPath;
		}
	}
}