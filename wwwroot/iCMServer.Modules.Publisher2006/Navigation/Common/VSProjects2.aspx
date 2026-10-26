<%@ Page AutoEventWireup="false" Inherits="System.Web.UI.Page" Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Import Namespace="Telerik.QuickStart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server"></telerik:HeadTag>

    <script runat="server">
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender (e);
            if (Request.QueryString["sln"] != null)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "application/octet-stream");
                Response.AddHeader("content-disposition","attachment;filename=project.url");
                string s = "[InternetShortcut]\r\n" + "URL=file://" + Server.MapPath("~/" + 
                ProductInfo.ControlName + "Examples.sln\r\n");

                Response.Write(s);
                Response.End();
            }
        }
    </script>

	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/VSProjectsNavigation.ascx"></telerik:Header>
			
<div class="download"><a href="?sln=yes"> Open 
	Solution</a><img runat="server" src="~/img/vs.gif" style="border: 0;margin-left: 11px; margin-right: 11px;" alt="VS.NET" /></div>
<br/>
The r.a.d.<strong><%= ProductInfo.ControlName %></strong> 
 contains a Sample Visual Studio .NET 2005 Web Site, available in VB.NET and C#. This Web Site can be
 loaded in Visual Studio .NET 2005 from the Start Menu: "<strong>telerik -&gt; r.a.d.<strong><%= ProductInfo.ControlName %></strong> v<%= ProductInfo.Version %> -&gt; ASP.NET 2.x</strong>". <br/>
			Please note that the sample web site is optimized for Visual Studio .NET 2005.
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>