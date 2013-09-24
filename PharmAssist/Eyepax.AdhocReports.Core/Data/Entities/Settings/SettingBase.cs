using System.Text;

namespace PharmAssist.Core.Data.Entities.Settings
{
	/// <summary>
	/// Class to keep base settings.
	/// </summary>
	public class SettingBase : EntityBase
	{
		/// <summary>
		/// Gets or sets the name of the setting.
		/// </summary>
		/// <value>The name of the setting.</value>
		public string SettingName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the setting value.
		/// </summary>
		/// <value>The setting value.</value>
		public string SettingValue
		{
			get;
			set;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(base.ToString());
			sb.Append("\nSettingName = " + SettingName);
			sb.Append("\nSettingValue = " + SettingValue);
			return sb.ToString();
		}
	}
}
