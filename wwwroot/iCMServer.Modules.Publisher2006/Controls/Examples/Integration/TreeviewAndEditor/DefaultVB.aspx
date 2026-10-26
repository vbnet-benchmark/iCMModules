<%@ Register TagPrefix="radT" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="rade" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndEditor.DefaultVB" Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			Drag &amp; Drop a node from the r.a.d.<b>treeview</b> in the r.a.d.<b>editor</b>'s 
			content area
			<br/>
			<table width="100%" summary="Resource Browser">
				<tr>
					<td valign="top" style="width:400px;" class="module">
						<fieldset style="FLOAT:right;WIDTH:130px;HEIGHT:130px">
							<legend>
					Preview</legend>
							<table style="WIDTH:100%;HEIGHT:100%">
								<tr>
									<td id="previewPane" align="center" valign="middle">Click a node to see its 
										preview...</td>
								</tr>
							</table>
						</fieldset>
						<radt:RadTreeView id="RadTreeView1" runat="server" Height="300px" BeforeClientDrop="MyDropHandler"
							BeforeClientDrag="MyDragHandler" BeforeClientClick="BeforeClick" ImagesBaseDir="WindowsXP" AfterClientMove="MyMoveHandler"
							DragAndDrop="True" Width="200px"></radt:RadTreeView>
					</td>
					<td style="PADDING-LEFT:20px" valign="top"><radE:RadEditor id="RadEditor1" Runat="server" Width="340px" Height="256px" FlashPaths="~/Editor/Img/UserDir"
							Editable="True" ToolsFile="ToolsFile.xml"></radE:RadEditor>
							
					</td>
					<td>
					</td>
				</tr>
			</table>
			<script type="text/javascript">
/*<![CDATA[*/
			var shimId = null;

			function GetRect(element)
			{
				var left = 0;
				var top  = 0;
				
				var width = element.offsetWidth;
				var height = element.offsetHeight;
					
				while (element.offsetParent)
				{
					left += element.offsetLeft;
					top += element.offsetTop;
					
					element = element.offsetParent;
				}
				
				if (element.x)
					left = element.x;
					
				if (element.y)
					top = element.y;
					
				return new Rect(left, top, width, height);
			}

			function Rect(left, top, width, height)
			{
				this.left   = (null != left ? left : 0);
				this.top    = (null != top ? top : 0);
				this.width  = (null != width ? width : 0);
				this.height = (null != height ? height : 0);
				
				this.right  = left + width;
				this.bottom = top + height;
			}			
		
		function IsMouseOverEditor(editor, events)
		{
			var editorFrame = document.getElementById ("RadEContentIframe" + "<%= RadEditor1.ClientID %>");
			if (shimId == null)
			{
				shimId = editor.SetOverlay();
			}
			
			var target = (document.all) ? events.srcElement : events.target;
			var editorRect = GetRect(editorFrame);
			var mouseX = events.clientX;
			var mouseY = events.clientY; 
			
			if (mouseX < editorRect.right && mouseX > editorRect.left &&
				mouseY < editorRect.bottom && mouseY > editorRect.top )
			{
				return true;
			}
			
			return false;
		}
		
		
		function MyDragHandler()
		{
			SaveCursorPosition();
		}
		
		function MyDropHandler(source, dest, events)
		{
			var editor = null;
			try
			{
				editor = <%= RadEditor1.ClientID %>;
			}catch(e)
			{
				return;
			}

			document.body.style.cursor = "default";
			
			if (IsMouseOverEditor(editor, events))
			//if (IsMouseInElement(events, editor.Document))
			{
				pasteTextInEditor(editor, source);
			}
			editor.ClearOverlay();
			shimId = null;
		}

		function pasteTextInEditor(editor, source, x,y) 
		{
			if (source.Value && (source.Value.indexOf(".gif") != -1 || source.Value.indexOf(".jpg") != -1 ))
			PasteAtSavedCursorPosition(editor, "<img src='" + source.Value + "'>");
			
		}

		function MyMoveHandler(events)
		{
			var editor = null;
			try
			{
				editor = <%= RadEditor1.ClientID %>;
			}catch(e)
			{
				return;
			}
			
			//if (IsMouseInElement(events, editor.Document))
			if (IsMouseOverEditor(editor, events))
			{
				if (shimId == null)
				{
					shimId = editor.SetOverlay();
				}
				document.body.style.cursor = "hand";
				

			}
			else
			{
				if (document.all)
				{
					document.body.style.cursor = "no-drop";
				} 
			}
			
		}
		
		function Scale(img, width, height)
		{
			var hRatio = img.height/height;
			var wRatio = img.width/width;

			if (img.width > width  && img.height > height)
			{
				var ratio = (hRatio>=wRatio ? hRatio:wRatio);
				img.width  = (img.width /ratio);
				img.height = (img.height /ratio);
			}
			else
			{
				if (img.width > width)
				{
					img.width  = (img.width /wRatio);
					img.height = (img.height /wRatio);
				}
				else
				{
					if (img.height > height)
					{
						img.width  = (img.width /hRatio);
						img.height = (img.height /hRatio);
					}
				}
			}
		}
		function BeforeClick(source, dest, events)
		{
			var object = document.createElement("IMG");
			object.src = source.Value;
			if (source.Category == "Folder")
			{
				return;
			}
			var previewPane = document.getElementById("previewPane");
			
			if (object.complete)
			{
				Scale(object, 100, 100);
				previewPane.innerHTML = "";
				previewPane.appendChild(object);
			}
			else
			{
				previewPane.innerHTML = "Loading image...";
				object.onload = function()
				{
					Scale(object, 100, 100);
					previewPane.innerHTML = "";
					previewPane.appendChild(object);
                    object.onload = null;
				}
			}	
		}

function SaveCursorPosition()
{

	if (window["<%= RadEditor1.ClientID %>"].Document.selection)
	{
		var oRange = window["<%= RadEditor1.ClientID %>"].Document.selection.createRange();
		if (oRange.pasteHTML)
		oRange.pasteHTML('<span id="cursorlocator" />');
    }
}


function PasteAtSavedCursorPosition(editor, textToPaste)
{
    editor.SetFocus();
    var oRange = window["<%= RadEditor1.ClientID %>"].Document.selection.createRange();
    var oElement = window["<%= RadEditor1.ClientID %>"].Document.getElementById('cursorlocator');
    if (oElement)
    {
		oRange.moveToElementText(oElement);
		oRange.select();
		oElement.removeNode(true);
		oRange.pasteHTML(textToPaste);
		oRange.collapse();
    }
    else
    {
		editor.PasteHtml(textToPaste);
    }
}
		/*]]>*/
			</script>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
