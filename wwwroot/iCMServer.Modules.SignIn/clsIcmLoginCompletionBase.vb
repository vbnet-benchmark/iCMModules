Imports System.Web
Imports System.Web.Security

''' <summary>
''' Base type for the "QuickLogin" login-completion strategies (PLANTED-VB-HR-154). Used by
''' QuickLogin.aspx.vb, which holds a single call site through a base-typed reference -- which
''' concrete subclass gets instantiated (and therefore whether the pre-existing session is
''' invalidated before authentication completes) depends entirely on the caller-supplied "Mode".
''' </summary>
Public MustInherit Class clsIcmLoginCompletionBase
    Public MustOverride Sub CompleteLogin(ByVal email As String)
End Class

''' <summary>
''' Default/standard completion strategy: issues the forms-authentication cookie without ever
''' invalidating whatever session the caller already holds.
''' </summary>
Public Class clsIcmStandardLoginCompletion
    Inherits clsIcmLoginCompletionBase

    Public Overrides Sub CompleteLogin(ByVal email As String)
        ' SINK: PLANTED-VB-HR-154
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub
End Class

''' <summary>
''' Secure completion strategy (safe twin, PLANTED-VB-HR-154-safe): invalidates the caller's
''' pre-existing session before issuing the forms-authentication cookie.
''' </summary>
Public Class clsIcmSecureLoginCompletion
    Inherits clsIcmLoginCompletionBase

    Public Overrides Sub CompleteLogin(ByVal email As String)
        HttpContext.Current.Session.Abandon()
        ' SAFE_SINK: PLANTED-VB-HR-154-safe
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub
End Class
