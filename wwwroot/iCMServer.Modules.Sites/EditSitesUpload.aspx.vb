Public Class EditSitesUpload
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMax As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Private DocId As Integer = 0
    Private ModId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

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

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

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

        ' Get language text and init the controls...
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Sites")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_header"))
        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_save"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "sites_upload_delete"))
        btnDelete.Attributes.Add("onclick", "return confirm('" & Server.HtmlDecode(oLang.Find(al, "sites_upload_confirm")) & "');")

        lblMax.Text = "Max: 1000 kb"

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not FileUpload.PostedFile Is Nothing Then
            If FileUpload.PostedFile.ContentLength < 1230000 Then
                'Response.Write(Server.MapPath("../../Design/") & "design.png") : Response.End()
                FileUpload.PostedFile.SaveAs(Server.MapPath("../../Design/") & "design.png")
                Dim oSit As New clsSites
                If Not osit.UpdatePictureHref() Then
                    Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                End If
                'Response.Write(FileUpload.PostedFile.ContentLength) : Response.End()
                'Dim length As Integer = CInt(FileUpload.PostedFile.InputStream.Length)
                'Dim contentType As String = FileUpload.PostedFile.ContentType
                'Dim content(length) As Byte
                'Dim oSit As New clsSites
                'FileUpload.PostedFile.InputStream.Read(content, 0, length)
                'If Not oSit.UpdatePicture(content, contentType, length) Then
                '    Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                'End If
            End If
        End If
        Response.Redirect("~/Server/Modules/Sites/EditSites.aspx?ModId=" & ModId)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Server/Modules/Sites/EditSites.aspx?ModId=" & ModId)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oSit As New clsSites
        If Not oSit.DeletePictureHref() Then
            Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
        End If
        'If Not oSit.DeletePicture(IIf(Trim(oSite.SiteLogo) = "", 0, CType(oSite.SiteLogo, Integer))) Then
        '    Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
        'End If
        Response.Redirect("~/Server/Modules/Sites/EditSites.aspx?ModId=" & ModId)
    End Sub
End Class
