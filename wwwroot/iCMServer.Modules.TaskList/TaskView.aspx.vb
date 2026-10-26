
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

    Public Class TaskView
        Inherits System.Web.UI.Page
        Protected WithEvents TitleField As System.Web.UI.WebControls.Label
    Protected WithEvents StatusField As System.Web.UI.WebControls.Label
        Protected WithEvents PriorityField As System.Web.UI.WebControls.Label
    Protected WithEvents StartField As System.Web.UI.WebControls.Label
        Protected WithEvents DueField As System.Web.UI.WebControls.Label
        Protected WithEvents cancelButton As System.Web.UI.WebControls.LinkButton
        Protected WithEvents CreatedBy As System.Web.UI.WebControls.Label
        Protected WithEvents CreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents ModifiedBy As System.Web.UI.WebControls.Label
        Protected WithEvents ModifiedDate As System.Web.UI.WebControls.Label
    Protected EditLink As String = ""
    Protected TasId As Integer = 0
    Protected WithEvents longdesc2 As System.Web.UI.HtmlControls.HtmlGenericControl
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

        ' Determine TasId of Announcements Portal Module
        TasId = Int32.Parse(Request.Params("TasId"))

        ' Determine ModuleId of Announcements Portal Module
        ModuleId = Int32.Parse(Request.Params("ModId"))

        ' Verify that the current user has access to edit this module
        If clsSiteSecurity.HasEditPermissions(ModuleId) = True Then
            'EditLink = "<a href='TasksEdit.aspx?ItemID=" & ItemId
            'EditLink += "&mid=" & ModuleId & "' class=Normal>Edit</a>"
        End If

        If Not Page.IsPostBack Then
            If TasId <> 0 Then
                Dim Tasks As New clsTaskList(ModuleId)
                Dim dr As DataRow
                dr = Tasks.GetSingleTask(TasId)

                TitleField.Text = CType(dr("tas_title"), String)
                longdesc.InnerHtml = CType(dr("tas_description"), String)
                StartField.Text = Format(dr("tas_startdate"), "yyyy-MM-dd HH:mm")
                DueField.Text = Format(dr("tas_duedate"), "yyyy-MM-dd HH:mm")
                longdesc2.InnerHtml = CType(dr("tas_assignedto"), String)
                CreatedDate.Text = Format(dr("tas_createddate"), "yyyy-MM-dd HH:mm")
                StatusField.Text = CType(dr("tas_status"), String)
                PriorityField.Text = CType(dr("tas_priority"), String)

            End If

            ' Store URL Referrer to return to portal
            ViewState("UrlReferrer") = Request.UrlReferrer.ToString()
        End If

    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        ' Redirect back to the portal home page
        Response.Redirect(CType(ViewState("UrlReferrer"), String))
    End Sub

End Class

