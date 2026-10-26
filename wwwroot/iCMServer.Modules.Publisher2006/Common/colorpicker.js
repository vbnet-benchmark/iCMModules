var oPopup = window.createPopup();

function GetColorPickerSelectedColor(color){
   var div = document.getElementById(currentColorBox);
   if (div){
		div.style.backgroundColor = color;		
   }
   var hidden = document.getElementById(hiddenField);
   if (hidden ){     
     hidden.value = color;
   }   
   oPopup.hide();
}


var currentColorBox = "";
var hiddenField = "";

function ColorPickerShowBoxBorder(td,color){
	td.style.border="1px solid "+color;
}

function ColorPickerInvoke(invoker, controlID, hiddenID)
{
	if (!document.getElementById('ColorTable') )createColorTable();
	currentColorBox = controlID;        
	hiddenField = hiddenID;
    var oPopBody = oPopup.document.body;        
    oPopBody.style.border = "solid black 1px";
    oPopBody.innerHTML = document.getElementById('ColorTable').innerHTML;//    
    oPopup.show(0, 20, 105, 72, invoker);       
}


function createColorTable (){
	var div = document.createElement("DIV");
	div.id = "ColorTable";
	div.style.visibility = "hidden";
	document.body.appendChild(div);	
	var bgColor = "#F9F8F7";    
	var itemsPerRow = 6;
	var divArea = document.getElementById(div.id);	
	var colorsArray = new Array(
			"", "#ffff00","#00ff00","#add8e6","#008000","#808080",//"#ffdab9",
			"#ffd700","#ffe4e1","#00ffff","#87ceeb","#0000ff","#a9a9a9",
			"#ffa500","#ffc0cb","#a52a2a","#008080","#000080", "#c0c0c0",
			"#ff0000","#c71585","#8b0000","#4b0082","#000000","#ffffff");
		
	var curHTML ="<table id =\"CP_ColorsTable\" style='cursor: default;' bgcolor='" + bgColor + "' border=0 cellspacing=1 cellpadding=1>";
	var isFirst = true;
		for (i=1; i <= colorsArray.length; i++){
			i--;//! because of inner cycle
			curHTML += "<tr>";
		    for (j=0; j< itemsPerRow ; i++,j++){		    
				if (i< colorsArray.length){	    
					curHTML += "<td style='padding: 1px 1px 1px 1px; border: 1px solid "+ bgColor+"' "+ 
					" onmouseOver=\"parent.ColorPickerShowBoxBorder(this,'#666666')\" "+
					" onMouseOut=\"parent.ColorPickerShowBoxBorder(this,'"+ bgColor+"')\" "+
					" onClick=\"parent.GetColorPickerSelectedColor('"+ colorsArray[i]+"')\" "+
					">";
					if (isFirst){
						curHTML += "<span style='background-image: url(Common/x.gif); background-repeat: no-repeat; background-position : center; border:1px solid #808080; height:12px; width:12px; font-size: 5pt'>&nbsp;&nbsp;&nbsp;&nbsp;</span>";
						isFirst = false;					
					} else {
						curHTML += "<span style='background-color:"+ colorsArray[i]+"; border:1px solid #808080; height:12px; width:12px; font-size: 5pt'>&nbsp;&nbsp;&nbsp;&nbsp;</span>";
					}
					curHTML +="</td>";	
				}
		    }
		    curHTML += "</tr>"
		}
		curHTML +="</table>";		
		divArea.innerHTML = curHTML;
}