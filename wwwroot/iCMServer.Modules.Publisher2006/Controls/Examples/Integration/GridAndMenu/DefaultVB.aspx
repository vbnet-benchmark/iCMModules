<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.GridExamplesVBNET.Integration.GridAndMenu.DefaultVB" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radM" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/tr/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag2"></telerik:HeadTag>
		<!-- custom head section -->
		<link href="../../../../Grid/Examples/Styles/ColorSchemes/Glassy/Styles.css" rel="stylesheet"
			type="text/css" />
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
			//document.oncontextmenu = null;
			function RowContextMenu(index, e)
			{
			   var MyMenu = <%= RadMenu1.ClientID %>;
			   document.getElementById("radGridClickedRowIndex").value = index;
			   MyMenu.OnContext(e, this.Rows[index].Control);
			}
			</script>
			<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
			<p>Right-click the grid to open context menu.</p>
			<div style="margin-right:20px;">
				<radg:radgrid id="RadGrid1" runat="server" CssClass="RadGrid" Width="100%" Gridlines="None" BorderWidth="0">
					<MasterTableView AllowCustomPaging="False" AllowSorting="False" PageSize="10" AllowPaging="False"
						Width="100%">
						<RowIndicatorColumn Visible="False" UniqueName="RowIndicator">
							<HeaderStyle Width="20px"></HeaderStyle>
						</RowIndicatorColumn>
						<EditFormSettings>
							<EditColumn UniqueName="EditCommandColumn"></EditColumn>
						</EditFormSettings>
						<ExpandCollapseColumn ButtonType="ImageButton" Visible="False" UniqueName="ExpandColumn">
							<HeaderStyle Width="19px"></HeaderStyle>
						</ExpandCollapseColumn>
					</MasterTableView>
					<PagerStyle Mode="NumericPages" CssClass="GridPager" height="20"></PagerStyle>
					<HeaderStyle Height="41" CssClass="GridHeader" ForeColor="#242500"></HeaderStyle>
					<ItemStyle Height="24" CssClass="GridRow"></ItemStyle>
					<AlternatingItemStyle Height="24" CssClass="GridAltRow"></AlternatingItemStyle>
					<SelectedItemStyle Height="24" CssClass="GridSelectedRow"></SelectedItemStyle>
					<ClientSettings>
						<ClientEvents OnRowContextMenu="RowContextMenu"></ClientEvents>
					</ClientSettings>
					<GroupPanel Visible="False"></GroupPanel>
				</radg:radgrid>
			</div>
			<radm:radmenu id="RadMenu1" autopostback="True" contentfile="Menu.xml" iscontext="True" menuflow="Vertical"
				runat="server" Theme="Office2003" ContextHtmlElementID="INVALID_ID_HERE"></radm:radmenu>
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
