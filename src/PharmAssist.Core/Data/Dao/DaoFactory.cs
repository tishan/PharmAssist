using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PharmAssist.Core.Data.Dao
{
    /// <summary>
    /// The factory class that creates DAO classes.
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        /// <summary>
        /// The dictionary containing the contructor information of DAO classes.
        /// </summary>
        private static Dictionary<Type, ConstructorInfo> _daoConstructors =
                new Dictionary<Type, ConstructorInfo>();

        /// <summary>
        /// Initializes static members of the <see cref="DaoFactory"/> class.
        /// </summary>
        static DaoFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());

            foreach (Type type in assembly.GetTypes())
            {
                Type[] interfaces = type.GetInterfaces();
                Type daoInterfaceType = null;
                bool daoInterfaceFound = false;

                // This code relies on the fact that DAO classes only implements 2 interfaces.
                if (interfaces.Length == 2)
                {
                    if (interfaces[0].Name == "IDao`1")
                    {
                        daoInterfaceType = interfaces[1];
                        daoInterfaceFound = true;
                    }
                    else if (interfaces[1].Name == "IDao`1")
                    {
                        daoInterfaceType = interfaces[0];
                        daoInterfaceFound = true;
                    }

                    if (daoInterfaceFound)
                    {
                        ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                        _daoConstructors.Add(daoInterfaceType, constructor);

                    }
                }
            }
        }

        /// <summary>
        /// Creates and return a DAO class.
        /// </summary>
        /// <typeparam name="T">The <see cref="IDao{T}"/> derived Dao interface
        /// type of the DAO class.</typeparam>
        /// <returns>A instance of <see cref="BaseDao{T}"/> derived DAO.</returns>
        public T CreateDao<T>()
        {
            ConstructorInfo constructor = _daoConstructors[typeof(T)];
            return (T)constructor.Invoke(new object[] { });
        }
    }
}
