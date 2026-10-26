<%@ Control Language="c#" AutoEventWireup="false" Inherits="Telerik.QuickStart.CodeViewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script type="text/javascript" src="<%= Page.ResolveUrl("~/Common/CodeViewer.js") %>"></script>
<br/>
<br/>
<div style="height:26px;clear:both;">
<table cellspacing="0" cellpadding="0" summary="telerik Code Viewer Control" border="0" class="codeTabs" style="width:100%;">
	<tr>
		<td><img src="<%= Page.ResolveUrl("~/Img/codeTabsStart.gif") %>" alt="" /></td>
		<asp:PlaceHolder ID="codePlaceholder" Runat="server"></asp:PlaceHolder>
		<td style="text-align:right;"><img src="<%= Page.ResolveUrl("~/Img/codeTabsFinish.gif") %>" style="border:none;" alt="" /></td>
	</tr>
</table>
</div>
<div class="codeOuter"><div class="code" id="codeContent"></div></div>
<asp:PlaceHolder ID="tabPlaceholder" Runat="server"></asp:PlaceHolder>