<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page CodeBehind="DefaultVB.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Telerik.ComboboxExamplesVBNET.Integration.Booking.DefaultVB" %>
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<link rel="stylesheet" type="text/css" href="ExampleFiles/Expedia.css"></link>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="VB" XhtmlCompliant="false"></telerik:Header>
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
/*]]>*/
		</script>
			<div class="expWrapper">
				<div class="expHeader"></div>
				<table cellpadding="0" cellspacing="0" class="expTbl">
					<tr>
						<td class="chooseService">&nbsp;</td>
						<td class="tdCenter" style="float: right;">
							<div class="callBckDiv">
								<div style="float: left; width: 64px;">
									<radclb:CallbackRadioButtonList 
										id="callbackRadioButtonList" 
										runat="server" 
										 CssClass="expRdBtn"
										OnSelectedIndexChanged="callbackRadioButtonList_IndexChanged"
										ClientEvents-OnRequestStart="showLoading" 
										ClientEvents-OnResponseEnd="hideLoading" DisableAtCallback="true">
										<asp:ListItem selected="true">Flight</asp:ListItem>
										<asp:ListItem>Hotel</asp:ListItem>
										<asp:ListItem>Car</asp:ListItem>
									</radclb:CallbackRadioButtonList>
								</div>
								<div style="float: left;width: 282px; font-size: 11px; color: #5a787c;">
									<asp:Panel ID="panelOptions" Runat="server"></asp:Panel>
								</div>
								<div style="margin-left: 115px;font-size: 11px; color: #5a787c;"><br />
									<radclb:CallbackButton 
										id="callbackSubmit" 
										Text="Search" 
										Runat="server" 
										OnClick="callbackSubmit_Clicked"
										ClientEvents-OnRequestStart="showLoading" 
										ClientEvents-OnResponseEnd="hideLoading" 
										CssClass="expBtnSrch"
										DisableAtCallback="true">
									</radclb:CallbackButton><br/>
									<asp:Label id="labelSelection" runat="server"></asp:Label>
								</div>
								<div style="margin-left: 115px;">
									<asp:panel 
										id="panelLoadingImage" 
										style="display: none; vertical-align: middle;text-align:center;padding:10px;"
										runat="server"><img style="vertical-align: middle;" alt="Loading..." src="ExampleFiles/loading.gif" /></asp:panel>
								</div>
							</div>
						</td>
						<td class="tdRight"><img src="ExampleFiles/tdRight.gif" height="119" width="87" alt="" class="expGrip" /></td>
					</tr>
					<tr>
						<td colspan="3" class="expFooter">&nbsp;</td>
					</tr>
				</table>
			</div>
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>
