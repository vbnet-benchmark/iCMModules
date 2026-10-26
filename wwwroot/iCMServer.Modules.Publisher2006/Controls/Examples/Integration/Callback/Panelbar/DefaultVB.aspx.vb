
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


Namespace Telerik.CallbackIntegrationExamplesVBNET.Panelbar
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected RadPanelbar1 As Telerik.WebControls.RadPanelbar
      
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected WithEvents RadPanelbar2 As Telerik.WebControls.RadPanelbar
      Protected WithEvents ddlDataSource As Telerik.WebControls.CallbackDropDownList
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
      Private Function GetPanelbarControl(ID As String) As Control
         Return RadPanelbar1.FindControl(ID)
      End Function 'GetPanelbarControl
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            LoadData()
         End If
      End Sub 'Page_Load
      
      
      Private Sub LoadFromContentFile(panelbar As RadPanelbar)
         RadPanelbar2.AfterClientPanelItemClicked = "itemClick"
         RadPanelbar2.LoadContentFromXmlFile("panelbar.xml")
      End Sub 'LoadFromContentFile
      
      
      Private Sub LoadFromDatabase(panelbar As RadPanelbar)
         RadPanelbar2.AfterClientPanelItemClicked = String.Empty
         Dim OldDbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath("Panelbar.mdb") + ";User ID=;Password=;")
         Dim adpPanelBar As New OleDbDataAdapter("SELECT * FROM Panelbar", OldDbCon)
         Dim dsPanelBar As New DataSet()
         adpPanelBar.Fill(dsPanelBar)
         panelbar.DataFieldID = "ID"
         panelbar.DataFieldParentID = "ParentID"
         panelbar.DataSource = dsPanelBar
         panelbar.DataBind()
      End Sub 'LoadFromDatabase
      
      
      Private Sub LoadData()
         
         If ddlDataSource.SelectedIndex = 0 Then
            LoadFromContentFile(RadPanelbar2)
         Else
            LoadFromDatabase(RadPanelbar2)
         End If
         Dim item As PanelItem
         For Each item In  RadPanelbar2.PanelItems
            item.SubGroupCssClass = "panelbarItemGroup"
         Next item
      End Sub 'LoadData
      
      
      
      
      Protected Sub btnCallbackSubmit_Click(sender As Object, e As System.EventArgs)
         Dim label As Label = CType(RadPanelbar1.FindControl("lSubmittedText"), Label)
         Dim textBox As TextBox = CType(RadPanelbar1.FindControl("tbTextToSubmit"), TextBox)
         
         Dim [text] As String = textBox.Text
         If [text].Length = 0 Then
            [text] = "[empty]"
            textBox.BackColor = Color.Yellow
         Else
            textBox.BackColor = Color.White
         End If
         label.Text = [text]
         textBox.Text = String.Empty
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(RadPanelbar1)
      End Sub 'btnCallbackSubmit_Click
      
      
      Protected Sub clbSelectedItems_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim label As Label = CType(GetPanelbarControl("lSelectedItems"), Label)
         Dim callbackCheckListBox As CallbackCheckBoxList = CType(GetPanelbarControl("cblSelectedItems"), CallbackCheckBoxList)
         Dim [text] As String = String.Empty
         Dim item As ListItem
         For Each item In  callbackCheckListBox.Items
            If item.Selected Then
               [text] += item.Text + " "
            End If
         Next item
         If [text].Length = 0 Then
            [text] = "[No Selected Items]"
         End If
         label.Text = [text]
         CType(sender, Telerik.WebControls.CallbackCheckBoxList).ControlsToUpdate.Add(RadPanelbar1)
      End Sub 'clbSelectedItems_SelectedIndexChanged
      
      
      Protected Sub lbItems_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim listBox As CallbackListBox = CType(GetPanelbarControl("lbItems"), CallbackListBox)
         Dim label As Label = CType(GetPanelbarControl("lSelectedItems2"), Label)
         Dim [text] As String = String.Empty
         Dim item As ListItem
         For Each item In  listBox.Items
            If item.Selected Then
               [text] += item.Text + " "
            End If
         Next item
         If [text].Length = 0 Then
            [text] = "[No Selected Items]"
         End If
         label.Text = [text]
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(RadPanelbar1)
      End Sub 'lbItems_SelectedIndexChanged
      
      
      Private Sub RadPanelbar2_PanelItemDataBound(sender As Object, e As Telerik.WebControls.RadPanelbarPanelItemDataBoundEventArgs) Handles RadPanelbar2.PanelItemDataBound
         If Not e.DataBoundDataRow.IsNull("Label") Then
            e.DataBoundPanelItem.Text = e.DataBoundDataRow("Label").ToString()
         End If
      End Sub 'RadPanelbar2_PanelItemDataBound
       
      Private Sub ddlDataSource_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDataSource.SelectedIndexChanged
         LoadData()
         ddlDataSource.ControlsToUpdate.Add(RadPanelbar2)
      End Sub 'ddlDataSource_SelectedIndexChanged
      
      
      Private Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         Dim item As PanelItem = RadPanelbar2.FindPanelItemById(args.Args)
         
         If Not (item Is Nothing) Then
            Select Case item.Value
               Case "Remove"
                  Dim parent As PanelItem = CType(item.ParentItem, PanelItem)
                  parent.PanelItems.Remove(item)
               Case "Disable"
                  item.Enabled = False
                  RadPanelbar2.SelectedPanelItem = Nothing
               Case "Add"
                  Dim newItem As New PanelItem(RadPanelbar2.PanelItems(2), RadPanelbar2)
                  newItem.ID = "Panel3_" + RadPanelbar2.PanelItems(2).PanelItems.Count.ToString() + "2"
                  newItem.Text = "Copy of " + item.Text
                  RadPanelbar2.PanelItems(2).PanelItems.Add(newItem)
                  RadPanelbar1.SelectedPanelItem = Nothing
               Case Else
                  RadCallback1.Alert("Action canceled!")
            End Select
            RadCallback1.ControlsToUpdate.Add(RadPanelbar2)
         End If
      End Sub 'RadCallback1_Callback
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Panelbar