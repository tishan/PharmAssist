using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Dao;

namespace PharmAssist.Core.Services
{
    /// <summary>
    /// Factory class for creating all services.
    /// </summary>
    public static class ServiceFactory
    {
        /// <summary>
        /// Creates a and returns a service.
        /// </summary>
        /// <typeparam name="T"> The type of the service to create.</typeparam>
        /// <returns>Returns the created service</returns>
        public static T CreateService<T>() where T : ServiceBase, new()
        {
            T service = new T();
            service.DaoFactory = new DaoFactory();

            return service;
        }
    }
}
