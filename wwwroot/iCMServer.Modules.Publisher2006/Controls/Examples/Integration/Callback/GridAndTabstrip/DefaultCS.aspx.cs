using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackIntegarationExamplesCSharp.GridAndTabstrip
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected Telerik.WebControls.RadCallback callbackShopping;
		protected Telerik.WebControls.RadGrid gridProducts;
		protected Telerik.WebControls.RadTabStrip tabsProductDetails;
		protected Telerik.WebControls.RadMultiPage multipageInformation;
		protected Telerik.WebControls.RadGrid gridShoppingCart;
		protected System.Web.UI.WebControls.Panel panelTabstripLoading;
		protected System.Web.UI.WebControls.Label labelDescription;
		protected Telerik.WebControls.PageView PageDescription;
		protected System.Web.UI.WebControls.Image imageProduct;
		protected Telerik.WebControls.PageView PageImages;
		protected System.Web.UI.WebControls.Panel panelLoadingImage;

		private string dataSource 
		{
			get { return (string)Session["dataSource"];}
			set { Session["dataSource"] = value;}
		}
		private DataTable shoppingCart
		{
			get { return (DataTable)Session["shoppingCart"];}
			set { Session["shoppingCart"] = value;}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			tabsProductDetails.SkinsPath = this.TemplateSourceDirectory + "/Skins/";
			tabsProductDetails.Skin = "ShoppingCart";
			if (!IsPostBack)
			{
				dataSource = Server.MapPath(Request.FilePath.Substring(0,Request.FilePath.LastIndexOf('/'))+"/Movies.mdb");
				shoppingCart = GetDataTable("SELECT TOP 1 * FROM Products");

			}
		}
		protected void gridProducts_NeedDataSource(object sender, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			gridProducts.DataSource = GetDataTable("SELECT * FROM Products");
			gridProducts.MasterTableView.DataKeyNames = new string[] {"ProductId"};
		}
		protected void gridShoppingCart_NeedDataSource(object sender, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			gridShoppingCart.DataSource = shoppingCart;
			gridProducts.MasterTableView.DataKeyNames = new string[] {"ProductId"};
		}
		private DataTable GetDataTable(String queryString)
		{
			OleDbConnection MyOleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dataSource);
			OleDbDataAdapter MyOleDbDataAdapter = new OleDbDataAdapter();
			MyOleDbDataAdapter.SelectCommand = new OleDbCommand(queryString, MyOleDbConnection);

			DataTable myDataTable = new DataTable();
			MyOleDbConnection.Open();
			try
			{
				MyOleDbDataAdapter.Fill(myDataTable);
			}
			finally
			{
				MyOleDbConnection.Close();
			}

			return myDataTable;
		}

		protected void shoppingCallback_Callback(object sender, Telerik.WebControls.CallbackEventArgs e)
		{
			int productId = int.Parse(e.Args);
			switch (e.CallbackEvent)
			{
				case "ViewImage":
					ShowProductInfo(productId, 1);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tabsProductDetails);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(multipageInformation);
					break;
				case "ViewDescription":
					ShowProductInfo(productId, 0);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tabsProductDetails);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(multipageInformation);
					break;
				case "AddToCart":
					AddProductToCart(productId);
					gridShoppingCart.Rebind();
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(gridShoppingCart);
					break;
				case "RemoveFromCart":
					RemoveProductFromCart(productId);
					gridShoppingCart.Rebind();
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(gridShoppingCart);
					break;
				default:
					break;
			}
		}
		private void AddProductToCart(int productId)
		{
			shoppingCart.ImportRow(GetDataTable("SELECT * FROM Products WHERE ProductId = "+ productId.ToString()).Rows[0]);
		}
		private void RemoveProductFromCart(int productId)
		{
			int i=0;
			while (i<shoppingCart.Rows.Count && ((int)shoppingCart.Rows[i]["ProductId"]) != productId)
				i++;
			if (i<shoppingCart.Rows.Count)
				shoppingCart.Rows.RemoveAt(i);
		}
		private void ShowProductInfo(int productId, int tabToShow)
		{
			DataRow productInfo = GetDataTable("SELECT * FROM Products WHERE ProductId = "+ productId.ToString()).Rows[0];
			string imageUrl = String.Format("Images/image{0}.jpg", productId);
			((System.Web.UI.WebControls.Label)multipageInformation.FindControl("labelDescription")).Text = (string)productInfo["ProductDescription"];
			((System.Web.UI.WebControls.Image)multipageInformation.FindControl("imageProduct")).ImageUrl = imageUrl;
			tabsProductDetails.SelectedIndex = tabToShow;
			multipageInformation.SelectedIndex= tabToShow;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.gridProducts.NeedDataSource +=new GridNeedDataSourceEventHandler(gridProducts_NeedDataSource);
			this.gridShoppingCart.NeedDataSource +=new GridNeedDataSourceEventHandler(gridShoppingCart_NeedDataSource);
		}
		#endregion
			
	}
}
