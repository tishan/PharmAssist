using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Interfaces
{
	/// <summary>
	/// Interface for column dao.
	/// </summary>
	public interface ICompanyDao : IDao<Company>
	{
		CompanyCollection GetCompanyCollection();
	}
}
