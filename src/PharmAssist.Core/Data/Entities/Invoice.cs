﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Entities
{
	public class Invoice:EntityBase
	{
		public DateTime InvoiceDate
		{
			get;
			set;
		}

		public string InvoiceNumber
		{
			get;
			set;
		}

		public double Amount
		{
			get;
			set;
		}

		public int CreditPeriod
		{
			get;
			set;
		}

		public int CustomerId
		{
			get;
			set;
		}

		public int CompanyId
		{
			get;
			set;
		}

	}
}
