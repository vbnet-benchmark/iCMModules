Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsLiteSites

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Protected oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function AddDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If ContentLength = 0 Then
                If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

                End If
                ds.Tables(0).Rows(0)("doc_name") = Name
                If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

                End If
            Else
                Me.DeleteAll(PageId, ModId)
                Dim oBlob As New clsBlobDataList
                oBlob.AddTableInfo("sit_id", oSite.SiteId, "int", "4", "10", False)
                oBlob.AddTableInfo("pag_id", PageId.ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("mod_id", ModId.ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("cat_id", CatId.ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_description", "-", "ntext", "1073741823", "0", False)
                oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
                oBlob.AddTableInfo("doc_contenttype", ContentType.ToString, "nvarchar", "200", "0", False)
                oBlob.AddTableInfo("doc_contentsize", ContentLength.ToString, "bigint", "8", "19", False)
                oBlob.AddTableInfo("doc_createddate", Now.ToLongDateString, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_createdby", User, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_updateddate", Now.ToLongDateString, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
                If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, Content, "", ED, EC, False) Then

                End If
            End If

            ds = New DataSet
            If Not oDO.GetDataSet("sit_sites", "sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("sit_logo") = "LiteMenuView.aspx?PageId=" & PageId & "&ModId=" & ModId
            ds.Tables(0).Rows(0)("sit_logohref") = Name
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer) As Boolean
        Dim ds As New DataSet
        Try
            Dim oBlob As New clsBlobDataList
            oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
            oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
            oBlob.AddTableInfo("doc_contenttype", ContentType.ToString, "nvarchar", "200", "0", False)
            oBlob.AddTableInfo("doc_contentsize", ContentLength.ToString, "bigint", "8", "19", False)
            oBlob.AddTableInfo("doc_updateddate", Now.ToLongDateString, "datetime", "8", "23", False)
            oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
            If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, oBlob.DataSet, Content, "", ED, EC, True) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteAll(ByVal PageId As Integer, ByVal ModId As Integer) As Boolean
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            For Each dr In ds.Tables(0).Rows
                dr.Delete()
            Next
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteDocument(ByVal PageId As Integer, ByVal ModId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0).Delete()
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            ds = New DataSet
            If Not oDO.GetDataSet("sit_sites", "sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("sit_logo") = ""
            ds.Tables(0).Rows(0)("sit_logohref") = ""
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

    Public Function GetMainDefinedDocument(ByVal PageId As Integer, ByVal ModId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefined As New clsDefinedDataList
            oDefined.AddDefinedTableColumn("doc_id")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefined.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetSiteInfo() As DataTable
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("sit_sites", "sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then

            End If
            Return ds.Tables(0)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

End Class
