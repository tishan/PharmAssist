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
using InvoiceSettlementEntity = PharmAssist.Core.Data.Entities.InvoiceSettlement;
using System.Globalization;

namespace PharmAssist.AdminWeb.ModuleAdmin.InvoiceSettlement
{
	public partial class InvoiceSettlementList : System.Web.UI.Page
	{
		IInvoiceSettlementService _invoiceSettlementService = ServiceFactory.CreateService<InvoiceSettlementService>();

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadSettlements();
			lnkAddSettlement.NavigateUrl = Navigation.GetPopupNavigationUrl(
				PopupControl.AddInvoiceSettlement, null);
		}

		private void LoadSettlements()
		{
			InvoiceSettlementCollection invoiceSettlementList = new InvoiceSettlementCollection();
			invoiceSettlementList = _invoiceSettlementService.GetInvoiceSettlementList();

			gvInvoiceSettlementList.DataSource = invoiceSettlementList;
			gvInvoiceSettlementList.DataBind();
		}


		protected void gvInvoiceSettlementList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			InvoiceSettlementEntity invoiceSettlement = e.Row.DataItem as InvoiceSettlementEntity;

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Dictionary<string, string> parameters = new Dictionary<string, string>();
				parameters.Add(QueryStringParameters.InvoiceSettlementId,
						 invoiceSettlement.Id.ToString(CultureInfo.InvariantCulture));

				HyperLink lnkInvoiceSettlementEdit = e.Row.FindControl("lnkInvoiceSettlementEdit") as HyperLink;
				if (lnkInvoiceSettlementEdit != null)
				{
					lnkInvoiceSettlementEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddInvoiceSettlement, null);
					lnkInvoiceSettlementEdit.ImageUrl = "../../Resources/edit-notes.png";
				}
			}
		}
	}
}