<%@ Control %>
<%@ Import Namespace="Telerik.QuickStart" %>

<script language="C#" runat="server">
public void Page_Load(object sender, EventArgs args)
{
	if (ProductInfo.ChmUrl == string.Empty)
		ChmLink.Visible = false;
	/*	
	if (ProductInfo.ManualUrl == string.Empty)
		ManualLink.Visible = false;
        */
		
	if (ProductInfo.PdfManualUrl == string.Empty)
		PdfManualLink.Visible = false;
}
</script>
<span runat="server" id="ChmLink">
	<a href="<%= ProductInfo.ChmUrl%>">
		<img runat="server" src="~/Img/helpIconCHM.gif" alt="help link" style="border: 0px;margin-left: 6px; margin-right: 6px;margin-top: 4px; margin-bottom: 4px;" />
			Deployment Manual and Reference (CHM format, MS Help 1)</a><br/>
</span>
<span runat="server" id="ManualLink">
    <a onclick="window.open('<%= ProductInfo.ManualUrl %>'); return false;" onkeypress="window.open('<%= ProductInfo.ManualUrl %>'); return false;" href="#">
		<img runat="server" src="~/Img/helpIconIE.gif" alt="help link" style="border: 0px;margin-left: 6px; margin-right: 6px;margin-top: 4px; margin-bottom: 4px;" />
			Deployment Manual and Reference (browsable on-line version)</a><br/>
</span>
<span runat="server" id="PdfManualLink">
	<a href="<%= ProductInfo.PdfManualUrl%>">
		<img runat="server" src="~/Img/helpIconPDF.gif" alt="help link" style="border: 0px;margin-left: 6px; margin-right: 6px;margin-top: 4px; margin-bottom: 4px;" />
			End-User Manual</a> (printable PDF document)
</span>