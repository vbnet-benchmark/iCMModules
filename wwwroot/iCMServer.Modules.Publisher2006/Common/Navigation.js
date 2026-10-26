function toggleNodes(node)
{
	var image = node.getElementsByTagName("IMG")[0];
	var nextRow;
	if (document.all)
	{
		nextRow = node.parentNode.parentNode.nextSibling.childNodes[0].childNodes[0];
	}
	else
	{
		nextRow = node.parentNode.parentNode.nextSibling.nextSibling.getElementsByTagName("TABLE")[0];
	}
	if (image.src.match(/Plus\.gif$/i))
	{
		image.src = image.src.replace(/Plus\.gif$/i, "Minus.gif");
		nextRow.style.display = "block";
	}
	else
	{
		image.src = image.src.replace(/Minus\.gif$/i, "Plus.gif");
		nextRow.style.display = "none";
	}
}

function overNode(node)
{
	node.getElementsByTagName("SPAN")[0].style.textDecoration = "underline";
}

function outNode(node)
{
	node.getElementsByTagName("SPAN")[0].style.textDecoration = "none";
}