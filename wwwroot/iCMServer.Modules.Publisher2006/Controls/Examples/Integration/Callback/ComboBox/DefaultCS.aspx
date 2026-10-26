<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radc" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegrationExamplesCSharp.ComboBox.DefaultCS" Language="c#" %>
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->		
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#" XhtmlCompliant="False"></telerik:Header>
			<!-- content start -->		
			<script type="text/javascript">
			/*<![CDATA[*/
				function test(item)
				{
					window["<%= RadCallback1.ClientID %>"].MakeCallback('combo', item.Text);
				}
			/*]]>*/
			</script>
			<div class="module" style="float:left;width: 330px;height:280px;">
			<asp:Label id="Label2" runat="server"
				style="padding-right:21px;" Font-Bold="True">Populate combobox:</asp:Label>
			<radclb:CallbackDropDownList id="CallbackDropDownList1" 
				runat="server" DisableAtCallback="true" Width="120px">
				<asp:ListItem Value="Not Bound">Not Bound</asp:ListItem>
				<asp:ListItem Value="Continents">Continents</asp:ListItem>
				<asp:ListItem Value="Countries">Countries</asp:ListItem>
				<asp:ListItem Value="Cities">Cities</asp:ListItem>
			</radclb:CallbackDropDownList><br /><br />
			<asp:TextBox id="tbNewItem" runat="server"
				Width="133px"></asp:TextBox>&nbsp;<br/>
			<radclb:callbackbutton id="btnAddNewItem" CssClass="button"
				runat="server" Width="120px" Text="Add New Item" DisableAtCallback="true"></radclb:callbackbutton>
			<radclb:callbackbutton id="btnRemoveItem" CssClass="button"
				runat="server" DisableAtCallback="true" Text="Remove Item" Width="120px" style="vertical-align:middle;"></radclb:callbackbutton>
			<br/><br/><hr/><br/>
			<radclb:RadCallback id="RadCallback1" runat="server"></radclb:RadCallback>
			<div style="border:1px solid #aca899;background-color:#ffffe1;padding: 11px;width: 300px;">
				<b>r.a.d.combobox:</b><br/>
				<br />
				<radc:RadComboBox id="RadComboBox1" runat="server" Width="120px" Height="200px" OnClientSelectedIndexChanging="test"></radc:RadComboBox>
				
			</div>
			<asp:Label id="lblStatus" runat="server"
				Width="224px" style="color:green;"></asp:Label>
			</div>
			<div class="module" style="width: 200px;height:260px;margin-left:360px;">
				<asp:Label id="Label1" runat="server"
				Width="224px" Font-Bold="True">Select a combobox skin:</asp:Label><br />
				<radclb:CallbackRadioButtonList id="rblSkin" DisableAtCallback="true" runat="server">
					<asp:ListItem Value="Brick">Brick</asp:ListItem>
					<asp:ListItem Value="Classic" Selected="True">Classic</asp:ListItem>
					<asp:ListItem Value="ClassicBlue">ClassicBlues</asp:ListItem>
					<asp:ListItem Value="ClassicGold">ClassicGold</asp:ListItem>
					<asp:ListItem Value="Mac">Mac</asp:ListItem>
					<asp:ListItem Value="Outlook">Outlook</asp:ListItem>
					<asp:ListItem Value="Rtl">Rtl</asp:ListItem>
					<asp:ListItem Value="VSNET">VSNET</asp:ListItem>
					<asp:ListItem Value="WhiteRound">WhiteRound</asp:ListItem>
					<asp:ListItem Value="WindowsGray">WindowsGray</asp:ListItem>
					<asp:ListItem Value="WindowsOlive">WindowsOlive</asp:ListItem>
					<asp:ListItem Value="WindowsXP">WindowsXP</asp:ListItem>
				</radclb:CallbackRadioButtonList>
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
