<%@ Page Language="c#" AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.GridExamplesCSharp.Integration.GridAndTreeView.DefaultCS" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radM" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radtlb" Namespace="Telerik.WebControls" Assembly="RadToolbar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/tr/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag2"></telerik:HeadTag>
		<link href="Styles.css" rel="stylesheet" type="text/css"></link>
		<!-- custom head section -->
		<style type="text/css">
			.RadGrid TABLE { FONT-SIZE: 11px; VERTICAL-ALIGN: middle; CURSOR: default; }
			.RadGrid A { COLOR: black; TEXT-DECORATION: none }
			.RadGrid TH A { PADDING-LEFT: 4px; FONT-WEIGHT: normal }
			.RadGrid TH { BORDER-LEFT: white 2px outset; BORDER-BOTTOM: #cbc7b8 2px solid; BACKGROUND-COLOR: #ece9d8 }
			.RadGrid TD {padding:0px;}
			.RadGrid {background-color: #ece9d8;}
			.FirstColumn {background-color: #f7f7f7;};
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
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
		function TreeNodeClick(node)
		{
			if ("Folder" == node.Category)
				window["<%= genericCallback.ClientID %>"].MakeCallback('NodeClick', node.Value);
		}
		function GridRowDblClick(rowIndex)
		{
			var itemIndex = window["grid_<%= RadGrid1.ClientID %>"].MasterTableView.Rows[rowIndex].RealIndex;
			window["<%= genericCallback.ClientID %>"].MakeCallback('GridDblClick', itemIndex);
			if (document.selection)
				document.selection.empty();
			else
				if (window.getSelection)
					window.getSelection().removeAllRanges();
		}
/*]]>*/
			</script>
			<radclb:RadCallback id="genericCallback" runat="server" OnCallback="genericCallback_Callback"
				ClientEvents-OnResponseEnd="hideLoading" ClientEvents-OnRequestStart="showLoading"></radclb:RadCallback>
			<table class="MainTable" cellpadding="0" cellspacing="0" width="690">
				<tr>
					<td colspan="2">
						<table cellspacing="0" cellpadding="0" width="100%" style="height:40px;">
							<tr>
								<td style="BORDER-BOTTOM: #d8d2bd 1px solid;height:19px;">
									<radM:radmenu id="RadMenu1" runat="server" ContentFile="menu.xml" CssFile="menu.css" ImagesBaseDir="img/"
										ShadowColor="#8E8E8E" ShadowWidth="4" ClickToOpen="True"></radM:radmenu>
								</td>
							</tr>
							<tr>
								<td style="border-top: white 1px solid; border-bottom: #d8d2bd 1px solid; height:31px;">
									<radtlb:RadToolbar runat="server" Skin="ExplorerXP">
										<items>
											<radtlb:radtoolbarbutton id="button_search" Tooltip="Search" CommandName="search" DisplayType="TextImage"
												ButtonText="Search" ButtonImage="search.gif" />
											<radtlb:radtoolbarbutton id="button_folders" Tooltip="Show/Hide Folders" CommandName="folders" DisplayType="TextImage"
												ButtonText="Folders" ButtonImage="folders.gif" />
											<radtlb:radtoolbarseparator />
											<radtlb:radtoolbarbutton id="button_refresh" Tooltip="Refresh" CommandName="refresh" ButtonImage="refresh.gif" />
											<radtlb:radtoolbarbutton id="button_cut" Tooltip="Cut" CommandName="cut" ButtonImage="cut.gif" />
											<radtlb:radtoolbarbutton id="button_views" Tooltip="Views" CommandName="views" ButtonImage="views.gif" />
											<radtlb:radtoolbarseparator />
											<radtlb:radtoolbarbutton id="button_delete" Tooltip="Delete" CommandName="delete" ButtonImage="delete.gif" />
										</items>
									</radtlb:RadToolbar>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td valign="top" style="width:260px;background-color: white;">
						<radT:RadTreeView ID="RadTree1" runat="server" Skin="Classic" ImagesBaseDir="~/TreeView/Examples/Programming/ClientLoadOnDemandDirectory/Img"
							Width="260px" Height="404px" BeforeClientClick="TreeNodeClick"></radT:RadTreeView>
					</td>
					<td valign="top" style="BORDER-LEFT: #ece9d8 4px solid;">
						<asp:panel id="panelLoadingImage" style="DISPLAY: none;VERTICAL-ALIGN: middle;TEXT-ALIGN: center;position:absolute;z-index:20;background-color:white;height:400px;width:410px;"
							runat="server">
							<img style="VERTICAL-ALIGN: middle" src="Img/loading.gif" alt="Loading..." /></asp:panel>
						<radg:radgrid id="RadGrid1" runat="server" AllowSorting="True" AllowPaging="False" BorderWidth="0px"
							AutoGenerateColumns="False" GridLines="None" GroupingEnabled="False" CssClass="RadGrid" enableasyncrequests="True"
							EnableAJAXLoadingTemplate="true">
							<GroupPanel Visible="False"></GroupPanel>
							<HeaderStyle Font-Size="11px" Font-Names="Arial" HorizontalAlign="Left" Height="20px"></HeaderStyle>
							<ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
								<ClientEvents OnRowDblClick="GridRowDblClick" />
								<Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="380px"></Scrolling>
								<Resizing EnableRealTimeResize="True" ResizeGridOnColumnResize="True" AllowColumnResize="True"></Resizing>
								<Selecting allowrowselect="True"></Selecting>
							</ClientSettings>
							<GroupHeaderItemStyle BorderColor="Black" BackColor="Silver"></GroupHeaderItemStyle>
							<MasterTableView AllowCustomPaging="False" AllowSorting="True" PageSize="20" AllowPaging="False"
								BackColor="white" Width="100%">
								<ItemStyle Height="21px"></ItemStyle>
								<RowIndicatorColumn Visible="False" UniqueName="RowIndicator"></RowIndicatorColumn>
								<AlternatingItemStyle Height="21px"></AlternatingItemStyle>
								<Columns>
									<radg:GridTemplateColumn UniqueName="Name" SortExpression="Name" HeaderText="Name">
										<ItemStyle CssClass="FirstColumn"></ItemStyle>
										<HeaderTemplate>
											<asp:LinkButton runat="server" CommandArgument="Name" CommandName="Sort" ID="Linkbutton1"></asp:LinkButton>
										</HeaderTemplate>
										<ItemTemplate>
											<asp:Image runat="server" id="icon" Runat="server" />
											<asp:Label Runat="server" ID="itemLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
											</asp:Label>
											<asp:Label Runat="server" style="display:none;" ID="pathLabel" Text='<%# DataBinder.Eval(Container.DataItem, "FullPath") %>'>
											</asp:Label>
										</ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridTemplateColumn UniqueName="Size" SortExpression="Size" HeaderText="Size">
										<ItemStyle></ItemStyle>
										<HeaderTemplate>
											<asp:LinkButton Runat="server" CommandName="Sort" CommandArgument="Size" ID="Linkbutton2"></asp:LinkButton>
										</HeaderTemplate>
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "Size") %>
										</ItemTemplate>
									</radg:GridTemplateColumn>
								</Columns>
							</MasterTableView>
						</radg:radgrid>
					</td>
				</tr>
				<tr>
					<td style="background-color: #ece9d8;" colspan="2">&nbsp;</td>
				</tr>
			</table>
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
