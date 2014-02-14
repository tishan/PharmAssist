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

namespace PharmAssiost.Core.Data.Dao.Impementations
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
				return "pharmAssist_GetInvoiceDetail";
			}
		}

		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssist_UpadteInvoice";
			}
		}

		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssist_DeleteCustomer";
			}
		}

		protected override void PopulateEntityFromReader(NullableDataReader reader, Invoice entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			//entity.invoiceId = Convert.ToInt32(reader.GetString("id"));
			entity.invoiceNumber = reader.GetString("invoice_number");
			entity.invoiceDate = Convert.ToDateTime(reader.GetDateTime("invoice_date"));
			entity.amount = Convert.ToDouble(reader.GetString("amount"));
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
			db.AddInParameter(command, "invoiceDate", DbType.String, entity.invoiceDate);
			db.AddInParameter(command, "invoiceNumber", DbType.String, entity.invoiceNumber);			
			db.AddInParameter(command, "amount", DbType.String, entity.amount);
			db.AddInParameter(command, "creditPeriod", DbType.Currency, entity.creditPeriod);
		}
	}
}
