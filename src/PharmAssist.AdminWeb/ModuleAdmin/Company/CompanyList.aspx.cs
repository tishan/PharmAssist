using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services.Implementations;
using PharmAssist.Core.Services;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.AdminWeb.ModuleAdmin.Company
{
	public partial class CompanyList : System.Web.UI.Page
	{
		ICompanyService _companyService = ServiceFactory.CreateService<CompanyService>();
	
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadCustomers();
			lnkAddCompany.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, null);
		}

		private void LoadCustomers()
		{
			CompanyCollection companyList = new CompanyCollection();
			companyList = _companyService.GetCompanyList();

			gvCompanyList.DataSource = companyList;
			gvCompanyList.DataBind();
		}

		protected void gvCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink lnkCompanyEdit = e.Row.FindControl("lnkCompanyEdit") as HyperLink;
				if (lnkCompanyEdit != null)
				{
					lnkCompanyEdit.NavigateUrl = Navigation.GetPopupNavigationUrl(
							PopupControl.AddCustomer, null);
					lnkCompanyEdit.ImageUrl = "../../Resources/edit-notes.png";
				}
			}
		}

	}
}