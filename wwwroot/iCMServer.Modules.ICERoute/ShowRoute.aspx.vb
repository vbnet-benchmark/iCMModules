Public Class ShowRoute
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Listbox2 As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents imgMap As System.Web.UI.WebControls.Image
    Protected WithEvents btnOpen As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnMeasure As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnZoomIn As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnZoomOut As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPrint As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPrevCust As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNextCust As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnListAllCust As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAddCust As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDelCust As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAddTrip As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDelTrip As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAddRoute As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDelRoute As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGetPosAddr As System.Web.UI.WebControls.Button
    Protected WithEvents btnGetPosMap As System.Web.UI.WebControls.Button

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
        'Put user code to initialize the page here
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnZoomIn.Click
        imgMap.ImageUrl() = ".\Images\SmallEx.BMP"
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnZoomOut.Click
        imgMap.ImageUrl() = ".\Images\LargeEx.BMP"
    End Sub

    Private Sub btnAddTrip_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddTrip.Click
        Response.Redirect(".\AddTrip")
    End Sub

    Private Sub btnAddRoute_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddRoute.Click
        Response.Redirect(".\AddRoute")
    End Sub

End Class
