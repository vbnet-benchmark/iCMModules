Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.HttpUtility

Public Class clsSearch

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private ModId As Integer = 0
    Private IsAuthorized As Boolean = False

    Public Sub New(ByVal iModId As Integer, ByVal bAuthorized As Boolean)
        Me.ModId = iModId
        Me.IsAuthorized = bAuthorized
    End Sub

    Public Function GenericSearch(ByVal Criteria As String) As DataSet
        Dim dsBase As New DataSet
        Try
            ' Leta upp alla moduler i systemet som användaren har rättighet att titta på.
            ' Sök igenom alla textbaserade fält i de tabeller som hittas.
            ' Returnera resultatet i ett dataset där varje moduls resultat ligger i en egen tabell.

            Dim oDefine As New clsDefinedDataList
            Dim dsResult As New DataSet
            Dim dsMod As DataSet
            Dim dsData As DataSet
            Dim dsInfo As DataSet
            Dim PageName As String
            Dim ModuleName As String
            Dim sWhere As String

            ' Get all Base Modules...
            oDefine = New clsDefinedDataList
            oDefine.AddDefinedTableColumn("mde_id")
            oDefine.AddDefinedTableColumn("mde_name")
            dsBase = New DataSet
            If Not oDO.GetDefinedDataSet("mde_moduledefinitions", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mde_hidden = 0 AND mde_deleted = 0", "", "", ED, EC, dsBase) Then

            End If

            ' Loop the Base Modules and ....
            For Each drBase As DataRow In dsBase.Tables(0).Rows
                sWhere = ""
                oDefine = New clsDefinedDataList
                oDefine.AddDefinedTableColumn("mod_id")
                oDefine.AddDefinedTableColumn("mod_title")
                oDefine.AddDefinedTableColumn("mod_authorizededitroles")
                dsMod = New DataSet
                If Not oDO.GetDefinedDataSet("mod_modules", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mde_id = " & CType(drBase("mde_id"), Integer) & " AND mod_hidden = 0 AND mod_deleted = 0", "", "", ED, EC, dsMod) Then

                End If
                For Each drMod As DataRow In dsMod.Tables(0).Rows
                    If clsSiteSecurity.IsInRoles(drMod("mod_authorizededitroles")) Then
                        sWhere += " sit_id = " & oSite.SiteId & _
                                  " AND mod_id = " & CType(drMod("mod_id"), String) & " OR "
                    End If
                Next
                If sWhere.Length > 0 Then
                    sWhere = sWhere.Substring(1, sWhere.Length - 5)

                    ' Search the Base Modules we have found in the system, based on if we have authority to do so...
                    Select Case CType(drBase("mde_name"), String).ToLower


                        Case "publisher" ' Perform search in Publisher Modules...
                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("htm_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("htm_desktophtml")
                            oDefine.AddDefinedTableColumn("htm_mobilesummary")
                            oDefine.AddDefinedTableColumn("htm_mobiledetails")
                            oDefine.AddDefinedTableColumn("htm_createdby")
                            oDefine.AddDefinedTableColumn("htm_createddate")
                            oDefine.AddDefinedTableColumn("htm_updatedby")
                            oDefine.AddDefinedTableColumn("htm_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("htm_htmltext", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("htm_desktophtml")) Then i += GetWordCount(HtmlDecode(CType(drData("htm_desktophtml"), String)), Criteria)
                                    'If Not IsDBNull(drData("htm_mobilesummary")) Then i += GetWordCount(HtmlDecode(CType(drData("htm_mobilesummary"), String)), Criteria)
                                    'If Not IsDBNull(drData("htm_mobiledetails")) Then i += GetWordCount(HtmlDecode(CType(drData("htm_mobiledetails"), String)), Criteria)
                                    If Not IsDBNull(drData("htm_createdby")) Then i += GetWordCount(drData("htm_createdby"), Criteria)
                                    If Not IsDBNull(drData("htm_createddate")) Then i += GetWordCount(drData("htm_createddate"), Criteria)
                                    If Not IsDBNull(drData("htm_updatedby")) Then i += GetWordCount(drData("htm_updatedby"), Criteria)
                                    If Not IsDBNull(drData("htm_updateddate")) Then i += GetWordCount(drData("htm_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("htm_desktophtml")) Then oSearch.EncodedDisplayText = CType(drData("htm_desktophtml"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("htm_createdby")) Then oSearch.CreatedBy = CType(drData("htm_createdby"), String)
                                            If Not IsDBNull(drData("htm_createddate")) Then oSearch.CreatedDate = CType(drData("htm_createddate"), String)
                                            If Not IsDBNull(drData("htm_updatedby")) Then oSearch.UpdatedBy = CType(drData("htm_updatedby"), String)
                                            If Not IsDBNull(drData("htm_updateddate")) Then oSearch.UpdatedDate = CType(drData("htm_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "documents" ' Perform search in Documents Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("doc_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("doc_name")
                            oDefine.AddDefinedTableColumn("doc_createdby")
                            oDefine.AddDefinedTableColumn("doc_createddate")
                            oDefine.AddDefinedTableColumn("doc_updatedby")
                            oDefine.AddDefinedTableColumn("doc_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("doc_name")) Then i += GetWordCount(drData("doc_name"), Criteria)
                                    If Not IsDBNull(drData("doc_createdby")) Then i += GetWordCount(drData("doc_createdby"), Criteria)
                                    If Not IsDBNull(drData("doc_createddate")) Then i += GetWordCount(drData("doc_createddate"), Criteria)
                                    If Not IsDBNull(drData("doc_updatedby")) Then i += GetWordCount(drData("doc_updatedby"), Criteria)
                                    If Not IsDBNull(drData("doc_updateddate")) Then i += GetWordCount(drData("doc_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("doc_name")) Then oSearch.EncodedDisplayText = CType(drData("doc_name"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("doc_createdby")) Then oSearch.CreatedBy = CType(drData("doc_createdby"), String)
                                            If Not IsDBNull(drData("doc_createddate")) Then oSearch.CreatedDate = CType(drData("doc_createddate"), String)
                                            If Not IsDBNull(drData("doc_updatedby")) Then oSearch.UpdatedBy = CType(drData("doc_updatedby"), String)
                                            If Not IsDBNull(drData("doc_updateddate")) Then oSearch.UpdatedDate = CType(drData("doc_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "mediagallery" ' Perform search in MediaGallery Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("doc_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("doc_name")
                            oDefine.AddDefinedTableColumn("doc_createdby")
                            oDefine.AddDefinedTableColumn("doc_createddate")
                            oDefine.AddDefinedTableColumn("doc_updatedby")
                            oDefine.AddDefinedTableColumn("doc_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("doc_documents", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("doc_name")) Then i += GetWordCount(drData("doc_name"), Criteria)
                                    If Not IsDBNull(drData("doc_createdby")) Then i += GetWordCount(drData("doc_createdby"), Criteria)
                                    If Not IsDBNull(drData("doc_createddate")) Then i += GetWordCount(drData("doc_createddate"), Criteria)
                                    If Not IsDBNull(drData("doc_updatedby")) Then i += GetWordCount(drData("doc_updatedby"), Criteria)
                                    If Not IsDBNull(drData("doc_updateddate")) Then i += GetWordCount(drData("doc_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("doc_name")) Then oSearch.EncodedDisplayText = CType(drData("doc_name"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("doc_createdby")) Then oSearch.CreatedBy = CType(drData("doc_createdby"), String)
                                            If Not IsDBNull(drData("doc_createddate")) Then oSearch.CreatedDate = CType(drData("doc_createddate"), String)
                                            If Not IsDBNull(drData("doc_updatedby")) Then oSearch.UpdatedBy = CType(drData("doc_updatedby"), String)
                                            If Not IsDBNull(drData("doc_updateddate")) Then oSearch.UpdatedDate = CType(drData("doc_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "events" ' Perform search in Events Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("eve_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("eve_title")
                            oDefine.AddDefinedTableColumn("eve_description")
                            oDefine.AddDefinedTableColumn("eve_createdby")
                            oDefine.AddDefinedTableColumn("eve_createddate")
                            oDefine.AddDefinedTableColumn("eve_updatedby")
                            oDefine.AddDefinedTableColumn("eve_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("eve_events", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("eve_title")) Then i += GetWordCount(drData("eve_title"), Criteria)
                                    If Not IsDBNull(drData("eve_description")) Then i += GetWordCount(drData("eve_description"), Criteria)
                                    If Not IsDBNull(drData("eve_createdby")) Then i += GetWordCount(drData("eve_createdby"), Criteria)
                                    If Not IsDBNull(drData("eve_createddate")) Then i += GetWordCount(drData("eve_createddate"), Criteria)
                                    If Not IsDBNull(drData("eve_updatedby")) Then i += GetWordCount(drData("eve_updatedby"), Criteria)
                                    If Not IsDBNull(drData("eve_updateddate")) Then i += GetWordCount(drData("eve_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("eve_title")) Then oSearch.EncodedDisplayText = CType(drData("eve_title"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("eve_createdby")) Then oSearch.CreatedBy = CType(drData("eve_createdby"), String)
                                            If Not IsDBNull(drData("eve_createddate")) Then oSearch.CreatedDate = CType(drData("eve_createddate"), String)
                                            If Not IsDBNull(drData("eve_updatedby")) Then oSearch.UpdatedBy = CType(drData("eve_updatedby"), String)
                                            If Not IsDBNull(drData("eve_updateddate")) Then oSearch.UpdatedDate = CType(drData("eve_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "quicklinks" ' Perform search in QuickLinks Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("qui_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("qui_title")
                            oDefine.AddDefinedTableColumn("qui_description")
                            oDefine.AddDefinedTableColumn("qui_createdby")
                            oDefine.AddDefinedTableColumn("qui_createddate")
                            oDefine.AddDefinedTableColumn("qui_updatedby")
                            oDefine.AddDefinedTableColumn("qui_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("qui_quicklinks", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("qui_title")) Then i += GetWordCount(drData("qui_title"), Criteria)
                                    If Not IsDBNull(drData("qui_description")) Then i += GetWordCount(drData("qui_description"), Criteria)
                                    If Not IsDBNull(drData("qui_createdby")) Then i += GetWordCount(drData("qui_createdby"), Criteria)
                                    If Not IsDBNull(drData("qui_createddate")) Then i += GetWordCount(drData("qui_createddate"), Criteria)
                                    If Not IsDBNull(drData("qui_updatedby")) Then i += GetWordCount(drData("qui_updatedby"), Criteria)
                                    If Not IsDBNull(drData("qui_updateddate")) Then i += GetWordCount(drData("qui_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("qui_title")) Then oSearch.EncodedDisplayText = CType(drData("qui_title"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("qui_createdby")) Then oSearch.CreatedBy = CType(drData("qui_createdby"), String)
                                            If Not IsDBNull(drData("qui_createddate")) Then oSearch.CreatedDate = CType(drData("qui_createddate"), String)
                                            If Not IsDBNull(drData("qui_updatedby")) Then oSearch.UpdatedBy = CType(drData("qui_updatedby"), String)
                                            If Not IsDBNull(drData("qui_updateddate")) Then oSearch.UpdatedDate = CType(drData("qui_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "discussion" ' Perform search in Discussion Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("dis_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("dis_title")
                            oDefine.AddDefinedTableColumn("dis_body")
                            oDefine.AddDefinedTableColumn("dis_createdby")
                            oDefine.AddDefinedTableColumn("dis_createddate")
                            oDefine.AddDefinedTableColumn("dis_updatedby")
                            oDefine.AddDefinedTableColumn("dis_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("dis_discussion", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("dis_title")) Then i += GetWordCount(drData("dis_title"), Criteria)
                                    If Not IsDBNull(drData("dis_body")) Then i += GetWordCount(drData("dis_body"), Criteria)
                                    If Not IsDBNull(drData("dis_createdby")) Then i += GetWordCount(drData("dis_createdby"), Criteria)
                                    If Not IsDBNull(drData("dis_createddate")) Then i += GetWordCount(drData("dis_createddate"), Criteria)
                                    If Not IsDBNull(drData("dis_updatedby")) Then i += GetWordCount(drData("dis_updatedby"), Criteria)
                                    If Not IsDBNull(drData("dis_updateddate")) Then i += GetWordCount(drData("dis_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("dis_title")) And Not IsDBNull(drData("dis_body")) Then oSearch.EncodedDisplayText = CType(drData("dis_title"), String) & " " & CType(drData("dis_body"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("dis_createdby")) Then oSearch.CreatedBy = CType(drData("dis_createdby"), String)
                                            If Not IsDBNull(drData("dis_createddate")) Then oSearch.CreatedDate = CType(drData("dis_createddate"), String)
                                            If Not IsDBNull(drData("dis_updatedby")) Then oSearch.UpdatedBy = CType(drData("dis_updatedby"), String)
                                            If Not IsDBNull(drData("dis_updateddate")) Then oSearch.UpdatedDate = CType(drData("dis_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If

                        Case "calendar" ' Perform search in Calendar Modules...

                            oDefine = New clsDefinedDataList
                            oDefine.AddDefinedTableColumn("cal_id")
                            oDefine.AddDefinedTableColumn("sit_id")
                            oDefine.AddDefinedTableColumn("pag_id")
                            oDefine.AddDefinedTableColumn("mod_id")
                            oDefine.AddDefinedTableColumn("cal_subject")
                            oDefine.AddDefinedTableColumn("cal_text")
                            oDefine.AddDefinedTableColumn("cal_starttime")
                            oDefine.AddDefinedTableColumn("cal_endtime")
                            oDefine.AddDefinedTableColumn("cal_createdby")
                            oDefine.AddDefinedTableColumn("cal_createddate")
                            oDefine.AddDefinedTableColumn("cal_updatedby")
                            oDefine.AddDefinedTableColumn("cal_updateddate")
                            dsData = New DataSet
                            If Not oDO.GetDefinedDataSet("cal_calendar", oDefine.DataSet, sWhere, "", "", ED, EC, dsData) Then

                            End If
                            If dsData.Tables(0).Rows.Count > 0 Then
                                For Each drData As DataRow In dsData.Tables(0).Rows
                                    Dim i As Integer = 0
                                    If Not IsDBNull(drData("cal_subject")) Then i += GetWordCount(drData("cal_subject"), Criteria)
                                    If Not IsDBNull(drData("cal_text")) Then i += GetWordCount(drData("cal_text"), Criteria)
                                    If Not IsDBNull(drData("cal_starttime")) Then i += GetWordCount(drData("cal_starttime"), Criteria)
                                    If Not IsDBNull(drData("cal_endtime")) Then i += GetWordCount(drData("cal_endtime"), Criteria)
                                    If Not IsDBNull(drData("cal_createdby")) Then i += GetWordCount(drData("cal_createdby"), Criteria)
                                    If Not IsDBNull(drData("cal_createddate")) Then i += GetWordCount(drData("cal_createddate"), Criteria)
                                    If Not IsDBNull(drData("cal_updatedby")) Then i += GetWordCount(drData("cal_updatedby"), Criteria)
                                    If Not IsDBNull(drData("cal_updateddate")) Then i += GetWordCount(drData("cal_updateddate"), Criteria)
                                    If Not i = 0 Then
                                        PageName = GetPageName(drData("pag_id"))
                                        If Not PageName = "none" Then
                                            ModuleName = GetModuleName(drData("mod_id"))
                                            Dim oSearch As New clsSearchTable(PageName & "-" & ModuleName & "-" & dsResult.Tables.Count.ToString)
                                            oSearch.SitId = CType(drData("sit_id"), String)
                                            oSearch.PagId = CType(drData("pag_id"), String)
                                            oSearch.ModId = CType(drData("mod_id"), String)
                                            If Not IsDBNull(drData("cal_subject")) And Not IsDBNull(drData("cal_text")) Then oSearch.EncodedDisplayText = CType(drData("cal_subject"), String) & " " & CType(drData("cal_text"), String)
                                            oSearch.Criteria = Criteria
                                            oSearch.WordCount = i.ToString
                                            If Not IsDBNull(drData("cal_createdby")) Then oSearch.CreatedBy = CType(drData("cal_createdby"), String)
                                            If Not IsDBNull(drData("cal_createddate")) Then oSearch.CreatedDate = CType(drData("cal_createddate"), String)
                                            If Not IsDBNull(drData("cal_updatedby")) Then oSearch.UpdatedBy = CType(drData("cal_updatedby"), String)
                                            If Not IsDBNull(drData("cal_updateddate")) Then oSearch.UpdatedDate = CType(drData("cal_updateddate"), String)
                                            dsResult.Tables.Add(oSearch.Table)
                                        End If
                                    End If
                                Next
                            End If
                    End Select
                End If
            Next

            Return dsResult
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.ToString)
            Return New DataSet
        End Try
    End Function

    Private Function GetPageName(ByVal PagId As Integer) As String
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("pag_name")
            Dim ds As New DataSet
            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId, "", "", ED, EC, ds) Then
                Throw New Exception
            End If
            Return ds.Tables(0).Rows(0)("pag_name")
        Catch ex As Exception
            Return "none"
        End Try
    End Function

    Private Function GetModuleName(ByVal ModId As Integer) As String
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("mod_title")
            Dim ds As New DataSet
            If Not oDO.GetDefinedDataSet("mod_modules", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then
                Throw New Exception
            End If
            Return ds.Tables(0).Rows(0)("mod_title")
        Catch ex As Exception
            Return "none"
        End Try
    End Function

    Private Function GetWordCount(ByVal str1 As String, ByVal str2 As String) As Integer
        Try
            If str1 = "" Then Return 0
            Dim i As Integer = 0
            Dim j As Integer = 0
            str1 = " " & str1.ToLower
            str2 = str2.ToLower
            While str1.LastIndexOf(str2) > -1
                j = str1.LastIndexOf(str2)
                str1 = str1.Remove(j, str2.Length)
                i += 1
            End While
            Return i
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class

Public Class clsSearchTable

    Public Table As DataTable

    Public Property SitId()
        Get
            Return Table.Rows(0).Item("SitId")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("SitId") = Value
        End Set
    End Property

    Public Property PagId()
        Get
            Return Table.Rows(0).Item("PagId")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("PagId") = Value
        End Set
    End Property

    Public Property ModId()
        Get
            Return Table.Rows(0).Item("ModId")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("ModId") = Value
        End Set
    End Property

    Public Property EncodedDisplayText()
        Get
            Return Table.Rows(0).Item("EncodedDisplayText")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("EncodedDisplayText") = Value
        End Set
    End Property

    Public Property Criteria()
        Get
            Return Table.Rows(0).Item("Criteria")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("Criteria") = Value
        End Set
    End Property

    Public Property WordCount()
        Get
            Return Table.Rows(0).Item("WordCount")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("WordCount") = Value
        End Set
    End Property

    Public Property CreatedBy()
        Get
            Return Table.Rows(0).Item("CreatedBy")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("CreatedBy") = Value
        End Set
    End Property

    Public Property CreatedDate()
        Get
            Return Table.Rows(0).Item("CreatedDate")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("CreatedDate") = Value
        End Set
    End Property

    Public Property UpdatedBy()
        Get
            Return Table.Rows(0).Item("UpdatedBy")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("UpdatedBy") = Value
        End Set
    End Property

    Public Property UpdatedDate()
        Get
            Return Table.Rows(0).Item("UpdatedDate")
        End Get
        Set(ByVal Value)
            Table.Rows(0).Item("UpdatedDate") = Value
        End Set
    End Property

    Sub New()
        Table = New DataTable("SearchTable")
        Call AddColumns()
        Call CreateRow()
    End Sub

    Sub New(ByVal sDataTableName As String)
        Table = New DataTable(sDataTableName)
        Call AddColumns()
        Call CreateRow()
    End Sub

    Private Sub AddColumns()
        Table.Columns.Add("SitId")
        Table.Columns.Add("PagId")
        Table.Columns.Add("ModId")
        Table.Columns.Add("EncodedDisplayText")
        Table.Columns.Add("Criteria")
        Table.Columns.Add("WordCount")
        Table.Columns.Add("CreatedBy")
        Table.Columns.Add("CreatedDate")
        Table.Columns.Add("UpdatedBy")
        Table.Columns.Add("UpdatedDate")
    End Sub

    Private Sub CreateRow()
        Dim dr As DataRow = Table.NewRow
        dr("SitId") = ""
        dr("PagId") = ""
        dr("ModId") = ""
        dr("EncodedDisplayText") = ""
        dr("Criteria") = ""
        dr("WordCount") = ""
        dr("CreatedBy") = ""
        dr("CreatedDate") = ""
        dr("UpdatedBy") = ""
        dr("UpdatedDate") = ""
        Table.Rows.Add(dr)
    End Sub

End Class
