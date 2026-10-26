Imports System.Web
Imports System.data
Imports System.Collections

Public Class Discussion : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected PagId As Integer = 0
    Protected ModId As Integer = 0
    Protected ExpId As Integer = 0
    Protected Posted As String = "Posted"
    Protected By As String = "By"
    Protected WithEvents TopLevelList As System.Web.UI.WebControls.DataList
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal

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
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Discussion")
        Posted = Server.HtmlDecode(oLang.Find(al, "discussion_posted"))
        By = Server.HtmlDecode(oLang.Find(al, "discussion_by"))
        PagId = oSite.ActivePage.PageId
        ModId = ModuleId
        Dim oDis As New clsDiscussion
        TopLevelList.DataSource = oDis.GetTopLevelMessages(PagId, ModId)
        TopLevelList.DataBind()
    End Sub

    Private Sub TopLevelList_Select(ByVal Sender As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles TopLevelList.ItemCommand
        Dim command As String = CType(e.CommandSource, System.Web.UI.WebControls.ImageButton).CommandName
        If command = "collapse" Then
            TopLevelList.SelectedIndex = -1
        Else
            TopLevelList.SelectedIndex = e.Item.ItemIndex
        End If
        Call BindData()
    End Sub

    Protected Function GetThreadMessages() As DataSet
        Dim odis As New clsDiscussion
        Return odis.GetSubLevelMessages(PagId, ModId, TopLevelList.DataKeys(TopLevelList.SelectedIndex).ToString())
    End Function

    Protected Function FormatUrl(ByVal DisId As Integer) As String
        Dim tLiteral As String = Literal1.Text
        Dim tFunction As String = "<script>function ThreadMessage" & PagId.ToString & ModId.ToString & DisId.ToString & "(){window.open('" & "Desktop/Modules/Discussion/DiscussionDetails.aspx?PagId=" & PagId & "&DisId=" & DisId & "&ModId=" & ModId & "','Edit','Height=350,Width=550')}</script>" & vbCrLf
        If InStr(tLiteral, tFunction) = 0 Then
            Literal1.Text += "<script>function ThreadMessage" & PagId.ToString & ModId.ToString & DisId.ToString & "(){window.open('" & "Desktop/Modules/Discussion/DiscussionDetails.aspx?PagId=" & PagId & "&DisId=" & DisId & "&ModId=" & ModId & "','Edit','Height=350,Width=550')}</script>" & vbCrLf
        End If
        Return "ThreadMessage" & PagId.ToString & ModId.ToString & DisId.ToString & "()"
    End Function

    Protected Function NodeImage(ByVal count As Integer) As String
        If count > 0 Then
            Return "Images/plus.gif"
        Else
            Return "Images/node.gif"
        End If
    End Function

End Class
