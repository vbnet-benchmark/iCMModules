Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.Components.iCDataGrid
Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class Language : Inherits clsSiteModuleControl

    Protected WithEvents Placeholder1 As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents Placeholder2 As System.Web.UI.WebControls.PlaceHolder
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSiteSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLanguageText As New clsLanguageText
    Private al As New ArrayList

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
        Dim ds As New DataSet
        Dim dg As New DataGrid
        Dim c As New Button
        Dim iCDataGrid As New clsDataGrid(ED, EC, 5, True, CRYPTO_KEY, CRYPTO_IV)

        If Page.IsPostBack Then
            dg = Session("iCDataGridLanguage")
            dg.DataBind()
            c = Session("iCDataGridButtonLanguage")
        Else
            al = oLanguageText.GetLanguageTextByLocation(oSiteSettings.Language, "iConsulting.iCMServer.Modules.Language")
            Dim iCColumnList As New clsGridColumnsList
            iCColumnList.AddColumn("lng_language", oLanguageText.Find(al, "lang_name"))

            Dim iCData As New iCDataManager.iCDataObject
            If Not iCData.GetDataSet("lng_language", "sit_id = " & oSiteSettings.SiteId & " AND lng_hidden = 0 AND lng_deleted = 0", "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If

            iCDataGrid.GridColumnList = iCColumnList.ColumnList
            iCDataGrid.UpdateText = oLanguageText.Find(al, "lang_update") '"Uppdatera/Spara"
            iCDataGrid.EditText = oLanguageText.Find(al, "lang_edit") '"Editera"
            iCDataGrid.DeleteText = oLanguageText.Find(al, "lang_delete") '"Radera"
            iCDataGrid.CancelText = oLanguageText.Find(al, "lang_cancel") '"Ångra"
            iCDataGrid.ButtonText = oLanguageText.Find(al, "lang_add") '"Lägg till ny"
            iCDataGrid.SetAuthorizedColumnString = "lng_hidden = 0 AND lng_deleted = 0"
            iCDataGrid.ConfirmText = oLanguageText.Find(al, "lang_confirm") '"Är du säker att du vill radera denna användaren?"
            iCDataGrid.LinkText = "" '"Koppla användare till roll"
            iCDataGrid.EditImageUrl = "Images/Edit.gif"
            iCDataGrid.UpdateImageUrl = "Images/Update.gif"
            iCDataGrid.CancelImageUrl = "Images/Cancel.gif"
            iCDataGrid.DeleteImageUrl = "Images/Delete.gif"
            iCDataGrid.LinkImageUrl = ""
            iCDataGrid.LinkDestPath = ""
            iCDataGrid.IsLinked = False
            iCDataGrid.UseArrow = True
            iCDataGrid.ArrowUrl = "Images/Arrow.gif"
            iCDataGrid.DefaultColumnWidth = 3

            dg = iCDataGrid.CreateDataGrid(ds)
            c = iCDataGrid.AddNewButton

            Session("iCDataGridLanguage") = dg
            Session("iCDataGridButtonLanguage") = c

        End If

        Placeholder1.Controls.Add(dg)
        Placeholder2.Controls.Add(c)
    End Sub

End Class
