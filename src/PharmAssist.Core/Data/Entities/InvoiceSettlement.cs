using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class InvoiceSettlement:EntityBase
	{
		public string InvoiceNumber
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

		public string CompanyName
		{
			get;
			set;
		}

		public string CustomerBusinessName
		{
			get;
			set;
		}

		public float Interest
		{
			get;
			set;
		}

		public int GrnId
		{
			get;
			set;
		}

		public double BalanceAmount
		{
			get;
			set;
		}

		public double TotalOutstandingAmount
		{
			get;
			set;
		}

		public int InvoiceId
		{
			get;
			set;
		}

		public int CompanyId
		{
			get;
			set;
		}

		public int CustomerId
		{
			get;
			set;
		}
	}
}
