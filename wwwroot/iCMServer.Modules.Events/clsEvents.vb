Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsEvents

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetEvents(ByVal ModId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If clsSiteSecurity.HasEditPermissions(ModId) Then
                If Not oDO.GetDataSet("eve_events", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND eve_hidden = 0 AND eve_deleted = 0", "", "", ED, EC, ds) Then

                End If
            Else
                If Not oDO.GetDataSet("eve_events", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND eve_hidden = 0 AND eve_deleted = 0 AND eve_showdate <= '" & Now.ToShortDateString & "' AND eve_hidedate >= '" & Now.ToShortDateString & "'", "eve_showdate", "", ED, EC, ds) Then

                End If
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetEvent(ByVal ModId As Integer, ByVal EveId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("eve_events", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND eve_id = " & EveId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteEvent(ByVal ModId As Integer, ByVal EveId As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("eve_events", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND eve_id = " & EveId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("eve_deleted") = 1
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

    Public Function AddEvent(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Link As String, ByVal Target As String, ByVal ShowDate As Date, ByVal HideDate As Date) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("eve_events", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("eve_title") = Title
                .Item("eve_description") = Description
                .Item("eve_link") = Link & "|" & Target
                .Item("eve_showdate") = ShowDate
                .Item("eve_hidedate") = HideDate
                .Item("eve_createddate") = Now.ToShortDateString
                .Item("eve_createdby") = HttpContext.Current.User.Identity.Name
                .Item("eve_updateddate") = Now.ToShortDateString
                .Item("eve_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("eve_hidden") = 0
                .Item("eve_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateEvent(ByVal ModId As Integer, ByVal EveId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Link As String, ByVal Target As String, ByVal ShowDate As Date, ByVal HideDate As Date) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("eve_events", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND pag_id = " & PagId & " AND eve_id = " & EveId, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("eve_title") = Title
                .Item("eve_description") = Description
                .Item("eve_link") = Link & "|" & Target
                .Item("eve_showdate") = ShowDate
                .Item("eve_hidedate") = HideDate
                .Item("eve_updateddate") = Now.ToShortDateString
                .Item("eve_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
