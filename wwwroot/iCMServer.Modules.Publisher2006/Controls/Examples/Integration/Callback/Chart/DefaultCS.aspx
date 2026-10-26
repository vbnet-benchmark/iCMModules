<%@ Register TagPrefix="radG" Namespace="Telerik.WebControls" Assembly="RadGrid" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadComboBox" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radc" Namespace="Telerik.WebControls" Assembly="RadChart" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultCS.aspx.cs" Inherits="Telerik.CallbackIntegrationExamplesCSharp.Chart.DefaultCS" Language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#" XhtmlCompliant="False"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
			/*<![CDATA[*/
				function LoadData(dataMode, seriesIndex)
				{
					window["<%= RadCallback1.ClientID %>"].MakeCallback(dataMode, seriesIndex);
				}
				
				function explode(itemIndex)
				{
					window["<%= RadCallback2.ClientID %>"].MakeCallback('', itemIndex);
				}
			/*]]>*/
			</script>
			<div class="module" style="float:right;height:307px;width:300px;margin-right: 24px;">
				<asp:label id="Label2" runat="server" Font-Bold="True">Series Orientation:</asp:label><radclb:callbackradiobuttonlist id="CallbackRadioButtonList1" runat="server" DisableAtCallback="true">
					<asp:ListItem Value="Vertical" Selected="True">Vertical</asp:ListItem>
					<asp:ListItem Value="Horizontal">Horizontal</asp:ListItem>
				</radclb:callbackradiobuttonlist>
				<asp:label id="Label1" runat="server" Font-Bold="True">Select Chart Type:</asp:label><radclb:callbackdropdownlist id="CallbackDropDownList1" runat="server" DisableAtCallback="true">
					<asp:ListItem Value="Bar">Bar</asp:ListItem>
					<asp:ListItem Value="StackedBar">StackedBar</asp:ListItem>
					<asp:ListItem Value="Line">Line</asp:ListItem>
					<asp:ListItem Value="Area">Area</asp:ListItem>
					<asp:ListItem Value="StackedArea">StackedArea</asp:ListItem>
				</radclb:callbackdropdownlist><radclb:radcallback id="RadCallback1" runat="server"></radclb:radcallback>
			</div>
			<radC:RadChart id="RadChart1" Height="333px" Width="340px" Margins-Bottom="107px" Margins-Left="40px"
				Margins-Top="34px" Margins-Right="10px" LicenseFile="~\RadControls\LicenseFile.xml" Runat="server">
				<Background MainColor="White" SecondColor="AliceBlue" ImageUrl="~/controls/examples/integration/callback/chart/images/demoChartBg.jpg"
					BorderColor="" FillStyle="Image"></Background>
				<PlotArea MainColor="76, 211, 211, 211" SecondColor="AntiqueWhite" BorderColor="" FillStyle="Solid"></PlotArea>
				<Legend VAlignment="Middle" ItemFont="Arial, 9px" ItemMark="Rectangle" Position="Bottom">
					<Background MainColor="76, 211, 211, 211" BorderColor="25, 0, 0, 0"></Background>
				</Legend>
				<YAxis DefaultItemFont="Arial, 7pt" AxisColor="#C9C8C7" MaxValue="60" SpaceToLabel="-6"
					MinValue="-100" SpaceToItem="0" MarkColor="#C9C8C7" Step="20"></YAxis>
				<Gridlines>
					<VerticalGridlines Visible="False"></VerticalGridlines>
					<HorizontalGridlines Color="DimGray"></HorizontalGridlines>
				</Gridlines>
				<Title1 Text="Set programmatically!" VAlignment="Top" TextFont="Arial, 10pt, style=Bold"
					VSpacing="11">
					<Background MainColor="76, 211, 211, 211" BorderColor="25, 0, 0, 0"></Background>
				</Title1>
				<XAxis DefaultItemFont="Arial, 8pt" ShowMarks="False" MarkLength="7" MaxValue="5" MinValue="1"
					Step="1"></XAxis>
				<ChartSeriesCollection>
					<radc:ChartSeries Name="Series xx" ShowLabels="False">
						<Items>
							<radc:ChartSeriesItem YValue="-46"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-21"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="24"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-58"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-35"></radc:ChartSeriesItem>
						</Items>
						<Appearance MainColor="Blue"></Appearance>
					</radc:ChartSeries>
					<radc:ChartSeries Name="Series xx" ShowLabels="False">
						<Items>
							<radc:ChartSeriesItem YValue="-14"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-65"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-81"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="-70"></radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="46"></radc:ChartSeriesItem>
						</Items>
						<Appearance MainColor="Green"></Appearance>
					</radc:ChartSeries>
				</ChartSeriesCollection>
			</radC:RadChart>
			<div style="clear:both;height:20px;"></div>
			<div class="module" style="float:right;height:307px;width:300px;margin-right: 24px;">
				<br />
				<b>Click on a pie to expand it without a postback</b>
			</div>
			<radclb:radcallback id="RadCallback2" runat="server"></radclb:radcallback>
			<radc:RadChart id="RadChart2" Runat="server" Height="333px" Width="340px">
				<YAxis Step="20"></YAxis>
				<XAxis MaxValue="5" MinValue="1" Step="1"></XAxis>
				<ChartSeriesCollection>
					<radc:ChartSeries Name="Series 1" DefaultLabel="" Type="Pie">
						<Items>
							<radc:ChartSeriesItem YValue="3" Name="item 1" MainColor="255, 150, 215">
								<Appearance MainColor="255, 150, 215" SecondColor="197, 0, 65"></Appearance>
							</radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="6" Name="item 2" MainColor="199, 243, 178">
								<Appearance MainColor="199, 243, 178" SecondColor="17, 147, 7"></Appearance>
							</radc:ChartSeriesItem>
							<radc:ChartSeriesItem YValue="12" Name="item 3" MainColor="253, 226, 0">
								<Appearance MainColor="253, 226, 0" SecondColor="255, 156, 0"></Appearance>
							</radc:ChartSeriesItem>
						</Items>
						<Appearance MainColor="199, 243, 178" SecondColor="17, 147, 7" BorderColor="DimGray"></Appearance>
						<LabelAppearance TextColor="White"></LabelAppearance>
					</radc:ChartSeries>
				</ChartSeriesCollection>
			</radc:RadChart>
			<div style="clear:both;"></div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
