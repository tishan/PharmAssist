using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Services;
using PharmAssist.Core.Services.Implementations;
using CompanyEntity = PharmAssist.Core.Data.Entities.Company;


namespace PharmAssist.AdminWeb.ModuleAdmin.Company
{
	public partial class AddCompany : DialogBase
	{
		ICompanyService _companyService = ServiceFactory.CreateService<CompanyService>();

		public override string Title
		{
			get { return "Add Company"; }
		}

		public override void OnSave()
		{
			base.OnSave();

			CompanyEntity company = new CompanyEntity();
			company.CompanyCode = txtCompanyCode.Text.Trim();
			company.CompanyName = txtCompanyName.Text.Trim();
			
			_companyService.SaveCompany(company);

			OnDialogEvent(this, DialogEventResult.Successful, "The selected vendor '" +
								txtCompanyName.Text + "' is added successfuly.", true);
			return;
		}
		
	}
}