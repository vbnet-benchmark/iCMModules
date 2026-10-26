<%@ Register TagPrefix="radP" Namespace="Telerik.WebControls" Assembly="RadPanelbar" %>
<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page CodeBehind="DefaultCS.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Telerik.PanelbarExamplesCSharp.Integration.DefaultCS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<script type="text/javascript">
			var blnDragging = false;
		    
			function panelMouseOver(obj)
			{
				if ((obj.ID == "Panel2" || obj.ID == "Panel1") && (blnDragging))
				{
					obj.Expand();
				}		
			}
		    
			function BeforeDragHandler()
			{
				blnDragging = true;
			}
			
			function BeforeDropHandler()
			{
				blnDragging = false;	
			}

			function AfterMoveHandler(e)
			{
				status = e.srcElement.id;
			}
		</script>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="C#"></telerik:Header>
			<radp:RadPanelbar id="RadPanelbar1" Runat="server" Theme="Outlook" Width="250px" ClientMouseOver="panelMouseOver" 
			ContentFile="Panelbar.xml">
				<PanelItemTemplates>
					<radp:PanelItemTemplate ID="Template1">
						<ContentTemplate>
							<radt:RadTreeView id="RadTreeView1" runat="server" ContentFile="tree.xml" DragAndDrop="True"
								ImagesBaseDir="Img/" BeforeClientDrag="BeforeDragHandler" BeforeClientDrop="BeforeDropHandler"
								AfterClientMove="AfterMoveHandler" MultipleSelect="True" OnNodeDrop="TreeDrop"></radt:RadTreeView>
						</ContentTemplate>
					</radp:PanelItemTemplate>
					<radp:PanelItemTemplate ID="Template2">
						<ContentTemplate>
							<radt:RadTreeView id="RadTreeView2" runat="server" ContentFile="tree.xml" DragAndDrop="True" ImagesBaseDir="Img/"
								MultipleSelect="True" OnNodeDrop="TreeDrop" BeforeClientDrag="BeforeDragHandler" BeforeClientDrop="BeforeDropHandler"></radt:RadTreeView>
						</ContentTemplate>
					</radp:PanelItemTemplate>
				</PanelItemTemplates>
				<PanelItems>
					<radp:PanelItem Text="root1" ID="Panel1"  Expanded="True">
						<radp:PanelItem ID="t1" Text="subroot1" TemplateID="Template1"></radp:PanelItem>
					</radp:PanelItem>
					<radp:PanelItem Text="root2" ID="Panel2" Expanded="False">
						<radp:PanelItem ID="t2" Text="subroot2" TemplateID="Template2"></radp:PanelItem>
					</radp:PanelItem>
				</PanelItems>
			</radp:RadPanelbar>
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>
