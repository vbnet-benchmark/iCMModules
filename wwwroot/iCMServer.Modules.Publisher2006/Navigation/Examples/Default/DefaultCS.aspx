<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" Language="c#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Products" Src="../../Shared/Products.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml"> 
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css"> 
			#newRelease a { text-decoration:none; }
			#newRelease a:hover { text-decoration:underline; }
			.productImage
			{
				border:0px;
				margin-left:9px;
				margin-right:9px;
				
			}
			.statusImage
			{
				margin-left:9px;
				margin-right:9px;
			}
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
            <uc1:Products id="Products1" runat="server" Language="CS"></uc1:Products>
            <!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
