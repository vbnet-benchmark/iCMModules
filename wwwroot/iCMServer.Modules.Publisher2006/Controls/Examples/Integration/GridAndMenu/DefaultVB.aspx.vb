
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


Namespace Telerik.GridExamplesVBNET.Integration.GridAndMenu
   
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents RadMenu1 As Telerik.WebControls.RadMenu
      Protected WithEvents RadGrid1 As Telerik.WebControls.RadGrid
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
      Private Sub RadGrid1_NeedDataSource([source] As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
         Dim MyOleDbConnection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("~/Grid/Data/Access/Nwind.mdb"))
         Dim MyOleDbDataAdapter As New OleDbDataAdapter()
         MyOleDbDataAdapter.SelectCommand = New OleDbCommand("SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, PostalCode FROM Customers", MyOleDbConnection)
         
         Dim myDataTable As New DataTable()
         
         MyOleDbConnection.Open()
         Try
            MyOleDbDataAdapter.Fill(myDataTable)
         Finally
            MyOleDbConnection.Close()
         End Try
         
         RadGrid1.DataSource = myDataTable
      End Sub 'RadGrid1_NeedDataSource
      
      
      Private Sub RadMenu1_ItemClicked(sender As Object, e As ItemEventArgs) Handles RadMenu1.ItemClicked
         Dim radGridClickedRowIndex As Integer
         
         radGridClickedRowIndex = Convert.ToInt32(Request.Form("radGridClickedRowIndex"))
         Select Case e.Item.Text
            Case "Select"
               RadGrid1.Items(radGridClickedRowIndex).Selected = True
            Case "Edit"
               RadGrid1.Items(radGridClickedRowIndex).Edit = True
               RadGrid1.Rebind()
            Case "Word"
               RadGrid1.MasterTableView.ExportToWord("RadGrid")
            Case "Excel"
               RadGrid1.MasterTableView.ExportToExcel("RadGrid")
         End Select
      End Sub 'RadMenu1_ItemClicked
   End Class 'DefaultVB
End Namespace 'Telerik.GridExamplesVBNET.Integration.GridAndMenu