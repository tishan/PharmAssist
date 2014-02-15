using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core.Services.Implementations;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Interfaces;

using CustomerEntity = PharmAssist.Core.Data.Entities.Customer;

namespace PharmAssist.AdminWeb.ModuleAdmin.Customer
{
	public partial class CustomerList : System.Web.UI.Page
	{
		ICustomerService _customerService = ServiceFactory.CreateService<CustomerService>();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadCustomers();
				lnkAddCustomer.NavigateUrl = Navigation.GetPopupNavigationUrl(
					PopupControl.AddCustomer, null);
			}
		}

		private void LoadCustomers()
		{
			CustomerCollection customerList = new CustomerCollection();
			customerList = _customerService.GetCustomerList();

			gvCustomerList.DataSource = customerList;
			gvCustomerList.DataBind();
		}

		protected void gvCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			CustomerEntity cutomer = e.Row.DataItem as CustomerEntity;

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink lnkCustomerEdit = e.Row.FindControl("lnkCustomerEdit") as HyperLink;
				if (lnkCustomerEdit != null)
				{
					Dictionary<string, string> parameters = new Dictionary<string, string>();
					parameters.Add(QueryStringParameters.CustomerId,
							 cutomer.Id.ToString(CultureInfo.InvariantCulture));

					lnkCustomerEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, parameters);
					lnkCustomerEdit.ImageUrl = "../../Resources/edit-notes.png";

					
				}

				LinkButton lbtnDelete = e.Row.FindControl("lbtnDelete") as LinkButton;
				if (lbtnDelete != null)
				{
					if (cutomer != null)
					{
						lbtnDelete.CommandArgument = cutomer.Id.ToString(CultureInfo.InvariantCulture);
					}
				}
			}	
		}

		protected void gvCustomerList_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "DeleteCustomer")
			{
				int customerId = Convert.ToInt32(e.CommandArgument, CultureInfo.InvariantCulture);
				_customerService.DeleteCustomer(customerId);
				LoadCustomers();
			}
		}

	}
}