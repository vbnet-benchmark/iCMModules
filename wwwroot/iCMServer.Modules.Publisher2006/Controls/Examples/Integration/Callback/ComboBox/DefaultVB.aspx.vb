
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing


Namespace Telerik.CallbackIntegrationExamplesVBNET.ComboBox
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      
      Protected tbNewItem As System.Web.UI.WebControls.TextBox
      Protected WithEvents btnAddNewItem As Telerik.WebControls.CallbackButton
      Protected WithEvents btnRemoveItem As Telerik.WebControls.CallbackButton
      Protected lblStatus As System.Web.UI.WebControls.Label
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected RadComboBox1 As Telerik.WebControls.RadComboBox
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected WithEvents rblSkin As Telerik.WebControls.CallbackRadioButtonList
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected WithEvents CallbackDropDownList1 As Telerik.WebControls.CallbackDropDownList
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
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
      Private Sub LoadData(category As Integer)
         If category = 0 Then
            RadComboBox1.Items.Clear()
            RadComboBox1.Text = [String].Empty
            Return
         End If
         Dim path As String = Server.MapPath("Countries.mdb")
         Dim dbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path)
         dbCon.Open()
         
         
         Dim adapter As OleDbDataAdapter = Nothing
         
         If category = 1 Then
            adapter = New OleDbDataAdapter("SELECT * FROM Continents ORDER BY Name", dbCon)
         ElseIf category = 2 Then
            adapter = New OleDbDataAdapter("SELECT * FROM Countries ORDER BY Name", dbCon)
         Else
            adapter = New OleDbDataAdapter("SELECT * FROM Cities ORDER BY Name", dbCon)
         End If
         
         Dim dt As New DataTable()
         adapter.Fill(dt)
         dbCon.Close()
         
         RadComboBox1.DataTextField = "Name"
         RadComboBox1.DataValueField = "ID"
         RadComboBox1.DataSource = dt
         RadComboBox1.DataBind()
         RadComboBox1.Text = [String].Empty
         
         ' RadComboBox1.Items.Insert(0, new RadComboBoxItem("- Select a continent -"));            
         Dim item As RadComboBoxItem
         For Each item In  RadComboBox1.Items
            item.ToolTip = item.Text
         Next item
      End Sub 'LoadData
       
      
      Private Sub UpdateStatusLabel()
         lblStatus.Text = "Combo has " + RadComboBox1.Items.Count.ToString() + " items."
      End Sub 'UpdateStatusLabel
      
      
      Private Sub btnAddNewItem_Click(sender As Object, e As System.EventArgs) Handles btnAddNewItem.Click
         If tbNewItem.Text.Length = 0 Then
            btnAddNewItem.Alert("Please, enter some text.")
            tbNewItem.BackColor = Color.Yellow
            Return
         End If
         RadComboBox1.Items.Add(New RadComboBoxItem(tbNewItem.Text))
         tbNewItem.Text = String.Empty
         btnRemoveItem.Enabled = True
         tbNewItem.BackColor = Color.White
         RadComboBox1.SelectedIndex = RadComboBox1.Items.Count - 1
         UpdateStatusLabel()
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(RadComboBox1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(lblStatus)
      End Sub 'btnAddNewItem_Click
      
      
      Private Sub btnRemoveItem_Click(sender As Object, e As System.EventArgs) Handles btnRemoveItem.Click
         If Not (RadComboBox1.SelectedItem Is Nothing) Then
            RadComboBox1.Items.Remove(RadComboBox1.SelectedIndex)
            tbNewItem.Text = String.Empty
            If RadComboBox1.Items.Count = 0 Then
               btnRemoveItem.Enabled = False
            End If 
         Else
            btnAddNewItem.Alert("Please, select an item!")
         End If
         RadComboBox1.Text = [String].Empty
         UpdateStatusLabel()
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(RadComboBox1)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(lblStatus)
      End Sub 'btnRemoveItem_Click
       
      
      
      Private Sub CallbackDropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CallbackDropDownList1.SelectedIndexChanged
         LoadData(CallbackDropDownList1.SelectedIndex)
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(RadComboBox1)
      End Sub 'CallbackDropDownList1_SelectedIndexChanged
      
      
      Private Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         tbNewItem.Text = args.Args
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tbNewItem)
      End Sub 'RadCallback1_Callback
      
      
      Private Sub rblSkin_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblSkin.SelectedIndexChanged
         RadComboBox1.Skin = rblSkin.SelectedItem.Value
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(RadComboBox1)
      End Sub 'rblSkin_SelectedIndexChanged
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.ComboBox