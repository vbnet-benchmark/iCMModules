<%@ Control Language="c#" AutoEventWireup="false" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="radcln" Namespace="Telerik.WebControls" Assembly="RadCalendar" %>
<table style="color: #5a7a7e; position: relative; left: 40px; font-size: 12px;" cellspacing="8">
	<tbody>
		<tr>
			<td colspan="2" style="border-bottom: dotted 6px #d1e2e4;">
				<h4>Flight Search</h4>
			</td>
		</tr>
		<tr>
			<td>From city:<br />
				<radcb:RadComboBox id="comboCityFrom" runat="server" ContentFile="~/Controls/Common/Cities.xml" Skin="Brick"
					ToolTip="Select a city" NoWrap="False" MarkFirstMatch="True" AllowCustomText="False" Height="200"
					Width="80" /></radcb:RadComboBox>
			</td>
			<td>To city:<br />
				<radcb:RadComboBox id="comboCityTo" runat="server" ContentFile="~/Controls/Common/Cities.xml" Skin="Brick"
					ToolTip="Select a city" NoWrap="False" MarkFirstMatch="True" AllowCustomText="False" Height="200"
					Width="80" /></radcb:RadComboBox>
			</td>
		</tr>
		<tr>
			<td>Departure date:
				<br />
				<radcln:RadDatePicker id="calendarCheckIn" Runat="server" MaxDate="3000-12-31" MinDate="1000-01-01" SelectedDate="2006-03-15">
					<DateInput Width="90px"></DateInput>
					<Calendar Skin="Sunny" FocusedDate="1000-01-01"></Calendar>
				</radcln:RadDatePicker>
			</td>
			<td>Return date:
				<br />
				<radcln:RadDatePicker id="calendarCheckOut" Runat="server" MaxDate="3000-12-31" MinDate="1000-01-01" SelectedDate="2006-03-15">
					<DateInput Width="90px"></DateInput>
					<Calendar Skin="Sunny" FocusedDate="1000-01-01"></Calendar>
				</radcln:RadDatePicker>
			</td>
		</tr>
	</tbody>
</table>
