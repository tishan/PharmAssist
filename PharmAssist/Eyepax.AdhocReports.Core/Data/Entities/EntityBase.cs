using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PharmAssist.Core.Data.Entities
{
	/// <summary>
	/// The base class for all entities.
	/// </summary>
	[Serializable]
	public abstract class EntityBase
	{
		/// <summary>
		/// Gets or sets the id of the entity.
		/// </summary>
		/// <value>An <see cref="int"/> representing the id of the entity record.</value>
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the reated date of the entity.
		/// </summary>
		/// <value>A <see cref="DateTime"/> representing the created date.</value>
		public DateTime Created
		{
			get;
			internal set;
		}

		/// <summary>
		/// Gets the modified date of the entity.
		/// </summary>
		/// <value>A <see cref="DateTime"/> representing the last modified date.</value>
		public DateTime Modified
		{
			get;
			internal set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this entity is enabled.
		/// </summary>
		/// <value>A <see cref="bool"/> indicating the entity is enabled or not.</value>
		public bool Enabled
		{
			get;
			set;
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture,
					"Id = {0}, Created = {1}, Modified = {2}, Enabled = {3}",
					Id, Created, Modified, Enabled);
		}
	}
}
