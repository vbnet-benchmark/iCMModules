<%@ Page Language="c#" CodeBehind="DefaultCS.aspx.cs" AutoEventWireup="false" Inherits="Telerik.IntegrationExamplesCSharp.Devenv.DefaultCS" %>
<%@ Register TagPrefix="radDk" Namespace="Telerik.WebControls" Assembly="RadDock" %>
<%@ Register TagPrefix="radtlb" Namespace="Telerik.WebControls" Assembly="RadToolbar" %>
<%@ Register TagPrefix="radts" Namespace="Telerik.WebControls" Assembly="RadTabStrip" %>
<%@ Register TagPrefix="radm" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<html>
	<head>
		<telerik:HeadTag runat="server" id="Headtag1"></telerik:HeadTag>
		<link rel="stylesheet" type="text/css" href="IdeStyles/Ide.css" />
		<script type="text/javascript" src="IdeJs/Ide.js"></script>
		<!-- r.a.d.dock layout (titlebar, border, shadow, pin/unpit and close buttons) uses the definitions in VSNetToolbox/Styles.css -->
		<link rel="stylesheet" type="text/css" href="VSNetToolbox/Styles.css">
	</head>
	<body class="body">
		<form id="Form1" method="post" runat="server">
			<!-- docking manager start -->
			<radDk:RadDockingManager id="RadDockingManager1" runat="server" ShowToolTipWhileDragging="False"></radDk:RadDockingManager>
			<!-- docking manager end -->
			<telerik:Header XhtmlCompliant="false" runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- ////////////////////////////// VS.Net IDE Start ////////////////////////////// -->
			<div style="height: auto;">
				<table border="0" cellpadding="0" cellspacing="0" class="ideTbl" id="ideTbl" width="99%"
					height="540">
					<tr>
						<td id="editorTitleBar" unselectable="on"><div style="float: left;" unselectable="on"><img src="IdeImages/VsNetIcon.gif" height="18" width="18" alt="" style="vertical-align: middle;">Microsoft 
								Development Environment [design] - Default.aspx*</div>
							<div class="winCmdButtons"><img src="IdeImages/windowMinimizeDisabled.gif" width="16" height="14" alt="" /><img src="IdeImages/windowMaximizeDisabled.gif" width="16" height="14" alt="" /><img src="IdeImages/windowClose.gif" width="16" height="14" hspace="2" alt="Close" onclick="winClose()" /></div>
						</td>
					</tr>
					<tr>
						<td class="mnuBar" valign="top">
							<!-- menu bar start -->
							<radm:RadMenu id="menuTop" runat="server" Overlay="true" Theme="WindowsXP">
								<RootGroupPersistable Flow="Horizontal">
									<radm:MenuItem Key="F" text="<u>F</u>ile">
										<ChildGroupPersistable>
											<radm:MenuItem Key="N" text="<u>N</u>ew" />
											<radm:MenuItem text="<u>O</u>pen" />
											<radm:MenuItem Key="C" text="<u>C</u>lose" />
										</ChildGroupPersistable>
									</radm:MenuItem>
									<radm:MenuItem Key="E" text="<u>E</u>dit" />
									<radm:MenuItem Key="V" text="<u>V</u>iew" />
									<radm:MenuItem Key="D" text="<u>D</u>ebug" />
									<radm:MenuItem OnClientClick="buildSolution" Key="B" text="<u>B</u>uild" />
									<radm:MenuItem Key="T" text="<u>T</u>able" />
									<radm:MenuItem Key="O" text="T<u>o</u>ols" />
									<radm:MenuItem Key="W" text="<u>W</u>indow" />
									<radm:MenuItem Key="H" text="<u>H</u>elp" />
								</RootGroupPersistable>
							</radm:RadMenu>
							<!-- menu bar end -->
						</td>
					</tr>
					<tr>
						<td class="ideToolbar" valign="top">
							<!-- toolbar start -->
							<radtlb:RadToolbar id="toolbarTop" runat="server" skin="vsnet">
								<items>
									<radtlb:radtoolbarbutton id="button_new" Tooltip="New Project (F5)" CommandName="new" ButtonText="New" ButtonImage="new.gif" />
									<radtlb:radtoolbarseparator />
									<radtlb:RadToolbarToggleButton id="button_btn1" Tooltip="Toggle Output Window" CommandName="output" ButtonText="Output"
										ButtonImage="output.gif" />
									<radtlb:radtoolbarbutton id="button_build" Tooltip="Build Solution" CommandName="build" ButtonText="Build"
										ButtonImage="build.gif" />
									<radtlb:RadToolbarToggleButton id="button_btn2" Tooltip="Toggle Toolbox" CommandName="toolbox" ButtonText="Toolbox" Toggled="True"
										ButtonImage="toolbox.gif" />
									<radtlb:radtoolbarseparator />
									<radtlb:RadToolbarToggleButton id="button_btn3" Tooltip="Toggle WordWrap" CommandName="wordwrap" ButtonText="WordWrap"
										ButtonImage="wordWrap.gif" />
									<radtlb:radtoolbarseparator />
									<radtlb:radtoolbarbutton id="button_cut" Tooltip="Cut" CommandName="cut" ButtonText="Cut" ButtonImage="cut.gif"
										Enabled="false" />
									<radtlb:radtoolbarbutton id="button_copy" Tooltip="Copy" CommandName="copy" ButtonText="Copy" ButtonImage="copy.gif"
										Enabled="false" />
									<radtlb:radtoolbarbutton id="button_paste" Tooltip="Paste" CommandName="paste" ButtonText="Paste" ButtonImage="paste.gif"
										Enabled="false" />
									<radtlb:radtoolbarseparator />
									<radtlb:radtoolbarbutton id="button_undo" Tooltip="Undo" CommandName="undo" ButtonText="Undo" ButtonImage="undo.gif"
										Enabled="false" />
									<radtlb:radtoolbarbutton id="button_redo" Tooltip="Redo" CommandName="redo" ButtonText="Redo" ButtonImage="redo.gif"
										Enabled="false" />
									<radtlb:radtoolbarseparator />
									<radtlb:radtoolbartemplatebutton runat="server" ID="combo_buildtype">
										<buttontemplate>
											<select class="toolbarCombo">
												<option selected value="Debug">Debug</option>
												<option value="Release">Release</option>
											</select>
										</buttontemplate>
									</radtlb:radtoolbartemplatebutton>
								</items>
							</radtlb:RadToolbar>
							<script type="text/javascript">
				toolbarTop.attachEvent("OnClientClick","ToolbarClickHandler");
				toolbarTop.attachEvent("OnClientMouseOver","ToolbarMouseOverHandler");
				toolbarTop.attachEvent("OnClientMouseOut","ToolbarMouseOutHandler");
							</script>
							<!-- tolbar end -->
						</td>
					</tr>
					<tr>
						<td class="editingAreaNavigation" id="editingAreaNavigation" valign="top" align="left">
							<!-- tabs start -->
							<table width="100%" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td align="left">
										<radts:RadTabStrip id="tabstripEditor" runat="server" EnableTheming="false" Skin="WinXP" SelectedIndex="1" MultiPageId="multipageEditor">
											<Tabs>
												<radts:Tab Text="Default.cs" ID="Tab1"></radts:Tab>
												<radts:Tab Text="Default.aspx" ID="Tab2"></radts:Tab>
												<radts:Tab Text="Data.js" ID="Tab3"></radts:Tab>
												<radts:Tab Text="Styles.css" ID="Tab4"></radts:Tab>
												<radts:Tab Text="Newsfeed.rss" ID="Tab5"></radts:Tab>
											</Tabs>
										</radts:RadTabStrip>
									</td>
									<td align="right">
										<span class="ctrButtons">
											<img src="IdeImages/arrowLeft.gif" height="11" class="cmdButton" /> <img src="IdeImages/arrowRight.gif" width="14" height="11" class="cmdButton" />
											<img src="IdeImages/btnClose.gif" alt="Close" width="14" height="11" class="cmdButton"
												onmouseover="btnOver()" onmouseout="btnOut()" onclick="btnClick();closeDoc()" id="close" />
										</span>
									</td>
								</tr>
							</table>
							<!-- tabs end -->
						</td>
					</tr>
					<tr id="comboBoxesTr">
						<td id="comboBoxes" align="left">
							<!-- client objects and events combo boxes start -->
							<select class="editorCombo" id="objectsAndEvents">
								<option selected="selected" value="Client Objects and Events">Client Objects and 
									Events</option>
							</select>
							<select class="editorCombo">
								<option selected="selected" value="No Events">(no events)</option>
							</select>
							<!-- client objects and events combo boxes end -->
						</td>
					</tr>
					<tr>
						<td class="editingArea" valign="top">
							<!-- ide editing area start -->
							<div class="editor" id="editor">
								<radts:RadMultiPage id="multipageEditor" runat="server" SelectedIndex="1">
									<radts:PageView ID="Page1" runat="server">
										<span class="editorCode" contenteditable="true">
											<font color='blue'>using&nbsp;</font><font color='black'>System.Web.UI.WebControls</font><font color='blue'>;<br />
												using&nbsp;</font><font color='black'>System.Web.UI.HtmlControls</font><font color='blue'>;<br />
												<br />
												namespace&nbsp;</font><font color='black'>Telerik.DockExamplesCSharp.Dock.Examples.PostIt<br />
												{<br />
												}<br />
											</font>
										</span>
									</radts:PageView>
									<radts:PageView ID="Page2" runat="server">
										<span class="editorCode" contenteditable="true">
											<span class="S15">&lt;%@</span><span class="S16">Page </span>
											<span class="S15">%&gt;</span>
											<br />
											<span class="S15">&lt;%@</span><span class="S16">Register TagPrefix="CS" Namespace="CommunityServer.Controls" Assembly="CommunityServer.Controls" </span>
											<span class="S15">%&gt;</span>
											<br />
											<span class="S15">&lt;%@</span><span class="S16">Register TagPrefix="CSD" Namespace="CommunityServer.Discussions.Controls" Assembly="CommunityServer.Discussions" </span>
											<span class="S15">%&gt;</span>
											<br />
											<span class="S21">&lt;!</span>
											<span class="S22">DOCTYPE</span>
											<span class="S21"></span>
											<span class="S23">html</span>
											<span class="S21">&nbsp;PUBLIC</span>
											<span class="S24">"-//W3C//DTD XHTML 1.0 Transitional//EN"</span>
											<span class="S21"></span>
											<span class="S24">"DTD/xhtml1-strict.dtd"</span>
											<span class="S21">&gt;</span>
											<br />
											<span class="S1">&lt;html</span>
											<span class="S8"></span>
											<span class="S3">xmlns</span>
											<span class="S8">=</span>
											<span class="S6">"http://www.w3.org/1999/xhtml"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S1">&lt;head&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S2">&lt;CSD:PageTitle runat="server" ID="Pagetitle1"/&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S2">&lt;CS:Script id = "Script1" runat = "server" /&gt;</span>
											<br />
											<span class="S1">&lt;/head&gt;</span>
											<br />
											<span class="S1">&lt;body&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;form</span>
											<span class="S8"></span>
											<span class="S3">id</span>
											<span class="S8">=</span>
											<span class="S6">"ContentForm"</span>
											<span class="S8"></span>
											<span class="S4">runat</span>
											<span class="S8">=</span>
											<span class="S6">"server"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;table</span>
											<span class="S8"></span>
											<span class="S3">border</span>
											<span class="S8">=</span>
											<span class="S6">"0"</span>
											<span class="S8"></span>
											<span class="S3">cellpadding</span>
											<span class="S8">=</span>
											<span class="S6">"0"</span>
											<span class="S8"></span>
											<span class="S3">cellspacing</span>
											<span class="S8">=</span>
											<span class="S6">"0"</span>
											<span class="S8"></span>
											<span class="S3">align</span>
											<span class="S8">=</span>
											<span class="S6">"center"</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"mainTbl"</span>
											<span class="S8"></span>
											<span class="S3">width</span>
											<span class="S8">=</span>
											<span class="S6">"750"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;td</span>
											<span class="S8"></span>
											<span class="S3">valign</span>
											<span class="S8">=</span>
											<span class="S6">"top"</span>
											<span class="S1">&gt;</span>
											<span class="S2">&lt;CS:DisplayTitle &nbsp;runat="server" Selected = "home" /&gt;</span>
											<span class="S1">&lt;/td&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;td</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"telerikHeader"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;div</span>
											<span class="S8"></span>
											<span class="S3">id</span>
											<span class="S8">=</span>
											<span class="S6">"navTab"</span>
											<span class="S1">&gt;</span>
											<span class="S2">&lt;CS:NavigationMenu Reverse = "True" runat = "Server" SelectedTab = "Blog" ID="Menu" /&gt;</span>
											<span class="S1">&lt;/div&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;div</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"searchBar"</span>
											<span class="S1">&gt;</span>
											<span class="S2">&lt;CS:SearchRedirect ID="SearchRedirect" runat="server" /&gt;</span>
											<span class="S1">&lt;/div&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/td&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;td</span>
											<span class="S8"></span>
											<span class="S3">valign</span>
											<span class="S8">=</span>
											<span class="S6">"top"</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"telerikSubheader"</span>
											<span class="S1">&gt;&lt;img</span>
											<span class="S8"></span>
											<span class="S3">src</span>
											<span class="S8">=</span>
											<span class="S6">"themes/blogs/telerik/Images/homeSheetTop.gif"</span>
											<span class="S8"></span>
											<span class="S3">alt</span>
											<span class="S8">=</span>
											<span class="S6">""</span>
											<span class="S8"></span>
											<span class="S3">title</span>
											<span class="S8">=</span>
											<span class="S6">""</span>
											<span class="S8"> &nbsp;</span>
											<span class="S3">height</span>
											<span class="S8">=</span>
											<span class="S6">"73"</span>
											<span class="S8"></span>
											<span class="S3">width</span>
											<span class="S8">=</span>
											<span class="S6">"780"</span>
											<span class="S1">&gt;&lt;/td&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;td</span>
											<span class="S8"></span>
											<span class="S3">valign</span>
											<span class="S8">=</span>
											<span class="S6">"top"</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"homeLinksTd"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;div</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"txtContainer"</span>
											<span class="S1">&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S2">&lt;CS:Login runat="server" /&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;br</span>
											<span class="S11">/&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/div&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/td&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;td&gt;&lt;img</span>
											<span class="S8"></span>
											<span class="S3">src</span>
											<span class="S8">=</span>
											<span class="S6">"themes/blogs/telerik/Images/homeFooter.gif"</span>
											<span class="S8"></span>
											<span class="S3">height</span>
											<span class="S8">=</span>
											<span class="S6">"40"</span>
											<span class="S8"></span>
											<span class="S3">width</span>
											<span class="S8">=</span>
											<span class="S6">"717"</span>
											<span class="S8"></span>
											<span class="S3">alt</span>
											<span class="S8">=</span>
											<span class="S6">""</span>
											<span class="S8"></span>
											<span class="S3">title</span>
											<span class="S8">=</span>
											<span class="S6">""</span>
											<span class="S8"></span>
											<span class="S3">class</span>
											<span class="S8">=</span>
											<span class="S6">"homeFooter"</span>
											<span class="S1">&gt;&lt;/td&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/tr&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/table&gt;</span>
											<br />
											<span class="S0">&nbsp; &nbsp; &nbsp; &nbsp; </span>
											<span class="S1">&lt;/form&gt;</span>
											<br />
											<span class="S1">&lt;/body&gt;</span>
											<br />
											<span class="S1">&lt;/html&gt;</span>
										</span>
									</radts:PageView>
									<radts:PageView ID="Page3" runat="server">
										<span class="editorCode" contenteditable="true">
						<font color='black'>window.onload&nbsp;</font><font color='blue'>=&nbsp;function</font><font color='black'>()<br />
{<br />
&nbsp;&nbsp;&nbsp;&nbsp;</font><font color='blue'>alert</font><font color='black'>(</font><font color='darkgreen'>'Hello,&nbsp;world!');<br />
</font><font color='black'>}</font>

					</span>
									</radts:PageView>
									<radts:PageView ID="Page4" runat="server">
										<span class="editorCode" contenteditable="true">
						<font color='maroon'>#myDiv<br />
