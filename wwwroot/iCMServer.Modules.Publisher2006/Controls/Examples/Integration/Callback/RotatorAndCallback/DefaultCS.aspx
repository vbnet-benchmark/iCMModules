<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radr" Namespace="Telerik.WebControls" Assembly="RadRotator" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegarationExamplesCSharp.RotatorAndCallback.DefaultCS" Language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:headtag id="Headtag1" runat="server"></telerik:headtag>
		<!-- custom head section -->
		<!-- end of custom head section -->
		<link rel="stylesheet" type="text/css" href="Styles.css"></link>
	</head>
	<body class="BODY">
		<form id="mainForm" style="WIDTH: 100%" method="post" runat="server">
			<telerik:header id="Header1" runat="server" NavigationLanguage="C#"></telerik:header>
			<!-- content start -->
			<script type="text/javascript">
/*<![CDATA[*/
function hideLoading()
{
	var imagePreview = document.getElementById("<%= imagePreview.ClientID %>");
	if (imagePreview) imagePreview.style.display = "block";
	var panelImagePreviewLoading = document.getElementById("<%= panelImagePreviewLoading.ClientID %>");
	if (panelImagePreviewLoading) panelImagePreviewLoading.style.display = "none";
	var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
	if (panelLoadingImage) panelLoadingImage.style.display = "none";
}

function showLoading()
{
	var imagePreview = document.getElementById("<%= imagePreview.ClientID %>");
	if (imagePreview) imagePreview.style.display = "none";
	var panelImagePreviewLoading = document.getElementById("<%= panelImagePreviewLoading.ClientID %>");
	if (panelImagePreviewLoading) panelImagePreviewLoading.style.display = "block";
	var panelLoadingImage = document.getElementById("<%= panelLoadingImage.ClientID %>");
	if (panelLoadingImage) panelLoadingImage.style.display = "block";
}
/*]]>*/
			</script>
			<radclb:radcallback id="genericCallback" runat="server" allowothercallbacks="False"
				oncallback="genericCallback_Callback" ClientEvents-OnRequestStart="showLoading" ClientEvents-OnResponseEnd="hideLoading"></radclb:radcallback>
			<table width="743" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td valign="top"><img src="Images/White.gif" height="22" width="60" alt="" /></td>
					<td valign="top"><img src="Images/cornerLeftTop.gif" height="22" width="50" alt="" /></td>
					<td valign="top"><img src="Images/topLeft.gif" height="22" width="292" alt="" /></td>
					<td valign="top"><img src="Images/topRight.gif" height="22" width="280" alt="" /></td>
					<td valign="top"><img src="Images/cornerRightTop.gif" height="22" width="62" alt="" /></td>
				</tr>
				<tr>
					<td valign="top"><img src="Images/whiteMiddle.gif" height="243" width="60" alt="" /></td>
					<td valign="top"><img src="Images/leftFrame.gif" height="243" width="50" alt="" /></td>
					<td class="previewPane" valign="top"><asp:panel id="panelImagePreviewLoading" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;TEXT-ALIGN: center"
							runat="server">Loading...<img style="VERTICAL-ALIGN: middle" alt="Loading..." src="Images/loading.gif" /></asp:panel><div style="MARGIN-TOP: 20px"><radclb:CallbackImage id="imagePreview" Runat="server" ImageUrl="Images/spacer.gif" Height="192px" Width="272px" AlternateText="preview"></radclb:CallbackImage></div>
					</td>
					<td class="infoPane" valign="top">
						<div class="infoPaneBg">
							<div class="imageDetailsHeader">Image details:</div>
							<asp:panel id="viewPanel" Runat="server">
								<div class="details"><strong>Name:</strong>&nbsp;
									<asp:label id="labelImageName" runat="server"></asp:label></div>
								<div class="details"><strong>Keywords:</strong>&nbsp;
									<asp:label id="labelImageKeywords" runat="server"></asp:label></div>
								<div class="details"><strong>Comments:</strong>&nbsp;
									<asp:label id="labelImageComments" runat="server"></asp:label></div>
								<div class="details" style="MARGIN-TOP: 5px; MARGIN-LEFT: 28px"><a href="javascript:buttonEditClicked();"><img style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
											height="20" alt="" src="Images/editBtn.gif" width="44" /></a></div>
							</asp:panel>
							<asp:panel style="DISPLAY: none" id="editPanel" Runat="server">
								<div class="details"><strong>Name:</strong>&nbsp;
									<asp:textbox id="textImageName" runat="server" CssClass="detailsTxtBox"></asp:textbox></div>
								<div class="details"><strong>Keywords:</strong>&nbsp;
									<asp:textbox id="textImageKeywords" runat="server" CssClass="detailsTxtBox"></asp:textbox></div>
								<div class="details"><strong>Comments:</strong>&nbsp;
									<asp:textbox id="textImageComments" runat="server" CssClass="detailsTxtBox"></asp:textbox></div>
								<div class="details">&nbsp;<a class="editBtns" href="javascript:buttonUpdateClicked();">OK</a>
									<a class="editBtns" href="javascript:buttonCancelClicked();">Cancel</a></div>
							</asp:panel>
							<asp:panel id="panelLoadingImage" style="DISPLAY: none;FONT-SIZE: 11px;VERTICAL-ALIGN: middle;COLOR: gray;TEXT-ALIGN: center"
								runat="server">Loading...<img style="VERTICAL-ALIGN: middle" alt="Loading..." src="Images/loading.gif" /></asp:panel>
						</div>
					</td>
					<td valign="top"><img src="Images/rightFrame.gif" height="243" width="62" alt="" /></td>
				</tr>
				<tr>
					<td valign="top"><img src="Images/whiteShadow.gif" height="117" width="60" alt="" /></td>
					<td valign="top"><img src="Images/left.gif" id="img_left" height="117" width="50" alt="" style="CURSOR: pointer" /></td>
					<td colspan="2" class="thumbsViewer" valign="top">
						<radr:radrotator id="thumbRotator" runat="server" AutoAdvance="false" width="572" TransitionType="Scroll"
							ScrollDirection="Left" FrameTimeout="0" ScrollSpeed="10" FramesToShow="6" UseSmoothScroll="False">
							<FrameTemplate>
								<div style="text-align:center">
									<img src='Images/<%# DataBinder.Eval(Container.DataItem,"Image") %>' alt='' style='margin:0px 11px;' onclick='showCallbackImage(this)' /><br />
									<%# DataBinder.Eval(Container.DataItem,"Name") %>
								</div>
							</FrameTemplate>
						</radr:radrotator>
					</td>
					<td valign="top"><img src="Images/right.gif" id="img_right" height="117" width="62" alt="" style="CURSOR: pointer" /></td>
				</tr>
			</table>
			<script type="text/javascript">
