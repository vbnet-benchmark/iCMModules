<%@ Page language="c#" Codebehind="Dialog.aspx.cs" SmartNavigation="false" AutoEventWireup="false" Inherits="Telerik.WebControls.Dialogs.Dialog" %>
<html>
	<head id="head" runat="server"></head>
	<body>
		<form id="mainForm" runat="server">
			<script language="javascript" src="<%= ScriptsUrl %>RadWindow.js"></script>
			<script>
				var editorID = '<%=this.EditorID%>';
				function GetDialogArguments()
				{
					if (window.radWindow) 
					{
						return window.radWindow.Argument;
					}
					else
					{
						return null;
					}
				}

				var isRadWindow = true;
				var radWindow = GetEditorRadWindowManager().GetCurrentRadWindow(window);
				if (radWindow)
				{ 
					if (window.dialogArguments) 
					{ 
						radWindow.Window = window;
					} 
					radWindow.OnLoad(); 
				}

				if (GetDialogArguments())
				{				
					if (GetDialogArguments().HideEditorStatusBar)
					{
						GetDialogArguments().HideEditorStatusBar(editorID);
					}
				}
															
				/* NEW: In Mozilla, clicking on a button will submit the form by default! We want to avoid it!*/				
			    if (document.addEventListener)
				{
					document.onclick = function(e)
					{    
						var oSrc = e.target;
						if (oSrc && (oSrc.tagName == "BUTTON" || (oSrc.tagName == "INPUT" && oSrc.type.toLowerCase() == "button" )))
						{												
							e.cancelBuble = true;
							e.returnValue = false;
							if (e.perventDefault) e.perventDefault();			
							return false;
						}	
					};
				}
			</script>
			<asp:placeholder id="plchControl" runat="server"></asp:placeholder>
		</form>
	</body>
</html>
