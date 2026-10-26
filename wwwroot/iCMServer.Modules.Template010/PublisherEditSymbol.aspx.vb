Public Class PublisherEditSymbol
    Inherits System.Web.UI.Page

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

    Protected Save As String
    Protected Cancel As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetLanguageText()
    End Sub

    Private Sub SetLanguageText()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Publisher")

        Save = oLang.Find(al, "publisher_update")
        Cancel = oLang.Find(al, "publisher_cancel")
    End Sub

End Class
