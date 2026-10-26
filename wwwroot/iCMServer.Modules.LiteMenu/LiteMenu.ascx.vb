
Imports System.Web

Public MustInherit Class LiteMenu : Inherits clsSiteModuleControl

    Protected WelcomeMessage As System.Web.UI.WebControls.Label
    Public Index As Integer
    Public ShowTabs As Boolean = True
    Protected WithEvents siteName As System.Web.UI.WebControls.Label
    Protected LogoffLink As String = ""
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Pages As System.Web.UI.WebControls.DataList
    Public MenuContainer(4, 0) As String

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
        ' Obtain PortalSettings from Current Context
        Dim _SiteSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

        If _SiteSettings.SiteLogo <> "" Then
            Dim sText As String
            'If _SiteSettings.SiteLogoHref <> "" Then
            '    'Label1.ToolTip = _SiteSettings.SiteLogoHref
            '    'sText += "<a href='" & _SiteSettings.SiteLogoHref
            '    'sText += "' target='_blank'>"
            '    sText += "<img src='Server/Modules/LiteMenu/" & _SiteSettings.SiteLogo
            '    sText += "' border=0></a>"
            'Else
            '    sText += "<a>"
            '    sText += "<img src='Server/Modules/LiteMenu/" & _SiteSettings.SiteLogo
            '    sText += "' border=0></a>"
            'End If
            sText += "<a>"
            sText += "<img src='Server/Modules/LiteMenu/" & _SiteSettings.SiteLogo
            sText += "' border=0></a>"
            Label1.Text = sText
        End If

        ' Dynamically render portal tab strip
        If ShowTabs = True Then
            Index = _SiteSettings.ActivePage.PageId
            Dim authorizedPages As New System.Collections.ArrayList
            Dim iPages As Integer = 0
            Dim i As Integer

            For i = 0 To _SiteSettings.DesktopPages.Count - 1
                Dim Page As clsPageStripDetails = CType(_SiteSettings.DesktopPages(i), clsPageStripDetails)
                If clsSiteSecurity.IsInRoles(Page.AuthorizedRoles) Then
                    authorizedPages.Add(Page)
                    'If SourceSubMenuIsAuthenticated(Page.PageParentId) Then
                    '    authorizedPages.Add(Page)
                    '    'ReDim Preserve MenuContainer(4, iPages)
                    '    'MenuContainer(0, iPages) = Page.PageId
                    '    'MenuContainer(1, iPages) = Page.PageName
                    '    'MenuContainer(2, iPages) = Page.PageOrder
                    '    'MenuContainer(3, iPages) = Page.AuthorizedRoles
                    '    'MenuContainer(4, iPages) = Page.PageParentId
                    'End If
                End If
                If Page.PageId = Index Then
                    Pages.SelectedIndex = iPages
                End If
                iPages += 1
            Next i

            ' Populate Tab List at Top of the Page with authorized tabs
            Pages.DataSource = authorizedPages
            Pages.DataBind()

        End If

    End Sub

    Private Function SourceSubMenuIsAuthenticated(ByVal PageParentId As Integer) As Boolean
        Dim oMenu As New clsLiteMenu
        If PageParentId = 0 Then Return True
        Return clsSiteSecurity.IsInRoles(oMenu.GetSourceSubMenu(PageParentId))
    End Function

    Public Sub CreateMenu(ByVal iStartPosition As Integer, ByVal iTabMultiplicator As Long, ByVal iTabSpace As Long)

        Dim i As Integer = 0
        Dim iWidth As Integer = 0
        Dim iCount As Integer = 0
        Dim iLength As Integer = 0
        Dim iHeaderLength As Integer = iStartPosition
        Dim sJava As String = "oM.menuPlacement=new Array("

        ' Loop all submenus (Tabs) and print them on the screen
        For i = LBound(MenuContainer, 2) To UBound(MenuContainer, 2)
            If Len(MenuContainer(0, i)) > 0 Then
                iCount += 1
                If MenuContainer(4, i) = 0 Then
                    sJava += iHeaderLength & ", "
                    iWidth = IIf((Len(MenuContainer(1, i)) * iTabMultiplicator) < 50, 50, (Len(MenuContainer(1, i)) * iTabMultiplicator))
                    iHeaderLength += (iWidth + iTabSpace)
                Else
                    iWidth = 155
                End If
                iLength += (iWidth + iTabSpace)
                Response.Write("oM.makeMenu('i" & MenuContainer(0, i) & "','" & IIf(MenuContainer(4, i) = 0, "", "i" & MenuContainer(4, i)) & "','" & MenuContainer(1, i) & "','" & Request.FilePath & "?PageId=" & MenuContainer(0, i) & "',''," & iWidth & ");")
            End If
        Next

        ' Perform the construct of the dynamic menu
        Response.Write(Left(sJava, Len(sJava) - 2) & ")" & ";")
        Response.Write("oM.construct();")


    End Sub

End Class
