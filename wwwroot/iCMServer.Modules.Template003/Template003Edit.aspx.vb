
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager

Public Class Template003Edit
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
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template003")
        Button1.Text = Server.HtmlDecode(oLang.Find(al, "template003_save"))
        Label10.Text = Server.HtmlDecode(oLang.Find(al, "template003_header"))

        Image1.ImageUrl = "BinaryFileCache/" & "Template003_1__" & ModID.ToString
        Image2.ImageUrl = "BinaryFileCache/" & "Template003_2__" & ModID.ToString
        Image3.ImageUrl = "BinaryFileCache/" & "Template003_3__" & ModID.ToString
        Image4.ImageUrl = "BinaryFileCache/" & "Template003_4__" & ModID.ToString
        Image6.ImageUrl = "BinaryFileCache/" & "Template003_6__" & ModID.ToString
        Image7.ImageUrl = "BinaryFileCache/" & "Template003_7__" & ModID.ToString
        Image8.ImageUrl = "BinaryFileCache/" & "Template003_8__" & ModID.ToString
        Image9.ImageUrl = "BinaryFileCache/" & "Template003_9__" & ModID.ToString

        Dim oTemplate003 As New clsTemplate003(ModID, PageID, clsSiteSecurity.HasEditPermissions(ModID))
        Dim ds As DataSet = oTemplate003.GetTemplate
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                TextBox1.Text = ds.Tables(0).Rows(0)("tem_tooltip1")
                Textbox2.Text = ds.Tables(0).Rows(0)("tem_tooltip2")
                Textbox3.Text = ds.Tables(0).Rows(0)("tem_tooltip3")
                Textbox4.Text = ds.Tables(0).Rows(0)("tem_tooltip4")
                Textbox6.Text = ds.Tables(0).Rows(0)("tem_tooltip6")
                Textbox7.Text = ds.Tables(0).Rows(0)("tem_tooltip7")
                Textbox8.Text = ds.Tables(0).Rows(0)("tem_tooltip8")
                Textbox9.Text = ds.Tables(0).Rows(0)("tem_tooltip9")
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oTemplate003 As New clsTemplate003(ModID, PageID, clsSiteSecurity.HasEditPermissions(ModID))
        If Not oTemplate003.UpdateTemplate(TextBox1.Text, Textbox2.Text, Textbox3.Text, Textbox4.Text, "not in use", Textbox6.Text, Textbox7.Text, Textbox8.Text, Textbox9.Text) Then

        End If
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
        If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_1__" & ModID.ToString, Browse1.PostedFile)
        If Browse2.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_2__" & ModID.ToString, Browse2.PostedFile)
        If Browse3.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_3__" & ModID.ToString, Browse3.PostedFile)
        If Browse4.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_4__" & ModID.ToString, Browse4.PostedFile)
        If Browse6.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_6__" & ModID.ToString, Browse6.PostedFile)
        If Browse7.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_7__" & ModID.ToString, Browse7.PostedFile)
        If Browse8.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_8__" & ModID.ToString, Browse8.PostedFile)
        If Browse9.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template003_9__" & ModID.ToString, Browse9.PostedFile)
        Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
    End Sub

End Class
