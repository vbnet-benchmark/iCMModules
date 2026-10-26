Public Class TasksNew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSend As System.Web.UI.WebControls.Button
    Protected WithEvents txtBody As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected ModuleId As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("sv-SE")

        ' Determine ModuleId of Tasks Module
        If Not (Request.Params("ModId") Is Nothing) Then
            ModuleId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not Page.IsPostBack Then
            ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
        End If

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        btnSend.Enabled = False
        If Page.IsValid Then
            Dim Tasks As New clsTaskList(ModuleId)

            If txtSubject.Text.Length < 1 Then txtSubject.Text = "blank"
            If txtBody.Text.Length < 1 Then txtBody.Text = ""

            Tasks.AddTask(ModuleId, 0, Context.User.Identity.Name, txtSubject.Text, Now(), txtBody.Text, "Pågående", "Normal", String.Empty, Now.AddDays(7), 0)

            ' Redirect back to the portal home page
            Response.Redirect(CType(ViewState("UrlReferrer"), String))

        End If
        btnSend.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        ' Redirect back to the portal home page
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub
End Class
