using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.WebControls;
using System.Web.UI.WebControls;
using Telerik.QuickStart;

namespace Telerik.GridExamplesCSharp.Integration.GridAndMenu
{
	public class DefaultCS : XhtmlPage
	{
		protected Telerik.WebControls.RadMenu RadMenu1;
		protected Telerik.WebControls.RadGrid RadGrid1;
		
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
			this.RadGrid1.NeedDataSource += new Telerik.WebControls.GridNeedDataSourceEventHandler(this.RadGrid1_NeedDataSource);
			this.RadMenu1.ItemClicked += new Telerik.WebControls.RadMenu.RadMenuItemEventHandler(this.RadMenu1_ItemClicked);

		}
		#endregion

		private void RadGrid1_NeedDataSource(object source, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			OleDbConnection MyOleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("~/Grid/Data/Access/Nwind.mdb"));
			OleDbDataAdapter MyOleDbDataAdapter = new OleDbDataAdapter();
			MyOleDbDataAdapter.SelectCommand = new OleDbCommand("SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, PostalCode FROM Customers", MyOleDbConnection);

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

			RadGrid1.DataSource = myDataTable;
		}

		private void RadMenu1_ItemClicked(object sender, ItemEventArgs e)
		{
			int radGridClickedRowIndex;
	
			radGridClickedRowIndex = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
			switch(e.Item.Text)
			{
				case "Select":
					RadGrid1.Items[radGridClickedRowIndex].Selected = true;
				break;
				case "Edit":
					RadGrid1.Items[radGridClickedRowIndex].Edit = true;
					RadGrid1.Rebind();
				break;
				case "Word":
					RadGrid1.MasterTableView.ExportToWord("RadGrid");
					break;
				case "Excel":
					RadGrid1.MasterTableView.ExportToExcel("RadGrid");
					break;
			}
		}
	}
}
