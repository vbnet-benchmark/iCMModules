<%@ Control Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script type="text/JavaScript">
<!--
	function expandTab(div)
	{
		var el = document.getElementById(div);
		if (!el) return;
		if (el.style.display == "none")
		{
			var controls = new Array("tab1", "tab2");
			for (var i=0; i<controls.length; i++)
			{
				if (controls[i] != div)
				{
					document.getElementById(controls[i]).style.display = "none";
				}
			}
			el.style.display = "inline";
		}
		return false;
	}
//-->
</script>
<br/>
<div class="sideNav">
	<a href="#" onclick="return expandTab('tab1')" onkeypress="return expandTab('tab1')">Help</a>
	<img src="../../Img/spacer.gif" alt="" width="1" height="1" />
</div>
<div class="sideNav">
	<a href="#" onclick="return expandTab('tab2')" onkeypress="return expandTab('tab2')">Support</a>
	<img src="../../Img/spacer.gif" alt="" width="1" height="1" />
</div>