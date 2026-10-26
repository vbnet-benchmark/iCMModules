
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports Telerik.WebControls
Imports System.Web.UI.WebControls
Imports Telerik.QuickStart


Namespace Telerik.IntegrationExamples.GridEidorAndCombo
   
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected Button1 As System.Web.UI.WebControls.Button
      Protected WithEvents RadGrid1 As Telerik.WebControls.RadGrid
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
      
      ' Put user code to initialize the page here
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/		Required method for Designer support - do not modify
      '/		the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      
      Private ReadOnly Property Data() As ArrayList
         Get
            Dim list As ArrayList
            If Not (Me.Session("ds") Is Nothing) Then
               list = CType(Me.Session("ds"), ArrayList)
            Else
               list = New ArrayList()
               list.Add(New ExampleListItem("<p>r.a.d.<strong>g</strong>rid ,&nbsp;r.a.d.<strong>e</strong>ditor , r.a.d.<strong>c</strong>ombo&nbsp;&nbsp;integration. This example demonstrates&nbsp;GridBoundColumn and GridDropDowColumn with&nbsp;different custom editors that in this case use r.a.d.<strong>e</strong>ditor, r.a.d.<strong>c</strong>ombo, even r.a.d.<strong>g</strong>rid itself</p>", 0, "1", "1", DateTime.Now))
               list.Add(New ExampleListItem("Item 1", 1, "2", "2", DateTime.Parse("11/15/2005")))
               list.Add(New ExampleListItem("Item 2", 2, "3", "3", DateTime.Parse("3/8/2001")))
               list.Add(New ExampleListItem("Item 3", 3, "", "", DateTime.Parse("12/31/2005")))
               
               Me.Session("ds") = list
            End If
            
            Return list
         End Get
      End Property
      
      
      Private Sub RadGrid1_NeedDataSource([source] As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
         Me.RadGrid1.DataSource = Me.Data
      End Sub 'RadGrid1_NeedDataSource
      
      
      Private Function GetComboSource() As ArrayList
         Dim itemsList As New ArrayList()
         itemsList.Add(New ListItem("One", "1"))
         itemsList.Add(New ListItem("Two", "2"))
         itemsList.Add(New ListItem("Three", "3"))
         itemsList.Add(New ListItem("Four", "4"))
         itemsList.Add(New ListItem("Five", "5"))
         itemsList.Add(New ListItem("Six", "6"))
         itemsList.Add(New ListItem("Seven", "7"))
         itemsList.Add(New ListItem("Eight", "8"))
         itemsList.Add(New ListItem("Nine", "9"))
         
         Return itemsList
      End Function 'GetComboSource
      
      
      Private Sub RadGrid1_CreateColumnEditor(sender As Object, e As Telerik.WebControls.GridCreateColumnEditorEventArgs) Handles RadGrid1.CreateColumnEditor
         If e.Column.UniqueName = "A" Then
            e.ColumnEditor = New HtmlTextColumnEditor()
         ElseIf e.Column.UniqueName = "C" Then
            Dim comboEditor As New ComboEditor()
            comboEditor.DataSource = GetComboSource()
            
            e.ColumnEditor = comboEditor
         ElseIf e.Column.UniqueName = "D" Then
            Dim gridEditor As New GridListEditor()
            gridEditor.DataSource = GetComboSource()
            e.ColumnEditor = gridEditor
         ElseIf e.Column.UniqueName = "E" Then
            e.ColumnEditor = New InputEditor()
         End If
      End Sub 'RadGrid1_CreateColumnEditor
      
      
      Private Function FindItemIn(list As ArrayList, B As Integer) As ExampleListItem
         Dim res As ExampleListItem = Nothing
         Dim i As Integer
         For i = 0 To list.Count - 1
            If CType(list(i), ExampleListItem).B = B Then
               res = CType(list(i), ExampleListItem)
               Exit For
            End If
         Next i
         If res Is Nothing Then
            Throw New InvalidOperationException("Cannot find item " + B.ToString())
         End If
         
         Return res
      End Function 'FindItemIn
      
      
      Private Sub RadGrid1_UpdateCommand([source] As Object, e As Telerik.WebControls.GridCommandEventArgs) Handles RadGrid1.UpdateCommand
         Dim item As GridEditableItem = CType(e.Item, GridEditableItem)
         Dim edited As ExampleListItem = Me.FindItemIn(Me.Data, Integer.Parse(item("B").Text))
         edited.A = CType(item.EditManager.GetColumnEditor("A"), GridTextColumnEditor).Text
         edited.C = CType(item.EditManager.GetColumnEditor("C"), GridDropDownColumnEditor).SelectedValue
         edited.D = CType(item.EditManager.GetColumnEditor("D"), GridDropDownColumnEditor).SelectedValue
         edited.E = CType(item.EditManager.GetColumnEditor("E"), InputEditor).SelectedDate
      End Sub 'RadGrid1_UpdateCommand
      
      
      Private Sub RadGrid1_PreRender(sender As Object, e As System.EventArgs) Handles RadGrid1.PreRender
         If Not IsPostBack Then
            Me.RadGrid1.Items(0).Edit = True
            Me.RadGrid1.Rebind()
         End If
      End Sub 'RadGrid1_PreRender
   End Class 'DefaultVB
End Namespace 'Telerik.IntegrationExamples.GridEidorAndCombo