/*<![CDATA[*/
document.getElementById("img_right").onmouseover = function() {<%= thumbRotator.ClientID %>.ScrollDirection="left";<%= thumbRotator.ClientID %>.StartRotator();}
document.getElementById("img_left").onmouseover = function() {<%= thumbRotator.ClientID %>.ScrollDirection="right";<%= thumbRotator.ClientID %>.StartRotator();}
document.getElementById("img_right").onmouseout = function() {<%= thumbRotator.ClientID %>.StopRotator();}
document.getElementById("img_left").onmouseout = function() {<%= thumbRotator.ClientID %>.StopRotator();}
	function showCallbackImage(srcElement)
	{
		window["<%= genericCallback.ClientID %>"].MakeCallback("ShowImage", srcElement.src);
	}
	function buttonEditClicked()
	{
		var panelViewImage = document.getElementById("<%= viewPanel.ClientID %>");
		panelViewImage.style.display = "none";
		var panelEditImage = document.getElementById("<%= editPanel.ClientID %>");
		panelEditImage.style.display = "block";
	}
	function buttonUpdateClicked()
	{
		var panelViewImage = document.getElementById("<%= viewPanel.ClientID %>");
		panelViewImage.style.display = "block";
		var panelEditImage = document.getElementById("<%= editPanel.ClientID %>");
		panelEditImage.style.display = "none";
		window["<%= genericCallback.ClientID %>"].MakeCallback("UpdateImageSettings",null);
	}
	function buttonCancelClicked()
	{
		var panelViewImage = document.getElementById("<%= viewPanel.ClientID %>");
		panelViewImage.style.display = "block";
		var panelEditImage = document.getElementById("<%= editPanel.ClientID %>");
		panelEditImage.style.display = "none";
	}
/*]]>*/
			</script>
			<!-- content end --><telerik:footer id="Footer1" runat="server"></telerik:footer></form>
	</body>
</html>
