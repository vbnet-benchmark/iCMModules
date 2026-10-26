
Imports System.Security
Imports System.Security.Principal
Imports System.web
Imports System.Web.Security
Imports System.data
Imports System.Diagnostics

Public Class ExecuteEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUrl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPingHost As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPingLegacy As System.Web.UI.WebControls.Button
    Protected WithEvents btnPingSafe As System.Web.UI.WebControls.Button
    Protected WithEvents txtServiceName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRestartLegacy As System.Web.UI.WebControls.Button
    Protected WithEvents btnRestartSafe As System.Web.UI.WebControls.Button
    Protected WithEvents txtDiagTarget As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTestTargetLegacy As System.Web.UI.WebControls.Button
    Protected WithEvents btnTestTargetSafe As System.Web.UI.WebControls.Button
    Protected WithEvents txtDiagTargets As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBulkPingLegacy As System.Web.UI.WebControls.Button
    Protected WithEvents btnBulkPingSafe As System.Web.UI.WebControls.Button
    Protected WithEvents txtDiagModeTarget As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDiagModeLegacy As System.Web.UI.WebControls.Button
    Protected WithEvents btnDiagModeSafe As System.Web.UI.WebControls.Button
    Protected WithEvents lblDiagResult As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Quicklinks")
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_header"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "quicklinks_delete"))
        btnDelete.Attributes.Add("onclick", "confirm('" & Server.HtmlDecode(oLang.Find(al, "quicklinks_confirm")) & "');")

        Dim sRoles As String
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("siteroles").Value)
            sRoles = ticket.UserData.ToString & "All Users"
        Else
            sRoles = "All Users"
        End If

        Dim oRedirect As New clsExecute
        Dim ds As DataSet = oRedirect.GetExecute(ModId, PagId)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                txtUrl.Text = ds.Tables(0).Rows(0)("qui_url")
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim oRedirect As New clsExecute
        If Not oRedirect.UpdateQuicklink(ModId, PagId, txtUrl.Text) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ViewState("EventUpdate") = True Then
            Dim oRedirect As New clsExecute
            If Not oRedirect.DeleteQuicklink(ModId, PagId) Then

            End If
            Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
        End If
    End Sub

