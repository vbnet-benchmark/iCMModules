Public Class BNIMembersImageStream
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

    Private BmeId As Integer = 0
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private Type As String = ""
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

        If Not (Request.Params("Type") Is Nothing) Then
            Type = Request.Params("Type")
        End If

        Dim oBNI As New clsBNIMembers
        Dim ds As New Data.DataSet
        ds = oBNI.GetPicture(PagId, ModId, BmeId, Type)
        Dim dr As Data.DataRow
        dr = ds.Tables(0).Rows(0)
        Dim buffer As Byte()
        Select Case LCase(Type)
            Case "logo"
                buffer = dr("bme_logocontent")
                Response.AppendHeader("content-disposition", "filename=" & Type)
                Response.ContentType = CType(dr("bme_logocontenttype"), String)
                Response.OutputStream.Write(buffer, 0, buffer.Length)
            Case "me"
                buffer = dr("bme_mecontent")
                Response.AppendHeader("content-disposition", "filename=" & Type)
                Response.ContentType = CType(dr("bme_mecontenttype"), String)
                Response.OutputStream.Write(buffer, 0, buffer.Length)
        End Select
        Response.End()
    End Sub

End Class
