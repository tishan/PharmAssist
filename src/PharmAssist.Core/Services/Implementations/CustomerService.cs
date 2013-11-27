using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Dao.Impementations;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Services.Implementations
{
	public class CustomerService: ServiceBase, ICustomerService
	{
		public void SaveCustomer(Customer customer)
		{
			ICustomerDao customerDao = DaoFactory.CreateDao<ICustomerDao>();
			customerDao.Save(customer);
		}

		public CustomerCollection GetCustomerList()
		{
			ICustomerDao customerDao = DaoFactory.CreateDao<ICustomerDao>();
			return customerDao.GetCustomerCollection();
		}
	}
}
