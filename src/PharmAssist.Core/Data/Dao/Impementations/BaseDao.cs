using System;
using System.Data;
using System.Data.Common;
using PharmAssist.Core.Data.Dao.Interfaces;
using PharmAssist.Core.Data.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PharmAssist.Core.Data.Dao.Impementations
{
	/// <summary>
	/// The base class for all data access objects.
	/// </summary>
	/// <typeparam name="T">The entity type that is handled by the data access objects</typeparam>
	/// <remarks>
	/// <para>The entity type should derive from <see cref="EntityBase"/> and must have a parameter less
	/// constructor.</para>
	/// </remarks>
	public abstract class BaseDao<T> : IDao<T> where T : EntityBase, new()
	{
		/// <summary>
		/// Gets the name of the insert stored procedure.
		/// </summary>
		/// <value>The name of the insert stored procedure.</value>
		protected abstract string InsertStoredProcedureName
		{
			get;
		}

		/// <summary>
		/// Gets the name of the select stored procedure.
		/// </summary>
		/// <value>The name of the select stored procedure.</value>
		protected abstract string SelectStoredProcedureName
		{
			get;
		}

		/// <summary>
		/// Gets the name of the update stored procedure.
		/// </summary>
		/// <value>The name of the update stored procedure.</value>
		protected abstract string UpdateStoredProcedureName
		{
			get;
		}

		/// <summary>
		/// Gets the name of the delete stored procedure.
		/// </summary>
		/// <value>The name of the delete stored procedure.</value>
		protected abstract string DeleteStoredProcedureName
		{
			get;
		}

		/// <summary>
		/// Retrieves an entity by its id.
		/// </summary>
		/// <param name="id">The id of the entity.</param>
		/// <returns>An entity of type <typeparamref name="T"/>.</returns>
		public virtual T GetById(int id)
		{
			string storedProcedureName = SelectStoredProcedureName;
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand(storedProcedureName);
			db.AddInParameter(command, "id", DbType.Int32, id);
			T entity = null;
			using (NullableDataReader reader = new NullableDataReader(db.ExecuteReader(command)))
			{
				if (reader.Read())
				{
					entity = new T();
					PopulateEntityFromReader(reader, entity);
				}
			}

			return entity;
		}

		/// <summary>
		/// Saves and entity to the database.
		/// </summary>
		/// <param name="entity">An entity object of type <typeparamref name="T"/> to be saved.</param>
		/// <remarks>
		/// If the entity is new, Inserts to the database else update the database.
		/// When a new entity is inserted, Id property is set after the insertion
		/// </remarks>
		public virtual void Save(T entity)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string storedProcedureName;
			DbCommand command;

			// New entity, Insert into to the entity table
			if (entity.Id == 0)
			{
				storedProcedureName = InsertStoredProcedureName;
				command = db.GetStoredProcCommand(storedProcedureName);
				PopulateParametersFromEntity(db, command, entity);
				db.AddOutParameter(command, "id", DbType.Int32, 4);
				db.AddOutParameter(command, "created", DbType.DateTime, 2);
				db.ExecuteNonQuery(command);
				entity.Id = (int)db.GetParameterValue(command, "id");
				entity.Created = (DateTime)db.GetParameterValue(command, "created");
				entity.Modified = entity.Created;
			}
			else
			{
				storedProcedureName = UpdateStoredProcedureName;
				command = db.GetStoredProcCommand(storedProcedureName);
				db.AddInParameter(command, "@id", DbType.Int32, entity.Id);
				db.AddOutParameter(command, "@modified", DbType.DateTime, 2);
				PopulateParametersFromEntity(db, command, entity);
				db.ExecuteNonQuery(command);
				entity.Modified = (DateTime)db.GetParameterValue(command, "modified");
			}
		}

		/// <summary>
		/// Deletes an entity.
		/// </summary>
		/// <param name="entity">An entity object of type <typeparamref name="T"/> to be saved.</param>
		public virtual void Delete(T entity)
		{
			DeleteById(entity.Id);
		}

		/// <summary>
		/// Deletes an entity by id.
		/// </summary>
		/// <param name="id">The id of the entity to delete.</param>
		public virtual void DeleteById(int id)
		{
			string storedProcedureName = DeleteStoredProcedureName;
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand command = db.GetStoredProcCommand(storedProcedureName);
			db.AddInParameter(command, "id", DbType.Int32, id);
			db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Populates an entity object from a data reader.
		/// </summary>
		/// <param name="reader">The <see cref="NullableDataReader"/> containing the record.</param>
		/// <param name="entity">An entity object of type <typeparamref name="T"/>
		/// that will be populated.</param>
		protected virtual void PopulateEntityFromReader(NullableDataReader reader, T entity)
		{
			entity.Id = reader.GetInt32("id");
			entity.Enabled = reader.GetBoolean("enabled");
			entity.Created = reader.GetDateTime("created");
			entity.Modified = reader.GetDateTime("modified");
		}

		/// <summary>
		///  Adds required parameters to a entity insert or update command.
		/// </summary>
		/// <param name="db">The <see cref="Database"/>instance the should be 
		/// used to create parameters.</param>
		/// <param name="command">The <see cref="DbCommand"/> that will be populated with parameters.</param>
		/// <param name="entity">The entity used to populate parameter.</param>
		protected virtual void PopulateParametersFromEntity(Database db, DbCommand command, T entity)
		{
			db.AddInParameter(command, "enabled", DbType.Boolean, entity.Enabled);
		}
	}
}
