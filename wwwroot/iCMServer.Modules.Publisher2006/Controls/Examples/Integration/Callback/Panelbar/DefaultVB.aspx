<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radp" Namespace="Telerik.WebControls" Assembly="RadPanelbar" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegrationExamplesVBNET.Panelbar.DefaultVB" Language="vb" %>
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
				function itemClick(item)
				{					
					window["<%= RadCallback1.ClientID %>"].MakeCallback("panelbar1", item.ID);
				}
			/*]]>*/
			</script>
			<div class="container">
				<div style="PADDING-RIGHT:20px;PADDING-LEFT:20px;PADDING-BOTTOM:20px;WIDTH:200px;PADDING-TOP:20px;BACKGROUND-COLOR:#1a1710;float:left;">
					<radp:RadPanelbar id="RadPanelbar1" Runat="server" Theme="Dark" Width="235px">
						<PanelItemTemplates>
							<radp:PanelItemTemplate ID="Template1">
								<ContentTemplate>
									<div style="padding:10px;padding-right:0px;">
										<asp:TextBox id="tbTextToSubmit" runat="server" Width="110px"></asp:TextBox><radclb:CallbackButton id="CallbackButton1" DisableAtCallback="true" onclick="btnCallbackSubmit_Click"
											runat="server" Text="Submit" CssClass="button"></radclb:CallbackButton>
										<br />
										<asp:Label id="lSubmittedText" runat="server"></asp:Label>
									</div>
								</ContentTemplate>
							</radp:PanelItemTemplate>
							<radp:PanelItemTemplate ID="Template2">
								<ContentTemplate>
									<asp:Label id="lSelectedItems" runat="server" ForeColor="Black">[No Selected Items]</asp:Label>
									<radclb:CallbackCheckBoxList id="cblSelectedItems" runat="server" DisableAtCallback="true" OnSelectedIndexChanged="clbSelectedItems_SelectedIndexChanged">
										<asp:ListItem Value="Editor">Editor</asp:ListItem>
										<asp:ListItem Value="Chart">Chart</asp:ListItem>
										<asp:ListItem Value="Menu">Menu</asp:ListItem>
									</radclb:CallbackCheckBoxList>
								</ContentTemplate>
							</radp:PanelItemTemplate>
							<radp:PanelItemTemplate ID="Template3">
								<ContentTemplate>
								<div style="padding:10px 0px;float:left;">
										<radclb:CallbackListBox id="lbItems" runat="server" DisableAtCallback="true" OnSelectedIndexChanged="lbItems_SelectedIndexChanged">
											<asp:ListItem Value="Editor">Editor</asp:ListItem>
											<asp:ListItem Value="Chart">Chart</asp:ListItem>
											<asp:ListItem Value="Menu">Menu</asp:ListItem>
										</radclb:CallbackListBox>
									</div>
									<br /><br />Selected Items:<br />
									<asp:Label id="lSelectedItems2" runat="server" ForeColor="Black">[No Selected Items]</asp:Label>
							</ContentTemplate>
							</radp:PanelItemTemplate>
						</PanelItemTemplates>
						<PanelItems>
							<radp:PanelItem ID="Panel1" Expanded="True" Text="CallbackButton" SubGroupCssClass="panelbarItemGroup">
								<radp:PanelItem ID="Panel1_1" Expanded="True" Text="CallbackButton" TemplateID="Template1"></radp:PanelItem>
							</radp:PanelItem>
							<radp:PanelItem ID="Panel2" Text="CallbackCheckBoxList" SubGroupCssClass="panelbarItemGroup">
								<radp:PanelItem ID="Panel2_1" Text="New Item" TemplateID="Template2"></radp:PanelItem>
							</radp:PanelItem>
							<radp:PanelItem ID="Panel3" Text="CallbackListBox" SubGroupCssClass="panelbarItemGroup">
								<radp:PanelItem ID="Panel3_1" Text="New Item" TemplateID="Template3"></radp:PanelItem>
							</radp:PanelItem>
						</PanelItems>
					</radp:RadPanelbar>
				</div>
				<radclb:radcallback id="RadCallback1" runat="server"></radclb:radcallback>
				<asp:label id="Label1" runat="server" Font-Bold="True">Load From: </asp:label><radclb:callbackdropdownlist id="ddlDataSource" DisableAtCallback="true" runat="server" Width="180px">
					<asp:ListItem Value="XML File">XML File</asp:ListItem>
					<asp:ListItem Value="Database">Database</asp:ListItem>
				</radclb:callbackdropdownlist>
				<br />
				<br />
				<div style="PADDING-RIGHT:20px;PADDING-LEFT:20px;PADDING-BOTTOM:20px;WIDTH:200px;PADDING-TOP:20px;BACKGROUND-COLOR:#1a1710;float:right;margin-right:130px;">
					<radp:RadPanelbar id="RadPanelbar2" Runat="server" Theme="Dark" Width="235px"></radp:RadPanelbar>
				</div>
				<br />
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
