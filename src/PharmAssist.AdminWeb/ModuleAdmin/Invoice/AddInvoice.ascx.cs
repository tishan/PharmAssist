using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Implementations;
using InvoiceEntity = PharmAssist.Core.Data.Entities.Invoice;

namespace PharmAssist.AdminWeb.ModuleAdmin.Invoice
{
	public partial class AddInvoice : DialogBase
	{
		IInvoiceService _invoiceService = ServiceFactory.CreateService<InvoiceService>();

		/// <summary>
		/// Default value for specification type
		/// </summary>
		private const string DefaultValueForDropdown = "-100";

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if(!IsPostBack)
			{
				LoadDropDownLists();
			}
		}

		public override string Title
		{
			get { return "Add Invoice"; }
		}

		private  void LoadDropDownLists()
		{
			ICustomerService customerService = ServiceFactory.CreateService<CustomerService>();
			CustomerCollection customerCollection = customerService.GetCustomerList();

			ddlCustomer.DataTextField = "CustomerName";
			ddlCustomer.DataValueField = "Id";

			ddlCustomer.DataSource = customerCollection;
			ddlCustomer.DataBind();
			ddlCustomer.Items.Insert(
					0, new ListItem("-Select Customer-", DefaultValueForDropdown));

			ICompanyService companyService = ServiceFactory.CreateService<CompanyService>();
			CompanyCollection companyCollection = companyService.GetCompanyList();

			ddlCompany.DataTextField = "CompanyName";
			ddlCompany.DataValueField = "Id";

			ddlCompany.DataSource = companyCollection;
			ddlCompany.DataBind();
			ddlCompany.Items.Insert(
					0, new ListItem("-Select Company-", DefaultValueForDropdown));


		}

		public override void OnSave()
		{
			base.OnSave();

			InvoiceEntity invoice = new InvoiceEntity();
			invoice.InvoiceNumber = txtInvoiceNumber.Text.Trim();
			invoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());
			invoice.Amount = Convert.ToDouble(txtAmount.Text.Trim());
			invoice.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text.Trim());
			invoice.CustomerId = Convert.ToInt32(ddlCustomer.SelectedValue.Trim());
			invoice.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue.Trim());

			_invoiceService.SaveInvoice(invoice);

			OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
								txtInvoiceNumber.Text + "' is added successfuly.", true);
			return;
		}
	}
}