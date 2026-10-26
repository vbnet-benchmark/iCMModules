Public Class HandlePages
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Mode As String
        Dim PageId As Integer = 0
        Dim ToId As Integer = 0
        Dim FromId As Integer = 0
        Dim ModId As Integer = 0
        Dim oPag As New clsPages
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles("Superadmin;Admins") = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("ToId") Is Nothing) Then
            ToId = Int32.Parse(Request.Params("ToId"))
        End If

        ' Determine ItemId of Events to Update
        If Not (Request.Params("FromId") Is Nothing) Then
            FromId = Int32.Parse(Request.Params("FromId"))
        End If

        ' Determine Handle event
        If Not (Request.Params("Mode") Is Nothing) Then
            Mode = Request.Params("Mode")
        End If

        Select Case LCase(Mode)
            Case "up"
                oPag.MoveNodeUp(PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "down"
                oPag.MoveNodeDown(PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "to"
                oPag.MoveNodeTo(PageId, ToId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "delete"
                oPag.DeleteNode(PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "preview"
                ' Bundle-preview: render several named page-engine fragments
                ' in one request, given as a comma separated list.
                Dim aFragments() As String = Split(Request.Params("Fragments"), ",")
                Dim swBundle As New System.IO.StringWriter
                Dim i As Integer
                For i = 0 To aFragments.GetUpperBound(0)
                    ' SINK: PLANTED-VB-HR-140
                    Server.Execute("Server/Modules/Pages/Fragments/" & aFragments(i) & ".aspx", swBundle)
                Next
                Response.Write(swBundle.ToString())
                Response.End()
            Case "previewsafe"
                Dim aFragmentsSafe() As String = Split(Request.Params("FragmentsSafe"), ",")
                Dim oAllowedBundleFragments As New System.Collections.Specialized.NameValueCollection
                oAllowedBundleFragments.Add("header", "Server/Modules/Pages/Fragments/Header.aspx")
                oAllowedBundleFragments.Add("footer", "Server/Modules/Pages/Fragments/Footer.aspx")
                oAllowedBundleFragments.Add("sidebar", "Server/Modules/Pages/Fragments/Sidebar.aspx")
                Dim swBundleSafe As New System.IO.StringWriter
                Dim j As Integer
                For j = 0 To aFragmentsSafe.GetUpperBound(0)
                    Dim sSafeBundlePath As String = oAllowedBundleFragments(LCase(aFragmentsSafe(j)))
                    If Not sSafeBundlePath Is Nothing Then
                        ' SAFE_SINK: PLANTED-VB-HR-140-safe
                        Server.Execute(sSafeBundlePath, swBundleSafe)
                    End If
                Next
                Response.Write(swBundleSafe.ToString())
                Response.End()
            Case "quickaction"
                ' Lightweight single-action dispatch for the admin "quick
                ' actions" menu, so a new page action can be wired up without
                ' adding another hardcoded Case branch here each time - see
                ' clsPages.InvokeNamedPageAction (PLANTED-VB-HR-173).
                oPag.InvokeNamedPageAction(Request.Params("Action"), PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "quickactionsafe"
                oPag.InvokeNamedPageActionSafe(Request.Params("ActionSafe"), PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "batchactions"
                ' Bulk variant of "quickaction" above: runs several named
                ' actions in one round trip, as a comma separated list (e.g.
                ' for an admin re-ordering several nodes in one go) - see
                ' clsPages.InvokeNamedPageActions (PLANTED-VB-HR-174).
                oPag.InvokeNamedPageActions(Request.Params("Actions"), PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case "batchactionssafe"
                oPag.InvokeNamedPageActionsSafe(Request.Params("ActionsSafe"), PageId)
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
            Case Else
                Response.Redirect("~/icm.aspx?PageId=" & FromId & "&ExpId=" & ModId)
        End Select

    End Sub

End Class
