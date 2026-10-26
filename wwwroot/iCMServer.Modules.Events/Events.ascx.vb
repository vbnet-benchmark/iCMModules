Imports System.Web
Imports System.Collections

Public MustInherit Class Events : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents myDataList As System.Web.UI.WebControls.DataList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected PagId As Integer = 0
    Protected Comming As String
    Protected Used As String
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

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
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Events")

        Comming = Server.HtmlDecode(oLang.Find(al, "events_coming"))
        Used = Server.HtmlDecode(oLang.Find(al, "events_used"))

        PagId = oSite.ActivePage.PageId
        Dim oEvent As New clsEvents
        myDataList.DataSource = oEvent.GetEvents(ModuleId, PagId)
        myDataList.DataBind()

        Dim i As Integer = 0
        Dim hl As System.Web.UI.webcontrols.HyperLink
        Dim l1 As System.Web.UI.webcontrols.Label
        Dim l2 As System.Web.UI.webcontrols.Label

        For i = 0 To myDataList.Items.Count - 1

            ' Replace the Read more... value
            hl = New System.Web.UI.webcontrols.HyperLink
            If TypeOf (myDataList.Items(i).FindControl("editLink")) Is System.Web.UI.webcontrols.HyperLink Then
                hl = myDataList.Items(i).FindControl("editLink")
                hl.ToolTip = Server.HtmlDecode(oLang.Find(al, "events_icon"))
            End If

            hl = New System.Web.UI.webcontrols.HyperLink
            If TypeOf (myDataList.Items(i).FindControl("moreLink")) Is System.Web.UI.webcontrols.HyperLink Then
                hl = myDataList.Items(i).FindControl("moreLink")
                hl.Text = Server.HtmlDecode(oLang.Find(al, "events_readmore"))
            End If

            l1 = New System.Web.UI.webcontrols.Label
            If TypeOf (myDataList.Items(i).FindControl("ShowDate")) Is System.Web.UI.webcontrols.Label Then
                l1 = myDataList.Items(i).FindControl("ShowDate")
                l1.Text = "&nbsp;&nbsp;" & Server.HtmlDecode(oLang.Find(al, "events_used"))
            End If

            l2 = New System.Web.UI.webcontrols.Label
            If TypeOf (myDataList.Items(i).FindControl("HideDate")) Is System.Web.UI.webcontrols.Label Then
                l2 = myDataList.Items(i).FindControl("HideDate")
                l2.Text = "&nbsp;&nbsp;" & Server.HtmlDecode(oLang.Find(al, "events_coming"))
            End If

        Next



    End Sub
End Class
