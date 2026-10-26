Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls
Imports System.IO

Public Class clsBB

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

    Public Function getBaby(ByVal iSelected As Integer) As DataSet
        Try
            Dim ds As New DataSet '
            If Not oDO.GetDataSet("bab_baby", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND bab_week=" & iSelected & " AND bab_hidden = 0 AND bab_deleted = 0", "", "", ED, EC, ds) Then
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

    Public Function getBabyByID(ByVal bab_id As Integer) As DataSet
        Try
            Dim ds As New DataSet '
            If Not oDO.GetDataSet("bab_baby", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND bab_id =" & bab_id & " AND bab_hidden = 0 AND bab_deleted = 0", "", "", ED, EC, ds) Then
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


    Public Function newBaby(ByVal Header1 As String, ByVal Text1 As String, ByVal week As Integer) As Integer
        Try
            Dim Exists As Boolean = False
            Dim ds As New DataSet
            Dim bab_id As Integer
            ''If Not oDO.GetDataSet("bab_baby", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND bab_hidden = 0 AND bab_deleted = 0", "", "", ED, EC, ds) Then
            ''    Return False
            ''End If
            ''If ds.Tables.Count > 0 Then
            ''    If ds.Tables(0).Rows.Count > 0 Then
            ''        Exists = True
            ''    End If
            ''End If
            If Not Exists Then
                ds = New DataSet
                Dim sError As String
                If Not oDO.GetEmptyDataSet("bab_baby", sError, ED, EC, ds) Then
                    Return sError
                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = Me.PagId
                    .Item("mod_id") = Me.ModId
                    .Item("bab_name") = "none"
                    .Item("bab_header1") = Header1
                    .Item("bab_text1") = Text1
                    .Item("bab_week") = week
                    .Item("bab_createddate") = Now.ToLongTimeString
                    .Item("bab_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("bab_updateddate") = Now.ToLongTimeString
                    .Item("bab_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("bab_hidden") = 0
                    .Item("bab_deleted") = 0
                End With
            Else
                With ds.Tables(0).Rows(0)
                    .Item("bab_header1") = Header1
                    .Item("bab_text1") = Text1
                    .Item("bab_updateddate") = Now.ToLongTimeString
                    .Item("bab_updatedby") = HttpContext.Current.User.Identity.Name
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                Return 0
            End If

            ds = New DataSet

            If Not oDO.GetDataSet("bab_baby", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND bab_hidden = 0 AND bab_deleted = 0", "bab_id", "", ED, EC, ds) Then
                Return 0
            End If
            Dim iCount As Integer
            If ds.Tables(0).Rows.Count = 0 Then
                bab_id = 0
            Else
                iCount = ds.Tables(0).Rows.Count - 1
            End If
            bab_id = ds.Tables(0).Rows(iCount)("bab_id")
            Return bab_id
        Catch ex As Exception
            Return 0
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

    Public Function DeleteBaby(ByVal id As Integer, ByVal path As String) As Boolean
        Try
            Dim imgName As String
            Dim ds As New DataSet
            If Not oDO.GetDataSet("bab_baby", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND bab_id= " & id & " AND bab_hidden = 0 AND bab_deleted = 0", "", "", ED, EC, ds) Then
                Return False
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                imgName = ds.Tables(0).Rows(0)("bab_id") & "_" & ds.Tables(0).Rows(0)("bab_week") & "_" & ModId & ".png"
                If oSite.SiteSoftDelete Then
                    ds.Tables(0).Rows(0)("bab_deleted") = 1
                Else
                    ds.Tables(0).Rows(0).Delete()
                End If
                If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                    Return False
                End If
                '/Test copy
                Try
                    Dim strOldFile As String
                    Dim strNewFile As String
                    strOldFile = path & "\" & imgName
                    strNewFile = path & "\Deleted\" & imgName
                    Dim fil1 As New FileInfo(strOldFile)
                    fil1.CopyTo(strNewFile, True)
                    fil1.Delete()
                Catch ex As Exception
                End Try
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
