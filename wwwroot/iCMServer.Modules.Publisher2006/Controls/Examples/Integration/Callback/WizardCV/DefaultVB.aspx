<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radts" Namespace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Register TagPrefix="rade" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page ValidateRequest="false" AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegarationExamplesVBNET.WizardCV.DefaultVB" Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:headtag id="Headtag1" runat="server"></telerik:headtag>
		<!-- custom head section -->
		<!-- end of custom head section -->
		<style type="text/css">
		.inputs
		{
			padding: 20px;
		}
		.label
		{
			width: 100px;
			float: left;
			height: 26px;
		}
		br
		{
			clear:both;
		}
		</style>
	</head>
	<body class="BODY">
		<form id="mainForm" style="WIDTH: 100%" method="post" runat="server">
			<telerik:header id="Header1" runat="server" NavigationLanguage="VB" XhtmlCompliant="False"></telerik:header>
			<!-- content start -->
			<script type="text/javascript">
/*<![CDATA[*/			
function showLoading()
{
	var panelLoading = document.getElementById("<%= panelLoading.ClientID %>");
	if (panelLoading) panelLoading.style.display = "block";
}

function hideLoading()
{
	var panelLoading = document.getElementById("<%= panelLoading.ClientID %>");
	if (panelLoading) panelLoading.style.display = "none";
}
/*]]>*/
			</script>
			<div style="background-image:url(Images/bg.gif);background-repeat: repeat-x;background-position: left 32px;">
				<div style="background-image:url(Images/left.jpg);background-repeat: no-repeat;background-position: left 32px;">
					<!-- preview part -->
					<div style="float:right;width:302px;margin-right:16px;"><img src="images/previewTop.gif" alt="" /><div style="width:277px;padding:10px;background-color:white;border-left:1px solid #dedede;border-right:4px solid #cccccc;">
							<div style="font-size:18px;border-bottom:1px solid silver;">CV Preview:</div>
							<div style="border-bottom:1px dotted silver;font-weight:bold;margin-top:11px;clear:both;">Personal 
								Info</div>
							<asp:Label ID="labelPersonal" Runat="server"></asp:Label>
							<div style="border-bottom:1px dotted silver;font-weight:bold;margin-top:11px;clear:both;">Educational 
								Info</div>
							<asp:Label ID="labelEducation" Runat="server"></asp:Label>
							<div style="border-bottom:1px dotted silver;font-weight:bold;margin-top:11px;clear:both;">Professional 
								Info</div>
							<asp:Label ID="labelEmployment" Runat="server"></asp:Label>
							<div style="border-bottom:1px dotted silver;font-weight:bold;margin-top:11px;clear:both;">Motivation 
								Letter:</div>
							<asp:Label id="labelMotivation" Runat="server"></asp:Label></div><img src="images/previewBottom.gif" alt="" /></div>
					<!-- preview part end -->
					<!-- wizard part -->
					<radts:RadTabstrip id="tabWizard" runat="server" Theme="HorizontalTabs" SelectedIndex="0" MultiPageId="multipageWizard" Width="400">
						<Tabs>
							<radts:tab id="tabPersonal" Text="Personal Info" PageViewID="Page0"></radts:tab>
							<radts:tab id="tabEducation" Text="Educational Info" Enabled="False" PageViewID="Page1"></radts:tab>
							<radts:tab id="tabProfessional" Text="Professional Info" Enabled="False" PageViewID="Page2"></radts:tab>
							<radts:tab id="tabMotivation" Text="Motivation Letter" Enabled="False" PageViewID="Page3"></radts:tab>
						</Tabs>
					</radts:RadTabstrip>
					<div style="float:left;" class="inputs">
						<radts:RadMultiPage id="multipageWizard" runat="server" SelectedIndex="0">
							<radts:PageView ID="Page0" Runat="server" />
							<radts:PageView ID="Page1" Runat="server" />
							<radts:PageView ID="Page2" Runat="server" />
							<radts:PageView ID="Page3" Runat="server">
								<rade:RadEditor id="editorMotivation" runat="server" Editable="true" Width="300px" ToolsFile="ToolsFile.xml"
									ShowSubmitCancelButtons="False" EnableDocking="false"></rade:RadEditor>
							</radts:PageView>
							<radts:PageView ID="Page4" Runat="server">
						Thank You for submitting your CV! <a href="javascript:window.location.reload();">Start Over</a>
						</radts:PageView>
						</radts:RadMultiPage>
						<radclb:CallbackButton id="buttonNext" runat="server" onclick="submitCV" CssClass="button" Text="Next"
							width="100" DisableAtCallback="true" ClientEvents-OnResponseEnd="hideLoading" ClientEvents-OnRequestStart="showLoading" />
						<asp:panel id="panelLoading" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;BACKGROUND-COLOR: white;TEXT-ALIGN: center"
							runat="server">
							<img style="VERTICAL-ALIGN: middle" src="Images/loading.gif" alt="Loading..." /></asp:panel>
					</div>
					<br />
					<!-- wizard part end -->
				</div>
			</div>
			<!-- content end -->
			<telerik:footer id="Footer1" runat="server"></telerik:footer>
		</form>
	</body>
</html>
