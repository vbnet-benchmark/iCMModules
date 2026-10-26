Imports iConsulting.iCMServer.iCDataManager
Imports iConsulting.iCMServer.Components.iCDataGrid
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class Publisher : Inherits clsSiteModuleControl

    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Protected WithEvents HtmlHolder As System.Web.UI.HtmlControls.HtmlTableCell
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
        Dim oPub As New clsPublisher
        HtmlHolder.Controls.Add(New LiteralControl(Server.HtmlDecode(oPub.GetHtmlText(oSite.ActivePage.PageId, ModuleId))))
    End Sub

End Class
