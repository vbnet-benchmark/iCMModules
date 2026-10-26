Imports System.Web
Imports System.Web.Security

''' <summary>
''' A lightweight, non-interactive credential-check endpoint (e.g. for an embedded widget that
''' posts credentials directly rather than rendering the SignIn.ascx control). Dispatches login
''' completion through a base-typed clsIcmLoginCompletionBase reference -- see
''' clsIcmLoginCompletionBase.vb for PLANTED-VB-HR-154 / PLANTED-VB-HR-154-safe.
''' </summary>
Public Class QuickLogin
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sEmail As String = Request.Params("Email")
        Dim sPassword As String = Request.Params("Password")
        If Not String.IsNullOrEmpty(sEmail) And Not String.IsNullOrEmpty(sPassword) Then
            Dim oSignIn As New clsSignIn
            Dim sUserEmail As String = oSignIn.Login(sEmail, sPassword)
            If Not (sUserEmail Is Nothing) And sUserEmail <> "" Then
                ' PLANTED-VB-HR-154 / PLANTED-VB-HR-154-safe: a single, shared completion call
                ' site dispatches through a base-typed reference -- the caller-supplied "Mode"
                ' alone decides which concrete login-completion strategy runs for this request.
                Dim oCompletion As clsIcmLoginCompletionBase
                Dim sMode As String = Request.QueryString("Mode")
                If sMode = "secure" Then
                    oCompletion = New clsIcmSecureLoginCompletion
                Else
                    oCompletion = New clsIcmStandardLoginCompletion
                End If
                oCompletion.CompleteLogin(sUserEmail)
                Response.Redirect("~/Default.aspx")
            End If
        End If
    End Sub

End Class
