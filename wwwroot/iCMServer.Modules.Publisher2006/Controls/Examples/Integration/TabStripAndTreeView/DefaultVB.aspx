<%@ Page CodeBehind="DefaultVB.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Telerik.TabStripExamplesVBNET.Integration.TabstripAndTreeView.DefaultVB" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="radTS" Namespace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<script type="text/javascript">
/*<![CDATA[*/
		function showLoading()
		{
			var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
			if (panelLoadingImage) panelLoadingImage.style.display = "block";
		}

		function hideLoading()
		{
			var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
			if (panelLoadingImage) panelLoadingImage.style.display = "none";
		}
/*]]>*/
		</script>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="VB"></telerik:Header>
				<radTS:RadTabStrip id="TabStrip1" runat="server" Skin="WinXP" SelectedIndex="0" MultiPageID="MultiPage1" Align="Justify" Width="321px">
					<Tabs>
						<radts:Tab ToolTip="Search" Text="Search" ID="Tab1"></radts:Tab>
						<radts:Tab ToolTip="Browse" Text="Browse" ID="Tab2"></radts:Tab>
					</Tabs>
				</radTS:RadTabStrip>
				<div style="BORDER-RIGHT:#7f9db9 1px solid; PADDING-RIGHT:10px; BORDER-TOP:0px; PADDING-LEFT:10px; PADDING-BOTTOM:10px; BORDER-LEFT:#7f9db9 1px solid; WIDTH:298px; PADDING-TOP:10px; BORDER-BOTTOM:#7f9db9 1px solid; POSITION:relative; TOP:-3px">
					<radts:RadMultiPage id="MultiPage1" SelectedIndex="0" runat="server" Height="300px">
						<radts:PageView id="Page1" Runat="server">
							<asp:Label id="Label2" runat="server" Font-Names="Verdana" ForeColor="Red" Font-Size="10px">Search for a country or city, e.g. "Boston". <br /> (case sensitive)</asp:Label>
							<br />
							<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
							<br />
							<radclb:CallbackButton id="Button1" runat="server" Text="Search" CssClass="button" ClientEvents-OnResponseEnd="hideLoading"
								ClientEvents-OnRequestStart="showLoading" DisableAtCallback="True" OnClick="Button1_Click"></radclb:CallbackButton>
							<br />
							<asp:Label id="Label1" runat="server" Font-Names="Verdana" ForeColor="Red" Font-Size="10px"
								EnableViewState="False"></asp:Label>
						</radts:PageView>
						<radts:PageView id="Page2" Runat="server">
							<br />
							<radT:RadTreeView ID="RadTree1" runat="server" ImagesBaseDir="~/treeview/img/WindowsXP" ContentFile="countries.xml"
								Height="250px" Width="298" />
						</radts:PageView>
					</radts:RadMultiPage>
			<asp:panel id="panelLoadingImage" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;TEXT-ALIGN: center"
				runat="server"><img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
			</div>
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>
