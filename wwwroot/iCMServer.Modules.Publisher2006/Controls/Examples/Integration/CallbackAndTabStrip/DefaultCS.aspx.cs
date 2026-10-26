using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackExamplesCS.Integration.CallbackAndTabStrip
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected System.Web.UI.HtmlControls.HtmlImage ProductLogo;
		protected System.Web.UI.HtmlControls.HtmlImage ProductImage;
		protected System.Web.UI.WebControls.Label ProductDescription;
		protected System.Web.UI.WebControls.Label Price;
		protected Telerik.WebControls.RadTabStrip RadTabStrip1;
		protected System.Web.UI.WebControls.Panel Panel1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				FillProductInfo(RadTabStrip1.Tabs[0].Value);
			}
		}

		private void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			FillProductInfo(args.CallbackEvent);
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(Panel1);
		}

		private void FillProductInfo(string TabID)
		{
			DataRow dr = GetProductRow(TabID);
			if (dr != null)
			{
				ProductLogo.Src = "Images/" + dr["ProductLogo"].ToString();
				ProductImage.Src = "Images/" + dr["ProductImage"].ToString();
				ProductDescription.Text = dr["ProductDescription"].ToString();
				Price.Text = dr["Price"].ToString();
			}
		}

		private DataRow GetProductRow(string TabID)
		{
			DataSet ds = new DataSet();
			ds.ReadXml(Server.MapPath("Products.xml"));
    
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				if (dr["ID"].ToString() == TabID) 
				{
					return dr; 
				}
			}
			return null; 
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.RadCallback1.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback1_Callback);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
