<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LitePages.ascx.vb" Inherits="iConsulting.iCMServer.Modules.LitePages.LitePages" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<Site:title runat="server" id="Title2" />
<TABLE cellSpacing="1" cellPadding="1" border="0" width="100%">
	<TR>
		<TD align="left">&nbsp;</TD>
		<TD align="left">
			<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="0">&nbsp;</TD>
					<TD><font class="SubSubHead">Denna modul hanterar alla sidor i systemet.</font></TD>
					<TD width="10%">&nbsp;</TD>
				</TR>
				<tr>
					<td colspan="3">&nbsp;</td>
				</tr>
			</TABLE>
			<table cellpadding="2" cellspacing="0" border="0">
				<tr valign="top">
					<td width="0">
						&nbsp;
					</td>
					<td width="50" class="SubHead">
						Sidor:
					</td>
					<td>
						<table cellpadding="0" cellspacing="0" border="0">
							<tr valign="top">
								<td>
									<asp:ListBox id="PageList" width=200 DataSource="<%# Pages %>" DataTextField="PageName" DataValueField="PageId" rows=10 runat="server" />
								</td>
								<td>
									&nbsp;
								</td>
								<td>
									<table>
										<tr>
											<td>
												<asp:button id="addBtn" runat="server" CssClass="iCWebControlsII" Text="Ny sida"></asp:button>
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="upBtn" ImageUrl="Images/MovePageUp.gif" CommandName="up" AlternateText="Flytta markerad sida upp i listan"
													runat="server" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="downBtn" ImageUrl="Images/MovePageDown.gif" CommandName="down" AlternateText="Flytta markerad sida ner i listan"
													runat="server" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="editBtn" ImageUrl="Images/EditPage.gif" AlternateText="Editera sidan" runat="server" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="deleteBtn" ImageUrl="Images/DeletePage.gif" AlternateText="Radera markerad sida"
													runat="server" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="right">
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
