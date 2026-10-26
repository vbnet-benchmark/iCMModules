
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security

Public Class Template004Edit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblUrl As System.Web.UI.WebControls.Label
    Protected WithEvents ddUrl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtUrl As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblIngress As System.Web.UI.WebControls.Label
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblNavText As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeader As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIngress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtText As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNavText As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddCategories As System.Web.UI.WebControls.DropDownList
    Protected WithEvents PanelNew As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelCategories As System.Web.UI.WebControls.Panel
    Protected WithEvents btnAddMedia As System.Web.UI.WebControls.Button
    Protected WithEvents ddPages As System.Web.UI.WebControls.DropDownList
    Protected WithEvents PanelPage As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSavePages As System.Web.UI.WebControls.Button
    Protected WithEvents lblAddMedia As System.Web.UI.WebControls.Label
    Protected WithEvents lblCategories As System.Web.UI.WebControls.Label
    Protected WithEvents lblPages As System.Web.UI.WebControls.Label
    Protected WithEvents lblDocument As System.Web.UI.WebControls.Label
    Protected WithEvents btnSaveDocument As System.Web.UI.WebControls.Button
    Protected WithEvents PanelDocument As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMedia As System.Web.UI.WebControls.Label
    Protected WithEvents btnSaveMedia As System.Web.UI.WebControls.Button
    Protected WithEvents PanelMedia As System.Web.UI.WebControls.Panel
    Protected WithEvents lblLink As System.Web.UI.WebControls.Label
    Protected WithEvents btnSaveLink As System.Web.UI.WebControls.Button
    Protected WithEvents PanelLink As System.Web.UI.WebControls.Panel
    Protected WithEvents btnBack4 As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack3 As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack2 As System.Web.UI.WebControls.Button
    Protected WithEvents BtnBack1 As System.Web.UI.WebControls.Button
    Protected WithEvents ddMediaFiles As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblRemove As System.Web.UI.WebControls.Label
    Protected WithEvents BtnBack5 As System.Web.UI.WebControls.Button
    Protected WithEvents btnRemove As System.Web.UI.WebControls.Button
    Protected WithEvents PanelRemove As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRemove As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemoveIndex As System.Web.UI.WebControls.TextBox
    Protected WithEvents BtnBack6 As System.Web.UI.WebControls.Button
    Protected WithEvents txtLink As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMedia As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddDocuments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDocIndex As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private PageID As Integer = 0
    Private ModID As Integer = 0
    Private Shared Type As String = String.Empty

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        Call BindData()

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template004")
        BtnBack1.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        btnBack2.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        btnBack3.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        btnBack4.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        BtnBack5.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        BtnBack6.Text = Server.HtmlDecode(oLang.Find(al, "template004_cancel"))
        btnSaveDocument.Text = Server.HtmlDecode(oLang.Find(al, "template004_save"))
        btnSaveLink.Text = Server.HtmlDecode(oLang.Find(al, "template004_save"))
        btnSaveMedia.Text = Server.HtmlDecode(oLang.Find(al, "template004_save"))
        btnSavePages.Text = Server.HtmlDecode(oLang.Find(al, "template004_save"))
        btnSave.Text = Server.HtmlDecode(oLang.Find(al, "template004_save"))
        btnRemove.Text = Server.HtmlDecode(oLang.Find(al, "template004_remove"))
        btnAddMedia.Text = Server.HtmlDecode(oLang.Find(al, "template004_addmedia"))
        lblAddMedia.Text = Server.HtmlDecode(oLang.Find(al, "template004_media"))
        lblCategories.Text = Server.HtmlDecode(oLang.Find(al, "template004_selcat"))
        lblDocument.Text = Server.HtmlDecode(oLang.Find(al, "template004_seldoc"))
        lblHeader.Text = Server.HtmlDecode(oLang.Find(al, "template004_header"))
        lblIngress.Text = Server.HtmlDecode(oLang.Find(al, "template004_ingress"))
        lblLink.Text = Server.HtmlDecode(oLang.Find(al, "template004_typelink"))
        lblMedia.Text = Server.HtmlDecode(oLang.Find(al, "template004_typemedia"))
        lblNavText.Text = Server.HtmlDecode(oLang.Find(al, "template004_navtext"))
        lblPages.Text = Server.HtmlDecode(oLang.Find(al, "template004_select"))
        lblText.Text = Server.HtmlDecode(oLang.Find(al, "template004_text"))
        lblUrl.Text = Server.HtmlDecode(oLang.Find(al, "template004_navurl"))
        lblRemove.Text = Server.HtmlDecode(oLang.Find(al, "template004_removemedia"))

        If Not Page.IsPostBack Then

            ddCategories.Items.Clear()
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_choose")), "default"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_page")), "page"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_word")), "word"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_pdf")), "pdf"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_pic")), "pic"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_movie")), "movie"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_link")), "link"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_sound")), "sound"))
            ddCategories.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "template004_flash")), "flash"))
            ddCategories.SelectedIndex = 0

            ' Prepare the Navigation Link...
            Dim sRoles As String
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("siteroles").Value)
                sRoles = ticket.UserData.ToString & "All Users"
            Else
                sRoles = "All Users"
            End If
            Dim oTemplate004 As New clsTemplate004(ModID, PageID, clsSiteSecurity.HasEditPermissions(ModID))
            Dim dsd As New System.Data.DataSet
            Dim drd As System.Data.DataRow
            dsd = oTemplate004.GetPages(sRoles)
            ddUrl.Items.Add(New ListItem("n/a", ""))
            For Each drd In dsd.Tables(0).Rows
                If CType(drd("pag_deleted"), Boolean) = False Then
                    ddUrl.Items.Add(New ListItem(drd("pag_name"), "iCM.aspx?PageId=" & drd("pag_id")))
                    ddPages.Items.Add(New ListItem(drd("pag_name"), "iCM.aspx?PageId=" & drd("pag_id")))
                End If
            Next
            Dim ds As DataSet = oTemplate004.GetRedirect(ModID, PageID)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    txtUrl.Text = ds.Tables(0).Rows(0)("qui_url")
                    Try
                        If txtUrl.Text.Length > 0 Then
                            For Each drd In dsd.Tables(0).Rows
                                If CType(drd("pag_id"), String) = txtUrl.Text.Substring(txtUrl.Text.LastIndexOf("=") + 1) Then
                                    ddUrl.SelectedValue = "iCM.aspx?PageId=" & drd("pag_id")
                                End If
                            Next
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If

            ' Prepare the Information text...
            Dim dst As DataSet = oTemplate004.GetTemplate
            If dst.Tables.Count > 0 Then
                If dst.Tables(0).Rows.Count > 0 Then
                    txtHeader.Text = dst.Tables(0).Rows(0)("tem_header")
                    txtIngress.Text = dst.Tables(0).Rows(0)("tem_ingress")
                    txtText.Text = dst.Tables(0).Rows(0)("tem_text")
                    txtNavText.Text = dst.Tables(0).Rows(0)("tem_navtext")
                    Call LoadMediaFiles(dst.Tables(0).Rows(0))
                Else
                    oTemplate004.UpdateTemplate("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                    Call LoadMediaFiles(oTemplate004.GetTemplate.Tables(0).Rows(0))
                End If
            Else
                oTemplate004.UpdateTemplate("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                Call LoadMediaFiles(oTemplate004.GetTemplate.Tables(0).Rows(0))
            End If

            ' Prepare the Media Fields...
            PanelNew.Visible = True
            PanelCategories.Visible = False
            PanelPage.Visible = False
            PanelDocument.Visible = False
            PanelMedia.Visible = False
            PanelLink.Visible = False
            PanelRemove.Visible = False

            ' Prepare the Documents...
            Dim dsDoc As New System.Data.DataSet
            dsDoc = oTemplate004.GetDocuments()
            ddDocuments.Items.Clear()
            ddDocuments.Items.Add(New ListItem("n/a", ""))
            For Each dr As DataRow In dsDoc.Tables(0).Rows
                ddDocuments.Items.Add(New ListItem(dr("doc_name"), "Desktop/Modules/Documents/DocumentsStream.aspx?ModId=" & dr("mod_id") & "&CatId=" & dr("cat_id") & "&DocId=" & dr("doc_id")))
            Next
        End If

    End Sub

    Private Sub InitAll()
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        Call LoadMediaFiles(oTemplate004.GetTemplate.Tables(0).Rows(0))
        ddMediaFiles.SelectedIndex = 0
        ddCategories.SelectedIndex = 0
        ddPages.SelectedIndex = 0
        PanelNew.Visible = True
        PanelCategories.Visible = False
        PanelPage.Visible = False
        PanelDocument.Visible = False
        PanelMedia.Visible = False
        PanelLink.Visible = False
        PanelRemove.Visible = False
        txtDocIndex.Text = ""
        txtMedia.Text = ""
        txtLink.Text = ""
        txtRemove.Text = ""
        txtRemoveIndex.Text = ""
    End Sub

    Private Sub LoadMediaFiles(ByVal dr As DataRow)
        ddMediaFiles.Items.Clear()
        ddMediaFiles.Items.Add(New ListItem("n/a", "0"))
        Dim i As Integer = 0
        If CType(dr("tem_medialink1"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink1"), String).Substring(0, CType(dr("tem_medialink1"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink1"), String).Substring(CType(dr("tem_medialink1"), String).IndexOf(";") + 1) & ")", "1"))
        If CType(dr("tem_medialink2"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink2"), String).Substring(0, CType(dr("tem_medialink2"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink2"), String).Substring(CType(dr("tem_medialink2"), String).IndexOf(";") + 1) & ")", "2"))
        If CType(dr("tem_medialink3"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink3"), String).Substring(0, CType(dr("tem_medialink3"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink3"), String).Substring(CType(dr("tem_medialink3"), String).IndexOf(";") + 1) & ")", "3"))
        If CType(dr("tem_medialink4"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink4"), String).Substring(0, CType(dr("tem_medialink4"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink4"), String).Substring(CType(dr("tem_medialink4"), String).IndexOf(";") + 1) & ")", "4"))
        If CType(dr("tem_medialink5"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink5"), String).Substring(0, CType(dr("tem_medialink5"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink5"), String).Substring(CType(dr("tem_medialink5"), String).IndexOf(";") + 1) & ")", "5"))
        If CType(dr("tem_medialink6"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink6"), String).Substring(0, CType(dr("tem_medialink6"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink6"), String).Substring(CType(dr("tem_medialink6"), String).IndexOf(";") + 1) & ")", "6"))
        If CType(dr("tem_medialink7"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink7"), String).Substring(0, CType(dr("tem_medialink7"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink7"), String).Substring(CType(dr("tem_medialink7"), String).IndexOf(";") + 1) & ")", "7"))
        If CType(dr("tem_medialink8"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink8"), String).Substring(0, CType(dr("tem_medialink8"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink8"), String).Substring(CType(dr("tem_medialink8"), String).IndexOf(";") + 1) & ")", "8"))
        If CType(dr("tem_medialink9"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink9"), String).Substring(0, CType(dr("tem_medialink9"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink9"), String).Substring(CType(dr("tem_medialink9"), String).IndexOf(";") + 1) & ")", "9"))
        If CType(dr("tem_medialink10"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink10"), String).Substring(0, CType(dr("tem_medialink10"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink10"), String).Substring(CType(dr("tem_medialink10"), String).IndexOf(";") + 1) & ")", "10"))
        'If CType(dr("tem_medialink11"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink11"), String).Substring(0, CType(dr("tem_medialink11"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink11"), String).Substring(CType(dr("tem_medialink11"), String).IndexOf(";") + 1) & ")", "11"))
        'If CType(dr("tem_medialink12"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink12"), String).Substring(0, CType(dr("tem_medialink12"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink12"), String).Substring(CType(dr("tem_medialink12"), String).IndexOf(";") + 1) & ")", "12"))
        'If CType(dr("tem_medialink13"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink13"), String).Substring(0, CType(dr("tem_medialink13"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink13"), String).Substring(CType(dr("tem_medialink13"), String).IndexOf(";") + 1) & ")", "13"))
        'If CType(dr("tem_medialink14"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink14"), String).Substring(0, CType(dr("tem_medialink14"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink14"), String).Substring(CType(dr("tem_medialink14"), String).IndexOf(";") + 1) & ")", "14"))
        'If CType(dr("tem_medialink15"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink15"), String).Substring(0, CType(dr("tem_medialink15"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink15"), String).Substring(CType(dr("tem_medialink15"), String).IndexOf(";") + 1) & ")", "15"))
        'If CType(dr("tem_medialink16"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink16"), String).Substring(0, CType(dr("tem_medialink16"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink16"), String).Substring(CType(dr("tem_medialink16"), String).IndexOf(";") + 1) & ")", "16"))
        'If CType(dr("tem_medialink17"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink17"), String).Substring(0, CType(dr("tem_medialink17"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink17"), String).Substring(CType(dr("tem_medialink17"), String).IndexOf(";") + 1) & ")", "17"))
        'If CType(dr("tem_medialink18"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink18"), String).Substring(0, CType(dr("tem_medialink18"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink18"), String).Substring(CType(dr("tem_medialink18"), String).IndexOf(";") + 1) & ")", "18"))
        'If CType(dr("tem_medialink19"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink19"), String).Substring(0, CType(dr("tem_medialink19"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink19"), String).Substring(CType(dr("tem_medialink19"), String).IndexOf(";") + 1) & ")", "19"))
        'If CType(dr("tem_medialink20"), String).Length > 0 Then i += 1 : ddMediaFiles.Items.Add(New ListItem("Media " & i.ToString & " (" & CType(dr("tem_medialink20"), String).Substring(0, CType(dr("tem_medialink20"), String).IndexOf(";")) & ") (" & CType(dr("tem_medialink20"), String).Substring(CType(dr("tem_medialink20"), String).IndexOf(";") + 1) & ")", "20"))
        If i = 10 Then btnAddMedia.Enabled = False
    End Sub

    Private Sub ddUrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUrl.SelectedIndexChanged
        txtUrl.Text = ddUrl.SelectedValue
    End Sub

    Private Sub btnAddMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMedia.Click
        PanelNew.Visible = False
        PanelCategories.Visible = True
        PanelPage.Visible = False
        PanelDocument.Visible = False
        PanelMedia.Visible = False
        PanelLink.Visible = False
        PanelRemove.Visible = False
    End Sub

    Private Sub ddCategories_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddCategories.SelectedIndexChanged
        If Not ddCategories.SelectedIndex = 0 Then
            PanelNew.Visible = False
            PanelCategories.Visible = False
            PanelPage.Visible = False
            PanelDocument.Visible = False
            PanelMedia.Visible = False
            PanelLink.Visible = False
            PanelRemove.Visible = False
            Select Case ddCategories.SelectedValue
                Case "default"
                Case "page" : PanelPage.Visible = True
                Case "word" : PanelDocument.Visible = True : Type = "word"
                Case "pdf" : PanelDocument.Visible = True : Type = "pdf"
                Case "pic" : PanelDocument.Visible = True : Type = "pic"
                Case "movie" : PanelMedia.Visible = True : Type = "movie"
                Case "link" : PanelLink.Visible = True : Type = "link"
                Case "sound" : PanelMedia.Visible = True : Type = "sound"
                Case "flash" : PanelDocument.Visible = True : Type = "flash"
            End Select
        End If
    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack1.Click, btnBack2.Click, btnBack3.Click, btnBack4.Click, BtnBack5.Click, BtnBack6.Click
        ddCategories.SelectedIndex = -1
        Response.Write("<script language=""javascript"">window.history.go(-2)</script>")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Save the Navigation Link...
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        If Not oTemplate004.UpdateQuicklink(ModID, PageID, txtUrl.Text) Then

        End If

        ' Save the Text information...
        If Not oTemplate004.UpdateTemplateText(txtHeader.Text, txtIngress.Text, txtText.Text, txtNavText.Text) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
    End Sub

    Private Sub btnSavePages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePages.Click
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        oTemplate004.AddTemplateMediaFile("page;" & ddPages.SelectedValue)
        Call InitAll()
    End Sub

    Private Sub ddMediaFiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddMediaFiles.SelectedIndexChanged
        If Not ddMediaFiles.SelectedIndex = 0 Then
            PanelNew.Visible = False
            PanelCategories.Visible = False
            PanelPage.Visible = False
            PanelDocument.Visible = False
            PanelMedia.Visible = False
            PanelLink.Visible = False
            PanelRemove.Visible = True
            txtRemove.Text = ddMediaFiles.Items(ddMediaFiles.SelectedIndex).Text
            txtRemoveIndex.Text = ddMediaFiles.SelectedValue
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        oTemplate004.RemoveTemplateMediaFile(txtRemoveIndex.Text)
        Call LoadMediaFiles(oTemplate004.GetTemplate.Tables(0).Rows(0))
        ddMediaFiles.SelectedIndex = -1
        ddCategories.SelectedIndex = -1
        ddPages.SelectedIndex = -1
        PanelNew.Visible = True
        PanelCategories.Visible = False
        PanelPage.Visible = False
        PanelDocument.Visible = False
        PanelMedia.Visible = False
        PanelLink.Visible = False
        PanelRemove.Visible = False
    End Sub

    Private Sub btnSaveLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveLink.Click
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        oTemplate004.AddTemplateMediaFile(Type & ";" & Server.HtmlEncode(txtLink.Text))
        Call InitAll()
    End Sub

    Private Sub btnSaveDocument_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDocument.Click
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        oTemplate004.AddTemplateMediaFile(Type & ";" & Server.HtmlEncode(ddDocuments.SelectedValue))
        Call InitAll()
    End Sub

    Private Sub btnSaveMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveMedia.Click
        Dim oTemplate004 As New clsTemplate004(ModID, PageID, False)
        oTemplate004.AddTemplateMediaFile(Type & ";" & Server.HtmlEncode(txtMedia.Text))
        Call InitAll()
    End Sub
End Class
