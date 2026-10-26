<%@ Register TagPrefix="radts" Assembly="RadTabStrip" NameSpace="Telerik.WebControls" %>
<%@ Register TagPrefix="radg" Assembly="RadGrid" NameSpace="Telerik.WebControls" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page AutoEventWireup="false" Trace="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegarationExamplesCSharp.GridAndTabstrip.DefaultCS" Language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css">
		.gridHeader
		{
			height: 40px;
			background-image: url(images/dots.gif);
			background-repeat: repeat-x;
			background-position: bottom;
			color: #85a6a9;
			font-size: 10px;
			font-weight: normal;
		}
		.gridHeader A
		{
			color: #85a6a9;
			text-decoration: none;
		}
		.gridItem
		{
			background-image: url(images/gridBg.gif);
			background-repeat: repeat-x;
			height: 40px;
			color: #a3bcbf;
			font-size: 14px;
		}
		.gridItemStripes
		{
			background-image: url(images/gridBgStripes.gif);
			background-repeat: repeat-x;
			height: 40px;
		}
		.previewPane
		{
			background-color: #f3f7f7;
			border-left: 5px solid #bad8db;
			border-right: 5px solid #bad8db;
			width: 267px;
			padding: 10px;
		}
		.RadGrid, .RadGrid A
		{
			color: #a3bcbf;
		}
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
/*<![CDATA[*/
function hideLoading()
{
	var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
	if (panelLoadingImage) panelLoadingImage.style.display = "none";
	var panelTabstripLoading = document.getElementById("<%= panelTabstripLoading.ClientID %>");
	if (panelTabstripLoading) panelTabstripLoading.style.display = "none";
	var labelDescription = document.getElementById("<%= labelDescription.ClientID %>");
	if (labelDescription) labelDescription.style.display = "block";
	var imageProduct = document.getElementById("<%= imageProduct.ClientID %>");
	if (imageProduct) imageProduct.style.display = "block";
}

