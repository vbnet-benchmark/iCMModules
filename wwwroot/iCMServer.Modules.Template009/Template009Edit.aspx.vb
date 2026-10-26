
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security

Public Class Template009Edit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Browse1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Header As System.Web.UI.WebControls.Label

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
    Private Shared Type As String = String.Empty

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template009")
        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "template009_save"))
        Header.Text = Server.HtmlDecode(oLang.Find(al, "template009_header"))

        ' Look for image in BinaryFileCache...
        Try
            Image1.ImageUrl = "BinaryFileCache/" & "Template009_1__" & ModID.ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
        If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template009_1__" & ModID.ToString, Browse1.PostedFile)
        Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
    End Sub

End Class
