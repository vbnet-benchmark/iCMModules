Public Class NoticeEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents lblLink As System.Web.UI.WebControls.Label
    Protected WithEvents lblShowDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblHideDate As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLink As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShowDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHideDate As System.Web.UI.WebControls.TextBox
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

    Private EveId As Integer = 0
    Private ModId As Integer = 0
    Private PagId As Integer = 0
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("EveId") Is Nothing) Then
            EveId = Int32.Parse(Request.Params("EveId"))
        End If

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
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Events")

        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "events_header"))
        lblTitle.Text = Server.HtmlDecode(oLang.Find(al, "events_title"))
        lblDescription.Text = Server.HtmlDecode(oLang.Find(al, "events_description"))
        lblLink.Text = Server.HtmlDecode(oLang.Find(al, "events_link"))
        lblTarget.Text = "Target:"
        lblShowDate.Text = Server.HtmlDecode(oLang.Find(al, "events_showdate"))
        lblHideDate.Text = Server.HtmlDecode(oLang.Find(al, "events_hidedate"))
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "events_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "events_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "events_delete"))

        btnDelete.Attributes.Add("onclick", "confirm('" & Server.HtmlDecode(oLang.Find(al, "events_confirm")) & "');")

        If EveId = 0 Then
            ViewState("EventUpdate") = False
            txtTitle.Text = ""
            txtDescription.Text = ""
            txtLink.Text = ""
            txtShowDate.Text = Now.ToShortDateString
            txtHideDate.Text = Now.AddDays(6).ToShortDateString
        Else
            ViewState("EventUpdate") = True
            Dim oEvent As New clsNotice
            Dim ds As New System.data.DataSet
            ds = oEvent.GetEvent(ModId, EveId, PagId)
            txtTitle.Text = ds.Tables(0).Rows(0)("eve_title")
            txtDescription.Text = ds.Tables(0).Rows(0)("eve_description")
            If InStr(ds.Tables(0).Rows(0)("eve_link"), "|") > 0 Then
                Dim aTemp() As String = Split(ds.Tables(0).Rows(0)("eve_link"), "|")
                txtLink.Text = aTemp(0)
                If Not IsNothing(aTemp(1)) Then
                    If Len(aTemp(1)) > 0 Then
                        If LCase(aTemp(1)) = "_blank" Then
                            ddTarget.SelectedIndex = 0
                        Else
                            ddTarget.SelectedIndex = 1
                        End If
                    Else
                        ddTarget.SelectedIndex = 0
                    End If
                Else
                    ddTarget.SelectedIndex = 0
                End If

            Else
                txtLink.Text = ds.Tables(0).Rows(0)("eve_link")
                ddTarget.SelectedIndex = 0
            End If

            txtShowDate.Text = ds.Tables(0).Rows(0)("eve_showdate")
            txtHideDate.Text = ds.Tables(0).Rows(0)("eve_hidedate")
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If IsDate(txtShowDate.Text) And IsDate(txtHideDate.Text) Then
            If ViewState("EventUpdate") = True Then
                Dim oEvent As New clsNotice
                If Trim(txtTitle.Text) = "" Then txtTitle.Text = "n/a"
                If Not oEvent.UpdateEvent(ModId, EveId, PagId, txtTitle.Text, txtDescription.Text, txtLink.Text, ddTarget.SelectedValue, txtShowDate.Text, txtHideDate.Text) Then

                End If
                Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
            ElseIf ViewState("EventUpdate") = False Then
                Dim oEvent As New clsNotice
                If Trim(txtTitle.Text) = "" Then txtTitle.Text = "n/a"
                If Not oEvent.AddEvent(ModId, PagId, txtTitle.Text, txtDescription.Text, txtLink.Text, ddTarget.SelectedValue, txtShowDate.Text, txtHideDate.Text) Then

                End If
                Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ViewState("EventUpdate") = True Then
            Dim oEvent As New clsNotice
            If Not oEvent.DeleteEvent(ModId, EveId, PagId) Then

            End If
            Response.Redirect("~/icm.aspx?PageId=" & PagId & "&ExpId=" & ModId)
        End If
    End Sub
End Class
