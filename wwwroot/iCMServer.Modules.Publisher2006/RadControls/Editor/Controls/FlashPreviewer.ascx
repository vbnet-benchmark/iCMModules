<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FlashPreviewer.ascx.cs" Inherits="Telerik.WebControls.EditorControls.FlashPreviewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="telerik" NameSpace="Telerik.WebControls.Dialogs" Assembly="RadEditor" %>
<table cellpadding="0" cellspacing="0">
	<tr>
		<td height="23" class="label">
			<input type="checkbox" onclick="javascript:SwitchPreviewMode();">
			<script>localization.showText("SwitchToPreviewMode");</script>
		</td>
	</tr>
	<tr>
		<td>
			<div class="PreviewAreaHolder">
				<div id="PropertiesPane">
					<table cellpadding="0" cellspacing="0" align="left">
						<tr>
							<td colspan="2" valign="top">
								<span id="loader" style="display:none"></span>
							</td>
						</tr>
						<tr>
							<td nowrap class="label" id="SpecifyClassIDCell">
								<script>
									localization.showText('SpecifyClassID');
									localization.setAttribute("SpecifyClassIDCell", "title", "NoteClassID");
								</script>
							</td>
							<td>
								<input type="checkbox" defaultvalue="false" id="classYes" onclick="enableClass(this.checked)" />
							</td>
						</tr>
						<tr id="classIDRow1" style="display:none">
							<td class="label" nowrap>
								<script>localization.showText('ClassID');</script>
							</td>
							<td>
								<input type="text" defaultvalue="" id="classID" class="RadETextBox" disabled />
							</td>
						</tr>
						<tr id="classIDRow2" style="display:none">
							<td class="label">
								<script>localization.showText('FlashVersion');</script>
							</td>
							<td>
								<select defaultvalue="5" class="DropDown" id="version" disabled>
									<option value="5">5.0</option>
									<option value="6">6.0</option>
								</select>
							</td>
						</tr>

						<tr>
							<td  class="label">
								<script>localization.showText('Width');</script>
							</td>
							<td>
								<input type="text" id="flashWidth" style="width:110px" defaultvalue="150" class="RadETextBox" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('Height');</script>
							</td>
							<td>
								<input type="text" id="flashHeight" style="width:110px" defaultvalue="150" class="RadETextBox" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('Quality');</script>
							</td>
							<td>
								<select id="quality" class="DropDown" defaultvalue="high">
									<option value="high">
										<script>localization.showText('High');</script>
									</option>
									<option value="medium">
										<script>localization.showText('Medium');</script>
									</option>
									<option value="low">
										<script>localization.showText('Low');</script>
									</option>
								</select>
							</td>
						</tr>
						<tr>
							<td class="label">
								<script>localization.showText('Play');</script>
							</td>
							<td >
								<input type="checkbox" checked="true" defaultvalue="true" id="playYes" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('Loop');</script>
							</td>
							<td >
								<input type="checkbox" defaultvalue="false" id="loopYes" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('FlashMenu');</script>
							</td>
							<td >
								<input type="checkbox" defaultvalue="false" id="menuYes" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('Transparent');</script>
							</td>
							<td >
								<input type="checkbox" defaultvalue="false" id="transparentYes" />
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('HTMLAlign');</script>
							</td>
							<td>
								<select id="htmlAlign" defaultvalue="baseline" class="DropDown">
									<option value="baseline">
										<script>localization.showText('Baseline');</script>
									</option>
									<option value="bottom">
										<script>localization.showText('Bottom');</script>
									</option>
									<option value="left">
										<script>localization.showText('Left');</script>
									</option>
									<option value="middle">
										<script>localization.showText('Middle');</script>
									</option>
									<option value="right">
										<script>localization.showText('Right');</script>
									</option>
									<option value="texttop">
										<script>localization.showText('TextTop');</script>
									</option>
									<option value="top">
										<script>localization.showText('Top');</script>
									</option>
								</select>
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('FlashAlign');</script>
							</td>
							<td>
								<select defaultvalue="LT" class="DropDown" id="flashAlign">
									<option value="LT">
										<script>localization.showText('LeftTop');</script>
									</option>
									<option value="LC">
										<script>localization.showText('LeftCenter');</script>
									</option>
									<option value="LB">
										<script>localization.showText('LeftBottom');</script>
									</option>
									<option value="RT">
										<script>localization.showText('RightTop');</script>
									</option>
									<option value="RC">
										<script>localization.showText('RightCenter');</script>
									</option>
									<option value="RB">
										<script>localization.showText('RightBottom');</script>
									</option>
									<option value="CT">
										<script>localization.showText('CenterTop');</script>
									</option>
									<option value="CC">
										<script>localization.showText('CenterCenter');</script>
									</option>
									<option value="CB">
										<script>localization.showText('CenterBottom');</script>
									</option>
								</select>
							</td>
						</tr>
						<tr>
							<td  class="label">
								<script>localization.showText('BackgroundColor');</script>
							</td>
							<td>
								<select defaultvalue="" class="DropDown" id="backgroundColor" onchange="changeColor(this, '_______', 9)">
									<option value="">
										<script>localization.showText('NoColor');</script>
									</option>
									<option value="#000000" style="background-color:#000000">
										<script>localization.showText('Black');</script>
									</option>
									<option value="#0000FF" style="background-color:#0000FF">
										<script>localization.showText('Blue');</script>
									</option>
									<option value="#008000" style="background-color:#008000">
										<script>localization.showText('Green');</script>
									</option>
									<option value="#FFA500" style="background-color:#FFA500">
										<script>localization.showText('Orange');</script>
									</option>
									<option value="#FF0000" style="background-color:#FF0000">
										<script>localization.showText('Red');</script>
									</option>
									<option value="#FFFFFF" style="background-color:#FFFFFF">
										<script>localization.showText('White');</script>
									</option>
									<option value="#FFFF00" style="background-color:#FFFF00">
										<script>localization.showText('Yellow');</script>
									</option>
									<option value="_______">
										<script>localization.showText('Custom');</script>
									</option>
								</select>
								<object id="dlgHelper" CLASSID="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px" height="0px" VIEWASTEXT></object>
							</td>
						</tr>
					</table>
				</div>
				<div id="PreviewPane">
					<table border="0" cellpadding="0" cellspacing="0" align="center" height="100%">
						<tr>
							<td id="PreviewObjectHolder"></td>
						</tr>
					</table>
				</div>
				<div id="EmptyPane">
					<table cellpadding="0" cellspacing="0" align="center" height="100%">
						<tr>
							<td></td>
						</tr>
					</table>
				</div>
			</div>
		</td>
	</tr>
</table>