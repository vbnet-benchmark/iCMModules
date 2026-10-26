<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TaskView.aspx.vb" Inherits="iConsulting.iCMServer.Modules.TaskList.TaskView" %>
<HTML>
	<HEAD>
		<icmserverstyle:title id="Title1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" marginheight="0" marginwidth="0">
		<form runat="server" ID="Form1">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
				<tbody>
					<tr valign="top">
						<td colspan="2">
						</td>
					</tr>
					<tr>
						<td>
							<br>
							<table cellspacing="0" cellpadding="4" width="98%" border="0">
								<tbody>
									<tr valign="top">
										<td width="50">
										</td>
										<td>
											<table cellspacing="0" cellpadding="4" width="600">
												<tbody>
													<tr>
														<td class="Head" align="left" width="120" colspan="2">
															Detaljer
														</td>
														<td align="right">
															<%= EditLink%>
														</td>
													</tr>
													<tr>
														<td colspan="3">
															<hr noshade size="1">
														</td>
													</tr>
												</tbody>
												<tbody>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Ämne:<br>
														</td>
														<td class="Normal" valign="top" colspan="2">
															<asp:Label id="TitleField" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Beskrivning:<br>
														</td>
														<td valign="top" colspan="2">
															<pre class="Normal" id="longdesc" runat="server"></pre>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Status:
														</td>
														<td class="Normal" valign="top" colspan="2">
															<asp:Label id="StatusField" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Prioritet:<br>
														</td>
														<td class="Normal" valign="top" colspan="2">
															<asp:Label id="PriorityField" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Åtgärdstext:<br>
														</td>
														<td class="Normal" valign="top" colspan="2">
															<pre class="Normal" id="longdesc2" runat="server"></pre>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Starttid:<br>
														</td>
														<td class="Normal" valign="top" colspan="2">
															<asp:Label id="StartField" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td class="SubHead" valign="top" nowrap width="100">
															Sluttid:<br>
														</td>
														<td class="Normal" valign="top" colspan="2">
															<asp:Label id="DueField" runat="server"></asp:Label>
														</td>
													</tr>
												</tbody>
											</table>
											<p>
												<asp:LinkButton id="cancelButton" Text=" Tillbaka " CausesValidation="False" runat="server" class="CommandButton"
													BorderStyle="none" />
											<p>
												<hr style="WIDTH: 600px; HEIGHT: 1px" noshade size="1">
											<p>
												<span class="Normal">
													Skapad den
													<asp:label id="CreatedDate" runat="server"></asp:label>
												</span>
											</p>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
