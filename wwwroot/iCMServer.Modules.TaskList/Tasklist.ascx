<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Tasklist.ascx.vb" Inherits="iConsulting.iCMServer.Modules.TaskList.Tasklist" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server" EditUrl="" Phrase="" Location="" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td class="NormalBold" align="center">
				<a class="NormalBold" href="Desktop/Modules/Tasklist/TasksNew.aspx?ModId=<%=ModId%>">
					Skapa ny felanmälan</a>
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>
				<asp:datagrid id="myDataGrid" runat="server" Border="0" width="100%" AutoGenerateColumns="False"
					EnableViewState="False" AllowSorting="True" OnSortCommand="SortTasks">
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:HyperLink id="HyperLink1" runat="server" Visible="<%# IsAuthorized %>" NavigateUrl='<%# "~/Desktop/Modules/Tasklist/TasksEdit.aspx?TasId=" & DataBinder.Eval(Container.DataItem,"tas_id")  & "&ModId=" & ModuleId %>' ImageUrl="~/Desktop/Modules/Tasklist/images/edit.gif">
								</asp:HyperLink>
							</ItemTemplate>
							<ItemStyle CssClass="Normal" VerticalAlign="Top"></ItemStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="tas_title" HeaderText="Ämne">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemTemplate>
								<%# DataBinder.Eval(Container, "DataItem.tas_title") %>
							</ItemTemplate>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="10%"></ItemStyle>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="tas_description" SortExpression="tas_description" HeaderText="Beskrivning">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="17%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="tas_status" SortExpression="tas_status" HeaderText="Status">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="8%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="tas_priority" SortExpression="tas_priority" HeaderText="Prioritet">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="8%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="tas_startdate" SortExpression="tas_duedate" HeaderText="Starttid">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="20%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="tas_duedate" SortExpression="tas_duedate" HeaderText="Sluttid">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="20%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="tas_assignedto" SortExpression="tas_assignedto" HeaderText="Åtgärdstext">
							<HeaderStyle CssClass="NormalBold"></HeaderStyle>
							<ItemStyle CssClass="Normal" VerticalAlign="Top" Width="17%"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</td>
		</tr>
	</table>
</div>
