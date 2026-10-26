Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.SessionState
Imports iConsulting
Imports iConsulting.iCMServer
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security

Public Class clsQuicklinks

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetQuicklinks(ByVal ModId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_hidden = 0 AND qui_deleted = 0", "qui_order", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetQuicklink(ByVal ModId As Integer, ByVal QuiId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_id = " & QuiId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteQuicklink(ByVal ModId As Integer, ByVal QuiId As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_id = " & QuiId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("qui_deleted") = 1
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

    Public Function AddQuicklink(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Url As String, ByVal Target As String, ByVal Order As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("qui_quicklinks", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("qui_title") = Title
                .Item("qui_description") = Description
                .Item("qui_url") = Url & "|" & Target
                .Item("qui_order") = Order
                .Item("qui_createddate") = Now.ToShortDateString
                .Item("qui_createdby") = HttpContext.Current.User.Identity.Name
                .Item("qui_updateddate") = Now.ToShortDateString
                .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("qui_hidden") = 0
                .Item("qui_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateQuicklink(ByVal ModId As Integer, ByVal QuiId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Url As String, ByVal Target As String, ByVal Order As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND pag_id = " & PagId & " AND qui_id = " & QuiId, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("qui_title") = Title
                .Item("qui_description") = Description
                .Item("qui_url") = Url & "|" & Target
                .Item("qui_order") = Order
                .Item("qui_updateddate") = Now.ToShortDateString
                .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetPages(ByVal sRoles As String) As DataSet
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId, "pag_pageparentid,pag_order", "", ED, EC, ds) Then

            End If
            For Each dr In ds.Tables(0).Rows
                If CheckPagePermission(sRoles, dr("pag_authorizedroles")) Then
                    dr("pag_deleted") = False
                Else
                    dr("pag_deleted") = True
                End If
            Next

            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Private Function CheckPagePermission(ByVal sRoles As String, ByVal AuthorizedRoles As String) As Boolean
        Dim aPage As New System.Collections.ArrayList
        Dim aPages() As String
        Dim l As ListItem
        Dim page As String
        For Each page In AuthorizedRoles.Split(New Char() {";"c})
            aPage.Add(page)
        Next
        aPages = CType(aPage.ToArray(GetType(String)), String())


        Dim role As String
        Dim i As Integer
        For i = 0 To aPages.Length - 1
            For Each role In sRoles.Split(New Char() {";"c})
                If aPages(i).ToString = role.ToString Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

End Class
