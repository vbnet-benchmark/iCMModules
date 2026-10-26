Public Class PublisherEdit
    Inherits System.Web.UI.Page

    Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents deleteButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DesktopText As System.Web.UI.WebControls.TextBox
    Protected urlholder As String = ""
    Protected ModId As Integer = 0
    Protected PageId As Integer = 0

    Protected DesignMode As String
    Protected HtmlMode As String
    Protected Header As String
    Protected Alert As String

    Protected Font As String
    Protected FontSize As String
    Protected Update As String
    Protected Cancel As String
    Protected DefaultText As String
    Protected Undo As String
    Protected Redo As String
    Protected Print As String
    Protected SelectAll As String
    Protected Cut As String
    Protected Copy As String
    Protected Paste As String
    Protected Bold As String
    Protected Italic As String
    Protected Underline As String
    Protected StrikeThrou As String
    Protected Left As String
    Protected Center As String
    Protected Right As String
    Protected OrderedList As String
    Protected BulletedList As String
    Protected Unindent As String
    Protected Indent As String
    Protected UpperCase As String
    Protected LowerCase As String
    Protected SuperScript As String
    Protected SubScript As String
    Protected Horizontal As String
    Protected TextColor As String
    Protected BGColor As String
    Protected Symbol As String
    Protected Table As String
    Protected Link As String
    Protected Image As String
    Protected Preview As String
    Protected Delete As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sContent As String = IIf(Len(Request.Params("EditorContent")) > 0, Request.Params("EditorContent"), "")

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If

        ' Determine url of Portal Module
        urlholder = IIf(Len(Request.Params("urlholder")) > 0, Request.Params("urlholder"), "")

        ' Verify that the current user has access to edit this module
        If clsSiteSecurity.HasEditPermissions(ModId) = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        Call SetLanguageText()

        ' Check if we gonna save the requested content or not...
        If Len(sContent) > 0 Then
            ' Save Area

            ' Create an instance of the HtmlTextDB component
            Dim oPub As New clsPublisher

            ' Update the text within the HtmlText table
            oPub.SetHtmlText(PageId, ModId, Server.HtmlEncode(sContent))

            Response.Redirect("~/icm.aspx?PageId=" & PageId & "&ExpId=" & ModId)

        Else
            ' Design Area

            ' Obtain a single row of text information
            Dim oPub As New clsPublisher
            Dim _content As String = oPub.GetHtmlText(PageId, ModId)
            'Response.Write(Server.HtmlDecode(CType(_content, String)).Length)
            If Server.HtmlDecode(CType(_content, String)).Length > 13 Then
                DesktopText.Text = Server.HtmlDecode(CType(_content, String))
            Else
                DesktopText.Text = "<TABLE height=380 cellSpacing=0 cellPadding=0 width=520 align=left border=0><TBODY><TR><TD><DIV id=liner001 style='OVERFLOW: auto; WIDTH: 520px; HEIGHT: 380px'>" & DefaultText & "</DIV></TD></TR></TBODY></TABLE>"
            End If

            urlholder = Request.UrlReferrer.ToString()
        End If

    End Sub

    Private Sub SetLanguageText()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Publisher")

        DesignMode = Server.HtmlDecode(oLang.Find(al, "publisher_designlayout"))
        HtmlMode = Server.HtmlDecode(oLang.Find(al, "publisher_htmllayout"))
        Header = Server.HtmlDecode(oLang.Find(al, "publisher_header"))

        Font = Server.HtmlDecode(oLang.Find(al, "publisher_font"))
        FontSize = Server.HtmlDecode(oLang.Find(al, "publisher_fontsize"))
        Update = Server.HtmlDecode(oLang.Find(al, "publisher_update"))
        Cancel = Server.HtmlDecode(oLang.Find(al, "publisher_cancel"))
        DefaultText = Server.HtmlDecode(oLang.Find(al, "publisher_defaulttext"))
        Undo = Server.HtmlDecode(oLang.Find(al, "publisher_undo"))
        Redo = Server.HtmlDecode(oLang.Find(al, "publisher_redo"))
        Print = Server.HtmlDecode(oLang.Find(al, "publisher_print"))
        SelectAll = Server.HtmlDecode(oLang.Find(al, "publisher_selectall"))
        Cut = Server.HtmlDecode(oLang.Find(al, "publisher_cut"))
        Copy = Server.HtmlDecode(oLang.Find(al, "publisher_copy"))
        Paste = Server.HtmlDecode(oLang.Find(al, "publisher_paste"))
        Bold = Server.HtmlDecode(oLang.Find(al, "publisher_bold"))
        Italic = Server.HtmlDecode(oLang.Find(al, "publisher_italic"))
        Underline = Server.HtmlDecode(oLang.Find(al, "publisher_underline"))
        StrikeThrou = Server.HtmlDecode(oLang.Find(al, "publisher_strikethrou"))
        Left = Server.HtmlDecode(oLang.Find(al, "publisher_left"))
        Center = Server.HtmlDecode(oLang.Find(al, "publisher_center"))
        Right = Server.HtmlDecode(oLang.Find(al, "publisher_right"))
        OrderedList = Server.HtmlDecode(oLang.Find(al, "publisher_orderedlist"))
        BulletedList = Server.HtmlDecode(oLang.Find(al, "publisher_bulletedlist"))
        Unindent = Server.HtmlDecode(oLang.Find(al, "publisher_unindent"))
        Indent = Server.HtmlDecode(oLang.Find(al, "publisher_indent"))
        UpperCase = Server.HtmlDecode(oLang.Find(al, "publisher_uppercase"))
        LowerCase = Server.HtmlDecode(oLang.Find(al, "publisher_lowercase"))
        SuperScript = Server.HtmlDecode(oLang.Find(al, "publisher_superscipt"))
        SubScript = Server.HtmlDecode(oLang.Find(al, "publisher_subscript"))
        Horizontal = Server.HtmlDecode(oLang.Find(al, "publisher_horizontal"))
        TextColor = Server.HtmlDecode(oLang.Find(al, "publisher_textcolor"))
        BGColor = Server.HtmlDecode(oLang.Find(al, "publisher_bgcolor"))
        Symbol = Server.HtmlDecode(oLang.Find(al, "publisher_symbol"))
        Table = Server.HtmlDecode(oLang.Find(al, "publisher_table"))
        Link = Server.HtmlDecode(oLang.Find(al, "publisher_link"))
        Image = Server.HtmlDecode(oLang.Find(al, "publisher_image"))
        Preview = Server.HtmlDecode(oLang.Find(al, "publisher_preview"))
        Delete = Server.HtmlDecode(oLang.Find(al, "publisher_delete"))
        Alert = Server.HtmlDecode(oLang.Find(al, "publisher_confirmclick"))
    End Sub

End Class
