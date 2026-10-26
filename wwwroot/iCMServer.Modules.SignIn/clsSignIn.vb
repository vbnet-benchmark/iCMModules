Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Web.Security

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

    ''' <summary>
    ''' Creates a new account for a self-registering visitor. Used by SignIn.ascx.vb's
    ''' self-registration branch (PLANTED-VB-HR-151), which authenticates the caller immediately
    ''' afterwards.
    ''' </summary>
    Public Sub Register(ByVal email As String, ByVal password As String)
        Dim ds As New DataSet
        If Not oDO.GetEmptyDataSet("usr_users", "", ED, EC, ds) Then

        End If
        With ds.Tables(0).Rows(0)
            .Item("sit_id") = oSite.SiteId
            .Item("usr_firstname") = "Guest"
            .Item("usr_lastname") = "Guest"
            .Item("usr_loginname") = email
            .Item("usr_description") = "self-registered"
            .Item("usr_password") = oCrypto.Encrypt(password)
            .Item("usr_email") = email
            .Item("usr_createddate") = Now.ToLongTimeString
            .Item("usr_updateddate") = Now.ToLongTimeString
            .Item("usr_hidden") = 0
            .Item("usr_deleted") = 0
        End With
        oDO.SaveDataSet("", ED, EC, ds, False)
    End Sub

    ''' <summary>
    ''' One-hop "trusted device" quick sign-in completion (PLANTED-VB-HR-152), reused by
    ''' SignIn.ascx.vb's QuickLogin branch. The visitor's pre-existing session is left untouched,
    ''' so any session id fixed on this visitor before the quick-login request now carries the
    ''' freshly-authenticated identity.
    ''' </summary>
    Public Sub CompleteQuickLogin(ByVal email As String)
        ' SINK: PLANTED-VB-HR-152
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub

    ''' <summary>
    ''' Safe twin of CompleteQuickLogin (PLANTED-VB-HR-152-safe): invalidates the visitor's
    ''' pre-existing session before granting it an authenticated identity.
    ''' </summary>
    Public Sub CompleteQuickLoginSafe(ByVal email As String)
        HttpContext.Current.Session.Abandon()
        ' SAFE_SINK: PLANTED-VB-HR-152-safe
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub

    ''' <summary>
    ''' Completes sign-in after a validated password-reset code (PLANTED-VB-HR-153) -- the second
    ''' of two hops beyond SignIn.ascx.vb's verify branch, called by the new
    ''' clsPasswordResetService (hop 1), never directly by the page itself.
    ''' </summary>
    Public Sub CompletePasswordReset(ByVal email As String)
        ' SINK: PLANTED-VB-HR-153
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub

    ''' <summary>
    ''' Safe twin of CompletePasswordReset (PLANTED-VB-HR-153-safe): invalidates the caller's
    ''' pre-existing session before issuing the forms-authentication cookie.
    ''' </summary>
    Public Sub CompletePasswordResetSafe(ByVal email As String)
        HttpContext.Current.Session.Abandon()
        ' SAFE_SINK: PLANTED-VB-HR-153-safe
        FormsAuthentication.SetAuthCookie(email, False)
    End Sub

End Class

