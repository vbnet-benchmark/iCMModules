<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Publisher2006.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Publisher2006.Publisher2006" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="radE" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<input type="hidden" name="Edited" runat="server" id="Edited">
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="1" cellPadding="1" border="0" width="100%">
		<TR>
			<td id="HtmlHolder" runat="server" width="100%">
				<radE:RadEditor ID="editor1" Runat="server" Width="100%" Height="450px" SaveInFile="true" ImagesPaths="~/Editor/Img/UserDir/Mina Bilder"
					UploadImagesPaths="~/Editor/Img/UserDir/Mina Bilder" DeleteImagesPaths="~/Editor/Img/UserDir/Mina Bilder"
					FlashPaths="~/Editor/Img/UserDir/Mina Flash" UploadFlashPaths="~/Editor/Img/UserDir/Mina Flash"
					DeleteFlashPaths="~/Editor/Img/UserDir/Mina Flash" MediaPaths="~/Editor/Img/UserDir/Mina Media"
					UploadMediaPaths="~/Editor/Img/UserDir/Mina Media" DeleteMediaPaths="~/Editor/Img/UserDir/Mina Media"
					DocumentsPaths="~/Editor/Img/UserDir/Mina Dokument" UploadDocumentsPaths="~/Editor/Img/UserDir/Mina Dokument"
					DeleteDocumentsPaths="~/Editor/Img/UserDir/Mina Dokument"
					AllowThumbGeneration="true" ThumbAppendix="thumb" ToolsFile="~/Editor/ToolsFile.xml"
					Skin="mac" ShowHtmlMode="True" MaxImageSize="200000" MaxFlashSize="50000" MaxMediaSize="100000">
					<strong><font face="Courier New" color="#c71585">Lite text</font></strong></radE:RadEditor>
			</td>
		</TR>
	</TABLE>
</div>
