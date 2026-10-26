<%@ Control Inherits="Telerik.WebControls.EditorDialogControls.BaseDialogControl"%>
<table cellspacing="0" cellpadding="2" border="1" bordercolor="#000000" style="font:normal 10px Arial">
	<tr>
		<td colspan="3" align="middle"><strong>GENERAL KNÖPFE</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonDesign.gif"></td>
		<td>Entwurfknopf - Schaltet r.a.d.editor in Entwurfmodus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonHtml.gif"></td>
		<td>HTML Knopf - Schaltet r.a.d.editor in HTML Modus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonPreview.gif"></td>
		<td>Vorschauknopf - Schaltet r.a.d.editor in Vorschaumodus.</td>
		<td>-</td>
	</tr>
	
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToUpper.gif"></td>
		<td>Das Werkzeug verwandelt den Text von der jetzigen Auswahl zu Großbuchstaben. Es bewahrt die Elemente wie Bildnisse und Tische (Elemente, die keine Textelemente sind).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToLower.gif"></td>
		<td>Das Werkzeug verwandelt den Text von der jetzigen Auswahl zu Kleinbuchstaben. Es bewahrt Elemente wie Bildnisse und Tische (Elemente, die keine Textelemente sind).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>Das Werkzeug erlaubt, dass die Verbraucher Bildnissekarten durch Schleppen über den Bildnissen schaffen, und schafft dann Gebiete mit verschiedenen Gestalten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Dropdown, der den Verbraucher erlaubt, Schriftartgröße zur jetzigen Auswahl zu verwenden. Der Schriftartgröße ist in Bildpunkten gemessen. Der Schriftartgröße ist nicht gesetzt wie im FontSize Werkzeug (1 zu 7).</td>
		<td>-</td>
	</tr>
	
	
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleScreenMode.gif"></td>
		<td>Umschaltschirmmodus - Schaltet r.a.d.editor in Vollbildmodus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleTableBorder.gif"></td>
		<td>Zeige/Verstecke Rahmen - Zeigen/Verstecken Sie Rahmen um Tische im Inhaltgebiet.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ModuleManager.gif"></td>
		<td>Modulmanager - Aktiviert /Deaktiviert Moduln von einem drop-down Liste verfügbarer Moduln.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleDocking.gif"></td>
		<td>Schalten Sie Docken um - Dockt alle schwebenden Werkzeugleisten zu ihren jeweiligen dockenden Gebieten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/RepeatLastCommand.gif"></td>
		<td>Wiederholen Sie Letzten Befehl - Eine Abkürzung, um die letzte Handlung zu wiederholen. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FindAndReplace.gif"></td>
		<td>Suchen uns Ersetzen - findet und ersetzt Text im Editor.</td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Print.gif"></td>
		<td>Druck-Knopf - druckt den Inhalt des r.a.d.editors oder der gesamten 
			Internetseite.</td>
		<td>Ctrl+P</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Spellcheck.gif"></td>
		<td>Rechtschreibung - startet den Assistenten für die Rechtschreibung.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Cut.gif"></td>
		<td>Ausschneide-Knopf - schneidet den markierten Bereich aus und kopiert ihn in die 
			Zwischenablage.</td>
		<td>Ctrl+X</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Copy.gif"></td>
		<td>Kopier-Knopf - kopiert den markierten Bereich in die Zwischenablage.</td>
		<td>Ctrl+C</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Paste.gif"></td>
		<td>Einfügen-Knopf - fügt den Inhalt der Zwischenablage in den Editor ein.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PastePlaintext.gif"></td>
		<td>Fugen Sie Standardtext ein Knopf - Fugt Standardtext (keine Formatierung) in den r.a.d.editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PasteFromWord.gif"></td>
		<td>Fugen Sie von Word ein Knopf  - Fugt Inhalt Ein, der von Wort  kopiert wurde und nimmt heraus das Gewebe unfreundliche. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PasteAsHtml.gif"></td>
		<td>Fügen Sie als HTML Knopf - Fügt HTML Code im Inhaltgebiet ein und behält alle HTML Tagen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Undo.gif"></td>
		<td>Rückgängig-Knopf - macht den letzten Arbeitsschritt rückgängig.</td>
		<td>Ctrl+Z</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Redo.gif"></td>
		<td>Wiederholen-Knop - wiederholt den letzten Schritt, der rückgängig gemacht 
			wurde.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Sweeper.gif"></td>
		<td>Formatierungs-Knopf - entfernt alle Formatierungen (auch benutzerdefinierte) 
			aus dem Text.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Help.gif"></td>
		<td>Direkthilfe - der Bildschirm den Sie gerade betrachten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/AboutDialog.gif"></td>
		<td>About Dialog - Zeigt die jetzige Version und die Befähigungsunterlagen von r.a.d.editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>Tabellen, Links, Sonderzeichen, Bilder und 
				Medien einfügen und verwalten</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageManager.gif"></td>
		<td>Bild einfügen - fügt ein Bild aus einem vordefinierten Verzeichnis ein.</td>
		<td>Ctrl+G</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>Bildniskarte - Erlaubt, dass Verbraucher anklickbare Gebiete innerhalb Bildnis definieren.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/AbsolutePosition.gif"></td>
		<td>Absolute Position - legt ie absolute Position eines Objektes fest (frei 
			beweglich).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertTable.gif"></td>
		<td>Tabelle einfügen - fügt eine Tabelle in den r.a.d.editor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleBorders.gif"></td>
		<td>Toggle Table Borders - Toggles borders of all tables within the editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertSnippet.gif"></td>
		<td>Code Elemente einfügen - fügt vorgefertigte Code Elemente ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertFormElement.gif"></td>
		<td>Fugen Sie Formelement ein - Fugt ein Formelement von einem Droop Down Liste mit verfugbaren Elementen Ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertDate.gif"></td>
		<td>Fügen Sie Datum Knopf ein - Fügt jetziges Datum Ein. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertTime.gif"></td>
		<td>Fügen Sie Zeit der Knopf ein - Fügt jetzige Zeit Ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FlashManager.gif"></td>
		<td>Flash einfügen - fügt eine Flash-Animation ein und läßt sie ihre Eigenschaften 
			verändern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/MediaManager.gif"></td>
		<td>Windows Media einfügen - fügt ein Windows Media Objekt (AVI, MPEG, WAV, etc.) 
			ein und läßt sie die Eigenschaften ändern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/DocumentManager.gif"></td>
		<td>Dokument einfügen - fügt ein Dokument in den Editor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Link erstellen - Macht aus dem ausgewählten Text, Nummer oder Bild einen 
			Hyperlink.</td>
		<td>Ctrl+K</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Unlink.gif"></td>
		<td>Link entfernen - entfernt einen Link aus dem gewählten Text, Nummer oder Bild.</td>
		<td>Ctrl+Shift+K</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Symbols.gif"></td>
		<td>Sonderzeichen einfügen - fügt Sonderzeichen ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Benutzerdefinierten Link hinzufügen - fügt einen internen oder externen Link 
			aus einer vorgefertigten Liste hinzu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/TemplateManager.gif"></td>
		<td>Wählen Sie HTML Modellrahmen - Verwendet einen HTML Modellrahmen von einer vordefinierten Liste der Modellrahmen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ERSTELLEN, FORMATIEREN UND BEARBEITEN von 
				ZEICHEN UND LINIEN</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertParagraph.gif"></td>
		<td>Neues Zeichen einfügen - fügt ein neues Zeichen ein.</td>
		<td>
			Ctrl+M<br>
			Ctrl+Enter
		</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Paragraph.gif"></td>
		<td>Standard-Zeichen Auswahlfeld - fügt Standard-Eigenschaften zu dem ausgwählten 
			Text zu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Outdent.gif"></td>
		<td>Links Ausrichten - richtet Zeichen links aus. (Indent?)</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Indent.gif"></td>
		<td>Rechts ausrichten - richtet Zeichen recht aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertHorizontalRule.gif"></td>
		<td>Horizontale Linie (z.B. horizontale Regel?) - fügt eine horizontale Linie bei 
			dem Cursor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyLeft.gif"></td>
		<td>Links ausrichten - richtet die ausgewählten Zeichen links aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyCenter.gif"></td>
		<td>Mittig ausrichten - richtet die ausgewählten Zeichen in der Mitte aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyRight.gif"></td>
		<td>Rechts ausrichten - richtet die ausgewählten Zeichen rechts aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertOrderedList.gif"></td>
		<td>Numerierte Liste - erstellt aus der Markierung eine numerierte Liste.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertUnorderedList.gif"></td>
		<td>Aufzählungszeichen - erstellt aus der Markierung eine Liste mit 
			Auszählungszeichen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ERSTELLEN, FORMATIEREN UND BEARBEITEN von TEXT, 
				SCHRIFTART und LISTEN</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Bold.gif"></td>
		<td>Fett - formatiert den markierten Text fett.</td>
		<td>Ctrl+B</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Italic.gif"></td>
		<td>Kursiv - formatiert den markierten Text kursiv.</td>
		<td>Ctrl+I</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Underline.gif"></td>
		<td>Unterstrichen - unterstreicht den markierten Text.</td>
		<td>Ctrl+U</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Superscript.gif"></td>
		<td>Hochgestellt - formatiert Text oder Nummern als hochgestellt.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Subscript.gif"></td>
		<td>Tiefgestellt - formatiert Text oder Nummern als tiefergestellt.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontName.gif"></td>
		<td>Schriftart - Schriftart wählen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Schriftgröße - Schriftgröße ändern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ForeColor.gif"></td>
		<td>Textfarbe (Vordergrund) - ändert die Vordergrundfarbe des ausgewählten Textes.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/BackColor.gif"></td>
		<td>Textfarbe (Hintergrundbild) - ändert die Hintergrundbild des ausgewählten Textes.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Class.gif"></td>
		<td>Benutzerdefinierte Formate - fügt benutzerdefinierte, vordefinierte 
			Formatierungen zum ausgewählten Text hinzu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ANDERE TASTENKOMBINATIONEN</strong></td>
	</tr>
	<tr>
		<td>-</td>
		<td>Markiert den gesamten Text, alle Bilder und Tabellen im Editor</td>
		<td>Ctrl+A</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Findet Text oder Zahlen im aktuellen Dokument.</td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Schließt das aktive Fenster.</td>
		<td>Ctrl+W</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Schließt die aktive Anwendung.</td>
		<td>Ctrl+F4</td>
	</tr>
</table>