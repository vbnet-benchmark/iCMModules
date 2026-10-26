Public Class LiteDocumentsUpload
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Upload As System.Web.UI.WebControls.CheckBox
    Protected WithEvents storeInDatabase As System.Web.UI.WebControls.CheckBox
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents MaxPost As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private PageID As Integer = 0
    Private ModID As Integer = 0
    Private CatID As Integer = 0
    Private DocId As Integer = 0
    Private MaxPostedFileLength As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        'If Not (Request.Params("CatID") Is Nothing) Then
        '    CatID = Int32.Parse(Request.Params("CatID"))
        'End If

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

        'If clsSiteSecurity.HasEditPermissions(ModID) = False Then
        '    Response.Redirect("~/Server/Security/AccessDenied.aspx")
        'End If

        MaxPostedFileLength = CType(System.Configuration.ConfigurationSettings.AppSettings.Get("MaxPostedFileContentLength"), Integer)

        MaxPost.Text = "Max storlek: " & FormatNumber(MaxPostedFileLength / 1023, 0) & " kb"

        If Not Page.IsPostBack Then
            If Not DocId = 0 Then
                ViewState("bIsUpdate") = True
                Dim ds As New Data.DataSet
                'Dim oDoc As New clsLiteDocuments
                '                ds = oDoc.GetDefinedDocument(PageID, ModID, CatID, DocId)
                ' NameField.Text = ds.Tables(0).Rows(0)("doc_name")
            End If
            ViewState("UrlReferrer") = "~/icm.aspx?PageId=" & PageID  ' = Left(Request.RawUrl, InStr(Request.RawUrl, "LiteDocumentsUpload.aspx")) ' "" 'IIf(IsNothing(Request.UrlReferrer.ToString()), "", Request.UrlReferrer.ToString())
        End If

        Call AddAttributes()

    End Sub

    Private Sub AddAttributes()
        btnDelete.Attributes.Add("onclick", "return confirm('Vill du verkligen radera detta dokument?');")
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not (FileUpload.PostedFile Is Nothing) Then
            If FileUpload.PostedFile.ContentLength < MaxPostedFileLength Then
                Dim length As Integer = CInt(FileUpload.PostedFile.InputStream.Length)
                Dim contentType As String = FileUpload.PostedFile.ContentType
                Dim content(length) As Byte
                Dim oDoc As New clsNorskFilmWizard(ModID, PageID, True)
                Dim m_DocId As Integer
                FileUpload.PostedFile.InputStream.Read(content, 0, length)
                If Len(txtTitle.Text) < 1 Then
                    Try
                        txtTitle.Text = Right(FileUpload.PostedFile.FileName, InStr(StrReverse(FileUpload.PostedFile.FileName), "\") - 1)
                    Catch ex As Exception
                        txtTitle.Text = "New Doc"
                    End Try
                End If

                Dim i As Integer
                i = oDoc.AddDocument(PageID, ModID, CatID, Context.User.Identity.Name, txtTitle.Text, content, contentType, length, 1, 0)
                Response.Write(i)

                If Not oDoc.AddDocument(PageID, ModID, CatID, Context.User.Identity.Name, txtTitle.Text, content, contentType, length, 1, 0) Then
                    Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                End If
            End If
        End If

        '       Response.Write("<script>window.parent.GetDocuments" & ModID.ToString & "(" & CatID & ");</script>")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'If Not DocId = 0 Then
        '    Dim oDoc As New clsLiteDocuments
        '    If Not oDoc.DeleteDocument(PageID, ModID, CatID, DocId) Then
        '        Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
        '    End If
        '    Response.Redirect(CType(ViewState("UrlReferrer"), String))
        'End If
    End Sub
End Class
