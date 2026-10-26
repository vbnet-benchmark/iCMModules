Imports iConsulting.iCMServer.iCDataManager
Imports iConsulting.iCMServer.Components.iCDataGrid
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class LiteDocuments : Inherits clsSiteModuleControl

    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLanguageText As New clsLanguageText
    Protected WithEvents ddCatalogs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgContent As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEdit As System.Web.UI.WebControls.Button
    Protected WithEvents btnDel As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents NewCatName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpload As System.Web.UI.WebControls.Button
    Private al As New ArrayList
    Protected WithEvents ibtnBack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtCatalog As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCatalog As System.Web.UI.WebControls.Label
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Private bHasEditPermission As Boolean

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

        bHasEditPermission = clsSiteSecurity.HasEditPermissions(ModuleId)

        If Not Page.IsPostBack Then
            Dim oDoc As New clsLiteDocuments
            oDoc.GetCatalogs(ModuleConfiguration.PageId, ModuleId, ddCatalogs)
            dgContent.DataSource = oDoc.GetCatalogsAndFiles(ModuleConfiguration.PageId, ModuleId, 0)
            dgContent.DataBind()
            Call AddAttributes()
            Call AddClientControls()
        End If

        Call FixPictures(bHasEditPermission)

        btnAdd.Visible = bHasEditPermission
        btnEdit.Visible = bHasEditPermission
        btnDel.Visible = bHasEditPermission
        btnUpload.Visible = bHasEditPermission

        Call Switch(True)

    End Sub

    Private Sub AddAttributes()
        btnDel.Attributes.Add("onclick", "return confirm('Vill du verkligen radera denna mapp?');")
        btnCancel.Attributes.Add("onclick", "window.history.go(-1);")
    End Sub

    Private Sub AddClientControls()

    End Sub

    Private Sub FixPictures(ByVal bEdit As Boolean)
        Dim iRowIndex As Integer = 0
        For iRowIndex = 0 To dgContent.Items.Count - 1
            If CType(dgContent.Items(iRowIndex).Cells(2).Text, Boolean) Then
                dgContent.Items(iRowIndex).Cells(0).Controls.Clear()
                Dim im As New System.Web.UI.WebControls.Image
                If bEdit Then
                    im = New System.Web.UI.WebControls.Image
                    im.ImageAlign = ImageAlign.Top
                    im.Height = im.Height.Pixel(12)
                    im.Width = im.Width.Pixel(12)
                    im.ImageUrl = "Images/edit.gif"
                    im.Style.Add("cursor", "hand")
                    im.Attributes.Add("onclick", "document.location.href='Desktop/Modules/LiteDocuments/LiteDocumentsUpload.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CatId=" & ddCatalogs.SelectedValue & "&DocId=" & dgContent.Items(iRowIndex).Cells(4).Text & "'")
                    im.EnableViewState = True
                    dgContent.Items(iRowIndex).Cells(0).Controls.Add(im)
                End If
                im = New System.Web.UI.WebControls.Image
                im.ImageAlign = ImageAlign.Top
                im.Height = im.Height.Pixel(14)
                im.Width = im.Width.Pixel(14)
                im.ImageUrl = "Images/html.gif"
                im.EnableViewState = True
                dgContent.Items(iRowIndex).Cells(0).Controls.Add(im)
            Else
                dgContent.Items(iRowIndex).Cells(0).Controls.Clear()
                Dim im As New System.Web.UI.WebControls.Image
                If bEdit Then
                    im = New System.Web.UI.WebControls.Image
                    im.ImageAlign = ImageAlign.Top
                    im.Height = im.Height.Pixel(12)
                    im.Width = im.Width.Pixel(12)
                    im.ImageUrl = "Images/none.gif"
                    im.EnableViewState = True
                    dgContent.Items(iRowIndex).Cells(0).Controls.Add(im)
                End If
                im = New System.Web.UI.WebControls.Image
                im.ImageAlign = ImageAlign.Top
                im.Height = im.Height.Pixel(13)
                im.Width = im.Width.Pixel(15)
                im.ImageUrl = "Images/folder.gif"
                im.EnableViewState = True
                dgContent.Items(iRowIndex).Cells(0).Controls.Add(im)
            End If
        Next
    End Sub

    Private Sub dgContent_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgContent.ItemCommand
        If e.CommandName = "XXX" Then
            Dim oDoc As New clsLiteDocuments
            If CType(dgContent.Items(e.Item.ItemIndex).Cells(2).Text, Boolean) Then
                Dim sUrl As String = "Desktop/Modules/LiteDocuments/LiteDocumentsView.aspx?PageId=" & ModuleConfiguration.PageId & "&CatId=" & ddCatalogs.SelectedValue & "&ModId=" & ModuleId & "&DocId=" & dgContent.Items(e.Item.ItemIndex).Cells(4).Text
                Response.Write("<script>window.open('" & sUrl & "')</script>")
            Else
                Call DataBindControls(ModuleConfiguration.PageId, ModuleId, dgContent.DataKeys(e.Item.ItemIndex), bHasEditPermission)
            End If
        End If
    End Sub

    Private Sub ddCatalogs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCatalogs.SelectedIndexChanged
        If ddCatalogs.SelectedIndex <> -1 Then
            Dim oDoc As New clsLiteDocuments
            Call DataBindControls(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue, bHasEditPermission)
        End If
    End Sub

    Public Sub dgContent_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgContent.ItemDataBound

    End Sub

    Private Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        If ddCatalogs.SelectedIndex <> -1 Then
            Dim oDoc As New clsLiteDocuments
            If Not oDoc.DeleteCatalog(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue) Then

            End If
            Call DataBindControls(ModuleConfiguration.PageId, ModuleId, 0, bHasEditPermission)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtCatalog.Text = "Ny Mapp"
        Call Switch(False)
        btnCancel.Visible = True
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Len(txtCatalog.Text) > 0 And Not Trim(txtCatalog.Text) = "" Then
            Call Switch(True)
            If ddCatalogs.SelectedIndex <> -1 Then
                Dim oDoc As New clsLiteDocuments
                If Not oDoc.AddCatalog(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue, txtCatalog.Text) Then

                End If
                Call DataBindControls(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue, bHasEditPermission)
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ddCatalogs.SelectedIndex > 0 Then
            Dim sName As String = "Nytt namn"
            If Len(ddCatalogs.SelectedItem.Text) > 2 Then sName = Right(ddCatalogs.SelectedItem.Text, Len(ddCatalogs.SelectedItem.Text) - 2)
            txtCatalog.Text = sName
            Call Switch(False)
            btnOk.Visible = False
            btnUpdate.Visible = True
            btnCancel.Visible = True
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(txtCatalog.Text) > 0 Then
            If ddCatalogs.SelectedIndex <> -1 Then
                Dim oDoc As New clsLiteDocuments
                If Not oDoc.UpdateCatalog(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue, txtCatalog.Text) Then

                End If
                Call DataBindControls(ModuleConfiguration.PageId, ModuleId, ddCatalogs.SelectedValue, bHasEditPermission)
            End If
            Call Switch(True)
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If ddCatalogs.SelectedIndex <> -1 Then
            Response.Redirect("~/Desktop/Modules/LiteDocuments/LiteDocumentsUpload.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CatId=" & ddCatalogs.SelectedValue)
        End If
    End Sub

    Private Sub ibtnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBack.Click
        If ddCatalogs.SelectedIndex <> -1 And Not ddCatalogs.SelectedValue = 0 Then
            Dim oDoc As New clsLiteDocuments
            Dim i As Integer = ddCatalogs.Items(ddCatalogs.SelectedIndex - 1).Value
            If i < 0 Then i = 0
            Call DataBindControls(ModuleConfiguration.PageId, ModuleId, i, bHasEditPermission)
        End If
    End Sub

    Private Sub DataBindControls(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal HasEditPermission As Boolean)
        Dim oDoc As New clsLiteDocuments
        oDoc.GetCatalogs(PageId, ModId, ddCatalogs, CatId)
        dgContent.DataSource = oDoc.GetCatalogsAndFiles(PageId, ModId, CatId)
        dgContent.DataBind()
        Call FixPictures(HasEditPermission)
        Call Switch(True)
    End Sub

    Private Sub Switch(ByVal DefaultMode As Boolean)
        If DefaultMode Then
            btnOk.Visible = False
            txtCatalog.Visible = False
            lblCatalog.Visible = False
            btnAdd.Visible = bHasEditPermission
            btnEdit.Visible = bHasEditPermission
            btnDel.Visible = bHasEditPermission
            btnUpload.Visible = bHasEditPermission
            btnUpdate.Visible = False
            btnCancel.Visible = False
        Else
            btnOk.Visible = True
            txtCatalog.Visible = True
            lblCatalog.Visible = True
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnDel.Visible = False
            btnUpload.Visible = False
            btnUpdate.Visible = False
            btnCancel.Visible = False
        End If
    End Sub

End Class