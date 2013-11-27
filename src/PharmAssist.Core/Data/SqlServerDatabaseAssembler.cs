using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace PharmAssist.Core.Data
{
	/// <summary>
	/// Sqlserver Database Assembler
	/// </summary>
	public class SqlServerDatabaseAssembler 
	{
		#region IDatabaseAssembler Members

		/// <summary>
		/// Assembles the database class from configuration.
		/// </summary>
		/// <param name="name">The name of the database.</param>
		/// <param name="connectionStringSettings">The connection string settings.</param>
		/// <param name="configurationSource">The configuration source.</param>
		/// <returns>The created database instance.</returns>
		public Microsoft.Practices.EnterpriseLibrary.Data.Database Assemble(string name,
				ConnectionStringSettings connectionStringSettings, IConfigurationSource configurationSource)
		{
			return new SqlServerDatabase(connectionStringSettings.ConnectionString);
		}

		#endregion
	}
}
