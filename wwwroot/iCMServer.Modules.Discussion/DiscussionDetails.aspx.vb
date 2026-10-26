Imports System.Web
Imports System.data
Imports System.Collections

Public Class DiscussionDetails
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected PagId As Integer = 0
    Protected ModId As Integer = 0
    Protected DisId As Integer = 0
    Protected Reply As String
    Protected sUser As String
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents lblSubject As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubjectText As System.Web.UI.WebControls.Label
    Protected WithEvents lblCreated As System.Web.UI.WebControls.Label
    Protected WithEvents lblAuthorText As System.Web.UI.WebControls.Label
    Protected WithEvents lblCreatedText As System.Web.UI.WebControls.Label
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFwd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnRev As System.Web.UI.WebControls.ImageButton

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

        If Not (Request.Params("PagId") Is Nothing) Then
            PagId = Int32.Parse(Request.Params("PagId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("DisId") Is Nothing) Then
            DisId = Int32.Parse(Request.Params("DisId"))
        End If

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        Dim oDis As New clsDiscussion
        Dim ds As New DataSet
        ds = oDis.GetThreadMessage(PagId, ModId, DisId)
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Discussion")

        btnFwd.ImageUrl = "Images/fwd.gif"
        btnFwd.AlternateText = Server.HtmlDecode(oLang.Find(al, "discussion_fwd"))
        btnRev.ImageUrl = "Images/rew.gif"
        btnRev.AlternateText = Server.HtmlDecode(oLang.Find(al, "discussion_rew"))
        Reply = Server.HtmlDecode(oLang.Find(al, "discussion_reply"))
        sUser = IIf(Len(Trim(HttpContext.Current.User.Identity.Name)) = 0, Server.HtmlDecode(oLang.Find(al, "discussion_unknown")), HttpContext.Current.User.Identity.Name)

        If Not Page.IsPostBack Then
            If ds.Tables(0).Rows(0)("dis_createdby") = HttpContext.Current.User.Identity.Name Then
                lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "discussion_edit"))
                lblTitle.Visible = True : lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "discussion_subject"))
                txtTitle.Visible = True : txtTitle.Text = ds.Tables(0).Rows(0)("dis_title")
                lblCreated.Visible = True : lblCreated.Text = Server.HtmlDecode(oLang.Find(al, "discussion_message"))
                txtDescription.Visible = True : txtDescription.Text = ds.Tables(0).Rows(0)("dis_body")
                lblSubject.Visible = False
                lblSubjectText.Visible = False
                lblAuthorText.Visible = False
                lblCreatedText.Visible = False
                txtMessage.Visible = False
                btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "discussion_update"))
                btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "discussion_cancel"))
                btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "discussion_deleted"))
                btnUpdate.Visible = True
                btnCancel.Visible = True
                btnDelete.Visible = True
                btnDelete.Attributes.Add("onclick", "confirm('" & Server.HtmlDecode(oLang.Find(al, "discussion_confirm")) & "');")
            Else
                lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "discussion_header"))
                lblTitle.Visible = True : lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "discussion_author"))
                txtTitle.Visible = False
                lblCreated.Visible = True : lblCreated.Text = Server.HtmlDecode(oLang.Find(al, "discussion_created"))
                txtDescription.Visible = False
                lblSubject.Visible = True : lblSubject.Text = Server.HtmlDecode(oLang.Find(al, "discussion_subject"))
                lblSubjectText.Visible = True : lblSubjectText.Text = ds.Tables(0).Rows(0)("dis_title")
                lblAuthorText.Visible = True : lblAuthorText.Text = ds.Tables(0).Rows(0)("dis_createdby")
                lblCreatedText.Visible = True : lblCreatedText.Text = ds.Tables(0).Rows(0)("dis_createddate") & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                txtMessage.Visible = True : txtMessage.Text = ds.Tables(0).Rows(0)("dis_body")
                btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "discussion_cancel"))
                btnUpdate.Visible = False
                btnCancel.Visible = True
                btnDelete.Visible = False
            End If

        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim oDis As New clsDiscussion
        If Not oDis.UpdateThreadMessage(PagId, ModId, DisId, txtTitle.Text, txtDescription.Text, sUser) Then

        End If
        Response.Write("<script>window.opener.location.reload();this.close();</script>")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oDis As New clsDiscussion
        If Not oDis.DeleteThreadMessage(PagId, ModId, DisId) Then

        End If
        Response.Write("<script>window.opener.location.reload();this.close();</script>")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<script>this.close();</script>")
    End Sub

    Private Sub btnFwd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFwd.Click
        Dim oDis As New clsDiscussion
        Dim i As Integer = oDis.GetNextMessage(PagId, ModId, DisId)
        If Not i = 0 Then
            Response.Redirect("DiscussionDetails.aspx?PagId=" & PagId & "&ModId=" & ModId & "&DisId=" & i.ToString)
        Else
            btnFwd.Visible = False
        End If

    End Sub

    Private Sub btnRev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRev.Click
        Dim oDis As New clsDiscussion
        Dim i As Integer = oDis.GetPreviusMessage(PagId, ModId, DisId)
        If Not i = 0 Then
            Response.Redirect("DiscussionDetails.aspx?PagId=" & PagId & "&ModId=" & ModId & "&DisId=" & i.ToString)
        Else
            btnRev.Visible = False
        End If
    End Sub
End Class
