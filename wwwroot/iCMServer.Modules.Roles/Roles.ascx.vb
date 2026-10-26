Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class Roles : Inherits clsSiteModuleControl

    Protected WithEvents Placeholder1 As System.Web.UI.WebControls.PlaceHolder
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLanguageText As New clsLanguageText
    Private al As New ArrayList

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        Call BindData()
    End Sub

    Private Sub BindData()
        al = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Roles")
        Dim T As System.Web.UI.WebControls.Table
        Dim TR As System.Web.UI.WebControls.TableRow
        Dim TD As System.Web.UI.WebControls.TableCell
        Dim IMG As System.Web.UI.HtmlControls.HtmlImage
        Dim oRol As New clsRoles
        Dim dt As DataTable = oRol.GetRoles
        Dim dr As DataRow

        ' UserTable
        T = New System.Web.UI.WebControls.Table
        T.BorderWidth = T.BorderWidth.Pixel(1)

        ' UserHeader
        TR = New System.Web.UI.WebControls.TableRow
        TR.CssClass = "SubHead"
        TD = New System.Web.UI.WebControls.TableCell
        TD.Text = ""
        TR.Controls.Add(TD)
        TD = New System.Web.UI.WebControls.TableCell
        TD.Text = "&nbsp;" & Server.HtmlDecode(oLanguageText.Find(al, "roles_name"))
        TR.Controls.Add(TD)
        TD = New System.Web.UI.WebControls.TableCell
        TD.Text = "&nbsp;" & Server.HtmlDecode(oLanguageText.Find(al, "roles_description"))
        TR.Controls.Add(TD)
        TD = New System.Web.UI.WebControls.TableCell
        TD.Text = ""
        TR.Controls.Add(TD)
        T.Controls.Add(TR)

        ' UserRows
        For Each dr In dt.Rows
            TR = New System.Web.UI.WebControls.TableRow
            TR.CssClass = "SubSubHead"
            TD = New System.Web.UI.WebControls.TableCell
            IMG = New System.Web.UI.HtmlControls.HtmlImage
            IMG.ID = "Edit" & dr("rol_id")
            IMG.Alt = Server.HtmlDecode(oLanguageText.Find(al, "roles_edit"))
            IMG.Attributes.Add("onclick", "document.location.href='Server/Modules/Roles/RolesEdit.aspx?RolId=" & dr("rol_id") & "&ModId=" & ModuleId & "'")
            IMG.Style.Add("cursor", "hand")
            IMG.Src = "Images/Edit.gif"
            TD.Controls.Add(IMG)
            TR.Controls.Add(TD)
            TD = New System.Web.UI.WebControls.TableCell
            TD.Text = "&nbsp;" & dr("rol_name")
            TR.Controls.Add(TD)
            TD = New System.Web.UI.WebControls.TableCell
            TD.Text = "&nbsp;" & dr("rol_description")
            TR.Controls.Add(TD)
            TD = New System.Web.UI.WebControls.TableCell
            IMG = New System.Web.UI.HtmlControls.HtmlImage
            IMG.ID = "Link" & dr("rol_id")
            IMG.Alt = Server.HtmlDecode(oLanguageText.Find(al, "roles_linktext"))
            IMG.Attributes.Add("onclick", "document.location.href='Server/Modules/Roles/RolesUsers.aspx?iID=" & dr("rol_id") & "&ModId=" & ModuleId & "'")
            IMG.Style.Add("cursor", "hand")
            IMG.Src = "Images/Roles.gif"
            TD.Controls.Add(IMG)
            TR.Controls.Add(TD)
            T.Controls.Add(TR)
        Next

        ' Button
        Dim B As New System.Web.UI.WebControls.Button
        B.CssClass = "iCWebcontrolsII"
        B.Style.Add("cursor", "hand")
        B.ToolTip = Server.HtmlDecode(oLanguageText.Find(al, "roles_add2"))
        B.Text = Server.HtmlDecode(oLanguageText.Find(al, "roles_add2"))
        AddHandler B.Click, AddressOf Button_Click

        ' WideTable
        TR = New System.Web.UI.WebControls.TableRow

        ' Add Dummy to row
        TD = New System.Web.UI.WebControls.TableCell
        TD.HorizontalAlign = HorizontalAlign.Left
        TD.VerticalAlign = VerticalAlign.Top
        TD.Text = "&nbsp;"
        TR.Controls.Add(TD)

        ' Add UserTable to row
        TD = New System.Web.UI.WebControls.TableCell
        TD.HorizontalAlign = HorizontalAlign.Left
        TD.VerticalAlign = VerticalAlign.Top
        TD.Controls.Add(T)
        TR.Controls.Add(TD)

        ' Add Button to row
        TD = New System.Web.UI.WebControls.TableCell
        TD.HorizontalAlign = HorizontalAlign.Right
        TD.VerticalAlign = VerticalAlign.Top
        TD.Controls.Add(B)
        TR.Controls.Add(TD)

        ' Add Dummy to row
        TD = New System.Web.UI.WebControls.TableCell
        TD.HorizontalAlign = HorizontalAlign.Right
        TD.VerticalAlign = VerticalAlign.Top
        TD.Text = "&nbsp;"
        TR.Controls.Add(TD)

        ' Add all to new table
        T = New System.Web.UI.WebControls.Table
        T.BorderWidth = T.BorderWidth.Pixel(0)
        T.Width = T.Width.Percentage(100)
        T.Controls.Add(TR)

        Placeholder1.Controls.Add(T)
    End Sub

    Private Sub Button_Click(ByVal Sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/Server/Modules/Roles/RolesEdit.aspx?ModId=" & ModuleId)
    End Sub

End Class
