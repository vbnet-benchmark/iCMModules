
Imports System
Imports System.Web.UI.WebControls
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.TabStripExamplesVBNET.Integration.TabstripAndTreeView
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected TabStrip1 As RadTabStrip
      Protected RadTree1 As RadTreeView
      Protected Button1 As CallbackButton
      Protected TextBox1 As TextBox
      Protected Label2 As Label
      Protected MultiPage1 As RadMultiPage
      Protected Label1 As Label
      
      
      Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
      
      ' Put user code to initialize the page here
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
         TextBox1 = CType(MultiPage1.FindControl("TextBox1"), TextBox)
         Label1 = CType(MultiPage1.FindControl("Label1"), Label)
         RadTree1 = CType(MultiPage1.FindControl("RadTree1"), RadTreeView)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/		Required method for Designer support - do not modify
      '/		the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      Protected Sub Button1_Click(sender As Object, e As EventArgs)
         Dim node As RadTreeNode = RadTree1.FindNodeByText(TextBox1.Text)
         If Not (node Is Nothing) Then
            If Not (RadTree1.SelectedNode Is Nothing) Then
               RadTree1.SelectedNode.Selected = False
            End If
            
            node.ExpandParentNodes()
            node.Expanded = True
            node.Selected = True
            MultiPage1.SelectedIndex = 1
            TabStrip1.SelectedIndex = 1
         Else
            MultiPage1.SelectedIndex = 0
            TabStrip1.SelectedIndex = 0
            Label1.Text = "No match!"
         End If
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(RadTree1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(TabStrip1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(MultiPage1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(Label1)
      End Sub 'Button1_Click
   End Class 'DefaultVB
End Namespace 'Telerik.TabStripExamplesVBNET.Integration.TabstripAndTreeView