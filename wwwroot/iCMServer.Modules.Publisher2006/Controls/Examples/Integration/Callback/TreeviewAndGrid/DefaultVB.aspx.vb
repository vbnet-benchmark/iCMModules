
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackIntegarationExamplesVBNET.TreeviewAndGrid
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      Protected callbackOutlook As Telerik.WebControls.RadCallback
      Protected treeFolders As Telerik.WebControls.RadTreeView
      Protected WithEvents RadGrid1 As Telerik.WebControls.RadGrid
      Protected labelFrom As System.Web.UI.WebControls.Label
      Protected labelSubject As System.Web.UI.WebControls.Label
      Protected labelDate As System.Web.UI.WebControls.Label
      Protected labelMessage As System.Web.UI.WebControls.Label
      
      
      
      
      Private Property dataSource() As DataSet
         Get
            Return CType(Session("dataSource"), DataSet)
         End Get
         Set
            Session("dataSource") = value
         End Set
      End Property 
      
      Private Property folderName() As String
         Get
            Return CStr(Session("folderName"))
         End Get
         Set
            Session("folderName") = value
         End Set
      End Property
       
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not IsPostBack Then
            folderName = "inbox"
            Session("dataSource") = New DataSet()
            Dim MyOleDbConnection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath((Request.FilePath.Substring(0, Request.FilePath.LastIndexOf("/"c)) + "/Mail.mdb")))
            Dim MyOleDbDataAdapter As New OleDbDataAdapter()
            MyOleDbDataAdapter.SelectCommand = New OleDbCommand("Select * from Mails", MyOleDbConnection)
            MyOleDbConnection.Open()
            Try
               MyOleDbDataAdapter.Fill(dataSource)
            Finally
               MyOleDbConnection.Close()
            End Try
         End If
      End Sub 'Page_Load
      
      Private Sub RadGrid1_NeedDataSource([source] As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
         If Not (dataSource Is Nothing) Then
            RadGrid1.DataSource = dataSource.Tables(0)
            RadGrid1.MasterTableView.FilterExpression = "FolderName = '" + folderName + "'"
            RadGrid1.MasterTableView.DataKeyNames = New String() {"mailID"}
         Else
            labelMessage.Text = "<div style='color:red;'>Your session has expired. Please reload the page.</div>"
         End If
      End Sub 'RadGrid1_NeedDataSource
      
      Private Sub GetMessage(mailID As Integer)
         If Not (dataSource Is Nothing) Then
            Dim dtRows As DataRow() = dataSource.Tables(0).Select(("mailID = '" + mailID.ToString() + "'"))
            If dtRows.Length > 0 Then
               labelFrom.Text = CStr(dtRows(0)("Name")) + " (" + CStr(dtRows(0)("From")) + ")"
               labelDate.Text = CType(dtRows(0)("Received"), DateTime).ToString("MM/dd/yyyy")
               labelSubject.Text = CStr(dtRows(0)("Subject"))
               labelMessage.Text = CStr(dtRows(0)("Content"))
            Else
               labelFrom.Text = [String].Empty
               labelDate.Text = [String].Empty
               labelSubject.Text = [String].Empty
               labelMessage.Text = [String].Empty
            End If
         Else
            labelMessage.Text = "<div style='color:red;'>Your session has expired. Please reload the page.</div>"
         End If
      End Sub 'GetMessage
      
      Private Function GetDataKey(grid As Telerik.WebControls.RadGrid, rowIndex As Integer) As Integer
         Dim item As Telerik.WebControls.GridItem = CType(CType(grid.MasterTableView.Controls(0), System.Web.UI.WebControls.Table).Rows(rowIndex), Telerik.WebControls.GridItem)
         
         Return CInt(grid.MasterTableView.DataKeyValues(item.ItemIndex)("mailID"))
      End Function 'GetDataKey
      
      Protected Sub outlookCallback_Callback(sender As Object, e As Telerik.WebControls.CallbackEventArgs)
         Select Case e.CallbackEvent
            Case "OpenFolder"
               folderName = e.Args
               RadGrid1.CurrentPageIndex = 0
               RadGrid1.Rebind()
               labelFrom.Text = [String].Empty
               labelDate.Text = [String].Empty
               labelSubject.Text = [String].Empty
               labelMessage.Text = [String].Empty
               CType(sender, RadCallback).ControlsToUpdate.Add(RadGrid1)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelMessage)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelFrom)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelDate)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelSubject)
            Case "OpenMail"
               Dim mailID As Integer = GetDataKey(RadGrid1, Integer.Parse(e.Args))
               GetMessage(mailID)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelMessage)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelFrom)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelDate)
               CType(sender, RadCallback).ControlsToUpdate.Add(labelSubject)
            Case Else
         End Select
      End Sub 'outlookCallback_Callback
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
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.TreeviewAndGrid