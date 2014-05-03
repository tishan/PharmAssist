using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	public class InvoiceDao : BaseDao <Invoice>, IInvoiceDao
	{
		protected override string InsertStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoice_AddInvoice";
			}
		}

		protected override string SelectStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoice_GetInvoiceDetail";
			}
		}

		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoice_UpdateInvoice";
			}
		}

		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoice_DeleteInvoice";
			}
		}

		protected override void PopulateEntityFromReader(NullableDataReader reader, Invoice entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			entity.Id = reader.GetInt32("id");
			entity.InvoiceNumber = reader.GetString("invoice_number");
			entity.InvoiceDate = Convert.ToDateTime(reader.GetDateTime("invoice_date"));
			entity.Amount = Convert.ToDouble(reader.GetString("amount"));
			entity.CustomerId = reader.GetInt32("customer_id");
			entity.CompanyId = reader.GetInt32("company_id");
		}

		public InvoiceCollection GetInvoiceCollection()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand("pharmAssistInvoice_GetInvoiceList");

			InvoiceCollection invoiceCollection = new InvoiceCollection();
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				while (reader.Read())
				{
					Invoice invoice = new Invoice();
					PopulateEntityFromReader(reader, invoice);
					invoiceCollection.Add(invoice);
				}
			}

			return invoiceCollection;
		}

		protected override void PopulateParametersFromEntity(Database db, DbCommand command, Invoice entity)
		{
			base.PopulateParametersFromEntity(db, command, entity);
			db.AddInParameter(command, "invoiceDate", DbType.DateTime, entity.InvoiceDate);
			db.AddInParameter(command, "invoiceNumber", DbType.String, entity.InvoiceNumber);
			db.AddInParameter(command, "amount", DbType.Currency, entity.Amount);
			db.AddInParameter(command, "creditPeriod", DbType.Int32, entity.CreditPeriod);

			if (entity.Id == 0)
			{
				db.AddInParameter(command, "customerId", DbType.Int32, entity.CustomerId);
				db.AddInParameter(command, "companyId", DbType.Int32, entity.CompanyId);
			}
		}
	}
}
