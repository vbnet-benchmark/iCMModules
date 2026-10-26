<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LiteDocuments.ascx.vb" Inherits="iConsulting.iCMServer.Modules.LiteDocuments.LiteDocuments" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<SITE:TITLE id="Title2" runat="server"></SITE:TITLE>
<TABLE cellSpacing="1" cellPadding="1" width="98%" border="0">
	<tr>
		<td>&nbsp;
		</td>
	</tr>
</TABLE>
<TABLE cellSpacing="1" cellPadding="1" width="96%" border="0">
	<TR>
		<TD align="left" height="1%">&nbsp;</TD>
		<TD align="left" width="100%" height="0">
			<table cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td align="left" width="100%">
						<table width="100%">
							<tr>
								<td align="left">
									<table>
										<tr>
											<td>
												<asp:imagebutton id="ibtnBack" runat="server" ImageUrl="Images/back.gif"></asp:imagebutton>
											</td>
										</tr>
									</table>
								</td>
								<td align="left">
									<table>
										<tr>
											<td>
												<asp:dropdownlist id="ddCatalogs" runat="server" AutoPostBack="True"></asp:dropdownlist>
											</td>
										</tr>
									</table>
								</td>
								<td align="right">
									<table>
										<tr>
											<td width="100" valign="middle"></td>
										</tr>
									</table>
								</td>
								<td align="right">
									<table>
										<tr>
											<td align="left" valign="middle">
												<asp:label id="lblCatalog" runat="server" CssClass="SubHead" Visible="false">Namn:</asp:label>&nbsp;
											</td>
											<td align="left" valign="middle">
												<asp:textbox id="txtCatalog" runat="server" Visible="false" Font-Names="Verdana" Font-Size="XX-Small"
													tabIndex="1"></asp:textbox>&nbsp;
											</td>
											<td align="left" valign="middle">
												<asp:Button id="btnUpdate" runat="server" Text="Updatera" CssClass="iCWebControlsII" Visible="false"
													tabIndex="2"></asp:Button>&nbsp;
											</td>
											<td align="left" valign="middle">
												<asp:button id="btnOk" runat="server" Text="Spara" CssClass="iCWebControlsII" Visible="false"
													tabIndex="2"></asp:button>
											</td>
											<td align="left" valign="middle">
												<asp:Button id="btnCancel" runat="server" Text="Ångra" CssClass="iCWebControlsII" Visible="false"
													tabIndex="3"></asp:Button>
											</td>
											<td align="left" valign="middle">
												<asp:button id="btnAdd" runat="server" Text="Ny mapp" CssClass="iCWebControlsII" Visible="true"></asp:button>&nbsp;
											</td>
											<td align="left" valign="middle">
												<asp:button id="btnEdit" runat="server" Text="Editera" CssClass="iCWebControlsII" Visible="true"></asp:button>&nbsp;
											</td>
											<td align="left" valign="middle">
												<asp:button id="btnDel" runat="server" Text="Radera" CssClass="iCWebControlsII" Visible="true"></asp:button>
											</td>
										</tr>
									</table>
								</td>
								<td align="right">
									<table>
										<tr>
											<td align="left" width="200" valign="middle">
											</td>
											<td align="left" valign="middle">
												<asp:button id="btnUpload" runat="server" Text="Ladda upp" CssClass="iCWebControlsII" Visible="true"></asp:button>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
<TABLE cellSpacing="1" cellPadding="1" width="98%" border="0">
	<tr>
		<TD align="left" height="1%">&nbsp;</TD>
		<td width="100%"><asp:datagrid id="dgContent" runat="server" CssClass="Grid" HeaderStyle-CssClass="GridHead" GridLines="Horizontal"
				OnItemDataBound="dgContent_ItemDataBound" Width="98%" AutoGenerateColumns="False" HorizontalAlign="Left"
				DataKeyField="cat_id" PageSize="20">
				<Columns>
					<asp:TemplateColumn>
						<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Wrap="False" HorizontalAlign="Left" Width="1%"
							VerticalAlign="Top"></ItemStyle>
					</asp:TemplateColumn>
					<asp:ButtonColumn Text="Name" DataTextField="name" CommandName="XXX">
						<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Wrap="False" HorizontalAlign="Left" ForeColor="Black"
							Width="100%" VerticalAlign="Middle"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="isfile" HeaderText="isfile"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cat_id" HeaderText="cat_id"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="doc_id" HeaderText="doc_id"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></td>
	</tr>
</TABLE>
