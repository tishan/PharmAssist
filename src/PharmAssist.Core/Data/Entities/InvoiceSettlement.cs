using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class InvoiceSettlement:EntityBase
	{
		public string invoiceNumber
		{
			get;
			set;
		}

		public DateTime collectionDate
		{
			get;
			set;
		}

		public int settlementType
		{
			get;
			set;
		}

		public DateTime depositDate
		{
			get;
			set;
		}

		public double settlementAmount
		{
			get;
			set;
		}

		public int settlementId
		{
			get;
			set;
		}
	}
}
