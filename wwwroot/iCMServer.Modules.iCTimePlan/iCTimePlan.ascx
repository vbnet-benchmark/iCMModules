<%@ Control Language="vb" AutoEventWireup="false" Codebehind="iCTimePlan.ascx.vb" Inherits="iConsulting.iCMServer.Modules.iCTimePlan.iCTimePlan" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<LINK href="iCTimePlan.css" type="text/css" rel="stylesheet">
<SITE:TITLE id="Title1" runat="server" EditUrl="~/Desktop/Modules/iCTimePlan/iCTimePlanEdit.aspx"
	Phrase="timeplan_edit" Location="iConsulting.iCMServer.Modules.Calendar" EditText=""></SITE:TITLE><BR>
<div id="Minimizer" runat="server">
	<!-- Meny -->
	<table id="Table5" width="100%" bgColor="#264e81">
		<tr>
			<td align="left"><asp:label id="lblDayOfToday1" runat="server" CssClass="MenuButton"></asp:label></td>
			<td></td>
			<td><asp:hyperlink id="lnkMonthPlan" runat="server">
					<font class="MenuButton">Månadsplan</font></asp:hyperlink></td>
			<td><asp:hyperlink id="lnkTimeReport" runat="server">
					<font class="MenuButton">Planering</font></asp:hyperlink></td>
			<td>&nbsp;
				<asp:hyperlink id="lnkTimeCode" runat="server">
					<font class="MenuButton">Tid koder</font></asp:hyperlink></td>
		</tr>
	</table>
	<BR>
	<table id="Table6" cellSpacing="0" cellPadding="2" width="600" border="0">
		<tr vAlign="top">
			<td></td>
		</tr>
	</table>
	<table id="Table7" cellSpacing="0" cellPadding="2" width="600" border="0">
		<tr vAlign="top">
			<td><asp:panel id="pnlMonthPlan" runat="server" Visible="False"><!-- New TimeReport -->
					<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR height="20">
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 322px; BORDER-BOTTOM: black 1px solid"
								vAlign="top" align="left" width="322" bgColor="#ffffff">&nbsp;
								<asp:ImageButton id="ImageButton1" runat="server" Visible="false" ImageUrl="Images/newappointment.gif"
									ImageAlign="Bottom"></asp:ImageButton><!--
										Inser from TextFile1
								-->  <!--
								<asp:LinkButton id="LinkButton1" runat="server" ForeColor="black" Font-Size="8" Font-Bold="false"
									Font-Name="verdana">New</asp:LinkButton>
									--></TD>
							<TD style="BORDER-TOP: black 1px solid; WIDTH: 2px; BORDER-BOTTOM: black 1px solid"
								vAlign="top" width="2" bgColor="#ffffff">&nbsp;</TD>
							<TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-BOTTOM: black 1px solid"
								vAlign="top" align="right" width="100%" bgColor="#ffffff">&nbsp;
							</TD>
							<TD width="5">&nbsp;</TD>
						</TR>
						<TR>
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-LEFT: black 1px solid; WIDTH: 322px" vAlign="top" align="center" width="322"
								bgColor="#ffffff">
								<asp:calendar id="cal2" runat="server" Height="88px" BackColor="#8CA4C3" DayNameFormat="FirstLetter"
									Font-Names="Verdana" SelectionMode="None" Width="152px" BorderColor="White" BorderWidth="1px"
									Font-Size="9pt" ForeColor="Black">
									<TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
									<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="GhostWhite" VerticalAlign="Bottom" BackColor="#264E81"></NextPrevStyle>
									<DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
									<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
									<TitleStyle Font-Size="XX-Small" Font-Names="verdana" Font-Bold="True" BorderWidth="2px" ForeColor="GhostWhite"
										BorderColor="GhostWhite" BackColor="#264E81"></TitleStyle>
									<OtherMonthDayStyle ForeColor="White"></OtherMonthDayStyle>
								</asp:calendar><BR>
								<TABLE class="tableHeadBG" id="Table9" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="Label19" runat="server" CssClass="RubNote">Bemanning</asp:Label><!-- Flex tid --></TD>
									</TR>
								</TABLE>
								<TABLE class="tableBG" id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 95px; HEIGHT: 26px">
											<asp:Label id="Label4" runat="server" CssClass="LabelNote" Width="128px">Bokad bemanning</asp:Label></TD>
										<TD style="HEIGHT: 26px">
											<asp:Label id="Label5" runat="server" CssClass="LabelNote2" Visible="False"></asp:Label></TD>
										<TD style="HEIGHT: 26px">
											<asp:Label id="Label6" runat="server" CssClass="LabelNote2" Visible="False"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 95px">
											<asp:Label id="Label7" runat="server" CssClass="LabelNote" Width="128px">Grund Bemanning</asp:Label></TD>
										<TD>
											<asp:Label id="Label8" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD>
											<asp:Label id="Label9" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 95px">
											<asp:Label id="Label10" runat="server" CssClass="LabelNote">Avvikelse</asp:Label></TD>
										<TD>
											<asp:Label id="Label11" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD>
											<asp:Label id="Label12" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
								</TABLE>
							</TD>
							<TD>&nbsp;</TD>
							<TD style="BORDER-RIGHT: black 1px solid" vAlign="top" width="100%" bgColor="#ffffff">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD noWrap>
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD>
														<asp:PlaceHolder id="BarHolder2" runat="server"></asp:PlaceHolder></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD noWrap>
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD>
														<asp:PlaceHolder id="TimeHolder2" runat="server" EnableViewState="false"></asp:PlaceHolder></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
								<BR>
								<CENTER><INPUT class="Button" id="Submit1" onclick="javascript:window.print()" type="submit" value="Skriv ut"
										name="Skriv ut"></CENTER>
							</TD>
							<CENTER></CENTER>
							<BR>
							<BR>
							<TD width="5">&nbsp;</TD>
						</TR> <!--
		<tr>
			<td width="5">&nbsp;</td>
			<td width="322" bgcolor="#ffffff" valign="top" style="BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="2" bgcolor="#ffffff" valign="top" style="BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="100%" bgcolor="#ffffff" valign="top" style="BORDER-RIGHT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="5">&nbsp;</td>
		</tr>
		-->
						<TR>
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
								vAlign="top" width="100%" bgColor="#f5f5f5" colSpan="3">
								<asp:PlaceHolder id="CalendarHolder2" runat="server" EnableViewState="false"></asp:PlaceHolder>&nbsp;<FONT face="Verdana"><FONT size="1"><STRONG>
										</STRONG></FONT></FONT>
							</TD>
							<TD width="5">&nbsp;</TD>
						</TR>
					</TABLE> <!--------------------></asp:panel><asp:panel id="pnlTimeReport" runat="server" Visible="False"><!-- New TimeReport -->
					<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR height="20">
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 322px; BORDER-BOTTOM: black 1px solid"
								vAlign="top" align="left" width="322" bgColor="#ffffff">&nbsp;
								<asp:ImageButton id="imgNewAppointment" runat="server" Visible="false" ImageUrl="Images/newappointment.gif"
									ImageAlign="Bottom"></asp:ImageButton><!--
										Inser from TextFile1
								-->  <!--
								<asp:LinkButton id="lnkNew" runat="server" ForeColor="black" Font-Size="8" Font-Bold="false" Font-Name="verdana">New</asp:LinkButton>
								--></TD>
							<TD style="BORDER-TOP: black 1px solid; WIDTH: 2px; BORDER-BOTTOM: black 1px solid"
								vAlign="top" width="2" bgColor="#ffffff">&nbsp;</TD>
							<TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-BOTTOM: black 1px solid"
								vAlign="top" align="right" width="100%" bgColor="#ffffff"><RIGHT>
									<asp:Panel id="PanelAddddl_User" runat="server"></asp:Panel></TD>
							</RIGHT>
							<TD width="5">&nbsp;</TD>
						</TR>
						<TR>
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-LEFT: black 1px solid; WIDTH: 322px" vAlign="top" align="center" width="322"
								bgColor="#ffffff">
								<asp:calendar id="cal" runat="server" Height="88px" BackColor="#8CA4C3" DayNameFormat="FirstLetter"
									Font-Names="Verdana" SelectionMode="None" Width="152px" BorderColor="White" BorderWidth="1px"
									Font-Size="9pt" ForeColor="Black">
									<TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
									<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="GhostWhite" VerticalAlign="Bottom" BackColor="#264E81"></NextPrevStyle>
									<DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
									<SelectedDayStyle Font-Size="XX-Small" ForeColor="White" BackColor="#333399"></SelectedDayStyle>
									<TitleStyle Font-Size="XX-Small" Font-Names="verdana" Font-Bold="True" BorderWidth="2px" ForeColor="GhostWhite"
										BorderColor="GhostWhite" BackColor="#264E81"></TitleStyle>
									<OtherMonthDayStyle ForeColor="White"></OtherMonthDayStyle>
								</asp:calendar><BR>
								<TABLE class="tableHeadBG" id="Table9" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="lblFlexTid" runat="server" CssClass="RubNote">Flextid</asp:Label><!-- Flex tid --></TD>
									</TR>
								</TABLE>
								<TABLE class="tableBG" id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD style="HEIGHT: 26px">
											<asp:Label id="lblFlexInsaldo" runat="server" CssClass="LabelNote">Insaldo</asp:Label></TD>
										<TD style="HEIGHT: 26px">
											<asp:Label id="lblFlexInsaldoRes" runat="server" CssClass="LabelNote2" Visible="False"></asp:Label></TD>
										<TD style="HEIGHT: 26px">
											<asp:Label id="lblFlexInsaldoRes2" runat="server" CssClass="LabelNote2" Visible="False"></asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblFlexNettoTid" runat="server" CssClass="LabelNote">+Nettotid</asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexNettoTidRes" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexNettoTidRes2" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblFlexTjanst" runat="server" CssClass="LabelNote">-Tjänst</asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexTjanstRes" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexTjanstRes2" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 23px">
											<asp:Label id="lblFlexKompTid" runat="server" CssClass="LabelNote">+Komptid</asp:Label></TD>
										<TD style="HEIGHT: 23px">
											<asp:Label id="lblFlexKompTidRes" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD style="HEIGHT: 23px">
											<asp:Label id="lblFlexKompTidRes2" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblFlexUtSaldo" runat="server" CssClass="LabelNote">=Utsaldo</asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexUtsaldoRes" runat="server" CssClass="LabelNote2"></asp:Label></TD>
										<TD>
											<asp:Label id="lblFlexUtsaldoRes2" runat="server" CssClass="LabelNote2"></asp:Label></TD>
									</TR>
								</TABLE>
								<BR>
								<TABLE class="tableHeadBG" id="Table11" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="Label1" runat="server" CssClass="RubNote">MerTid</asp:Label><!-- Flex tid --></TD>
									</TR>
								</TABLE>
								<TABLE class="tableBG" id="Table12" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="lblMerTidInsaldo" runat="server" CssClass="LabelNote">Insaldo</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblMerTidMerTid" runat="server" CssClass="LabelNote">Mertid</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblMerTidKontantUttag" runat="server" CssClass="LabelNote">-Kontantuttag</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblMerTidKomptidsUttag" runat="server" CssClass="LabelNote">-Komptidsuttag</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblMerTidUtsaldo" runat="server" CssClass="LabelNote">=Utsaldo</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</TABLE>
								<BR>
								<TABLE class="tableHeadBG" id="Table13" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="Label2" runat="server" CssClass="RubNote">Semester</asp:Label><!-- Flex tid --></TD>
									</TR>
								</TABLE>
								<TABLE class="tableBG" id="Table14" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="lblSemesterInsaldo" runat="server" CssClass="LabelNote">Insaldo</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblSemesterSemester" runat="server" CssClass="LabelNote">-Semester</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblSemesterKontantUttag" runat="server" CssClass="LabelNote">-Kontantuttag</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblSemesterAvdrag" runat="server" CssClass="LabelNote">-Avdrag</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblSemesterUtsaldo" runat="server" CssClass="LabelNote">=Utsaldo</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</TABLE>
								<BR>
								<TABLE class="tableHeadBG" id="Table15" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="Label3" runat="server" CssClass="RubNote">Övrigt</asp:Label><!-- Flex tid --></TD>
									</TR>
								</TABLE>
								<TABLE class="tableBG" id="Table16" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD>
											<asp:Label id="lblOvrigtManadsFlex" runat="server" CssClass="LabelNote">Månadsflex</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblOB" runat="server" CssClass="LabelNote">OB</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 22px">
											<asp:Label id="lblJour" runat="server" CssClass="LabelNote">Jour</asp:Label></TD>
										<TD style="HEIGHT: 22px"></TD>
										<TD style="HEIGHT: 22px"></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblBil" runat="server" CssClass="LabelNote">Bil</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblSa" runat="server" CssClass="LabelNote">S:a</asp:Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</TD>
							<TD></TD>
							<TD style="BORDER-RIGHT: black 1px solid" vAlign="top" width="100%">
								<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD noWrap>
											<TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD>
														<asp:PlaceHolder id="BarHolder" runat="server"></asp:PlaceHolder></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD noWrap>
											<TABLE id="Table19" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD>
														<asp:PlaceHolder id="TimeHolder" runat="server" EnableViewState="false"></asp:PlaceHolder></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE> <!-- nytt --><BR>
								<CENTER><INPUT class="Button" id="btnPrint" onclick="javascript:window.print()" type="submit" value="Skriv ut"></CENTER>
							</TD>
							<CENTER></CENTER>
							<BR>
							<BR>
							<TD width="5">&nbsp;</TD>
						</TR> <!--
		<tr>
			<td width="5">&nbsp;</td>
			<td width="322" bgcolor="#ffffff" valign="top" style="BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="2" bgcolor="#ffffff" valign="top" style="BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="100%" bgcolor="#ffffff" valign="top" style="BORDER-RIGHT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="5">&nbsp;</td>
		</tr>
		-->
						<TR>
							<TD width="5">&nbsp;</TD>
							<TD style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
								vAlign="top" width="100%" bgColor="#f5f5f5" colSpan="3">
								<asp:PlaceHolder id="CalendarHolder" runat="server" EnableViewState="false"></asp:PlaceHolder>&nbsp;<FONT face="Verdana"><FONT size="1"><STRONG>
										</STRONG></FONT></FONT>
							</TD>
							<TD width="5">&nbsp;</TD>
						</TR>
					</TABLE> <!--------------------></asp:panel><asp:panel id="pnlTimeCode" runat="server">
					<TABLE id="Table20">
						<TR>
							<TD></TD>
							<TD></TD>
							<TD>Start</TD>
							<TD>Rast</TD>
							<TD>Slut</TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="lblAddCode" runat="server">Kod:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtTimeCode" runat="server"></asp:TextBox></TD>
							<TD>
								<asp:DropDownList id="ddStartTime" runat="server">
									<asp:ListItem Value="00:00">00:00</asp:ListItem>
									<asp:ListItem Value="00:30">00:30</asp:ListItem>
									<asp:ListItem Value="01:00">01:00</asp:ListItem>
									<asp:ListItem Value="01:30">01:30</asp:ListItem>
									<asp:ListItem Value="02:00">02:00</asp:ListItem>
									<asp:ListItem Value="02:30">02:30</asp:ListItem>
									<asp:ListItem Value="03:00">03:00</asp:ListItem>
									<asp:ListItem Value="03:30">03:30</asp:ListItem>
									<asp:ListItem Value="04:00">04:00</asp:ListItem>
									<asp:ListItem Value="04:30">04:30</asp:ListItem>
									<asp:ListItem Value="05:00">05:00</asp:ListItem>
									<asp:ListItem Value="05:30">05:30</asp:ListItem>
									<asp:ListItem Value="06:00">06:00</asp:ListItem>
									<asp:ListItem Value="06:30">06:30</asp:ListItem>
									<asp:ListItem Value="07:00">07:00</asp:ListItem>
									<asp:ListItem Value="07:30">07:30</asp:ListItem>
									<asp:ListItem Value="08:00">08:00</asp:ListItem>
									<asp:ListItem Value="08:30">08:30</asp:ListItem>
									<asp:ListItem Value="09:00">09:00</asp:ListItem>
									<asp:ListItem Value="09:30">09:30</asp:ListItem>
									<asp:ListItem Value="10:00">10:00</asp:ListItem>
									<asp:ListItem Value="10:30">10:30</asp:ListItem>
									<asp:ListItem Value="11:00">11:00</asp:ListItem>
									<asp:ListItem Value="11:30">11:30</asp:ListItem>
									<asp:ListItem Value="12:00">12:00</asp:ListItem>
									<asp:ListItem Value="12:30">12:30</asp:ListItem>
									<asp:ListItem Value="13:00">13:00</asp:ListItem>
									<asp:ListItem Value="13:30">13:30</asp:ListItem>
									<asp:ListItem Value="14:00">14:00</asp:ListItem>
									<asp:ListItem Value="14:30">14:30</asp:ListItem>
									<asp:ListItem Value="15:00">15:00</asp:ListItem>
									<asp:ListItem Value="15:30">15:30</asp:ListItem>
									<asp:ListItem Value="16:00">16:00</asp:ListItem>
									<asp:ListItem Value="16:30">16:30</asp:ListItem>
									<asp:ListItem Value="17:00">17:00</asp:ListItem>
									<asp:ListItem Value="17:30">17:30</asp:ListItem>
									<asp:ListItem Value="18:00">18:00</asp:ListItem>
									<asp:ListItem Value="18:30">18:30</asp:ListItem>
									<asp:ListItem Value="19:00">19:00</asp:ListItem>
									<asp:ListItem Value="19:30">19:30</asp:ListItem>
									<asp:ListItem Value="20:00">20:00</asp:ListItem>
									<asp:ListItem Value="20:30">20:30</asp:ListItem>
									<asp:ListItem Value="21:00">21:00</asp:ListItem>
									<asp:ListItem Value="21:30">21:30</asp:ListItem>
									<asp:ListItem Value="22.00">22.00</asp:ListItem>
									<asp:ListItem Value="22:30">22:30</asp:ListItem>
									<asp:ListItem Value="23:00">23:00</asp:ListItem>
									<asp:ListItem Value="23:30">23:30</asp:ListItem>
								</asp:DropDownList></TD>
							<TD>
								<asp:DropDownList id="ddBreakTime" runat="server">
									<asp:ListItem Value="0,5">0,5</asp:ListItem>
									<asp:ListItem Value="1,0">1,0</asp:ListItem>
									<asp:ListItem Value="1,5">1,5</asp:ListItem>
									<asp:ListItem Value="2,0">2,0</asp:ListItem>
								</asp:DropDownList></TD>
							<TD>
								<asp:DropDownList id="ddEndTime" runat="server">
									<asp:ListItem Value="00:00">00:00</asp:ListItem>
									<asp:ListItem Value="00:30">00:30</asp:ListItem>
									<asp:ListItem Value="01:00">01:00</asp:ListItem>
									<asp:ListItem Value="01:30">01:30</asp:ListItem>
									<asp:ListItem Value="02:00">02:00</asp:ListItem>
									<asp:ListItem Value="02:30">02:30</asp:ListItem>
									<asp:ListItem Value="03:00">03:00</asp:ListItem>
									<asp:ListItem Value="03:30">03:30</asp:ListItem>
									<asp:ListItem Value="04:00">04:00</asp:ListItem>
									<asp:ListItem Value="04:30">04:30</asp:ListItem>
									<asp:ListItem Value="05:00">05:00</asp:ListItem>
									<asp:ListItem Value="05:30">05:30</asp:ListItem>
									<asp:ListItem Value="06:00">06:00</asp:ListItem>
									<asp:ListItem Value="06:30">06:30</asp:ListItem>
									<asp:ListItem Value="07:00">07:00</asp:ListItem>
									<asp:ListItem Value="07:30">07:30</asp:ListItem>
									<asp:ListItem Value="08:00">08:00</asp:ListItem>
									<asp:ListItem Value="08:30">08:30</asp:ListItem>
									<asp:ListItem Value="09:00">09:00</asp:ListItem>
									<asp:ListItem Value="09:30">09:30</asp:ListItem>
									<asp:ListItem Value="10:00">10:00</asp:ListItem>
									<asp:ListItem Value="10:30">10:30</asp:ListItem>
									<asp:ListItem Value="11:00">11:00</asp:ListItem>
									<asp:ListItem Value="11:30">11:30</asp:ListItem>
									<asp:ListItem Value="12:00">12:00</asp:ListItem>
									<asp:ListItem Value="12:30">12:30</asp:ListItem>
									<asp:ListItem Value="13:00">13:00</asp:ListItem>
									<asp:ListItem Value="13:30">13:30</asp:ListItem>
									<asp:ListItem Value="14:00">14:00</asp:ListItem>
									<asp:ListItem Value="14:30">14:30</asp:ListItem>
									<asp:ListItem Value="15:00">15:00</asp:ListItem>
									<asp:ListItem Value="15:30">15:30</asp:ListItem>
									<asp:ListItem Value="16:00">16:00</asp:ListItem>
									<asp:ListItem Value="16:30">16:30</asp:ListItem>
									<asp:ListItem Value="17:00">17:00</asp:ListItem>
									<asp:ListItem Value="17:30">17:30</asp:ListItem>
									<asp:ListItem Value="18:00">18:00</asp:ListItem>
									<asp:ListItem Value="18:30">18:30</asp:ListItem>
									<asp:ListItem Value="19:00">19:00</asp:ListItem>
									<asp:ListItem Value="20:00">20:00</asp:ListItem>
									<asp:ListItem Value="20:30">20:30</asp:ListItem>
									<asp:ListItem Value="21:00">21:00</asp:ListItem>
									<asp:ListItem Value="21:30">21:30</asp:ListItem>
									<asp:ListItem Value="22:00">22:00</asp:ListItem>
									<asp:ListItem Value="22:30">22:30</asp:ListItem>
									<asp:ListItem Value="23:00">23:00</asp:ListItem>
									<asp:ListItem Value="23:30">23:30</asp:ListItem>
								</asp:DropDownList></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD>
								<asp:Button id="btnSaveCode" runat="server" CssClass="button" Text="Save"></asp:Button></TD>
						</TR>
					</TABLE>
					<BR>
					<asp:datagrid id="dgProjList" runat="server" Width="600px" BorderColor="#8CA4C3" BorderWidth="1px"
						ForeColor="Black" CellPadding="2" CellSpacing="2" AutoGenerateColumns="False" HorizontalAlign="Left"
						DataKeyField="cod_id" OnUpdateCommand="dgProjList_UpdateCommand" OnDeleteCommand="dgProjList_DeleteCommand"
						OnCancelCommand="dgProjList_CancelCommand" OnEditCommand="dgProjList_EditCommand">
						<ItemStyle ForeColor="DimGray"></ItemStyle>
						<HeaderStyle Font-Size="10px" Font-Names="Verdana" ForeColor="ghostwhite" BackColor="#264E81"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn HeaderText="Kod">
								<HeaderStyle Font-Names="verdana" ForeColor="ghostwhite"></HeaderStyle>
								<ItemStyle ForeColor="Black" VerticalAlign="Top"></ItemStyle>
								<ItemTemplate>
									<asp:TextBox width="120px" TextMode=SingleLine style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ForeColor=#000000 ID="lblNr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_code") %>' ReadOnly=True>
									</asp:TextBox>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox width="120px" TextMode=SingleLine ID="txtCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_code") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Start">
								<HeaderStyle Font-Names="verdana" ForeColor="ghostwhite"></HeaderStyle>
								<ItemStyle Wrap="False" ForeColor="Black" VerticalAlign="Top"></ItemStyle>
								<ItemTemplate>
									<asp:TextBox width="100px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblStart" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_startTimeAm") %>'>
									</asp:TextBox>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox width="100px" TextMode=SingleLine ID="txtStartTimeAm" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_startTimeAm") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Rast">
								<HeaderStyle Font-Names="verdana" ForeColor="ghostwhite"></HeaderStyle>
								<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								<ItemTemplate>
									<asp:TextBox width="100px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblLeader" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_breakTimeAM") %>'>
									</asp:TextBox>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox width="100px" TextMode=SingleLine ID="txtBreakTimeAM" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_breakTimeAM") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Slut">
								<HeaderStyle Font-Names="verdana" ForeColor="ghostwhite"></HeaderStyle>
								<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								<ItemTemplate>
									<asp:TextBox width="100px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblParticipant" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_endTimeAM") %>'>
									</asp:TextBox>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox width="100px" TextMode=SingleLine ID="txtEndTimeAM" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cod_endTimeAM") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
					</asp:datagrid>
				</asp:panel></td>
		</tr>
		<tr vAlign="top">
			<td><asp:image id="picICTime" runat="server" ImageUrl="Images\ictime.gif"></asp:image></td>
		</tr>
		<tr>
			<td></td>
		</tr>
		<tr>
			<td></td>
		</tr>
	</table>
	<asp:datagrid id="DataGrid2" runat="server"></asp:datagrid></div>
