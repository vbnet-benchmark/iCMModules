<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TasksEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.TaskList.TasksEdit" %>
<HTML>
	<HEAD>
		<icmserverstyle:title id="Title1" ViewType="Standard" ViewSource="Main" runat="server"></icmserverstyle:title>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr vAlign="top">
						<td colSpan="2"></td>
					</tr>
					<tr>
						<td><br>
							<table cellSpacing="0" cellPadding="4" width="98%" border="0">
								<tbody>
									<tr vAlign="top">
										<td width="100"></td>
										<td width="*">
											<table cellSpacing="0" cellPadding="0" width="500">
												<tbody>
													<tr>
														<td class="Head" align="left">Detaljer
														</td>
													</tr>
													<tr>
														<td colSpan="2">
															<hr noShade SIZE="1">
														</td>
													</tr>
												</tbody></table>
											<table cellSpacing="0" cellPadding="0" width="750">
												<tbody>
													<tr vAlign="top">
														<td class="SubHead" width="100">Ämne:
														</td>
														<td rowSpan="8"></td>
														<td><asp:textbox id="TitleField" runat="server" cssclass="NormalTextBox" width="390" Columns="30"
																maxlength="150"></asp:textbox></td>
														<td width="25" rowSpan="8"></td>
														<td class="Normal" width="250"><asp:requiredfieldvalidator id="RequiredTitle" runat="server" Display="Dynamic" ControlToValidate="TitleField"
																ErrorMessage="You must enter a valid title"></asp:requiredfieldvalidator></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Beskrivning:
														</td>
														<td><asp:textbox id="DescriptionField" runat="server" width="390" Columns="44" TextMode="Multiline"
																Rows="6" CssClass="NormalTextBox"></asp:textbox></td>
														<td class="Normal"></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">% Klart:
														</td>
														<td><asp:textbox id="PercentCompleteField" runat="server" cssclass="NormalTextBox" width="50px" Columns="30"
																maxlength="150">0</asp:textbox>&nbsp;%</td>
														<td class="Normal">
															<p><asp:rangevalidator id="PercentValidator" runat="server" ControlToValidate="PercentCompleteField" ErrorMessage="Måste vara ett tal mellan 0 och 100"
																	Type="Integer" MaximumValue="100" MinimumValue="0"></asp:rangevalidator></p>
														</td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Status:
														</td>
														<td><asp:dropdownlist id="StatusField" runat="server" Width="95px">
																<asp:ListItem Value="Ej Startad" Selected="True">Ej Startad</asp:ListItem>
																<asp:ListItem Value="Pågående">Pågående</asp:ListItem>
																<asp:ListItem Value="Avklarad">Avklarad</asp:ListItem>
															</asp:dropdownlist></td>
														<td></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Prioritet:
														</td>
														<td><asp:dropdownlist id="PriorityField" runat="server" Width="95px">
																<asp:ListItem Value="Hög">Hög</asp:ListItem>
																<asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
																<asp:ListItem Value="Låg">Låg</asp:ListItem>
															</asp:dropdownlist></td>
														<td></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Åtgärdstext:
														</td>
														<td><asp:textbox id="AssignedField" runat="server" cssclass="NormalTextBox" Columns="44" TextMode="MultiLine"
																Rows="6" Width="390px"></asp:textbox></td>
														<td></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Starttid:
														</td>
														<td><asp:textbox id="StartField" runat="server" cssclass="NormalTextBox" width="160px" Columns="8"
																ReadOnly="True"></asp:textbox>&nbsp;
															<asp:imagebutton id="btnStart" onclick="Start_Click" runat="server" Width="19px" ImageUrl="~/Desktop/Modules/Tasklist/Images/picker.gif"
																Height="19px" CausesValidation="False"></asp:imagebutton></td>
														<td class="Normal"></td>
													</tr>
													<tr vAlign="top">
														<td class="SubHead">Sluttid:
														</td>
														<td><asp:textbox id="DueField" runat="server" cssclass="NormalTextBox" width="160px" Columns="8"
																ReadOnly="True"></asp:textbox>&nbsp;
															<asp:imagebutton id="btnDue" onclick="Due_Click" runat="server" Width="19px" ImageUrl="~/Desktop/Modules/Tasklist/Images/picker.gif"
																Height="19px" CausesValidation="False"></asp:imagebutton></td>
														<td class="Normal"></td>
													</tr>
												</tbody></table>
											<p><asp:linkbutton class="CommandButton" id="updateButton" runat="server" Text=" Uppdatera " BorderStyle="none"></asp:linkbutton>&nbsp;
												<asp:linkbutton class="CommandButton" id="cancelButton" runat="server" CausesValidation="False"
													Text=" Tillbaka " BorderStyle="none"></asp:linkbutton>&nbsp;
												<asp:linkbutton class="CommandButton" id="deleteButton" runat="server" CausesValidation="False"
													Text=" Radera " BorderStyle="none"></asp:linkbutton>
												<hr style="WIDTH: 500px; HEIGHT: 1px" width="764" noShade SIZE="1">
											<P></P>
											<p></p>
											<p><span class="Normal">Skapad av <asp:label id="CreatedBy" runat="server"></asp:label> den 
<asp:label id="CreatedDate" runat="server"></asp:label></span><br>
												<span class="Normal">Ändrad 
            av <asp:label id="ModifiedBy" runat="server"></asp:label> den 
<asp:label id="ModifiedDate" runat="server"></asp:label></span></p>
											<p><span class="Normal"></span>&nbsp;<span class="Normal">
													<asp:literal id="Literal1" runat="server"></asp:literal>
												</span></p>
										</td>
									</tr>
								</tbody></table>
						</td>
					</tr>
				</tbody></table>
		</form>
	</body>
</HTML>
