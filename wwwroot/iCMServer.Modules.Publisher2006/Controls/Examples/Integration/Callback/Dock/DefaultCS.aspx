<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegrationExamplesCSharp.Dock.DefaultCS" Language="c#" %>
<%@ Register TagPrefix="radDk" Namespace="Telerik.WebControls" Assembly="RadDock" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<HTML>
	<HEAD>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</HEAD>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<raddk:raddockingmanager id="RadDockingManager1" runat="server" Width="99px"></raddk:raddockingmanager>
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#" XhtmlCompliant="False"></telerik:Header>
			<!-- content start -->
			<div class="module" style="float:left;width:300px;margin-right:20px;">
			<asp:label id="Label2" runat="server" style="color:green;"></asp:label><br/>
			<asp:TextBox id="tbConfigName" 
				runat="server" Width="90px" MaxLength="20"></asp:TextBox>
			<radclb:callbackbutton  id="btnSaveState" CssClass="button"
				runat="server" DisableAtCallback="true" Text="Save Dock Configuration" Width="160px"></radclb:callbackbutton><br/><br/>
				<asp:Label id="Label5" runat="server"
				Font-Bold="True">Saved Dock Configurations:</asp:Label><br/>
				<asp:listbox id="lbSavedConfigs" 
				runat="server" Width="266px" Height="287px" /><br/><radclb:callbackbutton id="btnLoadState" 
				 runat="server" CssClass="button" DisableAtCallback="true" Text="Load State" Width="266px"></radclb:callbackbutton>
			</div>
			<div style="float:right;"><asp:Panel ID="Panel1" Runat="server">
				<radDk:RadDockingZone id="dockZone1" runat="server" Width="345px" Height="121px" style="text-align:center;padding-top:16px;">
					<radDk:RadDockableObject id="dockObject1" runat="server" Width="266px" Height="84px" DockingMode="AlwaysDock"
						Text="Dockable Object 1">
						<ContentTemplate>
							<asp:Label id="Label11" runat="server">Label 1</asp:Label>
							<radclb:CallbackButton  id="CallbackButton1" onclick="Button_Click" runat="server" DisableAtCallback="true" Text="Update Label in Dock Object 2"
								BackColor="ActiveBorder"></radclb:CallbackButton>
						</ContentTemplate>
						<Commands>
							<raddk:RadDockableObjectCommand ToolTip="Expand" Name="Expand" Enabled="False"></raddk:RadDockableObjectCommand>
							<raddk:RadDockableObjectCommand ToolTip="Collapse" Name="Collapse"></raddk:RadDockableObjectCommand>
						</Commands>
					</radDk:RadDockableObject>
				</radDk:RadDockingZone>
			</asp:Panel><br/><asp:Panel ID="Panel2" Runat="server">
				<radDk:RadDockingZone id="dockZone2" runat="server" Width="345px" Height="121px" style="text-align:center;padding-top:16px;">
					<radDk:RadDockableObject id="dockObject2" runat="server" Width="266px" Height="84px" DockingMode="AlwaysDock"
						Text="Dockable Object 2">
						<ContentTemplate>
							<asp:Label id="Label21" runat="server">Label 2</asp:Label>
							<radclb:CallbackButton  id="CallbackButton2" runat="server" DisableAtCallback="true" OnClick="Button_Click" Text="Update Label in Dock Object 3" BackColor="ActiveBorder"></radclb:CallbackButton>
						</ContentTemplate>
						<Commands>
							<raddk:RadDockableObjectCommand ToolTip="Expand" Name="Expand" Enabled="False"></raddk:RadDockableObjectCommand>
							<raddk:RadDockableObjectCommand ToolTip="Collapse" Name="Collapse"></raddk:RadDockableObjectCommand>
						</Commands>
					</radDk:RadDockableObject>
				</radDk:RadDockingZone>
			</asp:Panel><br/><asp:Panel ID="Panel3" Runat="server">
				<radDk:RadDockingZone id="dockZone3" runat="server" Width="345px" Height="121px" style="text-align:center;padding-top:16px;">
					<radDk:RadDockableObject id="dockObject3" runat="server" Width="266px" Height="84px" DockingMode="AlwaysDock"
						Text="Dockable Object 3">
						<ContentTemplate>
							<asp:Label id="Label31" runat="server">Label 3</asp:Label>
							<radclb:CallbackButton  id="CallbackButton3" runat="server" DisableAtCallback="true" OnClick="Button_Click" Text="Update Label in Dock Object 1" BackColor="ActiveBorder"></radclb:CallbackButton>
						</ContentTemplate>
						<Commands>
							<raddk:RadDockableObjectCommand ToolTip="Expand" Name="Expand" Enabled="False"></raddk:RadDockableObjectCommand>
							<raddk:RadDockableObjectCommand ToolTip="Collapse" Name="Collapse"></raddk:RadDockableObjectCommand>
						</Commands>
					</radDk:RadDockableObject>
				</radDk:RadDockingZone>
			</asp:Panel></div>
			<br/>
			<div style="clear:both;"></div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</HTML>
