Imports System.Globalization
Imports System.data
Imports System.Web
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports iConsulting.iCMServer.iCDataManager

Public Class BBEdit
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Browse1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Text1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Save As System.Web.UI.WebControls.Button
    Protected WithEvents ddlWeek As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label

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
        Dim selectedWeek As Integer
        Dim cal As New System.Globalization.GregorianCalendar
        Dim dd As Date = Now
        Dim FirstDay As New System.Globalization.CalendarWeekRule

        If Not (Request.Params("PageID") Is Nothing) Then
            PageID = Int32.Parse(Request.Params("PageID"))
        End If

        If Not (Request.Params("ModID") Is Nothing) Then
            ModID = Int32.Parse(Request.Params("ModID"))
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

        Dim i As Integer
        For i = 1 To 53
            ddlWeek.Items.Add(New ListItem(i, i))
        Next

        If Not Page.IsPostBack Then
            cal = New GregorianCalendar
            selectedWeek = cal.GetWeekOfYear(dd, FirstDay, System.DayOfWeek.Monday)
            ddlWeek.SelectedIndex = selectedWeek - 2

        End If


    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate006 As New clsBB(ModID, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModID))
            Dim ds As DataSet = oTemplate006.GetTemplate
   

            '  Header1.Text = String.Empty
            Text1.Text = String.Empty
            Image1.Visible = False

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ' Header1.Text = ds.Tables(0).Rows(0)("tem_header1")
                    Text1.Text = ds.Tables(0).Rows(0)("tem_text1")
                End If
            End If

            Try
                Dim Height As Integer = "190"
                Dim Width As Integer = "190"
                Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./BinaryFileCache/" & "Template006_1__" & ModID.ToString & ".png"))
                Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
                Image1.Height = Unit.Pixel(oThumb.GetThumbHeight)
                Image1.Width = Unit.Pixel(oThumb.GetThumbWidth)
                Image1.ImageUrl = "BinaryFileCache/" & "Template006_1__" & ModID.ToString & ".png"
                Image1.Visible = True
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oBB As New clsBB(ModID, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModID))
            'oBB.UpdateTemplate(Header1.Text, Text1.Text)
            Dim sReturn As String
            Dim bab_id As Integer
            Dim week As Integer
            week = ddlWeek.SelectedValue
            bab_id = oBB.newBaby("", Text1.Text, ddlWeek.SelectedValue)

            Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
            If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add(bab_id & "_" & week & "_" & ModID.ToString & ".png", Browse1.PostedFile)
            Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
        Catch ex As Exception
            Response.Write(ex.ToString())
        End Try

        'Try
        '    Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        '    Dim oTemplate006 As New clsBB(ModID, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModID))
        '    oTemplate006.UpdateTemplate(Header1.Text, Text1.Text)
        '    Dim Cache As New iConsulting.Library.Binary.Cache(Server.MapPath("./BinaryFileCache/"))
        '    If Browse1.PostedFile.ContentLength > 0 Then Cache.Item.Add("Template006_1__" & ModID.ToString & ".png", Browse1.PostedFile)
        '    Response.Redirect("~/icm.aspx?PageId=" & PageID & "&ExpId=" & ModID)
        'Catch ex As Exception

        'End Try

    End Sub

End Class
