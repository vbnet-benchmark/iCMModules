Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls

Public Class clsTemplate008

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

    Public Function GetHeadMenuItem() As DataSet
        Try
            Dim ds As New DataSet
            Dim oDefine As New iConsulting.Library.Data.clsDefinedDataList
            oDefine.AddDefinedTableColumn("pag_id")
            oDefine.AddDefinedTableColumn("pag_name")
            oDefine.AddDefinedTableColumn("pag_authorizedroles")
            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = 0 AND pag_level = 0 AND pag_hidden = 0 AND pag_deleted = 0", "pag_order", "", ED, EC, ds) Then
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

    Public Function GetTemplate() As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_Template008", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then

            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds
                End If
            End If
            Return New DataSet
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function UpdateTemplate(ByVal ToolTip1 As String, ByVal ToolTip2 As String, ByVal ToolTip3 As String, ByVal ToolTip4 As String, ByVal ToolTip5 As String, ByVal ToolTip6 As String, ByVal ToolTip7 As String, ByVal ToolTip8 As String, ByVal ToolTip9 As String, ByVal Text As String, ByVal PopupOn As Boolean, ByVal PopupText As String) As Boolean
        Try
            Dim Exists As Boolean = False
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_Template008", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
                Return False
            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Exists = True
                End If
            End If
            If Not Exists Then
                ds = New DataSet
                If Not oDO.GetEmptyDataSet("tem_Template008", "", ED, EC, ds) Then
                    Return False
                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = Me.PagId
                    .Item("mod_id") = Me.ModId
                    .Item("tem_name") = "none"
                    .Item("tem_tooltip1") = ToolTip1
                    .Item("tem_tooltip2") = ToolTip2
                    .Item("tem_tooltip3") = ToolTip3
                    .Item("tem_tooltip4") = ToolTip4
                    .Item("tem_tooltip5") = ToolTip5
                    .Item("tem_tooltip6") = ToolTip6
                    .Item("tem_tooltip7") = ToolTip7
                    .Item("tem_tooltip8") = ToolTip8
                    .Item("tem_tooltip9") = ToolTip9
                    .Item("tem_text") = Text
                    .Item("tem_popupon") = IIf(PopupOn, 1, 0)
                    .Item("tem_popupurl") = PopupText
                    .Item("tem_createddate") = Now.ToLongTimeString
                    .Item("tem_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_updateddate") = Now.ToLongTimeString
                    .Item("tem_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_hidden") = 0
                    .Item("tem_deleted") = 0
                End With
            Else
                With ds.Tables(0).Rows(0)
                    .Item("tem_tooltip1") = ToolTip1
                    .Item("tem_tooltip2") = ToolTip2
                    .Item("tem_tooltip3") = ToolTip3
                    .Item("tem_tooltip4") = ToolTip4
                    .Item("tem_tooltip5") = ToolTip5
                    .Item("tem_tooltip6") = ToolTip6
                    .Item("tem_tooltip7") = ToolTip7
                    .Item("tem_tooltip8") = ToolTip8
                    .Item("tem_tooltip9") = ToolTip9
                    .Item("tem_text") = Text
                    .Item("tem_popupon") = IIf(PopupOn, 1, 0)
                    .Item("tem_popupurl") = PopupText
                    .Item("tem_updateddate") = Now.ToLongTimeString
                    .Item("tem_updatedby") = HttpContext.Current.User.Identity.Name
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteTemplate() As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_Template008", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
                Return False
            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("tem_deleted") = 1
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
