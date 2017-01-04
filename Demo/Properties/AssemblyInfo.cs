using System.Reflection;
using System.Runtime.InteropServices;
using Paraesthesia.Web.Hosting;

[assembly: AssemblyTitle("EmbeddedResourcePathProvider Demo")]
[assembly: AssemblyDescription("Web site for testing the embedded resource virtual path provider.")]
[assembly: AssemblyCompany("Paraesthesia")]
[assembly: AssemblyProduct("Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider")]
[assembly: AssemblyCopyright("Copyright © Travis Illig 2007")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: EmbeddedResourceFile("Paraesthesia.Web.Hosting.Demo.Page1.aspx", "Paraesthesia.Web.Hosting.Demo")]
[assembly: EmbeddedResourceFile("Paraesthesia.Web.Hosting.Demo.WebUserControl1.ascx", "Paraesthesia.Web.Hosting.Demo")]
[assembly: EmbeddedResourceFile("Paraesthesia.Web.Hosting.Demo.SubFolder.Page2.aspx", "Paraesthesia.Web.Hosting.Demo")]
