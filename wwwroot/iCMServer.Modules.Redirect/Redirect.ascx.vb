Imports System.Web
Imports System.Collections
Imports System
Imports System.data

Public MustInherit Class Redirect : Inherits clsSiteModuleControl

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

    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected PagId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Call BindData()
    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        PagId = oSite.ActivePage.PageId
        Dim oRedirect As New clsRedirect
        Dim RedirectTo As String = ""
        Dim ds As DataSet = oRedirect.GetRedirect(ModuleId, PagId)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                RedirectTo = CType(ds.Tables(0).Rows(0)("qui_url"), String)
            End If
        End If
        If Not clsSiteSecurity.HasEditPermissions(ModuleId) Then
            If Not RedirectTo.Length < 1 Then
                Response.Redirect(RedirectTo)
            End If
        End If
    End Sub

End Class
