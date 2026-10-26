Imports System.Web
Imports System.data
Imports System.Collections

Public Class DiscussionNew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private PagId As Integer = 0
    Private ModId As Integer = 0
    Private DisId As Integer = 0
    Protected sUser As String
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button

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
            PagId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("DisId") Is Nothing) Then
            DisId = Int32.Parse(Request.Params("DisId"))
        End If

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Discussion")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "discussion_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "discussion_subject"))
        lblDescription.Text = Server.HtmlDecode(oLang.Find(al, "discussion_message"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "discussion_post"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "discussion_cancel"))
        sUser = IIf(Len(Trim(HttpContext.Current.User.Identity.Name)) = 0, Server.HtmlDecode(oLang.Find(al, "discussion_unknown")), HttpContext.Current.User.Identity.Name)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim oDis As New clsDiscussion
        If Not oDis.AddThreadMessage(PagId, ModId, txtTitle.Text, txtDescription.Text, DisId, sUser) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & PagId)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PagId)
    End Sub
End Class
