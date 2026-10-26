<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Template004.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Template004.Template004" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Template004/Template004Edit.aspx"
	Phrase="template004_edit" Location="iConsulting.iCMServer.Modules.Template004" EditText=""></SITE:TITLE>
<script language="Javascript">
	function ShowToolTip(id,type)
	{
		try
		{
			var pWidth = 0;
			var oWidth = 0;
			try
			{
				if(typeof(window.innerWidth) == 'number' )
				{
					pWidth = window.innerWidth;
				} 
				else if(document.documentElement && ( document.documentElement.clientWidth ||document.documentElement.clientHeight ) )
				{
					pWidth = document.documentElement.clientWidth;
				} 
				else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) )
				{
					pWidth = document.body.clientWidth;
				}

				if(pWidth<=740)
				{
					oWidth=7;
				}
				else
				{
					oWidth=((pWidth-740)/2);
				}
				//alert(oWidth);
				switch (id)
				{
					case 1:
						oWidth+=87
						break;
					case 2:
						oWidth+=129
						break;
					case 3:
						oWidth+=171
						break;
					case 4:
						oWidth+=213
						break;
					case 5:
						oWidth+=255
						break;
					case 6:
						oWidth+=297
						break;
					case 7:
						oWidth+=339
						break;
					case 8:
						oWidth+=381
						break;
					case 9:
						oWidth+=423
						break;
					case 10:
						oWidth+=465
						break;
					default:
						break;
				}
			}
			catch(e)
			{
				//alert(e);
			}
			
			var t = window.document.getElementById("ToolTip");
			t.style.left = oWidth+'px';//(event.clientX-20)+'px';   
			t.style.top = 430+'px';//(event.clientY-50)+'px'; 
			switch (type)
			{
				case "sound":
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/soundbubbla.gif)';
					break;
				case "pdf":
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/pdfbubbla.gif)';
					break;
				case "word":
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/wordbubbla.gif)';
					break;
				case "movie":
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/moviebubbla.gif)';
					break;
				case "flash":
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/pluginbubbla.gif)';
					break;
				default:
					t.style.backgroundImage = 'url(Desktop/Modules/Template004/Images/linkbubbla.gif)';
					break;
			}
			t.style.visibility = 'visible';
		}
		catch(e)
		{
			//alert(e);
		}
	}
	
	function HideToolTip(id)
	{
		try
		{
			var t = window.document.getElementById("ToolTip");
			t.style.visibility = 'hidden';
		}
		catch(e)
		{
			//alert(e);
		}
	}
