using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Telerik.ToolbarExamplesCS.Integration.ToolbarAndComboAndMenu
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : System.Web.UI.Page
	{
		protected Telerik.WebControls.RadComboBox RadComboBox3;
		protected Telerik.WebControls.RadDockableObject dockObjectToolbar;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				LoadDealers(String.Empty);
			}
		}

		private void LoadDealers(string filter)
		{
			string mdbPath = Server.MapPath("~/Combobox/Data/NWind.mdb"); 
			OleDbConnection dbCon = new OleDbConnection ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath); 
			dbCon.Open();
            
			string sql = "SELECT * from Customers";
			if (filter != String.Empty)
			{
				sql += " WHERE CompanyName LIKE '" + filter + "%'";
			}
            
			OleDbDataAdapter adapter = new OleDbDataAdapter(sql, dbCon);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			dbCon.Close();
			Telerik.WebControls.RadToolbar tb = (Telerik.WebControls.RadToolbar)dockObjectToolbar.FindControl("toolbarTop");
			Telerik.WebControls.RadToolbarTemplateButton bt = (Telerik.WebControls.RadToolbarTemplateButton)tb.Items.TemplatedButtons[0];
			Telerik.WebControls.RadComboBox cb = (Telerik.WebControls.RadComboBox)bt.FindControl("RadComboBox3");
            cb.DataSource= dt;
			cb.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
