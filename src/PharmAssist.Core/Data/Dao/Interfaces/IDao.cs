using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities;

namespace PharmAssist.Core.Data.Dao.Interfaces
{
    /// <summary>
    /// The base interface for all data access objects.
    /// </summary>
    /// <typeparam name="T">The entity type that is handled by the data access objects</typeparam>
    /// <remarks>
    /// <para>The entity type should derive from <see cref="EntityBase"/> and must have a parameter less
    /// constructor.</para>
    /// </remarks>
    public interface IDao<T> where T : EntityBase, new()
    {
        /// <summary>
        /// Retrieves an entity by its id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>An entity of type <typeparamref name="T"/>.</returns>
        T GetById(int id);

        /// <summary>
        /// Saves and entity to the database.
        /// </summary>
        /// <param name="entity">An entity object of type <typeparamref name="T"/> to be saved.</param>
        /// <remarks>
        /// If the entity is new, Inserts to the database else update the database.
        /// When a new entity is inserted, Id property is set after the insertion.
        /// </remarks>
        void Save(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">An entity object of type <typeparamref name="T"/> to be saved.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes an entity by id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        void DeleteById(int id);
    }
}
