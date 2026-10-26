
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing


Namespace Telerik.CallbackIntegrationExamplesVBNET.Menu
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected RadCallback1 As Telerik.WebControls.RadCallback
      Protected lbShoppingCart As System.Web.UI.WebControls.ListBox
      Protected lbDataSource As Telerik.WebControls.CallbackListBox
      Protected lBreadCrumb As System.Web.UI.WebControls.Label
      Protected tbItemText As System.Web.UI.WebControls.TextBox
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected btnRemove As Telerik.WebControls.CallbackButton
      Protected btnDisable As Telerik.WebControls.CallbackButton
      Protected btnAddChild As Telerik.WebControls.CallbackButton
      Protected btnAddRoot As Telerik.WebControls.CallbackButton
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected Label3 As System.Web.UI.WebControls.Label
      Protected pCart As System.Web.UI.WebControls.Panel
      Protected RadMenu1 As Telerik.WebControls.RadMenu
      
      
      Private Property LastItem() As String
         Get
            Return CStr(ViewState("LastItem"))
         End Get
         Set
            ViewState("LastItem") = value
         End Set
      End Property
      
      
      Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            LoadData()
         End If
         RadMenu1.ExpandToID = String.Empty
      End Sub 'Page_Load
      
      
      Protected Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs)
         Dim subArgs As String() = Server.UrlDecode(args.Args).Split(ControlChars.Lf)
         
         Dim clickedItem As Telerik.WebControls.MenuItem = Nothing
         If 2 = subArgs.Length Then
            clickedItem = GetMenuItem(subArgs(0), subArgs(1))
         End If 
         If Not (clickedItem Is Nothing) Then
            MakeBreadCrumb(clickedItem)
            UpdateShoppingCart(clickedItem)
            LastItem = clickedItem.Text
            CType(sender, RadCallback).ControlsToUpdate.Add(lBreadCrumb)
            CType(sender, RadCallback).ControlsToUpdate.Add(pCart)
         End If
      End Sub 'RadCallback1_Callback
      
      
      Protected Sub btnAddChild_Click(sender As Object, e As System.EventArgs)
         If CheckTextBox(CType(sender, CallbackButton), tbItemText) Then
            If Not (LastItem Is Nothing) Then
               Dim _lastItem As Telerik.WebControls.MenuItem = GetMenuItem(LastItem, "")
               
               If Not (_lastItem Is Nothing) Then
                  AddNewItem(_lastItem, tbItemText.Text)
                  RadMenu1.ExpandToID = tbItemText.Text
                  tbItemText.Text = String.Empty
                  CType(sender, CallbackButton).ControlsToUpdate.Add(RadMenu1)
                  CType(sender, CallbackButton).ControlsToUpdate.Add(tbItemText)
               End If
            Else
               CType(sender, CallbackButton).Alert("There is no last selected menu item!")
            End If
         End If
      End Sub 'btnAddChild_Click
      
      
      Protected Sub btnRemove_Click(sender As Object, e As System.EventArgs)
         If Not (LastItem Is Nothing) Then
            Dim _menuItem As Telerik.WebControls.MenuItem = GetMenuItem(LastItem, "")
            If Not (_menuItem Is Nothing) Then
               If Not (_menuItem.ParentItem Is Nothing) Then
                  _menuItem.ParentItem.Items.Remove(_menuItem)
               Else
                  RadMenu1.RootGroup.RemoveItem(_menuItem)
               End If
               CType(sender, CallbackButton).ControlsToUpdate.Add(RadMenu1)
               CType(sender, CallbackButton).ControlsToUpdate.Add(lBreadCrumb)
               lBreadCrumb.Text = Nothing
            End If
         Else
            CType(sender, CallbackButton).Alert("There is no last selected menu item!")
         End If
      End Sub 'btnRemove_Click
      
      
      Protected Sub lbDataSource_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         LoadData()
         UpdateElements()
         CType(sender, CallbackListBox).ControlsToUpdate.Add(RadMenu1)
         CType(sender, CallbackListBox).ControlsToUpdate.Add(pCart)
      End Sub 'lbDataSource_SelectedIndexChanged
      
      
      Protected Sub btnAddRoot_Click(sender As Object, e As System.EventArgs)
         If CheckTextBox(CType(sender, CallbackButton), tbItemText) Then
            Dim newItem As New Telerik.WebControls.MenuItem()
            newItem.Text = tbItemText.Text
            newItem.CssClass = "MainItem"
            newItem.CssClassOver = "MainItemOver"
            newItem.CssClassClicked = "MainItemOver"
            
            processMainItems(RadMenu1)
            
            RadMenu1.RootGroup.Items.Add(newItem)
            
            tbItemText.Text = String.Empty
            CType(sender, CallbackButton).ControlsToUpdate.Add(RadMenu1)
            CType(sender, CallbackButton).ControlsToUpdate.Add(tbItemText)
         End If
      End Sub 'btnAddRoot_Click
      
      
      Protected Sub btnDisable_Click(sender As Object, e As System.EventArgs)
         If Not (LastItem Is Nothing) Then
            Dim _menuItem As Telerik.WebControls.MenuItem = GetMenuItem(LastItem, "")
            If Not (_menuItem Is Nothing) Then
               _menuItem.Enabled = False
               CType(sender, CallbackButton).ControlsToUpdate.Add(RadMenu1)
            End If
         Else
            CType(sender, CallbackButton).Alert("There is no last selected menu item!")
         End If
      End Sub 'btnDisable_Click
      Protected Overrides Sub OnInit(e As EventArgs)
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      Private Sub LoadData()
         If lbDataSource.SelectedIndex = 0 Then
            Load1(RadMenu1)
         ElseIf lbDataSource.SelectedIndex = 1 Then
            Load2(RadMenu1)
         Else
            Load3(RadMenu1)
         End If
         processMainItems(RadMenu1)
      End Sub 'LoadData
      
      Private Sub MakeBreadCrumb(item As Telerik.WebControls.MenuItem)
         Dim bc As String = String.Empty
         
         While Not (item Is Nothing)
            If bc.Length = 0 Then
               bc = item.Text
            Else
               bc = item.Text + " > " + bc
            End If
            item = CType(item.ParentItem, Telerik.WebControls.MenuItem)
         End While
         lBreadCrumb.Text = bc
      End Sub 'MakeBreadCrumb
      
      
      Private Sub UpdateShoppingCart(item As Telerik.WebControls.MenuItem)
         If item.ParentItem Is Nothing Then
            Return
         End If
         If item.Category = String.Empty Then
            Return
         End If 
         If lbDataSource.SelectedIndex = 1 Then
            Dim [text] As String = item.Text
            Dim cartItem As ListItem = lbShoppingCart.Items.FindByText([text])
            If item.Category.Equals("Add") Then
               If cartItem Is Nothing Then
                  lbShoppingCart.Items.Add([text])
               Else
                  RadCallback1.Alert("Item already exists in the shopping cart!")
               End If
            Else
               If Not (cartItem Is Nothing) Then
                  lbShoppingCart.Items.Remove(cartItem)
               Else
                  RadCallback1.Alert("Item already removed from the shopping cart!")
               End If
            End If
         End If
      End Sub 'UpdateShoppingCart
      
      
      Private Sub AddNewItem(item As Telerik.WebControls.MenuItem, [text] As String)
         Dim newItem As New Telerik.WebControls.MenuItem()
         newItem.Text = [text]
         newItem.CssClass = "MainItem"
         newItem.CssClassOver = "MainItemOver"
         newItem.CssClassClicked = "MainItemOver"
         newItem.ID = [text]
         item.Items.Add(newItem)
      End Sub 'AddNewItem
      
      
      Private Function GetMenuItem([text] As String, category As String) As Telerik.WebControls.MenuItem
         Dim array As ArrayList = RadMenu1.FindItemByText([text], False)
         
         If array.Count > 1 Or array.Count = 0 Then
            Dim item As Telerik.WebControls.MenuItem
            For Each item In  array
               If item.Category.Equals(category) Then
                  Return item
               End If
            Next item
         End If
         
         If array.Count > 0 Then
            Return CType(array(0), Telerik.WebControls.MenuItem)
         Else
            Return Nothing
         End If
      End Function 'GetMenuItem
      
      Private Sub UpdateElements()
         If lbDataSource.SelectedIndex = 1 Then
            Dim ctrlv As Control
            For Each ctrlv In  pCart.Controls
               ctrlv.Visible = True
            Next ctrlv
         Else
            Dim ctrlnv As Control
            For Each ctrlnv In  pCart.Controls
               ctrlnv.Visible = False
            Next ctrlnv
         End If
      End Sub 'UpdateElements
      
      Private Function CheckTextBox(button As CallbackButton, textBox As TextBox) As Boolean
         button.ControlsToUpdate.Add(textBox)
         If textBox.Text.Length = 0 Then
            textBox.BackColor = Color.Yellow
            button.Alert("Name for the item is reqired.")
            Return False
         Else
            textBox.BackColor = Color.White
            Return True
         End If
      End Function 'CheckTextBox
      
      
      Private Function GetMenuDataSource(inputDSN As String) As DataSet
         Dim OldDbCon As New OleDbConnection(inputDSN)
         OldDbCon.Open()
         Dim MenuDataAdaptor As New OleDbDataAdapter("SELECT Text,idtext,parentIdtext FROM Links", OldDbCon)
         Dim MenuDataLoader As New DataSet()
         MenuDataAdaptor.Fill(MenuDataLoader)
         OldDbCon.Close()
         Return MenuDataLoader
      End Function 'GetMenuDataSource
      
      
      Private Sub MenuRealBind(menu As RadMenu)
         Dim DefaultDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("menudata.mdb")
         menu.EnableGroupChildrenImage = True
         menu.DataFieldID = "idtext" 'idtext
         menu.DataFieldParentID = "parentIdtext" 'parentIdtext
         menu.DataSource = GetMenuDataSource(DefaultDSN).Tables(0).DefaultView
         menu.DataBind()
         menu.RootGroup.Flow = PresentationDirection.Horizontal
      End Sub 'MenuRealBind
      
      
      Private Sub processMainItems(menu As RadMenu)
         If Not (menu.RootGroup Is Nothing) And menu.RootGroup.Items.Count > 0 Then
            Dim item As Telerik.WebControls.MenuItem
            For Each item In  menu.RootGroup.Items
               item.CssClass = "MainItem"
               item.CssClassOver = "MainItemOver"
               item.CssClassClicked = "MainItemOver"
            Next item
         End If
      End Sub 'processMainItems
      
      
      Private Sub Load1(menu As RadMenu)
         Dim TopGroup As New MenuGroup()
         TopGroup.Flow = PresentationDirection.Horizontal
         menu.RootGroup = TopGroup
         
         Dim TimeHeadItem As New Telerik.WebControls.MenuItem()
         TimeHeadItem.Text = "Current Time"
         TimeHeadItem.CssClass = "MainItem"
         TimeHeadItem.CssClassOver = "MainItemOver"
         TopGroup.AddItem(TimeHeadItem)
         
         Dim TimeGroup As New MenuGroup()
         TimeGroup.Width = 130
         TimeGroup.LeftCellWidth = 10
         TimeHeadItem.ChildGroup = TimeGroup
         
         Dim HourItem As New Telerik.WebControls.MenuItem()
         HourItem.Text = "Hours : " + System.DateTime.Now.Hour.ToString()
         TimeGroup.AddItem(HourItem)
         
         Dim MinuteItem As New Telerik.WebControls.MenuItem()
         MinuteItem.Text = "Minutes : " + System.DateTime.Now.Minute.ToString()
         TimeGroup.AddItem(MinuteItem)
         
         Dim SecondItem As New Telerik.WebControls.MenuItem()
         SecondItem.Text = "Seconds : " + System.DateTime.Now.Second.ToString()
         TimeGroup.AddItem(SecondItem)
         
         Dim DateHeadItem As New Telerik.WebControls.MenuItem()
         DateHeadItem.Text = "Current Date"
         DateHeadItem.CssClass = "MainItem"
         DateHeadItem.CssClassOver = "MainItemOver"
         TopGroup.AddItem(DateHeadItem)
         
         Dim DateGroup As New MenuGroup()
         DateGroup.Width = 130
         DateGroup.LeftCellWidth = 10
         DateHeadItem.ChildGroup = DateGroup
         
         Dim YearItem As New Telerik.WebControls.MenuItem()
         YearItem.Text = "Year : " + System.DateTime.Now.Year.ToString()
         DateGroup.AddItem(YearItem)
         
         Dim MonthItem As New Telerik.WebControls.MenuItem()
         MonthItem.Text = "Month : " + System.DateTime.Now.Month.ToString()
         DateGroup.AddItem(MonthItem)
         
         Dim DayItem As New Telerik.WebControls.MenuItem()
         DayItem.Text = "Day : " + System.DateTime.Now.Day.ToString()
         DayItem.ID = "DayItem"
         DateGroup.AddItem(DayItem)
      End Sub 'Load1
      
      
      Private Sub Load2(menu As RadMenu)
         menu.LoadContentFile("menu.xml")
      End Sub 'Load2
      
      
      Private Sub Load3(menu As RadMenu)
         MenuRealBind(menu)
      End Sub 'Load3
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Menu