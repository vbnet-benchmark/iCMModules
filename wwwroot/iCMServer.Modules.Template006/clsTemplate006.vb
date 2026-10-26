Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls

Public Class clsTemplate006

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

    Public Function GetTemplate() As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_template006", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then

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

    Public Function UpdateTemplate(ByVal Header1 As String, ByVal Text1 As String) As Boolean
        Try
            Dim Exists As Boolean = False
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_template006", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
                Return False
            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Exists = True
                End If
            End If
            If Not Exists Then
                ds = New DataSet
                If Not oDO.GetEmptyDataSet("tem_template006", "", ED, EC, ds) Then
                    Return False
                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = Me.PagId
                    .Item("mod_id") = Me.ModId
                    .Item("tem_name") = "none"
                    .Item("tem_header1") = Header1
                    .Item("tem_text1") = Text1
                    .Item("tem_createddate") = Now.ToLongTimeString
                    .Item("tem_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_updateddate") = Now.ToLongTimeString
                    .Item("tem_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_hidden") = 0
                    .Item("tem_deleted") = 0
                End With
            Else
                With ds.Tables(0).Rows(0)
                    .Item("tem_header1") = Header1
                    .Item("tem_text1") = Text1
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

    Public Function UpdateTemplate(ByVal dsTemplate As DataSet) As Boolean
        Try
            If Not oDO.SaveDataSet("", ED, EC, dsTemplate, False) Then
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
            If Not oDO.GetDataSet("tem_template006", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
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
