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
using System.Globalization;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.AdminWeb.ModuleAdmin.InvoiceSettlement
{
	public partial class AddInvoiceSettlement : DialogBase
	{
		IInvoiceSettlementService _invoiceSettlementService = ServiceFactory.CreateService<InvoiceSettlementService>();
		private const string DefaultValueForDropdown = "-100";

		public override string Title
		{
			get { return "Settle Invoice"; }
		}

		public int InvoiceSettlementId
		{
			get
			{
				if (!string.IsNullOrEmpty(Request.QueryString[QueryStringParameters.InvoiceSettlementId]))
				{
					return Convert.ToInt32(Request.QueryString[QueryStringParameters.InvoiceSettlementId],
							CultureInfo.InvariantCulture);
				}
				else
				{
					return 0;
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!IsPostBack)
			{
				if (InvoiceSettlementId  > 0)
				{
					LoadInvoiceSettlement(InvoiceSettlementId);
				}
				else
				{
					LoadDropDownLists();
				}
			}

		}

		private void LoadDropDownLists()
		{
			ICustomerService customerService = ServiceFactory.CreateService<CustomerService>();
			CustomerCollection customerCollection = customerService.GetCustomerList();

			ddlCustomerBusinessName.DataTextField = "CustomerName";
			ddlCustomerBusinessName.DataValueField = "Id";

			ddlCustomerBusinessName.DataSource = customerCollection;
			ddlCustomerBusinessName.DataBind();
			ddlCustomerBusinessName.Items.Insert(
					0, new ListItem("-Select Customer-", DefaultValueForDropdown));

			ICompanyService companyService = ServiceFactory.CreateService<CompanyService>();
			CompanyCollection companyCollection = companyService.GetCompanyList();

			ddlCompanyName.DataTextField = "CompanyName";
			ddlCompanyName.DataValueField = "Id";

			ddlCompanyName.DataSource = companyCollection;
			ddlCompanyName.DataBind();
			ddlCompanyName.Items.Insert(
					0, new ListItem("-Select Company-", DefaultValueForDropdown));


			//this list should be filled with retreiving the collection dynamically from the database from  the stelement type

			ddlCollectionType.Items.Insert(0, new ListItem("-Collection Type-"));
			ddlCollectionType.Items.Insert(1, new ListItem("Cash"));
			ddlCollectionType.Items.Insert(2, new ListItem("Cheque"));

		}

		public override void OnSave()
		{
			base.OnSave();

			InvoiceSettlementEntity invoiceSettlement = new InvoiceSettlementEntity();

			invoiceSettlement.SettlementId = Convert.ToInt32(hdfInvoiceSettlmentId.Value);
			invoiceSettlement.CollectionDate = Convert.ToDateTime(txtCollectionDate.Text.Trim());
			invoiceSettlement.SettlementType = Convert.ToInt32(ddlInvoiceNumber.SelectedIndex);
			invoiceSettlement.SettlementAmount = Convert.ToDouble(txtSettlementAmount.Text.Trim());
			invoiceSettlement.DepositDate = Convert.ToDateTime(txtDepositDate.Text.Trim());
			invoiceSettlement.Interest = (float)Convert.ToDouble(txtInterest.Text.Trim());
			invoiceSettlement.GrnId = Convert.ToInt32(txtInterest.Text.Trim());
			invoiceSettlement.BalanceAmount = Convert.ToDouble(txtBalanceAmount.Text.Trim());
			invoiceSettlement.TotalOutstandingAmount = Convert.ToDouble(txtTotalOutstading.Text.Trim());

			//Need to obtain the invoice id via a query from the invoice number, from the invoice table
			//and it should be applicable for the other two fields as well.
			invoiceSettlement.InvoiceId = Convert.ToInt32(ddlInvoiceNumber.SelectedValue.Trim());
			invoiceSettlement.CustomerId =  Convert.ToInt32(ddlCustomerBusinessName.SelectedValue.Trim());
			invoiceSettlement.CompanyId = Convert.ToInt32(ddlCompanyName.SelectedValue.Trim());

			_invoiceSettlementService.SaveInvoice(invoiceSettlement);

			OnDialogEvent(this, DialogEventResult.Successful, "The settlement for invoice number'" +
								ddlInvoiceNumber.SelectedValue.Trim() + "' is saved successfuly.", true);
			//_invoiceService.SaveInvoice(invoice);

			//OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
			//					txtInvoiceNumber.Text + "' is added successfuly.", true);
			return;
		}

		private void LoadInvoiceSettlement(int invoiceSettlementId)
		{
			InvoiceSettlementEntity invoiceSettlement = _invoiceSettlementService.GetInvoiceSettlement(invoiceSettlementId);
			hdfInvoiceSettlmentId.Value = Convert.ToString(invoiceSettlement.Id);
			ddlInvoiceNumber.Items.Insert(0, Convert.ToString(invoiceSettlement.InvoiceNumber));
			ddlCustomerBusinessName.Items.Insert(0, Convert.ToString(invoiceSettlement.CustomerId));
			ddlCompanyName.Items.Insert(0, Convert.ToString(invoiceSettlement.CompanyId));
			ddlCustomerBusinessName.Enabled = false;
			ddlCompanyName.Enabled = false;
		}

		protected void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlCompanyName.SelectedIndex > 0 && ddlCustomerBusinessName.SelectedIndex > 0)
			{
				IInvoiceService invoiceService = ServiceFactory.CreateService<InvoiceService>();
				InvoiceCollection invoiceCollection = invoiceService.GetFilteredInvoiceList(Convert.ToInt32 (ddlCompanyName.SelectedValue),Convert.ToInt32 ( ddlCustomerBusinessName.SelectedValue));

				ddlInvoiceNumber.DataTextField = "InvoiceNumber";
				ddlInvoiceNumber.DataValueField = "Id";

				ddlInvoiceNumber.DataSource = invoiceCollection;
				ddlInvoiceNumber.DataBind();
				ddlInvoiceNumber.Items.Insert(
						0, new ListItem("-Select Invoice-", DefaultValueForDropdown));
			}
		}



	}
}