<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegarationExamplesVBNET.TreeviewAndGrid.DefaultVB" Language="vb" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radt" Assembly="RadTreeView" NameSpace="Telerik.WebControls" %>
<%@ Register TagPrefix="radg" Assembly="RadGrid" NameSpace="Telerik.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
		<link rel="stylesheet" type="text/css" href="styles.css"></link>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width: 100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
/*<![CDATA[*/			
function hideLoading()
{
	var panelGridThreads = document.getElementById("<%= RadGrid1.ClientID %>");
	if (panelGridThreads) panelGridThreads.style.display = "block";
	var panelGridLoadingImage = document.getElementById("<%= panelGridLoadingImage.ClientID %>");
	if (panelGridLoadingImage) panelGridLoadingImage.style.display = "none";
	var labelMessage = document.getElementById("<%= labelMessage.ClientID %>");
	if (labelMessage) labelMessage.style.display = "block";
	var panelPreviewLoadingImage = document.getElementById("<%= panelPreviewLoadingImage.ClientID %>");
	if (panelPreviewLoadingImage) panelPreviewLoadingImage.style.display = "none";
}
function hideGrid()
{
	var panelGridThreads = document.getElementById("<%= RadGrid1.ClientID %>");
	if (panelGridThreads) panelGridThreads.style.display = "none";
	var panelGridLoadingImage = document.getElementById("<%= panelGridLoadingImage.ClientID %>");
	if (panelGridLoadingImage) panelGridLoadingImage.style.display = "block";
}
function hidePreview()
{
	var labelMessage = document.getElementById("<%= labelMessage.ClientID %>");
	if (labelMessage) labelMessage.style.display = "none";
	var panelPreviewLoadingImage = document.getElementById("<%= panelPreviewLoadingImage.ClientID %>");
	if (panelPreviewLoadingImage) panelPreviewLoadingImage.style.display = "block";
}
function treeOpenFolder(treeNode)
{
	if ("Folders" == treeNode.Category)
	{
		hideGrid();
		window["<%= callbackOutlook.ClientID %>"].MakeCallback("OpenFolder", treeNode.Text);
	}
	else
		return false;
};
function gridOpenMail(gridRow)
{
	if (gridRow.ItemType == "Item" || gridRow.ItemType == "AlternatingItem")
	{
		hidePreview();
		window["<%= callbackOutlook.ClientID %>"].MakeCallback("OpenMail", gridRow.RealIndex);
	}
}
/*]]>*/
			</script>
			<radclb:radcallback id="callbackOutlook" runat="server" oncallback="outlookCallback_Callback" allowothercallbacks="False"
				ClientEvents-OnResponseEnd="hideLoading" />
			<table cellpadding="0" cellspacing="3" class="outlookMainFrame" width="730">
				<tr>
					<td valign="top" style="border: solid 1px #002d96; background-color: #fff;width:150px;">
						<div class="outLookTopCell">Mail</div>
						<div style="width:150px;">
							<radt:radtreeview id="treeFolders" ImagesBaseDir="Images" runat="server" ContentFile="TreeView.xml"
								BeforeClientClick="treeOpenFolder" />
						</div>
					</td>
					<td valign="top" style="border: solid 1px #002d96; background-color: #fff;width:300px;">
						<div class="outLookTopCell">
							<div style="float: left;">Mailbox</div>
							<div style="float: right;"><img src="Images/Inbox.gif" height="24" width="18" alt="" /></div>
						</div>
						<radg:radgrid id="RadGrid1" style="VERTICAL-ALIGN: top;background-color: #ece9d8;" runat="server"
							GridLines="Horizontal" Width="300px" AutoGenerateColumns="False" ShowGroupPanel="False" AllowPaging="False"
							AllowSorting="False" BackColor="Window" Cellspacing="0" Cellpadding="0" enableasyncrequests="True"
							EnableAJAXLoadingTemplate="true">
							<PagerStyle Height="22px" BackColor="Control" CssClass="Pager" Mode="NumericPages"></PagerStyle>
							<ItemStyle CssClass="OutlookItem"></ItemStyle>
							<HeaderStyle Height="21px" CssClass="OutlookHeader"></HeaderStyle>
							<ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
								<Selecting AllowRowSelect="True"></Selecting>
								<Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="323px" SaveScrollPosition="True"></Scrolling>
								<Resizing AllowRowResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="True"
									AllowColumnResize="True"></Resizing>
								<ClientEvents OnRowSelected="gridOpenMail"></ClientEvents>
							</ClientSettings>
							<AlternatingItemStyle CssClass="OutlookItem"></AlternatingItemStyle>
							<GroupHeaderItemStyle Font-Bold="True" Height="35px" ForeColor="#3366CC" CssClass="GroupHeaderItem" VerticalAlign="Bottom"></GroupHeaderItemStyle>
							<MasterTableView DataMember="Mails" AllowMultiColumnSorting="True">
								<RowIndicatorColumn UniqueName="RowIndicator">
									<HeaderStyle Width="10px" CssClass="OutlookHeader"></HeaderStyle>
								</RowIndicatorColumn>
								<GroupByExpressions>
									<radg:GridGroupByExpression>
										<SelectFields>
											<radg:GridGroupByField FieldAlias="Received" FieldName="Received"></radg:GridGroupByField>
										</SelectFields>
										<GroupByFields>
											<radg:GridGroupByField FieldAlias="Received" SortOrder="Descending" FieldName="Received"></radg:GridGroupByField>
										</GroupByFields>
									</radg:GridGroupByExpression>
								</GroupByExpressions>
								<NoRecordsTemplate>
									<div style="text-align:center;height:300px">
										<asp:Label ForeColor="RoyalBlue" Font-Size="14" Runat="server" ID="Label1">The are no email items currently in this folder</asp:Label>
										<br />
									</div>
								</NoRecordsTemplate>
								<Columns>
									<radg:GridTemplateColumn UniqueName="TemplateColumn1" Groupable="False">
										<HeaderStyle Width="14px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Height="35px" VerticalAlign="top"></ItemStyle>
										<ItemTemplate>
											<img src="Images/MailIcon.gif" style="margin-top:4px;" alt="MailIcon" />
										</ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="From / Subject" GroupByExpression="From Group By From">
										<ItemStyle Height="35px"></ItemStyle>
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "From") %>
											<br />
											<div style="color:#808080;font-size:11px;">
												<%# DataBinder.Eval(Container.DataItem, "Subject") %>
											</div>
										</ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridBoundColumn UniqueName="Received" SortExpression="Received" HeaderText="Received" DataField="Received"
										DataFormatString="{0:MM/dd/yyyy}">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</radg:GridBoundColumn>
									<radg:GridTemplateColumn UniqueName="TemplateColumn3" Groupable="False">
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" Height="35px" backColor="#f2f0e4"></ItemStyle>
										<ItemTemplate>
											<img src="Images/MailFlag.gif" alt="MailFlag" /></ItemTemplate>
									</radg:GridTemplateColumn>
								</Columns>
							</MasterTableView>
						</radg:radgrid>
						<asp:panel id="panelGridLoadingImage" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;BACKGROUND-COLOR: white;TEXT-ALIGN: center"
							runat="server">Loading...<img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
					</td>
					<td valign="top" style="width:280px;" class="outLookOpenMessageCell">
						<table border="0" width="100%" style="border: solid 4px #808080; height: 378px;">
							<tr>
								<td class="msgTxt"><strong>From:</strong>
									<asp:Label id="labelFrom" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td class="msgTxt">
									<strong>Subject:</strong>
									<asp:Label id="labelSubject" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td class="msgTxt">
									<strong>Date:</strong>
									<asp:Label id="labelDate" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<hr class="messageSeparator" />
									<div class="messageScroll"><asp:panel id="panelPreviewLoadingImage" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;BACKGROUND-COLOR: white;TEXT-ALIGN: center"
											runat="server">Loading...<img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
										<asp:Label id="labelMessage" runat="server"></asp:Label>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
