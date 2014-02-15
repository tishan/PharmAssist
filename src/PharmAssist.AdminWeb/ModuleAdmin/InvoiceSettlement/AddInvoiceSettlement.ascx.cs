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

			invoiceSettlement.settlementId = Convert.ToInt32(txtSettlementId.Text.Trim());
			invoiceSettlement.invoiceNumber = txtInvoiceNumber.Text.Trim();
			invoiceSettlement.collectionDate = Convert.ToDateTime(txtCollectionDate.Text.Trim());
			invoiceSettlement.settlementType = Convert.ToInt32(txtSettlementType.Text.Trim());
			invoiceSettlement.settlementAmount = Convert.ToDouble(txtSettlementAmount.Text.Trim());
			invoiceSettlement.depositDate = Convert.ToDateTime(txtDepositDate.Text.Trim());
			//invoiceSettlement.
			//_invoiceService.SaveInvoice(invoice);

			//OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
			//					txtInvoiceNumber.Text + "' is added successfuly.", true);
			return;
		}



	}
}