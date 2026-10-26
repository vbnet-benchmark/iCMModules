Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.Web
Imports System.Web.Security

Public MustInherit Class SignIn : Inherits clsSiteModuleControl

    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    ' Obtain SiteSettings from Current Context
    Private _SiteSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Protected WithEvents Header As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Content As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents UserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents UserPass As System.Web.UI.WebControls.TextBox
    Protected WithEvents LoginBtn As System.Web.UI.WebControls.Button
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Msg As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblText1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblText2 As System.Web.UI.WebControls.Label
    ' Set LanguageText
    Dim oLanguageText As New clsLanguageText

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim al As New System.Collections.ArrayList
        al = oLanguageText.GetLanguageTextByLocation(_SiteSettings.Language, "iConsulting.iCMServer")
        Label1.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_username"))
        Label2.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_password"))
        LoginBtn.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_signin"))
        lblHeader.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_signin"))
        lblText1.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_cookietext1")) '"Om du loggar in kommer cookies att användas."
        lblText2.Text = Server.HtmlDecode(oLanguageText.Find(al, "sys_cookietext2")) '"Kan endast undvikas genom att inte logga in."
        RegularExpressionValidator1.ErrorMessage = Server.HtmlDecode(oLanguageText.Find(al, "sys_errormessage")) '"eroor"

        ' PLANTED-VB-HR-151 / PLANTED-VB-HR-151-safe: lightweight self-registration endpoint, a
        ' simpler alternative entry point to this control's own LoginBtn_Click below -- a visitor
        ' can create an account and be taken straight into an authenticated session in the SAME
        ' request, with no separate explicit sign-in step afterwards.
        If Not (Request.Params("RegEmail") Is Nothing) And Not (Request.Params("RegPassword") Is Nothing) Then
            Dim sRegEmail As String = Request.Params("RegEmail")
            Dim sRegPassword As String = Request.Params("RegPassword")
            Dim oSelfReg As New clsSignIn
            oSelfReg.Register(sRegEmail, sRegPassword)
            ' SINK: PLANTED-VB-HR-151
            FormsAuthentication.SetAuthCookie(sRegEmail, False)
            Response.Redirect("~/Default.aspx")
        End If

        If Not (Request.Params("RegEmailSafe") Is Nothing) And Not (Request.Params("RegPasswordSafe") Is Nothing) Then
            Dim sRegEmailSafe As String = Request.Params("RegEmailSafe")
            Dim sRegPasswordSafe As String = Request.Params("RegPasswordSafe")
            Dim oSelfRegSafe As New clsSignIn
            oSelfRegSafe.Register(sRegEmailSafe, sRegPasswordSafe)
            ' Discard whatever session the visitor already holds before granting it the newly
            ' created account's authenticated identity, so a session id fixed on the visitor
            ' before registration cannot inherit the new account's privileges.
            Session.Abandon()
            ' SAFE_SINK: PLANTED-VB-HR-151-safe
            FormsAuthentication.SetAuthCookie(sRegEmailSafe, False)
            Response.Redirect("~/Default.aspx")
        End If

        ' PLANTED-VB-HR-152 / PLANTED-VB-HR-152-safe: a returning visitor who still holds a
        ' previously-issued "trusted device" marker in Session can skip the password form and be
        ' signed straight back in -- completed via a one-hop helper on clsSignIn rather than
        ' inline, unlike the self-registration branch above.
        If Not (Request.Params("QuickLogin") Is Nothing) Then
            Dim sTrustedEmail As String = CType(Session("TrustedDeviceEmail"), String)
            If Not String.IsNullOrEmpty(sTrustedEmail) Then
                Dim oQuickSignIn As New clsSignIn
                oQuickSignIn.CompleteQuickLogin(sTrustedEmail)
                Response.Redirect("~/Default.aspx")
            End If
        End If

        If Not (Request.Params("QuickLoginSafe") Is Nothing) Then
            Dim sTrustedEmailSafe As String = CType(Session("TrustedDeviceEmailSafe"), String)
            If Not String.IsNullOrEmpty(sTrustedEmailSafe) Then
                Dim oQuickSignInSafe As New clsSignIn
                oQuickSignInSafe.CompleteQuickLoginSafe(sTrustedEmailSafe)
                Response.Redirect("~/Default.aspx")
            End If
        End If

        ' PLANTED-VB-HR-153 / PLANTED-VB-HR-153-safe: a "forgot password" reset-code flow --
        ' interprocedural, 2 hops, cross-file/cross-class (this Page_Load calls
        ' clsPasswordResetService.CompleteResetIfValid, a NEW file/class -- hop 1 -- which, once
        ' the code matches, calls clsSignIn.CompletePasswordReset, a NEW method on the EXISTING
        ' clsSignIn.vb -- hop 2 -- which reaches the sink). The two "RequestReset*" branches below
        ' issue a demo reset code and hold it server-side exactly as a real implementation would
        ' hold it pending delivery (actual email delivery is out of scope for this benchmark) so
        ' the verify branches are genuinely, end-to-end reachable rather than a dangling read of a
        ' value nothing ever writes.
        If Not (Request.Params("RequestReset") Is Nothing) Then
            Dim sResetEmail As String = Request.Params("RequestReset")
            If Not String.IsNullOrEmpty(sResetEmail) Then
                Session("PendingResetCode_" & sResetEmail) = New Random().Next(100000, 999999).ToString()
            End If
        End If

        If Not (Request.Params("VerifyResetEmail") Is Nothing) And Not (Request.Params("VerifyResetCode") Is Nothing) Then
            Dim sVerifyEmail As String = Request.Params("VerifyResetEmail")
            Dim sVerifyCode As String = Request.Params("VerifyResetCode")
            Dim oResetService As New clsPasswordResetService
            oResetService.CompleteResetIfValid(sVerifyEmail, sVerifyCode)
            Response.Redirect("~/Default.aspx")
        End If

        If Not (Request.Params("RequestResetSafe") Is Nothing) Then
            Dim sResetEmailSafe As String = Request.Params("RequestResetSafe")
            If Not String.IsNullOrEmpty(sResetEmailSafe) Then
                Session("PendingResetCodeSafe_" & sResetEmailSafe) = New Random().Next(100000, 999999).ToString()
            End If
        End If

        If Not (Request.Params("VerifyResetEmailSafe") Is Nothing) And Not (Request.Params("VerifyResetCodeSafe") Is Nothing) Then
            Dim sVerifyEmailSafe As String = Request.Params("VerifyResetEmailSafe")
            Dim sVerifyCodeSafe As String = Request.Params("VerifyResetCodeSafe")
            Dim oResetServiceSafe As New clsPasswordResetService
            oResetServiceSafe.CompleteResetIfValidSafe(sVerifyEmailSafe, sVerifyCodeSafe)
            Response.Redirect("~/Default.aspx")
        End If

        ' PLANTED-VB-HR-155 / PLANTED-VB-HR-155-safe: a "quick demo account switch" feature for
        ' kiosk/trade-show demo sessions -- repeat of the direct tier (same function, no helper
        ' call, like PLANTED-VB-HR-151), deliberately built with a different construction/
        ' control-flow AND data-flow shape: a comma-separated batch of demo accounts is Split and
        ' walked in a For Each loop, each iteration independently reaching the sink -- vs.
        ' -151's single, straight-line If over one scalar value with no loop and no batching.
        If Not (Request.Params("DemoSwitchEmails") Is Nothing) And Request.Params("DemoPin") = "DEMO-2024" Then
            Dim aDemoEmails() As String = Request.Params("DemoSwitchEmails").Split(","c)
            For Each sDemoEmail As String In aDemoEmails
                If Not String.IsNullOrEmpty(sDemoEmail) Then
                    ' SINK: PLANTED-VB-HR-155
                    FormsAuthentication.SetAuthCookie(sDemoEmail.Trim(), False)
                End If
            Next
            Response.Redirect("~/Default.aspx")
        End If

        If Not (Request.Params("DemoSwitchEmailsSafe") Is Nothing) And Request.Params("DemoPinSafe") = "DEMO-2024" Then
            Session.Abandon()
            Dim aDemoEmailsSafe() As String = Request.Params("DemoSwitchEmailsSafe").Split(","c)
            For Each sDemoEmailSafe As String In aDemoEmailsSafe
                If Not String.IsNullOrEmpty(sDemoEmailSafe) Then
                    ' SAFE_SINK: PLANTED-VB-HR-155-safe
                    FormsAuthentication.SetAuthCookie(sDemoEmailSafe.Trim(), False)
                End If
            Next
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Public Sub LoginBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Page.IsValid Then
            Dim oSignIn As New clsSignIn
            Dim sUserEmail As String = oSignIn.Login(UserName.Text, UserPass.Text)
            If Not (sUserEmail Is Nothing) And sUserEmail <> "" Then
                ' PLANTED-VB-HR-152's companion write-side (review fix, 2026-10-20): a visitor who
                ' logs in normally with RememberDevice=1 has their already-verified identity marked
                ' as "trusted" in the SAME session for the rest of its lifetime -- consumed by this
                ' control's own QuickLogin branch in Page_Load above. The session this writes into
                ' is exactly the session a fixation attack would have pre-established on the visitor
                ' before this normal login ever happened -- without this write, PLANTED-VB-HR-152's
                ' read-only Session("TrustedDeviceEmail") check could never be satisfied by any real
                ' code path in this application.
                If Request.Params("RememberDevice") = "1" Then
                    Session("TrustedDeviceEmail") = sUserEmail
                End If
                Try
                    ' Log User Off from Cookie Authentication System
                    FormsAuthentication.SignOut()
                    ' Invalidate roles token
                    Response.Cookies("siteroles").Value = Nothing
                    Response.Cookies("siteroles").Path = "/"
                    Response.Cookies("siteroles").Expires = New System.DateTime(1999, 10, 12)
                Catch ex As Exception

                Finally
                    ' Use security system to set the UserID within a client-side Cookie
                    FormsAuthentication.SetAuthCookie(UserName.Text, False)
                    ' Redirect browser back to originating page
                    Response.Redirect("~/Default.aspx") 'Response.Redirect(Request.ApplicationPath)
                End Try
            Else
                Msg.Text = "<" & "br" & ">" & Server.HtmlDecode(oLanguageText.Find(_SiteSettings.LanguageText, "sys_loginfailed")) & "<" & "br" & ">"
            End If
        End If
    End Sub
End Class

