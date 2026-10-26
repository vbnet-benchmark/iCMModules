Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Collections

Public Class clsLiteDocuments

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Protected oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetCatalogsAndFiles(ByVal PageId As Integer, ByVal ModId As Integer, Optional ByVal ParentId As Integer = 0) As DataSet
        Dim ds As DataSet
        Dim dsCat As New DataSet
        Dim dsDoc As New DataSet
        Dim dt As DataTable
        Dim dr As DataRow
        Dim drCat As DataRow
        Dim drDoc As DataRow
        Try
            Dim oDefined As New clsDefinedDataList
            oDefined.AddDefinedTableColumn("cat_id")
            oDefined.AddDefinedTableColumn("doc_id")
            oDefined.AddDefinedTableColumn("doc_name")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefined.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & ParentId & " AND doc_hidden = 0 AND doc_deleted = 0", "doc_id", "", ED, EC, dsDoc) Then

            End If
            If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_parentid = " & ParentId & " AND cat_hidden = 0 AND cat_deleted = 0", "cat_id", "", ED, EC, dsCat) Then

            End If

            ds = New DataSet("Content")
            dt = New DataTable("FoldersAndFiles")
            dt.Columns.Add("cat_id", System.Type.GetType("System.Int32"))
            dt.Columns.Add("doc_id", System.Type.GetType("System.Int32"))
            dt.Columns.Add("isfile", System.Type.GetType("System.Boolean"))
            dt.Columns.Add("name", System.Type.GetType("System.String"))

            For Each drCat In dsCat.Tables(0).Rows
                dr = dt.NewRow
                dr("cat_id") = drCat("cat_id")
                dr("doc_id") = 0
                dr("isfile") = False
                dr("name") = drCat("cat_name")
                dt.Rows.Add(dr)
            Next
            For Each drDoc In dsDoc.Tables(0).Rows
                dr = dt.NewRow
                dr("cat_id") = drDoc("cat_id")
                dr("doc_id") = drDoc("doc_id")
                dr("isfile") = True
                dr("name") = drDoc("doc_name")
                dt.Rows.Add(dr)
            Next

            ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try

    End Function

    Public Function GetCatalogs(ByVal PageId As Integer, ByVal ModId As Integer, ByRef ddl As DropDownList, Optional ByVal cat_id As Integer = 0)
        ddl.Items.Clear()
        Dim li As ListItem
        li = New ListItem
        li.Text = "Mina Dokument"
        li.Value = "0"
        ddl.Items.Add(li)

        If Not cat_id = 0 Then
            GetParentCatalog(PageId, ModId, ddl, cat_id, 0)
        End If

        ddl.Items(ddl.Items.Count - 1).Text = "*" & " " & ddl.Items(ddl.Items.Count - 1).Text
        ddl.Items(ddl.Items.Count - 1).Selected = True

    End Function

    Private Function GetParentCatalog(ByVal PageId As Integer, ByVal ModId As Integer, ByRef ddl As DropDownList, ByVal cat_id As Integer, ByVal Indent As Integer) As Boolean
        Dim ds As New DataSet
        Dim li As ListItem
        Dim i As Integer
        Dim sI As String
        If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & cat_id, "", "", ED, EC, ds) Then

        End If
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                If Not ds.Tables(0).Rows(0)("cat_parentid") = 0 Then
                    GetParentCatalog(PageId, ModId, ddl, ds.Tables(0).Rows(0)("cat_parentid"), Indent)
                    li = New ListItem
                    li.Text = ds.Tables(0).Rows(0)("cat_name")
                    li.Value = ds.Tables(0).Rows(0)("cat_id")
                    ddl.Items.Add(li)
                Else
                    li = New ListItem
                    li.Text = ds.Tables(0).Rows(0)("cat_name")
                    li.Value = ds.Tables(0).Rows(0)("cat_id")
                    ddl.Items.Add(li)
                End If
            End If
        End If
    End Function

    Public Function AddCatalog(ByVal PageId As Integer, ByVal ModId As Integer, ByVal cat_id As Integer, ByVal Name As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("cat_catalogs", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = PageId
                .Item("mod_id") = ModId
                .Item("cat_parentid") = cat_id
                .Item("cat_name") = Name
                .Item("cat_description") = " "
                .Item("cat_createddate") = Now
                .Item("cat_createdby") = HttpContext.Current.User.Identity.Name.ToString
                .Item("cat_updateddate") = Now
                .Item("cat_updatedby") = HttpContext.Current.User.Identity.Name.ToString
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateCatalog(ByVal PageId As Integer, ByVal ModId As Integer, ByVal cat_id As Integer, ByVal Name As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & cat_id, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("cat_name") = Name
                .Item("cat_description") = " "
                .Item("cat_updateddate") = Now
                .Item("cat_updatedby") = HttpContext.Current.User.Identity.Name.ToString
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteCatalog(ByVal PageId As Integer, ByVal ModId As Integer, ByVal cat_id As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId & " AND cat_id = " & cat_id, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("cat_deleted") = 1
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

    Public Function AddDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer) As Boolean
        Dim ds As New DataSet
        Try
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
End Class
