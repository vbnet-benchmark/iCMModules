Imports System
Imports System.data
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.web
Imports System.Collections

Public Class Template007Edit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents HeaderText As System.Web.UI.WebControls.Label
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblSmtp As System.Web.UI.WebControls.Label
    Protected WithEvents lblPrefix As System.Web.UI.WebControls.Label
    Protected WithEvents lblUsers As System.Web.UI.WebControls.Label
    Protected WithEvents txtSmtp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrefix As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsers As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMail As System.Web.UI.WebControls.Label
    Protected WithEvents txtMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNotice As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private ModId As Integer = 0
    Private PageId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oLanguageText As New clsLanguageText
            Dim al As ArrayList = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template007")
            Dim oTemplate007 As New clsTemplate007(ModId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModId))
            Dim ds As DataSet = oTemplate007.GetTemplate

            txtSmtp.Text = String.Empty
            txtMail.Text = String.Empty
            txtPrefix.Text = String.Empty
            txtUsers.Text = String.Empty

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    txtSmtp.Text = ds.Tables(0).Rows(0)("tem_smtpserver")
                    txtMail.Text = ds.Tables(0).Rows(0)("tem_smtpmail")
                    txtPrefix.Text = ds.Tables(0).Rows(0)("tem_subjectprefix")
                    txtUsers.Text = ds.Tables(0).Rows(0)("tem_users")
                End If
            End If

            HeaderText.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_header"))
            lblSmtp.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_smtp"))
            lblMail.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_default"))
            lblPrefix.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_prefix"))
            lblUsers.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_users"))
            lblNotice.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_notice"))
            btnOk.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_ok"))
            btnCancel.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_cancel"))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate007 As New clsTemplate007(ModId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModId))
            oTemplate007.UpdateTemplate(txtSmtp.Text, txtMail.Text, txtPrefix.Text, txtUsers.Text)
            Response.Redirect("~/icm.aspx?PageId=" & PageId & "&ExpId=" & ModId)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PageId & "&ExpId=" & ModId)
    End Sub

End Class
