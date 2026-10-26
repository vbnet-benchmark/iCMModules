Imports System.data
Public Class iFrameEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents lblUrl As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblWidth As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUrl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeight As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWidth As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTarget As System.Web.UI.WebControls.Label
    Protected WithEvents ddTarget As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.iFrame")

        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "iframe_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "iframe_title"))
        lblDescription.Text = Server.HtmlDecode(oLang.Find(al, "iframe_description"))
        lblUrl.Text = Server.HtmlDecode(oLang.Find(al, "iframe_url"))
        lblTarget.Text = "Target:"
        lblHeight.Text = Server.HtmlDecode(oLang.Find(al, "iframe_height"))
        lblWidth.Text = Server.HtmlDecode(oLang.Find(al, "iframe_width"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "iframe_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "iframe_cancel"))

        Dim bExists As Boolean = False
        Dim oiFrame As New clsiFrame
        Dim ds As New DataSet
        ds = oiFrame.GetiFrame(ModId, PagId)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                bExists = True
            End If
        End If

        If Not bExists Then
            txtTitle.Text = ""
            txtDescription.Text = ""
            txtUrl.Text = ""
            txtHeight.Text = "600px"
            txtWidth.Text = "100%"
        Else
            txtTitle.Text = ds.Tables(0).Rows(0)("ifr_title")
            txtDescription.Text = ds.Tables(0).Rows(0)("ifr_description")
            txtUrl.Text = ds.Tables(0).Rows(0)("ifr_url")
            ddTarget.SelectedValue = ds.Tables(0).Rows(0)("ifr_target")
            txtHeight.Text = ds.Tables(0).Rows(0)("ifr_height")
            txtWidth.Text = ds.Tables(0).Rows(0)("ifr_width")
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim oiFrame As New clsiFrame
        If Not oiFrame.UpdateiFrame(ModId, PagId, txtTitle.Text, txtDescription.Text, txtUrl.Text, ddTarget.SelectedValue, txtWidth.Text, txtHeight.Text) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

End Class
