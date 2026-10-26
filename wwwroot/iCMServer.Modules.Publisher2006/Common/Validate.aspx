<%@ Page Language="C#" %>

<html>
	<head runat="server">
		<script>	
			function postback()
			{
				document.getElementById("scanform").submit();     
			}
		</script>
	</head>
	<body onload="postback();">
		<form id="scanform" method="post" action="http://webxact.watchfire.com/submit.aspx" 
		onsubmit="document.getElementById('tzo').value=(new Date()).getTimezoneOffset();return true;">
			<div style="display:none">
				<input name="SCANURL" id="SCANURL" type="text" value="<%=Request.UrlReferrer.ToString()%>" size="50" maxlength="900" /> 
				<input type="submit" value="Go!" style="width: 5em;" />
				<input name="GL" type="hidden" value="<%= Request.Params["level"]%>" />
				<input name="FR" type="hidden" value="1" />
				<input name="CL" type="hidden" value="1" />
				<input name="AR" type="hidden" value="1" />
				<input name="RS" type="hidden" value="1" />
				<input name="SA" id="SA" type="hidden" value="1" />	
				<input type="hidden" name="complete" id="complete" value="1" />			
				<input name="tzo" id="tzo" type="hidden" value="" />				
			</div>
		</form>
	</body>
</html>