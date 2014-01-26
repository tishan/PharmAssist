using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Services.Interfaces
{
	/// <summary>
	/// Interface class for report class.
	/// </summary>
	public interface IInvoiceService
	{
		void SaveInvoice(Invoice invoice);

		InvoiceCollection GetInvoiceList();
	}
}
