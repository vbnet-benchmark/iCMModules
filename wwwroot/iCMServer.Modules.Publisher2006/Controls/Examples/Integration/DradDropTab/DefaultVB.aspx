<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radTS" Namespace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page CodeBehind="DefaultVB.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Telerik.TabStripExamplesVBNET.Integration.Explorer.DefaultVB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:headtag id="Headtag1" runat="server"></telerik:headtag>
		<style type="text/css">.PageViewCss { BORDER-RIGHT: #62b454 1px solid; PADDING-RIGHT: 10px; PADDING-LEFT: 10px; FONT-SIZE: 8pt; PADDING-BOTTOM: 10px; BORDER-LEFT: #62b454 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #62b454 1px solid; FONT-FAMILY: Tahoma, Arial, sans-serif; BACKGROUND-COLOR: white }
	</style>
	</head>
	<body class="BODY">
		<form id="mainForm" style="WIDTH: 100%" method="post" runat="server">
			<telerik:header id="Header1" runat="server" NavigationLanguage="VB"></telerik:header>
			<script type="text/javascript">
/*<![CDATA[*/
var blnDragging = false;

function GetRealParent(e)
{
	var target = (document.all) ? e.srcElement : e.target;
	parentNode = target;
	while (parentNode != null)
	{
		if (parentNode.id)
		{
			if (-1 !=parentNode.id.indexOf("Page1"))
			{
				return "Page1";
			}
			else if (-1 !=parentNode.id.indexOf("Page2"))
			{
				return "Page2";
			}
			else if (-1 !=parentNode.id.indexOf("Page3"))
			{
				return "Page3";
			}
		}
		parentNode = parentNode.parentNode;
	}
	return null;
}

function tabMouseOver(sender, eventArgs)
{
	if (blnDragging)
		eventArgs.Tab.Click();
}

function BeforeDragHandler()
{
	blnDragging = true;
}
	
function BeforeDropHandler(source, dest, e)
{
	blnDragging = false;
	var dropTarget = GetRealParent(e);
	if 	(dropTarget != null)
	{
		var args = source.ClientID;
		if (dest)
			args += '\n' + dest.ClientID;
		source.TreeView.HtmlElementID = dropTarget; 
		window["<%= genericCallback.ClientID %>"].MakeCallback('TreeDrop'+dropTarget, args);
	}
	return (false);
}

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
			<radclb:radcallback id="genericCallback" runat="server" ClientEvents-OnRequestStart="showLoading" ClientEvents-OnResponseEnd="hideLoading"
				OnCallback="genericCallback_Callback"></radclb:radcallback>
			<div style="BORDER-RIGHT: #4f88d6 2px solid; PADDING-RIGHT: 14px; BORDER-TOP: #4f88d6 2px solid; PADDING-LEFT: 14px; PADDING-BOTTOM: 14px; BORDER-LEFT: #4f88d6 2px solid; PADDING-TOP: 14px; BORDER-BOTTOM: #4f88d6 2px solid; BACKGROUND-COLOR: #d8e6f5">
				<table cellspacing="0" cellpadding="5" border="0">
					<tr>
						<td valign="top"><radt:radtreeview id="RadTreeView1" Width="200" Height="300" DragAndDrop="True" ContentFile="RadTreeView.xml"
								ImagesBaseDir="Images/" BeforeClientDrag="BeforeDragHandler" BeforeClientDrop="BeforeDropHandler" Runat="server"></radt:radtreeview></td>
						<td valign="top">
							<asp:panel id="panelLoadingImage" style="DISPLAY: none; FONT-SIZE: 11px; Z-INDEX: 100; MARGIN: 40px 0px 0px 10px; VERTICAL-ALIGN: middle; COLOR: gray; POSITION: absolute; BACKGROUND-COLOR: white; TEXT-ALIGN: center"
								runat="server" Height="260" Width="362">
								<img style="VERTICAL-ALIGN: middle" alt="Loading..." src="Images/loading.gif" /></asp:panel>
							<radTS:RadTabStrip id="RadTabStrip1" Runat="server" Height="27px" Width="382px" SelectedIndex="0" OnClientMouseOver="tabMouseOver"
								Skin="Longhorn" MultiPageID="multiPageContent">
								<Tabs>
									<radTS:Tab ID="Tab1" Text="Outlook" Width="90"></radTS:Tab>
									<radTS:Tab ID="Tab2" Text="Source Safe" Width="90"></radTS:Tab>
									<radTS:Tab ID="Tab3" Text="Explorer" Width="90"></radTS:Tab>
								</Tabs>
							</radTS:RadTabStrip>
							<radts:RadMultiPage id="multiPageContent" Runat="server" Height="242px" SelectedIndex="0" CssClass="PageViewCss">
								<radts:PageView id="Page1" Runat="server">
									<br/>
									<b>Drop items inside the page to attach them to the email:</b><br/>
									<br/>
									<table cellspacing="0" cellpadding="0" border="0">
										<tr>
											<td>To:</td>
											<td>
												<asp:TextBox id="TextBoxTo" Runat="server"></asp:TextBox></td>
											<td style="width:30px" rowspan="3">&nbsp;</td>
											<td rowspan="3">
												<radclb:CallbackButton id="SendEmail" onclick="SendEmail_Click" ClientEvents-OnResponseEnd="hideLoading"
													ClientEvents-OnRequestStart="showLoading" Runat="server" CssClass="button" DisableAtCallback="True"
													Text="Send "></radclb:CallbackButton></td>
										</tr>
										<tr>
											<td>Cc:</td>
											<td>
												<asp:TextBox id="TextBoxCc" Runat="server"></asp:TextBox></td>
										</tr>
										<tr>
											<td>Subject:&nbsp;</td>
											<td>
												<asp:TextBox id="TextBoxSubject" Runat="server"></asp:TextBox></td>
										</tr>
									</table>
									<br/>
									<br/>
									<b>Attachments:</b><br/>
									<div style="OVERFLOW: auto; WIDTH: 300px; HEIGHT: 104px">
										<asp:Label id="Attachments" Runat="server"></asp:Label></div>
								</radts:PageView>
								<radts:PageView id="Page2" Runat="server">
									<br/>
									<b>Drop items here to add them to Source Safe:</b><br/>
									<br/>
									<radT:RadTreeView id="RadTreeView2" Runat="server" ImagesBaseDir="Images/" ContentFile="SourceSafe.xml"></radT:RadTreeView>
								</radts:PageView>
								<radts:PageView id="Page3" Runat="server">
									<br/>
									<b>Drop items here to copy them here:</b><br/>
									<br/>
									<div style="OVERFLOW: auto; HEIGHT: 212px">
										<asp:DataGrid id="DataGrid1" Runat="server" Width="300px" BorderStyle="None" BackColor="White"
											CellPadding="3">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
											<ItemStyle ForeColor="#000066"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#61B353"></HeaderStyle>
											<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
											<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></div>
								</radts:PageView>
							</radts:RadMultiPage>
						</td>
					</tr>
				</table>
			</div>
			<telerik:footer id="Footer1" runat="server"></telerik:footer></form>
	</body>
</html>
