using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssist.AdminWeb
{
	/// <summary>
	/// Specifies a dialog event result.
	/// </summary>
	public enum DialogEventResult
	{
		/// <summary>
		/// No result is available.
		/// </summary>
		None = 0,

		/// <summary>
		/// Dialog event was successful.
		/// </summary>
		Successful = 1,

		/// <summary>
		/// Dialog event failed.
		/// </summary>
		Failed = 2,

		/// <summary>
		/// Close Dialog.
		/// </summary>
		Close = 3,

		/// <summary>
		/// Dialog event raised a warning.
		/// </summary>
		Warning = 4
	}
}