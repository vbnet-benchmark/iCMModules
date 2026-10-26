<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackExamplesVB.Integration.CallbackAndTabStrip.DefaultVB" Language="vb" %>
<%@ Register TagPrefix="radTS" NameSpace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Register TagPrefix="radCB" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css">
		.ProductPanel { BORDER-RIGHT: #717171 1px solid; PADDING-RIGHT: 10px; PADDING-LEFT: 10px; FONT-SIZE: 8pt; PADDING-BOTTOM: 10px; BORDER-LEFT: #717171 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #717171 1px solid; FONT-FAMILY: "MS Sans Serif", Arial, sans-serif }
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
		//<!--
		var selectedTabIndex;
		var clicked = false;
		
		function EnableTabs()
		{
			var tabstrip = window["<%=RadTabStrip1.ClientID%>"];
			var coll = tabstrip.Tabs;
			
            for (var i = 0; i < coll.length; i++)
            {
                coll[i].Enable();
            }
			coll[selectedTabIndex].Click();
			clicked = false;
		}
		
		function DisableTabs()
		{
            var tabstrip = window["<%=RadTabStrip1.ClientID%>"];
            selectedTabIndex = tabstrip.SelectedIndex;
            var coll = tabstrip.Tabs;
            for (var i = 0; i < coll.length; i++)
            {
				if (i != selectedTabIndex)
					coll[i].Disable();
            }
		}
		
		function TabCallback(sender, eventArgs)
		{
			if (clicked)
			{
				clicked = false;
				return;
			}
			clicked = true;
			DisableTabs();
			showLoadingImage();
			window["<%= RadCallback1.ClientID %>"].MakeCallback(eventArgs.Tab.Value, "");
		}

		function showLoadingImage()
		{
			document.getElementById("Panel1").innerHTML = '<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" bgcolor="white"><tr><td align="center"><img src="Images/Loading.gif"></td></tr></table>';
		}
		//-->
			</script>
			<radCB:RadCallback id="RadCallback1" Runat="server" ResponseScript="EnableTabs()"></radCB:RadCallback>
			<table border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td>
						<radTS:RadTabStrip ID="RadTabStrip1" Runat="server" Skin="Mac" SelectedIndex="0" OnClientTabSelected="TabCallback"
							Width="400px" Height="30px">
							<Tabs>
								<radts:Tab Text="r.a.d.tabstrip" Value="Tab1"></radts:Tab>
								<radts:Tab Text="r.a.d.panelbar" Value="Tab2"></radts:Tab>
								<radts:Tab Text="r.a.d.menu" Value="Tab3"></radts:Tab>
								<radts:Tab Text="r.a.d.editor" Value="Tab4"></radts:Tab>
								<radts:Tab Text="r.a.d.treeview" Value="Tab5"></radts:Tab>
							</Tabs>
						</radTS:RadTabStrip>
					</td>
				</tr>
				<tr>
					<td>
						<asp:panel ID="Panel1" Runat="server" BackColor="#FFFFFF" Width="378px" Height="350px" CssClass="ProductPanel">
							<div class="module">
								<img id="ProductLogo" alt="product image" Runat="server" />
								<br />
								<p style="TEXT-ALIGN: justify"><img id="ProductImage" style="FLOAT: left; MARGIN-RIGHT: 7px" alt="product image" Runat="server" />
									<asp:Label id="ProductDescription" Runat="server"></asp:Label></p>
								Price:
								<asp:Label id="Price" style="COLOR: brown" Runat="server"></asp:Label>
							</div>
						</asp:panel>
					</td>
				</tr>
			</table>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
