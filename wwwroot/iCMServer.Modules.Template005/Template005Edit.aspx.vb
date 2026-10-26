
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager

Public Class Template005Edit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Image3 As System.Web.UI.WebControls.Image
    Protected WithEvents Browse1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse2 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Browse3 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Header1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Header2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Text2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Header3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Text3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Save As System.Web.UI.WebControls.Button
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Ingress1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Text1 As System.Web.UI.WebControls.TextBox

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
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate005 As New clsTemplate005(ModID, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModID))
            Dim ds As DataSet = oTemplate005.GetTemplate

            Header1.Text = String.Empty
            Ingress1.Text = String.Empty
            Text1.Text = String.Empty
            Image1.Visible = False
            Header2.Text = String.Empty
            Text2.Text = String.Empty
            Image2.Visible = False
            Header3.Text = String.Empty
            Text3.Text = String.Empty
            Image3.Visible = False

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Header1.Text = ds.Tables(0).Rows(0)("tem_header1")
                    Ingress1.Text = ds.Tables(0).Rows(0)("tem_ingress1")
                    Text1.Text = ds.Tables(0).Rows(0)("tem_text1")
                    Header2.Text = ds.Tables(0).Rows(0)("tem_header2")
                    Text2.Text = ds.Tables(0).Rows(0)("tem_text2")
                    Header3.Text = ds.Tables(0).Rows(0)("tem_header3")
                    Text3.Text = ds.Tables(0).Rows(0)("tem_text3")
                End If
            End If

            Try
                Dim Height As Integer = "240"
                Dim Width As Integer = "240"
                Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./BinaryFileCache/" & "Template005_1__" & ModID.ToString & ".png"))
                Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
                Image1.Height = Unit.Pixel(oThumb.GetThumbHeight)
                Image1.Width = Unit.Pixel(oThumb.GetThumbWidth)
                Image1.ImageUrl = "BinaryFileCache/" & "Template005_1__" & ModID.ToString & ".png"
                Image1.Visible = True
            Catch ex As Exception

            End Try
            Try
                Dim Height As Integer = "190"
                Dim Width As Integer = "190"
                Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./BinaryFileCache/" & "Template005_2__" & ModID.ToString & ".png"))
                Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
                Image2.Height = Unit.Pixel(oThumb.GetThumbHeight)
                Image2.Width = Unit.Pixel(oThumb.GetThumbWidth)
                Image2.ImageUrl = "BinaryFileCache/" & "Template005_2__" & ModID.ToString & ".png"
                Image2.Visible = True
            Catch ex As Exception

            End Try
            Try
                Dim Height As Integer = "190"
                Dim Width As Integer = "190"
                Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./BinaryFileCache/" & "Template005_3__" & ModID.ToString & ".png"))
                Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
                Image3.Height = Unit.Pixel(oThumb.GetThumbHeight)
                Image3.Width = Unit.Pixel(oThumb.GetThumbWidth)
                Image3.ImageUrl = "BinaryFileCache/" & "Template005_3__" & ModID.ToString & ".png"
                Image3.Visible = True
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate005 As New clsTemplate005(ModID, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModID))
            oTemplate005.UpdateTemplate(Header1.Text, Ingress1.Text, Text1.Text, Header2.Text, Text2.Text, Header3.Text, Text3.Text)
            Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
            If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template005_1__" & ModID.ToString & ".png", Browse1.PostedFile)
            If Browse2.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template005_2__" & ModID.ToString & ".png", Browse2.PostedFile)
            If Browse3.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template005_3__" & ModID.ToString & ".png", Browse3.PostedFile)
            Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
        Catch ex As Exception

        End Try

    End Sub

End Class
