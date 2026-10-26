
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Telerik.WebControls.RadEditorUtils


Namespace Telerik.CallbackIntegrationExamplesVBNET.Editor
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected editor1 As Telerik.WebControls.RadEditor
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected Label3 As System.Web.UI.WebControls.Label
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected btnToggleEditorVisibility As Telerik.WebControls.CallbackButton
      Protected lbArticles As Telerik.WebControls.CallbackListBox
      Protected cblToolbars As Telerik.WebControls.CallbackCheckBoxList
      Protected rblSkin As Telerik.WebControls.CallbackRadioButtonList
      Protected EditedNews As HtmlInputHidden
      
      
      Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            cblToolbars.Items.Clear()
            Dim toolBar As Toolbar
            For Each toolBar In  editor1.Toolbars
               cblToolbars.Items.Add(toolBar.Name)
               cblToolbars.Items((cblToolbars.Items.Count - 1)).Selected = True
            Next toolBar
         End If
      End Sub 'Page_Load
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      Protected Sub editor1_EditableChanged(src As Object, e As Telerik.WebControls.EditableChangedEventArgs)
         btnToggleEditorVisibility.Text = btnToggleText(e.Editable)
      End Sub 'editor1_EditableChanged
      
      Private Function btnToggleText(editorVisible As Boolean) As String
         If editorVisible Then
            Return "Hide Editor"
         Else
            Return "Show Editor"
         End If
      End Function 'btnToggleText
      
      Protected Sub btnToggleEditorVisibility_Click(sender As Object, e As System.EventArgs)
         editor1.Editable = Not editor1.Editable
         btnToggleEditorVisibility.Text = btnToggleText(editor1.Editable)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(editor1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(btnToggleEditorVisibility)
      End Sub 'btnToggleEditorVisibility_Click
      
      
      Protected Sub cblToolbars_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim item As System.Web.UI.WebControls.ListItem
         For Each item In  cblToolbars.Items
            Dim toolBar As Toolbar = editor1.Toolbars(item.Text)
            toolBar.IsEnabled = item.Selected
         Next item
         CType(sender, Telerik.WebControls.CallbackCheckBoxList).ControlsToUpdate.Add(editor1)
      End Sub 'cblToolbars_SelectedIndexChanged
      
      
      Private Function CreateConnection() As OleDbConnection
         Dim connection As New OleDbConnection()
         connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath((Me.TemplateSourceDirectory + "\News.mdb")) + ";User ID=;Password=;"
         connection.Open()
         Return connection
      End Function 'CreateConnection
      
      
      Protected Sub rblSkin_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         editor1.Skin = rblSkin.SelectedItem.Text
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(editor1)
      End Sub 'rblSkin_SelectedIndexChanged
      
      
      Protected Sub lbArticles_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim connection As OleDbConnection = CreateConnection()
         
         Dim command As New OleDbCommand("SELECT NewsText FROM News WHERE NewsID = @nid", connection)
         command.Parameters.Add("nid", lbArticles.SelectedItem.Value)
         Dim record As OleDbDataReader = command.ExecuteReader()
         If record.Read() Then
            editor1.Html = record.GetString(0)
            EditedNews.Value = lbArticles.SelectedItem.Value
         Else
            editor1.Html = ""
            EditedNews.Value = ""
         End If
         record.Close()
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(editor1)
      End Sub 'lbArticles_SelectedIndexChanged
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Editor