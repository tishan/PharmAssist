﻿using System;
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
				return "pharmAssist_GetInvoiceSettlementDetail";
			}
		}

		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssist_UpadteInvoiceSettlement";
			}
		}

		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssist_DeleteInvoiceSettlement";
			}
		}

		protected override void PopulateEntityFromReader(NullableDataReader reader, InvoiceSettlement entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			entity.InvoiceId = Convert.ToInt32(reader.GetString("invoice_id"));
			entity.CollectionDate = Convert.ToDateTime(reader.GetString("collection_date"));
			entity.SettlementAmount = Convert.ToDouble(reader.GetString("settlement_amount"));
			entity.SettlementId = Convert.ToInt32(reader.GetString("settlement_id"));
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
			//db.AddInParameter(command, "invoice_id", DbType.String, entity.InvoiceId);
			//db.AddInParameter(command, "invoice_number", DbType.String, entity.InvoiceNumber);
			//db.AddInParameter(command, "invoice_date", DbType.String, entity.InvoiceDate);
			//db.AddInParameter(command, "amount", DbType.String, entity.Amount);
		}
	}
}