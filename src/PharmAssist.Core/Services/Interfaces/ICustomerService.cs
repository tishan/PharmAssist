using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Services.Interfaces
{
	public interface ICustomerService
	{
		void SaveCustomer(Customer customer);

		CustomerCollection GetCustomerList();
	}
}
