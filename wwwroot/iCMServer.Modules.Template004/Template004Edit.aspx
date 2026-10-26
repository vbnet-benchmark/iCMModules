<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Template004Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template004.Template004Edit"%>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="680" border="0">
							<tr>
								<td colSpan="7">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="7">&nbsp;&nbsp;&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td width="20">&nbsp;</td>
								<td vAlign="top" width="440" colSpan="4">
									<table>
										<tr>
											<td><asp:label id="lblHeader" runat="server" CssClass="SubHead">lblHeader</asp:label></td>
										</tr>
										<tr>
											<td><asp:textbox id="txtHeader" runat="server" TextMode="MultiLine" Width="423px"></asp:textbox></td>
										</tr>
									</table>
								</td>
								<td width="200">
									<table>
										<asp:panel id="PanelNew" runat="server">
											<TBODY>
												<TR>
													<TD>&nbsp;</TD>
													<TD>
														<asp:label id="lblAddMedia" runat="server" CssClass="SubHead">lblAddMedia</asp:label></TD>
												</TR>
												<TR>
													<TD>&nbsp;</TD>
													<TD>
														<asp:DropDownList id="ddMediaFiles" runat="server" Width="192px" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD>&nbsp;</TD>
													<TD>
														<TABLE>
															<TR>
																<TD align="left">&nbsp;</TD>
																<TD align="center">&nbsp;</TD>
																<TD align="right">
																	<asp:Button id="btnAddMedia" runat="server" CssClass="iCWebControlsII" Text="btnAddMedia"></asp:Button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
										</asp:panel><asp:panel id="PanelCategories" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblCategories" runat="server" CssClass="SubHead">lblCategories</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:DropDownList id="ddCategories" runat="server" Width="192px" AutoPostBack="True">
														<asp:ListItem Value="default" Selected="True">default</asp:ListItem>
														<asp:ListItem Value="page">page</asp:ListItem>
														<asp:ListItem Value="word">word</asp:ListItem>
														<asp:ListItem Value="pdf">pdf</asp:ListItem>
														<asp:ListItem Value="pic">pic</asp:ListItem>
														<asp:ListItem Value="movie">movie</asp:ListItem>
														<asp:ListItem Value="link">link</asp:ListItem>
														<asp:ListItem Value="sound">sound</asp:ListItem>
														<asp:ListItem Value="flash">flash</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="BtnBack6" runat="server" CssClass="iCWebControlsII" Text="BtnBack6"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">&nbsp;</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel><asp:panel id="PanelPage" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblPages" runat="server" CssClass="SubHead">lblPages</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px">&nbsp;</TD>
												<TD style="HEIGHT: 22px">
													<asp:DropDownList id="ddPages" runat="server" Width="192px"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="btnBack4" runat="server" CssClass="iCWebControlsII" Text="btnBack4"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">
																<asp:Button id="btnSavePages" runat="server" CssClass="iCWebControlsII" Text="btnSavePages"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel><asp:panel id="PanelDocument" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblDocument" runat="server" CssClass="SubHead">lblDocument</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:DropDownList id="ddDocuments" runat="server" Width="192px"></asp:DropDownList>
													<asp:TextBox id="txtDocIndex" runat="server" Width="32px" Visible="False"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="btnBack3" runat="server" CssClass="iCWebControlsII" Text="btnBack3"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">
																<asp:Button id="btnSaveDocument" runat="server" CssClass="iCWebControlsII" Text="btnSaveDocument"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel><asp:panel id="PanelMedia" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblMedia" runat="server" CssClass="SubHead">lblMedia</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:textbox id="txtMedia" runat="server" Width="192px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="btnBack2" runat="server" CssClass="iCWebControlsII" Text="btnBack2"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">
																<asp:Button id="btnSaveMedia" runat="server" CssClass="iCWebControlsII" Text="btnSaveMedia"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel><asp:panel id="PanelLink" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblLink" runat="server" CssClass="SubHead">lblLink</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:textbox id="txtLink" runat="server" Width="192px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="BtnBack1" runat="server" CssClass="iCWebControlsII" Text="BtnBack1"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">
																<asp:Button id="btnSaveLink" runat="server" CssClass="iCWebControlsII" Text="btnSaveLink"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel><asp:panel id="PanelRemove" runat="server">
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:label id="lblRemove" runat="server" CssClass="SubHead">lblRemove</asp:label></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD>
													<asp:textbox id="txtRemove" runat="server" Width="192px" ReadOnly="True"></asp:textbox>
													<asp:TextBox id="txtRemoveIndex" runat="server" Width="32px" Visible="False"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD align="center">
													<TABLE>
														<TR>
															<TD align="left">
																<asp:Button id="BtnBack5" runat="server" CssClass="iCWebControlsII" Text="BtnBack5"></asp:Button></TD>
															<TD align="center">&nbsp;</TD>
															<TD align="right">
																<asp:Button id="btnRemove" runat="server" CssClass="iCWebControlsII" Text="btnRemove"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</asp:panel>
									</table>
								</td>
							<TR>
								<td width="20">&nbsp;</td>
							</TR>
							<tr>
								<td colSpan="7">&nbsp;
								</td>
							</tr>
							<tr>
								<td width="20">&nbsp;</td>
								<td width="440" colSpan="4">
									<table>
										<tr>
											<td><asp:label id="lblIngress" runat="server" CssClass="SubHead">lblIngress</asp:label></td>
										</tr>
										<tr>
											<td><asp:textbox id="txtIngress" runat="server" TextMode="MultiLine" Width="423px" Height="64px"></asp:textbox></td>
										</tr>
									</table>
								</td>
								<td width="200">
									<table>
										<tr>
											<td>&nbsp;</td>
											<td></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td></td>
										</tr>
									</table>
								</td>
								<td width="20">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="7">&nbsp;&nbsp;&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td width="20">&nbsp;</td>
								<td width="440" colSpan="4">
									<table>
										<tr>
											<td><asp:label id="lblText" runat="server" CssClass="SubHead">lblText</asp:label></td>
										</tr>
										<tr>
											<td><asp:textbox id="txtText" runat="server" TextMode="MultiLine" Width="423px" Height="312px"></asp:textbox></td>
										</tr>
									</table>
								</td>
								<td vAlign="bottom" width="200">
									<table>
										<TR>
											<TD>&nbsp;</TD>
											<td><asp:label id="lblNavText" runat="server" CssClass="SubHead">lblNavText</asp:label></td>
										</TR>
										<TR>
											<td vAlign="top" align="right">&nbsp;</td>
											<td><asp:textbox id="txtNavText" runat="server" TextMode="MultiLine" Width="192px"></asp:textbox></td>
										</TR>
										<tr>
											<td>&nbsp;</td>
											<td></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td><asp:label id="lblUrl" runat="server" CssClass="SubHead">lblUrl</asp:label></td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td><asp:dropdownlist id="ddUrl" runat="server" Width="192px" AutoPostBack="True"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
											<td><asp:textbox id="txtUrl" runat="server" Width="192px"></asp:textbox></td>
										</tr>
									</table>
								</td>
								<td width="20">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="7">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="7">&nbsp;</td>
							</tr>
							<tr>
								<td align="center" colSpan="7"><asp:button id="btnSave" runat="server" CssClass="iCWebControlsII" Text="btnSave"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="7">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				</TBODY></table>
		</form>
	</BODY>
</HTML>
