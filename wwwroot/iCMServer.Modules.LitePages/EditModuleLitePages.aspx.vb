
Imports System.web
Imports System.Collections
Imports System.data
Imports System.Web.UI.WebControls

Public Class EditModuleLitePages
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents moduleTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents moduleDataSource As System.Web.UI.WebControls.TextBox
    Protected WithEvents cacheTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents authEditRoles As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ApplyButton As System.Web.UI.WebControls.LinkButton
    Private PageId As Integer = 0
    Private ModId As Integer = 0
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button

    Private oCrypto As New iConsulting.iCMServer.clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oDO As New iCDataManager.iCDataObject
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Protected WithEvents rbShow1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbShow2 As System.Web.UI.WebControls.RadioButton

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
        If Not (Request.Params("ModID") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModID"))
        End If

        ' Let an admin preview a named lite-page template inline, so they can
        ' see how it renders before applying it to this module.
        If Not (Request.Params("PreviewTemplate") Is Nothing) Then
            Dim oPag As New clsLitePages
            Response.Write(oPag.RenderNamedLiteTemplate(Request.Params("PreviewTemplate")))
        End If

        If Not (Request.Params("PreviewTemplateSafe") Is Nothing) Then
            Dim oPagSafe As New clsLitePages
            Response.Write(oPagSafe.RenderNamedLiteTemplateSafe(Request.Params("PreviewTemplateSafe")))
        End If

        ' Remember which template an admin last chose on LitePages.ascx, so it
        ' can be re-rendered here later (ReopenTemplate=1) without the name
        ' round-tripping through the querystring a second time.
        If Not (Request.Params("ReopenTemplate") Is Nothing) Then
            If Request.Params("ReopenTemplate") = "1" Then
                Dim oPagReopen As New clsLitePages
                oPagReopen.RenderRememberedTemplate(ModId, CStr(Session("LitePagesLastTemplate" & ModId)), Response)
            End If
        End If

        If Not (Request.Params("ReopenTemplateSafe") Is Nothing) Then
            If Request.Params("ReopenTemplateSafe") = "1" Then
                Dim oPagReopenSafe As New clsLitePages
                oPagReopenSafe.RenderRememberedTemplateSafe(ModId, CStr(Session("LitePagesLastTemplate" & ModId)), Response)
            End If
        End If

        If Not Page.IsPostBack Then
            btnSave.Text = "Spara"
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oPag As New clsLitePages
        Dim value As Object = oPag.GetModule(ModId)
        If Not (value Is Nothing) Then
            Dim m As clsModuleSettings = CType(value, clsModuleSettings)

            ' Update Textbox Settings
            moduleTitle.Text = m.ModuleTitle
            cacheTime.Text = m.CacheTime.ToString()

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

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

        Dim oPag As New clsLitePages
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

            If Not oPag.UpdateModule(ModId, m.ModuleOrder, m.ModuleFieldName, moduleTitle.Text, Int32.Parse(cacheTime.Text), editRoles, rbShow1.Checked) Then

            End If

            ' Update Textbox Settings
            moduleTitle.Text = m.ModuleTitle
            cacheTime.Text = m.CacheTime.ToString()

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

            Response.Redirect(("EditLitePages.aspx?PageId=" & PageId))
        End If
    End Sub
End Class
