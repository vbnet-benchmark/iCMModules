
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace Telerik.CallbackIntegarationExamplesVBNET.TreeView
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected tree2 As Telerik.WebControls.RadTreeView
      Protected tree1 As Telerik.WebControls.RadTreeView
      Protected WithEvents RadCallback2 As Telerik.WebControls.RadCallback
      Protected tbNodeText As System.Web.UI.WebControls.TextBox
      Protected WithEvents btnRename As Telerik.WebControls.CallbackButton
      Protected WithEvents btnAddChild As Telerik.WebControls.CallbackButton
      Protected WithEvents btnAddRoot As Telerik.WebControls.CallbackButton
      Protected tbNewNodeText As System.Web.UI.WebControls.TextBox
      Protected WithEvents btnToggleExpand As Telerik.WebControls.CallbackButton
      Protected ddlSkin As Telerik.WebControls.CallbackDropDownList
      Protected WithEvents lbSourceTree2 As Telerik.WebControls.CallbackListBox
      Protected WithEvents lbSourceTree1 As Telerik.WebControls.CallbackListBox
      Protected WithEvents btnRemove As Telerik.WebControls.CallbackButton
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
      Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            LoadTree1()
            LoadTree2()
            tree1.ExpandAllNodes()
            tree2.ExpandAllNodes()
         End If
      End Sub 'Page_Load
      
      
      Private Function CheckTextBox(button As CallbackButton, textBox As TextBox) As Boolean
         If textBox.Text.Length = 0 Then
            button.Alert("Text for the node is required!")
            textBox.BackColor = Color.Yellow
            Return False
         Else
            textBox.BackColor = Color.White
            Return True
         End If
      End Function 'CheckTextBox
      
      
      Private Sub btnAddChild_Click(sender As Object, e As System.EventArgs) Handles btnAddChild.Click
         If tree1.SelectedNode Is Nothing Then
            btnAddChild.Alert("Please, select an item!")
         Else
            If CheckTextBox(btnAddChild, tbNewNodeText) Then
               tree1.SelectedNode.AddNode(New RadTreeNode(tbNewNodeText.Text))
               tree1.SelectedNode.ExpandChildNodes()
               tbNewNodeText.Text = String.Empty
            End If
         End If 
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tbNewNodeText)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree1)
      End Sub 'btnAddChild_Click
      
      
      Private Sub btnRemove_Click(sender As Object, e As System.EventArgs) Handles btnRemove.Click
            If (Not (tree2.SelectedNode Is Nothing)) AndAlso (Not tree2.SelectedNode.Equals(tree2.Nodes(0))) Then
                tree2.SelectedNode.Remove()
                tbNodeText.Text = String.Empty
            Else
                If (tree2.SelectedNode Is Nothing) Then
                    btnRemove.Alert("Please, select an item!")
                Else
                    btnRemove.Alert("Root element cannot be removed!")
                End If
            End If
            CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree2)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tbNodeText)
      End Sub 'btnRemove_Click
      
      
      Private Sub AddChilds(dstNode As RadTreeNode, srcNode As RadTreeNode)
         
         Dim srcChildNode As RadTreeNode
         For Each srcChildNode In  srcNode.Nodes
            Dim destChildNode As New RadTreeNode(srcChildNode.Text, srcChildNode.Value)
            dstNode.AddNode(destChildNode)
            AddChilds(destChildNode, srcChildNode)
         Next srcChildNode
      End Sub 'AddChilds
      
      
      Private Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         Dim treeIds As String() = args.CallbackEvent.Split(","c)
         
         Dim srcTree As RadTreeView = Nothing
         Dim dstTree As RadTreeView = Nothing
         
         If tree1.ClientID.Equals(treeIds(0)) Then
            srcTree = tree1
         ElseIf tree2.ClientID.Equals(treeIds(0)) Then
            srcTree = tree2
         End If
         
         If tree1.ClientID.Equals(treeIds(1)) Then
            dstTree = tree1
         ElseIf tree2.ClientID.Equals(treeIds(1)) Then
            dstTree = tree2
         End If
         
         Dim nodeIds As String() = args.Args.Split(","c)
         Dim sourceNode As RadTreeNode = Nothing
         Dim destNode As RadTreeNode = Nothing
         
         sourceNode = srcTree.FindNodeByText(nodeIds(0))
         destNode = dstTree.FindNodeByText(nodeIds(1))
         
         If sourceNode.Parent Is Nothing Then
            CType(sender, Telerik.WebControls.RadCallback).Alert("Cannot move the root node")
            Return
         End If
         Dim tempNode As RadTreeNode = destNode
         While Not (tempNode Is Nothing) And Not tempNode.Equals(sourceNode)
            tempNode = tempNode.Parent
         End While
         If Not (tempNode Is Nothing) Then
            CType(sender, Telerik.WebControls.RadCallback).Alert("Cannot move a node to its child")
            Return
         End If
         Dim newNode As New RadTreeNode(sourceNode.Text, sourceNode.Value)
         AddChilds(newNode, sourceNode)
         destNode.AddNode(newNode)
         destNode.ExpandChildNodes()
         If Not sourceNode.Equals(srcTree.Nodes(0)) Then
            sourceNode.Remove()
         End If
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tree1)
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tree2)
      End Sub 'RadCallback1_Callback
      
      
      Private Sub RadCallback2_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback2.Callback
         tree2.ClearSelectedNodes()
         Dim node As RadTreeNode = tree2.FindNodeByText(args.Args)
         node.Selected = True
         tbNodeText.Text = args.Args
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tbNodeText)
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tree2)
      End Sub 'RadCallback2_Callback
      
      
      Private Sub btnRename_Click(sender As Object, e As System.EventArgs) Handles btnRename.Click
         If CheckTextBox(btnRename, tbNodeText) Then
            If Not (tree2.SelectedNode Is Nothing) Then
               tree2.SelectedNode.Text = tbNodeText.Text
               tbNodeText.Text = String.Empty
            End If
         End If
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree2)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tbNodeText)
      End Sub 'btnRename_Click
      
      
      Private Sub btnAddRoot_Click(sender As Object, e As System.EventArgs) Handles btnAddRoot.Click
         If CheckTextBox(btnAddRoot, tbNewNodeText) Then
            tree1.Nodes.Add(New RadTreeNode(tbNewNodeText.Text))
            tbNewNodeText.Text = String.Empty
         End If
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tbNewNodeText)
      End Sub 'btnAddRoot_Click
       
      
      Private Sub btnToggleExpand_Click(sender As Object, e As System.EventArgs) Handles btnToggleExpand.Click
         If btnToggleExpand.Text.Equals("Collapse All Nodes") Then
            btnToggleExpand.Text = "Expand All Nodes"
            tree1.CollapseAllNodes()
            tree2.CollapseAllNodes()
         Else
            btnToggleExpand.Text = "Collapse All Nodes"
            tree1.ExpandAllNodes()
            tree2.ExpandAllNodes()
         End If
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tree2)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(btnToggleExpand)
      End Sub 'btnToggleExpand_Click
      
      
      Protected Sub ddlSkin_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         If ddlSkin.SelectedIndex = 0 Then
            tree1.Skin = "MSDN/Blue"
            tree2.Skin = "MSDN/Blue"
         ElseIf ddlSkin.SelectedIndex = 1 Then
            tree1.Skin = "MSDN/Classic"
            tree2.Skin = "MSDN/Classic"
         Else
            tree1.Skin = "Round/3DBlue"
            tree2.Skin = "Round/3DBlue"
         End If
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(tree1)
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(tree2)
      End Sub 'ddlSkin_SelectedIndexChanged
      
      
      Private Sub GenerateTreeView(tree As RadTreeView)
         tree.Nodes.Clear()
         Dim currentTime As New RadTreeNode("Current Time")
         tree.AddNode(currentTime)
         
         Dim currentHour As New RadTreeNode("Hour : " + System.DateTime.Now.Hour.ToString())
         currentTime.AddNode(currentHour)
         Dim currentMin As New RadTreeNode("Minute : " + System.DateTime.Now.Minute.ToString())
         currentTime.AddNode(currentMin)
         Dim currentSec As New RadTreeNode("Second : " + System.DateTime.Now.Second.ToString())
         currentTime.AddNode(currentSec)
         
         Dim currentDate As New RadTreeNode("Current Date")
         tree.AddNode(currentDate)
         
         Dim currentYear As New RadTreeNode("Year : " + System.DateTime.Now.Year.ToString())
         currentDate.AddNode(currentYear)
         Dim currentMonth As New RadTreeNode("Month : " + System.DateTime.Now.Month.ToString())
         currentDate.AddNode(currentMonth)
         Dim currentDay As New RadTreeNode("Day: " + System.DateTime.Now.Day.ToString())
         currentDate.AddNode(currentDay)
      End Sub 'GenerateTreeView
      
      
      Private Sub LoadTreeView2(tree As RadTreeView)
         tree.Nodes.Clear()
         Dim dbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Tree.mdb"))
         dbCon.Open()
         
         Dim adapter As New OleDbDataAdapter("SELECT * FROM Links", dbCon)
         Dim ds As New DataSet()
         adapter.Fill(ds)
         
         tree.DataFieldID = "id"
         tree.DataFieldParentID = "parentId"
         
         tree.DataSource = ds
         tree.DataMember = "Links"
         tree.DataTextField = "Text"
         tree.DataBind()
      End Sub 'LoadTreeView2
      
      
      Private Sub LoadTree1()
         If lbSourceTree1.SelectedIndex = 0 Then
            GenerateTreeView(tree1)
         ElseIf lbSourceTree1.SelectedIndex = 1 Then
            LoadTreeView2(tree1)
         Else
            tree1.LoadContentFile("tree.xml")
         End If
         tree1.ExpandAllNodes()
      End Sub 'LoadTree1
      
      
      Private Sub LoadTree2()
         If lbSourceTree2.SelectedIndex = 0 Then
            GenerateTreeView(tree2)
         ElseIf lbSourceTree2.SelectedIndex = 1 Then
            LoadTreeView2(tree2)
         Else
            tree2.LoadContentFile("tree.xml")
         End If
         tree2.ExpandAllNodes()
      End Sub 'LoadTree2
      
      
      Private Sub lbSource_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lbSourceTree1.SelectedIndexChanged
         LoadTree1()
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(tree1)
      End Sub 'lbSource_SelectedIndexChanged
      
      
      Private Sub lbSourceTree2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lbSourceTree2.SelectedIndexChanged
         LoadTree2()
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(tree2)
      End Sub 'lbSourceTree2_SelectedIndexChanged
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.TreeView