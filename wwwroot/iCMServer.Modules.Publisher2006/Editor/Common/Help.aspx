<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="help" TagName="Control" Src="~/Common/ControlHelp.ascx" %>
<%@ Import Namespace="Telerik.QuickStart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/HelpNavigation.ascx"></telerik:Header>
		
			<div id="tab1" class="text">
				The distribution file (EXE) is shipped with a "<strong>Deployment Manual and Reference</strong>" 
				in MS Help 2 format, which is registered in the MSDN during the installation.
				<p>
					<help:Control ID="controlHelp" Runat="server" />
				</p>
				For additional technical resources, please visit the <a href="#" onkeypress="window.open('http://www.telerik.com/<%= ProductInfo.RadControlName %>'); return false;" onclick="window.open('http://www.telerik.com/<%= ProductInfo.RadControlName %>'); return false;">
					r.a.d.<strong><%= ProductInfo.ControlName %></strong></a> product section and the <a href="#" onclick="window.open('http://www.telerik.com/support'); return false;" onkeypress="window.open('http://www.telerik.com/support'); return false;">
					support</a> section on our web-site.
			</div>
			<div id="tab2" class="text" style="DISPLAY:none">
				<strong>t</strong>elerik is devoted to delivering not only high quality software but also 
				the respective level of technical support that will guarantee your effortless 
				experience when evaluating, deploying, or customizing our products.
				<div style="MARGIN-TOP:20px;FONT-WEIGHT:bold;BORDER-BOTTOM:gray 1px dotted">
					Support resources
				</div>
				An array of on-line technical resources is available in the <a href="#" onclick="window.open('http://www.telerik.com/support'); return false;" onkeypress="window.open('http://www.telerik.com/support'); return false;">
					support section</a> of our web-site:
				<br/>
				&nbsp;&nbsp;• Integrated ticketing system with complete history<br/>
				&nbsp;&nbsp;• Knowledge base<br/>
				&nbsp;&nbsp;• Learning center with on-line videos<br/>
				&nbsp;&nbsp;• Customer forums<br/>
				&nbsp;&nbsp;• Tips and tricks<br/>
				&nbsp;&nbsp;• Frequently asked questions<br/>
				&nbsp;&nbsp;• Feature suggestion/bug reporting section
			</div>


			

	<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>


