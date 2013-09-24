using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PharmAssist.Core.Data.Collection
{
	/// <summary>
	/// Base class for entity collection.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EntityCollection<T> : Collection<T>
	{

		/// <summary>
		/// Adds the elements in the specified collection to the end of the <see cref="Collection{T}"/>.
		/// </summary>
		/// <param name="collection">The values.</param>
		public void AddRange(IEnumerable<T> collection)
		{
			if (collection != null)
			{
				foreach (T item in collection)
				{
					Add(item);
				}
			}
		}

		/// <summary>
		/// Gets or sets the total count in the database. This value may not be populated from the DAO.
		/// </summary>
		/// <value>The total count.</value>
		public int? TotalCount
		{
			get;
			set;
		}
	}
}
