using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;

namespace PharmAssist.AdminWeb
{
	public static class Navigation
	{
		/// <summary>
		/// Gets the navigation URL for the popup window.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="paramList">The param list.</param>
		/// <returns>Popup window url</returns>
		public static string GetPopupNavigationUrl(PopupControl control, Dictionary<string, string> paramList)
		{
			return "~/" + GetPopupNavigationUrlRelativeToBase(control, paramList);
		}


		/// Gets the navigation URL for the popup window relative to application url.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="paramList">The param list.</param>
		/// <returns>Popup window url</returns>
		public static string GetPopupNavigationUrlRelativeToBase(PopupControl control,
				Dictionary<string, string> paramList)
		{
			StringBuilder navigateUrl = new StringBuilder();
			navigateUrl.Append("DialogHost.aspx");
			navigateUrl.Append("?");
			navigateUrl.Append(QueryStringParameters.PopupControlId);
			navigateUrl.Append("=");
			navigateUrl.Append(Convert.ToInt32(control, CultureInfo.InvariantCulture));

			if (paramList != null)
			{
				foreach (string paramName in paramList.Keys)
				{
					navigateUrl.Append("&");
					navigateUrl.Append(paramName);
					navigateUrl.Append("=");
					navigateUrl.Append(paramList[paramName]);
				}
			}

			return navigateUrl.ToString();
		}
	}
}