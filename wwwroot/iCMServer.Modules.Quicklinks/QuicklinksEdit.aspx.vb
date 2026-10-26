
Imports System.Security
Imports System.Security.Principal
Imports System.web
Imports System.Web.Security

Public Class QuicklinksEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblUrl As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents lblOrder As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUrl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrder As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents ddUrl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTarget As System.Web.UI.WebControls.Label
    Protected WithEvents ddTarget As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private QuiId As Integer = 0
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (Request.Params("QuiId") Is Nothing) Then
            QuiId = Int32.Parse(Request.Params("QuiId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Quicklinks")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_title"))
        lblDescription.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_description"))
        lblUrl.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_url"))
        lblOrder.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_order"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_delete"))
        btnDelete.Attributes.Add("onclick", "confirm('" & Server.HtmlDecode(oLang.Find(al, "quicklinks_confirm")) & "');")

        Dim sRoles As String
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("siteroles").Value)
            sRoles = ticket.UserData.ToString & "All Users"
        Else
            sRoles = "All Users"
        End If

        Dim oQuick As New clsQuicklinks
        Dim dsd As New System.Data.DataSet
        Dim drd As System.Data.DataRow
        dsd = oQuick.GetPages(sRoles)
        ddUrl.Items.Add(New System.Web.UI.WebControls.ListItem("n/a", ""))
        For Each drd In dsd.Tables(0).Rows
            If drd("pag_deleted") = False Then
                ddUrl.Items.Add(New System.Web.UI.WebControls.ListItem(drd("pag_name"), "iCM.aspx?PageId=" & drd("pag_id")))
            End If
        Next

        If QuiId = 0 Then
            ViewState("EventUpdate") = False
        Else
            ViewState("EventUpdate") = True
            oQuick = New clsQuicklinks
            Dim ds As New System.Data.DataSet
            ds = oQuick.GetQuicklink(ModId, QuiId, PagId)
            txtTitle.Text = ds.Tables(0).Rows(0)("qui_title")
            txtDescription.Text = ds.Tables(0).Rows(0)("qui_description")
            If InStr(ds.Tables(0).Rows(0)("qui_url"), "|") > 0 Then
                Dim aTemp() As String = Split(ds.Tables(0).Rows(0)("qui_url"), "|")
                txtUrl.Text = aTemp(0)
                If Not IsNothing(aTemp(1)) Then
                    If Len(aTemp(1)) > 0 Then
                        If LCase(aTemp(1)) = "_blank" Then
                            ddTarget.SelectedIndex = 0
                        Else
                            ddTarget.SelectedIndex = 1
                        End If
                    Else
                        ddTarget.SelectedIndex = 0
                    End If
                Else
                    ddTarget.SelectedIndex = 0
                End If

            Else
            txtUrl.Text = ds.Tables(0).Rows(0)("qui_url")
            ddTarget.SelectedIndex = 0
            End If
            txtOrder.Text = ds.Tables(0).Rows(0)("qui_order")
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If ViewState("EventUpdate") = True Then
            Dim oQuick As New clsQuicklinks
            If Trim(txtTitle.Text) = "" Then txtTitle.Text = "n/a"
            If Trim(txtOrder.Text) = "" Then txtOrder.Text = "0"
            If Not oQuick.UpdateQuicklink(ModId, QuiId, PagId, txtTitle.Text, txtDescription.Text, txtUrl.Text, ddTarget.SelectedValue, txtOrder.Text) Then

            End If
            Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
        ElseIf ViewState("EventUpdate") = False Then
            Dim oQuick As New clsQuicklinks
            If Trim(txtTitle.Text) = "" Then txtTitle.Text = "n/a"
            If Trim(txtOrder.Text) = "" Then txtOrder.Text = "0"
            If Not oQuick.AddQuicklink(ModId, PagId, txtTitle.Text, txtDescription.Text, txtUrl.Text, ddTarget.SelectedValue, txtOrder.Text) Then

            End If
            Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ViewState("EventUpdate") = True Then
            Dim oQuick As New clsQuicklinks
            If Not oQuick.DeleteQuicklink(ModId, QuiId, PagId) Then

            End If
            Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
        End If
    End Sub

    Private Sub ddUrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUrl.SelectedIndexChanged
        txtUrl.Text = ddUrl.SelectedValue
    End Sub

    Private Sub Dropdownlist1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddTarget.SelectedIndexChanged

    End Sub
End Class
