using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmAssist.Core.Data.Entities
{
	public class SettlementType : EntityBase
	{
		public int SettlementTypeId
		{
			get;
			set;
		}

		public string SettlementTypeName
		{
			get;
			set;
		}

	}
}
