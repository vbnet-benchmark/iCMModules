
Imports System
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.PanelbarExamplesVBNET.Integration
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected RadPanelbar1 As RadPanelbar
      
      
      
      Protected Sub TreeDrop(sender As Object, NodeEvent As RadTreeNodeEventArgs)
         ' Fetch event data
         Dim sourceNode As RadTreeNode = NodeEvent.SourceDragNode
         Dim destNode As RadTreeNode = NodeEvent.DestDragNode
         
         Dim RadTreeView1 As RadTreeView = sourceNode.TreeViewParent
         
         
         Dim result As String = String.Empty
         If RadTreeView1.SelectedNodes.Count > 0 Then
            Dim node As RadTreeNode
            For Each node In  RadTreeView1.SelectedNodes
               
               If Not node.Equals(destNode.Parent) Then
                  Dim nodeCollection As RadTreeNodeCollection = Nothing
                  If Not node.Parent.Equals(Nothing) Then
                     nodeCollection = node.Parent.Nodes
                  Else
                     nodeCollection = node.TreeViewParent.Nodes
                  End If
                  nodeCollection.Remove(node)
                  destNode.AddNode(node)
               End If
               node.Selected = False
            Next node
         Else
            If Not sourceNode.Equals(destNode.Parent) Then
               Dim nodeCollection As RadTreeNodeCollection = Nothing
               If Not sourceNode.Parent.Equals(Nothing) Then
                  nodeCollection = sourceNode.Parent.Nodes
               Else
                  nodeCollection = sourceNode.TreeViewParent.Nodes
               End If
               nodeCollection.Remove(sourceNode)
               destNode.AddNode(sourceNode)
            End If
            
            sourceNode.Selected = False
         End If
         destNode.Expanded = True
         RadTreeView1.ClearSelectedNodes()
      End Sub 'TreeDrop
      
      
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
   End Class 'DefaultVB 
End Namespace 'Telerik.PanelbarExamplesVBNET.Integration