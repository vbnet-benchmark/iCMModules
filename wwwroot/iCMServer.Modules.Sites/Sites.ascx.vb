Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class Sites : Inherits clsSiteModuleControl

    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLang As New clsLanguageText
    Private al As New ArrayList

    Protected WithEvents btnSettings As System.Web.UI.WebControls.Button
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

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
        Minimizer.ID = ModuleId

        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim oSit As New clsSites
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Sites")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "sites_header"))
        'lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "sites_title"))
        btnSettings.Text = Server.HtmlDecode(oLang.Find(al, "sites_settings"))
        'txtTitle.Text = oSit.GetSiteTitle
    End Sub

    Private Sub btnSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        Response.Redirect("~/Server/Modules/Sites/EditSites.aspx?ModId=" & ModuleId)
    End Sub
End Class
