<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NorskFilmWizard.ascx.vb" Inherits="iConsulting.iCMServer.Modules.NorskFilmWizard.NorskFilmWizard" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title1" runat="server" EditUrl="~/Desktop/Modules/NorskFilmWizard/NorskFilmWizardEdit.aspx"
	Phrase="publisher_edit" Location="iConsulting.iCMServer.Modules.NorskFilmWizard" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
		<tr>
			<td vAlign="top">
				<table width="600" border="0">
					<tr>
						<td></td>
						<td><asp:panel id="pnlAdministrera" runat="server" Width="400px" BackColor="Silver" Visible="False">
								<asp:DropDownList id="ddlAnsokningar" runat="server" Width="100px" AutoPostBack="True" CssClass="txtbox">
									<asp:ListItem Value="1">Inkommna</asp:ListItem>
									<asp:ListItem Value="2">Behandlade</asp:ListItem>
									<asp:ListItem Value="3">Arkiverade</asp:ListItem>
								</asp:DropDownList>
							</asp:panel></td>
						<td></td>
					</tr>
					<TR>
						<TD vAlign="top">
							<TABLE width="100">
								<tr>
									<td><asp:panel id="pnlText1" runat="server">1. Inngangside</asp:panel>
										<asp:panel id="pnlText1_1" runat="server">text.text.text.text.text.text.text.<BR>text.text.text.text.text.text.</asp:panel><BR>
									</td>
								</tr>
								<tr>
									<td><asp:panel id="pnlText2" runat="server">2. Kontaktsinformation</asp:panel>
										<asp:panel id="pnlText2_2" runat="server" Height="40px">.text.text.text.<BR>text.text.text.text. 
                  text.text.text.text.text.</asp:panel><BR>
									</td>
								</tr>
								<tr>
									<td><asp:panel id="pnlText3" runat="server">3. Fylle inn</asp:panel>
										<asp:panel id="pnlText3_3" runat="server">text.text.text.<BR>text.text.text.text.text.<BR>text.text.text.text. 
                  </asp:panel><BR>
									</td>
								</tr>
								<tr>
									<td><asp:panel id="pnlText4" runat="server">4. Laste Upp</asp:panel>
										<asp:panel id="pnlText4_4" runat="server">text.text.text.<BR>text.text.text.text.text<BR>.text.text.text.text.</asp:panel><BR>
									</td>
								</tr>
								<tr>
									<td><asp:panel id="pnlText5" runat="server">5. Oppsummering</asp:panel>
										<asp:panel id="pnlText5_5" runat="server">text.text.text.<BR>text.text.text.text.text.<BR>text.text.text.text.</asp:panel><BR>
									</td>
								</tr>
								<tr>
									<td></td>
								</tr>
							</TABLE>
						</TD>
						<TD vAlign="top"><asp:label id="lblStepRub" runat="server" CssClass="lblStepRub"></asp:label><asp:panel id="pnlStep1" runat="server">
								<TABLE>
									<TR>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD colSpan="2">
											<asp:panel id="pnlStep1Text" runat="server" CssClass="txtWizardBox">
												<P>Text.Text.Text.Text.Text.Text.<BR>
													Text.Text.Text.Text.Text.Text.<BR>
													Text.Text.Text.Text.Text.Text.<BR>
													Text.Text.Text.Text.Text.<BR>
													Text.Text.Text.Text.Text.</P>
											</asp:panel></TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlStep2" runat="server">
								<TABLE>
									<TR>
										<TD>
											<asp:Label id="lbl1Step3" runat="server" CssClass="txtWizardLabel">Tittel pa produktsjon</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Box1Step3" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label4" runat="server" CssClass="txtWizardLabel">Relevante stabsfunksjoner</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Textbox1" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label5" runat="server" CssClass="txtWizardLabel">Totalbudsjett</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Textbox2" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label6" runat="server" CssClass="txtWizardLabel">Navn på Registrerat och </asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Textbox3" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label7" runat="server" CssClass="txtWizardLabel">Soknadsdatom</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Textbox4" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:DropDownList id="ddlStep4" CssClass="txtWizardBox" Runat="server">
												<asp:ListItem Value="Valj onsket konsulent/">Valj onsket konsulent/</asp:ListItem>
												<asp:ListItem Value="Nykoping">Nykoping</asp:ListItem>
												<asp:ListItem Value="Oslo">Oslo</asp:ListItem>
											</asp:DropDownList></TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlStep3" runat="server">
								<TABLE id="Table1">
									<TR>
										<TD>
											<asp:Label id="Label9" runat="server" CssClass="txtWizardLabel">Tittel pa produktsjon</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="TextBox9" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label8" runat="server" CssClass="txtWizardLabel">Relevante stabsfunksjoner</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="TextBox8" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label3" runat="server" CssClass="txtWizardLabel">Totalbudsjett</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="TextBox7" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label2" runat="server" CssClass="txtWizardLabel">Navn på Registrerat och </asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="TextBox6" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="Label1" runat="server" CssClass="txtWizardLabel">Soknadsdatom</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="TextBox5" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:DropDownList id="DropDownList1" CssClass="txtWizardBox" Runat="server">
												<asp:ListItem Value="Valj onsket konsulent/">Valj onsket konsulent/</asp:ListItem>
												<asp:ListItem Value="Nykoping">Nykoping</asp:ListItem>
												<asp:ListItem Value="Oslo">Oslo</asp:ListItem>
											</asp:DropDownList></TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlStep4" runat="server">
								<TABLE>
									<TR>
										<TD>
											<asp:Label id="lbl1Step4" runat="server" CssClass="txtWizardLabel">Laste opp</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Box1Step4" runat="server" CssClass="txtWizardBox"></asp:TextBox><BR>
											<asp:Button id="btnTest" runat="server" Text="Ladde upp"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlStep5" runat="server">
								<TABLE>
									<TR>
										<TD>
											<asp:Label id="lbl1Step5" runat="server" CssClass="txtWizardLabel">Step 5</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:TextBox id="Box1Step5" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
								</TABLE>
								<asp:Button id="btnGo" runat="server" Text="Finish"></asp:Button>
							</asp:panel><BR>
							<asp:datagrid id="dgAccount" runat="server" Width="400px" CssClass="Grid" HorizontalAlign="Left"
								AutoGenerateColumns="False" DataKeyField="nor_id" OnDeleteCommand="dgAccount_DeleteCommand"
								OnItemDataBound="dgAccount_ItemDataBound" GridLines="Horizontal" HeaderStyle-CssClass="GridHead">
								<SelectedItemStyle VerticalAlign="Top"></SelectedItemStyle>
								<EditItemStyle VerticalAlign="Top"></EditItemStyle>
								<Columns>
									<asp:HyperLinkColumn DataNavigateUrlField="nor_id" DataNavigateUrlFormatString="../../../icm.aspx?PageId=10&a=true&nor_id={0}"
										DataTextField="nor_name" HeaderText="Namn" DataTextFormatString="{0:G}"></asp:HyperLinkColumn>
									<asp:TemplateColumn HeaderText="Kund">
										<HeaderStyle Font-Names="verdana" Width="25%"></HeaderStyle>
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nor_name")%>' ID="Label10">
											</asp:Label>
											&nbsp;
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nor_name")%>' ID="Label11">
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox Width=100px TextMode=SingleLine ID="txtUserName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nor_name") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid><BR>
							<asp:panel id="pnlApplicaton" runat="server" Visible="False">
								<TABLE>
									<TR>
										<TD>
											<asp:Label id="lblApplicaton1" runat="server" CssClass="txtWizardLabel">Namn:</asp:Label></TD>
										<TD>
											<asp:TextBox id="txtApplication1" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblApplicaton2" runat="server" CssClass="txtWizardLabel">Persnr:</asp:Label></TD>
										<TD>
											<asp:TextBox id="txtApplication2" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblApplicaton3" runat="server" CssClass="txtWizardLabel">Bidrag:</asp:Label></TD>
										<TD>
											<asp:TextBox id="txtApplication3" runat="server" CssClass="txtWizardBox"></asp:TextBox></TD>
									</TR>
								</TABLE>
								<asp:HyperLink id="lnkApplicationBack" runat="server" CssClass="txtWizardLabel"><< Back</asp:HyperLink>
							</asp:panel><asp:linkbutton id="lnkStep1" runat="server">Step1</asp:linkbutton>&nbsp;<asp:linkbutton id="lnkStep2" runat="server">Step2</asp:linkbutton>&nbsp;<asp:linkbutton id="lnkStep3" runat="server">Step3</asp:linkbutton>&nbsp;<asp:linkbutton id="lnkStep4" runat="server">Step4</asp:linkbutton>&nbsp;<asp:linkbutton id="lnkStep5" runat="server">Step5</asp:linkbutton></TD>
					</TR>
				</table>
				<table>
					<tr>
						<td width="130"></td>
						<td></td>
					</tr>
				</table>
			</td>
			<td vAlign="top"><asp:hyperlink id="lnkAdministrera" runat="server">Ansökningar</asp:hyperlink><BR>
				<BR>
				<asp:panel id="pnlInfo" runat="server" CssClass="pnlInfo">text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text<BR>text.text.text</asp:panel>
			</td>
		</tr>
	</TABLE>
</div>
