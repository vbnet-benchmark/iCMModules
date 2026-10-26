<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PickDateCalendar.aspx.vb" Inherits="iConsulting.iCMServer.Modules.TaskList.PickDateCalendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Choose Date</title>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" TitleFormat="Month" NextPrevFormat="ShortMonth" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" BackColor="White" DayNameFormat="FirstTwoLetters" Height="22px" Width="151px" FirstDayOfWeek="Monday">
				<TodayDayStyle backcolor="#CCCC99"></TodayDayStyle>
				<SelectorStyle font-size="8pt" font-names="Verdana" font-bold="True" forecolor="#333333" width="1%" backcolor="#CCCCCC"></SelectorStyle>
				<DayStyle width="14%"></DayStyle>
				<NextPrevStyle font-size="8pt" forecolor="White"></NextPrevStyle>
				<DayHeaderStyle font-size="7pt" font-names="Verdana" font-bold="True" height="10px" forecolor="#333333" backcolor="#CCCCCC"></DayHeaderStyle>
				<SelectedDayStyle forecolor="White" backcolor="#CC3333"></SelectedDayStyle>
				<TitleStyle font-size="13pt" font-bold="True" height="14pt" forecolor="White" backcolor="Black"></TitleStyle>
				<OtherMonthDayStyle forecolor="#999999"></OtherMonthDayStyle>
			</asp:Calendar>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
	</body>
</HTML>
