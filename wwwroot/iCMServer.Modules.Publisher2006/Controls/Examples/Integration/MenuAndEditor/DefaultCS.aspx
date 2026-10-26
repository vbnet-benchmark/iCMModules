<%@ Register TagPrefix="radM" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="radE" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page CodeBehind="DefaultCS.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Telerik.MenuExamplesCSharp.Integration.MenuAndEditor.DefaultCS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="C#"></telerik:Header>
			<script type="text/javascript">
			<!--
			function OnClick(menuItem)
			{
				try
				{
					var editor = <%= editor1.ClientID %>;
					if (menuItem.Category == "File" && menuItem.Text == "Close")
					{
						window.close();
					}
					else if (menuItem.Category == "View" && menuItem.Text != "Full Screen")
					{
						editor.SetMode(parseInt(menuItem.CustomAttributes[1]));
						menuItem.ParentMenu.CloseAll(0);
					}
					else if (menuItem.Category)
					{
						ExecuteCommand(menuItem.CustomAttributes[1], menuItem);
					}
				}catch(e)
				{
				}
			}
			
			function ExecuteCommand(command, menuItem)
			{
				var editor = <%= editor1.ClientID %>;
				editor.ContentWindow.focus();
				editor.SetActive();
				editor.Fire(command, null);
				if (menuItem)
				{
					menuItem.ParentMenu.CloseAll(0);
					menuItem.ResetStateToInitial();
					menuItem.Render(MODE_NORMAL);
				}
			}
			//-->
			</script>
			<table cellspacing="0" cellpadding="0" width="500" border="0" summary="text processor">
				<tr>
					<td style="background-color:#adc9f7;height:30px;"><radm:radmenu id="RadMenu1" OnClientClick="OnClick" EnableKeyboardControl="False" EnableSearchSupport="False"
							EnableImageCaching="False" runat="server" ContentFile="menu.xml" CssFile="menu.css"
							ImagesBaseDir="images/" ShadowColor="#D9E1F9" ShadowWidth="4" ActivationKey="F2" Overlay="True"
							EnableViewState="False"></radm:radmenu>
					</td>
				</tr>
				<tr>
					<td><rade:radeditor id="editor1" Runat="server" Width="600px" Height="400px" HasPermission="True" Editable="True"
							Scheme="Default" ImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" UploadImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							DeleteImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" FlashPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							UploadFlashPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" DeleteFlashPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							MediaPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" UploadMediaPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							DeleteMediaPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" DocumentsPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							UploadDocumentsPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations" DeleteDocumentsPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
							AllowThumbGeneration="true" ThumbAppendix="thumb" DeleteTemplatePaths="~/Editor/Img/UserDir/Templates"
							UploadTemplatePaths="~/Editor/Img/UserDir/Templates" TemplatePaths="~/Editor/Img/UserDir/Templates"></rade:radeditor></td>
				</tr>
			</table>
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>
