<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radr" Namespace="Telerik.WebControls" Assembly="RadRotator" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radc" Namespace="Telerik.WebControls" Assembly="RadChart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegarationExamplesVBNET.Rotator.DefaultVB" Language="vb" %>
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
			<div class="module" style="float:left;">
				<asp:label id="Label2" runat="server" Font-Bold="True">Select a Gallery:</asp:label><br />
				<radclb:callbackdropdownlist id="ddlGalery" runat="server" DisableAtCallback="true" Width="124px">
					<asp:ListItem Value="Gallery 1">Home Interior</asp:ListItem>
					<asp:ListItem Value="Gallery 2">Residence Exterior</asp:ListItem>
					<asp:ListItem Value="Gallery 3">Miscellaneous</asp:ListItem>
				</radclb:callbackdropdownlist>
				<br />
				<br />
				<asp:Label id="Label3" runat="server" Font-Bold="True">Select a speed</asp:Label>
				<asp:Label id="Label5" runat="server"> (1000 - 3000):</asp:Label><br />
				<asp:TextBox id="tbFrameTimeout" runat="server" Width="124px"></asp:TextBox>
				<asp:Label id="Label4" runat="server">ms</asp:Label>
				<br />
				<br />
				<radclb:CallbackButton id="btnApply" runat="server" Width="211px" CssClass="button" Text="Apply" DisableAtCallback="true"></radclb:CallbackButton>
				<br />
				<br />
				<br />
				<asp:label id="Label1" runat="server" Font-Bold="True">Select Transition Effect:</asp:label><br />
				<radclb:callbackradiobuttonlist id="CallbackRadioButtonList1" runat="server" RepeatColumns="2" DisableAtCallback="true"></radclb:callbackradiobuttonlist>
			</div>
			<div style="padding:10px;border: 1px solid #aeb38b;margin-left:280px;width:230px;height:170px;background-color:#e0e7b3;">
				<radR:RadRotator id="RadRotator1" runat="server" TransitionEffect="Pixelate" SmoothScrollDelay="5"
					ScrollDirection="Left" FrameTimeout="2000" height="170px" width="230px">
					<FrameTemplate>
						<div class="details">
							<div class="day"><img runat="server" src='<%# DataBinder.Eval(Container.DataItem, "Image") %>'  ID="Img1" alt="rotatoritem"/></div>
						</div>
					</FrameTemplate>
				</radR:RadRotator>
			</div>
			<br />
			<div style="clear:both;"></div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
