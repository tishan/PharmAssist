using System;
using System.Collections.Generic;
using System.Globalization;
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

		public int InvoiceId
		{
			get
			{
				if (!string.IsNullOrEmpty(Request.QueryString[QueryStringParameters.InvoiceId]))
				{
					return Convert.ToInt32(Request.QueryString[QueryStringParameters.InvoiceId],
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

			if(!IsPostBack)
			{
				if (InvoiceId > 0)
				{
					LoadInvoice(InvoiceId);
				}
				else
				{
					LoadDropDownLists();
				}
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

		private void LoadInvoice(int invoiceId)
		{
			InvoiceEntity invoice = _invoiceService.GetInvoice(invoiceId);
			hdfInvoiceId.Value = Convert.ToString(invoice.Id);
			txtInvoiceNumber.Text = Convert.ToString(invoice.InvoiceNumber);
			txtAmount.Text = Convert.ToString(invoice.Amount);
			txtInvoiceDate.Text = Convert.ToString(invoice.InvoiceDate);
			txtCreditPeriod.Text = Convert.ToString(invoice.CreditPeriod);
			ddlCustomer.Items.Insert(0, Convert.ToString(invoice.CustomerId));
			ddlCompany.Items.Insert(0,Convert.ToString(invoice.CompanyId));
			ddlCustomer.Enabled = false;
			ddlCompany.Enabled = false;
		}

		public override void OnSave()
		{
			base.OnSave();

			InvoiceEntity invoice = new InvoiceEntity();
			invoice.Id = Convert.ToInt32(hdfInvoiceId.Value);
			invoice.InvoiceNumber = txtInvoiceNumber.Text.Trim();
			invoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text.Trim());
			invoice.Amount = Convert.ToDouble(txtAmount.Text.Trim());
			invoice.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text.Trim());
			invoice.CustomerId = Convert.ToInt32(ddlCustomer.SelectedValue.Trim());
			invoice.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue.Trim());

			_invoiceService.SaveInvoice(invoice);

			OnDialogEvent(this, DialogEventResult.Successful, "The invoice '" +
								txtInvoiceNumber.Text + "' is saved successfuly.", true);
			return;
		}
	}
}