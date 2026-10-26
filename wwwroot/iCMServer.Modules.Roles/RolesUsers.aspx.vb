Imports System
Imports System.data
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.web
Imports System.Collections

Public Class RolesUsers
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtRole As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlUsers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents userRoles As System.Web.UI.WebControls.DataList
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents HeaderText As System.Web.UI.WebControls.Label
    Protected WithEvents SubText1 As System.Web.UI.WebControls.Label
    Protected WithEvents SubText2 As System.Web.UI.WebControls.Label
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

    Private m_iID As Integer = -1
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oRoles As New clsRoles
    Private oLanguageText As New clsLanguageText
    Private al As New ArrayList
    Private ModId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles(oSite.ActivePage.AuthorizedRoles) = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        If Not (Request.Params("iID") Is Nothing) Then
            Me.m_iID = CInt(Request.Params("iID"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        al = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Roles")

        If Not Page.IsPostBack Then
            Dim dsUserRoles As New System.data.DataSet
            dsUserRoles = oRoles.GetAllUsers
            Dim l As ListItem
            Dim dr As DataRow
            For Each dr In dsUserRoles.Tables(0).Rows
                l = New ListItem
                l.Text = IIf(IsDBNull(dr("usr_firstname")), "", dr("usr_firstname")) & " " & IIf(IsDBNull(dr("usr_lastname")), "", dr("usr_lastname"))
                l.Value = dr("usr_id")
                ddlUsers.Items.Add(l)
            Next
            Call GetRoleInfo()
            Call FixStyles()
            Call LoadRoleUsers()
            Dim adminIndex As Integer = oSite.DesktopPages.Count - 1
            ViewState("UrlReferrer") = "~/icm.aspx?PageId=" & CType(oSite.DesktopPages(adminIndex), clsPageStripDetails).PageId & "&ExpId=" & ModId
        End If

        HeaderText.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_headertext"))
        SubText1.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_subtext1"))
        SubText2.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_subtext2"))

    End Sub

    Private Sub GetRoleInfo()
        Dim dsUser As New DataSet
        dsUser = oRoles.GetRoleFromID(Me.m_iID)
        txtRole.Text = dsUser.Tables(0).Rows(0)("rol_name")
    End Sub

    Private Sub LoadRoleUsers()
        Dim dsRoles As New DataSet
        dsRoles = oRoles.GetUsersFromID(Me.m_iID)
        If dsRoles.Tables.Count > 0 Then
            If dsRoles.Tables(0).Rows.Count > 0 Then
                userRoles.DataSource = dsRoles
            End If
        End If
        userRoles.DataBind()
    End Sub

    Private Sub FixStyles()
        btnAdd.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_add3"))
        btnAdd.CssClass = "iCWebControlsII"
        btnOk.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_okok"))
        btnOk.CssClass = "iCWebControlsII"
        btnCancel.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_editcancel"))
        btnCancel.CssClass = "iCWebControlsII"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not oRoles.InsertRoleToUser(Me.m_iID, ddlUsers.SelectedItem.Value) Then

        End If
        Call LoadRoleUsers()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

    Private Sub UserRoles_ItemCommand(ByVal sender As Object, ByVal e As DataListCommandEventArgs) Handles userRoles.ItemCommand
        If Not oRoles.RemoveRoleFromUser(Me.m_iID, userRoles.DataKeys(e.Item.ItemIndex)) Then

        End If
        userRoles.EditItemIndex = -1
        Call LoadRoleUsers()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub
End Class
