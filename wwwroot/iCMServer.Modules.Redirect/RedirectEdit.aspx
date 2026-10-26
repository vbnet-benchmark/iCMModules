<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RedirectEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Redirect.RedirectEdit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr valign="top">
								<td width="150">
									&nbsp;
								</td>
								<td width="*">
									<table width="500" cellspacing="0" cellpadding="0">
										<tr>
											<td align="left" class="Head">
												<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label>
											</td>
										</tr>
									</table>
									<table width="750" cellspacing="0" cellpadding="0" border="0">
										<tr>
											<td class="SubHead" colspan="3">
												<hr>
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												<asp:Label id="lblUrl" runat="server">lblUrl</asp:Label>
											</td>
											<td height="17">
												<asp:DropDownList id="ddUrl" runat="server" Width="363px" AutoPostBack="True"></asp:DropDownList>
											</td>
											<td class="Normal">
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												<asp:Label id="Label1" runat="server"></asp:Label>
											</td>
											<td height="17">
												<asp:TextBox id="txtUrl" runat="server" Width="360px" ReadOnly="True"></asp:TextBox>
											</td>
											<td class="Normal">
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												&nbsp;
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												<asp:Button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="btnCancel" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnDelete" runat="server" Text="btnDelete" CssClass="iCWebControlsII"></asp:Button>
											</td>
										</tr>
									</table>
									<p>&nbsp;&nbsp;&nbsp;</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
