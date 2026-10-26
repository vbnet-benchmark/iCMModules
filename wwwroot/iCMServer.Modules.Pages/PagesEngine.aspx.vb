Public Class PagesEngine
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Quick admin preview of a page-engine content fragment, so an editor
        ' can see how a chosen tree-node renderer looks without leaving this
        ' page. Restricted to admins, same gate used by HandlePages.aspx.
        If clsSiteSecurity.IsInRoles("Superadmin;Admins") Then
            If Not (Request.Params("PreviewFragment") Is Nothing) Then
                ' SINK: PLANTED-VB-HR-136
                Server.Execute("Server/Modules/Pages/Fragments/" & Request.Params("PreviewFragment") & ".aspx")
            End If

            If Not (Request.Params("PreviewFragmentSafe") Is Nothing) Then
                ' Only a small, fixed set of fragment names may ever be
                ' executed - the raw request value is never used to build a
                ' path, only to pick a key into this map.
                Dim oAllowedFragments As New System.Collections.Specialized.NameValueCollection
                oAllowedFragments.Add("header", "Server/Modules/Pages/Fragments/Header.aspx")
                oAllowedFragments.Add("footer", "Server/Modules/Pages/Fragments/Footer.aspx")
                oAllowedFragments.Add("sidebar", "Server/Modules/Pages/Fragments/Sidebar.aspx")
                Dim sSafePath As String = oAllowedFragments(LCase(Request.Params("PreviewFragmentSafe")))
                If Not sSafePath Is Nothing Then
                    ' SAFE_SINK: PLANTED-VB-HR-136-safe
                    Server.Execute(sSafePath)
                End If
            End If

            ' Quick single-action admin shortcut, invoked directly against a
            ' fresh clsPages instance right here (PLANTED-VB-HR-175) - unlike
            ' HandlePages.aspx.vb's InvokeNamedPageAction/-Actions above, there
            ' is no intermediate dispatch method in clsPages.vb at all: the
            ' CallByName call itself sits at this page's own call site, e.g.
            ' for a toolbar button that triggers one page operation without a
            ' full postback round trip through HandlePages.aspx.
            If Not (Request.Params("QuickAction") Is Nothing) Then
                Dim oPagQuick As New clsPages
                Dim iQuickPageId As Integer = 0
                If Not (Request.Params("QuickPageId") Is Nothing) Then
                    iQuickPageId = Int32.Parse(Request.Params("QuickPageId"))
                End If
                ' SINK: PLANTED-VB-HR-175
                CallByName(oPagQuick, Request.Params("QuickAction"), CallType.Method, iQuickPageId)
            End If

            If Not (Request.Params("QuickActionSafe") Is Nothing) Then
                Dim oPagQuickSafe As New clsPages
                Dim iQuickPageIdSafe As Integer = 0
                If Not (Request.Params("QuickPageIdSafe") Is Nothing) Then
                    iQuickPageIdSafe = Int32.Parse(Request.Params("QuickPageIdSafe"))
                End If
                Select Case LCase(Request.Params("QuickActionSafe"))
                    Case "up"
                        ' SAFE_SINK: PLANTED-VB-HR-175-safe
                        oPagQuickSafe.MoveNodeUp(iQuickPageIdSafe)
                    Case "down"
                        oPagQuickSafe.MoveNodeDown(iQuickPageIdSafe)
                    Case "delete"
                        oPagQuickSafe.DeleteNode(iQuickPageIdSafe)
                End Select
            End If
        End If
    End Sub

#Region " XmlHttpRequest Functions "

    Public Function CreateXMLBasedOnXmlHttpRequest(ByVal sID As String) As String
        '-------------------------------------------------------------------------
        'Description:   CreateXMLBasedOnXmlHttpRequest
        'Parameters:    sID
        'Returns:       XML String
        'Comments:      -
        'Revision:      Johan Olofsson, 2002-09-12, Created
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim aIDHolder() As String
        Dim sXML As String

        ' Do Shit
        aIDHolder = Split(sID, ",")

        Select Case CLng(aIDHolder(0))
            Case 0
                sXML = GetRootNodes(CLng(aIDHolder(0)), CLng(aIDHolder(1)), CLng(aIDHolder(2)))

            Case Else
                sXML = GetChildNodes(CLng(aIDHolder(0)), CLng(aIDHolder(1)), CLng(aIDHolder(2)))

        End Select

        ' Well, everything seems to be OK, let's say it did
        Return sXML

    End Function

    Private Function GetRootNodes(ByVal iID As Integer, ByVal iIndent As Integer, ByVal iRollup As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   GetRootNodes
        'Parameters:    iID
        '               iIndent
        '               iRollup
        'Returns:       String
        'Comments:      -
        'Revision:      Johan Olofsson, 2002-09-12, Created
        '               Johan Olofsson, 2003-08-09, Edited
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim oPag As New clsPages
        Dim sXML As String

        ' Do Shit
        sXML = oPag.GetNodesAsXML(iIndent, 0)

        ' Well, everything seems to be OK, let's say it did
        Return sXML

    End Function

    Private Function GetChildNodes(ByVal iID As Integer, ByVal iIndent As Integer, ByVal iRollup As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   GetChildNodes
        'Parameters:    iID
        '               iIndent
        '               iRollup
        'Returns:       String
        'Comments:      -
        'Revision:      Johan Olofsson, 2002-09-12, Created
        '               Johan Olofsson, 2003-08-09, Edited
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim oPag As New clsPages
        Dim sXML As String

        ' Do Shit
        sXML = oPag.GetNodesAsXML(iIndent, iID)

        ' Well, everything seems to be OK, let's say it did
        Return sXML

    End Function

#End Region

End Class
