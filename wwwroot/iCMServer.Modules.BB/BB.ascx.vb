Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Globalization


Public Class BB : Inherits clsSiteModuleControl

    Public strImg As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Header1 As System.Web.UI.WebControls.Label
    Protected WithEvents Text1 As System.Web.UI.WebControls.Label
    Protected WithEvents w1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w3 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w6 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w4 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w5 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w8 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w7 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w10 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w9 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w11 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w12 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w18 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w17 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w16 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w15 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w14 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w13 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w19 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w20 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w21 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w22 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w23 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w24 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w30 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w29 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w28 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w27 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w26 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w25 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w31 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w32 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w33 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w34 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w35 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w36 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w42 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w41 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w40 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w39 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w38 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w37 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w43 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w44 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w45 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w46 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w47 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w48 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w51 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w50 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w49 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents MyList As System.Web.UI.WebControls.DataList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents plnDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents imgDetail As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents ImgText As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblWeek As System.Web.UI.WebControls.Label
    Protected WithEvents w53 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents w52 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private selectedWeek As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim img_id As String
        plnDetail.Visible = False
        lnkBack.Visible = False
        Minimizer.ID = ModuleId
        Response.Write("<link rel='stylesheet' type='text/css' href='Desktop\Modules\BB\bb.css'></link>")
        BindLink()

        If Request("w") = "" Or Request("w") = Nothing Then
            Dim cal As New System.Globalization.GregorianCalendar
            cal = New GregorianCalendar
            Dim dd As Date = Now
            Dim FirstDay As New System.Globalization.CalendarWeekRule
            selectedWeek = cal.GetWeekOfYear(dd, FirstDay, System.DayOfWeek.Monday)
            selectedWeek = selectedWeek - 1
        Else
            selectedWeek = Request("w")
        End If
        lblWeek.Text = selectedWeek
        If Not Page.IsPostBack Then
            Call BindData()
            If Not Request("img_id") = "" Or Request("img_id") = Nothing Then
                Try
                    img_id = Request("img_id")
                    getDetail(img_id)
                Catch ex As Exception
                End Try
            End If
        End If
        If Not clsSiteSecurity.HasEditPermissions(ModuleId) Then
            Try
                If MyList.Controls.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To MyList.Controls.Count
                        Dim b As New Button
                        b = CType(MyList.Controls(i).FindControl("Delete"), Button)
                        b.Visible = False
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

  
    Private Sub getDetail(ByVal img_id As String)
        Try
            Dim Height As Integer = "210"
            Dim Width As Integer = "210"
         
            Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./Desktop/Modules/BB/BinaryFileCache/" & img_id & ".png"))
            Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oBB As New clsBB(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oBB.getBaby(selectedWeek)
            Dim iArray As Array
            Image2.Height = Unit.Pixel(oThumb.GetThumbHeight)
            Image2.Width = Unit.Pixel(oThumb.GetThumbWidth)

            Image2.ImageUrl = "BinaryFileCache/" & img_id & ".png"
            Image2.Visible = True
            plnDetail.Visible = True
            iArray = Split(img_id, "_")
            ds = oBB.getBabyByID(iArray(0))
            ImgText.Text = ds.Tables(0).Rows(0)("bab_text1")
            MyList.Visible = False
            lnkBack.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=" & Request("w")
            lnkBack.Visible = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BindLink()
        w1.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=1"
        w2.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=2"
        w3.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=3"
        w4.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=4"
        w5.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=5"
        w6.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=6"
        w7.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=7"
        w8.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=8"
        w9.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=9"
        w10.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=10"
        w11.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=11"
        w12.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=12"
        w13.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=13"
        w14.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=14"
        w15.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=15"
        w16.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=16"
        w17.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=17"
        w18.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=18"
        w19.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=19"
        w20.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=20"
        w21.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=21"
        w22.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=22"
        w23.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=23"
        w24.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=24"
        w25.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=25"
        w26.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=26"
        w27.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=27"
        w28.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=28"
        w29.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=29"
        w30.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=30"
        w31.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=31"
        w32.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=32"
        w33.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=33"
        w34.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=34"
        w35.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=35"
        w36.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=36"
        w37.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=37"
        w38.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=38"
        w39.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=39"
        w40.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=40"
        w41.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=41"
        w42.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=42"
        w43.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=43"
        w44.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=44"
        w45.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=45"
        w46.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=46"
        w47.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=47"
        w48.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=48"
        w49.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=49"
        w50.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=50"
        w51.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=51"
        w52.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=52"
        w53.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&w=53"

    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oBB As New clsBB(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oBB.getBaby(selectedWeek)
            Dim dt As New DataTable
            Dim dc1 As New DataColumn("bab_id")
            dt.Columns.Add(dc1)
            Dim dc2 As New DataColumn("imgSource")
            dt.Columns.Add(dc2)
            Dim dc3 As New DataColumn("pageId")
            dt.Columns.Add(dc3)
            Dim dc4 As New DataColumn("img_id")
            dt.Columns.Add(dc4)
            Dim dc5 As New DataColumn("week_id")
            dt.Columns.Add(dc5)
            Dim dc6 As New DataColumn("imgAlt")
            dt.Columns.Add(dc6)

            Dim sImg As String
            Dim drDS As DataRow
            Dim dr As DataRow

            For Each drDS In ds.Tables(0).Rows
                Try
                    dr = dt.NewRow()
                    dr("bab_id") = drDS("bab_id") 'ds.Tables(0).Rows(0)("bab_id")
                    dr("imgSource") = "Desktop/Modules/BB/BinaryFileCache" & "/" & drDS("bab_id") & "_" & drDS("bab_week") & "_" & ModuleId.ToString & ".png"
                    dr("pageId") = ModuleConfiguration.PageId
                    dr("img_id") = drDS("bab_id") & "_" & drDS("bab_week") & "_" & ModuleId.ToString
                    dr("week_id") = selectedWeek
                    dr("imgAlt") = drDS("bab_text1")
                    dt.Rows.Add(dr)
                Catch ex As Exception
                    ex.ToString()
                End Try
            Next
            MyList.DataSource = dt
        Catch ex As Exception
        End Try
        MyList.DataBind()

    End Sub

    Public Sub DoItemDelete(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oBB As New clsBB(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
        Dim id As Integer
        Dim path As String
        id = MyList.DataKeys(e.Item.ItemIndex)
        path = Server.MapPath(".") & "\Desktop\Modules\BB\BinaryFileCache"
        oBB.DeleteBaby(id, path)
        BindData()
    End Sub

End Class
