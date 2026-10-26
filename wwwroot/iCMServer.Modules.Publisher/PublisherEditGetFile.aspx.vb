Public Class PublisherEditGetFile
    Inherits System.Web.UI.Page

    Private PageId As Integer = 0
    Private ModId As Integer = 0
    Private DocId As Integer = 0

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

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

        If DocId <> 0 Then

            Dim oPub As New clsPublisher
            Dim ds As New Data.DataSet
            ds = oPub.GetDocument(PageId, ModId, DocId)
            Response.AppendHeader("content-disposition", "filename=" & CStr(ds.Tables(0).Rows(0)("doc_name")))
            Response.ContentType = CType(ds.Tables(0).Rows(0)("doc_contenttype"), String)
            Response.OutputStream.Write(CType(ds.Tables(0).Rows(0)("doc_content"), Byte()), 0, CInt(ds.Tables(0).Rows(0)("doc_contentsize")))
            Response.End()

        End If

    End Sub

End Class
