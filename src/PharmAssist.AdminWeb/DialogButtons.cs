using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmAssist.AdminWeb
{
	/// <summary>
	/// Enum for dialog buttons.
	/// </summary>
	[Flags]
	public enum DialogButtons
	{
		/// <summary>
		/// No dialog buttons.
		/// </summary>
		None = 0,

		/// <summary>
		/// Ok button.
		/// </summary>
		Ok = 1,

		/// <summary>
		/// Save button.
		/// </summary>
		Save = 2,

		/// <summary>
		/// Cancel button.
		/// </summary>
		Cancel = 4,

		/// <summary>
		/// Close button.
		/// </summary>
		Close = 8,

		/// <summary>
		/// Save and continue button.
		/// </summary>
		SaveAndContinue = 16
	}
}