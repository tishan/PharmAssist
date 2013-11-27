using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class Settlement: EntityBase
	{
		public string Bank
		{
			get;
			set;
		}

		public string Branch
		{
			get;
			set;
		}

		public int SettlementType
		{
			get;
			set;
		}

		public string ChequeNo
		{
			get;
			set;
		}
	}
}
