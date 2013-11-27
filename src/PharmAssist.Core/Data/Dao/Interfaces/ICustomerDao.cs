using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Interfaces
{
	/// <summary>
	/// Interface class for customer dao.
	/// </summary>
	public interface ICustomerDao: IDao<Customer>
	{
		CustomerCollection GetCustomerCollection();
	}
}