</script>
<div id="ToolTip" style="BACKGROUND-POSITION: center center; Z-INDEX: 1000; BACKGROUND-ATTACHMENT: fixed; LEFT: 1px; BACKGROUND-IMAGE: url(Desktop/Modules/Template004/Images/bubblabasfilm.gif); VISIBILITY: hidden; WIDTH: 50px; CURSOR: hand; BACKGROUND-REPEAT: no-repeat; POSITION: absolute; TOP: 1px; HEIGHT: 40px"></div>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td align="center">
				<TABLE height="490" cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td width="32">&nbsp;</td>
						<td width="530">
							<TABLE height="490" cellSpacing="0" cellPadding="0" width="530" border="0">
								<tr height="50">
									<td bgColor="#ffffff">
										<asp:Table id="Header" height="50" cellSpacing="0" cellPadding="0" width="530" border="0" runat="server">
											<asp:TableRow ID="HeaderDummyTr" Height="10" runat="server">
												<asp:TableCell ID="HeaderDummyTdNone1" Width="45" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="HeaderDummyTd" Width="440" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="HeaderDummyTdNone2" Width="45" runat="server">&nbsp;</asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="HeaderTr" Height="25" runat="server">
												<asp:TableCell ID="HeaderTdNone1" Width="45" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="HeaderTd" Width="440" runat="server">
													<asp:TextBox id="HeaderText" runat="server" BackColor="#ffffff" BorderColor="#ffffff" BorderStyle="None"
														BorderWidth="0" Width="440" Height="25" Font-Bold="false" Font-Name="verdana" Font-Size="16"
														ForeColor="#cc6666"></asp:TextBox>
												</asp:TableCell>
												<asp:TableCell ID="HeaderTdNone2" Width="45" runat="server">&nbsp;</asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="Tablerow1" Height="10" runat="server">
												<asp:TableCell ID="Tablecell1" Width="45" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="Tablecell2" Width="440" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="Tablecell3" Width="45" runat="server">&nbsp;</asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
								<tr height="330">
									<td bgColor="#ffffff">
										<asp:Table id="Content" height="330" cellSpacing="0" cellPadding="0" width="530" border="0"
											runat="server">
											<asp:TableRow ID="ContentTr" Height="330" runat="server">
												<asp:TableCell ID="ContentTdNone1" Width="45" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="ContentTd" Width="440" runat="server">
													<asp:Label id="ContentText" style="OVERFLOW: auto; HEIGHT: 330px" runat="server" Width="440"
														Height="330" BackColor="#ffffff"></asp:Label>
												</asp:TableCell>
												<asp:TableCell ID="ContentTdNone2" Width="45" runat="server">&nbsp;</asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
								<tr height="50">
									<td bgColor="#ffffff">
										<asp:Table id="Media" height="50" cellSpacing="0" cellPadding="0" width="530" border="0" runat="server">
											<asp:TableRow ID="MediaTr" Height="50" runat="server">
												<asp:TableCell ID="MediaTdNone1" Width="45" runat="server">&nbsp;</asp:TableCell>
												<asp:TableCell ID="MediaTd" Width="440" runat="server">
													<asp:Table>
														<asp:TableRow>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton1" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton2" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton3" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton4" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton5" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton6" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton7" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton8" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton9" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
															<asp:TableCell Width="30">
																<asp:Image id="MediaButton10" runat="server" ImageUrl="Images/ikon.gif"></asp:Image>
															</asp:TableCell>
															<asp:TableCell Width="5">&nbsp;</asp:TableCell>
														</asp:TableRow>
													</asp:Table>
												</asp:TableCell>
												<asp:TableCell ID="MediaTdNone2" Width="45" runat="server">&nbsp;</asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
								<tr height="66">
									<td>
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td colspan="3"><asp:Panel ID="space1" Width="10" Height="36"></asp:Panel></td>
											</tr>
											<tr>
												<!--<td align="left" width="45">&nbsp;</td>-->
												<td align="left"><a href="http://www.bth.se/bibliotek/"><asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="XX-Small" Font-Names="Verdana">© Bibliotek och Learning Lab/Blekinge Tekniska Högskola</asp:Label></a></td>
												<td align="left" width="50">&nbsp;</td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
						<td width="10">&nbsp;</td>
						<td width="140">
							<TABLE height="490" cellSpacing="0" cellPadding="0" width="140" border="0">
								<tr height="122">
									<td valign="top">
										<asp:Image id="Dot" runat="server" Width="140px" Height="122px" ImageUrl="Images/loggaunder.gif"></asp:Image>
									</td>
								</tr>
								<tr height="322">
									<td>
										<asp:Table id="Navigation" height="300" cellSpacing="0" cellPadding="0" width="140" border="0"
											runat="server">
											<asp:TableRow ID="NavTr1" Height="20" BackColor="#D0888B">
												<asp:TableCell ID="NavTd1" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr2" Height="20" BackColor="#CA7A7B">
												<asp:TableCell ID="NavTd2" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr3" Height="20" BackColor="#C26766">
												<asp:TableCell ID="NavTd3" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr4" Height="20" BackColor="#B95152">
												<asp:TableCell ID="NavTd4" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr5" Height="20" BackColor="#B03E3D">
												<asp:TableCell ID="NavTd5" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr6" Height="20" BackColor="#AB2E2C">
												<asp:TableCell ID="NavTd6" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr7" Height="20" BackColor="#A01413">
												<asp:TableCell ID="NavTd7" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr8" Height="20" BackColor="#990100">
												<asp:TableCell ID="NavTd8" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr9" Height="20" BackColor="#A01413">
												<asp:TableCell ID="NavTd9" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr10" Height="20" BackColor="#AB2E2C">
												<asp:TableCell ID="NavTd10" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr11" Height="20" BackColor="#B03E3D">
												<asp:TableCell ID="NavTd11" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr12" Height="20" BackColor="#B95152">
												<asp:TableCell ID="NavTd12" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr13" Height="20" BackColor="#C26766">
												<asp:TableCell ID="NavTd13" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr14" Height="20" BackColor="#CA7A7B">
												<asp:TableCell ID="NavTd14" Height="20"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="NavTr15" Height="20" BackColor="#D0888B">
												<asp:TableCell ID="NavTd15" Height="20"></asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
								<tr height="56">
									<td>
										<asp:Table id="NextPage" height="56" cellSpacing="0" cellPadding="0" width="140" border="0"
											runat="server">
											<asp:TableRow>
												<asp:TableCell ID="NextText" Width="90" VerticalAlign="Middle" HorizontalAlign="Left">
													<asp:Label id="lblNextPage" runat="server" Font-Name="verdana" Font-Size="xx-small"></asp:Label>
												</asp:TableCell>
												<asp:TableCell ID="NextPic" Width="50" VerticalAlign="Middle" HorizontalAlign="Right">
													<asp:Image id="imgNextPage" runat="server" ImageUrl="Images/navigeringspil.gif"></asp:Image>
												</asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
							</TABLE>
						</td>
						<td width="10">&nbsp;</td>
					</tr>
				</TABLE>
			</td>
		</tr>
	</TABLE>
</div>
