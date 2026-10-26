<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Import Namespace="Telerik.QuickStart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1" NAME="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/QuickStartNavigation.ascx"></telerik:Header>
			

<div id="tab1" class="text">
	<strong>Adding r.a.d.<strong><%= ProductInfo.ControlName %></strong> to Your IDE (Visual Studio.NET / WebMatrix)</strong><br/><br/>
	Follow these steps to add r.a.d.<strong><%= ProductInfo.ControlName %></strong> to your toolbox:
	<ol>
		<li>Open the Toolbox.</li>
		<li>Expand the General Section.</li>
		<li>Right click it and open Customize Toolbox (called Add/Remove Items in v.1.1 and Choose Items in v2.0).</li>
		<li>Click the .NET Framework Components tab.</li>
		<li>Click the Browse button.</li>
		<li>Browse to the location where <%= ProductInfo.RadControlName %>.Net2.dll file resides and open it. By default, it must be in your Program Files\telerik\r.a.d.<%= ProductInfo.ControlName %><%= ProductInfo.Version %>\NET2\bin folder.</li>
		<li>Click the Open button to confirm.</li> 
	</ol>
</div>
<div id="tab2" class="text" style="display:none">
	<strong>Adding r.a.d.<strong><%= ProductInfo.ControlName %></strong> to Your Web Application Using Visual Studio.NET</strong><br/><br/>
	If you have added r.a.d.<strong><%= ProductInfo.ControlName %></strong> to the Visual Studio toolbox, do the following:
	<ul>
		<li>Drag the r.a.d.<strong><%= ProductInfo.ControlName %></strong> icon from the toolbox and drop it in your Web form / Web user control. Visual Studio will automatically copy the <%= ProductInfo.RadControlName %>.Net2.dll to the .\bin folder of your Web application and will create the respective Reference. </li>
	</ul>
	<i><strong>Note:</strong> Each time you create a new Web application, you must copy the 
	<strong>\RadControls</strong> folder from the virtual directory where r.a.d.<strong><%= ProductInfo.ControlName %></strong> 
	has been installed, into the folder of your Web application. <strong>\RadControls</strong> 
	folder contains files that are necessary for the functioning of 
	r.a.d.<strong><%= ProductInfo.ControlName %></strong>.</i> 
</div>
<div id="tab3" class="text" style="display:none">
	<strong>Adding r.a.d.<strong><%= ProductInfo.ControlName %></strong> to Your Web Application Manually</strong><br/><br/>
	<ol>
		<li>Copy the <%= ProductInfo.RadControlName %>.Net2.dll from the .\bin folder to the .\bin folder of your web-application. </li>
		<li>If you wish to speed up your work, you can also use some of the sample images and sample XML content files provided with the r.a.d.<strong><%= ProductInfo.ControlName %></strong> installation. Copy the files that you 
		need to the root directory of your web-application.</li>
	</ol>
	<i><strong>Note:</strong> Each time you create a new Web application, you must copy the 
	<strong>\RadControls</strong> folder from the virtual directory where r.a.d.<strong><%= ProductInfo.ControlName %></strong> 
	has been installed, into the folder of your Web application. <strong>\RadControls</strong> 
	folder contains files that are necessary for the functioning of 
	r.a.d.<strong><%= ProductInfo.ControlName %></strong>.</i> 
</div>
<div id="tab4" class="text" style="display:none">
	<strong>Adding r.a.d.<strong><%= ProductInfo.ControlName %></strong> to a Web Page</strong><br/><br/>
	Follow these steps to add r.a.d.<strong><%= ProductInfo.ControlName %></strong> to a blank ASP.NET page:
	<ul>
		<li>Open a blank <strong><i>aspx/ascx</i></strong> page </li>
		<li>Add the following tag in the beginning of your ASP.NET page:
			<br/>
			<span style="background:yellow 0% 50%;moz-background-clip:initial;moz-background-inline-policy:initial;moz-background-origin:initial">
				&lt;%@ Register TagPrefix="rad<%= ProductInfo.FirstLetter %>" Namespace="Telerik.WebControls" Assembly="<%= ProductInfo.RadControlName %>.Net2"%&gt;<br/>
			</span></li>
		<li>Place r.a.d.<span style="font-weight:bold"><%= ProductInfo.ControlName %></span> on the page anywhere you wish by pasting the following code:<br/>
			<span style="color:rgb(51,51,255)">&lt;</span>
			<span style="color:rgb(255,0,0)"><span style="color:rgb(153,0,0)">rad<%= ProductInfo.FirstLetter %>:<%= ProductInfo.RadControlName %></span> id<span style="color:rgb(51,51,255)">="<%= ProductInfo.RadControlName %>1"</span> Runat<span style="COLOR: rgb(51,51,255)">="server"&gt;&lt;/</span></span><span style="color:rgb(255,0,0)"><span style="color:rgb(153,0,0)">rad<%= ProductInfo.FirstLetter %>:<%= ProductInfo.RadControlName %></span></span><span style="color:rgb(51,51,255)">&gt;</span><br/>
			If there is more than on r.a.d.<span style="FONT-WEIGHT: bold"><%= ProductInfo.ControlName %></span> on the page, use <span style="color:rgb(255,0,0)">id<span style="color:rgb(51,51,255)">="<%= ProductInfo.RadControlName %>2"</span></span> for the next, <span style="color:rgb(255,0,0)">id<span style="color:rgb(51,51,255)">="<%= ProductInfo.RadControlName %>3"</span></span> for the third, and so on. <br/>
		</li>
		<li>Save your work</li>
	</ul>
	This will add the default <%= ProductInfo.ControlName %> to your ASP.NET page. Once you
	are done with this simple example, you can start experimenting with
	different configurations of r.a.d.<strong><%= ProductInfo.ControlName %></strong>.
</div>
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>



