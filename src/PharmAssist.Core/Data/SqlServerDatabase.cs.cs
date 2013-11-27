using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql.Configuration;

namespace PharmAssist.Core.Data
{
    /// <summary>
    /// Derived database class for enterprise library. The primary purpose is to trap SQL server
    /// specific exceptions and transform them into generic data layer exceptions to prevent 
    /// implementation leaks to layers above.
    /// </summary>
    //[DatabaseAssembler(typeof(SqlServerDatabaseAssembler))]
    [ConfigurationElementType(typeof(SqlDatabaseData))]
    public class SqlServerDatabase : SqlDatabase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDatabase"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlServerDatabase(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Executes a command against the database.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The return value from the command.</returns>
        public override int ExecuteNonQuery(DbCommand command)
        {
            try
            {
                return base.ExecuteNonQuery(command);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database within a given transaction.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="transaction">The database transaction.</param>
        /// <returns>The return value from the command.</returns>
        public override int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            try
            {
                return base.ExecuteNonQuery(command, transaction);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database and returns a data reader.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The result data reader.</returns>
        public override IDataReader ExecuteReader(DbCommand command)
        {
            try
            {
                return base.ExecuteReader(command);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database within a given transaction and returns a data reader.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="transaction">The database transaction.</param>
        /// <returns>The result data reader.</returns>
        public override IDataReader ExecuteReader(DbCommand command, DbTransaction transaction)
        {
            try
            {
                return base.ExecuteReader(command, transaction);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database and returns a single value result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The result value.</returns>
        public override object ExecuteScalar(DbCommand command)
        {
            try
            {
                return base.ExecuteScalar(command);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database within a given transaction
        /// and returns a single value result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>The result value.</returns>
        public override object ExecuteScalar(DbCommand command, DbTransaction transaction)
        {
            try
            {
                return base.ExecuteScalar(command, transaction);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database and returns a dataset result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The result value.</returns>
        public override DataSet ExecuteDataSet(DbCommand command)
        {
            try
            {
                return base.ExecuteDataSet(command);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }

        /// <summary>
        /// Executes a command against the database within a given transaction
        /// and returns a single value result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>The result dataset.</returns>
        public override DataSet ExecuteDataSet(DbCommand command, DbTransaction transaction)
        {
            try
            {
                return base.ExecuteDataSet(command, transaction);
            }
            catch (SqlException ex)
            {
                throw ExceptionHelper.CreateDataException(ex);
            }
        }
    }
}
