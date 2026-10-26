
Imports System
Imports System.Collections
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace Telerik.CallbackIntegrationExamplesVBNET.TabStrip
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected ddlDataSource As Telerik.WebControls.CallbackDropDownList
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected WithEvents lbActiveTab As Telerik.WebControls.CallbackListBox
      Protected RadMultiPage1 As Telerik.WebControls.RadMultiPage
      Protected RadTabStrip2 As Telerik.WebControls.RadTabStrip
      Protected btnSubmit As Telerik.WebControls.CallbackButton
      Protected tbSubmitText As System.Web.UI.WebControls.TextBox
      Protected lSubmittedText As System.Web.UI.WebControls.Label
      Protected lSelectedItems As System.Web.UI.WebControls.Label
      Protected cblItems As Telerik.WebControls.CallbackCheckBoxList
      Protected lbItems As Telerik.WebControls.CallbackListBox
      Protected llbItems As System.Web.UI.WebControls.Label
      Protected RadTabStrip1 As Telerik.WebControls.RadTabStrip
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            LoadData()
         End If
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
      Private Sub LoadData()
         If ddlDataSource.SelectedIndex = 0 Then
            LoadFromXml(RadTabStrip1)
         Else
            LoadFromDatabase(RadTabStrip1)
         End If
         lbActiveTab.Items.Clear()
         Dim tab As Tab
         For Each tab In  RadTabStrip1.Tabs
            lbActiveTab.Items.Add(New ListItem(tab.Text, tab.Value))
         Next tab
      End Sub 'LoadData
      
      
      Private Sub LoadFromXml(tabStrip As RadTabStrip)
         Dim xmlDoc As New XmlDocument()
         xmlDoc.Load(Request.MapPath("TabStrip.xml"))
         tabStrip.Tabs.Clear()
         tabStrip.SelectedIndex = - 1
         FillTabs(tabStrip.Tabs, xmlDoc.DocumentElement)
         tabStrip.OnClientTabSelected = "onTabClick"
      End Sub 'LoadFromXml
      
      Private Sub FillTabs(tabCollection As TabCollection, rootElement As XmlElement)
         Dim child As XmlNode
         For Each child In  rootElement.ChildNodes
            If child.NodeType = XmlNodeType.Element Then
               If child.Name = "Tab" Then
                  Dim tab As New Tab()
                  tab.ID = child.Attributes("ID").Value
                  tab.Text = child.Attributes("Text").Value
                  tab.Value = child.Attributes("Value").Value
                  tabCollection.Add(tab)
                  FillTabs(tab.Tabs, CType(child, XmlElement))
               End If
            End If
         Next child
      End Sub 'FillTabs
      
      
      Private Sub LoadFromDatabase(tabStrip As RadTabStrip)
         Dim OldDbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath("TabStrip.mdb") + ";User ID=;Password=;")
         Dim adpTabStrip As New OleDbDataAdapter("SELECT * FROM TabStrip", OldDbCon)
         Dim dsTabStrip As New DataSet()
         adpTabStrip.Fill(dsTabStrip)
         tabStrip.DataFieldID = "ID"
         tabStrip.DataValueField = "ID"
         tabStrip.DataFieldParentID = "ParentID"
         tabStrip.DataTextField = "Text"
         tabStrip.DataSource = dsTabStrip
         tabStrip.DataBind()
         tabStrip.OnClientTabSelected = String.Empty
         tabStrip.SelectedIndex = - 1
      End Sub 'LoadFromDatabase
      
      
      Protected Sub ddlDataSource_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         LoadData()
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(RadTabStrip1)
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(lbActiveTab)
      End Sub 'ddlDataSource_SelectedIndexChanged
      
      
      Protected Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         Dim tab As Tab = CType(RadTabStrip1.FindTabByText(args.Args), Tab)
         If Not (tab Is Nothing) Then
            If tab.Value = "Add" Then
               Dim newTab As New Tab("Copy of " + tab.Text)
               newTab.Width = Unit.Pixel(100)
               RadTabStrip1.Tabs(0).Tabs.Add(newTab)
            ElseIf tab.Value = "Remove" Then
               RadTabStrip1.Tabs(1).SelectedIndex = - 1
               RadTabStrip1.Tabs(1).Tabs.Remove(tab)
            ElseIf tab.Value = "Disable" Then
               tab.Enabled = False
            Else
               If tab.Tabs.Count = 0 Then
                  RadCallback1.Alert("Action not applicable!")
               End If
            End If
            CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(RadTabStrip1)
         End If
      End Sub 'RadCallback1_Callback
      
      
      Protected Sub lbActiveTab_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lbActiveTab.SelectedIndexChanged
         Dim tab As Tab = CType(RadTabStrip1.FindTabByValue(lbActiveTab.SelectedItem.Value), Tab)
         RadTabStrip1.SelectedIndex = RadTabStrip1.Tabs.IndexOf(tab)
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(RadTabStrip1)
      End Sub 'lbActiveTab_SelectedIndexChanged
      
      
      Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs)
         Dim [text] As String = tbSubmitText.Text
         If [text] = String.Empty Then
            tbSubmitText.BackColor = Color.Yellow
            [text] = "[empty]"
         Else
            tbSubmitText.BackColor = Color.White
         End If
         lSubmittedText.Text = [text]
         tbSubmitText.Text = String.Empty
         Me.RadTabStrip2.SelectedIndex = 0
         Me.RadMultiPage1.SelectedIndex = 0
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tbSubmitText)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(lSubmittedText)
      End Sub 'btnSubmit_Click
      
      
      Protected Sub cblItems_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim [text] As String = String.Empty
         Dim item As ListItem
         For Each item In  cblItems.Items
            If item.Selected Then
               [text] += item.Text + " "
            End If
         Next item
         If [text].Length = 0 Then
            [text] = "[No Selected Items]"
         End If
         lSelectedItems.Text = [text]
         Me.RadTabStrip2.SelectedIndex = 1
         Me.RadMultiPage1.SelectedIndex = 1
         CType(sender, Telerik.WebControls.CallbackCheckBoxList).ControlsToUpdate.Add(RadTabStrip2)
         CType(sender, Telerik.WebControls.CallbackCheckBoxList).ControlsToUpdate.Add(RadMultiPage1)
      End Sub 'cblItems_SelectedIndexChanged
      
      
      
      Protected Sub lbItems_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         Dim [text] As String = String.Empty
         Dim item As ListItem
         For Each item In  lbItems.Items
            If item.Selected Then
               [text] += item.Text + " "
            End If
         Next item
         If [text].Length = 0 Then
            [text] = "[No Selected Items]"
         End If
         llbItems.Text = [text]
         Me.RadTabStrip2.SelectedIndex = 2
         Me.RadMultiPage1.SelectedIndex = 2
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(RadTabStrip2)
         CType(sender, Telerik.WebControls.CallbackListBox).ControlsToUpdate.Add(RadMultiPage1)
      End Sub 'lbItems_SelectedIndexChanged
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.TabStrip