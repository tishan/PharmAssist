using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Services.Interfaces
{
	public interface IInvoiceSettlementService
	{
		void SaveInvoice(InvoiceSettlement invoiceSettlement);

		InvoiceSettlementCollection GetInvoiceSettlementList();
	}
}
