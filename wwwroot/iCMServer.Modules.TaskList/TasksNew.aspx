<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TasksNew.aspx.vb" Inherits="iConsulting.iCMServer.Modules.TaskList.TasksNew"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TasksNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0" align="center">
				<tr>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
				</tr>
				<tr>
					<td><img src="Images/pixel_trans.gif" width="30" height="1" border="0"></td>
					<td>
						<table cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td colspan="2"><img src="Images/pixel_trans.gif" width="1" height="5" border="0"></td>
							</tr>
							<tr>
								<td colspan="2" style="BORDER-BOTTOM: dimgray 1px solid"><asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Size="X-Large" ForeColor="DimGray">Felanmälan</asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" height="5"><img src="Images/pixel_trans.gif" width="1" height="25" border="0"></td>
							</tr>
							<tr>
								<td><asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Size="Smaller" ForeColor="DimGray">Ämne:&nbsp;</asp:Label></td>
								<td><asp:TextBox id="txtSubject" runat="server" Width="320px" Font-Names="Verdana" Font-Size="Smaller"
										ForeColor="DimGray"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2"><img src="Images/pixel_trans.gif" width="1" height="15" border="0"></td>
							</tr>
							<tr>
								<td colspan="2"><asp:Label id="Label3" runat="server" Font-Names="Verdana" Font-Size="Smaller" ForeColor="DimGray">Beskrivning:</asp:Label></td>
							</tr>
							<tr>
								<td colspan="2" height="35"><asp:TextBox id="txtBody" runat="server" Width="368px" TextMode="MultiLine" Height="224px" Font-Names="Verdana"
										Font-Size="Smaller" ForeColor="DimGray"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2" height="3"><img src="Images/pixel_trans.gif" width="1" height="25" border="0"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"><asp:Button id="btnSend" runat="server" Text="Skicka" Font-Names="Verdana" Font-Size="Smaller"
										ForeColor="DimGray"></asp:Button>&nbsp;&nbsp;
									<asp:Button id="btnCancel" runat="server" ForeColor="DimGray" Font-Size="Smaller" Font-Names="Verdana"
										Text="Tillbaka"></asp:Button></td>
							</tr>
							<tr>
								<td colspan="2"><img src="Images/pixel_trans.gif" width="1" height="5" border="0"></td>
							</tr>
						</table>
					</td>
					<td><img src="Images/pixel_trans.gif" width="30" height="1" border="0"></td>
				</tr>
				<tr>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
					<td><img src="Images/pixel_trans.gif" width="1" height="30" border="0"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
