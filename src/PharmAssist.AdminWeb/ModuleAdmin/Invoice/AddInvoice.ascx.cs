using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Implementations;
using InvoiceEntity = PharmAssist.Core.Data.Entities.Invoice;

namespace PharmAssist.AdminWeb.ModuleAdmin.Invoice
{
	public partial class AddInvoice : DialogBase
	{
		IInvoiceService _invoiceService = ServiceFactory.CreateService<InvoiceService>();

		public override string Title
		{
			get { return "Add Invoice"; }
		}

		public override void OnSave()
		{
			base.OnSave();

			InvoiceEntity invoice = new InvoiceEntity();
			invoice.InvoiceNumber = txtInvoiceNumber.Text.Trim();
			invoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());
			invoice.Amount = Convert.ToDouble(txtAmount.Text.Trim());
			invoice.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text.Trim());

			_invoiceService.SaveInvoice(invoice);

			OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
								txtInvoiceNumber.Text + "' is added successfuly.", true);
			return;
		}
	}
}