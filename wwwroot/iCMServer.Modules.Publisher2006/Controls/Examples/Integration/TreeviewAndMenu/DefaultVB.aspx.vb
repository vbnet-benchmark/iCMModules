
Imports System
Imports System.Web.UI.WebControls
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndMenu
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents RadTreeView1 As RadTreeView
      Protected WithEvents RadMenu2 As RadMenu
      Protected Label1 As Label
      Protected WithEvents RadMenu1 As RadMenu
      
      
      Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      Private Sub RadMenu1_ItemClicked(sender As Object, e As ItemEventArgs) Handles RadMenu1.ItemClicked
         HandleItemClicked(e)
      End Sub 'RadMenu1_ItemClicked
      
      
      Private Sub RadMenu2_ItemClicked(sender As Object, e As ItemEventArgs) Handles RadMenu2.ItemClicked
         HandleItemClicked(e)
      End Sub 'RadMenu2_ItemClicked
      
      
      Private Sub HandleItemClicked(e As ItemEventArgs)
         Select Case e.Item.Text
            Case "Delete"
               RadTreeView1.SelectedNode.Remove()
            Case "Add"
               RadTreeView1.SelectedNode.AddNode(New RadTreeNode("New Node"))
         End Select
      End Sub 'HandleItemClicked
      
      Private Sub RadTreeView1_NodeEdit(o As Object, e As RadTreeNodeEventArgs) Handles RadTreeView1.NodeEdit
         Dim nodeEdited As RadTreeNode = e.NodeEdited
         Dim newText As String = e.NewText
         
         nodeEdited.Text = newText
      End Sub 'RadTreeView1_NodeEdit 
   End Class 'DefaultVB
End Namespace 'Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndMenu