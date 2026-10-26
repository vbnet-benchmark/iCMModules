Public Class DocumentsGetFiles
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

    Protected CatId As Integer = 0
    Protected ModId As Integer = 0
    Protected urlRef As String = ""
    Protected Done As Integer = 0
    Private HasEditAuth As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("CatId") Is Nothing) Then
            CatId = Int32.Parse(Request.Params("CatId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("H") Is Nothing) Then
            HasEditAuth = Boolean.Parse(Request.Params("H"))
        End If

        If Not (Request.Params("Done") Is Nothing) Then
            Done = Int32.Parse(Request.Params("Done"))
        End If

        Try

            urlRef = Server.UrlEncode(Request.UrlReferrer.ToString())

            Dim oDoc As New clsDocuments
            Dim Folder As String
            Dim Files As String = oDoc.GetDocuments(ModId, CatId, urlRef, "", Folder, HasEditAuth)

            Response.Write("<html><body>")

            Response.Write("<div style='FONT-WEIGHT: bold; FONT-SIZE: 20pt; Z-INDEX: -1; LEFT: 10px; WIDTH: 370px; COLOR: #f7f7f7; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 5px; HEIGHT: 20px'><b>" & Folder & "</b></div>")

            Response.Write("<TABLE WIDTH=100% BORDER=0 CELLSPACING=0 CELLPADDING=0>")

            Response.Write(Files)

            Response.Write("</TABLE>")

            Response.Write("</body></html>")

            If Done = 0 Then
                Response.Write("<script language=javascript>document.location.href='DocumentsGetFiles.aspx?CatId=" & CatId & "&ModId=" & ModId & "&H=" & HasEditAuth & "&Done=1" & "';</script>")
            End If

        Catch ex As Exception
            Response.Write("error...")
        End Try


    End Sub

End Class
