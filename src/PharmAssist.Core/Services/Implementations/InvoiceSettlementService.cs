using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssist.Core.Services.Interfaces;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Dao.Impementations;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core.Services;


namespace PharmAssist.Core.Services.Implementations
{
	public class InvoiceSettlementService : ServiceBase, IInvoiceSettlementService
	{
		public void SaveInvoice(InvoiceSettlement invoiceSettlement)
		{
			IInvoiceSettlementDao invoiceSettlementDao = DaoFactory.CreateDao<IInvoiceSettlementDao>();
			invoiceSettlementDao.Save(invoiceSettlement);
		}

		public InvoiceSettlementCollection GetInvoiceSettlementList()
		{
			IInvoiceSettlementDao invoiceSettlementDao = DaoFactory.CreateDao<IInvoiceSettlementDao>();
			return invoiceSettlementDao.GetInvoiceSettlementCollection();
		}
	}
}
