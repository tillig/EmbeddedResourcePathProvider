using System;

namespace Paraesthesia.Web.Hosting.Demo
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedResourcePathProvider());
		}
	}
}