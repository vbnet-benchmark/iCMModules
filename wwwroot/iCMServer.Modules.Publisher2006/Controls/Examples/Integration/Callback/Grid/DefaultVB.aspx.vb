
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing


Namespace Telerik.CallbackIntegrationExamplesVBNET.Grid
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      
      Protected WithEvents RadGrid1 As Telerik.WebControls.RadGrid
      Protected CallbackPanel1 As Telerik.WebControls.CallbackPanel
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected WithEvents CallbackRadioButtonList1 As Telerik.WebControls.CallbackRadioButtonList
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs)
         If Not Page.IsPostBack Then
            If CallbackRadioButtonList1.SelectedIndex = 0 Then
               RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms
            Else
               RadGrid1.MasterTableView.EditMode = GridEditMode.InPlace
            End If
            RadGrid1.Rebind()
         End If
      End Sub 'Page_Load
      
      
      Private Sub RadGrid1_NeedDataSource([source] As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
         Dim MyOleDbConnection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("Nwind.mdb"))
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
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/        Required method for Designer support - do not modify
      '/        the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      Private Sub CallbackRadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CallbackRadioButtonList1.SelectedIndexChanged
         If CallbackRadioButtonList1.SelectedIndex = 0 Then
            RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms
         Else
            RadGrid1.MasterTableView.EditMode = GridEditMode.InPlace
         End If
         RadGrid1.Rebind()
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(RadGrid1)
      End Sub 'CallbackRadioButtonList1_SelectedIndexChanged
   End Class 'DefaultVB 
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Grid