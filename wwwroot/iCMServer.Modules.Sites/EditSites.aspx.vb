
Imports System.web
Imports System.Collections
Imports System.data
Imports System.Web.UI.WebControls

Public Class EditSites
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblShowedit As System.Web.UI.WebControls.Label
    Protected WithEvents rbShowedit1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbShowedit2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblShowfooter As System.Web.UI.WebControls.Label
    Protected WithEvents rbShowfooter1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbShowfooter2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents txtFooterleft As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFootercontent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFooterright As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFooterleft As System.Web.UI.WebControls.Label
    Protected WithEvents lblFootercontent As System.Web.UI.WebControls.Label
    Protected WithEvents lblFooterright As System.Web.UI.WebControls.Label
    Protected WithEvents lblContentadjust As System.Web.UI.WebControls.Label
    Protected WithEvents ddContentadjust As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblSoftdelete As System.Web.UI.WebControls.Label
    Protected WithEvents rbSoftdelete1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbSoftdelete2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblColor As System.Web.UI.WebControls.Label
    Protected WithEvents bColor As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPicture As System.Web.UI.WebControls.Label
    Protected WithEvents imgPicture As System.Web.UI.WebControls.Image
    Protected WithEvents btnPicture As System.Web.UI.WebControls.Button
    Protected WithEvents lblMenualign As System.Web.UI.WebControls.Label
    Protected WithEvents rbMenualign1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenualign2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenualign3 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenualign4 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblMenufade As System.Web.UI.WebControls.Label
    Protected WithEvents rbMenufade1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenufade2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblMenufadetime As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenufadetime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenutop As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuleft As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenutop As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMenuleft As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenuforecolor1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenubackcolor1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuforecolor2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenubackcolor2 As System.Web.UI.WebControls.Label
    Protected WithEvents bColor2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMenufont As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenufont As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenuoverbackcolor2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuoverforecolor2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuoverbackcolor1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuoverforecolor1 As System.Web.UI.WebControls.Label
    Protected WithEvents bColor6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMenuplacement As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenubetween As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuwait As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenulevel1borderx As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenulevel1bordery As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenulevel2borderx As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenulevel2bordery As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenuplacement As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMenubetween As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rbMenulevel1borderx1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel1borderx2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel1bordery1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel1bordery2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel2borderx1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel2borderx2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel2bordery1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenulevel2bordery2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ddMenuwait As System.Web.UI.WebControls.DropDownList
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Protected WithEvents lblLanguage As System.Web.UI.WebControls.Label
    Protected WithEvents ddLanguage As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenubold1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuoverbold1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenubold2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuoverbold2 As System.Web.UI.WebControls.Label
    Protected WithEvents rbMenuBold1_1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuBold1_2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuOverBold1_1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuOverBold1_2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuBold2_1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuBold2_2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuOverBold2_1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuOverBold2_2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblMenuRoundBorder As System.Web.UI.WebControls.Label
    Protected WithEvents rbMenuRoundBorder1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbMenuRoundBorder2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblMenuOverFontSize2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuOverFontSize1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuFontSize2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuFontSize1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenuFontSize1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMenuOverFontSize1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMenuFontSize2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMenuOverFontSize2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenuBorderColor1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuBorderColor2 As System.Web.UI.WebControls.Label
    Protected WithEvents bColor10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLogohorizontalalign As System.Web.UI.WebControls.Label
    Protected WithEvents lblLogoverticalalign As System.Web.UI.WebControls.Label
    Protected WithEvents ddLogohorizontalalign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddLogoverticalalign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenuOffset As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenuOffset As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHeadFamily As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeadSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeadWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeadColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubHeadFamily As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubHeadSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubHeadWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubHeadColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubSubHeadFamily As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubSubHeadWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubSubHeadSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblNormalSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonFamily As System.Web.UI.WebControls.Label
    Protected WithEvents lblNormalFamily As System.Web.UI.WebControls.Label
    Protected WithEvents lblNormalColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblNormalWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubSubHeadColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonBackColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonForeColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonBorderSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblHrHeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblHrColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonTextAlign As System.Web.UI.WebControls.Label
    Protected WithEvents lblButtonBorderColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblHrAlign As System.Web.UI.WebControls.Label
    Protected WithEvents ddHeadFamily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddHeadSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddHeadWeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubHeadFamily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubHeadSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubHeadWeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubSubHeadFamily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubSubHeadSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddSubSubHeadWeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddNormalFamily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddNormalSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddNormalWeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddButtonFamily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddButtonSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddButtonWeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddButtonBorderSize As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddButtonTextAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddHrHeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddHrAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents bColor12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor14 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor15 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor16 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor17 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor18 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bColor19 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSiteHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblCssHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuStdHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMenuAdvHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnSiteUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnSiteOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnCssOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnCssUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuStdOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuStdUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuAdvOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuAdvUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblLogoHorizontalTiling As System.Web.UI.WebControls.Label
    Protected WithEvents lblLogoVerticalTiling As System.Web.UI.WebControls.Label
    Protected WithEvents rbLogoHorizontalTiling1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbLogoHorizontalTiling2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbLogoVerticalTiling1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbLogoVerticalTiling2 As System.Web.UI.WebControls.RadioButton
    Private ModId As Integer = 0
    Protected WithEvents btnMenuDefOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuDefUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblSiteWidth As System.Web.UI.WebControls.Label
    Protected WithEvents ddSiteWidth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblContainerWidth1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddContainerWidth1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblContainerWidth2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddContainerWidth2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblContainerWidth3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddContainerWidth3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMetaDescription As System.Web.UI.WebControls.Label
    Protected WithEvents lblMetaKeywords As System.Web.UI.WebControls.Label
    Protected WithEvents lblMetaAuthor As System.Web.UI.WebControls.Label
    Protected WithEvents lblMetaCopyright As System.Web.UI.WebControls.Label
    Protected WithEvents lblMetaRobots As System.Web.UI.WebControls.Label
    Protected WithEvents txtMetaDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMetaKeywords As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMetaAuthor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMetaCopyright As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMetaRobots As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSiteCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnCssCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuStdCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuAdvCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnMenuDefCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblSiteAlign As System.Web.UI.WebControls.Label
    Protected WithEvents ddSiteAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMenuMultiplicator As System.Web.UI.WebControls.Label
    Protected WithEvents ddMenuMultiplicator As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHeadMenuTextAlign As System.Web.UI.WebControls.Label
    Protected WithEvents ddHeadMenuTextAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHeadMenuWidth As System.Web.UI.WebControls.Label
    Protected WithEvents ddHeadMenuWidth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHeadMenuHeight As System.Web.UI.WebControls.Label
    Protected WithEvents ddHeadMenuHeight As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblSubMenuTextAlign As System.Web.UI.WebControls.Label
    Protected WithEvents ddSubMenuTextAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblSubMenuWidth As System.Web.UI.WebControls.Label
    Protected WithEvents ddSubMenuWidth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblSubMenuHeight As System.Web.UI.WebControls.Label
    Protected WithEvents ddSubMenuHeight As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        Dim i As Integer
        Dim j As Double

        ' Get language text and init the controls...
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Sites")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_title"))
        lblShowedit.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_showedit"))
        rbShowedit1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbShowedit2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        lblShowfooter.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_showfooter"))
        rbShowfooter1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbShowfooter2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        lblFooterleft.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_footerleft"))
        lblFootercontent.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_footercontent"))
        lblFooterright.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_footerright"))
        lblContentadjust.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_contentadjust"))
        lblSoftdelete.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_softdelete"))
        rbSoftdelete1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbSoftdelete2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        lblColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_color"))
        lblPicture.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_picture"))
        btnPicture.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_picturebutton"))
        lblMenualign.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign"))
        rbMenualign1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1"))
        rbMenualign2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign2"))
        rbMenualign3.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3"))
        rbMenualign4.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign4"))
        lblMenufade.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menufade"))
        rbMenufade1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenufade2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        lblMenufadetime.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menufadedurance"))
        lblMenutop.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menutop"))
        lblMenuleft.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuleft"))
        'btnSave.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_save"))
        lblMenuforecolor1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuforecolor1"))
        lblMenubackcolor1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubackcolor1"))
        lblMenuforecolor2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuforecolor2"))
        lblMenubackcolor2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubackcolor2"))
        lblMenufont.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menufont"))
        lblMenuoverbackcolor2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverbackcolor2"))
        lblMenuoverforecolor2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverforecolor2"))
        lblMenuoverbackcolor1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverbackcolor1"))
        lblMenuoverforecolor1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverforecolor1"))

        lblMenuplacement.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_placement"))
        lblMenubetween.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_between"))
        lblMenuwait.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_wait"))
        lblMenulevel1borderx.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_level1borderx"))
        lblMenulevel1bordery.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_level1bordery"))
        lblMenulevel2borderx.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_level2borderx"))
        lblMenulevel2bordery.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_level2bordery"))

        rbMenulevel1borderx1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenulevel1borderx2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenulevel1bordery1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenulevel1bordery2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenulevel2borderx1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenulevel2borderx2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenulevel2bordery1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenulevel2bordery2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbLogoHorizontalTiling1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbLogoHorizontalTiling2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbLogoVerticalTiling1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbLogoVerticalTiling2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))

        lblLanguage.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_language"))


        lblMenubold1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubold1"))
        lblMenuoverbold1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverbold1"))
        lblMenubold2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubold2"))
        lblMenuoverbold2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverbold2"))
        rbMenuBold1_1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenuBold1_2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenuOverBold1_1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenuOverBold1_2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenuBold2_1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenuBold2_2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenuOverBold2_1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenuOverBold2_2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        rbMenuRoundBorder1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_yes"))
        rbMenuRoundBorder2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_no"))
        lblMenuRoundBorder.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuroundborder"))

        lblMenuFontSize1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menufontsize1"))
        lblMenuOverFontSize1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverfontsize1"))
        lblMenuFontSize2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menufontsize2"))
        lblMenuOverFontSize2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoverfontsize2"))
        lblMenuBorderColor1.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubordercolor1"))
        lblMenuBorderColor2.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menubordercolor2"))

        lblLogohorizontalalign.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_logohorizontalalign"))
        lblLogoverticalalign.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_logoverticalalign"))

        lblMenuOffset.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuoffset"))

        lblSiteHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_siteheader"))
        lblCssHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_cssheader"))
        lblMenuStdHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menustdheader"))
        lblMenuAdvHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_menuadvheader"))
        lblHeadFamily.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_headfamily"))
        lblHeadSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_headsize"))
        lblHeadWeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_headweight"))
        lblHeadColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_headcolor"))
        lblSubHeadFamily.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subheadfamily"))
        lblSubHeadSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subheadsize"))
        lblSubHeadWeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subheadweight"))
        lblSubHeadColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subheadcolor"))
        lblSubSubHeadFamily.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subsubheadfamily"))
        lblSubSubHeadSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subsubheadsize"))
        lblSubSubHeadWeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subsubheadweight"))
        lblSubSubHeadColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_subsubheadcolor"))
        lblNormalFamily.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_normalfamily"))
        lblNormalSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_normalsize"))
        lblNormalWeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_normalweight"))
        lblNormalColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_normalcolor"))
        lblButtonFamily.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonfamily"))
        lblButtonSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonsize"))
        lblButtonWeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonweight"))
        lblButtonForeColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonforecolor"))
        lblButtonBackColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonbackcolor"))
        lblButtonBorderSize.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonbordersize"))
        lblButtonBorderColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttonbordercolor"))
        lblButtonTextAlign.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_buttontextalign"))
        lblHrHeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_hrheight"))
        lblHrColor.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_hrcolor"))
        lblHrAlign.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_hralign"))

        lblLogoHorizontalTiling.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_horizontaltiling"))
        lblLogoVerticalTiling.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_verticaltiling"))

        btnSiteOk.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_ok"))
        btnCssOk.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_ok"))
        btnMenuStdOk.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_ok"))
        btnMenuAdvOk.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_ok"))
        btnMenuDefOk.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_ok"))
        btnSiteUpdate.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_update"))
        btnCssUpdate.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_update"))
        btnMenuStdUpdate.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_update"))
        btnMenuAdvUpdate.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_update"))
        btnMenuDefUpdate.Text = Server.HtmlDecode(oLang.Find(al, "sites_edit_update"))

        btnSiteCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))
        btnCssCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))
        btnMenuStdCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))
        btnMenuAdvCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))
        btnMenuDefCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))

        lblSiteWidth.Text = Server.HtmlDecode(oLang.Find(al, "sites_sitewidth"))
        lblContainerWidth1.Text = Server.HtmlDecode(oLang.Find(al, "sites_containerwidth1"))
        lblContainerWidth2.Text = Server.HtmlDecode(oLang.Find(al, "sites_containerwidth2"))
        lblContainerWidth3.Text = Server.HtmlDecode(oLang.Find(al, "sites_containerwidth3"))
        lblMetaDescription.Text = Server.HtmlDecode(oLang.Find(al, "sites_metadescription"))
        lblMetaKeywords.Text = Server.HtmlDecode(oLang.Find(al, "sites_metakeywords"))
        lblMetaAuthor.Text = Server.HtmlDecode(oLang.Find(al, "sites_metaauthor"))
        lblMetaCopyright.Text = Server.HtmlDecode(oLang.Find(al, "sites_metacopyright"))
        lblMetaRobots.Text = Server.HtmlDecode(oLang.Find(al, "sites_metarobots"))
        lblSiteAlign.Text = Server.HtmlDecode(oLang.Find(al, "sites_sitealign"))
        lblMenuMultiplicator.Text = Server.HtmlDecode(oLang.Find(al, "sites_multiplicator"))
        lblHeadMenuTextAlign.Text = Server.HtmlDecode(oLang.Find(al, "sites_headtextalign"))
        lblHeadMenuWidth.Text = Server.HtmlDecode(oLang.Find(al, "sites_headwidth"))
        lblHeadMenuHeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_headheight"))
        lblSubMenuTextAlign.Text = Server.HtmlDecode(oLang.Find(al, "sites_subtextalign"))
        lblSubMenuWidth.Text = Server.HtmlDecode(oLang.Find(al, "sites_subwidth"))
        lblSubMenuHeight.Text = Server.HtmlDecode(oLang.Find(al, "sites_subheight"))

        ' Set values....
        txtFooterleft.Text = oSite.SiteFooterTextLeft
        txtFootercontent.Text = oSite.SiteFooterTextContent
        txtFooterright.Text = oSite.SiteFooterTextRight
        txtTitle.Text = oSite.SiteName

        bColor.Text = oSite.Color : bColor.Style.Add("BACKGROUND-COLOR", oSite.Color)
        bColor2.Text = oSite.MenuDetails.MenuForeColor1 : bColor2.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuForeColor1)
        bColor3.Text = oSite.MenuDetails.MenuBackColor1 : bColor3.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuBackColor1)
        bColor4.Text = oSite.MenuDetails.MenuForeColor2 : bColor4.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuForeColor2)
        bColor5.Text = oSite.MenuDetails.MenuBackColor2 : bColor5.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuBackColor2)
        bColor6.Text = oSite.MenuDetails.MenuOverForeColor1 : bColor6.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuOverForeColor1)
        bColor7.Text = oSite.MenuDetails.MenuOverBackColor1 : bColor7.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuOverBackColor1)
        bColor8.Text = oSite.MenuDetails.MenuOverForeColor2 : bColor8.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuOverForeColor2)
        bColor9.Text = oSite.MenuDetails.MenuOverBackColor2 : bColor9.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuOverBackColor2)
        bColor10.Text = oSite.MenuDetails.MenuBorderColor1 : bColor10.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuBorderColor1)
        bColor11.Text = oSite.MenuDetails.MenuBorderColor2 : bColor11.Style.Add("BACKGROUND-COLOR", oSite.MenuDetails.MenuBorderColor2)
        bColor12.Text = oSite.SiteCssDetails.HeadColor : bColor12.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.HeadColor)
        bColor13.Text = oSite.SiteCssDetails.SubHeadColor : bColor13.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.SubHeadColor)
        bColor14.Text = oSite.SiteCssDetails.SubSubHeadColor : bColor14.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.SubSubHeadColor)
        bColor15.Text = oSite.SiteCssDetails.NormalColor : bColor15.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.NormalColor)
        bColor16.Text = oSite.SiteCssDetails.ButtonForeColor : bColor16.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.ButtonForeColor)
        bColor17.Text = oSite.SiteCssDetails.ButtonBackColor : bColor17.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.ButtonBackColor)
        bColor18.Text = oSite.SiteCssDetails.ButtonBorderColor : bColor18.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.ButtonBorderColor)
        bColor19.Text = oSite.SiteCssDetails.HrColor : bColor19.Style.Add("BACKGROUND-COLOR", oSite.SiteCssDetails.HrColor)

        Dim oSit As New clsSites
        Dim drLanguage As DataRow
        For Each drLanguage In oSit.GetLanguages.Tables(0).Rows
            ddLanguage.Items.Add(New ListItem(drLanguage("lng_language"), drLanguage("lng_id")))
        Next
        ddLanguage.SelectedValue = oSite.Language

        If oSite.AlwaysShowEditButton Then
            rbShowedit1.Checked = True
            rbShowedit2.Checked = False
        Else
            rbShowedit1.Checked = False
            rbShowedit2.Checked = True
        End If

        If oSite.SiteShowFooter Then
            rbShowfooter1.Checked = True
            rbShowfooter2.Checked = False
        Else
            rbShowfooter1.Checked = False
            rbShowfooter2.Checked = True
        End If

        ddContentadjust.SelectedValue = oSite.SiteContentAdjust

        If oSite.SiteSoftDelete Then
            rbSoftdelete1.Checked = True
            rbSoftdelete2.Checked = False
        Else
            rbSoftdelete1.Checked = False
            rbSoftdelete2.Checked = True
        End If

        If Not oSite.SiteLogoHref = "" Then
            ' Create Thumbnail and load it instead...
            Dim tHeight As Integer
            Dim tWidth As Integer
            Dim _bmpSource As New System.Drawing.Bitmap(Server.MapPath("../../Design/") & "design.png")
            Calculate(_bmpSource, 100, 100, tHeight, tWidth)
            Dim _bmpThumb As New System.Drawing.Bitmap(_bmpSource.GetThumbnailImage(tWidth, tHeight, Nothing, Nothing))
            _bmpThumb.Save(Server.MapPath("../../Design/") & "thumb.png")
            imgPicture.ImageUrl = "~/Server/Design/thumb.png"
        Else
            imgPicture.Visible = False
        End If

        ddHeadMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddHeadMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddHeadMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddHeadMenuTextAlign.SelectedValue = oSite.MenuDetails.MenuTextAlign1

        ddSubMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddSubMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddSubMenuTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddSubMenuTextAlign.SelectedValue = oSite.MenuDetails.MenuTextAlign2

        For i = 1 To 50
            ddHeadMenuHeight.Items.Add(New ListItem(i.ToString))
        Next
        ddHeadMenuHeight.SelectedValue = oSite.MenuDetails.MenuHeight1

        For i = 1 To 50
            ddSubMenuHeight.Items.Add(New ListItem(i.ToString))
        Next
        ddSubMenuHeight.SelectedValue = oSite.MenuDetails.MenuHeight2

        ddHeadMenuWidth.Items.Add(New ListItem("n/a"))
        For i = 1 To 1000
            ddHeadMenuWidth.Items.Add(New ListItem(i.ToString))
        Next
        ddHeadMenuWidth.SelectedValue = oSite.MenuDetails.MenuWidth1

        ddSubMenuWidth.Items.Add(New ListItem("n/a"))
        For i = 1 To 1000
            ddSubMenuWidth.Items.Add(New ListItem(i.ToString))
        Next
        ddSubMenuWidth.SelectedValue = oSite.MenuDetails.MenuWidth2

        For j = 0.1 To 19.9 Step 0.1
            Dim tJ As String = j.ToString("f").Substring(0, j.ToString("f").Length - 1)
            ddMenuMultiplicator.Items.Add(New ListItem(tJ))
        Next
        ddMenuMultiplicator.SelectedValue = oSite.MenuDetails.MenuMultiplicator.ToString("f").Substring(0, oSite.MenuDetails.MenuMultiplicator.ToString("f").Length - 1)

        ddSiteAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddSiteAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddSiteAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddSiteAlign.SelectedValue = oSite.SiteAlign

        ddLogohorizontalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddLogohorizontalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddLogohorizontalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddLogohorizontalalign.SelectedValue = oSite.SiteLogoHorizotalAlign

        ddLogoverticalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign2")), "top"))
        ddLogoverticalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddLogoverticalalign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign4")), "bottom"))
        ddLogoverticalalign.SelectedValue = oSite.SiteLogoVerticalAlign

        Select Case oSite.MenuDetails.MenuAlign
            Case "left"
                rbMenualign1.Checked = True
                rbMenualign2.Checked = False
                rbMenualign3.Checked = False
                rbMenualign4.Checked = False
            Case "top"
                rbMenualign1.Checked = False
                rbMenualign2.Checked = True
                rbMenualign3.Checked = False
                rbMenualign4.Checked = False
            Case "right"
                rbMenualign1.Checked = False
                rbMenualign2.Checked = False
                rbMenualign3.Checked = True
                rbMenualign4.Checked = False
            Case "bottom"
                rbMenualign1.Checked = False
                rbMenualign2.Checked = False
                rbMenualign3.Checked = False
                rbMenualign4.Checked = True
            Case Else
                rbMenualign1.Checked = False
                rbMenualign2.Checked = True
                rbMenualign3.Checked = False
                rbMenualign4.Checked = False
        End Select

        If oSite.MenuDetails.MenuFade Then
            rbMenufade1.Checked = True
            rbMenufade2.Checked = False
        Else
            rbMenufade1.Checked = False
            rbMenufade2.Checked = True
        End If

        ddMenufadetime.SelectedValue = oSite.MenuDetails.MenuDurance

        For i = -800 To 800
            ddMenuOffset.Items.Add(i)
        Next
        ddMenuOffset.SelectedValue = oSite.MenuDetails.MenuOffset

        For i = 0 To 1600
            ddMenuleft.Items.Add(i)
        Next
        ddMenuleft.SelectedValue = oSite.MenuDetails.MenuLeft

        For i = 0 To 1400
            ddMenutop.Items.Add(i)
        Next
        ddMenutop.SelectedValue = oSite.MenuDetails.MenuTop

        ddMenufont.SelectedValue = oSite.MenuDetails.MenuFont

        ddMenuplacement.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddMenuplacement.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign2")), "top"))
        ddMenuplacement.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddMenuplacement.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign4")), "bottom"))
        ddMenuplacement.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddMenuplacement.SelectedValue = oSite.MenuDetails.MenuPlacement

        For i = 0 To 1000
            ddMenubetween.Items.Add(i)
        Next
        ddMenubetween.SelectedValue = oSite.MenuDetails.MenuBetween

        For i = 0 To 2000
            ddMenuwait.Items.Add(i)
        Next
        ddMenuwait.SelectedValue = oSite.MenuDetails.MenuWait

        If oSite.MenuDetails.MenuLevel1BorderX Then
            rbMenulevel1borderx1.Checked = True
            rbMenulevel1borderx2.Checked = False
        Else
            rbMenulevel1borderx1.Checked = False
            rbMenulevel1borderx2.Checked = True
        End If

        If oSite.MenuDetails.MenuLevel1BorderY Then
            rbMenulevel1bordery1.Checked = True
            rbMenulevel1bordery2.Checked = False
        Else
            rbMenulevel1bordery1.Checked = False
            rbMenulevel1bordery2.Checked = True
        End If

        If oSite.MenuDetails.MenuLevel2BorderX Then
            rbMenulevel2borderx1.Checked = True
            rbMenulevel2borderx2.Checked = False
        Else
            rbMenulevel2borderx1.Checked = False
            rbMenulevel2borderx2.Checked = True
        End If

        If oSite.MenuDetails.MenuLevel2BorderY Then
            rbMenulevel2bordery1.Checked = True
            rbMenulevel2bordery2.Checked = False
        Else
            rbMenulevel2bordery1.Checked = False
            rbMenulevel2bordery2.Checked = True
        End If

        If oSite.MenuDetails.MenuBold1 Then
            rbMenuBold1_1.Checked = True
            rbMenuBold1_2.Checked = False
        Else
            rbMenuBold1_1.Checked = False
            rbMenuBold1_2.Checked = True
        End If

        If oSite.MenuDetails.MenuOverBold1 Then
            rbMenuOverBold1_1.Checked = True
            rbMenuOverBold1_2.Checked = False
        Else
            rbMenuOverBold1_1.Checked = False
            rbMenuOverBold1_2.Checked = True
        End If

        If oSite.MenuDetails.MenuBold2 Then
            rbMenuBold2_1.Checked = True
            rbMenuBold2_2.Checked = False
        Else
            rbMenuBold2_1.Checked = False
            rbMenuBold2_2.Checked = True
        End If

        If oSite.MenuDetails.MenuOverBold2 Then
            rbMenuOverBold2_1.Checked = True
            rbMenuOverBold2_2.Checked = False
        Else
            rbMenuOverBold2_1.Checked = False
            rbMenuOverBold2_2.Checked = True
        End If

        If oSite.MenuDetails.MenuRoundBorder Then
            rbMenuRoundBorder1.Checked = True
            rbMenuRoundBorder2.Checked = False
        Else
            rbMenuRoundBorder1.Checked = False
            rbMenuRoundBorder2.Checked = True
        End If

        For i = 0 To 50
            ddMenuFontSize1.Items.Add(i)
        Next
        ddMenuFontSize1.SelectedValue = oSite.MenuDetails.MenuFontSize1

        For i = 0 To 50
            ddMenuOverFontSize1.Items.Add(i)
        Next
        ddMenuOverFontSize1.SelectedValue = oSite.MenuDetails.MenuOverFontSize1

        For i = 0 To 50
            ddMenuFontSize2.Items.Add(i)
        Next
        ddMenuFontSize2.SelectedValue = oSite.MenuDetails.MenuFontSize2

        For i = 0 To 50
            ddMenuOverFontSize2.Items.Add(i)
        Next
        ddMenuOverFontSize2.SelectedValue = oSite.MenuDetails.MenuOverFontSize2

        ddHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightbold")), "bold"))
        ddHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightnormal")), "normal"))
        ddHeadWeight.SelectedValue = oSite.SiteCssDetails.HeadWeight

        ddHeadFamily.SelectedValue = oSite.SiteCssDetails.HeadFamily
        ddHeadSize.SelectedValue = oSite.SiteCssDetails.HeadSize

        ddSubHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightbold")), "bold"))
        ddSubHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightnormal")), "normal"))
        ddSubHeadWeight.SelectedValue = oSite.SiteCssDetails.SubHeadWeight

        ddSubHeadFamily.SelectedValue = oSite.SiteCssDetails.SubHeadFamily
        ddSubHeadSize.SelectedValue = oSite.SiteCssDetails.SubHeadSize

        ddSubSubHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightbold")), "bold"))
        ddSubSubHeadWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightnormal")), "normal"))
        ddSubSubHeadWeight.SelectedValue = oSite.SiteCssDetails.SubSubHeadWeight

        ddSubSubHeadFamily.SelectedValue = oSite.SiteCssDetails.SubSubHeadFamily
        ddSubSubHeadSize.SelectedValue = oSite.SiteCssDetails.SubSubHeadSize

        ddNormalWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightbold")), "bold"))
        ddNormalWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightnormal")), "normal"))
        ddNormalWeight.SelectedValue = oSite.SiteCssDetails.NormalWeight

        ddNormalFamily.SelectedValue = oSite.SiteCssDetails.NormalFamily
        ddNormalSize.SelectedValue = oSite.SiteCssDetails.NormalSize

        ddButtonWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightbold")), "bold"))
        ddButtonWeight.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_weightnormal")), "normal"))
        ddButtonWeight.SelectedValue = oSite.SiteCssDetails.ButtonFontWeight

        ddButtonFamily.SelectedValue = oSite.SiteCssDetails.ButtonFontFamily
        ddButtonSize.SelectedValue = oSite.SiteCssDetails.ButtonFontSize

        ddButtonBorderSize.Items.Add(New ListItem(1, "1"))
        ddButtonBorderSize.Items.Add(New ListItem(2, "2"))
        ddButtonBorderSize.Items.Add(New ListItem(3, "3"))
        ddButtonBorderSize.Items.Add(New ListItem(4, "4"))
        ddButtonBorderSize.Items.Add(New ListItem(5, "5"))
        ddButtonBorderSize.SelectedValue = oSite.SiteCssDetails.ButtonBorderSize

        ddButtonTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddButtonTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddButtonTextAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddButtonTextAlign.SelectedValue = oSite.SiteCssDetails.ButtonTextAlign

        ddHrAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign1")), "left"))
        ddHrAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign5")), "center"))
        ddHrAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "sites_edit_menualign3")), "right"))
        ddHrAlign.SelectedValue = oSite.SiteCssDetails.HrAlign

        If oSite.SiteLogoHorizotalTiling Then
            rbLogoHorizontalTiling1.Checked = True
            rbLogoHorizontalTiling2.Checked = False
        Else
            rbLogoHorizontalTiling1.Checked = False
            rbLogoHorizontalTiling2.Checked = True
        End If

        If oSite.SiteLogoVerticalTiling Then
            rbLogoVerticalTiling1.Checked = True
            rbLogoVerticalTiling2.Checked = False
        Else
            rbLogoVerticalTiling1.Checked = False
            rbLogoVerticalTiling2.Checked = True
        End If

        ddSiteWidth.Items.Add("n/a")
        For i = 1 To 1800
            ddSiteWidth.Items.Add(i)
        Next
        ddSiteWidth.SelectedValue = oSite.SiteWidth

        For i = 1 To 1800
            ddContainerWidth1.Items.Add(i)
        Next
        ddContainerWidth1.SelectedValue = oSite.ContainerWidth1

        For i = 1 To 1800
            ddContainerWidth2.Items.Add(i)
        Next
        ddContainerWidth2.SelectedValue = oSite.ContainerWidth2

        For i = 1 To 1800
            ddContainerWidth3.Items.Add(i)
        Next
        ddContainerWidth3.SelectedValue = oSite.ContainerWidth3

        txtMetaDescription.Text = oSite.MetaDescription
        txtMetaKeywords.Text = oSite.MetaKeywords
        txtMetaAuthor.Text = oSite.MetaAuthor
        txtMetaCopyright.Text = oSite.MetaCopyright
        txtMetaRobots.Text = oSite.MetaRobots

    End Sub

    Private Function Calculate(ByVal Source As System.Drawing.Bitmap, ByVal MaxHeight As Integer, ByVal MaxWidth As Integer, ByRef NewHeight As Integer, ByRef NewWidth As Integer)
        If Source.Height < MaxHeight And Source.Width < MaxWidth Then
            NewHeight = Source.Height
            NewWidth = Source.Width
        Else
            Dim _HeightRatio As Integer = Source.Height / MaxHeight
            Dim _WidthRatio As Integer = Source.Width / MaxWidth
            If _WidthRatio > _HeightRatio Then
                NewHeight = Source.Height / _WidthRatio
                NewWidth = Source.Width / _WidthRatio
            Else
                NewHeight = Source.Height / _HeightRatio
                NewWidth = Source.Width / _HeightRatio
            End If
        End If
    End Function

    Private Sub btnPicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPicture.Click
        Response.Redirect("~/Server/Modules/Sites/EditSitesUpload.aspx?ModId=" & ModId)
    End Sub

    Private Sub Save()
        Dim MenuAlign As String
        If rbMenualign1.Checked Then MenuAlign = "left"
        If rbMenualign2.Checked Then MenuAlign = "top"
        If rbMenualign3.Checked Then MenuAlign = "right"
        If rbMenualign4.Checked Then MenuAlign = "bottom"

        Dim oSit As New clsSites
        If Not oSit.UpdateSiteSetting(txtTitle.Text, ddLanguage.SelectedValue, rbShowedit1.Checked, rbShowfooter1.Checked, txtFooterleft.Text, txtFootercontent.Text, txtFooterright.Text, ddContentadjust.SelectedValue, rbSoftdelete1.Checked, bColor.Text, ddLogohorizontalalign.SelectedValue, ddLogoverticalalign.SelectedValue, ddHeadFamily.SelectedValue, ddHeadSize.SelectedValue, ddHeadWeight.SelectedValue, bColor12.Text, ddSubHeadFamily.SelectedValue, ddSubHeadSize.SelectedValue, ddSubHeadWeight.SelectedValue, bColor13.Text, ddSubSubHeadFamily.SelectedValue, ddSubSubHeadSize.SelectedValue, ddSubSubHeadWeight.SelectedValue, bColor14.Text, ddNormalFamily.SelectedValue, ddNormalSize.SelectedValue, ddNormalWeight.SelectedValue, bColor15.Text, ddButtonFamily.SelectedValue, ddButtonSize.SelectedValue, ddButtonWeight.SelectedValue, bColor16.Text, bColor17.Text, ddButtonBorderSize.SelectedValue, bColor18.Text, ddButtonTextAlign.SelectedValue, bColor19.Text, ddHrAlign.SelectedValue, ddHrHeight.SelectedValue, rbLogoHorizontalTiling1.Checked, rbLogoVerticalTiling1.Checked, MenuAlign, rbMenufade1.Checked, ddMenufadetime.SelectedValue, ddMenuOffset.SelectedValue, ddMenutop.SelectedValue, ddMenuleft.SelectedValue, bColor2.Text, bColor3.Text, bColor4.Text, bColor5.Text, bColor6.Text, bColor7.Text, bColor8.Text, bColor9.Text, ddMenufont.SelectedValue, ddMenuplacement.SelectedValue, ddMenubetween.SelectedValue, ddMenuwait.SelectedValue, rbMenulevel1borderx1.Checked, rbMenulevel1bordery1.Checked, rbMenulevel2borderx1.Checked, rbMenulevel2bordery1.Checked, rbMenuBold1_1.Checked, rbMenuOverBold1_1.Checked, rbMenuBold2_1.Checked, rbMenuOverBold2_1.Checked, rbMenuRoundBorder1.Checked, ddMenuFontSize1.SelectedValue, ddMenuOverFontSize1.SelectedValue, ddMenuFontSize2.SelectedValue, ddMenuOverFontSize2.SelectedValue, bColor10.Text, bColor11.Text, ddSiteWidth.SelectedValue, ddContainerWidth1.SelectedValue, ddContainerWidth2.SelectedValue, ddContainerWidth3.SelectedValue, txtMetaDescription.Text, txtMetaKeywords.Text, txtMetaAuthor.Text, txtMetaCopyright.Text, txtMetaRobots.Text, ddSiteAlign.SelectedValue, ddMenuMultiplicator.SelectedValue, ddHeadMenuTextAlign.SelectedValue, ddSubMenuTextAlign.SelectedValue, ddHeadMenuWidth.SelectedValue, ddSubMenuWidth.SelectedValue, ddHeadMenuHeight.SelectedValue, ddSubMenuHeight.SelectedValue) Then
            Response.Write("fel") : Response.End()
        End If
    End Sub

    Private Sub Ok(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiteOk.Click, btnCssOk.Click, btnMenuStdOk.Click, btnMenuAdvOk.Click, btnMenuDefOk.Click
        Call Save()
        Dim adminIndex As Integer = oSite.DesktopPages.Count - 1
        Response.Redirect(("~/icm.aspx?PageId=" & CType(oSite.DesktopPages(adminIndex), clsPageStripDetails).PageId) & "&ExpId=" & ModId)
    End Sub

    Private Sub Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiteUpdate.Click, btnCssUpdate.Click, btnMenuStdUpdate.Click, btnMenuAdvUpdate.Click, btnMenuDefUpdate.Click
        Call Save()
    End Sub

    Private Sub Cancel(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiteCancel.Click, btnCssCancel.Click, btnMenuStdCancel.Click, btnMenuAdvCancel.Click, btnMenuDefCancel.Click
        Dim adminIndex As Integer = oSite.DesktopPages.Count - 1
        Response.Redirect(("~/icm.aspx?PageId=" & CType(oSite.DesktopPages(adminIndex), clsPageStripDetails).PageId) & "&ExpId=" & ModId)
    End Sub

End Class
