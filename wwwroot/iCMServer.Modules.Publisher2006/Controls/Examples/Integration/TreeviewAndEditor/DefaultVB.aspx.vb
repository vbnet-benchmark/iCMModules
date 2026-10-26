
Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndEditor
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected RadTreeView1 As RadTreeView
      Protected RadEditor1 As RadEditor
      
      
      Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         If Not IsPostBack Then
            PopulateTreeViewFromDirectory(RadTreeView1.Nodes, Server.MapPath("~/Editor/Img/UserDir"))
            RadTreeView1.Nodes(0).Expanded = True
         End If
      End Sub 'Page_Load
      
      
      Private Sub PopulateTreeViewFromDirectory(nodes As RadTreeNodeCollection, _path As String)
         Dim _directories As String() = Directory.GetDirectories(_path)
         Dim _directory As String
         For Each _directory In  _directories
            Dim node As New RadTreeNode()
            node.Text = Path.GetFileName(_directory)
            node.Image = "folder.gif"
            node.Category = "Folder"
            nodes.Add(node)
            PopulateTreeViewFromDirectory(node.Nodes, _directory)
         Next _directory
         Dim _files As String() = Directory.GetFiles(_path)
         Dim _file As String
         For Each _file In  _files
            If IsSupportedFileType(_file) Then
               Dim node As New RadTreeNode()
               node.Text = Path.GetFileName(_file)
               node.Image = Path.GetExtension(_file).Substring(1) + ".gif"
               node.Value = ConvertAbsoluteToRelative(_file)
               nodes.Add(node)
            End If
         Next _file
      End Sub 'PopulateTreeViewFromDirectory
      
      
      Private Function IsSupportedFileType(file As String) As Boolean
         Dim pat As String = "(\.gif|\.jpg|\.jpeg|\.png)$"
         Return Regex.IsMatch(file, pat, RegexOptions.IgnoreCase)
      End Function 'IsSupportedFileType
      
      
      Private Function ConvertAbsoluteToRelative(absolute As String) As String
         Dim relative As String = absolute.Replace(MapPath(Request.ApplicationPath), Request.ApplicationPath)
         Return relative.Replace("\", "/")
      End Function 'ConvertAbsoluteToRelative
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
   End Class 'DefaultVB 
End Namespace 'Telerik.TreeViewExamplesVBNET.Integration.TreeviewAndEditor