Public Class PublisherEditImage
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents NewImageAlt As System.Web.UI.WebControls.TextBox
    Protected WithEvents NewImageBorder As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblAlt As System.Web.UI.WebControls.Label
    Protected WithEvents lblBorder As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private DocId As Integer = 0
    Private ModId As Integer = 0
    Private PageId As Integer = 0
    Private sAlt As String
    Private sSrc As String
    Private sBorder As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If
        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If
        btnCancel.Attributes.Add("onclick", "window.close();")
        Call SetLanguageText()
    End Sub

    Private Sub SetLanguageText()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Publisher")

        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "publisher_urlheader"))
        lblBorder.Text = Server.HtmlDecode(oLang.Find(al, "publisher_urlborder"))
        lblAlt.Text = Server.HtmlDecode(oLang.Find(al, "publisher_urlalt"))
        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "publisher_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "publisher_cancel"))
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Page.IsValid = True Then
            Dim iItemID As Integer
            Dim oPub As New clsPublisher
            Dim length As Integer = CInt(FileUpload.PostedFile.InputStream.Length)
            Dim contentType As String = FileUpload.PostedFile.ContentType
            Dim content(length) As Byte
            FileUpload.PostedFile.InputStream.Read(content, 0, length)
            DocId = oPub.SaveDocument(PageId, ModId, content, contentType, length)
            sAlt = NewImageAlt.Text
            sSrc = Left(Request.Path, Len(Request.Path) - InStr(StrReverse(Request.Path), "/")) & "/PublisherEditGetFile.aspx?PageId=" & PageId & "&ModId=" & ModId & "&DocId=" & DocId
            sBorder = NewImageBorder.SelectedItem.Text
            With Response
                .Write("<script>")
                .Write("function ImageReturn(){")
                .Write("var _ImageContent = '<IMG ALT=\'" & sAlt & " \'SRC=\'" & sSrc & " \'BORDER=\'" & sBorder & "\'>';")
                .Write("if(window.opener.IsIE456()){")
                .Write("var _MarkedRange = window.opener.getIFrameDocument('ContentView').selection.createRange();")
                .Write("_MarkedRange.pasteHTML(_ImageContent);")
                .Write("}")
                .Write("else{")
                .Write("window.opener.getIFrameDocument('ContentView').body.innerHTML = _ImageContent + window.opener.getIFrameDocument('ContentView').body.innerHTML;")
                .Write("}")
                .Write("window.opener.document.getElementById('ContentView').contentWindow.focus();")
                .Write("window.close();")
                .Write("}")
                .Write("</script>")
                .Write("<script>ImageReturn();</script>")
            End With
        End If
    End Sub
End Class
