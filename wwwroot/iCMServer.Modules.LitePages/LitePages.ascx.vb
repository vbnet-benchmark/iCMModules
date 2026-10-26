Imports System.Collections

Public MustInherit Class LitePages : Inherits clsSiteModuleControl

    Protected WithEvents addBtn As System.Web.UI.WebControls.Button
    Protected WithEvents PageList As System.Web.UI.WebControls.ListBox
    Protected WithEvents upBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents downBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents editBtn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents deleteBtn As System.Web.UI.WebControls.ImageButton

    Private Index As Integer = 0
    Private PageId As Integer = 0
    Protected Pages As ArrayList
    Private bError As Boolean

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Placeholder1 As System.Web.UI.WebControls.PlaceHolder

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
        ' Verify that the current user has access to access this page
        If clsSiteSecurity.IsInRoles("Admins;Superadmin") = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If
        If Not (Request.Params("Index") Is Nothing) Then
            Index = Int32.Parse(Request.Params("Index"))
        End If

        ' Remember which template the admin last picked, so
        ' EditModuleLitePages can re-render it later (ReopenTemplate=1)
        ' without the name round-tripping through the querystring again.
        If Not (Request.Params("RememberTemplate") Is Nothing) Then
            Session("LitePagesLastTemplate" & ModuleId) = Request.Params("RememberTemplate")
        End If

        ' Obtain PortalSettings from Current Context
        Dim _SiteSettings As clsSiteSettings = CType(Context.Items("SiteSettings"), clsSiteSettings)

        Pages = New ArrayList
        Dim oPage As clsPageStripDetails
        For Each oPage In _SiteSettings.DesktopPages

            Dim p As New PageItem
            p.PageName = oPage.PageName
            p.PageId = oPage.PageId
            p.PageOrder = oPage.PageOrder
            Pages.Add(p)

        Next oPage

        ' Give the admin tab a big sort order number, to ensure it's
        ' always at the end
        Dim adminTab As PageItem = CType(Pages((Pages.Count - 1)), PageItem)
        adminTab.PageOrder = 99999

        ' If this is the first visit to the page, bind the tab data to the page listbox
        If Page.IsPostBack = False Then

            Call AddAttributes()
            PageList.DataBind()

        End If
    End Sub

    Private Sub AddAttributes()
        deleteBtn.Attributes.Add("onclick", "return confirm('Vill du verkligen radera denna sida?');")
    End Sub

    Private Sub addBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addBtn.Click
        Response.Redirect("~/Server/Modules/LitePages/EditLitePages.aspx?PageID=0")
    End Sub

    Private Sub editBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles editBtn.Click
        If Not PageList.SelectedIndex = -1 Then
            Dim oPag As New clsLitePages
            Response.Redirect("~/Server/Modules/LitePages/EditLitePages.aspx?PageID=" & PageList.SelectedValue)
        End If
    End Sub

    Private Sub upBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles upBtn.Click
        If Not PageList.SelectedIndex = -1 Then
            Dim o As New clsLitePages
            bError = o.MoveNodeUp(PageList.SelectedValue)
            Response.Redirect(("~/icm.aspx?Index=" & (Pages.Count - 1).ToString() & "&PageId=" & PageId))
        End If
    End Sub

    Private Sub downBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles downBtn.Click
        If Not PageList.SelectedIndex = -1 Then
            Dim o As New clsLitePages
            bError = o.MoveNodeDown(PageList.SelectedValue)
            Response.Redirect(("~/icm.aspx?Index=" & (Pages.Count - 1).ToString() & "&PageId=" & PageId))
        End If
    End Sub

    Private Sub deleteBtn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles deleteBtn.Click
        If Not PageList.SelectedIndex = -1 Then
            Dim o As New clsLitePages
            bError = o.DeleteNode(PageList.SelectedValue)
            Response.Redirect(("~/icm.aspx?Index=" & (Pages.Count - 1).ToString() & "&PageId=" & PageId))
        End If
    End Sub
End Class

Public Class PageItem
    Implements IComparable

    Private _PageOrder As Integer
    Private _name As String
    Private _id As Integer


    Public Property PageOrder() As Integer

        Get
            Return _PageOrder
        End Get
        Set(ByVal Value As Integer)
            _PageOrder = Value
        End Set
    End Property


    Public Property PageName() As String

        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property


    Public Property PageId() As Integer

        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Overridable Function CompareTo(ByVal value As Object) As Integer Implements IComparable.CompareTo

        If value Is Nothing Then
            Return 1
        End If

        Dim compareOrder As Integer = CType(value, PageItem).PageOrder

        If Me.PageOrder = compareOrder Then Return 0
        If Me.PageOrder < compareOrder Then Return -1
        If Me.PageOrder > compareOrder Then Return 1
        Return 0

    End Function

End Class