<%@ Control Inherits="Telerik.WebControls.EditorDialogControls.BaseDialogControl"%>
<table cellspacing="0" cellpadding="2" border="1" bordercolor="#000000" style="font:normal 10px Arial">
	<tr>
		<td colspan="3" align="middle"><strong>BOUTONS GENERALS</strong></td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Img/ButtonDesign.gif"></td>
		<td>Bouton Mode Design - changer r.a.d.<span>editor</span> dans le mode de design.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Img/ButtonHtml.gif"></td>
		<td>Bouton Mode HTML - changer r.a.d.editor dans le mode de HTML.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Img/ButtonPreview.gif"></td>
		<td>Bouton Mode Prévision - changer r.a.d.editor dans le mode de prévision.</td>
		<td>-</td>
	</tr>
	
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToUpper.gif"></td>
		<td>L'outil convertir le text selectionne en majuscule, en preservant les eluments non-text, tels que images, tableaux</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToLower.gif"></td>
		<td>L'outil convertir en minusckule le texte selectionne tels que images et tableaux.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>L'outil permet a l'utilisateur de creer des ima maps en 'dragging' sur les images et en creant des zone hyperlink de differentes formes.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Menu deroulant qui permet de l'utilisateur d'appliquer une nouvelle taille de la police en pixels, plutot qu'une taille fixe de 1 de 7 (comme le fait l'outil de taille de police).</td>
		<td>-</td>
	</tr>
	
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ToggleScreenMode.gif"></td>
		<td>Écran Mode Bascule - changer r.a.d.editor dans le mode de plein écran.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ToggleTableBorder.gif"></td>
		<td>Bouton Exposer/Chaser - exposer ou cache des frontières autour des tables dans le secteur content.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ModuleManager.gif"></td>
		<td>Bouton Directeur Module - active/termine d'une liste de modules disponibles.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ToggleDocking.gif"></td>
		<td>Bouton Termine L'amarrage - accouple tous les toolbars flottants à leurs secteurs d'amarrage respectifs.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/RepeatLastCommand.gif"></td>
		<td>Bouton Répétez - un raccourci pour répéter la dernière action a exécuté.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/FindAndReplace.gif"></td>
		<td>Bouton Trouvez/Remplacez - trouve (et remplace) le texte dans le secteur content du rédacteur.</td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Print.gif"></td>
		<td>Bouton Impression - copies le contenu du r.a.d.editor ou de la page Web entière.</td>
		<td>Ctrl+P</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Spellcheck.gif"></td>
		<td>Bouton Orthographique - lancements le correcteur orthographique.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Cut.gif"></td>
		<td>Bouton Couper - coupe la sélection et l'insère dans le presse papier.</td>
		<td>Ctrl+X</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Copy.gif"></td>
		<td>Bouton Copier - copie la sélection et l'insère dans le presse papier.</td>
		<td>Ctrl+C</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Paste.gif"></td>
		<td>Bouton Pâte - pâtes le contenu copié de la planchette dans le rédacteur.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/PastePlaintext.gif"></td>
		<td>Bouton Collez Plain - pâtes raffinent le texte (aucun formatage) dans le rédacteur.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/PasteFromWord.gif"></td>
		<td>Bouton Pâtes de Word - pâtes contenu du Word et enlève les étiquettes enchaînement-peu amicales.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/PasteAsHtml.gif"></td>
		<td>Bouton Pâten de HTML - collee le code de HTML dans le secteur content et garde toutes les étiquettes de HTML.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Undo.gif"></td>
		<td>Bouton Annuler - annuler les derniers changements.</td>
		<td>Ctrl+Z</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Redo.gif"></td>
		<td>Bouton Refaire - Réapplique les derniers changements annulés.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Sweeper.gif"></td>
		<td>Bouton Retrait Formatage - supprimer les balises de formatage du texte.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Help.gif"></td>
		<td>Bouton Aide Rapide - pour accéder à l'aide rapide (document actuel).</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/AboutDialog.gif"></td>
		<td>Bouton au Sujet de - montre la version en cours et les qualifications de r.a.d.editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" style="text-align: middle;"><strong>INSÉRER, MODIFIER ET GÉRER LES LIENS, 
			TABLEAUX, IMAGES MÉDIAS ET CARACTÈRES SPÉCIAUX </strong></td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ImageManager.gif"></td>
		<td>Bouton Directeur Image - insérer une image d'un répertoire pré-défini.</td>
		<td>Ctrl+G</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>Image map - Permet aux utilisateurs de définir des parties de l'image sur lesquelles on peut cliquer.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/AbsolutePosition.gif"></td>
		<td>Bouton Position Absolut - définir la position d'un objet</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertTable.gif"></td>
		<td>Bouton Tableau - insére un tableau dans l'éditeur.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ToggleBorders.gif"></td>
		<td>Bouton Permuter Borders - permute les bordures de tous les tableaux de l'éditeur.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertSnippet.gif"></td>
		<td>Bouton Code-Snipeer - insère un code-snipper prédéfini.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertFormElement.gif"></td>
		<td>Bouton Forme - insère un élément de forme d'une liste drop-down avec les éléments disponibles.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertDate.gif"></td>
		<td>Bouton Date - insère la date du jour.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertTime.gif"></td>
		<td>Bouton Temps - insère le temps courant.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/FlashManager.gif"></td>
		<td>Bouton Directeur Animantion - insère une animation Flash et permet de définir ses propriétés.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/MediaManager.gif"></td>
		<td>Bouton Directeur Média - insère un objet Windows Média (AVI, MPEG, WAV, etc.) et permet de définir ses propriétés.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/DocumentManager.gif"></td>
		<td>Bouton Directeur Document - insère un document (PDF, Word)dans l'éditeur.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Bouton Hyperlien - transforme le contenu sélectionné en hyperlien.</td>
		<td>Ctrl+K</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Unlink.gif"></td>
		<td>Bouton Retire Hyperlien - retire l'hyperlien du contenu sélectionné.</td>
		<td>Ctrl+Shift+K</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Symbols.gif"></td>
		<td>Bouton Caractères Spéciaux. - insère des caractères spéciaux.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Bouton Lien Predefini - insère un lien interne ou externe à partir d'une liste pré-définie.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/TemplateManager.gif"></td>
		<td>Bouton Calibre - s'applique et calibre de HTML à partir d'une liste prédéfinie de calibres.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" style="text-align: middle;"><strong style="font-weight: bold;">INSÉRER, MODIFIER ET
			FORMATER LES PARAGRAPHES </strong></td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertParagraph.gif"></td>
		<td>Bouton Insère - insère un nouveau paragraphe.</td>
		<td>Ctrl+M<br/>
			Ctrl+Enter</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Paragraph.gif"></td>
		<td>Bouton Style - applique le style standard au texte sélectionné.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Outdent.gif"></td>
		<td>Bouton déplace Gauche - déplace le paragraphe vers la gauche</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Indent.gif"></td>
		<td>Bouton Déplace Droite - déplace le paragraphe vers la droite</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/JustifyLeft.gif"></td>
		<td>Buoton Aligne Gauche- aligne le paragraphe sélectionné au gauche.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/JustifyCenter.gif"></td>
		<td>Buouton Aligne Centre- aligne le paragraphe sélectionné au centre.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/JustifyRight.gif"></td>
		<td>Bouton Aligne Driote - aligne le paragraphe sélectionné à droite</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/JustifyFull.gif"></td>
		<td>Bouton Justifie - justifie le paragraphe choisi.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertUnorderedList.gif"></td>
		<td>Bouton Puces - insère des puces à la sélection.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertOrderedList.gif"></td>
		<td>Bouton Numérotation - insère une numérotation à la sélection.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/InsertHorizontalRule.gif"></td>
		<td>Bouton Ligne - insère une ligne horizontale à l'emplacement du curseur.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" style="text-align: middle;"><strong>INSÉRER, MODIFIER ET 
			FORMATER LE TEXTE ET LES LISTES </strong></td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Bold.gif"></td>
		<td>Bouton Gras - applique un format gras à la sélection.</td>
		<td>Ctrl+B</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Italic.gif"></td>
		<td>Bouton Italic - applique un format italic à la sélection.</td>
		<td>Ctrl+I</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Underline.gif"></td>
		<td>Bouton Souligné - applique un format souligné à la sélection.</td>
		<td>Ctrl+U</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Superscript.gif"></td>
		<td>Bouton Exposant - applique un format exposant à la sélection.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Subscript.gif"></td>
		<td>Bouton Indice - applique un format indice à la sélection.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/FontName.gif"></td>
		<td>Bouton Police - sélection de la police de caractères.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Bouton Taille - sélection de la taille de la police.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/ForeColor.gif"></td>
		<td>Bouton Coleur - sélection de la couleur du texte.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/BackColor.gif"></td>
		<td>Bouton Fond - changer de la couleur de l'arrière plan du texte.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Class.gif"></td>
		<td>Bouton coutume - applique un style pré-défini au texte sélectionné.</td>
		<td>-</td>
	</tr>
	<tr>
		<td style="text-align: middle;"><img src="<%= this.SkinPath %>Buttons/Class.gif"></td>
		<td>Enlève Formatage - enlève le formatage du texte choisi ou entier.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" style="text-align: middle;"><strong>AUTRES RACCOURCIS DE CLAVIER</strong></td>
	</tr>
	<tr>
		<td>-</td>
		<td>Choisit tous les texte, images et tables dans le rédacteur.</td>
		<td>Ctrl+A</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Recherche dans la page </td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Fermer la fenêtre active. </td>
		<td>Ctrl+W</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Fermer l'application active.</td>
		<td>Ctrl+F4</td>
	</tr>
</table>