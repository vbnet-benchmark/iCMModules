<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Language.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Language.Language" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<Site:title runat="server" id="Title2" />
<TABLE cellSpacing="1" cellPadding="1" border="0">
	<TR>
		<TD align="left">&nbsp;</TD>
		<TD align="center"><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></TD>
		<TD vAlign="top" align="left" width="100%">
			<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<TD><font class="SubSubHead">This module control the language in the system, to add a new language, click on the 
						button at bottom and fill in the fields.</font></TD>
					<TD width="10%">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD align="left">&nbsp;</TD>
		<TD align="right">
			<asp:PlaceHolder id="Placeholder2" runat="server"></asp:PlaceHolder></TD>
		<TD width="100%" align="left">
			&nbsp;
		</TD>
	</TR>
</TABLE>