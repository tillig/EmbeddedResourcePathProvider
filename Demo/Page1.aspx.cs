using System;

namespace Paraesthesia.Web.Hosting.Demo
{
	public partial class Page1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Label1.Text = DateTime.Now.ToString("F");
		}
	}
}
