<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.VSProjects" %>
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
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/VSProjectsNavigation.ascx"></telerik:Header>
			
<div class="download"><a href="?project=csproj"> Open 
	C# Project</a><img runat="server" src="~/img/vs.gif" style="border: 0;margin-left: 11px; margin-right: 11px;" alt="VS.NET" /></div>
<div class="download"><a href="?project=vbproj"> Open 
	VB.NET Project</a><img runat="server" src="~/img/vs.gif" style="border: 0;margin-left: 11px; margin-right: 11px;" alt="VS.NET" /></div>
<br/>
The r.a.d.<strong><%= ProductInfo.ControlName %></strong> distribution contains two sample Visual Studio .NET projects, 
available in VB.NET and C#. These projects can be loaded in Visual Studio .NET 
from the Start Menu: "<strong>telerik -&gt; r.a.d.<strong><%= ProductInfo.ControlName %></strong> v<%= ProductInfo.Version %> -&gt; ASP.NET 1.x</strong>". <br/>


The provided projects are shipped compiled and running. <br/>
Please note that these projects are optimized for Visual Studio 2002 and Visual Studio 2003. 
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
