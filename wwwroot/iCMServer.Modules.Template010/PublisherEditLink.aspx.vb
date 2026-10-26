
Imports System.Security
Imports System.Security.Principal
Imports System.web
Imports System.Web.Security

Public Class PublisherEditLink1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddUrl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents urlfield As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected Target As String
    Protected Type As String
    Protected Show As String
    Protected Url As String
    Protected Save As String
    Protected Cancel As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetLanguageText()
        If Not Page.IsPostBack Then
            Dim sRoles As String
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("siteroles").Value)
                sRoles = ticket.UserData.ToString & "All Users"
            Else
                sRoles = "All Users"
            End If
            Dim dsd As New System.Data.DataSet
            Dim drd As System.Data.DataRow
            Dim oPublisher As New clsPublisher
            dsd = oPublisher.GetPages(sRoles)
            ddUrl.Items.Add(New System.Web.UI.WebControls.ListItem("n/a", ""))
            For Each drd In dsd.Tables(0).Rows
                If drd("pag_deleted") = False Then
                    ddUrl.Items.Add(New System.Web.UI.WebControls.ListItem(drd("pag_name"), Left(Request.Url.AbsoluteUri, InStr(Request.Url.AbsoluteUri, "Desktop/Modules/Template010/PublisherEditLink.aspx") - 1) & "iCM.aspx?PageId=" & drd("pag_id")))
                End If
            Next
        End If
    End Sub

    Private Sub SetLanguageText()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Publisher")

        Target = "Target:"
        Type = oLang.Find(al, "publisher_linktype")
        Show = oLang.Find(al, "publisher_linkshow")
        Url = oLang.Find(al, "publisher_linkurl")
        Save = oLang.Find(al, "publisher_update")
        Cancel = oLang.Find(al, "publisher_cancel")
    End Sub

    Private Sub ddUrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUrl.SelectedIndexChanged
        urlfield.Text = ddUrl.SelectedValue
    End Sub
End Class
