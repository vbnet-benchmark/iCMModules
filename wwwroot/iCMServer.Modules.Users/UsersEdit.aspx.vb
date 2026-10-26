Imports System.Web
Imports System.Data
Imports System.Collections

Public Class UsersEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents lblFirstName As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastName As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblPassWord As System.Web.UI.WebControls.Label
    Protected WithEvents lblConfirm As System.Web.UI.WebControls.Label
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtConfirm As System.Web.UI.WebControls.TextBox
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator

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
    Private oCrypto As New clsCrypto
    Private oUsers As New clsUsers
    Private oLanguageText As New clsLanguageText
    Private al As New ArrayList
    Private UsrId As Integer = 0
    Private ModId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles(oSite.ActivePage.AuthorizedRoles) = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        If Not (Request.Params("UsrId") Is Nothing) Then
            UsrId = Int32.Parse(Request.Params("UsrId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
            Dim adminIndex As Integer = oSite.DesktopPages.Count - 1
            ViewState("UrlReferrer") = "~/icm.aspx?PageId=" & CType(oSite.DesktopPages(adminIndex), clsPageStripDetails).PageId & "&ExpId=" & ModId
        End If

    End Sub

    Private Sub BindData()
        al = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Users")

        lblHeader.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_editheader"))
        lblFirstName.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_forename")) & ":"
        lblLastName.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_lastname")) & ":"
        lblEmail.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_email")) & ":"
        lblPassWord.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_password")) & ":"
        lblConfirm.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_confirmpassword")) & ":"
        lblDescription.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_description")) & ":"
        btnUpdate.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_okok"))
        btnCancel.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_editcancel"))
        btnDelete.Text = Server.HtmlDecode(oLanguageText.Find(al, "users_editdelete"))
        RegularExpressionValidator1.ErrorMessage = Server.HtmlDecode(oLanguageText.Find(al, "users_editemailvalidator"))
        CompareValidator1.ErrorMessage = Server.HtmlDecode(oLanguageText.Find(al, "users_editconfirmvalidator"))

        btnDelete.Attributes.Add("onclick", "return confirm('" & Server.HtmlDecode(oLanguageText.Find(al, "users_confirm")) & "');")

        If Not UsrId = 0 Then
            Dim ds As New DataSet
            ds = oUsers.GetUserFromID(UsrId)
            txtFirstName.Text = ds.Tables(0).Rows(0)("usr_firstname")
            txtLastName.Text = ds.Tables(0).Rows(0)("usr_lastname")
            txtEmail.Text = ds.Tables(0).Rows(0)("usr_email")
            txtPassword.Text = ds.Tables(0).Rows(0)("usr_password")
            txtConfirm.Text = ds.Tables(0).Rows(0)("usr_password")
            txtDescription.Text = ds.Tables(0).Rows(0)("usr_description")
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Page.IsValid Then
            If Not UsrId = 0 Then
                If Not oUsers.UpdateUser(UsrId, txtFirstName.Text, txtLastName.Text, txtEmail.Text, oCrypto.Encrypt(txtPassword.Text), txtDescription.Text) Then

                End If
                Response.Redirect(ViewState("UrlReferrer"))
            Else
                If Not oUsers.AddUser(txtFirstName.Text, txtLastName.Text, txtEmail.Text, oCrypto.Encrypt(txtPassword.Text), txtDescription.Text) Then

                End If
                Response.Redirect(ViewState("UrlReferrer"))
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(ViewState("UrlReferrer"))
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not oUsers.DeleteUser(UsrId) Then

        End If
        Response.Redirect(ViewState("UrlReferrer"))
    End Sub
End Class
