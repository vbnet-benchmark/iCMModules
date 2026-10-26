<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radm" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegrationExamplesVBNET.Menu.DefaultVB" Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
			/*<![CDATA[*/			
				function makeCallback(item)
				{				
					window["<%= RadCallback1.ClientID %>"].MakeCallback("menu", escape(item.Text) + "\n" + ((item.Category) ? item.Category : ""));
				}	
			/*]]>*/							
			</script>
			<radM:RadMenu id="RadMenu1" runat="server" Overlay="True" Width="126px" ScrollDownDisabledImage="~/RadControls/Menu/Images/bottomscrolld.gif"
				ScrollDownImage="~/RadControls/Menu/Images/bottomscroll.gif" ScrollUpDisabledImage="~/RadControls/Menu/Images/topscrolld.gif"
				ScrollLeftImage="~/RadControls/Menu/Images/leftscroll.gif" GroupChildrenImage="~/RadControls/Menu/Images/arrow.gif"
				ScrollLeftImageDisabled="~/RadControls/Menu/Images/leftscrolld.gif" RequiresFilterSupport="False"
				ScrollUpImage="~/RadControls/Menu/Images/topscroll.gif" ScrollRightImageDisabled="~/RadControls/Menu/Images/rightscrolld.gif"
				Theme="CssGreen" ScrollRightImage="~/RadControls/Menu/Images/rightscroll.gif" DefaultItemClickedCss="MenuItemOver"
				OnClientClick="makeCallback">
				<RootGroupPersistable>
					<radm:MenuItem Selected="True" Text="Menu 1"></radm:MenuItem>
					<radm:MenuItem Text="Menu 2"></radm:MenuItem>
				</RootGroupPersistable>
			</radM:RadMenu>
			<br />
			<div class="module" style="HEIGHT:150px">
				<asp:label id="Label1" runat="server" Font-Bold="True">Selected Menu Item:</asp:label>
				<asp:label id="lBreadCrumb" runat="server" Width="456px" BackColor="#FFFFC0" style="font-weigh:bold"></asp:label>
				<radclb:callbackbutton id="btnRemove" OnClick="btnRemove_Click" runat="server" DisableAtCallback="true"
					Width="110px" Text="Remove Item" style="MARGIN-LEFT:15px;VERTICAL-ALIGN:middle" CssClass="button"></radclb:callbackbutton>
				<radclb:callbackbutton id="btnDisable" OnClick="btnDisable_Click" runat="server" DisableAtCallback="true"
					Width="110px" Text="Disable Item" style="VERTICAL-ALIGN:middle" CssClass="button"></radclb:callbackbutton>
				<br />
				<br />
				<asp:textbox id="tbItemText" runat="server" Width="128px"></asp:textbox>
				<radclb:callbackbutton id="btnAddChild" OnClick="btnAddChild_Click" runat="server" DisableAtCallback="true"
					Width="110px" Text="Add Child Item" CssClass="button"></radclb:callbackbutton>
				<radclb:callbackbutton id="btnAddRoot" OnClick="btnAddRoot_Click" runat="server" DisableAtCallback="true"
					Width="110px" Text="Add Root Item" CssClass="button"></radclb:callbackbutton>
				<hr />
				<div style="FLOAT:left;MARGIN-RIGHT:10px">
					<asp:label id="Label2" runat="server" Font-Bold="True">Rebind r.a.d.menu:</asp:label><br />
					<radclb:callbacklistbox id="lbDataSource" runat="server" DisableAtCallback="true" Height="66px" Width="128px"
						OnSelectedIndexChanged="lbDataSource_SelectedIndexChanged">
						<asp:ListItem Value="Programmatically" Selected="True">Programmatically</asp:ListItem>
						<asp:ListItem Value="XML File">XML File</asp:ListItem>
						<asp:ListItem Value="Database">Database</asp:ListItem>
					</radclb:callbacklistbox>
				</div>
				<asp:Panel ID="pCart" Runat="server" style="MARGIN-LEFT:170px" Width="300px">
					<asp:label id="Label3" runat="server" Font-Bold="True" Visible="False">Shopping Cart:</asp:label>
					<asp:ListBox id="lbShoppingCart" runat="server" Width="251px" Height="59px" Visible="False"></asp:ListBox>
				</asp:Panel>
				<radclb:radcallback id="RadCallback1" OnCallback="RadCallback1_Callback" runat="server"></radclb:radcallback>
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
