Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports System.Web.UI

Public Class Template003 : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents NavImage1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage3 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage6 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage5 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage4 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage7 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage8 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavImage9 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavLabel1 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel2 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel3 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel6 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel5 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel4 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel7 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel8 As System.Web.UI.WebControls.Label
    Protected WithEvents NavLabel9 As System.Web.UI.WebControls.Label
    Protected WithEvents NavPanel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel6 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel7 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel8 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavPanel9 As System.Web.UI.WebControls.Panel
    Private Navigator1 As String
    Private Navigator2 As String
    Private Navigator3 As String
    Private Navigator4 As String
    Private Navigator5 As String
    Private Navigator6 As String
    Private Navigator7 As String
    Private Navigator8 As String
    Private Navigator9 As String
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        Minimizer.ID = ModuleId
        Call HideNavigation()
        Call BindData()
        Call BindNavigation()
    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate003 As New clsTemplate003(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate003.GetTemplate
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    NavImage1.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip1")
                    NavImage2.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip2")
                    NavImage3.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip3")
                    NavImage4.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip4")
                    NavImage6.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip6")
                    NavImage7.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip7")
                    NavImage8.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip8")
                    NavImage9.ToolTip = ds.Tables(0).Rows(0)("tem_tooltip9")
                    NavImage1.ImageUrl = "BinaryFileCache/" & "Template003_1__" & ModuleId.ToString
                    NavImage2.ImageUrl = "BinaryFileCache/" & "Template003_2__" & ModuleId.ToString
                    NavImage3.ImageUrl = "BinaryFileCache/" & "Template003_3__" & ModuleId.ToString
                    NavImage4.ImageUrl = "BinaryFileCache/" & "Template003_4__" & ModuleId.ToString
                    NavImage6.ImageUrl = "BinaryFileCache/" & "Template003_6__" & ModuleId.ToString
                    NavImage7.ImageUrl = "BinaryFileCache/" & "Template003_7__" & ModuleId.ToString
                    NavImage8.ImageUrl = "BinaryFileCache/" & "Template003_8__" & ModuleId.ToString
                    NavImage9.ImageUrl = "BinaryFileCache/" & "Template003_9__" & ModuleId.ToString
                End If
            End If
        Catch ex As Exception
            Response.Write("error in binddata")
        End Try
    End Sub

    Private Sub BindNavigation()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate003 As New clsTemplate003(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate003.GetHeadMenuItem
            Dim Max As Integer = 0
            For Each dr As DataRow In ds.Tables(0).Rows
                Max += 1
                If Max <= 8 Then
                    ShowNavigation(Max, dr("pag_name"), "icm.aspx?PageId=" & dr("pag_id"))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowNavigation(ByVal Field As Integer, ByVal Title As String, ByVal Link As String)
        Try
            Select Case Field
                Case 1
                    Navigator1 = Link
                    NavLabel1.Text = Title
                    NavPanel1.Visible = True
                    NavImage1.Visible = True
                Case 2
                    Navigator2 = Link
                    NavLabel2.Text = Title
                    NavPanel2.Visible = True
                    NavImage2.Visible = True
                Case 3
                    Navigator3 = Link
                    NavLabel3.Text = Title
                    NavPanel3.Visible = True
                    NavImage3.Visible = True
                Case 4
                    Navigator4 = Link
                    NavLabel4.Text = Title
                    NavPanel4.Visible = True
                    NavImage4.Visible = True
                Case 5
                    Navigator6 = Link
                    NavLabel6.Text = Title
                    NavPanel6.Visible = True
                    NavImage6.Visible = True
                Case 6
                    Navigator7 = Link
                    NavLabel7.Text = Title
                    NavPanel7.Visible = True
                    NavImage7.Visible = True
                Case 7
                    Navigator8 = Link
                    NavLabel8.Text = Title
                    NavPanel8.Visible = True
                    NavImage8.Visible = True
                Case 8
                    Navigator9 = Link
                    NavLabel9.Text = Title
                    NavPanel9.Visible = True
                    NavImage9.Visible = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HideNavigation()
        Try
            NavPanel1.Visible = False
            NavPanel2.Visible = False
            NavPanel3.Visible = False
            NavPanel4.Visible = False
            NavPanel5.Visible = False
            NavPanel6.Visible = False
            NavPanel7.Visible = False
            NavPanel8.Visible = False
            NavPanel9.Visible = False
            NavImage1.Visible = False
            NavImage2.Visible = False
            NavImage3.Visible = False
            NavImage4.Visible = False
            NavImage5.Visible = False
            NavImage6.Visible = False
            NavImage7.Visible = False
            NavImage8.Visible = False
            NavImage9.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NavImage1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage1.Click
        Response.Redirect(Navigator1, True)
    End Sub

    Private Sub NavImage2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage2.Click
        Response.Redirect(Navigator2, True)
    End Sub

    Private Sub NavImage3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage3.Click
        Response.Redirect(Navigator3, True)
    End Sub

    Private Sub NavImage4_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage4.Click
        Response.Redirect(Navigator4, True)
    End Sub

    Private Sub NavImage5_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage5.Click
        Response.Redirect(Navigator5, True)
    End Sub

    Private Sub NavImage6_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage6.Click
        Response.Redirect(Navigator6, True)
    End Sub

    Private Sub NavImage7_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage7.Click
        Response.Redirect(Navigator7, True)
    End Sub

    Private Sub NavImage8_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage8.Click
        Response.Redirect(Navigator8, True)
    End Sub

    Private Sub NavImage9_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NavImage9.Click
        Response.Redirect(Navigator9, True)
    End Sub
End Class
