Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls

Public Class clsTemplate009

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private IsAuthorized As Boolean = False

    Public Sub New(ByVal iModId As Integer, ByVal iPagId As Integer, ByVal bAuthorized As Boolean)
        Me.ModId = iModId
        Me.PagId = iPagId
        Me.IsAuthorized = bAuthorized
    End Sub

    Public Function GetSubMenuItem() As DataSet
        Try
            Dim ds As New DataSet
            Dim oDefine As New iConsulting.Library.Data.clsDefinedDataList
            oDefine.AddDefinedTableColumn("pag_id")
            oDefine.AddDefinedTableColumn("pag_name")
            oDefine.AddDefinedTableColumn("pag_authorizedroles")
            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = " & oSite.ActivePage.PageId & " AND pag_hidden = 0 AND pag_deleted = 0", "pag_order", "", ED, EC, ds) Then
                Throw New Exception
            End If
            For Each dr As DataRow In ds.Tables(0).Rows
                If Not clsSiteSecurity.IsInRoles(CType(dr("pag_authorizedroles"), String)) Then
                    dr.Delete()
                End If
            Next
            ds.AcceptChanges()
            Return ds
        Catch ex As Exception
            Return New DataSet
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
