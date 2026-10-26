Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsDiscussion

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetTopLevelMessages(ByVal PagId As Integer, ByVal ModId As Integer) As DataSet
        Dim dsDis As New DataSet
        Dim dsChi As DataSet
        Dim dr As DataRow
        Dim dc As New DataColumn
        Dim oDefine As clsDefinedDataList
        Try
            ' Get all root nodes...
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_rollup = 0 AND dis_hidden = 0 AND dis_deleted = 0", "dis_id DESC", "", ED, EC, dsDis) Then

            End If

            ' Add a new column for holding child info...
            dc = New DataColumn("dis_childcount") : dsDis.Tables(0).Columns.Add(dc)

            ' Loop the nodes and look for child nodes...
            For Each dr In dsDis.Tables(0).Rows
                oDefine = New clsDefinedDataList
                oDefine.AddDefinedTableColumn("dis_id")
                dsChi = New DataSet
                If Not oDO.GetDefinedDataSet("dis_discussion", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_rollup = " & dr("dis_id") & " AND dis_hidden = 0 AND dis_deleted = 0", "", "", ED, EC, dsChi) Then

                End If
                dr("dis_childcount") = dsChi.Tables(0).Rows.Count
            Next

            Return dsDis
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetSubLevelMessages2(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As DataSet
        Dim dsDis As New DataSet
        Try
            ' Get all child for the specific node...
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_root = " & DisId & " AND dis_hidden = 0 AND dis_deleted = 0", "dis_rollup", "", ED, EC, dsDis) Then

            End If

            Return dsDis
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetSubLevelMessages(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As DataSet
        Dim dsRet As New DataSet
        Dim dcRet As DataColumn
        Dim drRet As DataRow
        Dim ds As New DataSet

        Dim dr As DataRow
        Try
            ' Get first level child for the specific node...
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_rollup = " & DisId & " AND dis_hidden = 0 AND dis_deleted = 0", "dis_id", "", ED, EC, ds) Then

            End If

            ' Clone the data structure...
            dsRet = ds.Clone

            ' Loop nodes and check for children...
            For Each dr In ds.Tables(0).Rows
                AddSubLevelNodes(dr, dsRet)
                CheckForChildren(PagId, ModId, dr("dis_id"), dsRet)
            Next

            Return dsRet
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Private Function CheckForChildren(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer, ByRef dsRet As DataSet)
        Dim ds As New DataSet
        Dim dr As DataRow
        If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_rollup = " & DisId & " AND dis_hidden = 0 AND dis_deleted = 0", "dis_id", "", ED, EC, ds) Then

        End If
        For Each dr In ds.Tables(0).Rows
            AddSubLevelNodes(dr, dsRet)
            CheckForChildren(PagId, ModId, dr("dis_id"), dsRet)
        Next
    End Function

    Private Function AddSubLevelNodes(ByVal dr As DataRow, ByRef dsRet As DataSet)
        Dim tdr As DataRow
        tdr = dsRet.Tables(0).NewRow
        With tdr
            .Item("dis_id") = dr("dis_id")
            .Item("sit_id") = dr("sit_id")
            .Item("mod_id") = dr("mod_id")
            .Item("pag_id") = dr("pag_id")
            .Item("dis_rollup") = dr("dis_rollup")
            .Item("dis_root") = dr("dis_root")
            .Item("dis_indent") = dr("dis_indent")
            .Item("dis_title") = dr("dis_title")
            .Item("dis_body") = dr("dis_body")
            .Item("dis_createddate") = dr("dis_createddate")
            .Item("dis_createdby") = dr("dis_createdby")
            .Item("dis_updateddate") = dr("dis_updateddate")
            .Item("dis_updatedby") = dr("dis_updatedby")
            .Item("dis_hidden") = 0
            .Item("dis_deleted") = 0
        End With
        dsRet.Tables(0).Rows.Add(tdr)
    End Function

    Public Function GetPreviusMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As Integer
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim i As Integer = 0
        Try
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            i = ds.Tables(0).Rows(0)("dis_rollup")
            ds = New DataSet
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & i, "", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)("dis_id")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetNextMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As Integer
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_rollup = " & DisId, "", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)("dis_id")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetThreadMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteThreadMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("dis_deleted") = 1
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

    Public Function AddThreadMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal Subject As String, ByVal Message As String, ByVal ParentId As Integer, ByVal User As String) As Boolean
        Dim ds As New DataSet
        Dim Indent As String
        Dim Root As Integer
        Dim Rollup As Integer
        Try
            If ParentId = 0 Then
                Rollup = ParentId
                Root = 0
                Indent = ""
            Else
                Rollup = ParentId
                Root = GetThreadRoot(PagId, ModId, ParentId)
                Indent = GetIndent(PagId, ModId, ParentId)
            End If
            If Not oDO.GetEmptyDataSet("dis_discussion", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("dis_rollup") = Rollup
                .Item("dis_root") = Root
                .Item("dis_indent") = Indent
                .Item("dis_title") = Subject
                .Item("dis_body") = Message
                .Item("dis_createddate") = Now.ToLongTimeString
                .Item("dis_createdby") = User
                .Item("dis_updateddate") = Now.ToLongTimeString
                .Item("dis_updatedby") = User
                .Item("dis_hidden") = 0
                .Item("dis_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateThreadMessage(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer, ByVal Subject As String, ByVal Message As String, ByVal User As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("dis_discussion", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("dis_title") = Subject
                .Item("dis_body") = Message
                .Item("dis_updateddate") = Now.ToLongTimeString
                .Item("dis_updatedby") = User
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetThreadRoot(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As Integer
        Dim ds As New DataSet
        Dim Root As Integer
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("dis_id")
            oDefine.AddDefinedTableColumn("dis_rollup")
            If Not oDO.GetDefinedDataSet("dis_discussion", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            If Not ds.Tables(0).Rows(0)("dis_rollup") = 0 Then
                If Not CheckIfRoot(PagId, ModId, ds.Tables(0).Rows(0)("dis_rollup"), Root) Then

                End If
            Else
                Root = ds.Tables(0).Rows(0)("dis_id")
            End If
            Return Root
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function CheckIfRoot(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer, ByRef Root As Integer) As Boolean
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("dis_id")
            oDefine.AddDefinedTableColumn("dis_rollup")
            If Not oDO.GetDefinedDataSet("dis_discussion", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId, "", "", ED, EC, ds) Then

            End If
            If Not ds.Tables(0).Rows(0)("dis_rollup") = 0 Then
                If Not CheckIfRoot(PagId, ModId, ds.Tables(0).Rows(0)("dis_rollup"), Root) Then

                End If
            Else
                Root = ds.Tables(0).Rows(0)("dis_id")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetIndent(ByVal PagId As Integer, ByVal ModId As Integer, ByVal DisId As Integer) As String
        Dim ds As New DataSet
        Dim s As String
        Dim i As Integer
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("dis_rollup")
            oDefine.AddDefinedTableColumn("dis_indent")
            If Not oDO.GetDefinedDataSet("dis_discussion", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND dis_id = " & DisId & " AND dis_hidden = 0 AND dis_deleted = 0", "", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows(0)("dis_rollup") = 0 Then
                Return "&nbsp;"
            End If
            s += ds.Tables(0).Rows(0)("dis_indent")
            For i = 1 To 5
                s += "&nbsp;"
            Next
            Return s
        Catch ex As Exception
            Return "&nbsp;"
        End Try
    End Function



End Class
