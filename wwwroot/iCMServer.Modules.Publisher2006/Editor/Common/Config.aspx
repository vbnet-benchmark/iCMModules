
<%@ Page Language="c#" Targetschema="http://schemas.microsoft.com/intellisense/ie5" CodeBehind="DefaultCS.aspx.cs" AutoEventWireup="false" Inherits="Telerik.EditorExamplesCSharp.Editor.Examples.WhatsNew.DefaultCS" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radE" Namespace="Telerik.WebControls" Assembly="RadEditor" %>
<!doctype html public "-//w3c//dtd xhtml 1.1//en" "http://www.w3.org/tr/xhtml11/dtd/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<script runat="server">
			private void Page_Load(object sender, EventArgs e)
			{
				if (!Page.IsPostBack)
				{
					Initialize(true);
				}
			}

			private void Initialize(bool fromPageLoad)
			{
				if (fromPageLoad)
				{
					SelectListItem(HasPermissionList, editor1.HasPermission.ToString());
					SelectListItem(EditableList, editor1.Editable.ToString());
					SelectListItem(UseClassicDialogsList, editor1.UseClassicDialogs.ToString());

					SelectListItem(ChooseToolbarMode, editor1.ToolbarMode.ToString());
					SelectListItem(ShowSubmitCancelButtonsList, editor1.ShowSubmitCancelButtons.ToString());
					SelectListItem(ShowHtmlModeList, editor1.ShowHtmlMode.ToString());
					SelectListItem(ShowPreviewModeList, editor1.ShowPreviewMode.ToString());
					SelectListItem(NewLineBrList, editor1.NewLineBr.ToString());
					HeightBox.Text = editor1.Height.ToString();
					WidthBox.Text = editor1.Width.ToString();

					StandardSkinSelect.SelectedIndex = GetEditorSelectedStandartSkinIndex();
				}
				else 
				{
					editor1.HasPermission = bool.Parse(HasPermissionList.SelectedItem.Value);
					editor1.Editable = bool.Parse(EditableList.SelectedItem.Value);
					editor1.UseClassicDialogs = bool.Parse(UseClassicDialogsList.SelectedItem.Value);
					editor1.ToolbarMode = (Telerik.WebControls.EditorToolbarMode) Enum.Parse(typeof(Telerik.WebControls.EditorToolbarMode), ChooseToolbarMode.SelectedItem.Value);
					editor1.ShowSubmitCancelButtons = bool.Parse(ShowSubmitCancelButtonsList.SelectedItem.Value);
					editor1.ShowHtmlMode = bool.Parse(ShowHtmlModeList.SelectedItem.Value);
					editor1.ShowPreviewMode = bool.Parse(ShowPreviewModeList.SelectedItem.Value);
					editor1.NewLineBr = bool.Parse(NewLineBrList.SelectedItem.Value);
					editor1.Height = Unit.Parse(HeightBox.Text);
					editor1.Width =   Unit.Parse(WidthBox.Text);

					SetEditorSkin(GetSelectedSkin());
				}
			}

			private void SelectListItem(ListControl list, string val)
			{
				System.Web.UI.WebControls.ListItem item = list.Items.FindByValue(val.ToString());
				if (item != null)
				{
					list.SelectedIndex = -1;
					item.Selected = true;
				}
			}

			private void Submit_Click(object sender, EventArgs e)
			{
				this.Initialize(false);	
			}

			private void Restore_Click(object sender, EventArgs e)
			{
				this.Response.Redirect(this.Request.Url.PathAndQuery);
			}

			private void SetEditorSkin(string skin)
			{
				if (skin != string.Empty)
				{
					editor1.Skin = skin;
				}
				else
				{
					editor1.Skin = "Default";
				}
			}

			private string GetSelectedSkin()
			{
				string standardSkin = string.Empty;

				if (StandardSkinSelect.SelectedIndex > 0)
					standardSkin = StandardSkinSelect.Items[StandardSkinSelect.SelectedIndex].Value;
				return standardSkin;
			}

			private int GetEditorSelectedStandartSkinIndex()
			{
				return GetHtmlSelectItemIndexByValue(StandardSkinSelect, editor1.Skin, 0);
			}

			private int GetHtmlSelectItemIndexByValue(HtmlSelect htmlSelect, string value, int defaultIndex)
			{
				for (int i = 0; i < htmlSelect.Items.Count; i++)
				{
					if (value == htmlSelect.Items[i].Value)
						return i;
				}
				return defaultIndex;
			}

			protected override void OnInit(EventArgs e)
			{
				this.Submit.Click += new EventHandler(this.Submit_Click);
				this.Restore.Click += new EventHandler(this.Restore_Click);
				this.Load += new EventHandler(Page_Load);
			}
		</script>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
		
			<rade:radeditor 
				ID="editor1" 
				Runat="server" 
				Editable="True" 
				ImagesPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				UploadImagesPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				DeleteImagesPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				
				FlashPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				UploadFlashPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				DeleteFlashPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				
				MediaPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				UploadMediaPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				DeleteMediaPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"

				DocumentsPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				UploadDocumentsPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"
				DeleteDocumentsPaths="~/Img/UserDir/Marketing,~/Img/UserDir/PublicRelations"

				AllowThumbGeneration="true" 
				ToolsWidth="580px"
				Width="580px"
				AllowThumbnailGeneration="True"
				TumbAppendix="thumb"
				Height="380px" >
				Below are some commonly used properties of the r.a.d.<strong>editor</strong>. Feel free to experiment with the various options and witness the effect on-the-fly.
			</rade:radeditor>
			<table border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td valign="top">
						<span style="font-size:13px;"><b>Displaying the editor in edit mode</b></span>
						<table cellpadding="3" class="module">
							<tr>
								<td style="white-space:nowrap;"><b>HasPermission</b> (default is <b>True</b>)</td>
								<td>
									<asp:radiobuttonlist cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" id="HasPermissionList" runat="server">
										<asp:listitem value="true" selected="True">True</asp:listitem>
										<asp:listitem value="false">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td><b>Editable</b> (default is <b>False</b>)</td>
								<td>
									<asp:radiobuttonlist cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" id="EditableList" runat="server">
										<asp:listitem value="True">True</asp:listitem>
										<asp:listitem value="False" selected="True">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<b>
										<br/>
										Basic Functional Properties</b><br/>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td colspan="2" style="white-space:nowrap;"><b>ToolsFile </b>(default is <b>~/RadControls/Editor/ToolsFile.xml</b>)</td>
							</tr>
							<tr>
								<td><b>UseClassicDialogs</b> (default is <b>False</b>)</td>
								<td>
									<asp:radiobuttonlist id="UseClassicDialogsList" cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" runat="server">
										<asp:listitem value="True">True</asp:listitem>
										<asp:listitem value="False" Selected="True">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td><b>ToolsOnPage</b> (default is <b>True</b>)</td>
								<td>
									<asp:dropdownlist id="ChooseToolbarMode" runat="server" autopostback="False">
										<asp:listitem value="Default">Default</asp:listitem>
										<asp:listitem value="PageTop">PageTop</asp:listitem>
										<asp:listitem value="ShowOnFocus" selected="True">ShowOnFocus</asp:listitem>
										<asp:listitem value="Floating">Floating</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							
						

							
							<tr>
								<td><b>ShowSubmitCancelButtons</b> (default is <b>True</b>)</td>
								<td>
									<asp:radiobuttonlist id="ShowSubmitCancelButtonsList" cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" runat="server">
										<asp:listitem value="True" selected="True">True</asp:listitem>
										<asp:listitem value="False">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td><b>ShowHtmlMode</b> (default is <b>True</b>)</td>
								<td>
									<asp:radiobuttonlist id="ShowHtmlModeList" cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" runat="server">
										<asp:listitem value="True" selected="True">True</asp:listitem>
										<asp:listitem value="False">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td><b>ShowPreviewMode</b> (default is <b>True</b>)</td>
								<td>
									<asp:radiobuttonlist id="ShowPreviewModeList" cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" runat="server">
										<asp:listitem value="True" selected="True">True</asp:listitem>
										<asp:listitem value="False">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td><b>NewLineBr</b> (default is <b>True</b>)</td>
								<td>
									<asp:radiobuttonlist id="NewLineBrList" cssclass="text" cellspacing="0" cellpadding="0" repeatdirection="Horizontal" runat="server">
										<asp:listitem value="True" selected="True">True</asp:listitem>
										<asp:listitem value="False">False</asp:listitem>
									</asp:radiobuttonlist>
								</td>
							</tr>
						</table>
					</td>
					<td style="width:20px;">&nbsp;</td>
					<td valign="top">
						<span style="font-size:13px;"><b>Basic Visual Properties</b></span>
						<table cellpadding="3" class="module">
							<tr>
								<td><b>Width</b>
								</td>
								<td style="width:100%;"><asp:textbox id="WidthBox" runat="server" class="textfield"></asp:textbox></td>
							</tr>
							<tr>
								<td><b>Height</b></td>
								<td style="width:100%;"><asp:textbox id="HeightBox" class="textfield" runat="server"></asp:textbox></td>
							</tr>
							<tr style="white-space:nowrap;">
								<td><b>Current skin</b></td>
								<td class="textred"><%=editor1.Skin%></td>
							</tr>
							<tr>
								<td style="white-space:nowrap;"><b>Standard skins</b></td>
								<td>
									<select id="StandardSkinSelect" runat="server">
										<option value="">-- Select skin --</option>
										<option value="Default" selected>Default</option>
										<option value="Monochrome">Monochrome</option>
										<option value="Custom">Custom</option>
										<option value="Office2000">Office2000</option>
										<option value="Mac">Mac</option>
									</select>
								</td>
							</tr>
							<tr>
								<td colspan="2" style="white-space:nowrap;">
									<b>
										<br/><br/>
										Getting/Setting the editor's content:</b><br/>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td colspan="2"><b>Html</b> e.g. <b>editor1.Html</b> returns the editor's content as 
									HTML</td>
							</tr>
							<tr>
								<td colspan="2"><b>Text</b> e.g. <b>editor1.Text</b> returns the editor's content as 
									text</td>
							</tr>
							<tr>
								<td colspan="2"><b>Xhtml</b> e.g. <b>editor1.Xhtml</b> returns the editor's content 
									as XHTML</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="center" style="padding-top:16px;">
						<asp:button runat="server" id="Submit" text="Apply Changes" class=button style="border:#33cc00 2px solid; width:110px;"></asp:button>
						&nbsp;&nbsp;
						<asp:button runat="server" id="Restore" text="Restore Defaults" class=button style="width:110px;"></asp:button>
					</td>
				</tr>
			</table>

			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>