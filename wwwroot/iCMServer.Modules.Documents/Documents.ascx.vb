Imports System.Web
Imports System.Collections

Public MustInherit Class Documents : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAddFolder As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDeleteFolder As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnUploadFile As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblSize As System.Web.UI.WebControls.Label
    Protected WithEvents lblModified As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitleSimple As System.Web.UI.WebControls.Label
    Protected WithEvents lblSizeSimple As System.Web.UI.WebControls.Label
    Protected WithEvents lblModifiedSimple As System.Web.UI.WebControls.Label
    Protected WithEvents lblFolders As System.Web.UI.WebControls.Label

    Protected WithEvents chkSimpleViewState As System.Web.UI.WebControls.CheckBox
    Protected WithEvents SimpleFiles As System.Web.UI.WebControls.PlaceHolder

    Protected PagId As Integer = 0
    Protected ModId As Integer = 0
    Protected ModTitle As String = ""
    Protected TreeName As String = "Tree"
    Protected AddFolderConfirm1 As String = ""
    Protected AddFolderConfirm2 As String = ""
    Protected AddFolderDefaultText As String = ""
    Protected DeleteFolderConfirm As String = ""
    Protected AddFolderAltText As String = ""
    Protected EditFolderAltText As String = ""
    Protected EditFolderConfirm As String = ""
    Protected DeleteFolderAltText As String = ""
    Protected UploadFileAltText As String = ""
    Protected SimpleViewAltText As String = ""
    Protected DefaultViewAltText As String = ""
    Protected RefreshAltText As String = ""
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected SimpleViewState As Boolean = False
    Private Declare Function GetTickCount Lib "kernel32" Alias "GetTickCount" () As Long
    Protected HasEditAuth As Boolean

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

        HasEditAuth = clsSiteSecurity.IsInRoles(ModuleConfiguration.AuthorizedEditRoles)

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Documents")

        TreeName = "Tree" & GetTickCount
        ModId = ModuleId
        ModTitle = ModuleConfiguration.ModuleTitle
        PagId = oSite.ActivePage.PageId

        AddFolderConfirm1 = Server.HtmlDecode(oLang.Find(al, "documents_addfolderconfirm1"))
        AddFolderConfirm2 = Server.HtmlDecode(oLang.Find(al, "documents_addfolderconfirm2"))
        AddFolderDefaultText = Server.HtmlDecode(oLang.Find(al, "documents_addfolderdefaulttext"))
        DeleteFolderConfirm = Server.HtmlDecode(oLang.Find(al, "documents_deletefolderconfirm"))
        AddFolderAltText = Server.HtmlDecode(oLang.Find(al, "documents_addfolderalttext"))
        EditFolderConfirm = Server.HtmlDecode(oLang.Find(al, "documents_editfolderconfirm"))
        EditFolderAltText = Server.HtmlDecode(oLang.Find(al, "documents_editfolderalttext"))
        DeleteFolderAltText = Server.HtmlDecode(oLang.Find(al, "documents_deletefolderalttext"))
        UploadFileAltText = Server.HtmlDecode(oLang.Find(al, "documents_uploadfilealttext"))
        RefreshAltText = Server.HtmlDecode(oLang.Find(al, "documents_refreshalttext"))
        chkSimpleViewState.Text = Server.HtmlDecode(oLang.Find(al, "documents_simpleviewstate"))
        lblFolders.Text = Server.HtmlDecode(oLang.Find(al, "documents_folders"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "documents_title"))
        lblTitleSimple.Text = Server.HtmlDecode(oLang.Find(al, "documents_title"))
        lblSize.Text = Server.HtmlDecode(oLang.Find(al, "documents_size"))
        lblSizeSimple.Text = Server.HtmlDecode(oLang.Find(al, "documents_size"))
        lblModified.Text = Server.HtmlDecode(oLang.Find(al, "documents_modified"))
        lblModifiedSimple.Text = Server.HtmlDecode(oLang.Find(al, "documents_modified"))

        If Not Page.IsPostBack Then
            ' Read the SimpleViewState from ModuleConfiguration.EditSrc....
            Try
                SimpleViewState = CType(ModuleConfiguration.EditSrc, Boolean)
                chkSimpleViewState.Checked = SimpleViewState
            Catch ex As Exception
                SimpleViewState = False
                chkSimpleViewState.Checked = False
            End Try
            If Not HasEditAuth Then
                chkSimpleViewState.Visible = False
            End If

        End If

        Call FillSimpleFiles()

    End Sub

    Private Sub FillSimpleFiles()
        If SimpleViewState Then
            Dim oDoc As New clsDocuments
            SimpleFiles.Controls.Add(New System.Web.UI.LiteralControl(oDoc.GetSimpleFiles(PagId, ModId, HasEditAuth)))
        End If
    End Sub

    Private Sub chkSimpleViewState_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSimpleViewState.CheckedChanged
        SimpleViewState = chkSimpleViewState.Checked
        Dim oDoc As New clsDocuments
        If Not oDoc.UpdateModuleViewState(PagId, ModId, SimpleViewState) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

End Class
