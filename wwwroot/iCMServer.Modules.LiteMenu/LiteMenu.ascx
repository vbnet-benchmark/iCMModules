<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LiteMenu.ascx.vb" Inherits="iConsulting.iCMServer.Modules.LiteMenu.LiteMenu" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table class="HeadBg" cellSpacing="0" width="100%" border="0">
	<tr>
		<td colSpan="2">
			<asp:label id="Label1" runat="server"></asp:label>
		</td>
	</tr>
	<tr>
		<td width="15%">
			&nbsp;
		</td>
		<td>
			<div id="dInfo" style="BACKGROUND-IMAGE: url(Server/Modules/LiteMenu/Images/menyBar1.gif); WIDTH: 100%; BACKGROUND-REPEAT: repeat-x; BACKGROUND-COLOR: transparent">
				<asp:datalist id="Pages" runat="server" cssclass="OtherTabsBg" repeatdirection="horizontal" SelectedItemStyle-CssClass="TabBg"
					EnableViewState="false" ItemStyle-Height="10" Height="10" Visible="True">
					<SelectedItemStyle CssClass="TabBg" Wrap="false"></SelectedItemStyle>
					<SelectedItemTemplate>
						&nbsp;<span class="SelectedTab" style="DIRECTION: ltr"><%# Ctype(Container.DataItem, iConsulting.iCMServer.clsPageStripDetails).PageName %></span>&nbsp;
					</SelectedItemTemplate>
					<SeparatorStyle BackColor="#E0E0E0"></SeparatorStyle>
					<ItemStyle Height="24px" Wrap="false"></ItemStyle>
					<ItemTemplate>
						&nbsp;&nbsp;<a href='/icm.aspx?PageId=<%# Ctype(Container.DataItem, iConsulting.iCMServer.clsPageStripDetails).PageId %>' class="OtherTabs"><%# Ctype(Container.DataItem, iConsulting.iCMServer.clsPageStripDetails).PageName %></a>&nbsp;&nbsp;
					</ItemTemplate>
				</asp:datalist>
			</div>
		</td>
	</tr>
</table>
