Imports iConsulting.iCMServer.iCDataManager
Imports iConsulting.iCMServer.Components.iCDataGrid
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class LiteSites : Inherits clsSiteModuleControl

    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLanguageText As New clsLanguageText
    Protected WithEvents Logga As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents btnEdit As System.Web.UI.WebControls.Button
    Private al As New ArrayList
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents imgHelp As System.Web.UI.WebControls.Image
    Private PageId As Integer = 0

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
        ' Verify that the current user has access to access this page
        If clsSiteSecurity.IsInRoles("Admins;Superadmin") = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If

        imgHelp.Attributes.Add("onclick", "window.open('Server/Modules/LiteSites/help.htm','Hjälp')")
        imgHelp.Attributes.Add("style", "cursor:hand")

        Dim ds As New DataSet
        Dim oLite As New clsLiteSites
        ds = oLite.GetMainDefinedDocument(PageId, ModuleConfiguration.ModuleId)
        If Not ds.Tables(0).Rows.Count > 0 Then
            Logga.Src = "Images/none.gif"
            lblName.Text = "&nbsp;&nbsp;" & oLite.GetSiteInfo.Rows(0)("sit_name")
        Else
            Logga.Src = "LiteSitesView.aspx?PageId=" & PageId & "&ModId=" & ModuleConfiguration.ModuleId & "&CatId=0&DocId=" & ds.Tables(0).Rows(0)("doc_id")
            lblName.Text = "&nbsp;&nbsp;" & oLite.GetSiteInfo.Rows(0)("sit_name")
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Response.Redirect("~/Server/Modules/LiteSites/LiteSitesUpload.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CatId=0")
    End Sub
End Class
