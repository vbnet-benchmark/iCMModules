Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports System.Web.UI

Public Class Template011 : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents HeaderText As System.Web.UI.WebControls.TextBox
    Protected WithEvents ContentText As System.Web.UI.WebControls.Label
    Protected WithEvents MediaButton1 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton2 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton3 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton4 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton5 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton6 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton7 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton8 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton9 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton10 As System.Web.UI.WebControls.Image
    Protected WithEvents imgNextPage As System.Web.UI.WebControls.Image
    Protected WithEvents lblNextPage As System.Web.UI.WebControls.Label
    Protected WithEvents NavLink1 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink2 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink3 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink4 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink5 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink6 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink7 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink8 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink9 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink10 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink11 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink12 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink13 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink14 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink15 As System.Web.UI.WebControls.Button
    Protected WithEvents space1 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavTd1 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd2 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd3 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd4 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd5 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd6 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd7 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd8 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd9 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd10 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd11 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd12 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd13 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd14 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd15 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NextPic As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavImage1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents NavLabel1 As System.Web.UI.WebControls.Label
    Protected WithEvents NavPanel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Link1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link3 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link4 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link5 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Back As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Link6 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link7 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Link8 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr2 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr3 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr4 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr5 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr6 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr7 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr8 As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Link1NavigateUrl As String
    Private Link2NavigateUrl As String
    Private Link3NavigateUrl As String
    Private Link4NavigateUrl As String
    Private Link5NavigateUrl As String
    Private Link6NavigateUrl As String
    Private Link7NavigateUrl As String
    Private Link8NavigateUrl As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Call BindData()
        Call BindNavigation()
    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

            Tr1.Visible = False
            Tr2.Visible = False
            Tr3.Visible = False
            Tr4.Visible = False
            Tr5.Visible = False
            Tr6.Visible = False
            Tr7.Visible = False
            Tr8.Visible = False
            Link1.Text = String.Empty
            Link2.Text = String.Empty
            Link3.Text = String.Empty
            Link4.Text = String.Empty
            Link5.Text = String.Empty
            Link6.Text = String.Empty
            Link7.Text = String.Empty
            Link8.Text = String.Empty
            Link1.Visible = False
            Link2.Visible = False
            Link3.Visible = False
            Link4.Visible = False
            Link5.Visible = False
            Link6.Visible = False
            Link7.Visible = False
            Link8.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindNavigation()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate011 As New clsTemplate011(ModuleId, oSite.ActivePage.PageId, True)
            Dim ds As DataSet = oTemplate011.GetSubMenuItem
            Dim Max As Integer = 0
            For Each dr As DataRow In ds.Tables(0).Rows
                Max += 1
                Select Case Max
                    Case 1
                        Link1NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link1.Text = dr("pag_name")
                        Link1.Visible = True
                        Tr1.Visible = True
                    Case 2
                        Link2NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link2.Text = dr("pag_name")
                        Link2.Visible = True
                        Tr2.Visible = True
                    Case 3
                        Link3NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link3.Text = dr("pag_name")
                        Link3.Visible = True
                        Tr3.Visible = True
                    Case 4
                        Link4NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link4.Text = dr("pag_name")
                        Link4.Visible = True
                        Tr4.Visible = True
                    Case 5
                        Link5NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link5.Text = dr("pag_name")
                        Link5.Visible = True
                        Tr5.Visible = True
                    Case 6
                        Link6NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link6.Text = dr("pag_name")
                        Link6.Visible = True
                        Tr6.Visible = True
                    Case 7
                        Link7NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link7.Text = dr("pag_name")
                        Link7.Visible = True
                        Tr7.Visible = True
                    Case 8
                        Link8NavigateUrl = "icm.aspx?PageId=" & dr("pag_id")
                        Link8.Text = dr("pag_name")
                        Link8.Visible = True
                        Tr8.Visible = True
                End Select
            Next
        Catch ex As Exception
            Response.Write(ex)
        End Try
    End Sub

    Private Function TransformToHTML(ByVal str As String) As String
        Try
            str = Replace(str, vbCrLf, "<br>")
            str = Replace(str, vbTab, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            Return str
        Catch ex As Exception
            Return str
        End Try
    End Function

    Private Sub Link1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link1.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link1" ' Link1SelId
        Response.Redirect(Link1NavigateUrl, True)
    End Sub

    Private Sub Link2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link2.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link2" 'Link2SelId
        Response.Redirect(Link2NavigateUrl, True)
    End Sub

    Private Sub Link3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link3.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link3" 'Link3SelId
        Response.Redirect(Link3NavigateUrl, True)
    End Sub

    Private Sub Link4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link4.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link4" 'Link4SelId
        Response.Redirect(Link4NavigateUrl, True)
    End Sub

    Private Sub Link5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Link5.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link5" 'Link5SelId
        Response.Redirect(Link5NavigateUrl, True)
    End Sub

    Private Sub Link6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link6.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link6" 'Link6SelId
        Response.Redirect(Link6NavigateUrl, True)
    End Sub

    Private Sub Link7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link7.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link7" 'Link7SelId
        Response.Redirect(Link7NavigateUrl, True)
    End Sub

    Private Sub Link8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Link8.Click
        HttpContext.Current.Session.Item("SelectedThirdLavelLink") = "Link8" 'Link8SelId
        Response.Redirect(Link8NavigateUrl, True)
    End Sub
End Class
