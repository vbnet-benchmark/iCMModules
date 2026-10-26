
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackExamplesVB.Integration.CallbackAndTabStrip
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected ProductLogo As System.Web.UI.HtmlControls.HtmlImage
      Protected ProductImage As System.Web.UI.HtmlControls.HtmlImage
      Protected ProductDescription As System.Web.UI.WebControls.Label
      Protected Price As System.Web.UI.WebControls.Label
      Protected RadTabStrip1 As Telerik.WebControls.RadTabStrip
      Protected Panel1 As System.Web.UI.WebControls.Panel
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not IsPostBack Then
            FillProductInfo(RadTabStrip1.Tabs(0).Value)
         End If
      End Sub 'Page_Load
      
      
      Private Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         FillProductInfo(args.CallbackEvent)
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(Panel1)
      End Sub 'RadCallback1_Callback
      
      
      Private Sub FillProductInfo(TabID As String)
         Dim dr As DataRow = GetProductRow(TabID)
         If Not (dr Is Nothing) Then
            ProductLogo.Src = "Images/" + dr("ProductLogo").ToString()
            ProductImage.Src = "Images/" + dr("ProductImage").ToString()
            ProductDescription.Text = dr("ProductDescription").ToString()
            Price.Text = dr("Price").ToString()
         End If
      End Sub 'FillProductInfo
      
      
      Private Function GetProductRow(TabID As String) As DataRow
         Dim ds As New DataSet()
         ds.ReadXml(Server.MapPath("Products.xml"))
         
         Dim dr As DataRow
         For Each dr In  ds.Tables(0).Rows
            If dr("ID").ToString() = TabID Then
               Return dr
            End If
         Next dr
         Return Nothing
      End Function 'GetProductRow
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
End Namespace 'Telerik.CallbackExamplesVB.Integration.CallbackAndTabStrip