<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radt" Namespace="Telerik.WebControls" Assembly="RadTreeView" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<%@ Page AutoEventWireup="false" CodeBehind="DefaultVB.aspx.vb" Inherits="Telerik.CallbackIntegarationExamplesVBNET.TreeView.DefaultVB" Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="VB"></telerik:Header>
			<!-- content start -->
			<script type="text/javascript">
			/*<![CDATA[*/			
				function tree2Click(node)
				{
					window["<%= RadCallback2.ClientID %>"].MakeCallback("treeview2", node.Text);
				}
			
				function treeNodeDropped(sourceNode, destNode)
				{
					if ((sourceNode) && (destNode))
					{
						window["<%= RadCallback1.ClientID %>"].MakeCallback(sourceNode.TreeView.ClientID + "," + destNode.TreeView.ClientID, sourceNode.Text + "," + destNode.Text);
						return false;
					}
				}
			/*]]>*/						
			</script>
			<asp:label id="Label2" runat="server" Font-Bold="True">Change TreeView Skins:</asp:label>
			<radclb:radcallback id="RadCallback1" runat="server"></radclb:radcallback>
			<radclb:callbackdropdownlist id="ddlSkin" runat="server" Width="188px" DisableAtCallback="true" OnSelectedIndexChanged="ddlSkin_SelectedIndexChanged">
				<asp:ListItem Value="MSDN Blue">MSDN Blue</asp:ListItem>
				<asp:ListItem Value="MSDN Classic">MSDN Classic</asp:ListItem>
				<asp:ListItem Value="ROUND 3DBlue">ROUND 3DBlue</asp:ListItem>
			</radclb:callbackdropdownlist>
			<radclb:radcallback id="RadCallback2" DisableAtCallback="true" runat="server"></radclb:radcallback>
			<radclb:callbackbutton id="btnToggleExpand" DisableAtCallback="true" runat="server" Text="Collapse All Nodes"
				Width="185px" CssClass="button"></radclb:callbackbutton>
			<br />
			<br />
			<br />
			<div style="float:left;width:332px;">
				<b>TreeView 1</b><br />
				<radt:RadTreeView id="tree2" runat="server" Width="332px" Height="353px" BeforeClientClick="tree2Click"
					draganddrop="True" beforeclientdrop="treeNodeDropped" Skin="MSDN/Blue" LoadingMessagePosition="BeforeNodeText"
					CausesValidation="True">
					<Nodes>
						<radt:RadTreeNode Value="node 3" Text="node 3">
							<Nodes>
								<radt:RadTreeNode Value="child 31" Text="child 31">
									<Nodes>
										<radt:RadTreeNode Text="child 311"></radt:RadTreeNode>
									</Nodes>
								</radt:RadTreeNode>
							</Nodes>
						</radt:RadTreeNode>
						<radt:RadTreeNode Value="node 4" Text="node 4">
							<Nodes>
								<radt:RadTreeNode Value="Child 41" Text="Child 41"></radt:RadTreeNode>
							</Nodes>
						</radt:RadTreeNode>
					</Nodes>
				</radt:RadTreeView>
				<hr />
			</div>
			<div class="module" style="width:280px;margin-right:100px;float:right;">
				<asp:label id="Label5" runat="server" Font-Bold="True">Rebind:</asp:label><br />
				<radclb:CallbackListBox id="lbSourceTree2" DisableAtCallback="true" runat="server" Width="185px" Height="82px">
					<asp:ListItem Value="Source 1">Programatically</asp:ListItem>
					<asp:ListItem Value="Source 2" Selected="True">Database</asp:ListItem>
					<asp:ListItem Value="Source 3">Xml file</asp:ListItem>
				</radclb:CallbackListBox><br />
				<asp:label id="Label1" runat="server" Font-Bold="True">Selected Node Text:</asp:label><br />
				<asp:textbox id="tbNodeText" runat="server" Width="180px"></asp:textbox><radclb:callbackbutton id="btnRename" DisableAtCallback="true" runat="server" Text="Rename" Width="86px"
					CssClass="button"></radclb:callbackbutton><br />
				<br />
				<radclb:callbackbutton id="btnRemove" DisableAtCallback="true" runat="server" Text="Remove Selected Node"
					Width="185px" CssClass="button"></radclb:callbackbutton>
			</div>
			<div style="clear:both;"></div>
			<div style="float:left;width:332px;">
				<b>TreeView 2</b><br />
				<radt:RadTreeView id="tree1" runat="server" Width="332px" Height="349px" draganddrop="True" beforeclientdrop="treeNodeDropped"
					Skin="MSDN/Blue" LoadingMessagePosition="BeforeNodeText" CausesValidation="True">
					<Nodes>
						<radt:RadTreeNode Value="node 1" Text="node 1">
							<Nodes>
								<radt:RadTreeNode Value="child 11" Text="child 11"></radt:RadTreeNode>
							</Nodes>
						</radt:RadTreeNode>
						<radt:RadTreeNode Value="node 2" Text="node 2">
							<Nodes>
								<radt:RadTreeNode Value="Child 22" Text="Child 22"></radt:RadTreeNode>
							</Nodes>
						</radt:RadTreeNode>
					</Nodes>
				</radt:RadTreeView>
			</div>
			<div class="module" style="width:280px;margin-right:100px;float:right;">
				<asp:label id="Label4" runat="server" Font-Bold="True"> Rebind:</asp:label><br />
				<radclb:CallbackListBox id="lbSourceTree1" DisableAtCallback="true" runat="server" Width="185px" Height="82px">
					<asp:ListItem Value="Source 1" Selected="True">Programatically</asp:ListItem>
					<asp:ListItem Value="Source 2">Database</asp:ListItem>
					<asp:ListItem Value="Source 3">Xml file</asp:ListItem>
				</radclb:CallbackListBox><br />
				<asp:label id="Label3" runat="server" Font-Bold="True">Add new Node:</asp:label><br />
				<asp:textbox id="tbNewNodeText" runat="server" Width="180px"></asp:textbox><br />
				<radclb:callbackbutton id="btnAddChild" runat="server" DisableAtCallback="true" Text="Add Child" CssClass="button"
					width="100"></radclb:callbackbutton>
				<radclb:callbackbutton id="btnAddRoot" DisableAtCallback="true" runat="server" Text="Add Main Item" CssClass="button"
					width="150"></radclb:callbackbutton>
			</div>
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
