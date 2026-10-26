Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web

Public Class clsSignIn

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function Login(ByVal email As String, ByVal password As String) As String
        Dim dsLogin As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("usr_users", "sit_id = " & oSite.SiteId & " AND usr_email = '" & email & "' AND usr_password = '" & oCrypto.Encrypt(password) & "' AND usr_deleted = 0", "", sError, ED, EC, dsLogin) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        If dsLogin.Tables.Count > 0 Then
            If dsLogin.Tables(0).Rows.Count > 0 Then
                Return IIf(IsDBNull(dsLogin.Tables(0).Rows(0)("usr_email")), "", dsLogin.Tables(0).Rows(0)("usr_email"))
            Else
                Return String.Empty
            End If
        Else
            Return String.Empty
        End If
    End Function

End Class

