Public Class PublisherEditTable
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

    Protected Width As String
    Protected Border As String
    Protected Rows As String
    Protected Columns As String
    Protected CellPadding As String
    Protected CellSpacing As String
    Protected BGColor As String
    Protected Align As String
    Protected BorderColor As String
    Protected Save As String
    Protected Cancel As String
    Protected Left As String
    Protected Center As String
    Protected Right As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetLanguageText()
    End Sub

    Private Sub SetLanguageText()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Publisher")

        Width = oLang.Find(al, "publisher_tablewidht")
        Border = oLang.Find(al, "publisher_tableborder")
        Rows = oLang.Find(al, "publisher_tablerows")
        Columns = oLang.Find(al, "publisher_tablecolumns")
        CellPadding = oLang.Find(al, "publisher_tablecellpadding")
        CellSpacing = oLang.Find(al, "publisher_tablecellspacing")
        BGColor = oLang.Find(al, "publisher_tablebgcolor")
        Align = oLang.Find(al, "publisher_tablealign")
        BorderColor = oLang.Find(al, "publisher_tablebordercolor")
        Left = oLang.Find(al, "publisher_tablealignleft")
        Center = oLang.Find(al, "publisher_tablealigncenter")
        Right = oLang.Find(al, "publisher_tablealignright")
        Save = oLang.Find(al, "publisher_update")
        Cancel = oLang.Find(al, "publisher_cancel")
    End Sub

End Class
