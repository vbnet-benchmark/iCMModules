Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls

Public Class ProjectList : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents ResultHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents ScriptHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents dgSearch As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgProjList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents btnAddRow As System.Web.UI.WebControls.Button

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            IsAuthorized = True
        End If

        lblError.Text = ""

        If Not Page.IsPostBack Then
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim ds As New DataSet
        Dim oProjList As New clsProjectList(ModuleId)
        ds = oProjList.GetAllProjects()
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgProjList.DataSource = ds
                dgProjList.DataBind()
            End If
        End If

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            dgProjList.Columns(7).Visible = True
            dgProjList.Columns(8).Visible = True
            btnAddRow.Visible = True
        Else
            dgProjList.Columns(7).Visible = False
            dgProjList.Columns(8).Visible = False
            btnAddRow.Visible = False
        End If
    End Sub

    Sub dgProjList_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        dgProjList.EditItemIndex = CType(e.Item.ItemIndex, Integer)
        BindData()        
    End Sub

    Sub dgProjList_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)        
        If Not e.Item.FindControl("lblNr") Is Nothing Then
            Dim nr As String = CType(CType(e.Item.FindControl("lblNr"), TextBox).Text, String)
            Dim start As String = CType(CType(e.Item.FindControl("lblStart"), TextBox).Text, String)
            Dim hidden As Integer = 1
            Dim deleted As Integer = 1
            Dim projId As Integer
            Dim oProjList As New clsProjectList(ModuleId)
            projId = dgProjList.DataKeys(e.Item.ItemIndex)

            oProjList.DeleteProject(projId, hidden, deleted)

            dgProjList.EditItemIndex = -1
            BindData()
        Else
            lblError.Text = "Vänligen avsluta editeringen innan du raderar objekt."
        End If
    End Sub

    Sub dgProjList_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        dgProjList.EditItemIndex = -1
        BindData()
    End Sub

    Sub dgProjList_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If Page.IsValid Then
            Dim nr As Integer = CType(CType(e.Item.FindControl("txtNr"), TextBox).Text, Integer)
            Dim start As String = CType(CType(e.Item.FindControl("txtStart"), TextBox).Text, String)
            Dim leader As String = CType(CType(e.Item.FindControl("txtLeader"), TextBox).Text, String)
            Dim participant As String = CType(CType(e.Item.FindControl("txtParticipant"), TextBox).Text, String)
            Dim description As String = CType(CType(e.Item.FindControl("txtDescription"), TextBox).Text, String)
            Dim aim As String = CType(CType(e.Item.FindControl("txtAim"), TextBox).Text, String)
            Dim month As String = CType(CType(e.Item.FindControl("txtMonth"), TextBox).Text, String)
            Dim projId As Integer
            Dim oProjList As New clsProjectList(ModuleId)
            projId = dgProjList.DataKeys(e.Item.ItemIndex)
         
            oProjList.UpdateProject(projId, nr, start, leader, participant, description, aim, month)

            dgProjList.EditItemIndex = -1
            BindData()
        End If
    End Sub

    Private Sub btnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
        Dim oProjList As New clsProjectList(ModuleId)
        oProjList.AddRow()
        BindData()        
    End Sub
End Class
