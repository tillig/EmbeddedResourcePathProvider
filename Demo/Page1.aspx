<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="Paraesthesia.Web.Hosting.Demo.Page1" %>
<%@ Register Src="~/WebUserControl1.ascx" TagName="UserControl1" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EmbeddedResourcePathProvider Page 1</title>
</head>
<body>
    <form id="form1" runat="server">
		<div style="border: 1px solid blue; padding: 5px;">
		<p>This text appears on embedded page 1.  The current date/time is: <asp:Label ID="Label1" runat="server" Text="Label" /></p>
		<p><asp:HyperLink runat="server" ID="HyperLink1" Text="Go to Page 2" NavigateUrl="~/SubFolder/Page2.aspx" /></p>
		</div>
		<uc1:UserControl1 id="UserControl1_1" runat="server" />
    </form>
</body>
</html>
