<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" Language="c#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Products" Src="../../Shared/Products.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1" Title="ASP.NET Controls: AJAX Components for Web Development"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css"> 
			#newRelease A { TEXT-DECORATION: none; } 
			#newRelease A:hover { TEXT-DECORATION: underline } 
			.productImage { BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; MARGIN-LEFT: 9px; MARGIN-RIGHT: 9px; BORDER-RIGHT-WIDTH: 0px } 
			.statusImage { MARGIN-LEFT: 9px; MARGIN-RIGHT: 9px } 
			</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
			<uc1:Products id="Products1" runat="server" Language="CS"></uc1:Products>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
