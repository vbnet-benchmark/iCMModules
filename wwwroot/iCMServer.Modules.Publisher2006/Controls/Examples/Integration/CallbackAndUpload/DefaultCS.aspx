<%@ Page AutoEventWireup="false" Inherits="Telerik.CallbackExamplesCS.Integration.CallbackAndUpload.DefaultCS" Language="c#" CodeBehind="DefaultCS.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="telerik" TagName="Header" Src="~/Common/Header.ascx" %>
<%@ Register TagPrefix="telerik" TagName="HeadTag" Src="~/Common/HeadTag.ascx" %>
<%@ Register TagPrefix="telerik" TagName="Footer" Src="~/Common/Footer.ascx" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload" %>
<%@ Register TagPrefix="radclb" Namespace="Telerik.WebControls" Assembly="RadCallback" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<telerik:HeadTag runat="server" ID="Headtag1"></telerik:HeadTag>
		<!-- custom head section -->
		<style type="text/css"> 
			label
			{
				font-family: Arial, Verdana, Helvetica;
				font-size: 11px;
				color: #333333;
			}
			input
			{
				vertical-align: middle;
			}
			</style>
		<!-- end of custom head section -->
	</head>
	<body class="BODY">
		<form runat="server" id="mainForm" method="post" style="WIDTH:100%">
			<telerik:Header runat="server" ID="Header1" NavigationLanguage="C#"></telerik:Header>
			<!-- content start -->
			<table style="width: 100%">
				<tr>
					<td style="vertical-align:top;">
						<radclb:CallbackRadioButtonList id="rblLanguages" runat="server" RepeatDirection="Vertical" OnSelectedIndexChanged="rblLanguages_SelectedIndexChanged">
							<asp:listitem Value="de-DE">Deutch</asp:listitem>
							<asp:listitem Selected Value="en-US">English</asp:listitem>
							<asp:listitem Value="fr-FR">Francais</asp:listitem>
						</radclb:CallbackRadioButtonList>
						<br />
						<radU:RadUpload id="upload1" Runat="server" />
						<radu:RadUploadProgressArea id="progressArea1" runat="server" DisplayFileCountProgressBar="True" DisplayFileCountProgressData="True"
							DisplayCancelButton="True"></radu:RadUploadProgressArea>
						<br />
						<asp:Button id="btnSubmit" OnClick="btnSubmit_Click" Runat="server" Text="Submit" CssClass="RadUploadButton"
							style="margin-left: 11px;" />
					</td>
					<td style="vertical-align:top;">
						<div class="module" style="width: 280px; height: 150px; overflow: auto; float: right; margin-top: 5px;">
							<asp:label ID="lblNoResults" Runat="server" Visible="True">No uploaded files yet</asp:label>
							<asp:repeater ID="rptReqults" Runat="server" Visible="False">
								<headertemplate>
									Uploaded files:<br />
								</headertemplate>
								<itemtemplate>
									<asp:literal ID="ltFileName" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FileName")%>' >
									</asp:literal>
									(<asp:literal ID="ltFileSize" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>' ></asp:literal>)<br />
								</itemtemplate>
							</asp:repeater>
						</div>
					</td>
				</tr>
			</table>
			<br />
			<br />
			Note: Because of the specifics of the Internet forms, chosen files will be 
			uploaded only during a postback (e.g. if you have selected some files and you change 
			the language, the files will NOT be uploaded)<br />
			<br />
			<!-- content end -->
			<telerik:Footer runat="server" ID="Footer1"></telerik:Footer>
		</form>
	</body>
</html>
