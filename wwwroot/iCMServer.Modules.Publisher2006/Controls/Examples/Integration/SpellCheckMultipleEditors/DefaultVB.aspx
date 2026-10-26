<%@ Register TagPrefix="radS" Namespace="Telerik.WebControls" Assembly="RadSpell" %>
<%@ Register TagPrefix="radE" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.ControlExamplesVBNET.Integration.SpellCheckMultipleEditors.DefaultVB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%">
			<telerik:Header id="Header1" runat="server" NavigationLanguage="VB"></telerik:Header>
			
			<table class="module" cellpadding="0" cellspacing="0" border="0" style="font-size:12px;">
			<tr>
				<th colspan="2" align="center">
					<img src="Img/header.gif" alt=""/>
					<br/><br/><a href="javascript: startSpell()" class="button" style="display:block;text-decoration:none;width: 190px;">Spellcheck everything</a>
				</th>
			</tr>
			<tr>
				<td>
					Photo:
					<br/><hr/>
					<radE:RadEditor ID="imageEditor" Runat="server"
						Editable="true"
						Width="150px"
						Height="100px"
						ImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						UploadImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						DeleteImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						ShowHtmlMode="false"
						SaveInFile="false"
						ToolsFile="ImageEditor.xml"
						>My picturw</radE:RadEditor>
				</td>
				<td>
					Nickname:
					<br/><hr/>
					<radE:RadEditor ID="formattingEditor" Runat="server"
						Editable="true"
						Width="450px"
						Height="100px"
						ShowHtmlMode="false"
						SaveInFile="false"
						ToolsFile="FormattingEditor.xml"
						>Short sommary</radE:RadEditor>
				</td>
			</tr>
			<tr>
				<td colspan="2">
					Your Resume:
					<br/><hr/>
					<radE:RadEditor ID="editor1" Runat="server"
						Editable="true"
						Width="100%"
						Height="260px"
						ImagesPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						FlashPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						MediaPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						DocumentsPaths="~/Editor/Img/UserDir/Marketing,~/Editor/Img/UserDir/PublicRelations"
						SaveInFile="false"
						ToolsFile="FullEditor.xml"
						>Muy resume here</radE:RadEditor>
				</td>
			</tr>
		</table>
		<br/>
		
		<rads:radspell ID="spell1" Runat="server" ButtonType="None"/>
		<script type="text/javascript">
		//<![CDATA[
		function MultipleTextSource(sources)
		{
			this.sources = sources;
			   
			this.getText = function()
			{
				var texts = [];
				for (var i = 0; i < this.sources.length; i++)
				{
					texts[texts.length] = this.sources[i].getText();
				}
				return texts.join("<controlSeparator><hr></controlSeparator>");
			}
			   
			this.setText = function(text)
			{
				var texts = text.split("<controlSeparator><hr></controlSeparator>");
				for (var i = 0; i < this.sources.length; i++)
				{
					this.sources[i].setText(texts[i]);
				}
			}
		}
		
		function Editor5Source(editor)
		{
			this.editor = editor;
			
			this.getText = function()
			{
				return this.editor.GetHtml();
			}
			   
			this.setText = function(text)
			{
				this.editor.SetHtml(text);
			}
		}

		function startSpell()
		{   
		var sources = 
			[
			new Editor5Source(<%= imageEditor.ClientID %>),
			new Editor5Source(<%= formattingEditor.ClientID %>),
			new Editor5Source(<%= editor1.ClientID %>)
			];
		   
		var spell = RadSpell.getSpellChecker('<%= spell1.ClientID %>');
		spell.setTextSource(new MultipleTextSource(sources));
		spell.startSpellCheck();
		}
		//]]>
		</script>
			
			<telerik:Footer id="Footer1" runat="server"></telerik:Footer>
		</form>
	</body>
</html>