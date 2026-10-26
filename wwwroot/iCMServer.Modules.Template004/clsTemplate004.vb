Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility
Imports System.Configuration.ConfigurationSettings
Imports System.Web.UI.HtmlControls

Public Class clsTemplate004

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
            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = " & oSite.ActivePage.PageParentId & " AND pag_hidden = 0 AND pag_deleted = 0", "pag_order", "", ED, EC, ds) Then
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
            If Not oDO.GetDataSet("tem_template004", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then

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

    Public Function UpdateTemplate(ByVal Header As String, ByVal Ingress As String, ByVal Text As String, ByVal NavText As String, ByVal MediaLink1 As String, ByVal MediaLink2 As String, ByVal MediaLink3 As String, ByVal MediaLink4 As String, ByVal MediaLink5 As String, ByVal MediaLink6 As String, ByVal MediaLink7 As String, ByVal MediaLink8 As String, ByVal MediaLink9 As String, ByVal MediaLink10 As String, ByVal MediaLink11 As String, ByVal MediaLink12 As String, ByVal MediaLink13 As String, ByVal MediaLink14 As String, ByVal MediaLink15 As String, ByVal MediaLink16 As String, ByVal MediaLink17 As String, ByVal MediaLink18 As String, ByVal MediaLink19 As String, ByVal MediaLink20 As String) As Boolean
        Try
            Dim Exists As Boolean = False
            Dim ds As New DataSet
            If Not oDO.GetDataSet("tem_template004", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
                Return False
            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Exists = True
                End If
            End If
            If Not Exists Then
                ds = New DataSet
                If Not oDO.GetEmptyDataSet("tem_template004", "", ED, EC, ds) Then
                    Return False
                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = Me.PagId
                    .Item("mod_id") = Me.ModId
                    .Item("tem_name") = "none"
                    .Item("tem_header") = Header
                    .Item("tem_ingress") = Ingress
                    .Item("tem_text") = Text
                    .Item("tem_navtext") = NavText
                    .Item("tem_medialink1") = MediaLink1
                    .Item("tem_medialink2") = MediaLink2
                    .Item("tem_medialink3") = MediaLink3
                    .Item("tem_medialink4") = MediaLink4
                    .Item("tem_medialink5") = MediaLink5
                    .Item("tem_medialink6") = MediaLink6
                    .Item("tem_medialink7") = MediaLink7
                    .Item("tem_medialink8") = MediaLink8
                    .Item("tem_medialink9") = MediaLink9
                    .Item("tem_medialink10") = MediaLink10
                    .Item("tem_medialink11") = MediaLink11
                    .Item("tem_medialink12") = MediaLink12
                    .Item("tem_medialink13") = MediaLink13
                    .Item("tem_medialink14") = MediaLink14
                    .Item("tem_medialink15") = MediaLink15
                    .Item("tem_medialink16") = MediaLink16
                    .Item("tem_medialink17") = MediaLink17
                    .Item("tem_medialink18") = MediaLink18
                    .Item("tem_medialink19") = MediaLink19
                    .Item("tem_medialink20") = MediaLink20
                    .Item("tem_createddate") = Now.ToLongTimeString
                    .Item("tem_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_updateddate") = Now.ToLongTimeString
                    .Item("tem_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("tem_hidden") = 0
                    .Item("tem_deleted") = 0
                End With
            Else
                With ds.Tables(0).Rows(0)
                    .Item("tem_header") = Header
                    .Item("tem_ingress") = Ingress
                    .Item("tem_text") = Text
                    .Item("tem_navtext") = NavText
                    .Item("tem_medialink1") = MediaLink1
                    .Item("tem_medialink2") = MediaLink2
                    .Item("tem_medialink3") = MediaLink3
                    .Item("tem_medialink4") = MediaLink4
                    .Item("tem_medialink5") = MediaLink5
                    .Item("tem_medialink6") = MediaLink6
                    .Item("tem_medialink7") = MediaLink7
                    .Item("tem_medialink8") = MediaLink8
                    .Item("tem_medialink9") = MediaLink9
                    .Item("tem_medialink10") = MediaLink10
                    .Item("tem_medialink11") = MediaLink11
                    .Item("tem_medialink12") = MediaLink12
                    .Item("tem_medialink13") = MediaLink13
                    .Item("tem_medialink14") = MediaLink14
                    .Item("tem_medialink15") = MediaLink15
                    .Item("tem_medialink16") = MediaLink16
                    .Item("tem_medialink17") = MediaLink17
                    .Item("tem_medialink18") = MediaLink18
                    .Item("tem_medialink19") = MediaLink19
                    .Item("tem_medialink20") = MediaLink20
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

    Public Function UpdateTemplateText(ByVal Header As String, ByVal Ingress As String, ByVal Text As String, ByVal NavText As String) As Boolean
        Try
            Dim ds As DataSet = Me.GetTemplate()
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("tem_header") = Header
                        .Item("tem_ingress") = Ingress
                        .Item("tem_text") = Text
                        .Item("tem_navtext") = NavText
                    End With
                    If Not Me.UpdateTemplate(ds) Then
                        Return False
                    End If
                    Return True
                End If
            End If
            Return UpdateTemplate(Header, Ingress, Text, NavText, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddTemplateMediaFile(ByVal What As String) As Boolean
        Try
            Dim ds As DataSet = Me.GetTemplate()
            If CType(ds.Tables(0).Rows(0)("tem_medialink1"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink1") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink2"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink2") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink3"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink3") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink4"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink4") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink5"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink5") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink6"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink6") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink7"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink7") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink8"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink8") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink9"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink9") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink10"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink10") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink11"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink11") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink12"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink12") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink13"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink13") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink14"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink14") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink15"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink15") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink16"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink16") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink17"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink17") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink18"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink18") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink19"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink19") = What
            ElseIf CType(ds.Tables(0).Rows(0)("tem_medialink20"), String).Length < 1 Then
                ds.Tables(0).Rows(0)("tem_medialink20") = What
            End If
            If Not Me.UpdateTemplate(ds) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RemoveTemplateMediaFile(ByVal MediaFile As String) As Boolean
        Try
            Dim ds As DataSet = Me.GetTemplate()
            Select Case MediaFile
                Case "1" : ds.Tables(0).Rows(0)("tem_medialink1") = ""
                Case "2" : ds.Tables(0).Rows(0)("tem_medialink2") = ""
                Case "3" : ds.Tables(0).Rows(0)("tem_medialink3") = ""
                Case "4" : ds.Tables(0).Rows(0)("tem_medialink4") = ""
                Case "5" : ds.Tables(0).Rows(0)("tem_medialink5") = ""
                Case "6" : ds.Tables(0).Rows(0)("tem_medialink6") = ""
                Case "7" : ds.Tables(0).Rows(0)("tem_medialink7") = ""
                Case "8" : ds.Tables(0).Rows(0)("tem_medialink8") = ""
                Case "9" : ds.Tables(0).Rows(0)("tem_medialink9") = ""
                Case "10" : ds.Tables(0).Rows(0)("tem_medialink10") = ""
                Case "11" : ds.Tables(0).Rows(0)("tem_medialink11") = ""
                Case "12" : ds.Tables(0).Rows(0)("tem_medialink12") = ""
                Case "13" : ds.Tables(0).Rows(0)("tem_medialink13") = ""
                Case "14" : ds.Tables(0).Rows(0)("tem_medialink14") = ""
                Case "15" : ds.Tables(0).Rows(0)("tem_medialink15") = ""
                Case "16" : ds.Tables(0).Rows(0)("tem_medialink16") = ""
                Case "17" : ds.Tables(0).Rows(0)("tem_medialink17") = ""
                Case "18" : ds.Tables(0).Rows(0)("tem_medialink18") = ""
                Case "19" : ds.Tables(0).Rows(0)("tem_medialink19") = ""
                Case "20" : ds.Tables(0).Rows(0)("tem_medialink20") = ""
            End Select
            If Not Me.UpdateTemplate(ds) Then
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
            If Not oDO.GetDataSet("tem_template004", "sit_id = " & oSite.SiteId & " AND pag_id = " & Me.PagId & " AND mod_id = " & Me.ModId & " AND tem_hidden = 0 AND tem_deleted = 0", "", "", ED, EC, ds) Then
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

    Public Function GetDocuments() As DataSet
        Try
            Dim ds As New DataSet
            Dim oDefine As New iConsulting.Library.Data.clsDefinedDataList
            oDefine.AddDefinedTableColumn("doc_id")
            oDefine.AddDefinedTableColumn("mod_id")
            oDefine.AddDefinedTableColumn("cat_id")
            oDefine.AddDefinedTableColumn("doc_name")
            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id <> 0 AND doc_hidden = 0 AND doc_deleted = 0", "", "", ED, EC, ds) Then

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

    Public Function GetRedirect(ByVal ModId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New iConsulting.Library.Data.clsDefinedDataList
            oDefine.AddDefinedTableColumn("qui_url")
            If Not oDO.GetDefinedDataSet("qui_quicklinks", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_hidden = 0 AND qui_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetQuicklink(ByVal ModId As Integer, ByVal QuiId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_id = " & QuiId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteQuicklink(ByVal ModId As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("qui_deleted") = 1
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

    Public Function AddQuicklink(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Url As String, ByVal Target As String, ByVal Order As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("qui_quicklinks", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("qui_title") = Title
                .Item("qui_description") = Description
                .Item("qui_url") = Url & "|" & Target
                .Item("qui_order") = Order
                .Item("qui_createddate") = Now.ToShortDateString
                .Item("qui_createdby") = HttpContext.Current.User.Identity.Name
                .Item("qui_updateddate") = Now.ToShortDateString
                .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("qui_hidden") = 0
                .Item("qui_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Exists(ByVal ModId As Integer, ByVal PagId As Integer) As Boolean
        Try
            Dim ds As DataSet = Me.GetRedirect(ModId, PagId)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateQuicklink(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Url As String) As Boolean
        Dim ds As New DataSet
        Try
            If Exists(ModId, PagId) Then
                If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND pag_id = " & PagId, "", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("qui_url") = Url
                    .Item("qui_updateddate") = Now.ToShortDateString
                    .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                End With
            Else
                If Not oDO.GetEmptyDataSet("qui_quicklinks", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("mod_id") = ModId
                    .Item("pag_id") = PagId
                    .Item("qui_title") = ""
                    .Item("qui_description") = ""
                    .Item("qui_url") = Url
                    .Item("qui_order") = 0
                    .Item("qui_createddate") = Now.ToLongTimeString
                    .Item("qui_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("qui_updateddate") = Now.ToLongTimeString
                    .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("qui_hidden") = 0
                    .Item("qui_deleted") = 0
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
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
