<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Import Namespace="Telerik.QuickStart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1" NAME="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/PurchaseNavigation.ascx"></telerik:Header>
			

<p><span style="foreground-color: #152b4d">
The following licenses are available for r.a.d.<strong><%= ProductInfo.ControlName %></strong>. For more details visit the <a href="#" onclick="window.open('http://www.telerik.com/purchase'); return false;" onkeypress="window.open('http://www.telerik.com/purchase'); return false;">purchase section</a> of our web-site.
<br/><br/>
<b>Trial License:</b><br/>
The Trial License allows you to install, copy and use a fully-functional version of r.a.d.<strong><%= ProductInfo.ControlName %></strong> for the sole purposes of testing and evaluation. The product will work indefinitely on http://localhost. You are also allowed to obtain a 30-day trial license key, which will remove the copyright message and will let you access the control(s) by domain name, IP address, or server name.
<br/><br/>
<b>Single Developer License:</b><br/>
The Single Developer License is licensed per developer seat. It allows you to use r.a.d.<strong><%= ProductInfo.ControlName %></strong> royalty-free, perpetually, in an unlimited number of websites and solutions, provided they are developed solely by the licensed developer(s). Please note that if you want to ship r.a.d.<strong><%= ProductInfo.ControlName %></strong> as an integrated part of a branded commercial, product you need to obtain an OEM license.
The Single Developer license includes 30 days of free product updates.
<br/><br/>
Only for <a href="#" onkeypress="window.open('http://www.telerik.com/radcontrols'); return false;" onclick="window.open('http://www.telerik.com/radcontrols'); return false;">r.a.d.<b>controls</b></a> and <a href="#" onclick="window.open('http://www.telerik.com/radnavigation'); return false;" onkeypress="window.open('http://www.telerik.com/radnavigation'); return false;">r.a.d.<b>navigation</b></a> suites!<br/>
<b>Single Developer License Plus Subscription:</b><br/>
The Single Developer Subscription includes a Single Developer License and entitles you to receive all version updates for the products included in the suite, as well as all new products that may be added to the suite for a period of one year.
</span></p>

			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>