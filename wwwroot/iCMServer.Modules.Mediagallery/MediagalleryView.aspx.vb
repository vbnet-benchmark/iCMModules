Public Class MediagalleryView
    Inherits System.Web.UI.Page

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

    Private PageID As Integer = 0
    Private ModID As Integer = 0
    Private CatID As Integer = 0
    Private DocId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        If Not (Request.Params("CatID") Is Nothing) Then
            CatID = Int32.Parse(Request.Params("CatID"))
        End If

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

        Dim oMed As New clsMediagallery
        Dim ds As New Data.DataSet
        ds = oMed.GetDocument(PageID, ModID, CatID, DocId)
        Dim dr As Data.DataRow
        dr = ds.Tables(0).Rows(0)

        'Response.AppendHeader("content-disposition", "attachment; filename=" & dr("doc_name"))
        Response.ContentType = CType(dr("doc_contenttype"), String) '"application/octet-stream"
        Response.OutputStream.Write(CType(dr("doc_content"), Byte()), 0, CInt(dr("doc_contentsize")))
        Response.End()



        'Response.AppendHeader("content-disposition", "attachment; filename=" & dr("doc_name"))
        'Response.ContentType = CType(dr("doc_contenttype"), String) '"application/octet-stream"
        'Response.OutputStream.Write(CType(Text.Encoding.ASCII.GetBytes(dr("doc_content")), Byte()), 0, CInt(dr("doc_contentsize")))
        'Response.End()


    End Sub

End Class
