
Imports iConsulting.iCMServer
Imports System.Collections

Public MustInherit Class Pages : Inherits clsSiteModuleControl

    Private bError As Boolean
    Protected oCrypto As New iConsulting.iCMServer.clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected WithEvents MoveTo As System.Web.UI.WebControls.Button
    Protected WithEvents ModuleTitle As System.Web.UI.WebControls.Label
    Protected WithEvents btnAddPage As System.Web.UI.WebControls.Button
    Protected WithEvents SelectedSiteID As System.Web.UI.WebControls.TextBox
    Protected WithEvents SelectedPageID As System.Web.UI.WebControls.TextBox
    Protected WithEvents OldSelectedPageID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Sel As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Sel As System.Web.UI.WebControls.Label
    Protected WithEvents imgUp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgDown As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgRight As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgEdit As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgDelete As System.Web.UI.WebControls.ImageButton
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Public oLang As New clsLanguageText
    Public al As New ArrayList
    Public FromId As Integer = 0

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
            ViewState("UrlReferrer") = Request.RawUrl.ToString
        Else
        End If
        FromId = ModuleConfiguration.PageId
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Pages")
    End Sub

End Class
