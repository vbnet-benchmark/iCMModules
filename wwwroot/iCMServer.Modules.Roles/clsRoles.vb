Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsRoles

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Protected oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function AddRole(ByVal Name As String, ByVal Description As String) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetEmptyDataSet("rol_roles", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("rol_name") = Name
                .Item("rol_description") = Description
                .Item("rol_createddate") = Now.ToLongTimeString
                .Item("rol_createdby") = HttpContext.Current.User.Identity.Name
                .Item("rol_updateddate") = Now.ToLongTimeString
                .Item("rol_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("rol_hidden") = 0
                .Item("rol_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRole(ByVal RolId As Integer, ByVal Name As String, ByVal Description As String) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("rol_roles", "sit_id = " & oSite.SiteId & " AND rol_id = " & RolId, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("rol_name") = Name
                .Item("rol_description") = Description
                .Item("rol_updateddate") = Now.ToLongTimeString
                .Item("rol_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteRole(ByVal RolId As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("rol_roles", "sit_id = " & oSite.SiteId & " AND rol_id = " & RolId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("rol_deleted") = 1
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetRoles() As DataTable
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("rol_roles", "sit_id = " & oSite.SiteId & " AND rol_hidden = 0 AND rol_deleted = 0", "rol_name", "", ED, EC, ds) Then

            End If
            Return ds.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Public Function GetRoleFromID(ByVal rol_id As Integer) As DataSet
        Dim dsUser As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("rol_roles", "rol_id = " & rol_id & " AND rol_hidden = 0 AND rol_deleted = 0 AND sit_id = " & oSite.SiteId, "", sError, ED, EC, dsUser) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Return dsUser
    End Function

    Public Function GetUsersFromID(ByVal rol_id As Integer) As DataSet
        Dim dsRoles As New DataSet
        Dim dsUserRoles As New DataSet
        Dim sError As String
        Dim sWhere As String = " "
        Dim i As Integer
        If Not oDO.GetDataSet("uro_userroles", "rol_id = " & rol_id & " AND uro_hidden = 0 AND uro_deleted = 0 AND sit_id = " & oSite.SiteId, "", sError, ED, EC, dsUserRoles) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        If dsUserRoles.Tables.Count > 0 Then
            If dsUserRoles.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsUserRoles.Tables(0).Rows.Count - 1
                    sWhere += dsUserRoles.Tables(0).Rows(i)("usr_id") & " OR usr_id = "
                Next
                sWhere = Left(sWhere, Len(sWhere) - 13)
                If Not oDO.GetDataSet("usr_users", "usr_id = " & sWhere & " AND usr_hidden = 0 AND usr_deleted = 0 AND sit_id = " & oSite.SiteId, "usr_firstname,usr_loginname", sError, ED, EC, dsRoles) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If
                Return dsRoles
            End If
            Return New DataSet
        End If
    End Function

    Public Function GetAllUsers() As DataSet
        Dim dsRoles As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("usr_users", "usr_hidden = 0 AND usr_deleted = 0 AND sit_id = " & oSite.SiteId, "usr_firstname,usr_loginname", sError, ED, EC, dsRoles) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Return dsRoles
    End Function

    Public Function InsertRoleToUser(ByVal rol_id As Integer, ByVal usr_id As Integer) As Boolean
        Try
            Dim dsUserRoles As New DataSet
            Dim sError As String
            If Not oDO.GetEmptyDataSet("uro_userroles", sError, ED, EC, dsUserRoles) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With dsUserRoles.Tables(0).Rows(0)
                .Item("usr_id") = usr_id
                .Item("sit_id") = oSite.SiteId
                .Item("rol_id") = rol_id
                .Item("uro_createddate") = Now
                .Item("uro_createdby") = HttpContext.Current.User.Identity.Name.ToString
                .Item("uro_updateddate") = Now
                .Item("uro_updatedby") = HttpContext.Current.User.Identity.Name.ToString
                .Item("uro_hidden") = False
                .Item("uro_deleted") = False
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, dsUserRoles, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RemoveRoleFromUser(ByVal rol_id As Integer, ByVal usr_id As Integer) As Boolean
        Try
            Dim dsUserRoles As New DataSet
            Dim sError As String
            If Not oDO.GetDataSet("uro_userroles", "usr_id = " & usr_id & " AND rol_id = " & rol_id & " AND sit_id = " & oSite.SiteId, "", sError, ED, EC, dsUserRoles) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Dim dr As DataRow
            For Each dr In dsUserRoles.Tables(0).Rows
                dr.Delete()
            Next
            If Not oDO.SaveDataSet(sError, ED, EC, dsUserRoles, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
