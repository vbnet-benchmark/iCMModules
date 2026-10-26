<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LiteSites.ascx.vb" Inherits="iConsulting.iCMServer.Modules.LiteSites.LiteSites" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<Site:title runat="server" id="Title2" />
<TABLE cellSpacing="1" cellPadding="1" border="0" width="100%">
	<tr>
		<TD width="4%">&nbsp;</TD>
		<TD width="100%">
			
				<asp:Image id="imgHelp" ImageUrl="Images/help4.gif" AlternateText="Visa hjälpfil" runat="server"></asp:Image>
				<font class="SubSubHead">Hjälp om hur CN Publisher fungerar</font>
		</TD>
		<TD width="10%">&nbsp;</TD>
	</tr>
	<tr><td clspan="3">&nbsp;</td></tr>
	<TR>
		<TD width="4%">&nbsp;</TD>
		<TD width="100%"><font class="SubSubHead">Denna modul hanterar systemspecifika 
				detaljer.</font></TD>
		<TD width="10%">&nbsp;</TD>
	</TR>
	<tr>
		<td>&nbsp;</td>
	</tr>
</TABLE>
<TABLE cellSpacing="1" cellPadding="1" border="0">
	<TR>
		<TD width="3%" align="left">&nbsp;</TD>
		<TD align="left">
		</TD>
		<TD vAlign="top" align="left" width="100%">
			<table cellspacing="0" cellpadding="0">
				<TR>
					<TD class="SubHead" width="64">
						<asp:Label id="Label1" runat="server" CssClass="SubHead">Namn:</asp:Label></TD>
					<TD class="Head">
						<asp:Label id="lblName" runat="server" CssClass="SubSubHead"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="SubHead" vAlign="top" align="left" width="64">Logga:
					</TD>
					<TD class="Head" align="left"><IMG id="Logga" src="" runat="server">
					</TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2">
						<asp:Button id="btnEdit" runat="server" CssClass="iCWebControlsII" Text="Editera"></asp:Button>&nbsp;&nbsp;
					</TD>
				</TR>
			</table>
		</TD>
	</TR>
</TABLE>
