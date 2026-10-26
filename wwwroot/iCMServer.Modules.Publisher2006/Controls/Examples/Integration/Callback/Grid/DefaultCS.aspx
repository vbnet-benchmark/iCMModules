<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radg" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegrationExamplesCSharp.Grid.DefaultCS" Language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css">
		.RadGrid th, .RadGrid th a
		{ 
		    font: bold 11px Tahoma;
		    color: white;
		}
	
		.RadGrid td, .RadGrid td a
		{ 
		    font: 11px tahoma;
		    color: #000000;
		}
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
			<div class="module" style="HEIGHT:80px;width:390px;">
				<b>Select r.a.d.grid edit mode:</b><br />
				<radCLB:CallbackRadioButtonList id="CallbackRadioButtonList1" runat="server" DisableAtCallback="true">
					<asp:ListItem Value="mode 1" Selected="True">in-forms editing mode</asp:ListItem>
					<asp:ListItem Value="mode 2">in-line editing mode</asp:ListItem>
				</radCLB:CallbackRadioButtonList>
				<hr />
				<asp:Label id="Label1" runat="server">Hint: Edit a grid row and then switch between the two edit modes.</asp:Label>
			</div>
			<br />
			<br />
			<radG:RadGrid id="RadGrid1" runat="server" CssClass="RadGrid" Width="100%" AllowPaging="True"
				AllowSorting="True" PageSize="10" ShowFooter="True" Gridlines="Horizontal" BorderWidth="1"
				EnableAsyncRequests="true">
				<MasterTableView>
					<Columns>
						<radg:GridEditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
							<HeaderStyle Width="40"></HeaderStyle>
						</radg:GridEditCommandColumn>
					</Columns>
				</MasterTableView>
				<PagerStyle Mode="NumericPages" CssClass="RadGridPager"></PagerStyle>
				<PagerStyle Mode="NumericPages" BackColor="#E5EEF3"></PagerStyle>
				<HeaderStyle Height="40" BackColor="#5898C5" ForeColor="#ffffff"></HeaderStyle>
				<FooterStyle CssClass="MyStyle"></FooterStyle>
				<ItemStyle BackColor="#F2F9FF" Height="20"></ItemStyle>
				<AlternatingItemStyle BackColor="#FFFFFF" Height="20"></AlternatingItemStyle>
				<EditItemStyle BackColor="#E5EEF3" Height="35"></EditItemStyle>
				<SelectedItemStyle CssClass="RadGridSelectedItem"></SelectedItemStyle>
			</radG:RadGrid>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
