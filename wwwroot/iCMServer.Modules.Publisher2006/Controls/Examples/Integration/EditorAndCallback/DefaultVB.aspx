<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="rade" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page ValidateRequest="false" AutoEventWireup="false" Inherits="Telerik.IntegrationExamplesVBNET.EditorAndCallback.DefaultVB" Language="vb" CodeBehind="DefaultVB.aspx.vb" %>
<HTML>
	<HEAD>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</HEAD>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB" XHTMLCompliant="False"></telerik:Header>
			<!-- content start -->
			<rade:RadEditor id="Editor1" EnableDocking="false" runat="server" Editable="true" ToolsFile="ToolsFile.xml"></rade:RadEditor>
			<asp:Label ID="statusLabel" Runat="server" EnableViewState="False" style="color:#9fbddc;font-weight:bold;"></asp:Label>
			<radclb:CallbackTimer id="Timer1" Runat="server" AutoStart="true" DelayTime="60000" Interval="60000" OnTick="Timer1_Tick"
				StatusLabel-LabelID="statusLabel" StatusLabel-BusyMessage="Saving..." StatusLabel-ReadyMessage="Draft saved"></radclb:CallbackTimer>
			<br>
			<br>
			<radclb:CallbackButton id="showDraft" runat="server" OnClick="showDraft_Click" Text="Show saved text" DisableAtCallback="true" CssClass="button" Width="200px"></radclb:CallbackButton>
			<asp:Label id="labelLastChanged" Runat="server" EnableViewState="false"></asp:Label>
			<br>
			<div style="WIDTH: 630px; HEIGHT: 200px; overflow: auto;margin-top: 25px;border: solid 1px #cccccc;">
				<asp:Label id="labelPreview" Runat="server" EnableViewState="False"></asp:Label>
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</HTML>
