Imports System.Web
Imports System.Collections

Public MustInherit Class Quicklinks : Inherits clsSiteModuleControl

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


    Protected WithEvents myDataList As System.Web.UI.WebControls.DataList
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected linkImage As String = ""
    Protected PagId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Protected Function GetUrl(ByVal Url As String) As String
        If InStr(Url, "|") > 0 Then
            Return Left(Url, InStr(Url, "|") - 1)
        Else
            Return Url
        End If
    End Function

    Protected Function GetTarget(ByVal Url As String) As String
        If InStr(Url, "|") > 0 Then
            Return Right(Url, Len(Url) - InStr(Url, "|"))
        Else
            Return "_Blank"
        End If
    End Function

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Quicklinks")

        ' Set the link image type
        If IsEditable Then
            linkImage = "Images/Edit.gif"
        Else
            linkImage = "Images/navlink.gif"
        End If

        PagId = oSite.ActivePage.PageId
        Dim oQuick As New clsQuicklinks
        myDataList.DataSource = oQuick.GetQuicklinks(ModuleId, PagId)
        myDataList.DataBind()

        'Dim i As Integer = 0
        'Dim hl As System.Web.UI.webcontrols.HyperLink
        'Dim ll As System.Web.UI.WebControls.Label

        'For i = 0 To myDataList.Items.Count - 1
        '    hl = New System.Web.UI.webcontrols.HyperLink
        '    If TypeOf (myDataList.Items(i).FindControl("editLink")) Is System.Web.UI.webcontrols.HyperLink Then
        '        hl = myDataList.Items(i).FindControl("editLink")
        '        If IsEditable Then
        '            hl.ToolTip = Server.HtmlDecode(oLang.Find(al, "qicklinks_iconedit"))
        '        Else
        '            ll = New System.Web.UI.WebControls.Label
        '            If TypeOf (myDataList.Items(i).FindControl("editUrl")) Is System.Web.UI.webcontrols.Label Then
        '                ll = myDataList.Items(i).FindControl("editUrl")
        '                hl.NavigateUrl = ll.Text
        '                hl.ToolTip = ll.Text
        '            End If
        '            'hl.ToolTip = Server.HtmlDecode(oLang.Find(al, "qicklinks_iconnavigate"))
        '        End If
        '    End If
        'Next

    End Sub
End Class
