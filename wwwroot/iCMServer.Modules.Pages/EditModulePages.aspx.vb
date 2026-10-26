
Imports System.web
Imports System.Collections
Imports System.data
Imports System.Web.UI.WebControls

Public Class EditModulePages
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents moduleTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents moduleDataSource As System.Web.UI.WebControls.TextBox
    Protected WithEvents authEditRoles As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ApplyButton As System.Web.UI.WebControls.LinkButton
    Private PageId As Integer = 0
    Private ModId As Integer = 0
    Private ExpId As Integer = 0
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button

    Public oLang As New clsLanguageText
    Public al As New ArrayList
    Private oCrypto As New iConsulting.iCMServer.clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oDO As New iCDataManager.iCDataObject
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Protected WithEvents rbShow1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbShow2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbVisible1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbVisible2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCache As System.Web.UI.WebControls.Label
    Protected WithEvents lblRoles As System.Web.UI.WebControls.Label
    Protected WithEvents lblShowtitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblIsVisible As System.Web.UI.WebControls.Label
    Protected WithEvents lblAlign As System.Web.UI.WebControls.Label
    Protected WithEvents lblBorder As System.Web.UI.WebControls.Label
    Protected WithEvents ddCache As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddAlign As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddBorder As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblColor As System.Web.UI.WebControls.Label
    Protected WithEvents bColor As System.Web.UI.WebControls.TextBox
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

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles("Superadmin;Admins") = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("PageID") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageID"))
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("ExpId") Is Nothing) Then
            ExpId = Int32.Parse(Request.Params("ExpId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oPag As New clsPages
        Dim value As Object = oPag.GetModule(ModId)

        If Not (value Is Nothing) Then
            Dim i As Integer = 0
            Dim m As clsModuleSettings = CType(value, clsModuleSettings)

            al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Pages")
            btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "pages__cancel"))
            btnSave.Text = Server.HtmlDecode(oLang.Find(al, "pages__ok"))
            btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "pages__update"))
            rbShow1.Text = Server.HtmlDecode(oLang.Find(al, "modedit_yes"))
            rbShow2.Text = Server.HtmlDecode(oLang.Find(al, "modedit_no"))
            lblCache.Text = Server.HtmlDecode(oLang.Find(al, "modedit_cache"))
            lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "modedit_header"))
            lblName.Text = Server.HtmlDecode(oLang.Find(al, "modedit_name"))
            lblRoles.Text = Server.HtmlDecode(oLang.Find(al, "modedit_roles"))
            lblShowtitle.Text = Server.HtmlDecode(oLang.Find(al, "modedit_showtitle"))
            lblIsVisible.Text = Server.HtmlDecode(oLang.Find(al, "modedit_visible"))
            rbVisible1.Text = Server.HtmlDecode(oLang.Find(al, "modedit_yes"))
            rbVisible2.Text = Server.HtmlDecode(oLang.Find(al, "modedit_no"))
            lblAlign.Text = Server.HtmlDecode(oLang.Find(al, "modedit_align"))
            lblBorder.Text = Server.HtmlDecode(oLang.Find(al, "modedit_border"))
            lblColor.Text = Server.HtmlDecode(oLang.Find(al, "modedit_color"))

            'bColor.Attributes.Add("onclick", "ChangeColor();")
            bColor.Text = IIf(m.Color = "", "n/a", m.Color)

            ddAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "modedit_alignleft")), "left"))
            ddAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "modedit_alignmiddle")), "middle"))
            ddAlign.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "modedit_alignright")), "right"))
            Select Case m.Alignment
                Case "left"
                    ddAlign.Items(0).Selected = True
                Case "middle"
                    ddAlign.Items(1).Selected = True
                Case "right"
                    ddAlign.Items(2).Selected = True
                Case Else
                    ddAlign.Items(1).Selected = True
            End Select

            For i = 0 To 10
                ddBorder.Items.Add(i.ToString)
            Next
            Select Case m.Border
                Case ""
                    ddBorder.Items(0).Selected = True
                Case "0"
                    ddBorder.Items(0).Selected = True
                Case Else
                    ddBorder.Items(m.Border).Selected = True
            End Select

            If Not m.Hidden Then
                rbVisible1.Checked = True
                rbVisible2.Checked = False
            Else
                rbVisible1.Checked = False
                rbVisible2.Checked = True
            End If

            ' Update Textbox Settings
            moduleTitle.Text = m.ModuleTitle

            For i = 0 To 3600
                ddCache.Items.Add(i.ToString)
            Next
            Dim c As Integer = m.CacheTime
            ddCache.Items(c).Selected = True

            If m.ShowTitle Then
                rbShow1.Checked = True
                rbShow2.Checked = False
            Else
                rbShow1.Checked = False
                rbShow2.Checked = True
            End If

            ' Populate checkbox list with all security roles for this portal
            ' and "check" the ones already configured for this module
            Dim roles As New DataSet
            Dim dr As DataRow
            roles = oPag.GetSiteRoles


            ' Clear existing items in checkboxlist
            authEditRoles.Items.Clear()

            Dim allItem As New ListItem
            allItem.Text = "All Users"

            If m.AuthorizedEditRoles.LastIndexOf("All Users") > -1 Then
                allItem.Selected = True
            End If

            authEditRoles.Items.Add(allItem)

            Dim item As New ListItem
            For Each dr In roles.Tables(0).Rows
                item = New ListItem
                item.Text = CType(dr("rol_name"), String)
                item.Value = dr("rol_id").ToString()
                If m.AuthorizedEditRoles.LastIndexOf(item.Text) > -1 Then
                    item.Selected = True
                End If
                authEditRoles.Items.Add(item)
            Next
        End If
    End Sub

    Private Sub Save()

        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

        Dim oPag As New clsPages
        Dim value As Object = oPag.GetModule(ModId)
        If Not (value Is Nothing) Then
            Dim m As clsModuleSettings = CType(value, clsModuleSettings)

            ' Construct Authorized User Roles String
            Dim editRoles As String = "Superadmin;"

            Dim item As ListItem

            For Each item In authEditRoles.Items

                If item.Selected = True Then
                    editRoles += item.Text & ";"
                End If

            Next item

            If Not oPag.UpdateModule(ModId, m.ModuleOrder, m.ModuleFieldName, moduleTitle.Text, Int32.Parse(ddCache.SelectedValue), editRoles, rbShow1.Checked, rbVisible1.Checked, ddAlign.SelectedValue, ddBorder.SelectedValue, bColor.Text) Then

            End If

            ' Update Textbox Settings
            moduleTitle.Text = m.ModuleTitle
            'cacheTime.Text = m.CacheTime.ToString()

            ' Populate checkbox list with all security roles for this portal
            ' and "check" the ones already configured for this module
            Dim roles As New DataSet
            Dim dr As DataRow
            roles = oPag.GetSiteRoles


            ' Clear existing items in checkboxlist
            authEditRoles.Items.Clear()

            Dim allItem As New ListItem
            allItem.Text = "All Users"

            If m.AuthorizedEditRoles.LastIndexOf("All Users") > -1 Then
                allItem.Selected = True
            End If

            authEditRoles.Items.Add(allItem)

            For Each dr In roles.Tables(0).Rows
                item = New ListItem
                item.Text = CType(dr("rol_name"), String)
                item.Value = dr("rol_id").ToString()
                If m.AuthorizedEditRoles.LastIndexOf(item.Text) > -1 Then
                    item.Selected = True
                End If
                authEditRoles.Items.Add(item)
            Next


        End If
    End Sub

    Private Sub Redirect()
        Dim oPag As New clsPages
        Dim value As Object = oPag.GetModule(ModId)
        If Not (value Is Nothing) Then
            Response.Redirect(("EditPages.aspx?PageId=" & PageId & "&ModId=" & ExpId))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call Save()
        Call Redirect()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Call Save()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect(("EditPages.aspx?PageId=" & PageId & "&ModId=" & ExpId))
    End Sub
End Class
