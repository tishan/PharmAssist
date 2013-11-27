using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Dao;

namespace PharmAssist.Core.Services
{
    /// <summary>
    /// The base class for all services.
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// The <see cref="IDaoFactory"/> that is used to create DAO classes.
        /// </summary>
        public IDaoFactory DaoFactory
        {
            get;
            set;
        }
    }
}
