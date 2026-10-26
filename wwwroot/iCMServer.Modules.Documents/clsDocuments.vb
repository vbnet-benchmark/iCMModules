Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System
Imports System.ComponentModel


Public Class clsDocuments

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetNodesAsXML(ByVal ModuleId As Integer, ByVal id As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   GetNodesAsXML for Child Nodes
        'Parameters:    moduleId
        '               id
        'Returns:       String
        'Comments:      -
        'Revision:      Johan Olofsson, 2002-11-21, Created
        '               Johan Olofsson, 2003-09-08, Edited
        '-------------------------------------------------------------------------

        Const XML_TREE_START = "<?xml version='1.0' encoding='ISO-8859-1'?>" & vbCrLf & "<tree>" & vbCrLf
        Const XML_TREE_END = "</tree>" & vbCrLf
        Const TREE_ENGINE_FILE = "Desktop/Modules/Documents/DocumentsEngine.aspx"
        Const DEFAULT_XML = "<tree text='No items avalible' icon='Desktop/Modules/Documents/XLoadTree/images/xp/file.png' openIcon='Desktop/Modules/Documents/XLoadTree/images/xp/file.png'></tree>"

        ' Standard variables
        Dim sXML As String
        Dim sSQL As String
        Dim myDataSet As New DataSet
        Dim myRow As DataRow
        Dim sIcon As String
        Dim sOpenIcon As String
        Dim bHaveChild As Boolean

        If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND cat_parentid = " & id & " AND mod_id = " & ModuleId & " AND cat_hidden = 0 AND cat_deleted = 0", "cat_name", "", ED, EC, myDataSet) Then

        End If

        ' Do Shit
        sXML = XML_TREE_START

        ' x
        If myDataSet.Tables(0).Rows.Count = 0 Then
            sXML += DEFAULT_XML
        End If

        ' Loop all Nodes
        For Each myRow In myDataSet.Tables(0).Rows
            bHaveChild = CheckForChild(ModuleId, myRow("cat_id"))
            sIcon = "Desktop/Modules/Documents/XLoadTree/images/xp/folder.png"
            sOpenIcon = "Desktop/Modules/Documents/XLoadTree/images/xp/openfolder.png"
            If Not bHaveChild Then
                sXML += CreateNodeStart(myRow("cat_name"), "", "javascript:GetDocuments" & ModuleId.ToString & "(" & myRow("cat_id") & ")", sIcon, sOpenIcon)
                sXML += CreateNodeEnd()
            Else
                sXML += CreateNodeStart(myRow("cat_name"), TREE_ENGINE_FILE & "?sID=" & myRow("cat_id") & "," & ModuleId & ",0", "javascript:GetDocuments" & ModuleId.ToString & "(" & myRow("cat_id") & ")", sIcon, sOpenIcon)
                sXML += CreateNodeEnd()
            End If
            bHaveChild = False
        Next

        sXML += XML_TREE_END

        ' Well, everything seems to be OK, let's say it did
        Return sXML

    End Function

    Private Function CheckForChild(ByVal ModuleId As Integer, ByVal RollupID As Integer) As Boolean
        '-------------------------------------------------------------------------
        'Description:   CheckForChild
        'Parameters:    ModuleId
        '               RollupID
        'Returns:       Boolean
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2001-11-22, Created 
        '               Johan Olofsson, 2003-09-08, Edited
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim myDataSet As New DataSet
        Dim myDataAdapter As New SqlClient.SqlDataAdapter
        Dim sSQL As String
        Try

            ' Do Shit
            If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModuleId & " AND cat_parentid = " & RollupID & " AND cat_hidden = 0 AND cat_deleted = 0", "", "", ED, EC, myDataSet) Then

            End If

            If myDataSet.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If

        Catch
            Return False

        End Try

    End Function

    Private Function CreateNodeStart(ByVal sTitle As String, ByVal sSrc As String, ByVal sAction As String, ByVal sIcon As String, ByVal sOpenIcon As String) As String
        '-------------------------------------------------------------------------
        'Description:   CreateNodeStart
        'Parameters:    sTitle
        '               sSrc
        '               sAction
        '               sIcon
        '               sOpenIcon
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2001-10-10, Created 
        '               Johan Olofsson 2001-10-10, Edited
        '-------------------------------------------------------------------------

        Const XML_NODE_START = "<tree text='"
        Const XML_NODE_SRC = "' src='"
        Const XML_NODE_ACTION = "' action='"
        Const XML_NODE_ICON = "' icon='"
        Const XML_NODE_OPENICON = "' openIcon='"
        Const XML_NODE_END = "'>" & vbCrLf

        ' Standard variables
        Dim sXML As String

        ' Do Shit
        sXML = XML_NODE_START & _
               System.Web.HttpUtility.HtmlEncode(sTitle) & _
               XML_NODE_SRC & _
               sSrc & _
               XML_NODE_ACTION & _
               sAction & _
               XML_NODE_ICON & _
               sIcon & _
               XML_NODE_OPENICON & _
               sOpenIcon & _
               XML_NODE_END

        Return sXML

    End Function

    Private Function CreateNodeEnd() As String
        '-------------------------------------------------------------------------
        'Description:   CreateNodeEnd
        'Parameters:    -
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2001-10-10, Created 
        '               Johan Olofsson 2001-10-10, Edited
        '-------------------------------------------------------------------------

        Const XML_NODE_END = "</tree>" & vbCrLf

        ' Standard variables
        Dim sXML As String

        ' Do Shit
        sXML = XML_NODE_END

        Return sXML

    End Function

    Public Function GetDocuments(ByVal ModId As Integer, ByVal CatId As Integer, ByVal UrlReferrer As String, ByVal NodeList As String, ByRef Folder As String, ByVal HasEditAuth As Boolean) As String
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font style='FONT-WEIGHT: bold; COLOR: black; FONT-FAMILY: Verdana'>"
            Const FONT_END = "</font>"
            Dim JAVA_SCRIPT As String = "<script language='javascript'>" & _
                                            "function GetSingleDocument" & ModId.ToString & "(DocId,ModId,CatId){try{window.open('DocumentsStream.aspx?CatId='+CatId+'&ModId='+ModId+'&DocId='+DocId)}catch(e){}}" & _
                                            "function EditDoc" & ModId.ToString & "(DocId,ModId,CatID){try{window.open('../DesktopModules/EditDocs.aspx?DocId='+DocId+'&ModId='+ModId+'&CatID='+CatID+'&url=" & UrlReferrer & "&NodeList=" & NodeList & "&From=inner" & "')}catch(e){}}" & _
                                            "function EditDoc2" & ModId.ToString & "(DocId,ModId,CatId){try{window.parent.document.getElementById('FileContainer" & ModId.ToString & "').src='Desktop/Modules/Documents/DocumentsEdit.aspx?CatId='+CatId+'&ModId='+ModId+'&DocId='+DocId;}catch(e){}}" & _
                                        "</script>" & GetReadOnlyDocument(ModId)

            ' Standard variables
            Dim sMetaList As String
            Dim ds As New DataSet
            Dim dr As DataRow
            Dim oDefine As New clsDefinedDataList

            ' Get the Folder title ...
            If Not CatId = 0 Then
                oDefine.AddDefinedTableColumn("cat_name")
                If Not oDO.GetDefinedDataSet("cat_catalogs", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND cat_id = " & CatId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

                End If
                Folder = ds.Tables(0).Rows(0)("cat_name")
            Else
                oDefine.AddDefinedTableColumn("mod_title")
                If Not oDO.GetDefinedDataSet("mod_modules", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

                End If
                Folder = ds.Tables(0).Rows(0)("mod_title")
            End If

            ' Get the documents info ....
            ds = New DataSet
            oDefine = New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND cat_id = " & CatId & " AND mod_id = " & ModId & " AND doc_hidden = 0 AND doc_deleted = 0", "doc_name", "", ED, EC, ds) Then

            End If

            ' Sort new
            Dim First As New System.Collections.ArrayList
            Dim Third As New System.Collections.ArrayList
            For Each dri As DataRow In ds.Tables(0).Rows
                Dim _d As New DocumentItem
                _d.ID = dri("doc_id")
                _d.Name = dri("doc_name")
                _d.ContentSize = dri("doc_contentsize")
                _d.UpdatedDate = dri("doc_updateddate")
                First.Add(_d)
            Next
            Dim FileArray(First.Count - 1) As String
            Dim i As Integer = 0
            For Each d As DocumentItem In First
                FileArray(i) = d.Name
                i += 1
            Next
            Array.Sort(FileArray, New IConsultingFileComparer)
            For i = FileArray.GetLowerBound(0) To FileArray.GetUpperBound(0)
                For Each d As DocumentItem In First
                    If FileArray(i).ToLower = d.Name.ToLower Then
                        Dim _d As New DocumentItem
                        _d.ID = d.ID
                        _d.Name = d.Name
                        _d.ContentSize = d.ContentSize
                        _d.UpdatedDate = d.UpdatedDate
                        Third.Add(_d)
                    End If
                Next
            Next
            sMetaList += JAVA_SCRIPT
            For Each d As DocumentItem In Third
                sMetaList += "<TR>" & vbCrLf
                sMetaList += "  <TD WIDTH=5%>" & vbCrLf
                If HasEditAuth Then
                    sMetaList += "    <IMG src='Images/edit.gif' style='cursor:hand' ONCLICK='EditDoc2" & ModId.ToString & "(" & d.ID & "," & ModId & "," & CatId & ")'></IMG>" & vbCrLf
                End If
                sMetaList += "  </TD>" & vbCrLf
                sMetaList += "  <TD WIDTH=50%>" & vbCrLf
                sMetaList += "    <DIV ID=1" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & d.ID & "," & ModId & "," & CatId & ")'>&nbsp;" & FONT_START & d.Name & FONT_END & "</DIV>" & vbCrLf
                sMetaList += "  </TD>" & vbCrLf
                sMetaList += "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf
                sMetaList += "    <DIV ID=2" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & d.ID & "," & ModId & "," & CatId & ")'>&nbsp;" & FONT_START & IIf(Left(CType(d.ContentSize / 1024, Double).ToString("00"), 1) = "0", Right(CType(d.ContentSize / 1024, Double).ToString("00"), Len(CType(d.ContentSize / 1024, Double).ToString("00")) - 1), CType(d.ContentSize / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf
                sMetaList += "  </TD>" & vbCrLf
                sMetaList += "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf
                sMetaList += "    <DIV ID=6" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & d.ID & "," & ModId & "," & CatId & ")'>" & FONT_START & d.UpdatedDate & FONT_END & "</DIV>" & vbCrLf
                sMetaList += "  </TD>" & vbCrLf
                sMetaList += "</TR>"
            Next

            Return sMetaList
        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Private Function AddSpace(ByVal s As String, ByVal l As Integer) As String
        Dim sp As String = String.Empty
        For i As Integer = 1 To l
            sp += " "
        Next
        Return sp & s
    End Function

    Public Function AddFolder(ByVal PagId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal Title As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("cat_catalogs", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("cat_parentid") = CatId
                .Item("cat_name") = Title
                .Item("cat_description") = ""
                .Item("cat_createdby") = HttpContext.Current.User.Identity.Name
                .Item("cat_createddate") = Now.ToShortDateString
                .Item("cat_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("cat_updateddate") = Now.ToShortDateString
                .Item("cat_hidden") = 0
                .Item("cat_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateFolder(ByVal PagId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal Title As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cat_catalogs", "cat_id = " & CatId & " AND mod_id = " & ModId & " AND pag_id = " & PagId & " AND cat_hidden = 0 AND cat_deleted = 0", "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("cat_name") = Title
                .Item("cat_description") = ""
                .Item("cat_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("cat_updateddate") = Now.ToShortDateString
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Deletefolder(ByVal PagId As Integer, ByVal ModId As Integer, ByVal CatId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cat_catalogs", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND cat_id = " & CatId, "", "", ED, EC, ds) Then

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

    Public Function AddDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer, ByVal Revision As Integer, ByVal Rollup As Integer) As Boolean
        Dim ds As New DataSet
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
            If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, Content, "", ED, EC, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateDocument(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer, ByVal Revision As Integer, ByVal Rollup As Integer) As Boolean
        Dim ds As New DataSet
        If oSite.SiteSoftDelete Then
            Try
                ' Get the old document info and put it into some variables, for now...
                Dim NewContent As Byte()
                Dim NewContentLength As Integer
                Dim NewContentType As String
                Dim NewRevision As Integer
                Dim NewRollup As Integer
                Dim dr As DataRow
                ds = New DataSet
                If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then
                    Throw New Exception("Error in: GetDataSet")
                End If
                dr = ds.Tables(0).Rows(0)
                ds.Dispose()
                ds = Nothing
                If Not ContentLength = 0 Then
                    NewContent = Content
                    Content = Nothing
                    NewContentLength = ContentLength
                    NewContentType = ContentType
                    NewRevision = (CType(dr("doc_revision"), Integer) + 1)
                    NewRollup = dr("doc_id")
                Else
                    NewContent = dr("doc_content")
                    NewContentLength = dr("doc_contentsize")
                    NewContentType = dr("doc_contenttype")
                    NewRevision = (CType(dr("doc_revision"), Integer) + 1)
                    NewRollup = dr("doc_id")
                End If
                ' Save the new document...
                Dim oBlob As New clsBlobDataList
                oBlob.AddTableInfo("sit_id", oSite.SiteId, "int", "4", "10", False)
                oBlob.AddTableInfo("pag_id", dr("pag_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("mod_id", dr("mod_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("cat_id", dr("cat_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_rollup", NewRollup, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_revision", NewRevision, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_description", "-", "ntext", "1073741823", "0", False)
                oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
                oBlob.AddTableInfo("doc_contenttype", NewContentType.ToString, "nvarchar", "200", "0", False)
                oBlob.AddTableInfo("doc_contentsize", NewContentLength.ToString, "bigint", "8", "19", False)
                oBlob.AddTableInfo("doc_createddate", dr("doc_createddate"), "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_createdby", dr("doc_createdby"), "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_updateddate", Now, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_hidden", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
                oBlob.AddTableInfo("doc_deleted", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
                dr = Nothing
                If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, NewContent, "", ED, EC, False) Then
                    Throw New Exception("Error in: SaveBlobData")
                End If
                If Not HideOldDocument(ModId, CatId, DocId) Then
                    Throw New Exception("Error in: HideOldDocument")
                End If
                NewContent = Nothing
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Try
                Dim oBlob As New clsBlobDataList
                oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
                If Not ContentLength = 0 Then
                    oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
                    oBlob.AddTableInfo("doc_contenttype", ContentType.ToString, "nvarchar", "200", "0", False)
                    oBlob.AddTableInfo("doc_contentsize", ContentLength.ToString, "bigint", "8", "19", False)
                End If
                oBlob.AddTableInfo("doc_updateddate", Now, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
                If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, oBlob.DataSet, Content, "", ED, EC, True) Then
                    Throw New Exception("Error in: SaveBlobData")
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

    End Function

    Public Function GetDocument(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetDocumentInfo(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_name")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteDocument(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

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

    Public Function CheckIfFileAlreadyExists(ByVal PagId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal Title As String) As Integer
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND cat_id = " & CatId & " AND doc_name = '" & Title & "'", "doc_id DESC", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)("doc_id")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetDocumentRevisions(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font color=red face=verdana size=1>"
            Const FONT_END = "</font>"
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_rollup")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            oDefine.AddDefinedTableColumn("doc_revision")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND cat_id = " & CatId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Dim MetaData As String
            MetaData += "<script language='javascript'>"
            MetaData += "function GetSingleDocument" & ModId.ToString & "(DocId,ModId,CatId){window.open('DocumentsStream.aspx?CatId='+CatId+'&ModId='+ModId+'&DocId='+DocId)}"
            MetaData += "</script>"
            MetaData += "<div style='OVERFLOW:auto;HEIGHT:120px'><table>"
            dr = ds.Tables(0).Rows(0)
            Dim Revision As Integer = dr("doc_revision")
            MetaData += "<TR>" & _
                         "  <TD WIDTH=5%>" & vbCrLf & _
                         "    <DIV ID=1" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(dr("doc_revision") = 1, "Org:", "Rev:") & dr("doc_revision").ToString & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=50%>" & vbCrLf & _
                         "    <DIV ID=2" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_name") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=3" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(Left(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), 1) = "0", Right(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), Len(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) - 1), CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=4" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_updateddate") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "</TR>"
            If Not dr("doc_rollup") = 0 Then
                If Not GetDocumentRevisionParent(ModId, CatId, dr("doc_rollup"), MetaData, Revision) Then

                End If
            End If

            MetaData += "</table></div>"

            Return MetaData

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetDocumentRevisionParent(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer, ByRef MetaData As String, ByRef Revision As Integer) As Boolean
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font color=red face=verdana size=1>"
            Const FONT_END = "</font>"
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_rollup")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            oDefine.AddDefinedTableColumn("doc_revision")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND cat_id = " & CatId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "doc_id", "", ED, EC, ds) Then

            End If
            dr = ds.Tables(0).Rows(0)
            MetaData += "<TR>" & _
                         "  <TD WIDTH=5%>" & vbCrLf & _
                         "    <DIV ID=1" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(dr("doc_revision") = 1, "Org:", "Rev:") & dr("doc_revision").ToString & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=50%>" & vbCrLf & _
                         "    <DIV ID=2" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_name") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=3" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(Left(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), 1) = "0", Right(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), Len(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) - 1), CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=4" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & "," & CatId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_updateddate") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "</TR>"
            If Not dr("doc_rollup") = 0 Then
                If Not GetDocumentRevisionParent(ModId, CatId, dr("doc_rollup"), MetaData, Revision) Then

                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateModuleViewState(ByVal PagId As Integer, ByVal ModId As Integer, ByVal ViewState As Boolean) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("mod_modules", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id=" & ModId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("mod_editsrc") = ViewState.ToString
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetModule(ByVal ModId As Integer) As clsModuleSettings

        Dim _module As clsModuleSettings
        For Each _module In oSite.ActivePage.Modules

            If _module.ModuleId = ModId Then
                Return _module
            End If

        Next _module

        Return Nothing

    End Function

    ' Simple Files Functions

    Public Function AddDocumentSimple(ByVal PageId As Integer, ByVal ModId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer, ByVal Revision As Integer, ByVal Rollup As Integer) As Boolean
        Dim ds As New DataSet
        Try
            Dim oBlob As New clsBlobDataList
            oBlob.AddTableInfo("sit_id", oSite.SiteId, "int", "4", "10", False)
            oBlob.AddTableInfo("pag_id", PageId.ToString, "int", "4", "10", False)
            oBlob.AddTableInfo("mod_id", ModId.ToString, "int", "4", "10", False)
            oBlob.AddTableInfo("cat_id", 0, "int", "4", "10", False)
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
            If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, Content, "", ED, EC, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateDocumentSimple(ByVal ModId As Integer, ByVal DocId As Integer, ByVal User As String, ByVal Name As String, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentLength As Integer, ByVal Revision As Integer, ByVal Rollup As Integer) As Boolean
        Dim ds As New DataSet
        If oSite.SiteSoftDelete Then
            Try
                ' Get the old document info and put it into some variables, for now...
                Dim NewContent As Byte()
                Dim NewContentLength As Integer
                Dim NewContentType As String
                Dim NewRevision As Integer
                Dim NewRollup As Integer
                Dim dr As DataRow
                If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then
                    Throw New Exception("Error in: GetDataSet")
                End If
                dr = ds.Tables(0).Rows(0)
                ds.Dispose()
                ds = Nothing
                If Not ContentLength = 0 Then
                    NewContent = Content
                    Content = Nothing
                    NewContentLength = ContentLength
                    NewContentType = ContentType
                    NewRevision = (CType(dr("doc_revision"), Integer) + 1)
                    NewRollup = dr("doc_id")
                Else
                    NewContent = dr("doc_content")
                    NewContentLength = dr("doc_contentsize")
                    NewContentType = dr("doc_contenttype")
                    NewRevision = (CType(dr("doc_revision"), Integer) + 1)
                    NewRollup = dr("doc_id")
                End If
                ' Save the new document...
                Dim oBlob As New clsBlobDataList
                oBlob.AddTableInfo("sit_id", oSite.SiteId, "int", "4", "10", False)
                oBlob.AddTableInfo("pag_id", dr("pag_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("mod_id", dr("mod_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("cat_id", dr("cat_id").ToString, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_rollup", NewRollup, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_revision", NewRevision, "int", "4", "10", False)
                oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_description", "-", "ntext", "1073741823", "0", False)
                oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
                oBlob.AddTableInfo("doc_contenttype", NewContentType.ToString, "nvarchar", "200", "0", False)
                oBlob.AddTableInfo("doc_contentsize", NewContentLength.ToString, "bigint", "8", "19", False)
                oBlob.AddTableInfo("doc_createddate", dr("doc_createddate"), "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_createdby", dr("doc_createdby"), "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_updateddate", Now, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
                oBlob.AddTableInfo("doc_hidden", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
                oBlob.AddTableInfo("doc_deleted", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", False, 0), Nothing, Nothing, Nothing, False)
                dr = Nothing
                If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId, oBlob.DataSet, NewContent, "", ED, EC, False) Then
                    Throw New Exception("Error in: SaveBlobData")
                End If
                If Not HideOldDocument(ModId, 0, DocId) Then
                    Throw New Exception("Error in: HideOldDocument")
                End If
                NewContent = Nothing
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Try
                Dim oBlob As New clsBlobDataList
                oBlob.AddTableInfo("doc_name", Name, "nvarchar", "255", "0", False)
                If Not ContentLength = 0 Then
                    oBlob.AddTableInfo("doc_content", "", "image", "2147483647", "0", True)
                    oBlob.AddTableInfo("doc_contenttype", ContentType.ToString, "nvarchar", "200", "0", False)
                    oBlob.AddTableInfo("doc_contentsize", ContentLength.ToString, "bigint", "8", "19", False)
                End If
                oBlob.AddTableInfo("doc_updateddate", Now, "datetime", "8", "23", False)
                oBlob.AddTableInfo("doc_updatedby", User, "nvarchar", "255", "0", False)
                If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, oBlob.DataSet, Content, "", ED, EC, True) Then
                    Throw New Exception("Error in: SaveBlobData")
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

    End Function

    Public Function CheckIfFileAlreadyExistsSimple(ByVal PagId As Integer, ByVal ModId As Integer, ByVal Title As String) As Integer
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND cat_id = 0 AND mod_id = " & ModId & " AND doc_name = '" & Title & "'", "doc_id DESC", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)("doc_id")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetDocumentInfoSimple(ByVal ModId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_name")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteDocumentSimple(ByVal ModId As Integer, ByVal DocId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

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

    Public Function GetDocumentRevisionsSimple(ByVal ModId As Integer, ByVal DocId As Integer) As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font color=red face=verdana size=1>"
            Const FONT_END = "</font>"
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_rollup")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            oDefine.AddDefinedTableColumn("doc_revision")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            Dim MetaData As String
            MetaData += "<script language='javascript'>"
            MetaData += "function GetSingleDocument" & ModId.ToString & "(DocId,ModId){window.open('DocumentsStream.aspx?ModId='+ModId+'&DocId='+DocId)}"
            MetaData += "</script>"
            MetaData += "<div style='OVERFLOW:auto;HEIGHT:120px'><table>"
            dr = ds.Tables(0).Rows(0)
            Dim Revision As Integer = dr("doc_revision")
            MetaData += "<TR>" & _
                         "  <TD WIDTH=5%>" & vbCrLf & _
                         "    <DIV ID=1" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(dr("doc_revision") = 1, "Org:", "Rev:") & dr("doc_revision").ToString & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=50%>" & vbCrLf & _
                         "    <DIV ID=2" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_name") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=3" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(Left(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), 1) = "0", Right(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), Len(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) - 1), CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=4" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_updateddate") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "</TR>"
            If Not dr("doc_rollup") = 0 Then
                If Not GetDocumentRevisionParentSimple(ModId, dr("doc_rollup"), MetaData, Revision) Then

                End If
            End If

            MetaData += "</table></div>"

            Return MetaData

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetDocumentRevisionParentSimple(ByVal ModId As Integer, ByVal DocId As Integer, ByRef MetaData As String, ByRef Revision As Integer) As Boolean
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font color=red face=verdana size=1>"
            Const FONT_END = "</font>"
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_rollup")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            oDefine.AddDefinedTableColumn("doc_revision")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, "doc_id", "", ED, EC, ds) Then

            End If
            dr = ds.Tables(0).Rows(0)
            MetaData += "<TR>" & _
                         "  <TD WIDTH=5%>" & vbCrLf & _
                         "    <DIV ID=1" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(dr("doc_revision") = 1, "Org:", "Rev:") & dr("doc_revision").ToString & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=50%>" & vbCrLf & _
                         "    <DIV ID=2" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_name") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=3" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & IIf(Left(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), 1) = "0", Right(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00"), Len(CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) - 1), CType(CType(dr("doc_contentsize"), Integer) / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf & _
                         "    <DIV ID=4" & dr("doc_id") & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocument" & ModId.ToString & "(" & dr("doc_id") & "," & ModId & ")'>" & IIf(dr("doc_revision") = Revision, FONT_START, FONT_START2) & dr("doc_updateddate") & FONT_END & "</DIV>" & vbCrLf & _
                         "  </TD>" & vbCrLf & _
                         "</TR>"
            If Not dr("doc_rollup") = 0 Then
                If Not GetDocumentRevisionParentSimple(ModId, dr("doc_rollup"), MetaData, Revision) Then

                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetSimpleFiles(ByVal PagId As Integer, ByVal ModId As Integer, ByVal HasEditAuth As Boolean) As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            Const FONT_START = "<font color=#000000 face=verdana size=1>"
            Const FONT_START2 = "<font style='FONT-WEIGHT: bold; COLOR: black; FONT-FAMILY: Verdana'>"
            Const FONT_END = "</font>"
            Dim JAVA_SCRIPT As String = "<script language='javascript'>" & _
                                            "function GetSingleDocumentSimple" & ModId.ToString & "(DocId,ModId){window.open('Desktop/Modules/Documents/DocumentsStream.aspx?ModId='+ModId+'&DocId='+DocId)}" & _
                                            "function EditDocSimple" & ModId.ToString & "(DocId,ModId){window.open('Desktop/Modules/Documents/DocumentsEditSimple.aspx?ModId='+ModId+'&DocId='+DocId,'DocumentsEdit','Height=350,Width=500');}" & _
                                        "</script>" & GetReadOnlyDocument(ModId)
            Dim MetaData As String
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("doc_name")
            oDefine.AddDefinedTableColumn("doc_contentsize")
            oDefine.AddDefinedTableColumn("doc_updateddate")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND doc_hidden = 0 AND doc_deleted = 0", "doc_name", "", ED, EC, ds) Then

            End If

            ' Sort new
            Dim First As New System.Collections.ArrayList
            Dim Third As New System.Collections.ArrayList
            For Each dri As DataRow In ds.Tables(0).Rows
                Dim _d As New DocumentItem
                _d.ID = dri("doc_id")
                _d.Name = dri("doc_name")
                _d.ContentSize = dri("doc_contentsize")
                _d.UpdatedDate = dri("doc_updateddate")
                First.Add(_d)
            Next
            Dim FileArray(First.Count - 1) As String
            Dim i As Integer = 0
            For Each d As DocumentItem In First
                FileArray(i) = d.Name
                i += 1
            Next
            Array.Sort(FileArray, New IConsultingFileComparer)
            For i = FileArray.GetLowerBound(0) To FileArray.GetUpperBound(0)
                For Each d As DocumentItem In First
                    If FileArray(i).ToLower = d.Name.ToLower Then
                        Dim _d As New DocumentItem
                        _d.ID = d.ID
                        _d.Name = d.Name
                        _d.ContentSize = d.ContentSize
                        _d.UpdatedDate = d.UpdatedDate
                        Third.Add(_d)
                    End If
                Next
            Next

            MetaData += JAVA_SCRIPT & "<TABLE cellSpacing='0' cellPadding='1' width='100%' align='left' border='0'>"
            For Each d As DocumentItem In Third
                MetaData += "<TR>" & vbCrLf
                MetaData += "  <TD WIDTH=5%>" & vbCrLf
                If HasEditAuth Then
                    MetaData += "    <IMG src='Desktop/Modules/Documents/Images/edit.gif' style='cursor:hand' ONCLICK='EditDocSimple" & ModId.ToString & "(" & d.ID & "," & ModId & ")'></IMG>" & vbCrLf
                End If
                MetaData += "  </TD>" & vbCrLf
                MetaData += "  <TD WIDTH=50%>" & vbCrLf
                MetaData += "    <DIV ID=1" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocumentSimple" & ModId.ToString & "(" & d.ID & "," & ModId & ")'>&nbsp;" & FONT_START & d.Name & FONT_END & "</DIV>" & vbCrLf
                MetaData += "  </TD>" & vbCrLf
                MetaData += "  <TD WIDTH=15% ALIGN=RIGHT>" & vbCrLf
                MetaData += "    <DIV ID=2" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocumentSimple" & ModId.ToString & "(" & d.ID & "," & ModId & ")'>&nbsp;" & FONT_START & IIf(Left(CType(d.ContentSize / 1024, Double).ToString("00"), 1) = "0", Right(CType(d.ContentSize / 1024, Double).ToString("00"), Len(CType(d.ContentSize / 1024, Double).ToString("00")) - 1), CType(d.ContentSize / 1024, Double).ToString("00")) & " KB" & FONT_END & "</DIV>" & vbCrLf
                MetaData += "  </TD>" & vbCrLf
                MetaData += "  <TD WIDTH=30% ALIGN=RIGHT>" & vbCrLf
                MetaData += "    <DIV ID=6" & d.ID & " WIDTH='100%' style='cursor:hand' ONCLICK='GetSingleDocumentSimple" & ModId.ToString & "(" & d.ID & "," & ModId & ")'>" & FONT_START & d.UpdatedDate & FONT_END & "</DIV>" & vbCrLf
                MetaData += "  </TD>" & vbCrLf
                MetaData += "</TR>" & vbCrLf
            Next
            MetaData += "</TABLE>"

            Return MetaData
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function HideOldDocument(ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As Boolean
        Try
            Dim oBlob As New clsBlobDataList
            'oBlob.AddTableInfo("doc_hidden", True, "bit", "1", "1", False)
            oBlob.AddTableInfo("doc_hidden", IIf(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource") = "MSSQLServer", True, 1), Nothing, "1", "1", False)
            If Not oDO.SaveBlobData("doc_documents", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND doc_id = " & DocId, oBlob.DataSet, Nothing, "", ED, EC, True) Then
                Throw New Exception("Error in: HideOldDocument::SaveBlobData")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Common Files Functions

    Private Function GetReadOnlyDocument(ByVal ModId As Integer) As String
        Try
            Dim s As String
            s += "<script language='javascript'>"
            s += "function GetReadOnlyDocument" & ModId.ToString & "(DocId,ModId,CatId){try{window.open('DocumentsStream.aspx?CatId='+CatId+'&ModId='+ModId+'&DocId='+DocId,""Readonly"",""toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no"")}catch(e){}}"
            s += "function GetReadOnlyDocumentSimple" & ModId.ToString & "(DocId,ModId){try{window.open('Desktop/Modules/Documents/DocumentsStream.aspx?ModId='+ModId+'&DocId='+DocId,""Readonly"",""toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no"")}catch(e){}}"
            s += "</script>"
            Return s
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class

Public Class DocumentItem
    Public ID As String
    Public Name As String
    Public ContentSize As Integer
    Public UpdatedDate As String
End Class
