
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing


Namespace Telerik.CallbackIntegrationExamplesVBNET.Chart
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Private Shared colors As Color() =  {Color.Red, Color.Blue, Color.Green, Color.Aquamarine, Color.Azure, Color.CornflowerBlue, Color.SteelBlue}
      
      Protected RadChart1 As Telerik.WebControls.RadChart
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected WithEvents CallbackRadioButtonList1 As Telerik.WebControls.CallbackRadioButtonList
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected WithEvents RadCallback1 As Telerik.WebControls.RadCallback
      Protected RadChart2 As Telerik.WebControls.RadChart
      Protected WithEvents RadCallback2 As Telerik.WebControls.RadCallback
      Protected WithEvents CallbackDropDownList1 As Telerik.WebControls.CallbackDropDownList
      
      
      Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            LoadChart1()
            
            Dim itemIndex As Integer = 0
            Dim item As ChartSeriesItem
            For Each item In  RadChart2.ChartSeriesCollection(0).Items
               item.ItemMap.HRef = String.Format("javascript:explode('{0}');", itemIndex)
               itemIndex += 1
            Next item
         End If
      End Sub 'Page_Load
      
      
      
      Private Sub LoadChart1()
         Dim dbCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("chart.mdb"))
         dbCon.Open()
         ' Remove the previous series.
         RadChart1.ChartSeriesCollection.Clear()
         
         ' Form sql query to the database.
         Dim sqlString As String = "SELECT SC.Id, SC.Name, D.Year, D.Value FROM (Category AS C INNER JOIN Subcategory AS SC ON C.Id=SC.Category_id) INNER JOIN Data AS D ON SC.ID=D.SubCategory_Id WHERE C.ID={0} ORDER BY C.ID, SC.ID, Year;"
         sqlString = [String].Format(sqlString, 1)
         
         Dim adapter As New OleDbDataAdapter(sqlString, dbCon)
         Dim ds As New DataSet()
         adapter.Fill(ds)
         
         ' Load data.
         Dim oldsubcategory_id As Integer = - 1
         Dim subcategory_id As Integer
         Dim currentSeries As ChartSeries = Nothing
         
         Dim dbRow As DataRow
         For Each dbRow In  ds.Tables(0).Rows
            subcategory_id = CInt(dbRow("Id"))
            
            If subcategory_id <> oldsubcategory_id Then
               currentSeries = RadChart1.CreateSeries(CStr(dbRow("Name")), Color.Blue, ChartSeriesType.Bar)
               currentSeries.Appearance.BorderColor = Color.Black
               
               currentSeries.ShowLabels = False
               oldsubcategory_id = subcategory_id
            End If
            
            If Not (currentSeries Is Nothing) Then
               currentSeries.AddItem(CDbl(dbRow("Value")))
            End If
         Next dbRow
         
         ' Set colors for the series in the series collection.
         Dim i As Integer = 0
         Dim series As ChartSeries
         For Each series In  RadChart1.ChartSeriesCollection
            
            series.ImageMap.HRef = String.Format("javascript:LoadData('single', '{0}');", i)
            series.ImageMap.ToolTip = "Click to see only series " + i.ToString()
            series.MainColor = colors((i Mod colors.Length))
            i += 1
            series.Appearance.FillStyle = FillStyle.Solid
            series.PointMark = ChartPointMark.None
         Next series
         
         ' Set additional properties and settings for the chart.
         RadChart1.Title1.Text = "Statistics"
         
         dbCon.Close()
      End Sub 'LoadChart1
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
      Protected Sub CallbackRadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CallbackRadioButtonList1.SelectedIndexChanged
         If CallbackRadioButtonList1.SelectedIndex = 0 Then
            RadChart1.SeriesOrientation = ChartSeriesOrientation.Vertical
         Else
            RadChart1.SeriesOrientation = ChartSeriesOrientation.Horizontal
         End If
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(RadChart1)
      End Sub 'CallbackRadioButtonList1_SelectedIndexChanged
      
      
      
      Protected Sub RadCallback1_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback1.Callback
         LoadChart1()
         
         If args.CallbackEvent.Equals("single") Then
            Dim seriesIndex As Integer = Integer.Parse(args.Args)
            
            Dim i As Integer
            For i = RadChart1.ChartSeriesCollection.Count - 1 To 0 Step -1
               If i <> seriesIndex Then
                  RadChart1.RemoveSeriesAt(i)
               End If
            Next i
            RadChart1.ChartSeriesCollection(0).ImageMap.HRef = "javascript:LoadData('all', '');"
         End If
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(RadChart1)
      End Sub 'RadCallback1_Callback
      
      
      
      Protected Sub RadCallback2_Callback(sender As Object, args As Telerik.WebControls.CallbackEventArgs) Handles RadCallback2.Callback
         Dim item As ChartSeriesItem
         For Each item In  RadChart2.ChartSeriesCollection(0).Items
            item.Exploded = False
         Next item
         RadChart2.ChartSeriesCollection(0).Items(Integer.Parse(args.Args)).Exploded = True
         CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(RadChart2)
      End Sub 'RadCallback2_Callback
      
      
      
      Protected Sub CallbackDropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CallbackDropDownList1.SelectedIndexChanged
         Dim seriesType As ChartSeriesType = CType([Enum].Parse(GetType(ChartSeriesType), CallbackDropDownList1.SelectedItem.Text), ChartSeriesType)
         Dim series As ChartSeries
         For Each series In  RadChart1.ChartSeriesCollection
            series.Type = seriesType
         Next series
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(RadChart1)
      End Sub 'CallbackDropDownList1_SelectedIndexChanged
   End Class 'DefaultVB 
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Chart 