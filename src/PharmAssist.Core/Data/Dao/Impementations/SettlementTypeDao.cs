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
	public class SettlementTypeDao : BaseDao<SettlementType>, ISettlementTypeDao
	{
		protected override string InsertStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_AddSettlementType";
			}
		}

		protected override string SelectStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_GetSettlementType";
			}
		}

		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_UpadteSettlementType";
			}
		}

		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssistInvoiceSettlement_DeleteSettlementType";
			}
		}

		protected override void PopulateEntityFromReader(NullableDataReader reader, SettlementType entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			entity.Id = reader.GetInt32("id");
			entity.SettlementTypeId = reader.GetInt32("settlement_type");
			entity.SettlementTypeName = reader.GetString("settlement_type_name");

		}

		public SettlementTypeCollection GetSettlementTypeCollection()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand("pharmAssistInvoiceSettlement_GetSettlementTypeList");

			SettlementTypeCollection settlementTypeCpllection = new SettlementTypeCollection();
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				while (reader.Read())
				{
					SettlementType settlementType = new SettlementType();
					PopulateEntityFromReader(reader, settlementType);
					settlementTypeCpllection.Add(settlementType);
				}
			}

			return settlementTypeCpllection;
		}

		protected override void PopulateParametersFromEntity(Database db, DbCommand command, SettlementType entity)
		{
			base.PopulateParametersFromEntity(db, command, entity);
		}
	}
}
