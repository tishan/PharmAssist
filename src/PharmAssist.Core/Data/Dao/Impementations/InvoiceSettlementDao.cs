using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Dao.Impementations;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PharmAssist.Core.Data.Entities;
using System.Data;
using PharmAssist.Core.Data.Collection.SettingCollection;
using PharmAssist.Core.Data.Collection;
using PharmAssist.Core;

namespace PharmAssist.Core.Data.Dao.Impementations
{
	public class InvoiceSettlementDao : BaseDao<InvoiceSettlement>, IInvoiceSettlementDao
	{
		protected override string InsertStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_AddInvoiceSettlement";
			}
		}

		protected override string SelectStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_GetInvoiceSettlementDetail";
			}
		}

		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_UpadteInvoiceSettlement";
			}
		}

		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_DeleteInvoiceSettlement";
			}
		}

		protected override void PopulateEntityFromReader(NullableDataReader reader, InvoiceSettlement entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			entity.Id = reader.GetInt32("id");
			entity.InvoiceNumber =reader.GetString("invoice_id");
			entity.CollectionDate = Convert.ToDateTime(reader.GetString("collection_date"));
			entity.SettlementAmount = Convert.ToDouble(reader.GetString("settlement_amount"));
		}

		public InvoiceSettlementCollection GetInvoiceSettlementCollection()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand("pharmAssistInvoiceSettlement_GetInvoiceSettlementList");

			InvoiceSettlementCollection invoiceCollection = new InvoiceSettlementCollection();
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				while (reader.Read())
				{
					InvoiceSettlement invoiceSettlement = new InvoiceSettlement();
					PopulateEntityFromReader(reader, invoiceSettlement);
					invoiceCollection.Add(invoiceSettlement);
				}
			}

			return invoiceCollection;
		}

		protected override void PopulateParametersFromEntity(Database db, DbCommand command, InvoiceSettlement entity)
		{
			base.PopulateParametersFromEntity(db, command, entity);
		}
	}
}
