<%@ Page Language="c#" AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.IntegrationExamples.GridEidorAndCombo.DefaultCS" ValidateRequest="false" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radM" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radI" Namespace="Telerik.WebControls" Assembly="RadInput"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/tr/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag2"></telerik:HeadTag>
		<!-- custom head section -->
		<link href="Styles.css" rel="stylesheet" type="text/css"></link>
		<style type="text/css">
		.Row
		{
			padding: 7px 0px;
		}

		.EditForm A
		{
			border:1px solid #D5D5D5;
			border-bottom: 1px solid #C2C2C2;
			border-right: 1px solid #C2C2C2;
			font-family: Verdana, Arial;
			font-size:10px;
			font-weight:bold;
			color:#666666;
			background-image:url(Img/buttonBg.gif);
			background-position:top;
			background-color:white;
			height:20px;
			width:80px;
			margin: 5px;
			padding-left: 16px;
		}
		.EditForm
		{
			background-color: #ffffe1;
		}
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
			
			<radg:radgrid CssClass="RadGrid" id="RadGrid1" runat="server" Width="740" AutoGenerateColumns="False"
		Gridlines="None" BorderWidth="0" AllowSorting="True" style="border-bottom:1px solid #319AEA;">
		<PagerStyle Height="20px" CssClass="GridPager" Mode="NumericPages"></PagerStyle>
		<ItemStyle BackColor="#F2F2F2" CssClass="Row"></ItemStyle>
		<GroupPanel Visible="False"></GroupPanel>
		<HeaderStyle Height="41px" CssClass="GridHeader"></HeaderStyle>
		<AlternatingItemStyle BackColor="#E1E1E1" CssClass="Row"></AlternatingItemStyle>
		<GroupHeaderItemStyle BorderColor="Black" BackColor="Silver"></GroupHeaderItemStyle>
		<MasterTableView>
			<RowIndicatorColumn UniqueName="RowIndicator">
				<HeaderStyle Width="20px"></HeaderStyle>
			</RowIndicatorColumn>
			<Columns>
				<radg:GridEditCommandColumn UniqueName="EditCommandColumn">
					<HeaderStyle Width="50px"></HeaderStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
				</radg:GridEditCommandColumn>
				<radg:GridBoundColumn UniqueName="A" SortExpression="A" HeaderText="&lt;span style='font-weight: normal; text-decoration: none'&gt;r.a.d.&lt;strong&gt;editor&lt;/strong&gt; column&lt;/span&gt;"
					DataField="A">
					<HeaderStyle Width="400px"></HeaderStyle>
				</radg:GridBoundColumn>
				<radg:GridDropDownColumn UniqueName="C" SortExpression="C" ListTextField="Text" ListValueField="Value" HeaderText="&lt;span style='font-weight: normal; text-decoration: none'&gt;r.a.d.&lt;strong&gt;combobox&lt;/strong&gt; column&lt;/span&gt;"
					DataField="C"></radg:GridDropDownColumn>
				<radg:GridDropDownColumn UniqueName="D" SortExpression="D" ListTextField="Text" ListValueField="Value" HeaderText="&lt;span style='font-weight: normal; text-decoration: none'&gt;r.a.d.&lt;strong&gt;grid&lt;/strong&gt; column&lt;/span&gt;"
					DataField="D"></radg:GridDropDownColumn>
				<radg:GridBoundColumn UniqueName="E" SortExpression="E" HeaderText="&lt;span style='font-weight: normal; text-decoration: none'&gt;r.a.d.&lt;strong&gt;input&lt;/strong&gt; column&lt;/span&gt;"
					DataField="E" DataFormatString="{0:d}"></radg:GridBoundColumn>
				<radg:GridBoundColumn Visible="False" UniqueName="B" SortExpression="B" ReadOnly="True" HeaderText="B"
					DataField="B"></radg:GridBoundColumn>
			</Columns>
			<EditFormSettings CaptionFormatString="Custom editors:">
				<FormTableItemStyle Wrap="False" ForeColor="#000000"></FormTableItemStyle>
				<FormTableStyle CellSpacing="0" CellPadding="3" width="100%" BorderWidth="0"></FormTableStyle>
				<FormStyle Width="100%" CssClass="EditForm"></FormStyle>
			</EditFormSettings>
			<ExpandCollapseColumn ButtonType="ImageButton" Visible="False" UniqueName="ExpandColumn">
				<HeaderStyle Width="19px"></HeaderStyle>
			</ExpandCollapseColumn>
		</MasterTableView>
	</radg:radgrid>
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
