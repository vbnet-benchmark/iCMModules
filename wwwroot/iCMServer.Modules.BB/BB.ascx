<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BB.ascx.vb" Inherits="iConsulting.iCMServer.Modules.BB.BB" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" EditText="" Location="iConsulting.iCMServer.Modules.BB" Phrase="BB_edit"
	EditUrl="~/Desktop/Modules/BB/BBEdit.aspx" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td>
				<table class="weekCalender" width="530">
					<tr>
						<td class="rub1" width="130">Vecka
							<asp:label id="lblWeek" runat="server"></asp:label></td>
						<td class="rub1">För större format, klicka på bilden
						</td>
					</tr>
					<tr>
						<td vAlign="top">
							<table>
								<tr>
									<td><asp:hyperlink id="w1" runat="server">1</asp:hyperlink></td>
									<td><asp:hyperlink id="w2" runat="server">2</asp:hyperlink></td>
									<td><asp:hyperlink id="w3" runat="server">3</asp:hyperlink></td>
									<td><asp:hyperlink id="w4" runat="server">4</asp:hyperlink></td>
									<td><asp:hyperlink id="w5" runat="server">5</asp:hyperlink></td>
									<td><asp:hyperlink id="w6" runat="server">6</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w7" runat="server">7</asp:hyperlink></td>
									<td><asp:hyperlink id="w8" runat="server">8</asp:hyperlink></td>
									<td><asp:hyperlink id="w9" runat="server">9</asp:hyperlink></td>
									<td><asp:hyperlink id="w10" runat="server">10</asp:hyperlink></td>
									<td><asp:hyperlink id="w11" runat="server">11</asp:hyperlink></td>
									<td><asp:hyperlink id="w12" runat="server">12</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w13" runat="server">13</asp:hyperlink></td>
									<td><asp:hyperlink id="w14" runat="server">14</asp:hyperlink></td>
									<td><asp:hyperlink id="w15" runat="server">15</asp:hyperlink></td>
									<td><asp:hyperlink id="w16" runat="server">16</asp:hyperlink></td>
									<td><asp:hyperlink id="w17" runat="server">17</asp:hyperlink></td>
									<td><asp:hyperlink id="w18" runat="server">18</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w19" runat="server">19</asp:hyperlink></td>
									<td><asp:hyperlink id="w20" runat="server">20</asp:hyperlink></td>
									<td><asp:hyperlink id="w21" runat="server">21</asp:hyperlink></td>
									<td><asp:hyperlink id="w22" runat="server">22</asp:hyperlink></td>
									<td><asp:hyperlink id="w23" runat="server">23</asp:hyperlink></td>
									<td><asp:hyperlink id="w24" runat="server">24</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w25" runat="server">25</asp:hyperlink></td>
									<td><asp:hyperlink id="w26" runat="server">26</asp:hyperlink></td>
									<td><asp:hyperlink id="w27" runat="server">27</asp:hyperlink></td>
									<td><asp:hyperlink id="w28" runat="server">28</asp:hyperlink></td>
									<td><asp:hyperlink id="w29" runat="server">29</asp:hyperlink></td>
									<td><asp:hyperlink id="w30" runat="server">30</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w31" runat="server">31</asp:hyperlink></td>
									<td><asp:hyperlink id="w32" runat="server">32</asp:hyperlink></td>
									<td><asp:hyperlink id="w33" runat="server">33</asp:hyperlink></td>
									<td><asp:hyperlink id="w34" runat="server">34</asp:hyperlink></td>
									<td><asp:hyperlink id="w35" runat="server">35</asp:hyperlink></td>
									<td><asp:hyperlink id="w36" runat="server">36</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w37" runat="server">37</asp:hyperlink></td>
									<td><asp:hyperlink id="w38" runat="server">38</asp:hyperlink></td>
									<td><asp:hyperlink id="w39" runat="server">39</asp:hyperlink></td>
									<td><asp:hyperlink id="w40" runat="server">40</asp:hyperlink></td>
									<td><asp:hyperlink id="w41" runat="server">41</asp:hyperlink></td>
									<td><asp:hyperlink id="w42" runat="server">42</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w43" runat="server">43</asp:hyperlink></td>
									<td><asp:hyperlink id="w44" runat="server">44</asp:hyperlink></td>
									<td><asp:hyperlink id="w45" runat="server">45</asp:hyperlink></td>
									<td><asp:hyperlink id="w46" runat="server">46</asp:hyperlink></td>
									<td><asp:hyperlink id="w47" runat="server">47</asp:hyperlink></td>
									<td><asp:hyperlink id="w48" runat="server">48</asp:hyperlink></td>
								</tr>
								<tr>
									<td><asp:hyperlink id="w49" runat="server">49</asp:hyperlink></td>
									<td><asp:hyperlink id="w50" runat="server">50</asp:hyperlink></td>
									<td><asp:hyperlink id="w51" runat="server">51</asp:hyperlink></td>
									<td><asp:hyperlink id="w52" runat="server">52</asp:hyperlink></td>
									<td><asp:hyperlink id="w53" runat="server">53</asp:hyperlink></td>
								</tr>
							</table>
						</td>
						<td vAlign="top">
							<!-- Show Image For Specefic week -->
							<span style="OVERFLOW: auto; WIDTH: 400px; HEIGHT: 232px">
								<asp:datalist id="MyList" runat="server" BackColor="Transparent" OnDeleteCommand="DoItemDelete"
									ForeColor="Transparent" RepeatColumns="5" DataKeyField="bab_id" Visible="True">
									<AlternatingItemStyle ForeColor="Transparent" BackColor="Transparent"></AlternatingItemStyle>
									<ItemStyle ForeColor="Transparent" BackColor="Transparent"></ItemStyle>
									<ItemTemplate>
										<table>
											<tr>
												<td valign="top">
													<a href='icm.aspx?pageId=<%# DataBinder.Eval(Container.DataItem, "pageId") %>&img_id=<%# DataBinder.Eval(Container.DataItem, "img_id") %>&w=<%# DataBinder.Eval(Container.DataItem, "week_id") %>'>
														<img width="60" height="75" border=0 id="Bilden2" alt='<%# DataBinder.Eval(Container.DataItem, "imgAlt") %>' src='<%# DataBinder.Eval(Container.DataItem, "imgSource") %>' border="0">
													</a>
												</td>
											</tr>
										</table>
										<center>
											<asp:Button CommandName="Delete" Text="Ta bort" Runat="server" ID="Delete"></asp:Button>
										</center>
									</ItemTemplate>
								</asp:datalist><asp:panel id="plnDetail" runat="server">
									<TABLE border="0">
										<TR>
											<TD style="CURSOR: default" vAlign="top">
												<asp:Image id="Image2" runat="server"></asp:Image></TD>
											<TD vAlign="top">
												<asp:TextBox id="ImgText" runat="server" Height="197" TextMode="MultiLine" Rows="9" BorderStyle="None"
													ReadOnly="True" BorderWidth="0px" BorderColor="Transparent"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</asp:panel>
								<asp:hyperlink id="lnkBack" runat="server" ForeColor="#E0E0E0" Font-Names="Verdana"><< Tillbaka </asp:hyperlink></span></td>
						</SPAN>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table width="530">
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr class="rub1">
						<td>Beställning</td>
					</tr>
					<tr class="information">
						<td>
							Bilderna beställs genom att använda postgirots inbetalningskort. Ange bildens 
							referensnummer, vilket eller vilka bildpaket ni önskar. Räkna ut det 
							slutgiltliga beloppet. Förskottsbetalning gäller. Insättning sker på 
							Postgirokonto: 139 34 15-3. Leveransen sker inom 14 dagar efter beställning och 
							betalning registrerats på vårt konto.
							<table>
								<tr>
									<td>Paket 1.</td>
									<td>4 stycken 10x15, 2 stycken 15x20 250 kr
									</td>
								</tr>
								<tr>
									<td>Paket 2.</td>
									<td>8 stycken 10x15, 2 stycken 15x20  350 kr</td>
								</tr>
									<tr>
									<td>Tackkort.</td>
									<td>10x15 30 kr/styck (minst 8 stycken av samma motiv).</td>
								</tr>
								<tr>
									<td>Endast bild.</td>
									<td>15x20 cm 150 kr, 20x30 cm  250 kr</td>
								</tr>
							</table>
							 
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</TABLE>
</div>
<asp:datagrid id="DataGrid1" runat="server"></asp:datagrid>
