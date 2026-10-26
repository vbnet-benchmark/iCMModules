
Imports System
Imports System.Collections
Imports System.Web.UI.WebControls
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.TabStripExamplesVBNET.Integration.Explorer
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected genericCallback As Telerik.WebControls.RadCallback
      Protected RadTreeView1 As Telerik.WebControls.RadTreeView
      Protected panelLoadingImage As System.Web.UI.WebControls.Panel
      Protected RadTabStrip1 As Telerik.WebControls.RadTabStrip
      Protected TextBoxTo As System.Web.UI.WebControls.TextBox
      Protected SendEmail As Telerik.WebControls.CallbackButton
      Protected TextBoxCc As System.Web.UI.WebControls.TextBox
      Protected TextBoxSubject As System.Web.UI.WebControls.TextBox
      Protected Attachments As System.Web.UI.WebControls.Label
      Protected Page1 As Telerik.WebControls.PageView
      Protected RadTreeView2 As Telerik.WebControls.RadTreeView
      Protected Page2 As Telerik.WebControls.PageView
      Protected DataGrid1 As System.Web.UI.WebControls.DataGrid
      Protected Page3 As Telerik.WebControls.PageView
      Protected multiPageContent As Telerik.WebControls.RadMultiPage
      
      
      Private Property GridData() As ArrayList
         Get
            Return CType(Session("GridDataArray"), ArrayList)
         End Get
         Set
            Session("GridDataArray") = value
         End Set
      End Property
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            GridData = New ArrayList()
            GridData.Add("App_Themes")
            GridData.Add("bin")
            GridData.Add("RadControls")
            DataGrid1.DataSource = GridData
            DataGrid1.DataBind()
         End If
      End Sub 'Page_Load
      
      
      Protected Sub SendEmail_Click(sender As Object, e As System.EventArgs)
         TextBoxTo.Text = [String].Empty
         TextBoxCc.Text = [String].Empty
         TextBoxSubject.Text = [String].Empty
         Attachments.Text = [String].Empty
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(TextBoxTo)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(TextBoxCc)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(TextBoxSubject)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(Attachments)
      End Sub 'SendEmail_Click
      
      
      Protected Sub genericCallback_Callback(sender As Object, e As Telerik.WebControls.CallbackEventArgs)
         Dim args As String() = e.Args.Split(ControlChars.Lf)
         Dim sourceNode As RadTreeNode = Nothing
         Dim destNode As RadTreeNode = Nothing
         If args.Length > 0 Then
            sourceNode = GetNodeByClientId(RadTreeView1, args(0))
         Else
            Return
         End If
         Select Case e.CallbackEvent
            Case "TreeDropPage1"
               Attachments.Text += sourceNode.Text + "<br />"
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(Attachments)
               Me.RadTabStrip1.SelectedIndex = 0
               Me.multiPageContent.SelectedIndex = 0
            Case "TreeDropPage2"
               If args.Length > 1 Then
                  destNode = GetNodeByClientId(RadTreeView2, args(1))
                  If Not (destNode Is Nothing) Then
                     Dim newNode As New RadTreeNode(sourceNode.Text)
                     newNode.Image = "SSFolder.gif"
                     destNode.Nodes.Add(newNode)
                     destNode.Expanded = True
                  End If
               Else
                  Dim newNode As New RadTreeNode(sourceNode.Text)
                  newNode.Image = "SSFolder.gif"
                  RadTreeView2.Nodes(0).Nodes.Add(newNode)
               End If
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(RadTreeView2)
               Me.RadTabStrip1.SelectedIndex = 1
               Me.multiPageContent.SelectedIndex = 1
            Case "TreeDropPage3"
               GridData.Add(sourceNode.Text)
               DataGrid1.DataSource = GridData
               DataGrid1.DataBind()
               Me.RadTabStrip1.SelectedIndex = 2
               Me.multiPageContent.SelectedIndex = 2
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(DataGrid1)
            Case Else
         End Select
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(RadTabStrip1)
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(multiPageContent)
      End Sub 'genericCallback_Callback
      
      
      Private Function GetNodeByClientId(treeView As RadTreeView, nodeId As String) As RadTreeNode
         Dim node As RadTreeNode
         For Each node In  treeView.GetAllNodes()
            If node.ClientID = nodeId Then
               Return node
            End If
         Next node
         Return Nothing
      End Function 'GetNodeByClientId
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
End Namespace 'Telerik.TabStripExamplesVBNET.Integration.Explorer