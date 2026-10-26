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

    Protected Directory As String
    Protected ModId As Integer = 0
    Protected urlRef As String = ""
    Protected Done As Integer = 0
    Protected Search As String = ""
    Private HasEditAuth As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("Directory") Is Nothing) Then
            Directory = Request.Params("Directory")
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

        If Not (Request.Params("Search") Is Nothing) Then
            Search = Request.Params("Search")
        End If

        ' Remember which attachment the user clicked on, so DocumentsEdit.aspx
        ' can re-open it later (Reopen=1) without the name round-tripping
        ' through the querystring a second time.
        If Not (Request.Params("Remember") Is Nothing) Then
            Session("DocumentsLastFile" & ModId) = Request.Params("Remember")
        End If

        ' Quick-view vs. secure-download attachment flows - both resolve the
        ' requested name through a common base-typed resolver, but each wires
        ' up a different concrete implementation (see clsIcmAttachmentResolverBase
        ' in clsDocuments.vb).
        If Not (Request.Params("Attachment") Is Nothing) Then
            Dim sBaseDir As String = Server.MapPath("Desktop/Modules/DocumentsFromDisk/PreviewFiles/" & ModId.ToString)
            Dim oResolver As clsIcmAttachmentResolverBase = New clsIcmOpenAttachmentResolver
            Dim sResolvedPath As String = oResolver.ResolvePath(sBaseDir, Request.Params("Attachment"))
            Response.ContentType = "application/octet-stream"
            ' SINK: PLANTED-VB-HR-39
            Response.WriteFile(sResolvedPath)
            Response.End()
        End If

        If Not (Request.Params("AttachmentSecure") Is Nothing) Then
            Dim sBaseDirSafe As String = Server.MapPath("Desktop/Modules/DocumentsFromDisk/PreviewFiles/" & ModId.ToString)
            Dim oResolverSafe As clsIcmAttachmentResolverBase = New clsIcmSandboxedAttachmentResolver
            Try
                Dim sResolvedPathSafe As String = oResolverSafe.ResolvePath(sBaseDirSafe, Request.Params("AttachmentSecure"))
                Response.ContentType = "application/octet-stream"
                ' SAFE_SINK: PLANTED-VB-HR-39-safe
                Response.WriteFile(sResolvedPathSafe)
            Catch ex As System.Security.SecurityException
                Response.Write("Access denied.")
            End Try
            Response.End()
        End If

        ' Bulk export of a file nested a few folders deep, named as a comma
        ' separated list of path segments.
        If Not (Request.Params("Bundle") Is Nothing) Then
            Dim oDocBundle As New clsDocuments
            Response.Write("<pre>" & Server.HtmlEncode(oDocBundle.GetMergedExportText(ModId, Request.Params("Bundle"))) & "</pre>")
            Response.End()
        End If

        If Not (Request.Params("BundleSafe") Is Nothing) Then
            Dim oDocBundleSafe As New clsDocuments
            Response.Write("<pre>" & Server.HtmlEncode(oDocBundleSafe.GetMergedExportTextSafe(ModId, Request.Params("BundleSafe"))) & "</pre>")
            Response.End()
        End If

        Try

            'Response.Write("BoundedDirectory = " & Session("BoundedDirectory" & ModId))
            'Response.Write("<br><br>" & Directory)

            urlRef = Server.UrlEncode(Request.UrlReferrer.ToString())

            Dim oDoc As New clsDocuments
            Dim Folder As String
            Dim Files As String = oDoc.GetDocuments(ModId, Directory.Replace("/", "\"), urlRef, "", Folder, HasEditAuth, Search)

            Response.Write("<html><body>")

            Response.Write("<div style='FONT-WEIGHT: bold; FONT-SIZE: 20pt; Z-INDEX: -1; LEFT: 10px; WIDTH: 370px; COLOR: #f7f7f7; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 5px; HEIGHT: 20px'><b>" & Folder & "</b></div>")

            Response.Write("<TABLE WIDTH=100% BORDER=0 CELLSPACING=0 CELLPADDING=0>")

            Response.Write(Files)

            Response.Write("</TABLE>")

            Response.Write("</body></html>")

            If Done = 0 Then
                'Response.Write("<script language=javascript>document.location.href='DocumentsGetFiles.aspx?Directory=" & CatId & "&ModId=" & ModId & "&H=" & HasEditAuth & "&Done=1" & "';</script>")
            End If

        Catch ex As Exception
            'Response.Write("error...")
        End Try


    End Sub

End Class
