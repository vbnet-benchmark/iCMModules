
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager

Public Class Template008Edit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Image3 As System.Web.UI.WebControls.Image
    Protected WithEvents Image7 As System.Web.UI.WebControls.Image
    Protected WithEvents Image8 As System.Web.UI.WebControls.Image
    Protected WithEvents Image9 As System.Web.UI.WebControls.Image
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Image4 As System.Web.UI.WebControls.Image
    Protected WithEvents Image6 As System.Web.UI.WebControls.Image
    Protected WithEvents Browse1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse2 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse3 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse4 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse6 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse7 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse8 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse9 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents TextLabel As System.Web.UI.WebControls.TextBox
    Protected WithEvents Image5 As System.Web.UI.WebControls.Image
    Protected WithEvents Browse5 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents TextBox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents News As System.Web.UI.WebControls.Label
    Protected WithEvents PopupUrl As System.Web.UI.WebControls.Label
    Protected WithEvents PopupOn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents PopupUrlText As System.Web.UI.WebControls.TextBox
    Protected WithEvents PopupImage As System.Web.UI.WebControls.Image
    Protected WithEvents PopupBrowse As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template008")
        Button1.Text = Server.HtmlDecode(oLang.Find(al, "Template008_save"))
        Label10.Text = Server.HtmlDecode(oLang.Find(al, "Template008_header"))
        News.Text = Server.HtmlDecode(oLang.Find(al, "Template008_news"))
        PopupOn.Text = Server.HtmlDecode(oLang.Find(al, "Template008_popupon"))
        PopupUrl.Text = Server.HtmlDecode(oLang.Find(al, "Template008_popupurl"))

        Image1.ImageUrl = "BinaryFileCache/" & "Template008_1__" & ModID.ToString
        Image2.ImageUrl = "BinaryFileCache/" & "Template008_2__" & ModID.ToString
        Image3.ImageUrl = "BinaryFileCache/" & "Template008_3__" & ModID.ToString
        Image4.ImageUrl = "BinaryFileCache/" & "Template008_4__" & ModID.ToString
        Image5.ImageUrl = "BinaryFileCache/" & "Template008_5__" & ModID.ToString
        Image6.ImageUrl = "BinaryFileCache/" & "Template008_6__" & ModID.ToString
        Image7.ImageUrl = "BinaryFileCache/" & "Template008_7__" & ModID.ToString
        Image8.ImageUrl = "BinaryFileCache/" & "Template008_8__" & ModID.ToString
        Image9.ImageUrl = "BinaryFileCache/" & "Template008_9__" & ModID.ToString

        Dim oTemplate008 As New clsTemplate008(ModID, PageID, clsSiteSecurity.HasEditPermissions(ModID))
        Dim ds As DataSet = oTemplate008.GetTemplate
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                TextBox1.Text = ds.Tables(0).Rows(0)("tem_tooltip1")
                Textbox2.Text = ds.Tables(0).Rows(0)("tem_tooltip2")
                Textbox3.Text = ds.Tables(0).Rows(0)("tem_tooltip3")
                Textbox4.Text = ds.Tables(0).Rows(0)("tem_tooltip4")
                Textbox5.Text = ds.Tables(0).Rows(0)("tem_tooltip5")
                Textbox6.Text = ds.Tables(0).Rows(0)("tem_tooltip6")
                Textbox7.Text = ds.Tables(0).Rows(0)("tem_tooltip7")
                Textbox8.Text = ds.Tables(0).Rows(0)("tem_tooltip8")
                Textbox9.Text = ds.Tables(0).Rows(0)("tem_tooltip9")
                TextLabel.Text = ds.Tables(0).Rows(0)("tem_text")
                PopupUrlText.Text = ds.Tables(0).Rows(0)("tem_popupurl")
                If CType(ds.Tables(0).Rows(0)("tem_popupon"), Integer) = 0 Then
                    PopupOn.Checked = False
                    Panel1.Visible = False
                Else
                    PopupOn.Checked = True
                    PopupImage.ImageUrl = "BinaryFileCache/" & "Template008_10__" & ModID.ToString
                    Panel1.Visible = True
                End If
            End If
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oTemplate008 As New clsTemplate008(ModID, PageID, clsSiteSecurity.HasEditPermissions(ModID))
        Try
            If Not oTemplate008.UpdateTemplate(TextBox1.Text, Textbox2.Text, Textbox3.Text, Textbox4.Text, TextBox5.Text, Textbox6.Text, Textbox7.Text, Textbox8.Text, Textbox9.Text, TextLabel.Text, PopupOn.Checked, PopupUrlText.Text) Then

            End If
        Catch ex As Exception
            If Not oTemplate008.UpdateTemplate(TextBox1.Text, Textbox2.Text, Textbox3.Text, Textbox4.Text, TextBox5.Text, Textbox6.Text, Textbox7.Text, Textbox8.Text, Textbox9.Text, TextLabel.Text, False, "") Then

            End If
        End Try
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
        If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_1__" & ModID.ToString, Browse1.PostedFile)
        If Browse2.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_2__" & ModID.ToString, Browse2.PostedFile)
        If Browse3.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_3__" & ModID.ToString, Browse3.PostedFile)
        If Browse4.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_4__" & ModID.ToString, Browse4.PostedFile)
        If Browse5.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_5__" & ModID.ToString, Browse5.PostedFile)
        If Browse6.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_6__" & ModID.ToString, Browse6.PostedFile)
        If Browse7.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_7__" & ModID.ToString, Browse7.PostedFile)
        If Browse8.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_8__" & ModID.ToString, Browse8.PostedFile)
        If Browse9.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_9__" & ModID.ToString, Browse9.PostedFile)
        Try
            If PopupBrowse.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template008_10__" & ModID.ToString, PopupBrowse.PostedFile)
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(Server.MapPath("BinaryFileCache/" & "Template008_11__" & ModID.ToString))
            sw.WriteLine("<html><body style=""cursor:hand"" bottomMargin=""0"" leftMargin=""0"" topMargin=""0"" rightMargin=""0"" marginheight=""0"" marginwidth=""0"" onclick=""window.open('" & PopupUrlText.Text & "');window.close()""><img src=""" & Request.FilePath.Substring(0, Request.FilePath.LastIndexOf("/")) & "/BinaryFileCache/" & "Template008_10__" & ModID.ToString & """></body></html>")
            sw.Close()
        Catch ex As Exception
            'Response.Write(ex)
            'Response.End()
        End Try
        Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
    End Sub

    Private Sub PopupOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopupOn.CheckedChanged
        If PopupOn.Checked Then
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oLang As New clsLanguageText
            Dim al As New ArrayList
            al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template008")
            PopupOn.Text = Server.HtmlDecode(oLang.Find(al, "Template008_popupon"))
            PopupUrl.Text = Server.HtmlDecode(oLang.Find(al, "Template008_popupurl"))
            PopupImage.ImageUrl = "BinaryFileCache/" & "Template008_10__" & ModID.ToString
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub
End Class
