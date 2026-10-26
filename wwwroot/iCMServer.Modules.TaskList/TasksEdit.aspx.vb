
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Public Class TasksEdit
    Inherits System.Web.UI.Page
    Protected WithEvents TitleField As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredTitle As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents DescriptionField As System.Web.UI.WebControls.TextBox
    Protected WithEvents PercentCompleteField As System.Web.UI.WebControls.TextBox
    Protected WithEvents PercentValidator As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents StatusField As System.Web.UI.WebControls.DropDownList
    Protected WithEvents PriorityField As System.Web.UI.WebControls.DropDownList
    Protected WithEvents AssignedField As System.Web.UI.WebControls.TextBox
    Protected WithEvents StartField As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnStart As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DueField As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDue As System.Web.UI.WebControls.ImageButton
    Protected WithEvents updateButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents deleteButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents CreatedBy As System.Web.UI.WebControls.Label
    Protected WithEvents CreatedDate As System.Web.UI.WebControls.Label
    Protected WithEvents ModifiedBy As System.Web.UI.WebControls.Label
    Protected WithEvents ModifiedDate As System.Web.UI.WebControls.Label
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal

    Protected TasId As Integer = 0
    Protected WithEvents longdesc As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected ModuleId As Integer = 0
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

        ' Determine ItemId of Tasks Module
        If Not (Request.Params("TasId") Is Nothing) Then
            TasId = Int32.Parse(Request.Params("TasId"))
        End If

        ' Determine ModuleId of Tasks Module
        If Not (Request.Params("ModId") Is Nothing) Then
            ModuleId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not Page.IsPostBack Then
            StartField.Text = Format(Now(), "yyyy-MM-dd HH:mm")
            DueField.Text = Format(Now(), "yyyy-MM-dd HH:mm")

            If TasId <> 0 Then
                Dim Tasks As New clsTaskList(ModuleId)
                Dim dr As DataRow
                dr = Tasks.GetSingleTask(TasId)

                TitleField.Text = CType(dr("tas_title"), String)
                DescriptionField.Text = CType(dr("tas_description"), String)
                StartField.Text = Format(dr("tas_startdate"), "yyyy-MM-dd HH:mm")
                DueField.Text = Format(dr("tas_duedate"), "yyyy-MM-dd HH:mm")
                CreatedBy.Text = CType(dr("tas_createdby"), String)
                ModifiedBy.Text = CType(dr("tas_updatedby"), String)
                PercentCompleteField.Text = CType(dr("tas_percentcomplete").ToString(), Int32)
                AssignedField.Text = CType(dr("tas_assignedto"), String)
                CreatedDate.Text = Format(CType(dr("tas_createddate").ToString(), DateTime), "yyyy-MM-dd HH:mm")
                ModifiedDate.Text = Format(CType(dr("tas_updateddate").ToString(), DateTime), "yyyy-MM-dd HH:mm")
                StatusField.SelectedIndex = GetStatus(CType(dr("tas_status"), String))
                PriorityField.SelectedIndex = GetPriority(CType(dr("tas_priority"), String))
            Else
                deleteButton.Visible = False

            End If

            ' Store URL Referrer to return to portal
            ViewState("UrlReferrer") = Request.UrlReferrer.ToString()

        End If

    End Sub

    Protected Function GetStatus(ByVal status As String) As Integer
        Select Case status
            Case "Pågående"
                Return 1
            Case "Avklarad"
                Return 2
            Case Else
                Return 0
        End Select
    End Function

    Protected Function GetPriority(ByVal priority As String) As Integer
        Select Case priority
            Case "Normal"
                Return 1
            Case "Låg"
                Return 2
            Case Else
                Return 0
        End Select
    End Function

    Protected Sub Start_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim sScript As String
        sScript = "<script language=javascript>"
        sScript += "window.open('PickDateCalendar.aspx?formname=form1.StartField&seldate="
        sScript += StartField.Text & "','PickDateCalWin','height=188,width=172,left=300,top=300')"
        sScript += "</" & "script>"
        Literal1.Text = sScript
    End Sub

    Protected Sub Due_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim sScript As String
        sScript = "<script language=javascript>"
        sScript += "window.open('PickDateCalendar.aspx?formname=form1.DueField&seldate="
        sScript += DueField.Text & "','PickDateCalWin','height=188,width=172,left=300,top=300')"
        sScript += "</" & "script>"
        Literal1.Text = sScript
    End Sub

    Private Sub updateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles updateButton.Click
        If Page.IsValid Then
            Dim Tasks As New clsTaskList(ModuleId)
            If TasId = 0 Then
                Tasks.AddTask(ModuleId, TasId, Context.User.Identity.Name, TitleField.Text, DateTime.Parse(StartField.Text), DescriptionField.Text, StatusField.SelectedItem.Value, PriorityField.SelectedItem.Value, AssignedField.Text, DateTime.Parse(DueField.Text), Int16.Parse(PercentCompleteField.Text))
            Else
                Tasks.UpdateTask(ModuleId, TasId, Context.User.Identity.Name, TitleField.Text, DateTime.Parse(StartField.Text), DescriptionField.Text, StatusField.SelectedItem.Value, PriorityField.SelectedItem.Value, AssignedField.Text, DateTime.Parse(DueField.Text), Int16.Parse(PercentCompleteField.Text))
            End If
            ' Redirect back to the portal home page
            Response.Redirect(CType(ViewState("UrlReferrer"), String))
        End If
    End Sub

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        If TasId <> 0 Then
            Dim Tasks As New clsTaskList(ModuleId)
            Tasks.DeleteTask(TasId)
        End If
        ' Redirect back to the portal home page
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        ' Redirect back to the portal home page
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub
End Class