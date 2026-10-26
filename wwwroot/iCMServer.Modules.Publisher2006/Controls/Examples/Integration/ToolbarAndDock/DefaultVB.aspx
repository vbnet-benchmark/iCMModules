<%@ Page AutoEventWireup="false" Inherits="Telerik.ToolbarExamplesVB.Integration.ToolbarAndDock.DefaultVB" Language="vb" CodeBehind="DefaultVB.aspx.vb" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radtlb" Namespace="Telerik.WebControls" Assembly="RadToolbar" %>
<%@ Register TagPrefix="radcb" Namespace="Telerik.WebControls" Assembly="RadCombobox" %>
<%@ Register TagPrefix="radm" Namespace="Telerik.WebControls" Assembly="RadMenu" %>
<%@ Register TagPrefix="raddk" Namespace="Telerik.WebControls" Assembly="RadDock" %>
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<link rel="stylesheet" type="text/css" href="WinWord/Styles/Styles.css" />
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<raddk:RadDockingManager 
				id="radManager" 
				runat="server"
			    ShowToolTipWhileDragging="False"
                SkinsPath="~/Controls/Examples/Integration/ToolbarAndDock/Dock/" 
                Skin="Toolbar"></raddk:RadDockingManager>
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB" XHTMLCompliant="False"></telerik:Header>
			<!-- content start -->
			
			<div class="winWord">
				<div class="fileBar"></div>
				<div class="horizontalDockZoneWrapper">
					<raddk:RadDockingZone 
						id="dockTop" 
						runat="server" 
						type="Horizontal" 
						style="border: solid 1px #c3daf9;"
						height="28px" 
						width="735px">
					</raddk:RadDockingZone>
				</div>
				<div class="mainArea">
					<div class="verticalDockZoneWrapper">
						<raddk:RadDockingZone 
							id="dockLeft" 
							runat="server" 
							type="Vertical" 
							height="441px" 
							width="26px">
						</raddk:RadDockingZone>
					</div>
					<div class="editingArea">
						<div class="dumpText">
							<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Cras purus pede, aliquam vel, eleifend in, mollis sit amet, ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Mauris tempor. Ut pretium. Donec libero turpis, viverra ac, pharetra vel, rutrum ut, pede. Proin vulputate diam a libero. Donec nec turpis. Integer purus. Proin ipsum risus, tempus scelerisque, tempus et, commodo quis, diam. Cras pulvinar urna ac erat. Aliquam pulvinar gravida justo. </p>
							<p>Curabitur a magna. Nunc cursus, lorem vitae auctor porta, arcu felis suscipit nulla, a auctor erat turpis eget quam. Nunc condimentum nunc nec elit. Nam blandit ultricies pede. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce suscipit commodo justo. Vestibulum eu felis a orci vulputate adipiscing. Aliquam erat volutpat. Donec libero ante, accumsan vitae, consequat et, laoreet vitae, leo.</p>
						</div>
					</div>	
				</div>
			</div>
			
							
						
								
							
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
			<raddk:RadDockableObject 
				id="dockObjectToolbar" 
				runat="server"
				Behavior="None" 
				FloatingObjectEnabledGrips="Titlebar" 
				DockedObjectEnabledGrips="Auto"
				Text="Edit" Width="440px" Height="1px"
				style="position: absolute; top:200px;left:300px;">
				<contenttemplate>
					<radtlb:radtoolbar runat="server" id="toolbar1" skin="Office2003" DisplayEnds="false"
					UseFadeEffect="True" style="vertical-align:top;">
						<items>
							<radTlb:RadToolbarButton 
								id="button_new" 
								Tooltip="New Document" 
								CommandName="new" 
								ButtonText="New" 
								ButtonImage="new.gif" />
							<radTlb:RadToolbarButton 
								id="button_open" 
								Tooltip="Open" 
								CommandName="open" 
								ButtonText="Open" 
								ButtonImage="open.gif" />
							<radTlb:RadToolbarButton 
								id="button_save" 
								Tooltip="Save" 
								CommandName="save" 
								ButtonText="Save" 
								ButtonImage="save.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarButton 
								id="button_print" 
								Tooltip="Print" 
								CommandName="print" 
								ButtonText="Print" 
								ButtonImage="print.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarButton 
								id="button_cut" 
								Tooltip="Cut" 
								CommandName="cut" 
								ButtonText="Cut" 
								ButtonImage="cut.gif" />
							<radTlb:RadToolbarButton 
								id="button_copy" 
								Tooltip="Copy" 
								CommandName="copy" 
								ButtonText="Copy" 
								ButtonImage="copy.gif" />
							<radTlb:RadToolbarButton 
								id="button_paste" 
								Tooltip="Paste" 
								CommandName="paste" 
								ButtonText="Paste" 
								ButtonImage="paste.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarButton 
								id="button_undo" 
								Tooltip="Undo" 
								CommandName="undo" 
								ButtonText="Undo" 
								ButtonImage="undo.gif" />
							<radTlb:RadToolbarButton 
								id="button_redo" 
								Tooltip="Redo" 
								CommandName="redo" 
								ButtonText="Redo" 
								ButtonImage="redo.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarToggleButton 
								ButtonGroup="alignment"
								id="button_left" 
								Tooltip="Align Left" 
								CommandName="left" 
								ButtonText="Navigate Backward" 
								ButtonImage="alignLeft.gif" />
							<radTlb:RadToolbarToggleButton 
								ButtonGroup="alignment"
								id="button_justify" 
								Tooltip="Justify" 
								CommandName="justify" 
								ButtonText="Navigate Forward" 
								ButtonImage="justify.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarToggleButton 
								id="button_ol" 
								Tooltip="Numbering" 
								CommandName="ol" 
								ButtonGroup="lists" 
								ButtonText="Navigate Forward" 
								ButtonImage="numbering.gif" />
							<radTlb:RadToolbarToggleButton 
								id="button_ul" 
								ButtonGroup="lists" 
								Tooltip="Bullets" 
								CommandName="ul" 
								ButtonText="Navigate Forward" 
								ButtonImage="bullets.gif" />
							<radTlb:RadToolbarSeparator/>
							<radTlb:RadToolbarButton 
								id="button_link" 
								Tooltip="Hyperlink" 
								CommandName="link" 
								ButtonText="Insert Hyperlink" 
								ButtonImage="link.gif" />
							<radTlb:RadToolbarButton 
								id="button_table" 
								Tooltip="Draw Table" 
								CommandName="table" 
								ButtonText="Table" 
								ButtonImage="table.gif" />
							<radTlb:RadToolbarToggleButton 
								id="button_bold" 
								Tooltip="Bold" 
								CommandName="bold" 
								ButtonText="Bold" 
								ButtonImage="bold.gif" />
							<radTlb:RadToolbarToggleButton 
								id="button_italic" 
								Tooltip="Italic" 
								CommandName="italic" 
								ButtonText="Italic" 
								ButtonImage="italic.gif" />
							<radTlb:RadToolbarToggleButton 
								id="button_undeline" 
								Tooltip="Underline"
								CommandName="underline" 
								ButtonText="Underline" 
								ButtonImage="underline.gif" />
						</items>
					</radtlb:radtoolbar>
				</contenttemplate>
			</raddk:RadDockableObject>
		</form>
	</body>
</html>