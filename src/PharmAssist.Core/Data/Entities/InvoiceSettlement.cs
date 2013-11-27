using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class InvoiceSettlement:EntityBase
	{
		public int InvoiceId
		{
			get;
			set;
		}

		public DateTime CollectionDate
		{
			get;
			set;
		}

		public int SettlementType
		{
			get;
			set;
		}

		public DateTime DepositDate
		{
			get;
			set;
		}

		public double SettlementAmount
		{
			get;
			set;
		}

		public int SettlementId
		{
			get;
			set;
		}
	}
}
