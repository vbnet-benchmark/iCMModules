<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditLitePages.aspx.vb" Inherits="iConsulting.iCMServer.Modules.LitePages.EditLitePages"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditLitePages</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../../Server/Css/iCMServer.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top" height="100">
					<td colSpan="2">&nbsp;</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="4" width="98%">
				<tr vAlign="top">
					<td width="50">&nbsp;
					</td>
					<td width="*">
						<table cellSpacing="0" cellPadding="4" width="98%">
							<tr vAlign="top">
								<td width="150">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="1" cellPadding="2" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td Class="Head" align="left">Sidan's Titel och Layout
														</td>
													</tr>
													<tr>
														<td>
															<hr noShade SIZE="1">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<%If Not IsAdmin Then%>
										<tr>
											<td class="SubHead" width="120">Sidan's namn:
											</td>
											<td colSpan="3">
												<asp:textbox id="PageName" runat="server" cssclass="NormalTextBox" width="300"></asp:textbox>
											</td>
										</tr>
										<%End If%>
										<tr>
											<td class="SubHead" width="120">Vänster modul fält bredd (px):
											</td>
											<td colSpan="3">
												<asp:DropDownList id="ddlV" runat="server" EnableViewState="true"></asp:DropDownList>
											</td>
										</tr>
										<tr>
											<td class="SubHead" width="120">Höger modul fält bredd (px):
											</td>
											<td colSpan="3">
												<asp:DropDownList id="ddlH" runat="server" EnableViewState="true"></asp:DropDownList>
											</td>
										</tr>
										<tr>
											<td class="SubHead" noWrap valign="top">Berättigade roller:
											</td>
											<td colSpan="3"><asp:checkboxlist id="authRoles" runat="server" width="512px" Font-Size="8pt" Font-Names="Verdana,Arial"
													RepeatColumns="3"></asp:checkboxlist></td>
										</tr>
										<%If Not IsAdmin Then%>
										<tr>
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td class="SubHead">Lägg till modul:
											</td>
											<td class="SubHead">Modul typ
											</td>
											<td colSpan="2"><asp:dropdownlist id="moduleType" runat="server" DataTextField="FriendlyName" DataValueField="ModuleDefID"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td class="SubHead">Modul namn:
											</td>
											<td colSpan="2"><asp:textbox id="moduleTitle" runat="server" cssclass="NormalTextBox" width="250" Text="Nytt Modul Namn"
													EnableViewState="false"></asp:textbox></td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<table width="100%">
													<tr>
														<td align="center">
															<asp:Button id="btnAdd" runat="server" Text="btnAdd" CssClass="iCWebControlsII"></asp:Button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">Organisera Moduler:
											</td>
											<td width="120">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubHead">&nbsp;Vänstra modul fältet
														</td>
													</tr>
													<tr vAlign="top">
														<td>
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=LeftModuleField runat="server" width="110" DataTextField="ModuleTitle" DataValueField="ModuleId" rows="7" DataSource="<%# leftList %>"></asp:listbox></td>
																	<td vAlign="top" noWrap>
																		<asp:imagebutton id="LeftUpBtn" runat="server" AlternateText="Flytta markerad modul upp i listan"
																			CommandArgument="LeftModuleField" CommandName="up" ImageUrl="Images/MovePageUp.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftRightBtn" runat="server" AlternateText="Flytta markerad modul till det centrerade fältet"
																			CommandName="right" ImageUrl="Images/MovePageRight.gif" targetpane="ContentModuleField" sourcepane="LeftModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftDownBtn" runat="server" AlternateText="Flytta markerad modul ner i listan"
																			CommandArgument="LeftModuleField" CommandName="down" ImageUrl="Images/MovePageDown.gif"></asp:imagebutton>&nbsp;&nbsp;
																	</td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="LeftEditBtn" runat="server" AlternateText="Editera" CommandArgument="LeftModuleField"
																			CommandName="edit" ImageUrl="Images/EditPage.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftDeleteBtn" runat="server" AlternateText="Radera" CommandArgument="LeftModuleField"
																			CommandName="delete" ImageUrl="Images/DeletePage.gif"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
											<td width="*">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubHead">&nbsp;Centrerade modul fältet
														</td>
													</tr>
													<tr>
														<td align="center">
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=ContentModuleField runat="server" width="170" DataTextField="ModuleTitle" DataValueField="ModuleId" rows="7" DataSource="<%# contentList %>"></asp:listbox></td>
																	<td vAlign="top" noWrap><asp:imagebutton id="ContentUpBtn" runat="server" AlternateText="Flytta markerad modul upp i listan"
																			CommandArgument="ContentModuleField" CommandName="up" ImageUrl="Images/MovePageUp.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentLeftBtn" runat="server" AlternateText="Flytta markerad modul till vänstra fältet"
																			ImageUrl="Images/MovePageLeft.gif" targetpane="LeftModuleField" sourcepane="ContentModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentRightBtn" runat="server" AlternateText="Flytta markerad modul till högra fältet"
																			ImageUrl="Images/MovePageRight.gif" targetpane="RightModuleField" sourcepane="ContentModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentDownBtn" runat="server" AlternateText="Flytta markerad modul ner i listan"
																			CommandArgument="ContentModuleField" CommandName="down" ImageUrl="Images/MovePageDown.gif"></asp:imagebutton>&nbsp;&nbsp;
																	</td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="ContentEditBtn" runat="server" AlternateText="Editera" CommandArgument="ContentModuleField"
																			CommandName="edit" ImageUrl="Images/EditPage.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentDeleteBtn" runat="server" AlternateText="Radera" CommandArgument="ContentModuleField"
																			CommandName="delete" ImageUrl="Images/DeletePage.gif"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
											<td width="120">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubHead">&nbsp;Högra modul fältet
														</td>
													</tr>
													<TR>
														<td>
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=RightModuleField runat="server" width="110" DataTextField="ModuleTitle" DataValueField="ModuleId" rows="7" DataSource="<%# rightList %>"></asp:listbox></td>
																	<td vAlign="top" noWrap><asp:imagebutton id="RightUpBtn" runat="server" AlternateText="Flytta markerad modul upp i listan"
																			CommandArgument="RightModuleField" CommandName="up" ImageUrl="Images/MovePageUp.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="RightLeftBtn" runat="server" AlternateText="Flytta markerad modul till det centrerade fältet"
																			ImageUrl="Images/MovePageLeft.gif" targetpane="ContentModuleField" sourcepane="RightModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="RightDownBtn" runat="server" AlternateText="Flytta markerad modul ner i listan"
																			CommandArgument="RightModuleField" CommandName="down" ImageUrl="Images/MovePageDown.gif"></asp:imagebutton></td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="RightEditBtn" runat="server" AlternateText="Editera" CommandArgument="RightModuleField"
																			CommandName="edit" ImageUrl="Images/EditPage.gif"></asp:imagebutton><br>
																		<asp:imagebutton id="RightDeleteBtn" runat="server" AlternateText="Radera" CommandArgument="RightModuleField"
																			CommandName="delete" ImageUrl="Images/DeletePage.gif"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</TR>
												</table>
											</td>
										</tr>
										<%End If%>
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td colSpan="4"><asp:Button id="btnSave" runat="server" Text="btnSave" CssClass="iCWebControlsII"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE>
		</form>
	</body>
</HTML>
