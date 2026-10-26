/* 
External JavaScript file for
r.a.d.dock Visual Studio .Net IDE example
- Please, refer to IdeStyles/Ide.css for id's and classes of the objects;
*/
/* window command buttons - minimize and maximize/restore are disabled */
// status bar help
function statBarHelp(statBarMsg)
{
	document.getElementById('statBarInfo').innerHTML = statBarMsg; // update status bar with a responding string (statBarMsg);
}
// open file
function newDocument()
{
	if(confirm('\tThis will reload the page.\t\t\n\tAre you sure?\t\t'))
	{
		location.reload();
	}
	else
	{
		return;
	}
}
// close window prompt
function winClose()
{
	if(confirm('Are you sure you want to close the example?\nIf you chose to close it, you can re-open it by rehreshing the page.'))
		{
			document.getElementById('RadDockableObject1').style.display = 'none'; // hide output window
			document.getElementById('RadDockableObject2').style.display = 'none'; // hide toolbox
			document.getElementById('ideTbl').style.display = 'none'; // hide editor
		}
	else
	{
			return true;	
	}
}
// Open build panel and simulate build
function buildSolution()
/*
Remote function call:
The default here is 'simulateError()', but you can use also 'simulateBuild();' with 
the same syntax line - document.frames('ifrOutput').functionName();
Available simulations:
	- simulateError(); - simulates vs.net compilation error - more interesting
	- simulateBuild(); - simulates successful vs.net compilation - less interesting
*/
{
if(document.getElementById('editor').style.visibility == 'hidden')
{
	if(confirm('The compiler encountered an error: no project has been loaded.\n\nWould you like to load one now?'))
	{
		document.getElementById('editor').style.visibility = 'visible'; // shoe editor
		document.getElementById('editingAreaNavigation').style.visibility = 'visible'; // show tabstrip
		document.getElementById('comboBoxesTr').style.visibility = 'visible'; // show combo boxes
		document.getElementById('RadDockableObject1').style.display = 'block'; // show output
		document.getElementById('tabstripEditor').style.display = 'block'; // show tabs
		window.frames['ifrOutput'].simulateError(); // start compilation
		toolbarBtnsApp1(); 
	}
}
else 
{
	if(document.getElementById('RadDockableObject1').style.display == 'block') // check if panel is open
	{
		window.frames['ifrOutput'].simulateError();
		toolbarBtnsApp1(); // set active state of the responding toolbar button
	}
	else
	{	
		document.getElementById('RadDockableObject1').style.display = 'block'; // check if panel is closed
		window.frames['ifrOutput'].simulateError(); // remote buildSolution() function call
		toolbarBtnsApp1();
	}
	}
}
// Toggle panel toolbar button appearance for output panel - active / normal
function toolbarBtnsApp1()
{
	if(document.getElementById('RadDockableObject1').style.display == 'block') // check if panel is open
	{
		window.toolbarTop.ToggleONButton('output');
	}
	else // if panel is closed
	{
		window.toolbarTop.ToggleOFFButton('output');
	}
}
// Toggle panel toolbar button appearance for toolbox panel - active / normal
function toolbarBtnsApp2()
{
	if(document.getElementById('RadDockableObject2').style.display == 'block') // check if panel is open
	{
		window.toolbarTop.ToggleONButton('toolbox');
	}
	else // if panel is closed
	{
		window.toolbarTop.ToggleOFFButton('toolbox');
	}
}
// toggle panels visible / hidden
function toggleDocks(dockID)
{
if(document.getElementById('editor').style.visibility == 'hidden') {
		if(confirm('Could not open the output and toolbox windows, because no project has been loaded.\nWould you like to load one now and then open the selected tool ('+ dockID +')?'))
		{
			document.getElementById('editor').style.visibility = 'visible';
			document.getElementById('editingAreaNavigation').style.visibility = 'visible';
			document.getElementById('comboBoxesTr').style.visibility = 'visible';
			document.getElementById(dockID).style.display = 'block';
			document.getElementById('tabstripEditor').style.display = 'block'; // show tabs
		}
		else
		{
			return;
		}
}
else {
		if(document.getElementById(dockID).style.display == 'none') // check if panel is visible
		{
			document.getElementById(dockID).style.display = 'block'; 
		}
		else // if panel is not hidden
		{
			document.getElementById(dockID).style.display = 'none';
		}
	}
}

