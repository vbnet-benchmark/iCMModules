<%@ Register TagPrefix="telerik" NameSpace="Telerik.WebControls.EditorControls" Assembly="RadEditor" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FileBrowser.ascx.cs" Inherits="Telerik.WebControls.EditorControls.FileBrowser" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<input type="hidden" id="selectedItemParentPathHolder" runat="server">
<input type="hidden" id="selectedItemTypeHolder" runat="server">
<input type="hidden" id="selectedItemNameHolder" runat="server">
<table cellpadding="0" cellspacing="0">
	<tr>
		<td>
			<table border="0" align="left" height="10" id="FileBrowserImageButtonHolder" cellpadding="0" cellspacing="0" class="ImageButtonHolder">
				<tr>
					<td><a href="#" id="<%=this.ClientID%>refreshButtonLink" onclick="document.forms[0].submit();"> <button class="ImageButton" type="button">
								<telerik:editorschemeimage id="refresh" align="absMiddle" relsrc="Dialogs/refresh.gif" runat="server" border="0"></telerik:editorschemeimage></button>
						</a>
						<script>localization.setAttribute("refreshButtonLink", "title", "Refresh")</script>
					</td>
					<td><a href="#"><button class="ImageButton" id="NewFolderButton" onClick="return <%=this.ClientID%>.CreateNewFolder()"
								type=button>
								<telerik:editorschemeimage id="newFolderIcon" align="absMiddle" relsrc="Dialogs/newFolderIcon.gif" runat="server" border="0"></telerik:editorschemeimage></button>
						</a>
						<script>localization.setAttribute("NewFolderButton", "title", "NewFolder")</script>
					</td>
					<td><a href="#"> <button class="ImageButton" id="DeleteButton" runat="server" type="button">
								<telerik:editorschemeimage id="deleteIcon" relsrc="Dialogs/deleteIcon.gif" border="0" runat="server"></telerik:editorschemeimage></button>
						</a>
						<script>localization.setAttribute("DeleteButton", "title", "Delete")</script>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<div runat="server" id="NewFolderDiv" class="DialogUtilityArea" style="DISPLAY:none" >
			<table cellpadding="0" cellspacing="0" border=0 ><tr>
				<td width="100%">			
				<asp:textbox ID="newFolderNameHolder" CssClass="RadETextBox" EnableViewState="False" Runat="server"></asp:textbox>
				</td>
				<td>
				<button id="NewButton" runat="server" class="ImageButton" type="button">
					<telerik:editorschemeimage id="okIcon" align="absMiddle" relsrc="Dialogs/okIcon.gif" runat="server" border="0"></telerik:editorschemeimage></button>
				</td>
				<td>
				<button class="ImageButton" onClick="return <%=this.ClientID%>.CancelNewFolderCreation()" type=button>
				<telerik:editorschemeimage id="cancelIcon" relsrc="Dialogs/cancelIcon.gif" runat="server"></telerik:editorschemeimage></button>
				</td>
			</tr>
			</table>
			</div>
			<div class="FileNodeTreeHolder">
				<table id="<%= this.ClientID %>FileList" cellpadding="0" cellspacing="0">
					<thead>
<tr>
<td style="width:1%"><button class="FileBrowserSortHeader" onclick="<%= this.ClientID %>.Sort('Extension');" style="width:100%"><img id="<%= this.ClientID %>SortExtensionDirection" src="<%= this.SkinPath %>Dialogs/empty.gif">Ext</button></td>
<td style="width:99%"><button class="FileBrowserSortHeader" onclick="<%= this.ClientID %>.Sort('Name');" style="width:100%"><img id="<%= this.ClientID %>SortNameDirection" src="<%= this.SkinPath %>Dialogs/empty.gif">Name</button></td>
<td style="width:1%"><button class="FileBrowserSortHeader" onclick="<%= this.ClientID %>.Sort('Size');" style="width:100%"><img id="<%= this.ClientID %>SortSizeDirection" src="<%= this.SkinPath %>Dialogs/empty.gif">Size</button></td></tr>
</thead>
<tbody>

</tbody>
				</table>
			</div>
		</td>
	</tr>
</table>
<script type="text/javascript">
var <%= this.ClientID %> = new RadEditorNamespace.FileBrowser(
		'<%= this.ClientID %>',
		document.getElementById('<%= this.ClientID %>FileList'),
		'<%= this.SkinPath %>',
		document.getElementById('<%= selectedItemParentPathHolder.ClientID %>'),
		document.getElementById('<%= selectedItemTypeHolder.ClientID %>'),
		document.getElementById('<%= selectedItemNameHolder.ClientID %>'),
		document.getElementById('<%= NewFolderDiv.ClientID %>'),
		document.getElementById('<%= newFolderNameHolder.ClientID %>'),
		document.getElementById('<%= NewButton.ClientID %>'),
		document.getElementById('<%= DeleteButton.ClientID %>'),
		document.getElementById('<%= this.ClientID %>SortExtensionDirection'),
		document.getElementById('<%= this.ClientID %>SortNameDirection'),
		document.getElementById('<%= this.ClientID %>SortSizeDirection'),
		document.getElementById('<%= this.ClientID %>refreshButtonLink'),
		'<%= this.UniqueID %>',
		document.getElementById('<%= this.GetForm().ClientID %>')
		);
</script>
<asp:literal ID="literalInitializer" Runat="server"/>