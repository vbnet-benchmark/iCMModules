using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;

namespace Telerik.CallbackIntegrationExamplesCSharp.Grid
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		
		protected Telerik.WebControls.RadGrid RadGrid1;
		protected Telerik.WebControls.CallbackPanel CallbackPanel1;
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackRadioButtonList CallbackRadioButtonList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (CallbackRadioButtonList1.SelectedIndex==0)
				{
					RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms;					
				}
				else
				{
					RadGrid1.MasterTableView.EditMode = GridEditMode.InPlace;					
				}
				RadGrid1.Rebind();
			}
		}

		private void RadGrid1_NeedDataSource(object source, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			OleDbConnection MyOleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("Nwind.mdb"));
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
			this.CallbackRadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.CallbackRadioButtonList1_SelectedIndexChanged);
			this.RadGrid1.NeedDataSource += new Telerik.WebControls.GridNeedDataSourceEventHandler(this.RadGrid1_NeedDataSource);

		}
		#endregion

		private void CallbackRadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (CallbackRadioButtonList1.SelectedIndex==0)
			{
				RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms;					
			}
			else
			{
				RadGrid1.MasterTableView.EditMode = GridEditMode.InPlace;					
			}
			RadGrid1.Rebind();
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(RadGrid1);
		}

	}
}
