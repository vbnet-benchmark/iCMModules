Public Class Publisher2006 : Inherits clsSiteModuleControl 'System.Web.UI.UserControl '

    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents editor1 As Telerik.WebControls.RadEditor
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents HtmlHolder As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Edited As System.Web.UI.HtmlControls.HtmlInputHidden

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

        editor1.Editable = False
        editor1.HasPermission = clsSiteSecurity.HasEditPermissions(ModuleId)
        editor1.AllowThumbGeneration = True

        If Not Page.IsPostBack Then BindData()

    End Sub

    Private Sub BindData()
        Dim HTML As String = String.Empty
        Dim oPub As New clsPublisher
        HTML = oPub.GetHtmlText(oSite.ActivePage.PageId, ModuleId)
        editor1.Html = HTML
        Edited.Value = HTML
    End Sub

    Private Sub editor1_SubmitClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles editor1.SubmitClicked
        Dim oPub As New clsPublisher
        If Not Edited.Value = String.Empty Then
            oPub.SetHtmlText(oSite.ActivePage.PageId, ModuleId, editor1.Html)
        Else
            oPub.SetHtmlText(oSite.ActivePage.PageId, ModuleId, editor1.Html)
        End If
        Response.Redirect(Request.Url.PathAndQuery)
    End Sub

End Class
