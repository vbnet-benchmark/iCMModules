<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditModuleLitePages.aspx.vb" Inherits="iConsulting.iCMServer.Modules.LitePages.EditModuleLitePages"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditModuleLitePages</title>
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
														<td class="Head" align="left">Modul inställningar
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
										<tr>
											<td class="SubHead" width="100">Modul namn:
											</td>
											<td colSpan="3">&nbsp;<asp:textbox id="moduleTitle" runat="server" cssclass="NormalTextBox" width="300"></asp:textbox>
											</td>
										</tr>
										<tr>
											<td class="SubHead">Cache timeout (sekunder):
											</td>
											<td colSpan="3">&nbsp;<asp:textbox id="cacheTime" runat="server" cssclass="NormalTextBox" width="100"></asp:textbox>
											</td>
										</tr>
										<tr>
											<td class="SubHead">Visa titel:
											</td>
											<td colSpan="3">&nbsp;
												<asp:RadioButton id="rbShow1" CssClass="SubSubHead" runat="server" Text="Ja" GroupName="sh" Checked="True"></asp:RadioButton>
												<asp:RadioButton id="rbShow2" CssClass="SubSubHead" runat="server" Text="Nej" GroupName="sh"></asp:RadioButton>
											</td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td class="SubHead" valign="top">Roller som kan editera innehållet:
											</td>
											<td colSpan="3"><asp:checkboxlist id="authEditRoles" runat="server" width="300" cellspacing="0" cellpadding="0" Font-Size="8pt"
													Font-Names="Verdana,Arial" RepeatColumns="2"></asp:checkboxlist></td>
										</tr>
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
