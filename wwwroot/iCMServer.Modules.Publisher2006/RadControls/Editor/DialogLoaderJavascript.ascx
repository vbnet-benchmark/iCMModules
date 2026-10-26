<%@ Control CodeBehind="DialogLoaderJavascript.ascx.cs" Language="c#" AutoEventWireup="false" Inherits="Telerik.WebControls.Dialogs.DialogLoaderJavascript" %>
<input type="hidden" runat="server" id="hiddenDialogParams"/>
<asp:literal id="literalScripts" runat="server" />
<asp:placeholder id="placeholderDialog" runat="server"></asp:placeholder>
<asp:literal runat="server" id="literalSelfReloadScript">
	<script type="text/javascript">
		if (window.attachEvent)
		{
			window.attachEvent("onload", SubmitParameters);
		}
		else if (window.addEventListener)
		{
			window.addEventListener("load", SubmitParameters, false);
		}
		
		function SubmitParameters()
		{
			var internalParameters = GetDialogArguments().InternalParameters;
			if (internalParameters)
			{
				myHiddenDialogParams.value = internalParameters;
			}

			document.forms[0].submit();
		}
		
	</script>
</asp:literal>