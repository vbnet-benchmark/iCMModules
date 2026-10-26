using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;

namespace Telerik.CallbackIntegrationExamplesCSharp.Chart
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		static Color[] colors = {Color.Red, Color.Blue, Color.Green, Color.Aquamarine, Color.Azure, Color.CornflowerBlue, Color.SteelBlue};

		protected Telerik.WebControls.RadChart RadChart1;
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackRadioButtonList CallbackRadioButtonList1;
		protected System.Web.UI.WebControls.Label Label2;
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected Telerik.WebControls.RadChart RadChart2;
		protected Telerik.WebControls.RadCallback RadCallback2;
		protected Telerik.WebControls.CallbackDropDownList CallbackDropDownList1;
				
		protected void Page_Load(object sender, System.EventArgs e)
		{			
			if (!Page.IsPostBack)
			{								
				LoadChart1();

				int itemIndex = 0;
				foreach (ChartSeriesItem item in RadChart2.ChartSeriesCollection[0].Items)
				{
					item.ItemMap.HRef = string.Format("javascript:explode('{0}');", itemIndex);
					itemIndex+=1;
				}
			}    
		}		


		private void LoadChart1()
		{
			OleDbConnection dbCon = new OleDbConnection ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("chart.mdb"));			
			dbCon.Open();
			// Remove the previous series.
			RadChart1.ChartSeriesCollection.Clear();
                        
			// Form sql query to the database.
			string sqlString = "SELECT SC.Id, SC.Name, D.Year, D.Value FROM (Category AS C INNER JOIN Subcategory AS SC ON C.Id=SC.Category_id) INNER JOIN Data AS D ON SC.ID=D.SubCategory_Id WHERE C.ID={0} ORDER BY C.ID, SC.ID, Year;";
			sqlString = String.Format(sqlString, 1);
            
			OleDbDataAdapter  adapter = new OleDbDataAdapter(sqlString, dbCon);
			DataSet ds = new DataSet();
			adapter.Fill(ds);
            
			// Load data.
			int oldsubcategory_id = -1;
			int subcategory_id;
			ChartSeries currentSeries = null;

			foreach (DataRow dbRow in ds.Tables[0].Rows)
			{
				subcategory_id = (int) dbRow["Id"];

				if (subcategory_id != oldsubcategory_id)
				{
					currentSeries = RadChart1.CreateSeries((string) dbRow["Name"], Color.Blue, ChartSeriesType.Bar);                                        
					currentSeries.Appearance.BorderColor = Color.Black;                    
                    
					currentSeries.ShowLabels = false;
					oldsubcategory_id = subcategory_id;
				}

				if (currentSeries != null)
				{
					currentSeries.AddItem( (double) dbRow["Value"]);
				}                
			}

			// Set colors for the series in the series collection.
			int i = 0;
			foreach (ChartSeries series in RadChart1.ChartSeriesCollection)
			{
				
				series.ImageMap.HRef = string.Format("javascript:LoadData('single', '{0}');", i);
				series.ImageMap.ToolTip = "Click to see only series " + i.ToString();
				series.MainColor = colors[i % colors.Length];
				i+=1;
				series.Appearance.FillStyle = FillStyle.Solid;
				series.PointMark = ChartPointMark.None;				
			}

			// Set additional properties and settings for the chart.
			RadChart1.Title1.Text = "Statistics";

			dbCon.Close();
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
        
		///        Required method for Designer support - do not modify
		///        the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{			
			this.RadCallback2.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback2_Callback);
			this.CallbackRadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.CallbackRadioButtonList1_SelectedIndexChanged);
			this.CallbackDropDownList1.SelectedIndexChanged += new System.EventHandler(this.CallbackDropDownList1_SelectedIndexChanged);
			this.RadCallback1.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback1_Callback);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion            

		protected void CallbackRadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			if (CallbackRadioButtonList1.SelectedIndex == 0)
			{
				RadChart1.SeriesOrientation = ChartSeriesOrientation.Vertical;
			}
			else
			{
				RadChart1.SeriesOrientation = ChartSeriesOrientation.Horizontal;
			}
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(RadChart1);
		}


		protected void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			LoadChart1();
			
			if (args.CallbackEvent.Equals("single"))
			{
				int seriesIndex = int.Parse(args.Args);

				for (int i = RadChart1.ChartSeriesCollection.Count - 1; i >= 0; i--)
				{
					if (i != seriesIndex)
					{
						RadChart1.RemoveSeriesAt(i);
					}
				}; 			
				RadChart1.ChartSeriesCollection[0].ImageMap.HRef = "javascript:LoadData('all', '');";
			}
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(RadChart1);
		}


		protected void RadCallback2_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			foreach (ChartSeriesItem item in RadChart2.ChartSeriesCollection[0].Items)
			{
				item.Exploded = false;
			}
			RadChart2.ChartSeriesCollection[0].Items[int.Parse(args.Args)].Exploded = true;
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(RadChart2);
		}


		protected void CallbackDropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			ChartSeriesType seriesType = (ChartSeriesType) Enum.Parse(typeof(ChartSeriesType), CallbackDropDownList1.SelectedItem.Text);
			foreach (ChartSeries series in RadChart1.ChartSeriesCollection)
			{												
				series.Type = seriesType;				
			}
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(RadChart1);
		}


	}
}
