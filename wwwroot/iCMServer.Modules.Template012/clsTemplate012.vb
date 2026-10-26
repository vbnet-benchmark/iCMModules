Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls

Public Class clsTemplate012

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
            Dim Page As clsPageSettings = CType(oSite.ActivePage, clsPageSettings)

            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = " & Page.PageParentId & " AND pag_hidden = 0 AND pag_deleted = 0", "pag_order", "", ED, EC, ds) Then
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

End Class
