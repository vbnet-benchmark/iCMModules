<%@ Control AutoEventWireup="false" Inherits="Telerik.QuickStart.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Import Namespace="Telerik.QuickStart" %>
<script type="text/javascript">
//<![CDATA[
function ValidationClick()
{
	var url = "http://www.telerik.com/r.a.d." + "<%= ProductInfo.ControlName.ToLower()%>";
	var confirmed = 
	confirm("The validator requires this page to be online.\r\nDo you want to go to the Online Examples at\r\n " + url);
	if (confirmed)
	{
		window.open(url, "_blank");
	}
}
// set div.content dimensions to div.footer dimensions
function setDimensions() 
{
	var footerElement = document.getElementById("footer");
	var contentRightElement = document.getElementById("contentRight");
	if (footerElement && contentRightElement)
	{
		footerElement.style.width = contentRightElement.offsetWidth + "px";
	}
	var tabsElement = document.getElementById("tabs");
	if (tabsElement && contentRightElement)
	{
		tabsElement.style.width = contentRightElement.offsetWidth  + "px";
	}
}

var QuickStartOriginalOnLoadStorage = (window.onload) ? window.onload :  function(){};
function QuickStartOnLoadHandler()
{ 
    setDimensions(); 
    QuickStartOriginalOnLoadStorage();
}
window.onload =  QuickStartOnLoadHandler;

var QuickStartOriginalOnMouseUpStorage = (document.onmouseup) ? document.onmouseup :  function(){};
function QuickStartOnMouseUpHandler()
{ 
    setDimensions(); 
    QuickStartOriginalOnMouseUpStorage();
}
document.onmouseup = QuickStartOnMouseUpHandler;
//]]>
</script>
<div class="header">
	<img alt="product box" id="productBox" runat="server" width="76" height="94" style="marign-left:6px;float:left;" /><img alt="product logo" id="productLogo" runat="server" style="margin-bottom: 45px;float:left;"/><img alt="product caption" id="productCaption" runat="server" style="margin-left:30px; margin-top: 20px;float:left;" />
	<div id="logos">
		<a href="http://www.telerik.com"><img alt="telerik logo" id="logo" runat="server" src="~/Img/telerikLogo.gif" style="border:0;" /></a><br/>
		<img runat="server" src="~/Img/ajax.gif" alt="AJAX enabled" class="headerLogo">
	</div>
</div>
<div id="wrapper">
	<div id="navigation">
		<asp:PlaceHolder ID="leftNavigation" Runat="server" />
	</div>
	<div id="content">
		<div id="tabs">
			<telerik:Tabs id="tabControl" runat="server" CssClass="TabsRightCorner"></telerik:Tabs>
		</div>
		<div id="contentTD">
			<div id="contentRight">
				<div class="contentInner">