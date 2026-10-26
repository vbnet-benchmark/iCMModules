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

Public Class clsPages

    Protected oDO As New iCDataObject
    Private oCrypto As New iConsulting.iCMServer.clsCrypto
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
        Const TREE_ENGINE_FILE = "Server/Modules/Pages/PagesEngine.aspx"
        Const DEFAULT_XML = "<tree text='No items avalible' icon='Server/Modules/Pages/XLoadTree/images/xp/netdoc.png' openIcon='Server/Modules/Pages/XLoadTree/images/xp/netdoc.png'></tree>"

        ' Standard variables
        Dim sXML As String
        Dim sSQL As String
        Dim myDataSet As New DataSet
        Dim myRow As DataRow
        Dim sIcon As String
        Dim sOpenIcon As String
        Dim bHaveChild As Boolean
        Dim oDefine As New clsDefinedDataList

        oDefine.AddDefinedTableColumn("pag_id")
        oDefine.AddDefinedTableColumn("pag_name")
        If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = " & id & " AND pag_deleted = 0", "pag_order", "", ED, EC, myDataSet) Then

        End If

        ' Do Shit
        sXML = XML_TREE_START

        ' x
        If myDataSet.Tables(0).Rows.Count = 0 Then
            sXML += DEFAULT_XML
        End If

        ' Loop all Nodes
        For Each myRow In myDataSet.Tables(0).Rows
            bHaveChild = CheckForChild(ModuleId, myRow("pag_id"))
            sIcon = "Server/Modules/Pages/XLoadTree/images/xp/netdoc.png"
            sOpenIcon = "Server/Modules/Pages/XLoadTree/images/xp/netdoc.png"
            If Not bHaveChild Then
                sXML += CreateNodeStart(myRow("pag_name"), "", "javascript:SelectSubItem(" & myRow("pag_id") & ")", sIcon, sOpenIcon)
                sXML += CreateNodeEnd()
            Else
                sXML += CreateNodeStart(myRow("pag_name"), TREE_ENGINE_FILE & "?sID=" & myRow("pag_id") & "," & ModuleId & ",0", "javascript:SelectSubItem(" & myRow("pag_id") & ")", sIcon, sOpenIcon)
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
        Dim oDefine As New clsDefinedDataList

        Try

            ' Do Shit
            oDefine.AddDefinedTableColumn("pag_id")
            If Not oDO.GetDefinedDataSet("pag_page", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_pageparentid = " & RollupID & " AND pag_deleted = 0", "", "", ED, EC, myDataSet) Then

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
                If Not DeleteChildNode(PageID) Then

                End If
                If Not Me.ReArrangePagesOrder() Then

                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Private Function DeleteChildNode(ByVal PageID As Integer) As Boolean
        Try
            Dim ds As New DataSet
            Dim dr As DataRow
            If Not oDO.GetDataSet("pag_page", "pag_pageparentid = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            For Each dr In ds.Tables(0).Rows
                If Not DeleteChildNode(dr("pag_id")) Then

                End If
                Dim iLevel As Integer = CType(dr("pag_level"), Integer)
                ' 333 = Startpage
                ' 666 = Adminpage
                If Not iLevel = 333 And Not iLevel = 666 Then
                    If oSite.SiteSoftDelete Then
                        dr("pag_deleted") = 1
                    Else
                        dr.Delete()
                    End If
                End If
            Next
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
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

    Public Function MoveNodeTo(ByVal PageID As Integer, ByVal ToId As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "pag_id = " & PageID & " AND sit_id = " & oSite.SiteId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_pageparentid") = ToId
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

    ''' <summary>
    ''' Single-action dispatch for HandlePages.aspx's "quickaction" mode
    ''' (PLANTED-VB-HR-173): the caller names the clsPages method to invoke by
    ''' string, instead of HandlePages.aspx.vb's own hardcoded Select Case
    ''' routing to DeleteNode/MoveNodeUp/MoveNodeDown/MoveNodeTo.
    ''' </summary>
    Public Function InvokeNamedPageAction(ByVal sActionName As String, ByVal PageId As Integer) As Boolean
        Try
            ' SINK: PLANTED-VB-HR-173
            CallByName(Me, sActionName, CallType.Method, PageId)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Safe twin of InvokeNamedPageAction (PLANTED-VB-HR-173-safe): the
    ''' caller-supplied key only ever selects one of the SAME three actions
    ''' HandlePages.aspx.vb's own hardcoded routing already exposes - it is
    ''' never used as the method name itself.
    ''' </summary>
    Public Function InvokeNamedPageActionSafe(ByVal sActionKey As String, ByVal PageId As Integer) As Boolean
        Try
            Select Case LCase(sActionKey)
                Case "up"
                    ' SAFE_SINK: PLANTED-VB-HR-173-safe
                    Return MoveNodeUp(PageId)
                Case "down"
                    Return MoveNodeDown(PageId)
                Case "delete"
                    Return DeleteNode(PageId)
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Bulk variant of InvokeNamedPageAction (PLANTED-VB-HR-174): loops over a
    ''' caller-supplied, comma separated list of method names and invokes each
    ''' one by name. Distinct shape from the single-call HR-173 above (a batch
    ''' loop, not one dispatch) - no genuine polymorphism/virtual dispatch was
    ''' found anywhere near this module's Shell()/CallByName() host code to
    ''' build a type-dependent instance from instead (clsPages/HandlePages/
    ''' PagesEngine declare no Interface/MustInherit/Overridable hierarchy of
    ''' their own), so this uses the loop-batch-CallByName shape explicitly as
    ''' the substitute. The underlying danger is the same as HR-173: any
    ''' public method on this class can be named, not just the three
    ''' HandlePages.aspx.vb itself would ever route to.
    ''' </summary>
    Public Sub InvokeNamedPageActions(ByVal sActionList As String, ByVal PageId As Integer)
        If sActionList Is Nothing Then
            Return
        End If
        Dim aActions() As String = Split(sActionList, ",")
        Dim i As Integer
        For i = 0 To aActions.GetUpperBound(0)
            Try
                ' SINK: PLANTED-VB-HR-174
                CallByName(Me, aActions(i).Trim(), CallType.Method, PageId)
            Catch ex As Exception
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Safe twin of InvokeNamedPageActions (PLANTED-VB-HR-174-safe): each
    ''' entry in the list only ever selects one of the SAME allow-listed
    ''' actions as InvokeNamedPageActionSafe - never used as a method name.
    ''' </summary>
    Public Sub InvokeNamedPageActionsSafe(ByVal sActionList As String, ByVal PageId As Integer)
        If sActionList Is Nothing Then
            Return
        End If
        Dim aActionsSafe() As String = Split(sActionList, ",")
        Dim j As Integer
        For j = 0 To aActionsSafe.GetUpperBound(0)
            Select Case LCase(aActionsSafe(j).Trim())
                Case "up"
                    ' SAFE_SINK: PLANTED-VB-HR-174-safe
                    MoveNodeUp(PageId)
                Case "down"
                    MoveNodeDown(PageId)
                Case "delete"
                    DeleteNode(PageId)
            End Select
        Next
    End Sub

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
        If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_deleted = 0", "pag_pageparentid,pag_order", "", ED, EC, ds) Then
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
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("rol_id")
            oDefine.AddDefinedTableColumn("rol_name")
            Dim ds As New DataSet
            If Not oDO.GetDefinedDataSet("rol_roles", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND rol_hidden = 0 AND rol_deleted = 0", "rol_name", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetModuleDefinitions() As DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("mde_id")
            oDefine.AddDefinedTableColumn("mde_name")
            Dim ds As New DataSet
            If Not oDO.GetDefinedDataSet("mde_moduledefinitions", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mde_hidden = 0 AND mde_deleted = 0", "", "", ED, EC, ds) Then
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
                .Item("mod_alignment") = "middle"
                .Item("mod_color") = ""
                .Item("mod_border") = "0"
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

    Public Function UpdatePage(ByVal PageId As Integer, ByVal PageName As String, ByVal PageOrder As Integer, ByVal authorizedRoles As String, ByVal LeftModuleFieldWith As String, ByVal CenterModuleFieldWith As String, ByVal RightModuleFieldWith As String, ByVal ContentAlignCenter As Boolean, ByVal IsVisible As Boolean, ByVal BackColor As String, ByVal Top As String, ByVal Height As String, ByVal UseMinimizer As Boolean, ByVal PictureHorizontalAlign As String, ByVal PictureVerticalAlign As String, ByVal PictureHorizontalTiling As Boolean, ByVal PictureVerticalTiling As Boolean) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            ds.Tables(0).Rows(0)("pag_order") = CInt(PageOrder)
            If Not ds.Tables(0).Rows(0)("pag_level") = 666 Then
                ds.Tables(0).Rows(0)("pag_name") = CStr(PageName)
            End If

            ds.Tables(0).Rows(0)("pag_backcolor") = BackColor
            ds.Tables(0).Rows(0)("pag_picturehorizontalalign") = PictureHorizontalAlign
            ds.Tables(0).Rows(0)("pag_pictureverticalalign") = PictureVerticalAlign
            ds.Tables(0).Rows(0)("pag_picturehorizontaltiling") = IIf(PictureHorizontalTiling, 1, 0)
            ds.Tables(0).Rows(0)("pag_pictureverticaltiling") = IIf(PictureVerticalTiling, 1, 0)
            ds.Tables(0).Rows(0)("pag_minimizer") = IIf(UseMinimizer, 1, 0)
            ds.Tables(0).Rows(0)("pag_height") = Height
            ds.Tables(0).Rows(0)("pag_top") = Top

            ds.Tables(0).Rows(0)("pag_leftmodulefieldwidth") = CStr(LeftModuleFieldWith)
            ds.Tables(0).Rows(0)("pag_contentmodulefieldwidth") = CStr(CenterModuleFieldWith)
            ds.Tables(0).Rows(0)("pag_rightmodulefieldwidth") = CStr(RightModuleFieldWith)
            ds.Tables(0).Rows(0)("pag_authorizedroles") = CStr(authorizedRoles)
            ds.Tables(0).Rows(0)("pag_isvisible") = IIf(IsVisible, 1, 0)
            ds.Tables(0).Rows(0)("pag_contentalign") = IIf(ContentAlignCenter, 1, 0)
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddPage(ByVal ContainerWidth1 As String, ByVal ContainerWidth2 As String, ByVal ContainerWidth3 As String, Optional ByVal ParentId As Integer = 0) As Integer
        Try
            Dim ds As New DataSet
            If Not oDO.GetEmptyDataSet("pag_page", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("lng_id") = 0
                .Item("pag_order") = 99997
                .Item("pag_pageparentid") = ParentId

                .Item("pag_backcolor") = "n/a"
                .Item("pag_pictureid") = ""
                .Item("pag_picturehref") = ""
                .Item("pag_picturehorizontalalign") = "center"
                .Item("pag_pictureverticalalign") = "center"
                .Item("pag_picturehorizontaltiling") = 0
                .Item("pag_pictureverticaltiling") = 0
                .Item("pag_minimizer") = 0
                .Item("pag_height") = "n/a"
                .Item("pag_top") = "0"

                .Item("pag_name") = "New Page"
                .Item("pag_description") = ""
                .Item("pag_mobilename") = ""
                .Item("pag_mobiledescription") = ""
                .Item("pag_authorizedroles") = "Superadmin;"
                .Item("pag_showmobile") = 0
                .Item("pag_leftmodulefieldwidth") = ContainerWidth1
                .Item("pag_contentmodulefieldwidth") = ContainerWidth2
                .Item("pag_rightmodulefieldwidth") = ContainerWidth3
                .Item("pag_contentalign") = 0
                .Item("pag_level") = 0
                .Item("pag_iconfile") = ""
                .Item("pag_adminpageicon") = ""
                .Item("pag_isvisible") = 1
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

    Public Function UpdateModule(ByVal mod_id As Integer, ByVal moduleOrder As Integer, ByVal FieldName As String, ByVal title As String, ByVal cacheTime As Integer, ByVal editRoles As String, ByVal ShowTitle As Boolean, ByVal IsVisible As Boolean, ByVal Align As String, ByVal Border As String, ByVal Color As String) As Boolean
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
                .Item("mod_alignment") = Align
                .Item("mod_border") = Border
                .Item("mod_color") = IIf(Color = "n/a", "", Color)
                .Item("mod_cachetime") = cacheTime
                .Item("mod_authorizededitroles") = editRoles
                .Item("mod_hidden") = IIf(IsVisible, 0, 1)
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
            If ds.Tables(0).Rows(0)("pag_level") = 666 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsHomeOrAdminPage(ByVal PageId As Integer) As Boolean
        Try
            Dim ds As New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId, "", "", ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(ds.GetXml)
            End If
            If ds.Tables(0).Rows(0)("pag_level") = 666 Or ds.Tables(0).Rows(0)("pag_level") = 333 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetPicture(ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds
                Else
                    Return New DataSet
                End If
            Else
                Return New DataSet
            End If
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function UpdatePicture(ByVal content As Byte(), ByVal contentType As String, ByVal length As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Dim i As Integer
        Try
            If Not oDO.GetEmptyDataSet("doc_documents", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("doc_rollup") = 0
                .Item("doc_revision") = 0
                .Item("doc_content") = content
                .Item("doc_contenttype") = contentType
                .Item("doc_contentsize") = length
                .Item("doc_createddate") = Now.ToLongDateString
                .Item("doc_createdby") = HttpContext.Current.User.Identity.Name
                .Item("doc_updateddate") = Now.ToLongDateString
                .Item("doc_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            i = ds.Tables(0).Rows(0)("doc_id")
            ds = New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("pag_pictureid") = i.ToString
            ds.Tables(0).Rows(0)("pag_picturehref") = "EditPagesStream.aspx?DocId=" & i
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeletePicture(ByVal DocId As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("doc_deleted") = 1
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            ds = New DataSet
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("pag_pictureid") = ""
            ds.Tables(0).Rows(0)("pag_picturehref") = ""
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CheckIfThereIsAInstanceOfDocuments(ByVal PagId As Integer, ByVal MdeId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("mde_desktopsrc")
            If oDO.GetDefinedDataSet("mde_moduledefinitions", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND mde_id = " & MdeId, "", "", ED, EC, ds) Then

            End If
            If LCase(ds.Tables(0).Rows(0)("mde_desktopsrc")) = "desktop/modules/documents/documents.ascx" Then
                ds = New DataSet
                oDefine = New clsDefinedDataList
                oDefine.AddDefinedTableColumn("mod_id")
                If oDO.GetDefinedDataSet("mod_modules", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mde_id = " & MdeId & " AND mod_deleted = 0", "", "", ED, EC, ds) Then

                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

End Class