// toggle word wrap - enable / disable
function toggleWordWrap()
{
	if(document.getElementById('editor').style.whiteSpace == 'normal') // check if word wrap is enabled
	{
		document.getElementById('editor').style.whiteSpace = 'nowrap';
	}
	else // check if it is disabled
	{
		document.getElementById('editor').style.whiteSpace = 'normal';
	}
}
// 3-state (normal, over and clicked) close button - creates 3D illusion onmouseover and onmouseout using css border properties
function btnOver() // onmouseover
{
	document.getElementById('close').style.borderTop = 'solid 1px #d4d0c8'; // top border
	document.getElementById('close').style.borderRight = 'solid 1px #000000'; // right border
	document.getElementById('close').style.borderBottom = 'solid 1px #000000'; // bottom border
	document.getElementById('close').style.borderLeft = 'solid 1px #d4d0c8'; // left border
}
function btnOut() // onmouseout / normal state
{
	document.getElementById('close').style.borderTop = 'solid 1px #f7f3e9'; // top border
	document.getElementById('close').style.borderRight = 'solid 1px #f7f3e9'; // right border
	document.getElementById('close').style.borderBottom = 'solid 1px #f7f3e9'; // bottom border
	document.getElementById('close').style.borderLeft = 'solid 1px #f7f3e9'; // left border
}
function btnClick() // onclick
{
	document.getElementById('close').style.borderTop = 'solid 1px #000000'; // top border
	document.getElementById('close').style.borderRight = 'solid 1px #f7f3e9'; // right border
	document.getElementById('close').style.borderBottom = 'solid 1px #f7f3e9'; // bottom border
	document.getElementById('close').style.borderLeft = 'solid 1px #000000'; // left border
}
// close document prompt
function closeDoc()
{
// the default editor title bar (without open files)
var defaultIDETitleBar = '<div style="float: left;"><img src="IdeImages/VsNetIcon.gif" height="18" width="18" alt="" style="vertical-align: middle;">Microsoft Development Environment</div><div class="winCmdButtons"><img src="IdeImages/windowMinimizeDisabled.gif" width="16" height="14" alt="" /><img src="IdeImages/windowMaximizeDisabled.gif" width="16" height="14" alt="" /><img src="IdeImages/windowClose.gif" width="16" height="14" hspace="2" alt="Close" onclick="winClose()" /></div>'
	if(confirm('Are you sure you want to close the current project?')) // ask for save
		{
		document.getElementById('editor').style.visibility = 'hidden'; // hide editing area
		document.getElementById('editingAreaNavigation').style.visibility = 'hidden'; // hide open documents tabstrip
		document.getElementById('comboBoxesTr').style.visibility = 'hidden'; // hide comboboxes
		document.getElementById('RadDockableObject1').style.display = 'none'; // hide ouput r.a.d. dock
		document.getElementById('RadDockableObject2').style.display = 'none'; // hide toolbox r.a.d. dock
		document.getElementById('tabstripEditor').style.display = 'none'; // hide tabstrip
		document.getElementById('editorTitleBar').innerHTML = defaultIDETitleBar; // set default editor titlebar text
		toolbarBtnsApp1(); // toggle otput toolbar button - active / inactive
		toolbarBtnsApp2(); // toggle toolbox toolbar button - active / inactive
		}
	else
	{
		return; // stop propagating the close function
	}
}
/* deprecated vs.net IDE functions in the QSF version start: */
// Preview Webpage - not handled in the qsf version - opens a new window, takes the innerText value of div#editor and using the document.write method generates preview of the edited page. Works with IE only. Mozilla 3refuzes to run code, Opera behaves oddly
function preview()
{
	fPreview=window.open('','_blank','width="800, height=600, top=100, left=180, scrollbars=1, toolbar=0, menubar=1"'); // create window
	fPreview.document.write(document.getElementById('editor').innerText); // render html code form div#editor
}
// Open New Document - not handled in the QSF version - replaces the default open document (div#editor innerHTML) with the following basic html tags string. no syntaxt highlighting implemented
function newDoc()
{
// New html page basic HTML code string template - not handled in the QSF version
newPage = [
	'<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" \n'+
    '"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">\n'+
	'<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">\n'+
	'<head>\n'+
	'\t<title></title>\n'+
	'</head>\n'+
	'<body>\n\n'+
	'</body>\n'+
	'</html>'
]
	document.getElementById('fileName').innerHTML = 'HTMLPage1'; // set title of the page to tab
	document.getElementById('editor').innerText = newPage; // add the new page code string to the div#editor
	document.getElementById('editor').style.visibility = 'visible'; // set div#editor to visible
	document.getElementById('editingAreaNavigation').style.visibility = 'visible'; // set div#editingAreaNavigation to visible
	document.getElementById('comboBoxesTr').style.visibility = 'visible'; // show comboboxes
	document.getElementById('tabstripEditor').style.display = 'block'; // show tabs
}
//r.a.d.toolbar handler functions

function ToolbarClickHandler(sender, e)
{
    switch (sender.CommandName)
    {
		case "new":
			newDocument();
		break;
		case "output":
			 toggleDocks('RadDockableObject1');
			 toolbarBtnsApp1();
		break;
		case "build":
			buildSolution();
		break;
		case "toolbox":
			toggleDocks('RadDockableObject2');
			toolbarBtnsApp2();
		break;
		case "wordwrap":
			toggleWordWrap();
		break;
		default:
		break;
    }
}
function ToolbarMouseOverHandler(sender, e)
{
    switch (sender.CommandName)
    {
		case "new":
			statBarHelp('New Project (F5)');
		break;
		case "output":
			statBarHelp('Toggle Output Window');
		break;
		case "build":
			statBarHelp('Build');
		break;
		case "toolbox":
			statBarHelp('Toggle Toolbox');
		break;
		case "wordwrap":
			statBarHelp('Toglle Wordwrap');
		break;
		default:
		break;
    }
}
function ToolbarMouseOutHandler(sender, e)
{
    switch (sender.CommandName)
    {
		case "new":
		case "output":
		case "build":
		case "toolbox":
		case "wordwrap":
			statBarHelp('Ready');
		break;
		default:
		break;
    }
}
/* deprecated vs.net IDE functions in the QSF version end: */
/* Sept 01, 2005 */