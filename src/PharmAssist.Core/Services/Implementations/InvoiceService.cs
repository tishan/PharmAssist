using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Dao.Impementations;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core.Services;

namespace PharmAssist.Core.Services.Implementations
{
	public class InvoiceService : ServiceBase, IInvoiceService
	{
		public void SaveInvoice(Invoice invoice)
		{
			IInvoiceDao invoiceDao = DaoFactory.CreateDao<IInvoiceDao>();
			invoiceDao.Save(invoice);
		}
		public  InvoiceCollection GetInvoiceList()
		{
			IInvoiceDao invoiceDao = DaoFactory.CreateDao<IInvoiceDao>();
			return invoiceDao.GetInvoiceCollection();
		}

		public Invoice  GetInvoice(int invoiceid)
		{
			IInvoiceDao invoiceDao = DaoFactory.CreateDao<IInvoiceDao>();
			return invoiceDao.GetById(invoiceid);
		}
	}
}