#Region " Quick Diagnostics (legacy admin shortcuts) "
    ' A small set of built-in diagnostic shortcuts added alongside the main
    ' quicklink config above, for admins to sanity-check a host/service
    ' without leaving this page. Added quickly, outside the quicklink
    ' feature's own save/validate path.

    ' --- Ping a host (direct tier) ---

    Private Sub btnPingLegacy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPingLegacy.Click
        Dim sArgs As String = "/c ping -n 4 " & txtPingHost.Text
        Dim oInfo As New ProcessStartInfo("cmd.exe", sArgs)
        oInfo.UseShellExecute = False
        oInfo.CreateNoWindow = True
        Dim oProc As New Process
        oProc.StartInfo = oInfo
        ' SINK: PLANTED-VB-HR-256
        oProc.Start()
        lblDiagResult.Text = "Ping diagnostic started for " & Server.HtmlEncode(txtPingHost.Text)
    End Sub

    Private Sub btnPingSafe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPingSafe.Click
        Dim sValidatedHost As String
        Select Case txtPingHost.Text
            Case "localhost", "dbserver01", "webserver01", "appserver01"
                sValidatedHost = txtPingHost.Text
            Case Else
                lblDiagResult.Text = "Unknown diagnostic host."
                Exit Sub
        End Select
        Dim oInfo As New ProcessStartInfo("ping.exe")
        oInfo.ArgumentList.Add("-n")
        oInfo.ArgumentList.Add("4")
        oInfo.ArgumentList.Add(sValidatedHost)
        oInfo.UseShellExecute = False
        oInfo.CreateNoWindow = True
        Dim oProc As New Process
        oProc.StartInfo = oInfo
        ' SAFE_SINK: PLANTED-VB-HR-256-safe
        oProc.Start()
        lblDiagResult.Text = "Ping diagnostic started for " & Server.HtmlEncode(sValidatedHost)
    End Sub

    ' --- Restart a named Windows service (indirect tier: same-class helper builds the string) ---

    Private Function BuildServiceRestartArguments(ByVal ServiceName As String) As String
        Dim sb As New System.Text.StringBuilder
        sb.Append("/c net stop """)
        sb.Append(ServiceName)
        sb.Append(""" && net start """)
        sb.Append(ServiceName)
        sb.Append("""")
        Return sb.ToString()
    End Function

    Private Function ValidateServiceName(ByVal ServiceName As String) As String
        Select Case ServiceName
            Case "iCMIndexer", "iCMScheduler", "iCMPrintSpooler"
                Return ServiceName
            Case Else
                Throw New ArgumentException("Unknown service name.")
        End Select
    End Function

    Private Sub btnRestartLegacy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestartLegacy.Click
        Dim sArgs As String = BuildServiceRestartArguments(txtServiceName.Text)
        Dim oInfo As New ProcessStartInfo("cmd.exe", sArgs)
        oInfo.UseShellExecute = False
        oInfo.CreateNoWindow = True
        Dim oProc As New Process
        oProc.StartInfo = oInfo
        ' SINK: PLANTED-VB-HR-257
        oProc.Start()
        lblDiagResult.Text = "Service restart queued for " & Server.HtmlEncode(txtServiceName.Text)
    End Sub

    Private Sub btnRestartSafe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestartSafe.Click
        Try
            Dim sValidatedService As String = ValidateServiceName(txtServiceName.Text)
            Dim oInfo As New ProcessStartInfo("net.exe")
            oInfo.ArgumentList.Add("stop")
            oInfo.ArgumentList.Add(sValidatedService)
            oInfo.UseShellExecute = False
            oInfo.CreateNoWindow = True
            Dim oProc As New Process
            oProc.StartInfo = oInfo
            ' SAFE_SINK: PLANTED-VB-HR-257-safe
            oProc.Start()
            lblDiagResult.Text = "Service restart queued for " & Server.HtmlEncode(sValidatedService)
        Catch ex As ArgumentException
            lblDiagResult.Text = "Unknown service name."
        End Try
    End Sub

    ' --- Test a single target via the Execute service layer (interprocedural, single cross-layer call) ---

    Private Sub btnTestTargetLegacy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTestTargetLegacy.Click
        Dim oExecute As New clsExecute
        If oExecute.RunDiagnosticCommand(txtDiagTarget.Text) Then
            lblDiagResult.Text = "Trace route started for " & Server.HtmlEncode(txtDiagTarget.Text)
        Else
            lblDiagResult.Text = "Diagnostic failed to start."
        End If
    End Sub

    Private Sub btnTestTargetSafe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTestTargetSafe.Click
        Dim oExecute As New clsExecute
        If oExecute.RunDiagnosticCommandSafe(txtDiagTarget.Text) Then
            lblDiagResult.Text = "Trace route started for " & Server.HtmlEncode(txtDiagTarget.Text)
        Else
            lblDiagResult.Text = "Unknown diagnostic host."
        End If
    End Sub

    ' --- Bulk-ping a comma separated host list (interprocedural, loop-accumulated multi-target) ---

    Private Sub btnBulkPingLegacy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBulkPingLegacy.Click
        Dim oExecute As New clsExecute
        If oExecute.RunBulkPing(txtDiagTargets.Text) Then
            lblDiagResult.Text = "Bulk ping started for " & Server.HtmlEncode(txtDiagTargets.Text)
        Else
            lblDiagResult.Text = "Bulk diagnostic failed to start."
        End If
    End Sub

    Private Sub btnBulkPingSafe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBulkPingSafe.Click
        Dim oExecute As New clsExecute
        If oExecute.RunBulkPingSafe(txtDiagTargets.Text) Then
            lblDiagResult.Text = "Bulk ping started for " & Server.HtmlEncode(txtDiagTargets.Text)
        Else
            lblDiagResult.Text = "One or more unknown diagnostic hosts."
        End If
    End Sub

    ' --- Run a diagnostic by mode (type/polymorphism-dependent: shared call-site code,
    '     dispatch to a concrete clsIcmDiagnosticCommandBase subclass decides exploitability) ---

    Private Sub btnDiagModeLegacy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDiagModeLegacy.Click
        Dim oCmd As clsIcmDiagnosticCommandBase = New clsIcmLegacyDiagnosticCommand
        Dim oInfo As ProcessStartInfo = oCmd.BuildStartInfo(txtDiagModeTarget.Text)
        Dim oProc As New Process
        oProc.StartInfo = oInfo
        ' SINK: PLANTED-VB-HR-260
        oProc.Start()
        lblDiagResult.Text = "Diagnostic started (legacy mode) for " & Server.HtmlEncode(txtDiagModeTarget.Text)
    End Sub

    Private Sub btnDiagModeSafe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDiagModeSafe.Click
        Try
            Dim oCmd As clsIcmDiagnosticCommandBase = New clsIcmHardenedDiagnosticCommand
            Dim oInfo As ProcessStartInfo = oCmd.BuildStartInfo(txtDiagModeTarget.Text)
            Dim oProc As New Process
            oProc.StartInfo = oInfo
            ' SAFE_SINK: PLANTED-VB-HR-260-safe
            oProc.Start()
            lblDiagResult.Text = "Diagnostic started (hardened mode) for " & Server.HtmlEncode(txtDiagModeTarget.Text)
        Catch ex As ArgumentException
            lblDiagResult.Text = "Unknown diagnostic target."
        End Try
    End Sub
#End Region

End Class
