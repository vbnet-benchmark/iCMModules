/* 
External javacsript file for 
r.a.d.dock visual studio .net toolbox example
- Please, refer to Styles.css for id's and classes for the objects;
- Please, refer to the bottom of this file for default open panel.
*/

// Toggle 'clipboard ring' panel - expand / collapse
function toggleShowClipboardRingPanel()
{
    if(document.getElementById('clipboardRingPanel').style.display == 'block') // if visible
    {
        document.getElementById('clipboardRingPanel').style.display = 'none';
    }
    else
    {
        document.getElementById('clipboardRingPanel').style.display = 'block'; // if hidden
    }
}
// Toggle 'html' panel - expand / collapse
function toggleShowHtmlPanel()
{
    if(document.getElementById('htmlPanel').style.display == 'block') // if visible
    {
        document.getElementById('htmlPanel').style.display = 'none'; 
    }
    else
    {
        document.getElementById('htmlPanel').style.display = 'block'; // if hidden
    }
}
// Toggle 'telerik' panel - expand / collapse
function toggleGeneralPanel()
{
    if(document.getElementById('telerik').style.display == 'block') // if visible
    {
        document.getElementById('telerik').style.display = 'none';
    }
    else
    {
        document.getElementById('telerik').style.display = 'block'; // if hidden
    }
}
// hide currently open panels, get by IDs
function hideOpenPanel1(panelId)
{
    document.getElementById(panelId).style.display = 'none'; // hide
}
function hideOpenPanel2(panelId)
{
    document.getElementById(panelId).style.display = 'none'; // hide
}
// hide window status for aesthetic purposes
function hidestatus()
{
    window.status=''; // window status empty string
    return true;
}
if (document.layers)
	document.captureEvents(Event.MOUSEOVER | Event.MOUSEOUT) // event handlers
	document.onmouseover = hidestatus;
	document.onmouseout = hidestatus;
// get tool onclick
function getTool(toolId)
{
    if(navigator.appName == 'Netscape') // for Gecko browsers with no innerText support
    {
        document.getElementById('selectedToolDisplay').innerHTML = '&nbsp;current control: <b><br />&nbsp;' + document.getElementById(toolId).innerHTML + '</b>';
        document.getElementById('removeSeletedTool').innerHTML = '<a href="javascript:removeTool()" class="removeTool">remove control</a>&nbsp;';
    }
    else // for IE, etc. - with innerText support
    {
        document.getElementById('selectedToolDisplay').innerHTML = '&nbsp;current control: <b><br />&nbsp;' + document.getElementById(toolId).innerHTML + '</b>';
        document.getElementById('removeSeletedTool').innerHTML = '<a href="javascript:removeTool()" class="removeTool">remove control</a>&nbsp;';
    }
}
// remove selected tool
function removeTool()
{
    if(navigator.appName == 'Netscape') // for Gecko browsers with no innerText support
    {
        if(confirm('Are you sure you want to remove the selected control?\nClick OK to continue deletion or Cancel to return.'))
        {
            document.getElementById('selectedToolDisplay').innerHTML = '&nbsp;current control: <br />&nbsp;<i class="noTool">none</i>';
            document.getElementById('removeSeletedTool').innerHTML = '<a class="removeToolDisabled">remove control</a>&nbsp;';
        }
        else
        {
            return;
        }
    }
    else // for IE, etc. - with innerText support
    {
        if(confirm('Are you sure you want to remove the' + document.getElementById('selectedToolDisplay').innerText + '?\nClick OK to continue deletion or Cancel to return.'))
        {
            document.getElementById('selectedToolDisplay').innerHTML = '&nbsp;current control: <br /><i class="noTool">&nbsp;none</i>';
            document.getElementById('removeSeletedTool').innerHTML = '<a class="removeToolDisabled">remove control</a>&nbsp;';
        }
        else
        {
            return;
        }
    }
}
/*
Set the default expanded panel on page load
Here, we have specified 'telerik' for default,
but this could be easily changed by modifying the 
script below
*/
function defaultPanel()
{
    toggleGeneralPanel(); // open telerik panel -  - set to display: block;
    hideOpenPanel1('htmlPanel'); // hide html panel - set to display: none;
    hideOpenPanel2('clipboardRingPanel'); // hide clipboard ring panel - set to display: none;
}
window.onload = defaultPanel; // open default panel event handler