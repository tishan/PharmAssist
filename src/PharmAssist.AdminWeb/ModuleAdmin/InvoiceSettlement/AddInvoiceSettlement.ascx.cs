using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services.Implementations;
using PharmAssist.Core.Services;
using InvoiceSettlementEntity = PharmAssist.Core.Data.Entities.InvoiceSettlement;

namespace PharmAssist.AdminWeb.ModuleAdmin.InvoiceSettlement
{
	public partial class AddInvoiceSettlement : DialogBase
	{
		IInvoiceService _invoiceService = ServiceFactory.CreateService<InvoiceService>();

		public override string Title
		{
			get { return "Settle Invoice"; }
		}

		public override void OnSave()
		{
			base.OnSave();

			InvoiceSettlementEntity invoiceSettlement = new InvoiceSettlementEntity();

			invoiceSettlement.SettlementId = Convert.ToInt32(txtSettlementId.Text.Trim());
			invoiceSettlement.InvoiceNumber = txtInvoiceNumber.Text.Trim();
			invoiceSettlement.CollectionDate = Convert.ToDateTime(txtCollectionDate.Text.Trim());
			invoiceSettlement.SettlementType = Convert.ToInt32(txtSettlementType.Text.Trim());
			invoiceSettlement.SettlementAmount = Convert.ToDouble(txtSettlementAmount.Text.Trim());
			invoiceSettlement.DepositDate = Convert.ToDateTime(txtDepositDate.Text.Trim());
			//invoiceSettlement.
			//_invoiceService.SaveInvoice(invoice);

			//OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
			//					txtInvoiceNumber.Text + "' is added successfuly.", true);
			return;
		}



	}
}