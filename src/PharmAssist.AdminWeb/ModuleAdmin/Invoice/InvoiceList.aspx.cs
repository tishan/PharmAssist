using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Implementations;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.AdminWeb.ModuleAdmin.Invoice
{
	public partial class InvoiceList : System.Web.UI.Page
	{
		IInvoiceService _invoiceService = ServiceFactory.CreateService<InvoiceService>();

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadInvoices();
		}

		private void LoadInvoices()
		{
			InvoiceCollection customerList = new InvoiceCollection();
			customerList = _invoiceService.GetInvoiceList();

			gvInvoiceList.DataSource = customerList;
			gvInvoiceList.DataBind();
		}

		protected void gvInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink lnkCustomerEdit = e.Row.FindControl("lnkInvoiceEdit") as HyperLink;
				if (lnkCustomerEdit != null)
				{
					lnkCustomerEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, null);
				}
			}
		}
	}
}