<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndMenu.DefaultVB" Language="vb" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radm" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
		//<!--
		function ShowRadMenu(node, e)
		{		
			if (node.Category == "Folder")
			{
				RadMenu1.OnContext(e, node.TextElement());
			}
			else 
			{
				RadMenu2.OnContext(e, node.TextElement());
			}
		}
		function OnClick(menuItem)
		{

			var treeView = <%= RadTreeView1.ClientID %>;
			if (menuItem.Text == "Rename")
			{
				treeView.SelectedNode.StartEdit();
				menuItem.ParentMenu.CloseAll(0);
				menuItem.ParentMenu.HideMenu();
				return false;
			}
			if (menuItem.Text == "Disable")
			{
				treeView.SelectedNode.Disable();
				menuItem.ParentMenu.CloseAll(0);
				menuItem.ParentMenu.HideMenu();
				return false;
			}
			if (menuItem.Text == "Enable All")
			{
				for (var i=0; i < treeView.AllNodes.length; i++)
				{
					treeView.AllNodes[i].Enable();
				}
				menuItem.ParentMenu.CloseAll(0);
				menuItem.ParentMenu.HideMenu();
				return false;
			}
			if (menuItem.Text == "Expand")
			{
				treeView.SelectedNode.Expand();
				menuItem.ParentMenu.CloseAll(0);
				menuItem.ParentMenu.HideMenu();
				return false;
			}
			if (menuItem.Text == "Collapse")
			{
				treeView.SelectedNode.Collapse();
				menuItem.ParentMenu.CloseAll(0);
				menuItem.ParentMenu.HideMenu();
				return false;
			}
			
		}
		//-->
			</script>
			<div class="module" style="width:200px;">
				<radT:RadTreeView id="RadTreeView1" runat="server" ContentFile="tree.xml" Skin="Square/3DBlue" BeforeClientContextMenu="ShowRadMenu"></radT:RadTreeView>
			</div>
			<radm:RadMenu id="RadMenu1" runat="server" ContentFile="menu1.xml" IsContext="True" Theme="Office2003"
				MenuFlow="Vertical" AutoPostBack="True" OnClientClick="OnClick"></radm:RadMenu>
			<radm:RadMenu id="RadMenu2" runat="server" ContentFile="menu2.xml" IsContext="True" Theme="Office2003"
				MenuFlow="Vertical" AutoPostBack="True" OnClientClick="OnClick"></radm:RadMenu>
			<br />
			<br />
			<script type="text/javascript">		
			document.oncontextmenu = null;		
			</script>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
