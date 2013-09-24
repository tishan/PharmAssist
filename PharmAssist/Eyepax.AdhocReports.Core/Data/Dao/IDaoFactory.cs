using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmAssist.Core.Data.Dao
{
    /// <summary>
    /// The interface implemented by a concreta DAO factory.
    /// </summary>
    public interface IDaoFactory
    {
        /// <summary>
        /// Creates a concrete DAO class given a DAO interface.
        /// </summary>
        /// <typeparam name="T">A dal interface type derived from <see cref="IDao{T}"/>.</typeparam>
        /// <returns>A concrete DAO class.</returns>
        T CreateDao<T>();
    }
}
