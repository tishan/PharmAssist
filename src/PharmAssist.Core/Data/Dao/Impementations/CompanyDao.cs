using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;
using PharmAssist.Core.Data.Dao.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Impementations
{
	public class CompanyDao : BaseDao<Company>, ICompanyDao
	{
		/// <summary>
		/// Name of the Stored Procedure name to insert data.
		/// </summary>
		/// <remarks>This name is used to infer the stored procedure names for basic CRUD operations.
		/// </remarks>
		protected override string InsertStoredProcedureName
		{
			get
			{
				return "pharmAssist_AddCompany";
			}
		}

		/// <summary>
		/// Name of the Stored Procedure name to select data.
		/// </summary>
		/// <remarks>This name is used to infer the stored procedure names for basic CRUD operations.
		/// </remarks>
		protected override string SelectStoredProcedureName
		{
			get
			{
				return "pharmAssist_GetCompanyDetail";
			}
		}

		/// <summary>
		/// Name of the Stored Procedure name to update data.
		/// </summary>
		/// <remarks>This name is used to infer the stored procedure names for basic CRUD operations.
		/// </remarks>
		protected override string UpdateStoredProcedureName
		{
			get
			{
				return "pharmAssist_UpdateCompany";
			}
		}

		/// <summary>
		/// Name of the Stored Procedure name to delete data.
		/// </summary>
		/// <remarks>This name is used to infer the stored procedure names for basic CRUD operations.
		/// </remarks>
		protected override string DeleteStoredProcedureName
		{
			get
			{
				return "pharmAssist_DeleteCompany";
			}
		}

		/// <summary>
		/// Populates a <see cref="User"/> from the passed data reader.
		/// </summary>
		/// <param name="reader">A <see cref="NullableDataReader"/> containing the module record.</param>
		/// <param name="entity">The <see cref="User"/> instance to be populated.</param>
		protected override void PopulateEntityFromReader(NullableDataReader reader, Company entity)
		{
			base.PopulateEntityFromReader(reader, entity);

			entity.CompanyName = reader.GetString("company_name");

		}

		/// <summary>
		/// Adds required parameters to save a <see cref="User"/> instance.
		/// </summary>
		/// <param name="db">The <see cref="Database"/>instance the should be used to create parameters.
		/// </param>
		/// <param name="command">The <see cref="DbCommand"/> that will be populated with parameters.</param>
		/// <param name="entity">The <see cref="User"/> instance that is used to generate the
		/// parameters.</param>
		protected override void PopulateParametersFromEntity(Database db, DbCommand command, Company entity)
		{
			base.PopulateParametersFromEntity(db, command, entity);
			db.AddInParameter(command, "company_name", DbType.String, entity.CompanyName);
		}


		public CompanyCollection GetCompany()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand("pharmAssist_GetCompanyList");

			CompanyCollection companyCollection = new CompanyCollection();
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				while (reader.Read())
				{
					Company company = new Company();
					PopulateEntityFromReader(reader, company);
					companyCollection.Add(company);
				}
			}

			companyCollection.TotalCount = (int)db.GetParameterValue(command, "totalCount");

			return companyCollection;
		}
	}
}
