<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegrationExamplesCSharp.Editor.DefaultCS" Language="c#" ValidateRequest="false" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="rade" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<HTML>
	<HEAD>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</HEAD>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#" XhtmlCompliant="False"></telerik:Header>
			<!-- content start -->
			<div class="module">
				<div style="FLOAT:left;VERTICAL-ALIGN:top;WIDTH:200px">
					<asp:label id="Label2" runat="server" Font-Bold="True">Edit Article:</asp:label>
					<radclb:callbacklistbox id="lbArticles" runat="server" Width="178px" DisableAtCallback="true" onselectedindexchanged="lbArticles_SelectedIndexChanged">
						<asp:ListItem Value="17">Article 1</asp:ListItem>
						<asp:ListItem Value="98">Article 2</asp:ListItem>
						<asp:ListItem Value="110">Article 3</asp:ListItem>
					</radclb:callbacklistbox>
				</div>
				<div style="FLOAT:left;MARGIN:0px 60px;VERTICAL-ALIGN:top">
					&nbsp;<asp:label id="Label3" runat="server" Font-Bold="True">Change Skin:</asp:label>
					<radclb:callbackradiobuttonlist id="rblSkin" runat="server" DisableAtCallback="true" onselectedindexchanged="rblSkin_SelectedIndexChanged">
						<asp:ListItem Value="Custom">Custom</asp:ListItem>
						<asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
						<asp:ListItem Value="Mac">Mac</asp:ListItem>
						<asp:ListItem Value="Monochrome">Monochrome</asp:ListItem>
						<asp:ListItem Value="Office2000">Office2000</asp:ListItem>
					</radclb:callbackradiobuttonlist>
				</div>
				&nbsp;<asp:label id="Label1" runat="server" Font-Bold="True">Select Toobars:</asp:label>
				<radclb:callbackcheckboxlist id="cblToolbars" DisableAtCallback="true" runat="server" onselectedindexchanged="cblToolbars_SelectedIndexChanged"></radclb:callbackcheckboxlist>
			</div>
			<br />
			<radclb:callbackbutton id="btnToggleEditorVisibility" cssclass="button" Width="157px" Runat="server" Text="Show Editor"
				DisableAtCallback="True" onclick="btnToggleEditorVisibility_Click"></radclb:callbackbutton><input id="EditedNews" type="hidden" name="EditedNews" runat="server">
			<br />
			<radE:RadEditor id="editor1" Runat="server" ToolsFile="ToolsFile1.xml" HasPermission="true" OnEditableChanged="editor1_EditableChanged"
				EnableDocking="false"></radE:RadEditor>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</HTML>
