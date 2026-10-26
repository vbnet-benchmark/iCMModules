
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Namespace Telerik.ToolbarExamplesVB.Integration.ToolbarAndComboAndMenu
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits System.Web.UI.Page
      Protected RadComboBox3 As Telerik.WebControls.RadComboBox
      Protected dockObjectToolbar As Telerik.WebControls.RadDockableObject
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         ' Put user code to initialize the page here
         If Not IsPostBack Then
            LoadDealers([String].Empty)
         End If
      End Sub 'Page_Load
      
      
      Private Sub LoadDealers(filter As String)
         Dim mdbPath As String = Server.MapPath("~/Combobox/Data/NWind.mdb")
         Dim dbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath)
         dbCon.Open()
         
         Dim sql As String = "SELECT * from Customers"
         If filter <> [String].Empty Then
            sql += " WHERE CompanyName LIKE '" + filter + "%'"
         End If
         
         Dim adapter As New OleDbDataAdapter(sql, dbCon)
         Dim dt As New DataTable()
         adapter.Fill(dt)
         dbCon.Close()
         Dim tb As Telerik.WebControls.RadToolbar = CType(dockObjectToolbar.FindControl("toolbarTop"), Telerik.WebControls.RadToolbar)
         Dim bt As Telerik.WebControls.RadToolbarTemplateButton = CType(tb.Items.TemplatedButtons(0), Telerik.WebControls.RadToolbarTemplateButton)
         Dim cb As Telerik.WebControls.RadComboBox = CType(bt.FindControl("RadComboBox3"), Telerik.WebControls.RadComboBox)
         cb.DataSource = dt
         cb.DataBind()
      End Sub 'LoadDealers
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
End Namespace 'Telerik.ToolbarExamplesVB.Integration.ToolbarAndComboAndMenu