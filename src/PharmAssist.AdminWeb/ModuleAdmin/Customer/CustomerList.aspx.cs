using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core.Services.Implementations;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Interfaces;

namespace PharmAssist.AdminWeb.ModuleAdmin.Customer
{
	public partial class CustomerList : System.Web.UI.Page
	{
		ICustomerService _customerService = ServiceFactory.CreateService<CustomerService>();

		protected void Page_Load(object sender, EventArgs e)
		{
			LoadCustomers();
			lnkAddCustomer.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, null);
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
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink lnkCustomerEdit = e.Row.FindControl("lnkCustomerEdit") as HyperLink;
				if (lnkCustomerEdit != null)
				{
					lnkCustomerEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, null);
					lnkCustomerEdit.ImageUrl = "../../Resources/edit-notes.png";
				}
			}
		}


	}
}