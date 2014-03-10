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
using InvoiceEntity = PharmAssist.Core.Data.Entities.Invoice;
using System.Globalization;

namespace PharmAssist.AdminWeb.ModuleAdmin.Invoice
{
	public partial class InvoiceList : System.Web.UI.Page
	{
		IInvoiceService _invoiceService = ServiceFactory.CreateService<InvoiceService>();

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadInvoices();
			lnkAddInvoice.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddInvoice, null);
		}

		private void LoadInvoices()
		{
			InvoiceCollection invoiceList = new InvoiceCollection();
			invoiceList = _invoiceService.GetInvoiceList();

			gvInvoiceList.DataSource = invoiceList;
			gvInvoiceList.DataBind();
		}

		protected void gvInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			 InvoiceEntity invoice = e.Row.DataItem as InvoiceEntity;

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Dictionary<string, string> parameters = new Dictionary<string, string>();
				parameters.Add(QueryStringParameters.InvoiceId,
						 invoice.Id.ToString(CultureInfo.InvariantCulture));

				HyperLink lnkInvoiceEdit = e.Row.FindControl("lnkInvoiceEdit") as HyperLink;
				if (lnkInvoiceEdit != null)
				{
					lnkInvoiceEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddInvoice, parameters);
					lnkInvoiceEdit.ImageUrl = "../../Resources/edit-notes.png";
				}
			}
		}

		protected void lnkAddInvoice_DataBinding(object sender, EventArgs e)
		{

		}
	}
}