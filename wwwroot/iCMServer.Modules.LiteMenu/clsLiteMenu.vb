Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.web

Public Class clsLiteMenu

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Protected oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)


    'Public Function GetNodesAsXML(ByVal ModuleId As Integer, ByVal id As Integer) As String
    '    '-------------------------------------------------------------------------
    '    'Description:   GetNodesAsXML for Child Nodes
    '    'Parameters:    moduleId
    '    '               id
    '    'Returns:       String
    '    'Comments:      -
    '    'Revision:      Johan Olofsson, 2002-11-21, Created
    '    '               Johan Olofsson, 2003-02-17, Edited
    '    '-------------------------------------------------------------------------

    '    Const XML_TREE_START = "<?xml version='1.0' encoding='ISO-8859-1'?>" & vbCrLf & "<tree>" & vbCrLf
    '    Const XML_TREE_END = "</tree>" & vbCrLf
    '    Const TREE_ENGINE_FILE = "Subs/SubsTreeviewEngine.aspx"
    '    Const DEFAULT_XML = "<tree text='No items avalible' icon='XLoadTree/images/file.png' openIcon='XLoadTree/images/file.png'></tree>"

    '    ' Standard variables
    '    Dim sXML As String
    '    Dim sSQL As String
    '    Dim myDataSet As New DataSet()
    '    Dim myDataAdapter As New SqlClient.SqlDataAdapter()
    '    Dim myRow As DataRow
    '    Dim sIcon As String
    '    Dim sOpenIcon As String
    '    Dim bHaveChild As Boolean

    '    ' Create Instance of Connection and Command Object
    '    sSQL = "SELECT * FROM Tabs WHERE TabID <> 0 AND ParentID = " & id & "ORDER BY TabOrder" ' WHERE ModuleID = " & ModuleId & " AND RollupID = " & id
    '    Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
    '    myDataAdapter = New SqlClient.SqlDataAdapter(sSQL, myConnection)

    '    ' Execute the command
    '    myDataAdapter.Fill(myDataSet)

    '    ' Do Shit
    '    sXML = XML_TREE_START

    '    ' x
    '    If myDataSet.Tables(0).Rows.Count = 0 Then
    '        sXML += DEFAULT_XML
    '    End If

    '    ' Loop all Nodes
    '    For Each myRow In myDataSet.Tables(0).Rows
    '        bHaveChild = CheckForChild(ModuleId, myRow("TabID"))
    '        sIcon = "XLoadTree/images/xp/netdoc.png"
    '        sOpenIcon = "XLoadTree/images/xp/netdoc.png"
    '        If Not bHaveChild Then
    '            sXML += CreateNodeStart(myRow("TabName"), "", "javascript:SelectSubItem(" & myRow("TabID") & ")", sIcon, sOpenIcon)
    '            sXML += CreateNodeEnd()
    '        Else
    '            sXML += CreateNodeStart(myRow("TabName"), TREE_ENGINE_FILE & "?sID=" & myRow("TabID") & "," & ModuleId & ",0", "javascript:SelectSubItem(" & myRow("TabID") & ")", sIcon, sOpenIcon)
    '            sXML += CreateNodeEnd()
    '        End If
    '        bHaveChild = False
    '    Next

    '    sXML += XML_TREE_END

    '    ' Well, everything seems to be OK, let's say it did
    '    Return sXML

    'End Function

    'Private Function CheckForChild(ByVal ModuleId As Integer, ByVal RollupID As Integer) As Boolean
    '    '-------------------------------------------------------------------------
    '    'Description:   CheckForChild
    '    'Parameters:    ModuleId
    '    '               RollupID
    '    'Returns:       Boolean
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2001-11-22, Created 
    '    '               Johan Olofsson 2003-02-17, Edited
    '    '-------------------------------------------------------------------------

    '    ' Standard variables
    '    Dim myDataSet As New DataSet()
    '    Dim myDataAdapter As New SqlClient.SqlDataAdapter()
    '    Dim sSQL As String
    '    Try

    '        ' Do Shit
    '        sSQL = "SELECT * FROM Tabs WHERE TabID <> 0 AND ParentID = " & RollupID  ' WHERE ModuleID = " & ModuleId & " AND RollupID = " & RollupID

    '        ' Create Instance of Connection and Command Object
    '        Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
    '        myDataAdapter = New SqlClient.SqlDataAdapter(sSQL, myConnection)

    '        ' Execute the command
    '        myDataAdapter.Fill(myDataSet)

    '        If myDataSet.Tables(0).Rows.Count = 0 Then
    '            Return False
    '        Else
    '            Return True
    '        End If

    '    Catch
    '        Return False

    '    End Try

    'End Function

    'Private Function CreateNodeStart(ByVal sTitle As String, ByVal sSrc As String, ByVal sAction As String, ByVal sIcon As String, ByVal sOpenIcon As String) As String
    '    '-------------------------------------------------------------------------
    '    'Description:   CreateNodeStart
    '    'Parameters:    sTitle
    '    '               sSrc
    '    '               sAction
    '    '               sIcon
    '    '               sOpenIcon
    '    'Returns:       String
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2001-10-10, Created 
    '    '               Johan Olofsson 2001-10-10, Edited
    '    '-------------------------------------------------------------------------

    '    Const XML_NODE_START = "<tree text='"
    '    Const XML_NODE_SRC = "' src='"
    '    Const XML_NODE_ACTION = "' action='"
    '    Const XML_NODE_ICON = "' icon='"
    '    Const XML_NODE_OPENICON = "' openIcon='"
    '    Const XML_NODE_END = "'>" & vbCrLf

    '    ' Standard variables
    '    Dim sXML As String

    '    ' Do Shit
    '    sXML = XML_NODE_START & _
    '           System.Web.HttpUtility.HtmlEncode(sTitle) & _
    '           XML_NODE_SRC & _
    '           sSrc & _
    '           XML_NODE_ACTION & _
    '           sAction & _
    '           XML_NODE_ICON & _
    '           sIcon & _
    '           XML_NODE_OPENICON & _
    '           sOpenIcon & _
    '           XML_NODE_END

    '    Return sXML

    'End Function

    'Private Function CreateNodeEnd() As String
    '    '-------------------------------------------------------------------------
    '    'Description:   CreateNodeEnd
    '    'Parameters:    -
    '    'Returns:       String
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2001-10-10, Created 
    '    '               Johan Olofsson 2001-10-10, Edited
    '    '-------------------------------------------------------------------------

    '    Const XML_NODE_END = "</tree>" & vbCrLf

    '    ' Standard variables
    '    Dim sXML As String

    '    ' Do Shit
    '    sXML = XML_NODE_END

    '    Return sXML

    'End Function

    'Public Function GetAllSubs() As DataSet
    '    '-------------------------------------------------------------------------
    '    'Description:   GetAllSubs
    '    'Parameters:    -
    '    'Returns:       DataSet
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2003-02-18, Created 
    '    '               Johan Olofsson 2003-02-18, Edited
    '    '-------------------------------------------------------------------------

    '    ' Standard variables
    '    Dim sSQL As String
    '    Dim myDataSet As New DataSet()
    '    Dim myDataAdapter As New SqlClient.SqlDataAdapter()

    '    ' Do Shit

    '    ' Create Instance of Connection and Command Object
    '    sSQL = "SELECT * FROM Tabs WHERE TabID <> 0 ORDER BY ParentID, TabOrder"
    '    Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
    '    myDataAdapter = New SqlClient.SqlDataAdapter(sSQL, myConnection)

    '    ' Execute the command
    '    myDataAdapter.Fill(myDataSet)

    '    Return myDataSet

    'End Function

    'Public Function GetAllSubsDESC() As DataSet
    '    '-------------------------------------------------------------------------
    '    'Description:   GetAllSubs
    '    'Parameters:    -
    '    'Returns:       DataSet
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2003-02-18, Created 
    '    '               Johan Olofsson 2003-02-18, Edited
    '    '-------------------------------------------------------------------------

    '    ' Standard variables
    '    Dim sSQL As String
    '    Dim myDataSet As New DataSet()
    '    Dim myDataAdapter As New SqlClient.SqlDataAdapter()

    '    ' Do Shit

    '    ' Create Instance of Connection and Command Object
    '    sSQL = "SELECT * FROM Tabs WHERE TabID <> 0 ORDER BY ParentID, TabOrder DESC"
    '    Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
    '    myDataAdapter = New SqlClient.SqlDataAdapter(sSQL, myConnection)

    '    ' Execute the command
    '    myDataAdapter.Fill(myDataSet)

    '    Return myDataSet

    'End Function

    'Public Function GetChildSubs(ByVal ParentID As Integer) As DataSet
    '    '-------------------------------------------------------------------------
    '    'Description:   GetChildSubs
    '    'Parameters:    -
    '    'Returns:       DataSet
    '    'Comments:      -
    '    'ToDo:          -
    '    'Revision:      Johan Olofsson 2003-02-20, Created 
    '    '               Johan Olofsson 2003-02-20, Edited
    '    '-------------------------------------------------------------------------

    '    ' Standard variables
    '    Dim sSQL As String
    '    Dim myDataSet As New DataSet()
    '    Dim myDataAdapter As New SqlClient.SqlDataAdapter()

    '    ' Do Shit

    '    ' Create Instance of Connection and Command Object
    '    sSQL = "SELECT * FROM Tabs WHERE TabID <> 0 AND ParentID = " & ParentID
    '    Dim myConnection As New SqlConnection(ConfigurationSettings.AppSettings("connectionString"))
    '    myDataAdapter = New SqlClient.SqlDataAdapter(sSQL, myConnection)

    '    ' Execute the command
    '    myDataAdapter.Fill(myDataSet)

    '    Return myDataSet

    'End Function

    Public Function GetDocument(ByVal PageId As Integer, ByVal ModId As Integer, ByVal CatId As Integer, ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND pag_id = " & PageId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetSourceSubMenu(ByVal PageId As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   GetSourceSubMenu
        'Parameters:    -
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2003-02-26, Created 
        '               Johan Olofsson 2003-05-22, Edited
        '-------------------------------------------------------------------------

        Return SearchForSourceSubMenu(PageId)

    End Function

    Private Function SearchForSourceSubMenu(ByVal PageId As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   SearchForSourceSubMenu
        'Parameters:    -
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2003-02-26, Created 
        '               Johan Olofsson 2003-05-22, Edited
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim Auth As String
        Dim dsPage As New DataSet
        Dim sError As String

        If Not oDO.GetDataSet("pag_page", "pag_id = " & PageId & " AND pag_deleted = 0", "", sError, ED, EC, dsPage) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If

        If dsPage.Tables.Count > 0 Then
            If dsPage.Tables(0).Rows.Count > 0 Then
                If dsPage.Tables(0).Rows(0)("pag_pageparentid") = 0 Then
                    Return dsPage.Tables(0).Rows(0)("pag_authorizedroles")
                Else
                    Auth = SearchForSourceSubMenu(dsPage.Tables(0).Rows(0)("pag_pageparentid"))
                End If
            Else
                Auth = "Superadmin;"
            End If
        Else
            Auth = "Superadmin;"
        End If

        Return Auth

    End Function

End Class

