Public Class DocumentsFolderEdit
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

    Private Mode As String = ""
    Private Title As String = ""
    Private PagId As Integer = 0
    Private ModId As Integer = 0
    Private CatId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("Mode") Is Nothing) Then
            Mode = Request.Params("Mode")
        End If

        If Not (Request.Params("Title") Is Nothing) Then
            Title = Request.Params("Title")
        End If

        If Not (Request.Params("PagId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PagId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("CatId") Is Nothing) Then
            CatId = Int32.Parse(Request.Params("CatId"))
        End If

        'Response.Write(Mode & "<br>")
        'Response.Write(Title & "<br>")
        'Response.Write(ModId & "<br>")
        'Response.Write(CatId & "<br>")

        'Response.End()
        Dim oDoc As New clsDocuments

        Select Case Mode
            Case "ADDFOLDER"
                oDoc.AddFolder(PagId, ModId, CatId, Title)
                Response.Write("<script>window.parent.ReloadSelectedNode" & ModId.ToString & "('ADD');</script>")

            Case "DELETEFOLDER"
                oDoc.Deletefolder(PagId, ModId, CatId)
                Response.Write("<script>window.parent.ReloadSelectedNode" & ModId.ToString & "('DELETE');</script>")

            Case "EDITFOLDER"
                oDoc.UpdateFolder(PagId, ModId, CatId, Title)
                Response.Write("<script>window.parent.ReloadSelectedNode" & ModId.ToString & "('ADD');</script>")

        End Select
    End Sub

End Class
