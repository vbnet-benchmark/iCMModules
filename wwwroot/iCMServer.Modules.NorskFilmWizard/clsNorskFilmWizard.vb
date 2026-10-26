Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls
Imports System.IO

Public Class clsNorskFilmWizard

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

#Region "Document"

    Public Function AddDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer, ByVal Revision As Integer, ByVal Rollup As Integer) As Integer
        Dim sError As String
        Dim ds As New DataSet
        Dim doc_id As Integer
        Dim dsCount As New DataSet

        Try
            Dim oBlob As New clsBlobDataList
            oBlob.AddTableInfo("sit_id", oSite.SiteId, "int", "4", "10", False)
            oBlob.AddTableInfo("pag_id", PageId.ToString, "int", "4", "10", False)
            oBlob.AddTableInfo("mod_id", ModId.ToString, "int", "4", "10", False)
            oBlob.AddTableInfo("cat_id", CatId.ToString, "int", "4", "10", False)
            oBlob.AddTableInfo("doc_rollup", Rollup, "int", "4", "10", False)
            oBlob.AddTableInfo("doc_revision", Revision, "int", "4", "10", False)
            oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
            oBlob.AddTableInfo("doc_description", "-", "ntext", "1073741823", "0", False)
            oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
            oBlob.AddTableInfo("doc_contenttype", ContentType.ToString, "nvarchar", "200", "0", False)
            oBlob.AddTableInfo("doc_contentsize", ContentLength.ToString, "bigint", "8", "19", False)
            oBlob.AddTableInfo("doc_createddate", Now, "datetime", "8", "23", False)
            oBlob.AddTableInfo("doc_createdby", User, "nvarchar", "255", "0", False)
            oBlob.AddTableInfo("doc_updateddate", Now, "datetime", "8", "23", False)
            oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
            oBlob.AddTableInfo("doc_hidden", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
            oBlob.AddTableInfo("doc_deleted", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
            'If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, Content, "", ED, EC, False) Then
            'End If

            Dim iResult As Integer
            iResult = 0
            Dim c As Integer
            If Not oDO.SaveBlobData("doc_documentsnff", "sit_id = " & oSite.SiteId, oBlob.DataSet, Content, "", ED, EC, False) Then
            End If
            If Not oDO.GetDataSet("doc_documentsnff", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND doc_hidden = 0 and doc_deleted = 0", "", "", ED, EC, dsCount) Then
            End If
            doc_id = dsCount.Tables(0).Rows(dsCount.Tables(0).Rows.Count - 1)("doc_id")

            Dim dsNewInsert As New DataSet
            If Not oDO.GetEmptyDataSet("nor_norskFilmWizard", sError, ED, EC, dsNewInsert) Then
                Return sError
            End If
            With dsNewInsert.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = Me.PagId
                .Item("mod_id") = Me.ModId
                .Item("nor_name") = "TestIgen"
                .Item("nor_docID") = doc_id
                .Item("nor_createddate") = Now.ToLongTimeString
                .Item("nor_createdby") = HttpContext.Current.User.Identity.Name
                .Item("nor_updateddate") = Now.ToLongTimeString
                .Item("nor_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("nor_hidden") = 0
                .Item("nor_deleted") = 0
            End With

            If Not oDO.SaveDataSet("", ED, EC, dsNewInsert, False) Then
                Return False
            End If

            Return doc_id
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Function DeleteDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("doc_deleted") = 1
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

    Public Function GetDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetDefinedDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefined As New clsDefinedDataList
            oDefined.AddDefinedTableColumn("cat_id")
            oDefined.AddDefinedTableColumn("doc_id")
            oDefined.AddDefinedTableColumn("doc_name")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefined.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function


#End Region

#Region "Old"

    Public Function GetApplicationDetails(ByVal nor_id As Integer) As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("nor_norskFilmWizard", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND nor_hidden = 0 AND nor_deleted = 0 and nor_id=" & nor_id, "", "", ED, EC, ds) Then

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

    Public Function GetApplication() As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("nor_norskFilmWizard", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND nor_hidden = 0 AND nor_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
            'If ds.Tables.Count > 0 Then
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        Return ds
            '    End If
            'End If
            'Return New DataSet
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


    Public Function newApplication(ByVal nor_name As String) As Integer
        Try
            Dim Exists As Boolean = False
            Dim ds As New DataSet
            Dim bab_id As Integer
            If Not Exists Then
                ds = New DataSet
                Dim sError As String
                If Not oDO.GetEmptyDataSet("nor_norskFilmWizard", sError, ED, EC, ds) Then
                    Return sError
                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = Me.PagId
                    .Item("mod_id") = Me.ModId
                    .Item("nor_name") = nor_name
                    .Item("nor_createddate") = Now.ToLongTimeString
                    .Item("nor_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("nor_updateddate") = Now.ToLongTimeString
                    .Item("nor_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("nor_hidden") = 0
                    .Item("nor_deleted") = 0
                End With
            Else
                'With ds.Tables(0).Rows(0)
                '    .Item("bab_header1") = Header1
                '    .Item("bab_text1") = Text1
                '    .Item("bab_updateddate") = Now.ToLongTimeString
                '    .Item("bab_updatedby") = HttpContext.Current.User.Identity.Name
                'End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                Return 0
            End If

        Catch ex As Exception

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

#End Region

End Class
