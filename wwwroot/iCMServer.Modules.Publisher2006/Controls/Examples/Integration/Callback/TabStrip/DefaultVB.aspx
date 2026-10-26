<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radts" Namespace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegrationExamplesVBNET.TabStrip.DefaultVB" Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
			/*<![CDATA[*/
				function onTabClick(sender, eventArgs)
				{
					window["<%= RadCallback1.ClientID %>"].MakeCallback("tabstrip1", eventArgs.Tab.Text);
				}
			/*]]>*/
			</script>
			<div class="module">
				<asp:Label id="Label1" runat="server" Font-Bold="True">Load data from:</asp:Label>
				<radclb:CallbackDropDownList id="ddlDataSource" runat="server" DisableAtCallback="true" Width="171px" OnSelectedIndexChanged="ddlDataSource_SelectedIndexChanged">
					<asp:ListItem Value="XML File">XML File</asp:ListItem>
					<asp:ListItem Value="Database">Database</asp:ListItem>
				</radclb:CallbackDropDownList>
				<br />
				<br />
				<asp:Label id="Label2" runat="server" Font-Bold="True">Select The Active Tab:</asp:Label><br />
				<radclb:CallbackListBox id="lbActiveTab" DisableAtCallback="true" runat="server" Width="157px" Height="84px"></radclb:CallbackListBox>
				<radclb:RadCallback id="RadCallback1" runat="server"></radclb:RadCallback>
				<br />
				<br />
				<radts:RadTabStrip id="RadTabStrip1" Runat="server" UnselectChildren="true" OnClientTabSelected="onTabClick" Skin="Mac">
				</radts:RadTabStrip>
			</div>
			<br />
			<div class="module">
				<radts:RadTabStrip id="RadTabStrip2" Runat="server" Skin="Mac" SelectedIndex="0" MultiPageID="RadMultiPage1">
					<Tabs>
						<radts:Tab Text="CallbackButton" PageViewID="Page1"></radts:Tab>
						<radts:Tab Text="CallbackCheckBoxList" PageViewID="Page2"></radts:Tab>
						<radts:Tab Text="CallbackListBox" PageViewID="Page3"></radts:Tab>
					</Tabs>
				</radts:RadTabStrip>
				<radts:RadMultiPage id="RadMultiPage1" Width="478px" Runat="server" SelectedIndex="0">
					<radts:PageView ID="Page1" Runat="server" CssClass="MultiPage">
							<br />
							<asp:TextBox runat="server" ID="tbSubmitText"></asp:TextBox>
							<radclb:CallbackButton OnClick="btnSubmit_Click" cssClass="button" runat="server" DisableAtCallback="true"
							Text="Submit" ID="btnSubmit"></radclb:CallbackButton>
							<br /><br />
							You Typed: <asp:Label runat="server" ID="lSubmittedText" style="color: green;"></asp:Label>
						</radts:PageView>
					<radts:PageView ID="Page2" Runat="server" CssClass="MultiPage">
							<radclb:CallbackCheckBoxList runat="server" DisableAtCallback="true" ID="cblItems" OnSelectedIndexChanged="cblItems_SelectedIndexChanged">
							<asp:ListItem Value="Editor">Editor</asp:ListItem>
							<asp:ListItem Value="Chart">Chart</asp:ListItem>
							<asp:ListItem Value="Menu">Menu</asp:ListItem>
						</radclb:CallbackCheckBoxList>
							<br />Selected Items:
							<asp:Label runat="server" ID="lSelectedItems">[No Selected Items]</asp:Label>
						</radts:PageView>
					<radts:PageView ID="Page3" Runat="server" CssClass="MultiPage">
							<br />
							<radclb:CallbackListBox runat="server" DisableAtCallback="true" Height="61px" Width="104px" SelectionMode="multiple"
							ID="lbItems" OnSelectedIndexChanged="lbItems_SelectedIndexChanged">
							<asp:ListItem Value="Editor">Editor</asp:ListItem>
							<asp:ListItem Value="Chart">Chart</asp:ListItem>
							<asp:ListItem Value="Menu">Menu</asp:ListItem>
						</radclb:CallbackListBox>
							<br /><br />Selected Items:
							<asp:Label runat="server" ID="llbItems">[No Selected Items]</asp:Label>
						</radts:PageView>
				</radts:RadMultiPage>
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
