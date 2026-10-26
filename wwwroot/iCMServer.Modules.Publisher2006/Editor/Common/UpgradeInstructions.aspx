<%@ Page AutoEventWireup="false" Inherits="Telerik.QuickStart.XhtmlPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
  "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="width:100%;">
			<telerik:Header runat="server" ID="Header1" NavigationControl="~/Common/UpgradeInstructionsNavigation.ascx"></telerik:Header>

			<div>
			<p style="text-align:center"><b>Upgrade Instructions – r.a.d.editor v5.x to r.a.d.editor 
			v6.x</b></p><ol>
			<li><b>Back up Your Old Files </b><br/>
			We strongly suggest that you back-up your old r.a.d.editor files and folders, 
			especially if you would like to <br/>
			use your old settings and your ToolsFile.xml.</li>

			<li><b>Install (Unpack) the New File </b><br/>
			Run the EXE installer or unpack the ZIP version to a convenient location (e.g. 
			\Program <br/>
			Files\telerik\r.a.d.editor6.0).
			<br/></li>
			<li><b>Important: Delete the following old folders</b> from your web-application 
			project folder (a simple overwrite is <br/>
			not sufficient). Otherwise you will experience JavaScript errors.<br/>
			~\RadControsl\Editor<br/>
			~\RadControls\Spell
			<br/></li>
			<li><b>Copy all files from the &quot;\bin&quot; and &quot;\RadControls&quot; folders</b> of the 
			installation folder (e.g. \Program <br/>
			Files\telerik\r.a.d.editor6.0) to the respective folder of your web-application. 
			Overwrite all files when <br/>
			asked.
			<br/></li>
			<li><b>Using the ConfigFile.xml file </b><br/>
			IMPORTANT: Make sure that you remove all deprecated properties from the XML 
			ConfigFile, otherwise the <br/>
			application will throw an error. For detailed instructions, please, review 
			section &quot;Changes and Backward <br/>
			Compatibility&quot; in the Deployment Manual.
			<br/></li>
			<li><b>API Changes </b><br/>
			Please, review the API changes, described in the &quot;Changes and Backward 
			Compatibility&quot; section of the <br/>
			Deployment Manual.</li></ol>
		</div>

	<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>