function gridShowProduct(eventType, productId)
{
	if ("AddToCart"==eventType || "RemoveFromCart"==eventType )
	{
		var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
		if (panelLoadingImage) panelLoadingImage.style.display = "block";
	}
	else
	{
		var panelTabstripLoading = document.getElementById("<%= panelTabstripLoading.ClientID %>");
		if (panelTabstripLoading) panelTabstripLoading.style.display = "block";
		var labelDescription = document.getElementById("<%= labelDescription.ClientID %>");
		if (labelDescription) labelDescription.style.display = "none";
		var imageProduct = document.getElementById("<%= imageProduct.ClientID %>");
		if (imageProduct) imageProduct.style.display = "none";
	}
	window["<%= callbackShopping.ClientID %>"].MakeCallback(eventType, productId);
}
/*]]>*/
			</script>
			<radclb:radcallback id="callbackShopping" runat="server" oncallback="shoppingCallback_Callback"	ClientEvents-OnResponseEnd="hideLoading" />
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td valign="top" style="width:420;"><radg:radgrid id="gridProducts" style="VERTICAL-ALIGN: top" runat="server" GridLines="none" AutoGenerateColumns="False"
							ShowGroupPanel="False" AllowPaging="True" AllowSorting="True" PageSize="20" Width="420px" Cellspacing="0" Cellpadding="0">
							<PagerStyle Height="22px" BackColor="Control" CssClass="Pager" Mode="NumericPages"></PagerStyle>
							<ItemStyle CssClass="gridItemStripes" Height="40px"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
								<Scrolling AllowScroll="False" UseStaticHeaders="true"></Scrolling>
								<Resizing AllowRowResize="False" AllowColumnResize="True"></Resizing>
							</ClientSettings>
							<AlternatingItemStyle CssClass="gridItemStripes"></AlternatingItemStyle>
							<MasterTableView DataMember="Products" AllowMultiColumnSorting="True">
								<RowIndicatorColumn UniqueName="RowIndicator">
									<HeaderStyle Width="20px" CssClass="ResizeHeader"></HeaderStyle>
								</RowIndicatorColumn>
								<NoRecordsTemplate>
									<div style="text-align:center;height:300px">
										<asp:Label ForeColor="RoyalBlue" Font-Size="14" Runat="server" ID="Label2">There are no items</asp:Label>
										<br />
									</div>
								</NoRecordsTemplate>
								<Columns>
									<radg:GridTemplateColumn UniqueName="ProductImage" Groupable="False">
										<HeaderStyle Width="26px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<img src='Images/thumb<%# DataBinder.Eval(Container.DataItem, "ProductID") %>.jpg' alt="Product Picture" height="39"/></ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridBoundColumn UniqueName="ProductName" HeaderText="DVD Top Sellers:" DataField="ProductName">
										<HeaderStyle Width="235px" Font-Size="18px"></HeaderStyle>
										<ItemStyle Wrap="False" CssClass="gridItem"></ItemStyle>
									</radg:GridBoundColumn>
									<radg:GridBoundColumn UniqueName="Price" HeaderText="" DataField="Price" DataFormatString="${0}">
										<HeaderStyle Width="34px"></HeaderStyle>
										<ItemStyle Wrap="False" Font-Size="11px" CssClass="gridItem"></ItemStyle>
									</radg:GridBoundColumn>
									<radg:GridTemplateColumn UniqueName="ViewImage" Groupable="False" HeaderText="Buy">
										<HeaderStyle Width="30px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<a href='javascript:gridShowProduct("AddToCart",<%# DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
												<img src='Images/cart.gif' alt="Add to cart" style="border:0px;" /></a></ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridTemplateColumn UniqueName="ViewImage" Groupable="False" HeaderText="Preview">
										<HeaderStyle Width="40px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<a href='javascript:gridShowProduct("ViewImage",<%# DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
												<img src='Images/preview.gif' alt="Product Picture" style="border:0px;" /></a></ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridTemplateColumn UniqueName="ViewImage" Groupable="False" HeaderText="Details">
										<HeaderStyle Width="40px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<a href='javascript:gridShowProduct("ViewDescription",<%# DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
												<img src='Images/details.gif' alt="Product Details" style="border:0px;" /></a></ItemTemplate>
									</radg:GridTemplateColumn>
								</Columns>
							</MasterTableView>
						</radg:radgrid></td>
					<td valign="top" style="width:400;">
						<div style="background-image: url(images/previewRightCorner.gif);background-repeat:no-repeat;width: 297px;background-position: left bottom;padding-bottom:13px;">
							<radts:RadTabStrip id="tabsProductDetails" runat="server" MultiPageId="multipageInformation">
								<Tabs>
									<radts:tab id="tabMoreInfo" Text="More Info" PageViewID="PageDescription"></radts:tab>
									<radts:tab id="tabGallery" Text="Cover" PageViewID="PageImages"></radts:tab>
								</Tabs>
							</radts:RadTabStrip></div>
						<div class="previewPane"><asp:panel id="panelTabstripLoading" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;TEXT-ALIGN: center"
								runat="server">Loading...<img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
							<radts:RadMultiPage id="multipageInformation" runat="server">
								<radts:PageView ID="PageDescription" Runat="server">
									<asp:Label ID="labelDescription" Runat="server"></asp:Label>
								</radts:PageView>
								<radts:PageView ID="PageImages" Runat="server">
									<asp:Image ID="imageProduct" Runat="server" ImageUrl="Images/spacer.gif" BorderWidth="0"></asp:Image>
								</radts:PageView>
							</radts:RadMultiPage>
						</div>
						<img src="images/previewBottom.gif" alt="" /><br />
						<asp:panel id="panelLoadingImage" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;TEXT-ALIGN: center"
							runat="server">Loading...<img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
						<radg:radgrid id="gridShoppingCart" runat="server" GridLines="none" AutoGenerateColumns="False"
							ShowGroupPanel="False" AllowPaging="False" AllowSorting="True" PageSize="20" Width="250px"
							style="margin: 20px;" CssClass="RadGrid">
							<ItemStyle CssClass="OutlookItem"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<ClientSettings>
								<Scrolling AllowScroll="False" UseStaticHeaders="True" SaveScrollPosition="True"></Scrolling>
								<Resizing AllowColumnResize="True"></Resizing>
							</ClientSettings>
							<AlternatingItemStyle CssClass="OutlookItem"></AlternatingItemStyle>
							<GroupHeaderItemStyle Font-Bold="True" Height="35px" ForeColor="#3366CC" CssClass="GroupHeaderItem" VerticalAlign="Bottom"></GroupHeaderItemStyle>
							<MasterTableView DataMember="Products" AllowMultiColumnSorting="True">
								<RowIndicatorColumn UniqueName="RowIndicator">
									<HeaderStyle Width="20px" CssClass="ResizeHeader"></HeaderStyle>
								</RowIndicatorColumn>
								<NoRecordsTemplate>
									<div style="text-align:center;height:100px">
										<asp:Label ForeColor="RoyalBlue" Font-Size="14" Runat="server" ID="Label1">The are no items</asp:Label>
										<br />
									</div>
								</NoRecordsTemplate>
								<Columns>
									<radg:GridTemplateColumn UniqueName="ProductImage" Groupable="False">
										<HeaderStyle Width="30px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Height="36px" VerticalAlign="top"></ItemStyle>
										<ItemTemplate>
											<img src='Images/thumb<%# DataBinder.Eval(Container.DataItem, "ProductID") %>.jpg' alt="Product Picture" />
										</ItemTemplate>
									</radg:GridTemplateColumn>
									<radg:GridBoundColumn UniqueName="ProductName" HeaderText="Shopping Cart" DataField="ProductName">
										<HeaderStyle Width="140px" Font-size="15"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</radg:GridBoundColumn>
									<radg:GridBoundColumn UniqueName="Price" DataField="Price" DataFormatString="${0}">
										<HeaderStyle Width="37px"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</radg:GridBoundColumn>
									<radg:GridHyperLinkColumn Text="Remove" DataNavigateUrlField="ProductId" UniqueName="BuyProduct" DataNavigateUrlFormatString="javascript:gridShowProduct('RemoveFromCart',{0})">
										<HeaderStyle Width="50px"></HeaderStyle>
									</radg:GridHyperLinkColumn>
								</Columns>
							</MasterTableView>
						</radg:radgrid>
					</td>
				</tr>
			</table>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
