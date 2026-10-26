Imports System
Imports System.data
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.web
Imports System.Collections

Public Class TimesheetEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents HeaderText As System.Web.UI.WebControls.Label
    Protected WithEvents SubText2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlUsers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents SubText3 As System.Web.UI.WebControls.Label

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
    Private oLanguageText As New clsLanguageText
    Private al As New ArrayList
    Private ModId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("iID") Is Nothing) Then
            Me.m_iID = CInt(Request.Params("iID"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        al = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")

        If Not Page.IsPostBack Then
            Dim oTimesheet As New clsCalendar(ModId)
            Dim dsUserRoles As New System.data.DataSet
            dsUserRoles = oTimesheet.GetAllUsers
            Dim l As ListItem
            Dim dr As DataRow
            For Each dr In dsUserRoles.Tables(0).Rows
                l = New ListItem
                l.Text = IIf(IsDBNull(dr("usr_firstname")), "", dr("usr_firstname")) & " " & IIf(IsDBNull(dr("usr_lastname")), "", dr("usr_lastname"))
                l.Value = dr("usr_id")
                ddlUsers.Items.Add(l)
            Next
            'txtRole.Text = "role1"
            Call FixStyles()
            Call LoadRoleUsers()
            ViewState("UrlReferrer") = "~/icm.aspx?PageId=" & oSite.ActivePage.PageId
        End If

        HeaderText.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_header"))
        SubText2.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_users"))
        SubText3.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_addedusers"))

    End Sub

    Private Sub LoadRoleUsers()
        Dim oTimesheet As New clsCalendar(ModId)
        Dim dsUserRoles As New System.data.DataSet
        dsUserRoles = oTimesheet.GetAllUsers
        Dim Users() As String
        For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
            If _mod.ModuleId = ModId Then Users = Split(_mod.EditSrc, ";")
        Next
        ListBox1.Items.Clear()
        For Each dr As DataRow In dsUserRoles.Tables(0).Rows
            For Each s As String In Users
                If s.Length > 0 And s.ToLower = CType(dr("usr_id"), String).ToLower Then ListBox1.Items.Add(New ListItem(CType(dr("usr_firstname"), String) & " " & CType(dr("usr_lastname"), String), s))
            Next
        Next
    End Sub

    Private Sub FixStyles()
        btnDelete.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_delete"))
        btnDelete.CssClass = "iCWebControlsII"
        btnAdd.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_add"))
        btnAdd.CssClass = "iCWebControlsII"
        btnOk.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_ok"))
        btnOk.CssClass = "iCWebControlsII"
        btnCancel.Text = Server.HtmlDecode(oLanguageText.Find(al, "timesheet_cancel"))
        btnCancel.CssClass = "iCWebControlsII"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim Users As String
        Dim _Users() As String
        Dim Exist As Boolean = False
        For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
            If _mod.ModuleId = ModId Then Users = _mod.EditSrc : _Users = Split(_mod.EditSrc, ";")
        Next
        For Each s As String In _Users
            If s = ddlUsers.SelectedItem.Value Then Exist = True
        Next
        If Not Exist Then Users += ddlUsers.SelectedItem.Value & ";"
        Dim oTimesheet As New clsCalendar(ModId)
        If Not oTimesheet.UpdateModuleUsers(oSite.ActivePage.PageId, ModId, Users) Then

        End If
        HttpContext.Current.Items("SiteSettings") = New clsSiteSettings(0, oSite.ActivePage.PageId)
        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Call LoadRoleUsers()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim Users As String
        Dim _Users() As String
        Dim Exist As Boolean = False
        For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
            If _mod.ModuleId = ModId Then Users = _mod.EditSrc : _Users = Split(_mod.EditSrc, ";")
        Next
        Dim nn As String
        For Each s As String In _Users
            If Not s = ListBox1.SelectedValue And s.Length > 0 Then nn += s & ";"
        Next
        Users = nn
        Dim oTimesheet As New clsCalendar(ModId)
        If Not oTimesheet.UpdateModuleUsers(oSite.ActivePage.PageId, ModId, Users) Then

        End If
        HttpContext.Current.Items("SiteSettings") = New clsSiteSettings(0, oSite.ActivePage.PageId)
        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Call LoadRoleUsers()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Dim Users As String
            Dim _Users() As String
            Dim Exist As Boolean = False
            For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
                If _mod.ModuleId = ModId Then Users = _mod.EditSrc : _Users = Split(_mod.EditSrc, ";")
            Next
            Dim nn As String
            For Each s As String In _Users
                If Not s = ListBox1.SelectedValue And s.Length > 0 Then nn += s & ";"
            Next
            Users = nn
            Dim oTimesheet As New clsCalendar(ModId)
            If Not oTimesheet.UpdateModuleUsers(oSite.ActivePage.PageId, ModId, Users) Then

            End If
            HttpContext.Current.Items("SiteSettings") = New clsSiteSettings(0, oSite.ActivePage.PageId)
            oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Call LoadRoleUsers()
        End If
    End Sub
End Class
