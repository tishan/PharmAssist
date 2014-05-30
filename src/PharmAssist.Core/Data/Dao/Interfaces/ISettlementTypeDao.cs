using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Interfaces
{
	public interface ISettlementTypeDao : IDao<SettlementType>
	{
		SettlementTypeCollection GetSettlementTypeCollection();
	}
}
