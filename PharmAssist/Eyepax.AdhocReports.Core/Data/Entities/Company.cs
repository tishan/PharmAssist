using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PharmAssist.Core.Data.Entities.Settings;

namespace PharmAssist.Core.Data.Entities
{
	/// <summary>
	/// Entity class for report entity.
	/// </summary>
	public class Company : EntityBase
	{
		/// <summary> 
		/// Gets or seets report name.
		/// </summary>
		public string CompanyName
		{
			get;
			set;
		}

	}
}
