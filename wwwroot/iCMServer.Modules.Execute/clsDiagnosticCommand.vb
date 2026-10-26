Imports System.Diagnostics

' Base type for the "Run a diagnostic by mode" quick-diagnostic shortcut on
' ExecuteEdit.aspx: the call site holds a clsIcmDiagnosticCommandBase-typed
' variable and always calls BuildStartInfo + Process.Start uniformly; which
' concrete subclass gets instantiated (legacy vs. hardened) is what decides
' whether the resulting ProcessStartInfo is exploitable.
Public MustInherit Class clsIcmDiagnosticCommandBase
    Public MustOverride Function BuildStartInfo(ByVal Target As String) As ProcessStartInfo
End Class

Public Class clsIcmLegacyDiagnosticCommand
    Inherits clsIcmDiagnosticCommandBase

    Public Overrides Function BuildStartInfo(ByVal Target As String) As ProcessStartInfo
        Dim sArgs As String = "/c nslookup " & Target
        Dim oInfo As New ProcessStartInfo("cmd.exe", sArgs)
        oInfo.UseShellExecute = False
        oInfo.CreateNoWindow = True
        Return oInfo
    End Function

End Class

Public Class clsIcmHardenedDiagnosticCommand
    Inherits clsIcmDiagnosticCommandBase

    Public Overrides Function BuildStartInfo(ByVal Target As String) As ProcessStartInfo
        Dim aAllowed As String() = {"localhost", "dbserver01", "webserver01", "appserver01"}
        If Array.IndexOf(aAllowed, Target) < 0 Then
            Throw New ArgumentException("Unknown diagnostic target.")
        End If
        Dim oInfo As New ProcessStartInfo("nslookup.exe")
        oInfo.ArgumentList.Add(Target)
        oInfo.UseShellExecute = False
        oInfo.CreateNoWindow = True
        Return oInfo
    End Function

End Class
