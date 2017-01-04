using System;

namespace Paraesthesia.Web.Hosting.Demo.SubFolder
{
	public partial class Page2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Label1.Text = DateTime.Now.ToString("F");
		}
	}
}
