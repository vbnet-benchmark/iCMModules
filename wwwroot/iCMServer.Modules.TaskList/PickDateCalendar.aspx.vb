Imports System.Web

Public Class PickDateCalendar
    Inherits System.Web.UI.Page
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim strSelected As String = HttpContext.Current.Request.QueryString("seldate")
        Dim dtSel As DateTime = DateTime.Today
        Try
            dtSel = Convert.ToDateTime(strSelected)
        Catch

        End Try
        Calendar1.SelectedDate = dtSel
        Calendar1.VisibleDate = dtSel
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Dim strJscript As String = "<script language=javascript>"
        strJscript += "window.opener." + HttpContext.Current.Request.QueryString("formname") + ".value = '"
        strJscript += Format(Calendar1.SelectedDate(), "yyyy-MM-dd") + Format(Now(), " HH:mm") + "';window.close();"
        strJscript += "</script" + ">"
        Literal1.Text = strJscript
    End Sub

End Class