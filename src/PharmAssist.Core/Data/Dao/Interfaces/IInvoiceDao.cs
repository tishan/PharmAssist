using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Interfaces
{
	/// <summary>
	/// Interfcae class for invoice dao class.
	/// </summary>
	public interface IInvoiceDao: IDao<Invoice>
	{
		InvoiceCollection GetInvoiceCollection();
	}
}
