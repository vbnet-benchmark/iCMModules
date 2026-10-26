<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NorskFilmWizardEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.NorskFilmWizard.NorskFilmWizardEdit"%>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="680" border="0" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid">
							<tr>
								<td></td>
								<td></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<TD></TD>
							</tr>
							<TR>
								<TD vAlign="top">
									<asp:label id="Label1" runat="server" CssClass="SubHead">Text:</asp:label></TD>
								<TD vAlign="top">
									<asp:textbox id="Text1" runat="server" Width="286px" Height="144px" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
								<TD vAlign="top"><asp:label id="Label3" runat="server" CssClass="SubHead">Vecka:</asp:label></TD>
								<TD vAlign="top">
									<P>
										<asp:DropDownList id="ddlWeek" runat="server" Width="56px"></asp:DropDownList><asp:image id="Image1" runat="server"></asp:image></P>
									<P><INPUT id="Browse1" style="WIDTH: 284px; HEIGHT: 22px" type="file" size="28" name="FileUpload"
											runat="server"></P>
								</TD>
							</TR>
							<TR>
								<TD colSpan="5">&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="5">
									<asp:Button id="Save" runat="server" CssClass="iCWebControlsII" Text="Spara"></asp:Button></TD>
							</TR>
							<TR>
								<TD colSpan="5">&nbsp;</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
