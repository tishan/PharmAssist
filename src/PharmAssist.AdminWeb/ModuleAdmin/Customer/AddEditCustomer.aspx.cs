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
	public partial class AddEditCustomer : System.Web.UI.Page
	{
		ICustomerService _customerService = ServiceFactory.CreateService<CustomerService>();

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
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
			
		}
	}
}