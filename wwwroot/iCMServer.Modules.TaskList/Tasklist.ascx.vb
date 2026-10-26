Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls

Public Class Tasklist : Inherits clsSiteModuleControl

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

    Protected IsAuthorized As Boolean = False
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents myDataGrid As System.Web.UI.WebControls.DataGrid
    Protected myDataView As System.Data.DataView
    Protected sortField As String
    Protected sortDirection As String
    Protected ModId As Int32

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("sv-SE")

        Minimizer.ID = ModuleId
        ModId = ModuleId

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            IsAuthorized = True
        End If

        If Not Page.IsPostBack Then
            sortField = "tas_duedate"
            sortDirection = "ASC"
            ViewState("SortField") = sortField
            ViewState("sortDirection") = sortDirection
            viewstate.Add("sortField", sortField)
            ViewState.Add("sortDirection", sortDirection)
        Else
            sortField = CType(ViewState("SortField"), String)
            sortDirection = CType(ViewState("sortDirection"), String)
        End If

        myDataView = New DataView

        Dim tasks = New clsTaskList(ModuleId)
        Dim taskdata As New DataSet

        taskdata = tasks.GetTasksDependingOnUser()
        myDataView = taskdata.Tables(0).DefaultView
        If Not Page.IsPostBack Then myDataView.Sort = sortField & " " & sortDirection

        Call BindGrid()

        Call MarkOldTasks()
    End Sub

    Protected Sub BindGrid()
        myDataGrid.DataSource = myDataView
        myDataGrid.DataBind()
    End Sub

    Protected Sub MarkOldTasks()
        Dim iRowIndex As Integer = 0
        For iRowIndex = 0 To myDataGrid.Items.Count - 1
            Dim x1 As DateTime = CType(myDataGrid.Items(iRowIndex).Cells(6).Text, DateTime)
            Dim x2 As DateTime = Now
            Dim x3 As DateTime = x1.AddDays(3)
            If x3 < x2 Then
                myDataGrid.Items(iRowIndex).Cells(6).ForeColor = myDataGrid.Items(iRowIndex).ForeColor.Red
            ElseIf x1 < x2 Then
                myDataGrid.Items(iRowIndex).Cells(6).ForeColor = myDataGrid.Items(iRowIndex).ForeColor.Orange
            Else
                myDataGrid.Items(iRowIndex).Cells(6).ForeColor = myDataGrid.Items(iRowIndex).ForeColor.Green
            End If
            myDataGrid.Items(iRowIndex).Cells(6).Text = Format(CType(myDataGrid.Items(iRowIndex).Cells(6).Text, DateTime), "yyyy-MM-dd HH:mm")
            myDataGrid.Items(iRowIndex).Cells(5).Text = Format(CType(myDataGrid.Items(iRowIndex).Cells(5).Text, DateTime), "yyyy-MM-dd HH:mm")
        Next
    End Sub

    Protected Sub SortTasks(ByVal source As Object, ByVal e As DataGridSortCommandEventArgs)
        If sortField = e.SortExpression Then
            If sortDirection = "ASC" Then
                sortDirection = "DESC"
            Else
                sortDirection = "ASC"
            End If
        Else
            If e.SortExpression = "tas_duedate" Then
                sortDirection = "DESC"
            End If
        End If
        ViewState("SortField") = e.SortExpression
        ViewState("sortDirection") = sortDirection
        myDataView.Sort = e.SortExpression + " " + sortDirection
        Call BindGrid()
        Call MarkOldTasks()
    End Sub


End Class