</font><font color='blue'>{</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;position</font><font color='blue'>:&nbsp;absolute;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;left</font><font color='blue'>:&nbsp;248px;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;top</font><font color='blue'>:&nbsp;180px;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;border-top</font><font color='blue'>:&nbsp;none;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;border-left</font><font color='blue'>:&nbsp;solid&nbsp;2px&nbsp;#d4d0c8;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;border-right</font><font color='blue'>:&nbsp;solid&nbsp;1px&nbsp;#404040;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;border-bottom</font><font color='blue'>:&nbsp;solid&nbsp;1px&nbsp;#404040;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;background-color</font><font color='blue'>:&nbsp;#dbd8d1;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;z-index</font><font color='blue'>:&nbsp;1000;</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;filter</font><font color='blue'>:&nbsp;progid:DXImageTransform.Microsoft.Shadow(direction=157,color=#808080,strength=3);</font><font color='red'><br />
&nbsp;&nbsp;&nbsp;&nbsp;display</font><font color='blue'>:&nbsp;none;</font><font color='red'><br />
</font><font color='blue'>}</font>

					</span>
									</radts:PageView>
									<radts:PageView ID="Page5" runat="server">
										<span class="editorCode" contenteditable="true">
											<font color='blue'>&lt;</font><font color='maroon'>?xml</font><font color='red'>&nbsp;version</font><font color='blue'>="1.0"?&gt;</font><font color='black'><br />
											</font>
										</span>
									</radts:PageView>
								</radts:RadMultiPage>
							</div>
							<!-- ide editing area end -->
						</td>
					</tr>
					<tr>
						<td class="viewSwitch">
							<a href="javascript:" class="viewSwitchBtn"><img src="IdeImages/design.gif" height="10" width="10" title="" class="view">Design</a>
							<a href="javascript:" class="viewSwitchBtnClicked"><img src="IdeImages/html.gif" height="10" width="10" class="view">HTML</a>
						</td>
					</tr>
					<tr>
						<td class="statBar">
							<!-- statis bar begin -->
							<table border="0" cellpadding="0" cellspacing="2" width="100%">
								<tr>
									<td class="statbarCells" id="statBarInfo" unselectable="on">Ready</td>
									<td class="statbarCells" unselectable="on" width="100">&nbsp;</td>
									<td class="statbarCells" unselectable="on" width="244">Ln 
										38&nbsp;&nbsp;&nbsp;&nbsp; Col 58&nbsp;&nbsp;&nbsp;&nbsp; Ch 47</td>
									<td class="statbarCells" unselectable="on" width="21">&nbsp;</td>
									<td class="statbarCells" unselectable="on" width="21" align="center">INS</td>
								</tr>
							</table>
							<!-- status bar end -->
						</td>
					</tr>
				</table>
			</div>
			<!-- ////////////////////////////// VS.Net IDE End ////////////////////////////// -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
			<radDk:RadDockableObject id="RadDockableObject2" runat="server" Text="Toolbox" DockingMode="NeverDock" Width="204px"
				Height="321px" Behavior="Pin,Resize">
				<TitleBarStyle></TitleBarStyle>
				<ContentTemplate>
					<iframe name="ifrToolbox" src="toolbox.html" width="100%" height="318" frameborder="0" scrolling="0"></iframe>
				</ContentTemplate>
				<Commands>
					<raddk:RadDockableObjectCommand ToolTip="Pin" Name="Pin"></raddk:RadDockableObjectCommand>
					<raddk:RadDockableObjectCommand ToolTip="Unpin" Name="Unpin" Enabled="False"></raddk:RadDockableObjectCommand>
					<raddk:RadDockableObjectCommand ToolTip="Close" Name="Close" Enabled="True"></raddk:RadDockableObjectCommand>
				</Commands>
			</radDk:RadDockableObject>
			<radDk:RadDockableObject id="RadDockableObject1" runat="server" Text="Output" DockingMode="NeverDock" Width="400"
				Height="350px" Behavior="Pin,Resize">
				<TitleBarStyle></TitleBarStyle>
				<ContentTemplate>
					<iframe name="ifrOutput" src="output.html" width="100%" height="318" frameborder="0" scrolling="0"></iframe>
				</ContentTemplate>
				<Commands>
					<raddk:RadDockableObjectCommand ToolTip="Pin" Name="Pin"></raddk:RadDockableObjectCommand>
					<raddk:RadDockableObjectCommand ToolTip="Unpin" Name="Unpin" Enabled="False"></raddk:RadDockableObjectCommand>
					<raddk:RadDockableObjectCommand ToolTip="Close" Name="Close" Enabled="True"></raddk:RadDockableObjectCommand>
				</Commands>
			</radDk:RadDockableObject>
		</form>
	</body>
</html>
