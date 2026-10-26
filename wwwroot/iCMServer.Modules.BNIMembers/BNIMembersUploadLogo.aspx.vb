Public Class BNIMembersUploadLogo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private BmeId As Integer = 0
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("BmeId") Is Nothing) Then
            BmeId = Int32.Parse(Request.Params("BmeId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PagId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PagId"))
        End If

        Dim oSit As New clsSiteSecurity
        If Not oSit.HasEditPermissions(ModId) Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.BNIMembers")

        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_logotitle"))
        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_logosave"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_logocancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_logodelete"))

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If FileUpload.PostedFile.ContentLength < 1230000 Then
            Dim oBNI As New clsBNIMembers
            Dim length As Integer = CInt(FileUpload.PostedFile.InputStream.Length)
            Dim contentType As String = FileUpload.PostedFile.ContentType
            Dim content(length) As Byte
            FileUpload.PostedFile.InputStream.Read(content, 0, length)
            oBNI.UpdateLogo(PagId, ModId, BmeId, content, contentType, length)
        End If
        Response.Redirect("~/iCM.aspx?PageId=" & PagId)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/iCM.aspx?PageId=" & PagId)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oBNI As New clsBNIMembers
        If Not oBNI.DeletePicture(PagId, ModId, BmeId, "Logo") Then

        End If
        Response.Redirect("~/iCM.aspx?PageId=" & PagId)
    End Sub
End Class
