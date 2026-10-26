Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Public Class Template006 : Inherits clsSiteModuleControl

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
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate006 As New clsTemplate006(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate006.GetTemplate

            Header1.Text = String.Empty
            Text1.Text = String.Empty
            Image1.Visible = False

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Header1.Text = ds.Tables(0).Rows(0)("tem_header1")
                    Text1.Text = ds.Tables(0).Rows(0)("tem_text1")
                End If
            End If

            Try
                Dim Height As Integer = "190"
                Dim Width As Integer = "190"
                Dim Bmp As New System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("./Desktop/Modules/Template006/BinaryFileCache/" & "Template006_1__" & ModuleId.ToString & ".png"))
                Dim oThumb As New iConsulting.Library.Image.clsThumbnail(Height, Width, Bmp)
                Image1.Height = Unit.Pixel(oThumb.GetThumbHeight)
                Image1.Width = Unit.Pixel(oThumb.GetThumbWidth)
                Image1.ImageUrl = "BinaryFileCache/" & "Template006_1__" & ModuleId.ToString & ".png"
                Image1.Visible = True
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

End Class
