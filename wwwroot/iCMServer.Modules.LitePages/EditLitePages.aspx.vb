Imports System
Imports System.data
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.web
Imports System.Collections
Public Class EditLitePages : Inherits System.Web.UI.Page

    Private oCrypto As New iConsulting.iCMServer.clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oDO As New iCDataManager.iCDataObject
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private PageID As Integer = 0
    Protected leftList As ArrayList
    Protected contentList As ArrayList
    Protected rightList As ArrayList
    Protected IsAdmin As Boolean

    Protected WithEvents PageName As System.Web.UI.WebControls.TextBox
    Protected WithEvents authRoles As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents moduleType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents moduleTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents LeftUpBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LeftRightBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LeftDownBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LeftEditBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LeftDeleteBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentUpBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentLeftBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentRightBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentDownBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentEditBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ContentDeleteBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RightUpBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RightLeftBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RightDownBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RightEditBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RightDeleteBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents LeftModuleField As System.Web.UI.WebControls.ListBox
    Protected WithEvents ContentModuleField As System.Web.UI.WebControls.ListBox
    Protected WithEvents RightModuleField As System.Web.UI.WebControls.ListBox
    Protected WithEvents ddlV As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlH As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles("Superadmin;Admins") = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not Page.IsPostBack Then
            btnSave.Text = "Spara"
            btnAdd.Text = "Lägg till modulen"
            If PageID = 0 Then
                Dim oPag As New clsLitePages
                Dim _PageId As Integer = oPag.AddPage
                Dim _Url As String = Left(Request.RawUrl, Len(Request.RawUrl) - InStr(StrReverse(Request.RawUrl), "/")) & "/EditLitePages.aspx?PageID=" & _PageId.ToString
                Response.Redirect(_Url)
            Else
                If LCase(oSite.ActivePage.PageName) = "admin" Then
                    IsAdmin = True
                End If
                Call BindData()
            End If
        End If

    End Sub

    Private Sub BindData()
        Dim Page As clsPageSettings = oSite.ActivePage
        PageName.Text = Page.PageName

        Dim dsRoles As New DataSet
        Dim drRoles As DataRow
        Dim oPag As New clsLitePages
        dsRoles = oPag.GetSiteRoles
        authRoles.Items.Clear()
        Dim allItem As New ListItem
        allItem.Text = "All Users"
        If Page.AuthorizedRoles.LastIndexOf("All Users") > -1 Then
            allItem.Selected = True
        End If

        authRoles.Items.Add(allItem)
        Dim item As New ListItem
        For Each drRoles In dsRoles.Tables(0).Rows
            item = New ListItem
            item.Text = CType(drRoles("rol_name"), String)
            item.Value = drRoles("rol_id").ToString()
            If Page.AuthorizedRoles.LastIndexOf(item.Text) > -1 Then
                item.Selected = True
            End If
            authRoles.Items.Add(item)
        Next

        ' Populate the ModuleFieldWidth
        Call PrepareFieldCombo(False)
        If Page.LeftModuleFieldWidth = "" Then
            ddlV.SelectedValue = 0
        Else
            ddlV.SelectedValue = CType(Page.LeftModuleFieldWidth, Integer)
        End If
        If Page.RightModuleFieldWidth = "" Then
            ddlH.SelectedValue = 0
        Else
            ddlH.SelectedValue = CType(Page.RightModuleFieldWidth, Integer)
        End If

        ' Populate the "Add Module" Data
        moduleType.DataTextField = "mde_name"
        moduleType.DataValueField = "mde_id"
        moduleType.DataSource = oPag.GetModuleDefinitions
        moduleType.DataBind()

        ' Populate Right Hand Module Data
        rightList = oPag.GetModules("RightModuleField")
        RightModuleField.DataBind()

        ' Populate Content Pane Module Data
        contentList = oPag.GetModules("ContentModuleField")
        ContentModuleField.DataBind()

        ' Populate Left Hand Pane Module Data
        leftList = oPag.GetModules("LeftModuleField")
        LeftModuleField.DataBind()

    End Sub

    Private Sub SavePageData()
        Dim authorizedRoles As String = "Superadmin;Admins;"
        Dim item As ListItem
        Dim oPag As New clsLitePages

        For Each item In authRoles.Items
            If item.Selected = True Then
                authorizedRoles += item.Text & ";"
            End If
        Next item

        If Not oPag.UpdatePage(PageID, PageName.Text, oSite.ActivePage.PageOrder, authorizedRoles, ddlV.SelectedValue, ddlH.SelectedValue) Then

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SavePageData()
        Dim adminIndex As Integer = oSite.DesktopPages.Count - 1
        Response.Redirect(("~/icm.aspx?Index=" & adminIndex.ToString() & "&PageId=" & CType(oSite.DesktopPages(adminIndex), clsPageStripDetails).PageId))
    End Sub

    Private Sub PageSettings_Change(ByVal sender As Object, ByVal e As EventArgs) Handles authRoles.SelectedIndexChanged, PageName.TextChanged
        Call SavePageData()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' All new modules go to the end of the contentpane
        Dim m As New clsModuleItem
        m.ModuleTitle = moduleTitle.Text
        m.ModuleDefId = Int32.Parse(moduleType.SelectedItem.Value)
        m.ModuleOrder = 999

        Dim oPag As New clsLitePages
        m.ModuleId = oPag.AddModule(PageID, m.ModuleOrder, "ContentModuleField", m.ModuleTitle, m.ModuleDefId, 0, "Admins;Superadmin")

        HttpContext.Current.Items("SiteSettings") = New clsSiteSettings(oSite.SiteId, PageID)

        ' reorder the modules in the content pane
        Dim modules As ArrayList = oPag.GetModules("ContentModuleField")
        If Not oPag.OrderModules(modules) Then

        End If

        ' resave the order
        Dim item As clsModuleItem
        For Each item In modules
            If Not oPag.UpdateModuleOrder(item.ModuleId, item.ModuleOrder, "ContentModuleField") Then

            End If
        Next item

        Response.Redirect(Request.RawUrl)
    End Sub

    Private Sub UpDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LeftDownBtn.Click, LeftUpBtn.Click, ContentDownBtn.Click, ContentUpBtn.Click, RightDownBtn.Click, RightUpBtn.Click

        Dim cmd As String = CType(sender, ImageButton).CommandName
        Dim pane As String = CType(sender, ImageButton).CommandArgument
        Dim _listbox As ListBox = CType(Page.FindControl(pane), ListBox)
        Dim oPag As New clsLitePages
        Dim modules As ArrayList = oPag.GetModules(pane)

        If _listbox.SelectedIndex <> -1 Then
            Dim delta As Integer
            Dim selection As Integer = -1

            If cmd = "down" Then
                delta = 3
                If _listbox.SelectedIndex < _listbox.Items.Count - 1 Then
                    selection = _listbox.SelectedIndex + 1
                End If
            Else
                delta = -3
                If _listbox.SelectedIndex > 0 Then
                    selection = _listbox.SelectedIndex - 1
                End If
            End If

            Dim m As clsModuleItem
            m = CType(modules(_listbox.SelectedIndex), clsModuleItem)
            m.ModuleOrder += delta

            ' reorder the modules in the content pane
            If Not oPag.OrderModules(modules) Then

            End If

            ' resave the order
            Dim item As clsModuleItem
            For Each item In modules
                If Not oPag.UpdateModuleOrder(item.ModuleId, item.ModuleOrder, pane) Then

                End If
            Next item

        End If

        Response.Redirect(Request.RawUrl)

    End Sub

    Private Sub RightLeft_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LeftRightBtn.Click, ContentLeftBtn.Click, ContentRightBtn.Click, RightLeftBtn.Click

        Dim sourcePane As String = CType(sender, ImageButton).Attributes("sourcepane")
        Dim targetPane As String = CType(sender, ImageButton).Attributes("targetpane")
        Dim sourceBox As ListBox = CType(Page.FindControl(sourcePane), ListBox)
        Dim targetBox As ListBox = CType(Page.FindControl(targetPane), ListBox)
        Dim oPag As New clsLitePages

        If sourceBox.SelectedIndex <> -1 Then

            ' get source arraylist
            Dim sourceList As ArrayList = oPag.GetModules(sourcePane)

            ' get a reference to the module to move
            ' and assign a high order number to send it to the end of the target list
            Dim m As clsModuleItem = CType(sourceList(sourceBox.SelectedIndex), clsModuleItem)

            ' add it to the database
            If Not oPag.UpdateModuleOrder(m.ModuleId, 998, targetPane) Then

            End If

            ' delete it from the source list
            sourceList.RemoveAt(sourceBox.SelectedIndex)

            ' reload the _portalSettings from the database
            HttpContext.Current.Items("SiteSettings") = New clsSiteSettings(oSite.SiteId, PageID)

            ' reorder the modules in the source pane
            sourceList = oPag.GetModules(sourcePane)
            If Not oPag.OrderModules(sourceList) Then

            End If

            ' resave the order
            Dim item As clsModuleItem
            For Each item In sourceList
                If Not oPag.UpdateModuleOrder(item.ModuleId, item.ModuleOrder, sourcePane) Then

                End If
            Next item

            ' reorder the modules in the target pane
            Dim targetList As ArrayList = oPag.GetModules(targetPane)
            If Not oPag.OrderModules(targetList) Then

            End If

            ' resave the order
            For Each item In targetList
                If Not oPag.UpdateModuleOrder(item.ModuleId, item.ModuleOrder, targetPane) Then

                End If
            Next item

            ' Redirect to the same page to pick up changes
            Response.Redirect(Request.RawUrl)
        End If

    End Sub

    Private Sub DeleteBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LeftDeleteBtn.Click, ContentDeleteBtn.Click, RightDeleteBtn.Click

        Dim pane As String = CType(sender, ImageButton).CommandArgument
        Dim _listbox As ListBox = CType(Page.FindControl(pane), ListBox)
        Dim oPag As New clsLitePages
        Dim modules As ArrayList = oPag.GetModules(pane)

        If _listbox.SelectedIndex <> -1 Then

            Dim m As clsModuleItem = CType(modules(_listbox.SelectedIndex), clsModuleItem)
            If m.ModuleId > -1 Then
                If Not oPag.DeleteModule(m.ModuleId) Then

                End If
            End If

        End If

        ' Redirect to the same page to pick up changes
        Response.Redirect(Request.RawUrl)

    End Sub

    Private Sub EditBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LeftEditBtn.Click, ContentEditBtn.Click, RightEditBtn.Click

        Dim pane As String = CType(sender, ImageButton).CommandArgument
        Dim _listbox As ListBox = CType(Page.FindControl(pane), ListBox)

        If _listbox.SelectedIndex <> -1 Then

            Dim ModId As Integer = Int32.Parse(_listbox.SelectedItem.Value)

            ' Redirect to module settings page
            Response.Redirect(("EditModuleLitePages.aspx?ModId=" & ModId & "&PageId=" & PageID))

        End If

    End Sub

    Private Sub PrepareFieldCombo(ByVal Selected As Boolean)
        Dim i As Integer
        For i = 0 To 1000
            ddlV.Items.Add(i.ToString)
            ddlH.Items.Add(i.ToString)
        Next
        If Selected Then
            ddlV.SelectedValue = 0
            ddlH.SelectedValue = 0
        End If
    End Sub

End Class
