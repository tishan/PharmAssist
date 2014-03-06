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
using System.Globalization;

namespace PharmAssist.AdminWeb.ModuleAdmin.Customer
{
	public partial class AddCustomer : DialogBase
	{
		ICustomerService _customerService = ServiceFactory.CreateService<CustomerService>();

		public int CustomerId
		{
			get
			{
				if (!string.IsNullOrEmpty(Request.QueryString[QueryStringParameters.CustomerId]))
				{
					return Convert.ToInt32(Request.QueryString[QueryStringParameters.CustomerId],
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
				if(CustomerId > 0)
				{
					LoadCustomer(CustomerId);
				}
			}
		}

		private void LoadCustomer(int customerId)
		{
			CustomerEntity customer = _customerService.GetCustomer(customerId);
			hdfCustomerId.Value = Convert.ToString(customer.Id);
			txtCustomerPersonalName.Text = customer.CustomerName;
			txtTown.Text = customer.Town;
			txtAddress.Text = customer.Address;
			txtComments.Text = customer.Comments;
			txtEmail.Text = customer.Email;
			txtMobile.Text = customer.Mobile;
			txtTelephone.Text = customer.Telephone;
			txtCustomerBusinessName.Text = customer.CutomerBussinessName;
			txtComments.Text = customer.Comments;
		}


		public override string Title
		{
			get
			{
				string title = "Add Customer";

				if (CustomerId > 0)
				{
					title = "Edit Customer";
				}

				return title;
			}
		}

		public override void OnSave()
		{
			base.OnSave();

			CustomerEntity customer = new CustomerEntity();
			customer.Id = Convert.ToInt32(hdfCustomerId.Value);
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