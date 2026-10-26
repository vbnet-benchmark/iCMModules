
Imports System
Imports System.Collections
Imports System.IO
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports Telerik.WebControls
Imports System.Web.UI.WebControls
Imports Telerik.QuickStart


Namespace Telerik.GridExamplesVBNET.Integration.GridAndTreeView
   
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents RadTree1 As RadTreeView
      Protected WithEvents RadGrid1 As RadGrid
      Protected genericCallback As RadCallback
      
      
      Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         If Not IsPostBack Then
            LoadTreeView(Server.MapPath("~/Controls/Examples/Integration"))
         End If
      End Sub 'Page_Load
      
      
      
      Private Sub LoadGrid(directory As String)
         Dim dir As New DirectoryInfo(directory)
         Dim filesAndFolders As New DataTable()
         filesAndFolders.Columns.Add("Name")
         filesAndFolders.Columns.Add("Size")
         filesAndFolders.Columns.Add("FullPath")
         Dim subDir As DirectoryInfo
         For Each subDir In  dir.GetDirectories()
            filesAndFolders.Rows.Add(New String() {subDir.Name, "-1", subDir.FullName})
         Next subDir
         Dim file As FileInfo
         For Each file In  dir.GetFiles()
            filesAndFolders.Rows.Add(New String() {file.Name, file.Length.ToString(), file.FullName})
         Next file
         
         RadGrid1.DataSource = filesAndFolders
      End Sub 'LoadGrid
      
      
      
      Private Sub LoadTreeView(folder As String)
         Dim rootNode As New RadTreeNode(folder)
         rootNode.Image = "Folder.gif"
         rootNode.Expanded = True
         rootNode.Category = "Folder"
         rootNode.Value = folder
         RadTree1.AddNode(rootNode)
         
         BindDirectory(folder, rootNode.Nodes)
         
         RadTree1.LoadingMessagePosition = LoadingMessagePosition.BeforeNodeText
         RadTree1.LoadingMessageCssClass = "LoadingMessageBlue"
         RadTree1.LoadingMessage = "(loading ..)"
      End Sub 'LoadTreeView
      
      
      
      Protected Sub RadTree1_NodeExpand(o As Object, e As RadTreeNodeEventArgs) Handles RadTree1.NodeExpand
         Dim folderNode As RadTreeNode = e.NodeClicked
         Dim path As String = folderNode.Value
         folderNode.Nodes.Clear()
         BindDirectory(path, folderNode.Nodes)
      End Sub 'RadTree1_NodeExpand
      
      
      
      Private Sub BindDirectory(dirPath As String, collection As RadTreeNodeCollection)
         Dim dirs As String() = Directory.GetDirectories(dirPath)
         Dim path As String
         For Each path In  dirs
            Dim parts As String() = path.Split("\"c)
            Dim name As String = parts((parts.Length - 1))
            Dim node As New RadTreeNode(name)
            node.Image = "Folder.gif"
            node.Value = path
            node.Category = "Folder"
            
            If Directory.GetDirectories(path).Length > 0 Then
               node.ExpandMode = ExpandMode.ServerSideCallBack
            End If
            collection.Add(node)
         Next path
      End Sub 'BindDirectory
      
      
      
      Private Function GetImageForExtension(fileName As String) As String
         Dim image As String = "File.gif"
         Select Case Path.GetExtension(fileName)
            Case ".cs"
               image = "cs.gif"
            Case ".css"
               image = "css.gif"
            Case ".html"
               image = "html.gif"
            Case ".resx"
               image = "resx.gif"
            Case ".vb"
               image = "vb.gif"
            Case ".xml"
               image = "xml.gif"
            Case ".ascx"
               image = "ascx.gif"
            Case ".gif", ".jpg"
               image = "gif.gif"
            Case ""
               image = "folder.gif"
         End Select
         Return image
      End Function 'GetImageForExtension
      
      
      
      Private Function GridItemSelected(path As String) As Boolean
         If System.IO.Directory.Exists(path) Then
            Dim node As RadTreeNode = RadTree1.FindNodeByValue(path)
            Dim tempNode As RadTreeNode = Nothing
            
            If node Is Nothing And RadTree1.Nodes.Count > 0 Then
               node = RadTree1.Nodes(0)
               Dim dirParts As String = path.Replace(node.Value, "")
               If dirParts.StartsWith("\") Then
                  dirParts = dirParts.Remove(0, 1)
               End If 
               Dim folder As String
               For Each folder In  dirParts.Split("\"c)
                  tempNode = RadTree1.FindNodeByValue((node.Value + "\" + folder))
                  If tempNode Is Nothing Then
                     BindDirectory(node.Value, node.Nodes)
                     node = RadTree1.FindNodeByValue((node.Value + "\" + folder))
                  Else
                     node = tempNode
                  End If
               Next folder
            End If
            
            If Not (node Is Nothing) Then
               BindDirectory(path, node.Nodes)
               node.Expanded = True
               If Not (RadTree1.SelectedNode Is Nothing) Then
                  RadTree1.SelectedNode.Selected = False
               End If
               node.Selected = True
               node.ExpandParentNodes()
               LoadGrid(path)
               RadGrid1.DataBind()
            End If
         ElseIf System.IO.File.Exists(path) Then
            'do something with the file
            'currently nothing to do so we return false and do not update anything
            Return False
         End If
         Return True
      End Function 'GridItemSelected
      
      
      
      Protected Sub genericCallback_Callback(o As Object, e As CallbackEventArgs)
         Select Case e.CallbackEvent
            Case "NodeClick"
               LoadGrid(e.Args)
               RadGrid1.DataBind()
               genericCallback.ControlsToUpdate.Add(RadGrid1)
            Case "GridDblClick"
               Dim itemIndex As Integer = Integer.Parse(e.Args)
               Dim item As GridItem = CType(CType(RadGrid1.MasterTableView.Controls(0), Table).Rows(itemIndex), GridItem)
               Dim fullPath As String = CType(item.FindControl("pathLabel"), Label).Text
               If GridItemSelected(fullPath) Then
                  genericCallback.ControlsToUpdate.Add(RadTree1)
                  genericCallback.ControlsToUpdate.Add(RadGrid1)
               End If
            Case Else
         End Select
      End Sub 'genericCallback_Callback
      
      
      
      Protected Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
         If TypeOf e.Item Is GridDataItem Then
            Dim icon As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("icon"), System.Web.UI.WebControls.Image)
            icon.ImageUrl = RadTree1.ImagesBaseDir + GetImageForExtension(CStr(DataBinder.Eval(e.Item.DataItem, "Name")))
            icon.AlternateText = "icon"
            'icon.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsMiddle;
            icon.Style.Add("vertical-align", "middle")
            icon.BorderWidth = Unit.Pixel(0)
            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)
            
            Dim fileLength As String = CStr(DataBinder.Eval(e.Item.DataItem, "Size"))
            If fileLength <> "-1" Then
               dataItem("Size").Text = fileLength
            Else
               dataItem("Size").Text = ""
            End If
         End If
      End Sub 'RadGrid1_ItemDataBound
       
      
      Protected Sub RadGrid1_NeedDataSource([source] As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
         If Not (RadTree1.SelectedNode Is Nothing) Then
            LoadGrid(RadTree1.SelectedNode.Value)
         Else
            LoadGrid(Server.MapPath("~/Controls/Examples/Integration"))
         End If
      End Sub 'RadGrid1_NeedDataSource
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
End Namespace 'Telerik.GridExamplesVBNET.Integration.GridAndTreeView