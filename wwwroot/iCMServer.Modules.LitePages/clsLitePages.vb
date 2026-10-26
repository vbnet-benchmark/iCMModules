Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System
Imports System.Drawing
Imports iConsulting
Imports iConsulting.iCMServer
Imports System.Collections

Public Class clsLitePages

    Protected oDO As New iCDataObject
    Private oCrypto As New iConsulting.iCMServer.clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function DeleteNode(ByVal PageID As Integer) As Boolean
        If Not PageID = 0 Then
            Try
                Dim ds As New DataSet
                If Not oDO.GetDataSet("pag_page", "pag_id = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                    System.Diagnostics.Debug.WriteLine(ds.GetXml)
                End If
                Dim iLevel As Integer = CType(ds.Tables(0).Rows(0)("pag_level"), Integer)
                ' 333 = Startpage
                ' 666 = Adminpage
                If Not iLevel = 333 And Not iLevel = 666 Then
                    If oSite.SiteSoftDelete Then
                        ds.Tables(0).Rows(0)("pag_deleted") = 1
                    Else
                        ds.Tables(0).Rows(0).Delete()
                    End If
                End If
                If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                    System.Diagnostics.Debug.WriteLine(ds.GetXml)
                End If
                If Not Me.ReArrangePagesOrder() Then

                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Public Function MoveNodeUp(ByVal PageID As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "pag_id = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = (ds.Tables(0).Rows(0)("pag_order") - 3)
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If Not Me.ReArrangePagesOrder() Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MoveNodeDown(ByVal PageID As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "pag_id = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = (ds.Tables(0).Rows(0)("pag_order") + 3)
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If Not Me.ReArrangePagesOrder() Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ReArrangePagesOrder() As Boolean
        Dim ds As New DataSet
        ds = Me.GetPages()
        Try
            Dim i As Integer = 1
            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                If Not Me.SetPageOrder(dr("pag_id"), i) Then

                End If
                i += 2
            Next
            If Not SetAdminPageOrder() Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SetAdminPageOrder() As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_level = 666", "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = 99999
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetPagesDESC() As DataSet
        Dim ds As New DataSet
        If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId, "pag_order DESC", "", ED, EC, ds) Then
            System.Diagnostics.Debug.WriteLine(ds.GetXml)
        End If
        Return ds
    End Function

    Private Function GetPages() As DataSet
        Dim ds As New DataSet
        If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_deleted = 0", "pag_order", "", ED, EC, ds) Then
            System.Diagnostics.Debug.WriteLine(ds.GetXml)
        End If
        Return ds
    End Function

    Private Function SetPageOrder(ByVal PageID As Integer, ByVal PageOrder As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "pag_id = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = PageOrder
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetSiteRoles() As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("rol_roles", "sit_id = " & oSite.SiteId & "AND rol_hidden = 0 AND rol_deleted = 0", "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetModuleDefinitions() As DataSet
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("mde_moduledefinitions", "sit_id = " & oSite.SiteId & "AND mde_hidden = 0 AND mde_deleted = 0", "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetModules(ByVal pane As String) As ArrayList
        Try
            oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim paneModules As New ArrayList
            Dim _module As clsModuleSettings
            For Each _module In oSite.ActivePage.Modules
                If _module.ModuleFieldName.ToLower = pane.ToLower() Then
                    Dim m As New clsModuleItem
                    m.ModuleTitle = _module.ModuleTitle
                    m.ModuleId = _module.ModuleId
                    m.ModuleDefId = _module.ModuleDefId
                    m.ModuleOrder = _module.ModuleOrder
                    paneModules.Add(m)
                End If
            Next _module
            Return paneModules

        Catch ex As Exception
            Return New ArrayList
        End Try
    End Function

    Public Function AddModule(ByVal PageId As Integer, ByVal moduleOrder As Integer, ByVal FieldName As String, ByVal title As String, ByVal mde_id As Integer, ByVal cacheTime As Integer, ByVal editRoles As String) As Integer
        Try
            Dim ds As New DataSet
            If Not oDO.GetEmptyDataSet("mod_modules", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = CInt(PageId)
                .Item("lng_id") = 0
                .Item("mde_id") = CInt(mde_id)
                .Item("mod_order") = CInt(moduleOrder)
                .Item("mod_panename") = CStr(FieldName)
                .Item("mod_title") = CStr(title)
                .Item("mod_description") = "-"
                .Item("mod_authorizededitroles") = CStr(editRoles)
                .Item("mod_cachetime") = CInt(cacheTime)
                .Item("mod_showmobile") = 0
                .Item("mod_alignment") = ""
                .Item("mod_color") = ""
                .Item("mod_border") = ""
                .Item("mod_editsrc") = ""
                .Item("mod_iconfile") = ""
                .Item("mod_editmoduleicon") = ""
                .Item("mod_friendlyname") = ""
                .Item("mod_secure") = 0
                .Item("mod_allpages") = 0
                .Item("mod_showtitle") = 0
                .Item("mod_personalize") = 0 ' int
                .Item("mod_skinpath") = "none"
                .Item("mod_createddate") = Now.ToShortDateString
                .Item("mod_createdby") = "System"
                .Item("mod_updateddate") = Now.ToShortDateString
                .Item("mod_updatedby") = "System"
                .Item("mod_hidden") = 0
                .Item("mod_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return ds.Tables(0).Rows(0)("mod_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateModuleOrder(ByVal mod_id As Integer, ByVal mod_order As Integer, ByVal pane As String) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("mod_modules", "mod_id = " & mod_id & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("mod_order") = CInt(mod_order)
            ds.Tables(0).Rows(0)("mod_panename") = CStr(pane)
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function OrderModules(ByRef list As ArrayList) As Boolean
        Dim i As Integer = 1
        list.Sort()
        Dim m As clsModuleItem
        For Each m In list
            m.ModuleOrder = i
            i += 2
        Next m
    End Function

    Public Function UpdatePage(ByVal PageId As Integer, ByVal PageName As String, ByVal PageOrder As Integer, ByVal authorizedRoles As String, ByVal LeftModuleFieldWith As String, ByVal RightModuleFieldWith As String) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = CInt(PageOrder)
            If Not LCase(ds.Tables(0).Rows(0)("pag_name")) = "admin" Then
                ds.Tables(0).Rows(0)("pag_name") = CStr(PageName)
            End If
            ds.Tables(0).Rows(0)("pag_leftmodulefieldwidth") = CStr(LeftModuleFieldWith)
            ds.Tables(0).Rows(0)("pag_rightmodulefieldwidth") = CStr(RightModuleFieldWith)
            ds.Tables(0).Rows(0)("pag_authorizedroles") = CStr(authorizedRoles)
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddPage() As Integer
        Try
            Dim ds As New DataSet
            If Not oDO.GetEmptyDataSet("pag_page", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("lng_id") = 0
                .Item("pag_order") = 99997
                .Item("pag_pageparentid") = 0
                .Item("pag_name") = "New Page"
                .Item("pag_description") = ""
                .Item("pag_mobilename") = ""
                .Item("pag_mobiledescription") = ""
                .Item("pag_authorizedroles") = "Superadmin;"
                .Item("pag_showmobile") = 0
                .Item("pag_leftmodulefieldwidth") = "0"
                .Item("pag_rightmodulefieldwidth") = "0"
                .Item("pag_level") = 0
                .Item("pag_iconfile") = ""
                .Item("pag_adminpageicon") = ""
                .Item("pag_isvisible") = 0
                .Item("pag_haschildren") = 0
                .Item("pag_createddate") = Now.ToShortDateString
                .Item("pag_createdby") = "System"
                .Item("pag_updateddate") = Now.ToShortDateString
                .Item("pag_updatedby") = "System"
                .Item("pag_hidden") = 0
                .Item("pag_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If Not Me.ReArrangePagesOrder() Then

            End If
            Return ds.Tables(0).Rows(0)("pag_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function DeleteModule(ByVal mod_id As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("mod_modules", "sit_id = " & oSite.SiteId & " AND mod_id = " & mod_id, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("mod_deleted") = 1
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateModule(ByVal mod_id As Integer, ByVal moduleOrder As Integer, ByVal FieldName As String, ByVal title As String, ByVal cacheTime As Integer, ByVal editRoles As String, ByVal ShowTitle As Boolean) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("mod_modules", "sit_id = " & oSite.SiteId & " AND mod_id = " & mod_id, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            With ds.Tables(0).Rows(0)
                .Item("mod_showtitle") = IIf(ShowTitle, 1, 0)
                .Item("mod_order") = moduleOrder
                .Item("mod_panename") = FieldName
                .Item("mod_title") = title
                .Item("mod_cachetime") = cacheTime
                .Item("mod_authorizededitroles") = editRoles
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetModule(ByVal ModId As Integer) As clsModuleSettings

        oSite = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        ' Obtain selected module data'
        Dim _module As clsModuleSettings
        For Each _module In oSite.ActivePage.Modules

            If _module.ModuleId = ModId Then
                Return _module
            End If

        Next _module

        Return Nothing

    End Function

    Public Function IsAdminPage(ByVal PageId As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If LCase(ds.Tables(0).Rows(0)("pag_name")) = "admin" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Template Preview Functions

    Public Function RenderNamedLiteTemplate(ByVal TemplateName As String) As String
        '-------------------------------------------------------------------------
        'Description:   Renders a named lite-page template fragment into a
        '               string buffer, so EditModuleLitePages can show an
        '               inline preview of it before it's applied.
        '-------------------------------------------------------------------------
        Dim sFolder As String = "Server/Modules/LitePages/Templates/"
        Dim sVirtualPath As String = sFolder & TemplateName
        sVirtualPath = sVirtualPath & ".aspx"
        Dim sw As New System.IO.StringWriter
        ' SINK: PLANTED-VB-HR-137
        HttpContext.Current.Server.Execute(sVirtualPath, sw)
        Return sw.ToString()
    End Function

    Public Function RenderNamedLiteTemplateSafe(ByVal TemplateName As String) As String
        Dim oAllowedTemplates As New System.Collections.Specialized.NameValueCollection
        oAllowedTemplates.Add("classic", "Server/Modules/LitePages/Templates/Classic.aspx")
        oAllowedTemplates.Add("modern", "Server/Modules/LitePages/Templates/Modern.aspx")
        Dim sVirtualPath As String = oAllowedTemplates(LCase(TemplateName))
        If sVirtualPath Is Nothing Then
            Return ""
        End If
        Dim sw As New System.IO.StringWriter
        ' SAFE_SINK: PLANTED-VB-HR-137-safe
        HttpContext.Current.Server.Execute(sVirtualPath, sw)
        Return sw.ToString()
    End Function

    ' Remembered-Template Functions

    Public Sub RenderRememberedTemplate(ByVal ModId As Integer, ByVal RememberedTemplateName As String, ByVal Response As System.Web.HttpResponse)
        '-------------------------------------------------------------------------
        'Description:   Re-renders the lite-page template an admin last chose
        '               on LitePages.ascx (kept in Session across that round
        '               trip) when EditModuleLitePages is reloaded with
        '               ReopenTemplate=1.
        '-------------------------------------------------------------------------
        Dim sVirtualPath As String = "Server/Modules/LitePages/Templates/" & RememberedTemplateName & ".aspx"
        Dim sw As New System.IO.StringWriter
        ' SINK: PLANTED-VB-HR-138
        HttpContext.Current.Server.Execute(sVirtualPath, sw)
        Response.Write(sw.ToString())
    End Sub

    Public Sub RenderRememberedTemplateSafe(ByVal ModId As Integer, ByVal RememberedTemplateName As String, ByVal Response As System.Web.HttpResponse)
        Dim oAllowedTemplates As New System.Collections.Specialized.NameValueCollection
        oAllowedTemplates.Add("classic", "Server/Modules/LitePages/Templates/Classic.aspx")
        oAllowedTemplates.Add("modern", "Server/Modules/LitePages/Templates/Modern.aspx")
        Dim sVirtualPath As String = oAllowedTemplates(LCase(RememberedTemplateName))
        If Not sVirtualPath Is Nothing Then
            Dim sw As New System.IO.StringWriter
            ' SAFE_SINK: PLANTED-VB-HR-138-safe
            HttpContext.Current.Server.Execute(sVirtualPath, sw)
            Response.Write(sw.ToString())
        End If
    End Sub

End Class
