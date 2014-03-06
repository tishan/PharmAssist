using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities.Settings;
using PharmAssist.Core.Data.Dao.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using PharmAssist.Core.Data.Entities;
using System.Data;
using PharmAssist.Core.Data.Collection.SettingCollection;
using PharmAssist.Core.Data.Collection;

namespace PharmAssist.Core.Data.Dao.Impementations
{
	public class CustomerDao : BaseDao<Customer>, ICustomerDao
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
				return "pharmAssistCustomer_AddCustomer";
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
				return "pharmAssistCustomer_GetCustomerDetail";
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
				return "pharmAssistCustomer_UpdateCustomer";
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
				return "pharmAssistCustomer_DeleteCustomer";
			}
		}

		/// <summary>
		/// Populates a <see cref="User"/> from the passed data reader.
		/// </summary>
		/// <param name="reader">A <see cref="NullableDataReader"/> containing the module record.</param>
		/// <param name="entity">The <see cref="User"/> instance to be populated.</param>
		protected override void PopulateEntityFromReader(NullableDataReader reader, Customer entity)
		{
			base.PopulateEntityFromReader(reader, entity);
			entity.Id = reader.GetInt32("id");
			entity.CustomerName = reader.GetString("customer_name");
			entity.CutomerBussinessName = reader.GetString("customer_business_name");
			entity.Town = reader.GetString("town");
			entity.Address = reader.GetString("address");
			entity.Telephone = reader.GetString("telephone");
			entity.Mobile = reader.GetString("mobile");
			entity.Email = reader.GetString("email");
			entity.Comments = reader.GetString("comments");
		}

		/// <summary>
		/// Adds required parameters to save a <see cref="User"/> instance.
		/// </summary>
		/// <param name="db">The <see cref="Database"/>instance the should be used to create parameters.
		/// </param>
		/// <param name="command">The <see cref="DbCommand"/> that will be populated with parameters.</param>
		/// <param name="entity">The <see cref="User"/> instance that is used to generate the
		/// parameters.</param>
		protected override void PopulateParametersFromEntity(Database db, DbCommand command, Customer entity)
		{
			base.PopulateParametersFromEntity(db, command, entity);
			db.AddInParameter(command, "customerName", DbType.String, entity.CustomerName);
			db.AddInParameter(command, "customerBussinessName", DbType.String, entity.CutomerBussinessName);
			db.AddInParameter(command, "town", DbType.String, entity.Town);
			db.AddInParameter(command, "address", DbType.String, entity.Address);
			db.AddInParameter(command, "telephone", DbType.String, entity.Telephone);
			db.AddInParameter(command, "mobile", DbType.String, entity.Mobile);
			db.AddInParameter(command, "email", DbType.String, entity.Email);
			db.AddInParameter(command, "comments", DbType.String, entity.Comments);
		}


		public CustomerCollection GetCustomerCollection()
		{
		    Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand("pharmAssistCustomer_GetCustomerList");

			CustomerCollection customerCollection = new CustomerCollection();
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				while (reader.Read())
				{
					Customer customer = new Customer();
					PopulateEntityFromReader(reader, customer);
					customerCollection.Add(customer);
				}
			}

			return customerCollection;
		}

	}
}
