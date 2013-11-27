using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PharmAssist.AdminWeb
{
	public partial class SiteMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			AddJavaScripts();
		}

		private void AddJavaScripts()
		{
			StringBuilder scripts = new StringBuilder();
			scripts.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>\n", ResolveUrl("~/Js/JQuery/jquery-1.7.2.js"));
			scripts.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>\n", ResolveUrl("~/Js/JQuery/jquery.modal.js"));
			scripts.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>\n", ResolveUrl("~/Js/PopupDialog.js"));
			ltlJavascripts.Text = scripts.ToString();
		}
	}
}
