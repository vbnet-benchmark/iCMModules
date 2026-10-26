<%@ Page AutoEventWireup="false" Inherits="Telerik.ToolbarExamplesCS.Integration.ToolbarAndComboAndMenu.DefaultCS" Language="c#" CodeBehind="DefaultCS.aspx.cs" %>
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
		<style type="text/css">
		.comboItem { font-size: 11;}
		</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<raddk:RadDockingManager id="radManager" runat="server"
				ShowToolTipWhileDragging="False"
				SkinsPath="~/Controls/Examples/Integration/ToolbarAndDock/Dock/" 
                Skin="Toolbar"></raddk:RadDockingManager>
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#" XHTMLCompliant="False"></telerik:Header>
			<!-- content start -->
			<raddk:RadDockingZone id="dockTop" runat="server" type="Horizontal" height="50px" width="450px"></raddk:RadDockingZone>
			<raddk:RadDockingZone id="dockLeft" runat="server" type="Horizontal" height="50px" width="450px"></raddk:RadDockingZone>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
						<raddk:RadDockableObject id="dockObjectToolbar" runat="server"
				Behavior="None" FloatingObjectEnabledGrips="Auto" DockedObjectEnabledGrips="Auto"
				Text="toolbar" Width="405" Height="1" style="position: absolute; top:100px;left:200px;">
			<contenttemplate><radtlb:RadToolbar id="toolbarTop" runat="server" DisplayEnds="false" Skin="Office2003">
				<items>
					<radtlb:radtoolbarbutton id="button_new" Tooltip="New" CommandName="new" ButtonText="New" ButtonImage="new.gif" />
					<radtlb:radtoolbarseparator />
					<radtlb:radtoolbarbutton id="button_undo" Tooltip="Undo" CommandName="undo" ButtonText="Undo" ButtonImage="undo.gif" Enabled="false" />
					<radtlb:radtoolbarbutton id="button_redo" Tooltip="Redo" CommandName="redo" ButtonText="Redo" ButtonImage="redo.gif" Enabled="false" />
					<radtlb:radtoolbarseparator />
					<radtlb:radtoolbartemplatebutton runat="server" ID="combo_address">
						<buttontemplate><div style="white-space: nowrap;font-family:Arial;font-size:11px;">Address:
						 <radcb:radcombobox 
                            Skin="WindowsXP"
                            id="RadComboBox3"
                            Runat="server"
                            Height="190px"
                            MarkFirstMatch="true"
                            HighlightTemplatedItems="true"
                            TabIndex="3" DataTextField="Country">
                            <headertemplate>
                                <table border="0" style="width:435px" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width:125px;">
                                            <div class="comboItem">Country</div>
                                        </td>
                                        <td style="width:125px;">
                                            <div class="comboItem">Dealer Name</div>
                                        </td>
                                        <td>
                                            <div class="comboItem">Address</div>
                                        </td>
                                    </tr>
                                </table>
                            </headertemplate>
                            <itemtemplate>
                                <table style="width:415px" class="comboTable" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width:125px;">
                                            <div class="comboItem"><%# DataBinder.Eval(Container.DataItem, "Country") %></div>
                                        </td>
                                        <td style="width:125px;">
                                            <div class="comboItem"><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></div>
                                        </td>
                                        <td style="width:125px;">
                                            <div class="comboItem"><%# DataBinder.Eval(Container.DataItem, "Address") %></div>
                                        </td>
                                        <td style="width:40px;">
                                        </td>
                                    </tr>
                                </table>
                            </itemtemplate>                            
                        </radcb:radcombobox></div>
                        </buttontemplate>
					</radtlb:radtoolbartemplatebutton>
					<radtlb:radtoolbarseparator />
					<radtlb:radtoolbartemplatebutton runat="server" ID="menu_app">
						<buttontemplate>
							<radm:RadMenu id="toolbarMenu" runat="server" Theme="Office2003">
								<RootGroupPersistable Flow="Horizontal" CssClass="Office2003_MainGroup">
									<radm:MenuItem Key="F" text="<u>F</u>ile" CssClass="Office2003_MainItem" CssClassOver="Office2003_MainItemOver" CssClassClicked="Office2003_MainItemOver">
										<ChildGroupPersistable Flow="Vertical">
											<radm:MenuItem Key="E" text="<u>E</u>dit" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="V" text="<u>V</u>iew" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="D" text="<u>D</u>ebug" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="B" text="<u>B</u>uild" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="T" text="<u>T</u>able" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="O" text="T<u>o</u>ols" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="W" text="<u>W</u>indow" LeftLogo="spacer.gif"/>
											<radm:MenuItem Key="H" text="<u>H</u>elp" LeftLogo="spacer.gif"/>
										</ChildGroupPersistable>
									</radm:MenuItem>
								</RootGroupPersistable>
							</radm:RadMenu>
						</buttontemplate>
					</radtlb:radtoolbartemplatebutton>
				</items>
			</radtlb:RadToolbar></contenttemplate>
			</raddk:RadDockableObject>
		</form>
	</body>
</html>
