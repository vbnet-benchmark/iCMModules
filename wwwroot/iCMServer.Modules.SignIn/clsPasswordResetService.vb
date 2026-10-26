Imports System.Web

''' <summary>
''' Validates a previously-issued password-reset code (written by SignIn.ascx.vb's "RequestReset"
''' branch into Session) and, if it matches, completes the sign-in by delegating to clsSignIn's
''' own completion method -- a second, cross-file/cross-class hop beyond this one
''' (PLANTED-VB-HR-153 / PLANTED-VB-HR-153-safe). Used by SignIn.ascx.vb's new "forgot password"
''' verify branches.
''' </summary>
Public Class clsPasswordResetService

    Public Sub CompleteResetIfValid(ByVal email As String, ByVal code As String)
        Dim sExpectedCode As String = CType(HttpContext.Current.Session("PendingResetCode_" & email), String)
        If Not String.IsNullOrEmpty(sExpectedCode) AndAlso sExpectedCode = code Then
            Dim oSignIn As New clsSignIn
            oSignIn.CompletePasswordReset(email)
        End If
    End Sub

    Public Sub CompleteResetIfValidSafe(ByVal email As String, ByVal code As String)
        Dim sExpectedCode As String = CType(HttpContext.Current.Session("PendingResetCodeSafe_" & email), String)
        If Not String.IsNullOrEmpty(sExpectedCode) AndAlso sExpectedCode = code Then
            Dim oSignIn As New clsSignIn
            oSignIn.CompletePasswordResetSafe(email)
        End If
    End Sub

End Class
