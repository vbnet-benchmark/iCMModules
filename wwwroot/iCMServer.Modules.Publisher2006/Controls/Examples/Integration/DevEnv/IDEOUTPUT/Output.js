/* 
External javascript file for 
r.a.d.dock visual studio .net toolbox window example
- Please, refer to Styles.css for id's and classes for the objects;
- Please, refer to the bottom of this file for default pageload action (successful or unsuccessful build).
*/
// Simulate successful build
// Original vs.net compiler message strings on successful build
var line0 = '<br /><br /><br />Microsoft Visual Studio .Net<br />version 7.1.3088<br />Microsoft .Net Framework 1.1.4322 SP1';
var line1 = 'Updating references...<br />';
var line2 = 'Performing main compilation...<br /><br />';
var line3 = 'Build complete ';
var line4 = '-- 0 errors, 0 warnings<br />';
var line5 = 'Building satelite assemblies...';
var line6 = '<br /><br /><br />----- Done -----';
var line7 = '<br /><br />Rebuild All:<br />10 succeeded, 0 failed, 0 skipped<br /><br />----------------';
function simulateBuild()
{
	document.getElementById('outputCombo').disabled = true; // disable combo box while "compiling"
	setTimeout("document.getElementById('output').innerHTML = ''", 100); // clear div#output
	setTimeout("document.getElementById('output').innerHTML += line1" && "parent.document.getElementById('statBarInfo').innerHTML = 'Build started...'", 1000); // clear div#output and update statusbar
	setTimeout("document.getElementById('output').innerHTML += line2" && "parent.document.getElementById('statBarInfo').innerHTML = 'Performing main compilation...'", 2000);
	setTimeout("document.getElementById('output').innerHTML += line3", 3000);
	setTimeout("document.getElementById('output').innerHTML += line4", 4000);
	setTimeout("document.getElementById('output').innerHTML += line5", 5000);
	setTimeout("document.getElementById('output').innerHTML += line6", 6000);
	setTimeout("document.getElementById('output').innerHTML += line7", 7000);
	setTimeout("document.getElementById('output').innerHTML += line0", 8000);
	setTimeout("document.getElementById('outputCombo').disabled = false", 9000); // enable combo box after "successful build"
	setTimeout("parent.document.getElementById('statBarInfo').innerHTML = 'Build succeeded'", 10000); // update statusbar
}
// Simulate unsuccessful build
// Draw table header [do not edit, if you want to keep the original vs.net layout]
var err1 = [
	'<div class="errContainer">' +
	'<div class="errHeader" id="0">' +
	'<div class="errHeaderRow" style="width: 2%;" unselectable="on">!</div>' +
	'<div class="errHeaderRow" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errHeaderRow" style="width: 3%" unselectable="on"><input type="checkbox" id="chkBox" checked="checked" /></div>' +
	'<div class="errHeaderRow" style="width: 45%; text-align: left;" unselectable="on">&nbsp;Description</div>' +
	'<div class="errHeaderRow" style="width: 40%; text-align: left;" unselectable="on">&nbsp;File</div>' +
	'<div class="errHeaderRow" style="width: 5%; text-align: left;" unselectable="on">&nbsp;Line</div>' +
	'</div>' +
	'<div class="errLinesContainer" id="1" onclick="highlight(1);removeHighlight(2);removeHighlight(3);removeHighlight(4);removeHighlight(5);">' +
	'<div class="errLines" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 3%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 45%; text-align: left; color: #808080;" unselectable="on">&nbsp;Click here to add new task</div>' +
	'<div class="errLines" style="width: 40%; text-align: left;">&nbsp;</div>' +
	'<div class="errLines" style="width: 5%; text-align: left;">&nbsp;</div>' +
	'</div>'
]
// error line 1 [editable]
var err2 = [
	'<div class="errLinesContainer" id="2" onclick="highlight(2);removeHighlight(4);removeHighlight(3);removeHighlight(5);removeHighlight(1);" ondblclick="alert(\'Compiler Output:\\n\\n\' + this.innerText + \'\\n\\nDo you wish to debug?\')">' +
	'<div class="errLines" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 2%;" unselectable="on"><img src="VSNetOutput/Images/build.gif" alt="" height="15" width="15" /></div>' +
	'<div class="errLines" style="width: 3%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 45%; text-align: left;" unselectable="on">&nbsp;\'mySite.Common.VersionData\' is obsolete</div>' +
	'<div class="errLines" style="width: 40%; text-align: left;" unselectable="on">&nbsp;C:\\MyWebs\\Websites\\mySite\\Private\\loginFrm.ascx</div>' +
	'<div class="errLines" style="width: 5%; text-align: left;" unselectable="on">&nbsp;55</div>' +
	'</div>'
]
// error line 2 [editable]
var err3 = [
	'<div class="errLinesContainer" onclick="highlight(3);removeHighlight(5);removeHighlight(4);removeHighlight(2);removeHighlight(1);" ondblclick="alert(\'Compiler Output:\\n\\n\' + this.innerText + \'\\n\\nDo you wish to debug?\')" id="3">' +
	'<div class="errLines" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 2%;" unselectable="on"><img src="VSNetOutput/Images/wave.gif" alt="" height="14" width="8" /></div>' +
	'<div class="errLines" style="width: 3%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 45%; text-align: left;" unselectable="on">&nbsp;Could not find any atribute \'class\' of element \'LinkButton\'</div>' +
	'<div class="errLines" style="width: 40%; text-align: left;" unselectable="on">&nbsp;C:\\MyWebs\\Websites\\mySite\\Private\\profile.ascx</div>' +
	'<div class="errLines" style="width: 5%; text-align: left;" unselectable="on">&nbsp;98</div>' +
	'</div>'
]
// error line 3 [editable]
var err4 = [
	'<div class="errLinesContainer" onclick="highlight(4);removeHighlight(5);removeHighlight(3);removeHighlight(2);removeHighlight(1);" ondblclick="alert(\'Compiler Output:\\n\\n\' + this.innerText + \'\\n\\nDo you wish to debug?\')" id="4">' +
	'<div class="errLines" style="width: 2%;" unselectable="on"><img src="VSNetOutput/Images/exclamation.gif" alt="" height="14" width="13" /></div>' +
	'<div class="errLines" style="width: 2%;" unselectable="on"><img src="VSNetOutput/Images/app.gif" alt="" height="14" width="13" /></div>' +
	'<div class="errLines" style="width: 3%;" unselectable="on"><input type="checkbox" class="chkBox" checked="checked" /></div>' +
	'<div class="errLines" style="width: 45%; text-align: left;" unselectable="on">&nbsp;File ot assembly name DataAccess, or one of its dependencies, was not found</div>' +
	'<div class="errLines" style="width: 40%; text-align: left;" unselectable="on">&nbsp;C:\\MyWebs\\Websites\\mySite\\Private\\profile.ascx.cs</div>' +
	'<div class="errLines" style="width: 5%; text-align: left;" unselectable="on">&nbsp;101</div>' +
	'</div>'
]
// error line 4 [editable]
var err5 = [
	'<div class="errLinesContainer" onclick="highlight(5);removeHighlight(4);removeHighlight(3);removeHighlight(2);removeHighlight(1);" ondblclick="alert(\'Compiler Output:\\n\\n\' + this.innerText + \'\\n\\nDo you wish to debug?\')" id="5">' +
	'<div class="errLines" style="width: 2%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 2%;" unselectable="on"><img src="VSNetOutput/Images/wave.gif" alt="" height="14" width="8" /></div>' +
	'<div class="errLines" style="width: 3%;" unselectable="on"></div>' +
	'<div class="errLines" style="width: 45%; text-align: left;" unselectable="on">&nbsp;Per the active schema, the element \'asp:checkbox\' cannot be nested within \'asp:linkbutton\'</div>' +
	'<div class="errLines" style="width: 40%; text-align: left;" unselectable="on">&nbsp;C:\\MyWebs\\Websites\\mySite\\Private\\editProfile.ascx</div>' +
	'<div class="errLines" style="width: 5%; text-align: left;" unselectable="on">&nbsp;193</div>' +
	'</div>'
]
// Simulate build error - animate table cells
function simulateError()
{	
	document.getElementById('outputCombo').disabled = true; // Disable combo box while "generating error"
	document.getElementById('output').innerHTML = ''; // clear div#output
	setTimeout("document.getElementById('output').innerHTML = ''" && "parent.document.getElementById('statBarInfo').innerHTML = 'Build started...'", 100);	// clear output div and update status bar
	setTimeout("document.getElementById('output').innerHTML += err1", 100);	
	setTimeout("document.getElementById('output').innerHTML += err2", 1000);
	setTimeout("document.getElementById('output').innerHTML += err3", 2000);
	setTimeout("document.getElementById('output').innerHTML += err4", 3000);
	setTimeout("document.getElementById('output').innerHTML += err5", 4000);	
	setTimeout("document.getElementById('output').innerHTML += line0", 5000);
	setTimeout("document.getElementById('outputCombo').disabled = false", 6000); // Enable combo box after "generating error"
	setTimeout("parent.document.getElementById('statBarInfo').innerHTML = 'Build failed'", 7000); // update statusbar
}
// Highlight divs onclick
function highlight(divId) {
	document.getElementById(divId).style.backgroundColor = 'highlight'; // Background color (darkBlue)
	document.getElementById(divId).style.color = 'white'; // Font color (#ffffff)
}
// Remove div highlighting onclick
function removeHighlight(divIdM)
{
	document.getElementById(divIdM).style.backgroundColor = 'white'; // Background color (#ffffff)
	document.getElementById(divIdM).style.color = 'black'; // Font color (#000000)
}
/*
Uncomment the default onload build action.
By default, no build action is specified, but you can use
ONE of the listed below:
*/
// window.onload = simulateError;
// window.onload = simulateBuild;