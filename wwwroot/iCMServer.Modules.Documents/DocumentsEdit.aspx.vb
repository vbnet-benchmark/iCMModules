Public Class DocumentsEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblMax As System.Web.UI.WebControls.Label
    Protected WithEvents btnRevision As System.Web.UI.WebControls.Button
    Protected WithEvents Revisions As System.Web.UI.WebControls.PlaceHolder

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
    Private CatId As Integer = 0
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private MaxPostedFileLength As Integer = 0
    Private NewRevision As Boolean
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

        If Not (Request.Params("CatId") Is Nothing) Then
            CatId = Int32.Parse(Request.Params("CatId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PageId"))
        End If

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Documents")

        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "documents_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "documents_title2"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "documents_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "documents_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "documents_delete"))
        btnRevision.Text = Server.HtmlDecode(oLang.Find(al, "documents_revisions"))

        btnDelete.Attributes.Add("onclick", "return confirm('" & Server.HtmlDecode(oLang.Find(al, "documents_deletefileconfirm")) & "');")

        MaxPostedFileLength = CType(System.Configuration.ConfigurationSettings.AppSettings.Get("MaxPostedFileContentLength"), Integer)

        lblMax.Text = "Max: " & FormatNumber(MaxPostedFileLength / 1023, 0) & " KB"

        If Not DocId = 0 Then
            NewRevision = True
            If Not Page.IsPostBack Then
                Dim oDoc As New clsDocuments
                Dim ds As New System.data.DataSet
                ds = oDoc.GetDocumentInfo(ModId, CatId, DocId)
                txtTitle.Text = ds.Tables(0).Rows(0)("doc_name")
            End If
        Else
            btnDelete.Visible = False
            btnRevision.Visible = False
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not (FileUpload.PostedFile Is Nothing) Then
            If FileUpload.PostedFile.ContentLength < MaxPostedFileLength Then
                Dim length As Integer = CInt(FileUpload.PostedFile.InputStream.Length)
                Dim contentType As String = FileUpload.PostedFile.ContentType
                Dim content(length) As Byte
                Dim oDoc As New clsDocuments
                Dim m_DocId As Integer
                FileUpload.PostedFile.InputStream.Read(content, 0, length)
                If Len(txtTitle.Text) < 1 Then
                    Try
                        txtTitle.Text = Right(FileUpload.PostedFile.FileName, InStr(StrReverse(FileUpload.PostedFile.FileName), "\") - 1)
                    Catch ex As Exception
                        txtTitle.Text = "New Doc"
                    End Try
                End If

                ' Check if a file already exists in the database with the same name....
                m_DocId = oDoc.CheckIfFileAlreadyExists(PagId, ModId, CatId, txtTitle.Text)
                If Not m_DocId = 0 Then
                    ' Automaticaly save a new revision...
                    If Not oDoc.UpdateDocument(ModId, CatId, m_DocId, Context.User.Identity.Name, txtTitle.Text, content, contentType, length, 0, 0) Then
                        Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                    End If
                Else
                    If NewRevision Then
                        ' Save a new revision...
                        If Not oDoc.UpdateDocument(ModId, CatId, DocId, Context.User.Identity.Name, txtTitle.Text, content, contentType, length, 0, 0) Then
                            Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                        End If
                    Else
                        ' Save a fresh file...
                        If Not oDoc.AddDocument(PagId, ModId, CatId, Context.User.Identity.Name, txtTitle.Text, content, contentType, length, 1, 0) Then
                            Response.Write("<script>alert('" & Replace(Err.Description, "'", "") & "');</script>")
                        End If
                    End If
                End If

            End If
        End If
        Response.Write("<script>window.parent.GetDocuments" & ModId.ToString & "(" & CatId & ");</script>")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<script>window.parent.GetDocuments" & ModId.ToString & "(" & CatId & ");</script>")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oDoc As New clsDocuments
        If Not oDoc.DeleteDocument(ModId, CatId, DocId) Then

        End If
        Response.Write("<script>window.parent.GetDocuments" & ModId.ToString & "(" & CatId & ");</script>")
    End Sub

    Private Sub btnRevision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevision.Click
        Dim oDoc As New clsDocuments
        Revisions.Controls.Add(New System.Web.UI.LiteralControl(oDoc.GetDocumentRevisions(ModId, CatId, DocId)))
    End Sub

End Class