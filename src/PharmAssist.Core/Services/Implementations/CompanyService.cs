using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Dao.Impementations;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Services.Implementations
{
	public class CompanyService : ServiceBase, ICompanyService
	{
		public void SaveCompany(Company company)
		{
			ICompanyDao companyDao = DaoFactory.CreateDao<ICompanyDao>();
			companyDao.Save(company);
		}

		public CompanyCollection GetCompanyList()
		{
			ICompanyDao companyDao = DaoFactory.CreateDao<ICompanyDao>();
			return companyDao.GetCompanyCollection();
		}
	}
}
