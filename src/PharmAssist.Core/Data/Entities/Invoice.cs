using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class Invoice:EntityBase
	{
		public int invoiceId
		{
			get;
			set;
		}

		public DateTime invoiceDate
		{
			get;
			set;
		}

		public string invoiceNumber
		{
			get;
			set;
		}

		public double amount
		{
			get;
			set;
		}

		public int creditPeriod
		{
			get;
			set;
		}



	}
}
