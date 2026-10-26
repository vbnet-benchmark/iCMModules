
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackIntegarationExamplesVBNET.GridAndTabstrip
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected callbackShopping As Telerik.WebControls.RadCallback
      Protected gridProducts As Telerik.WebControls.RadGrid
      Protected tabsProductDetails As Telerik.WebControls.RadTabStrip
      Protected multipageInformation As Telerik.WebControls.RadMultiPage
      Protected gridShoppingCart As Telerik.WebControls.RadGrid
      Protected panelTabstripLoading As System.Web.UI.WebControls.Panel
      Protected labelDescription As System.Web.UI.WebControls.Label
      Protected PageDescription As Telerik.WebControls.PageView
      Protected imageProduct As System.Web.UI.WebControls.Image
      Protected PageImages As Telerik.WebControls.PageView
      Protected panelLoadingImage As System.Web.UI.WebControls.Panel
      
      
      Private Property dataSource() As String
         Get
            Return CStr(Session("dataSource"))
         End Get
         Set
            Session("dataSource") = value
         End Set
      End Property
      
      Private Property shoppingCart() As DataTable
         Get
            Return CType(Session("shoppingCart"), DataTable)
         End Get
         Set
            Session("shoppingCart") = value
         End Set
      End Property
       
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         tabsProductDetails.SkinsPath = Me.TemplateSourceDirectory + "/Skins/"
         tabsProductDetails.Skin = "ShoppingCart"
         If Not IsPostBack Then
            dataSource = Server.MapPath((Request.FilePath.Substring(0, Request.FilePath.LastIndexOf("/"c)) + "/Movies.mdb"))
            shoppingCart = GetDataTable("SELECT TOP 1 * FROM Products")
         End If 
      End Sub 'Page_Load
      
      Protected Sub gridProducts_NeedDataSource(sender As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs)
         gridProducts.DataSource = GetDataTable("SELECT * FROM Products")
         gridProducts.MasterTableView.DataKeyNames = New String() {"ProductId"}
      End Sub 'gridProducts_NeedDataSource
      
      Protected Sub gridShoppingCart_NeedDataSource(sender As Object, e As Telerik.WebControls.GridNeedDataSourceEventArgs)
         gridShoppingCart.DataSource = shoppingCart
         gridProducts.MasterTableView.DataKeyNames = New String() {"ProductId"}
      End Sub 'gridShoppingCart_NeedDataSource
      
      Private Function GetDataTable(queryString As [String]) As DataTable
         Dim MyOleDbConnection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dataSource)
         Dim MyOleDbDataAdapter As New OleDbDataAdapter()
         MyOleDbDataAdapter.SelectCommand = New OleDbCommand(queryString, MyOleDbConnection)
         
         Dim myDataTable As New DataTable()
         MyOleDbConnection.Open()
         Try
            MyOleDbDataAdapter.Fill(myDataTable)
         Finally
            MyOleDbConnection.Close()
         End Try
         
         Return myDataTable
      End Function 'GetDataTable
      
      
      Protected Sub shoppingCallback_Callback(sender As Object, e As Telerik.WebControls.CallbackEventArgs)
         Dim productId As Integer = Integer.Parse(e.Args)
         Select Case e.CallbackEvent
            Case "ViewImage"
               ShowProductInfo(productId, 1)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tabsProductDetails)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(multipageInformation)
            Case "ViewDescription"
               ShowProductInfo(productId, 0)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(tabsProductDetails)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(multipageInformation)
            Case "AddToCart"
               AddProductToCart(productId)
               gridShoppingCart.Rebind()
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(gridShoppingCart)
            Case "RemoveFromCart"
               RemoveProductFromCart(productId)
               gridShoppingCart.Rebind()
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(gridShoppingCart)
            Case Else
         End Select
      End Sub 'shoppingCallback_Callback
      
      Private Sub AddProductToCart(productId As Integer)
         shoppingCart.ImportRow(GetDataTable(("SELECT * FROM Products WHERE ProductId = " + productId.ToString())).Rows(0))
      End Sub 'AddProductToCart
      
      Private Sub RemoveProductFromCart(productId As Integer)
         Dim i As Integer = 0
         While i < shoppingCart.Rows.Count And CInt(shoppingCart.Rows(i)("ProductId")) <> productId
            i += 1
         End While
         If i < shoppingCart.Rows.Count Then
            shoppingCart.Rows.RemoveAt(i)
         End If
      End Sub 'RemoveProductFromCart
      
      Private Sub ShowProductInfo(productId As Integer, tabToShow As Integer)
         Dim productInfo As DataRow = GetDataTable(("SELECT * FROM Products WHERE ProductId = " + productId.ToString())).Rows(0)
         Dim imageUrl As String = [String].Format("Images/image{0}.jpg", productId)
         CType(multipageInformation.FindControl("labelDescription"), System.Web.UI.WebControls.Label).Text = CStr(productInfo("ProductDescription"))
         CType(multipageInformation.FindControl("imageProduct"), System.Web.UI.WebControls.Image).ImageUrl = imageUrl
         tabsProductDetails.SelectedIndex = tabToShow
         multipageInformation.SelectedIndex = tabToShow
      End Sub 'ShowProductInfo
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
         
         AddHandler Me.gridProducts.NeedDataSource, AddressOf gridProducts_NeedDataSource
         AddHandler Me.gridShoppingCart.NeedDataSource, AddressOf gridShoppingCart_NeedDataSource
      End Sub 'InitializeComponent
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.GridAndTabstrip