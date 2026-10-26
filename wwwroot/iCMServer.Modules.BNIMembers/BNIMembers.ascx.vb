Imports System.Web
Imports System.Data
Imports System.Collections

Public Class BNIMembers : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents imgLogga As System.Web.UI.WebControls.Image
    Protected WithEvents lnkLogga As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lnkNewPic As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtMemberText As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBoxSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPhone As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPhone As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkMail As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Web As System.Web.UI.WebControls.Label
    Protected WithEvents txtWeb As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkWeb As System.Web.UI.WebControls.HyperLink
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblSeek As System.Web.UI.WebControls.Label
    Protected WithEvents lName As System.Web.UI.WebControls.Label
    Protected WithEvents lPhone As System.Web.UI.WebControls.Label
    Protected WithEvents lMail As System.Web.UI.WebControls.Label
    Protected WithEvents lWeb As System.Web.UI.WebControls.Label
    Protected WithEvents imgMe As System.Web.UI.WebControls.Image
    Protected WithEvents lStreet As System.Web.UI.WebControls.Label
    Protected WithEvents lPcode As System.Web.UI.WebControls.Label
    Protected WithEvents lcity As System.Web.UI.WebControls.Label
    Protected WithEvents txtStreet As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCity As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblStreet As System.Web.UI.WebControls.Label
    Protected WithEvents lblPcode As System.Web.UI.WebControls.Label
    Protected WithEvents lblCity As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private PagId As Integer = 0
    Private ModId As Integer = 0
    Private BmeId As Integer = 0
    Private IsAuthorized As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Dim oBNI As New clsBNIMembers
        PagId = oSite.ActivePage.PageId
        ModId = ModuleId
        BmeId = oBNI.Exists(PagId, ModId)
        Dim oSit As New clsSiteSecurity
        If oSit.HasEditPermissions(ModId) Then
            IsAuthorized = True
        End If
        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()

        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.BNIMembers")

        lnkLogga.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_logo"))
        lblSeek.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_hook"))
        lnkNewPic.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_me"))
        lName.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_name"))
        lPhone.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_phone"))
        lMail.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_mail"))
        lWeb.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_web"))
        lStreet.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_street"))
        lPcode.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_pcode"))
        lcity.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_city"))

        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "bnimember_save"))

        lnkLogga.NavigateUrl = "~/Desktop/Modules/BNIMembers/BNIMembersUploadLogo.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId
        lnkNewPic.NavigateUrl = "~/Desktop/Modules/BNIMembers/BNIMembersUploadMe.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId

        If IsAuthorized Then
            lblName.Visible = False
            lblPhone.Visible = False
            lnkMail.Visible = False
            lnkWeb.Visible = False
            lblStreet.Visible = False
            lblPcode.Visible = False
            lblCity.Visible = False
            txtStreet.Visible = True
            txtPcode.Visible = True
            txtCity.Visible = True
            txtName.Visible = True
            txtPhone.Visible = True
            txtMail.Visible = True
            txtWeb.Visible = True
            lnkLogga.Visible = True
            lnkNewPic.Visible = True
            btnSave.Visible = True
            imgLogga.Visible = False
            imgMe.Visible = False
            txtMemberText.ReadOnly = False
            txtBoxSearch.ReadOnly = False
            If Not BmeId = 0 Then
                Dim oBNI As New clsBNIMembers
                Dim dr As DataRow
                dr = oBNI.GetMember(PagId, ModId, BmeId).Tables(0).Rows(0)
                txtName.Text = IIf(IsDBNull(dr("bme_name")), "", dr("bme_name"))
                txtPhone.Text = IIf(IsDBNull(dr("bme_phone")), "", dr("bme_phone"))
                txtMail.Text = IIf(IsDBNull(dr("bme_mail")), "", dr("bme_mail"))
                txtWeb.Text = IIf(IsDBNull(dr("bme_web")), "", dr("bme_web"))
                txtStreet.Text = IIf(IsDBNull(dr("bme_street")), "", dr("bme_street"))
                txtPcode.Text = IIf(IsDBNull(dr("bme_pcode")), "", dr("bme_pcode"))
                txtCity.Text = IIf(IsDBNull(dr("bme_city")), "", dr("bme_city"))
                txtMemberText.Text = IIf(IsDBNull(dr("bme_text")), "", dr("bme_text"))
                txtBoxSearch.Text = IIf(IsDBNull(dr("bme_hook")), "", dr("bme_hook"))
                If IIf(IsDBNull(dr("bme_logocontentsize")), 0, dr("bme_logocontentsize")) > 0 Then
                    imgLogga.ImageUrl = "~/Desktop/Modules/BNIMembers/BNIMembersImageStream.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId & "&Type=Logo"
                    imgLogga.Visible = True
                Else
                    imgLogga.Visible = False
                End If

                If IIf(IsDBNull(dr("bme_mecontentsize")), 0, dr("bme_mecontentsize")) > 0 Then
                    imgMe.ImageUrl = "~/Desktop/Modules/BNIMembers/BNIMembersImageStream.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId & "&Type=Me"
                    imgMe.Visible = True
                Else
                    imgMe.Visible = False
                End If
            End If
        Else
            lblName.Visible = True
            lblPhone.Visible = True
            lnkMail.Visible = True
            lnkWeb.Visible = True
            txtName.Visible = False
            txtPhone.Visible = False
            txtMail.Visible = False
            txtWeb.Visible = False
            lblStreet.Visible = True
            lblPcode.Visible = True
            lblCity.Visible = True
            txtStreet.Visible = False
            txtPcode.Visible = False
            txtCity.Visible = False
            lnkLogga.Visible = False
            lnkNewPic.Visible = False
            btnSave.Visible = False
            imgLogga.Visible = False
            imgMe.Visible = False
            If Not BmeId = 0 Then
                Dim oBNI As New clsBNIMembers
                Dim dr As DataRow
                dr = oBNI.GetMember(PagId, ModId, BmeId).Tables(0).Rows(0)
                lblName.Text = IIf(IsDBNull(dr("bme_name")), "", dr("bme_name"))
                lblPhone.Text = IIf(IsDBNull(dr("bme_phone")), "", dr("bme_phone"))
                lnkMail.Text = IIf(IsDBNull(dr("bme_mail")), "", dr("bme_mail"))
                lnkMail.NavigateUrl = "mailto:" & IIf(IsDBNull(dr("bme_mail")), "", dr("bme_mail"))
                lnkWeb.Text = IIf(IsDBNull(dr("bme_web")), "", dr("bme_web"))
                lnkWeb.NavigateUrl = "http://" & IIf(IsDBNull(dr("bme_web")), "", dr("bme_web")) : lnkWeb.Target = "_new"
                lblStreet.Text = IIf(IsDBNull(dr("bme_street")), "", dr("bme_street"))
                lblPcode.Text = IIf(IsDBNull(dr("bme_pcode")), "", dr("bme_pcode"))
                lblCity.Text = IIf(IsDBNull(dr("bme_city")), "", dr("bme_city"))
                txtMemberText.Text = IIf(IsDBNull(dr("bme_text")), "", dr("bme_text"))
                txtBoxSearch.Text = IIf(IsDBNull(dr("bme_hook")), "", dr("bme_hook"))
                If IIf(IsDBNull(dr("bme_logocontentsize")), 0, dr("bme_logocontentsize")) > 0 Then
                    imgLogga.ImageUrl = "~/Desktop/Modules/BNIMembers/BNIMembersImageStream.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId & "&Type=Logo"
                    imgLogga.Visible = True
                Else
                    imgLogga.Visible = False
                End If

                If IIf(IsDBNull(dr("bme_mecontentsize")), 0, dr("bme_mecontentsize")) > 0 Then
                    imgMe.ImageUrl = "~/Desktop/Modules/BNIMembers/BNIMembersImageStream.aspx?PagId=" & PagId & "&ModId=" & ModId & "&BmeId=" & BmeId & "&Type=Me"
                    imgMe.Visible = True
                Else
                    imgMe.Visible = False
                End If
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim oBNI As New clsBNIMembers
        If Not oBNI.UpdateText(PagId, ModId, BmeId, Replace(txtName.Text, "'", "´"), Replace(txtPhone.Text, "'", "´"), Replace(txtMail.Text, "'", "´"), Replace(txtWeb.Text, "'", "´"), Replace(txtStreet.Text, "'", "´"), Replace(txtPcode.Text, "'", "´"), Replace(txtCity.Text, "'", "´"), Replace(txtMemberText.Text, "'", "´"), Replace(txtBoxSearch.Text, "'", "´"), HttpContext.Current.User.Identity.Name) Then

        End If
        Response.Redirect("~/iCM.aspx?PageId=" & PagId)
    End Sub

End Class
