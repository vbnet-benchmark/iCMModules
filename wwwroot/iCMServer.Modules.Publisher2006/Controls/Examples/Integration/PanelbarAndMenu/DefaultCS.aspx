<%@ Register TagPrefix="radM" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="radp" Namespace="Telerik.WebControls" Assembly="RadPanelbar" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page CodeBehind="DefaultCS.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Telerik.MenuExamplesCSharp.Integration.PanelbarAndMenu.DefaultCS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="C#"></telerik:Header>
			<radP:RadPanelbar ID="RadPanelbar1" 
                    runat="server" 
                    Theme="WinXP" 
                    HeaderCollapsedCssClass="panelbarHeaderCollapsed" 
                    HeaderExpandedCssClass="panelbarHeaderExpand" 
                    HeaderHoverCollapsedCssClass="panelbarHeaderHover" 
                    HeaderHoverExpandedCssClass="panelbarHeaderHover" 
                    ItemCollapsedCssClass="panelbarItem" 
                    ItemHoverCollapsedCssClass="panelbarItemHover" 
                    ItemHoverExpandedCssClass="panelbarItemHover" 
                    ItemSelectedCssClass="panelbarItemHover" 
                    ContentFile="panelbar.xml"
                    Width="188px">
                    <PanelItemTemplates>
                        <radP:PanelItemTemplate ID="MenuTemplate">
                            <ContentTemplate>
                                <radm:radmenu id="RadMenu1" 
                                    Width = "166"
                                    runat="server"
                                    ContentFile="menu.xml"
                                    Theme="WinXP"
                                    />
                            </ContentTemplate>
                        </radP:PanelItemTemplate>
                         <radP:PanelItemTemplate ID="MenuTemplate2">
                            <ContentTemplate>
                                <radm:radmenu id="Radmenu2" 
                                    Width = "166"
                                    runat="server"
                                    ContentFile="menu2.xml"
                                    Theme="WinXP"
                                    />
                            </ContentTemplate>
                        </radP:PanelItemTemplate>
                    </PanelItemTemplates>
                </radP:RadPanelbar>
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>
