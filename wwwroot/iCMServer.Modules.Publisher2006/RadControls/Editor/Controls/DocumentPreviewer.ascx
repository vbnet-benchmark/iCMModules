<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DocumentPreviewer.ascx.cs" Inherits="Telerik.WebControls.EditorControls.DocumentPreviewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="telerik" NameSpace="Telerik.WebControls.EditorControls" Assembly="RadEditor" %>
<table cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td height="23px">&nbsp;</td>
	</tr>
	<tr>
		<td>
			<div class="PreviewAreaHolder">
				<table cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td colspan="2" align="left" valign="top">
							<span id="loader" style="display:none"></span>
						</td>
					</tr>
					<tr>
						<td class="label">
							<script>localization.showText('Tooltip');</script>
						</td>
						<td>
							<input type="text" id="tooltip" style="width:120px" class="RadETextBox">&nbsp;
							<telerik:editorschemeimage relsrc="Dialogs/Accessibility.gif" id="Editorschemeimage2" runat="server"></telerik:editorschemeimage>
						</td>
					</tr>
					<tr>
						<td class="Label">
							<script>localization.showText('Target');</script>
						</label>
						</td>
						<td>
							<input type="text" id="linkTarget" style="width:120px" value="" class="RadETextBox">&nbsp;
							<select class="DropDown" onchange="changeTarget(this)">
								<option value="">
									<script>document.write(localization.Target);</script>
								</option>
								<option value="_blank"><script>localization.showText('_blank')</script></option>
								<option value="_parent"><script>localization.showText('_parent')</script></option>
								<option value="_self"><script>localization.showText('_self')</script></option>
								<option value="_top"><script>localization.showText('_top')</script></option>
								<option value="_search"><script>localization.showText('_search')</script></option>
								<option value="_media"><script>localization.showText('_media')</script></option>							
							</select>
						</td>
					</tr>
				</table>
			</div>
		</td>
	</tr>
</table>