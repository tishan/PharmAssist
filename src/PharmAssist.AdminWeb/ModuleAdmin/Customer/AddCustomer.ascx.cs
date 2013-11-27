using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Implementations;
using CustomerEntity = PharmAssist.Core.Data.Entities.Customer;

namespace PharmAssist.AdminWeb.ModuleAdmin.Customer
{
	public partial class AddCustomer : DialogBase
	{
		ICustomerService _customerService = ServiceFactory.CreateService<CustomerService>();


		public override string Title
		{
			get { return "Add Customer"; }
		}

		public override void OnSave()
		{
			base.OnSave();

			CustomerEntity customer = new CustomerEntity();
			customer.CustomerName = txtCustomerPersonalName.Text.Trim();
			customer.CutomerBussinessName = txtCustomerBusinessName.Text.Trim();
			customer.Town = txtTown.Text.Trim();
			customer.Address = txtAddress.Text.Trim();
			customer.Comments = txtComments.Text.Trim();
			customer.Email = txtEmail.Text.Trim();
			customer.Mobile = txtMobile.Text.Trim();
			customer.Telephone = txtTelephone.Text.Trim();

			_customerService.SaveCustomer(customer);

			OnDialogEvent(this, DialogEventResult.Successful, "The selected vendor '" +
								txtCustomerPersonalName.Text + "' is added successfuly.", true);
			return;
		}
	}
}