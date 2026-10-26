var lastTab = "";
var http_request = null;

function updateTabAJAX()
{
	if (http_request.readyState == 4)
	{
        if (http_request.status == 200)
        {
			
			var container = document.getElementById("codeViewerAjaxContainer");
			if (container)
			{
				var htmlContent = http_request.responseText.substring(http_request.responseText.indexOf("<![CDATA[")+9,http_request.responseText.lastIndexOf("]]>")).replace("&lt;![CDATA[","<![CDATA[").replace("]]&gt;","]]>");
				var newDiv = document.createElement("div");
				container.appendChild(newDiv);
				newDiv.id = http_request.responseText.substring(http_request.responseText.indexOf("<tab>")+5,http_request.responseText.lastIndexOf("</tab>")) + "TabContent";
				newDiv.innerHTML = htmlContent;
				document.getElementById("codeContent").innerHTML = htmlContent;
			}
        }
        else
        {
            document.getElementById("codeContent").innerHTML = "An Error occured! Code:"+http_request.status;
        }
    }
}

function CreateXMLHTTPRequest() {
	if (window.XMLHttpRequest)
	{ 
		var xmlHttp = new XMLHttpRequest();
	    if (xmlHttp.overrideMimeType)
	    {
			xmlHttp.overrideMimeType('text/xml');
		}
		return xmlHttp;
	}
	var progIDs = [ 'Msxml2.XMLHTTP', 'Microsoft.XMLHTTP' ];
	for (var i = 0; i < progIDs.length; i++) {
		try
		{
			var xmlHttp = new ActiveXObject(progIDs[i]);
			return xmlHttp;
		}
		catch (ex) {}
	}
	return null;
}

function displayTabAJAX(tabName, fileName)
{
	if (tabName.length>0 && tabName != lastTab)
	{
		var tabCell = document.getElementById(tabName + "Tab");
		var tabContent = document.getElementById(tabName + "TabContent");
		if (!tabContent)
		{
			/* the content is not yet here. request it from the server using AJAX */
			if (!serviceUrl)
				return false;
			http_request = CreateXMLHTTPRequest();
			if (!http_request)
			{
				/* AJAX init failed. Fallback to normal http requests. */
				displayTabPOSTBACK(tabName);
				return false;
			}
			http_request.onreadystatechange = updateTabAJAX;
			http_request.open('POST', serviceUrl, true);
			var postData = "fileType="+tabName+"&filePath="+fileName;
			http_request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
			http_request.setRequestHeader('Content-Length', postData.length);
			http_request.send(postData);
			document.getElementById("codeContent").innerHTML = document.getElementById("codeViewerLoadingTemplate").innerHTML;
		}
		else
		{
			document.getElementById("codeContent").innerHTML = tabContent.innerHTML;
		}
		
		if (lastTab != "")
		{
			var lastTabCell = document.getElementById(lastTab + "Tab");
			lastTabCell.childNodes[0].src = lastTabCell.childNodes[0].src.replace(/\.gif$/ig, "Disabled.gif");
		}
		tabCell.childNodes[0].src = tabCell.childNodes[0].src.replace(/Disabled\.gif$/ig, ".gif");
		lastTab = tabName;
	}
	return false;
//	if (tabName != "Description")
//		window.location.href="#codeContent";
}
