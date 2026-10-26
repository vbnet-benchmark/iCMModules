namespace iConsulting.iCMServer.Modules.ModuleDefinition
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Text; 
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections; 
	using iConsulting;
	using iConsulting.iCMServer; 

		/// <summary>
		///		Summary description for ModuleDefinition.
		/// </summary>
	public abstract class ModuleDefinition : clsSiteModuleControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl Minimizer;
		protected System.Web.UI.WebControls.DropDownList ddSystem;
		protected System.Web.UI.WebControls.DropDownList ddDesktop;
		protected System.Web.UI.WebControls.Label lblSystem;
		protected System.Web.UI.WebControls.Label lblDesktop;
		protected System.Web.UI.WebControls.Panel ItemInfo;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblUrl;
		protected System.Web.UI.WebControls.TextBox txtTitle;
		protected System.Web.UI.WebControls.TextBox txtUrl;
		protected System.Web.UI.WebControls.Label lblType;
		protected System.Web.UI.WebControls.TextBox txtType;
		protected System.Web.UI.WebControls.Label lblId;
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.Button btnUpdate;

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
			this.ddSystem.SelectedIndexChanged += new System.EventHandler(this.ddSystem_SelectedIndexChanged);
			this.ddDesktop.SelectedIndexChanged += new System.EventHandler(this.ddDesktop_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				BindData();
			}
		}

		private void BindData()
		{
			try
			{
				clsSiteSettings oSite   = (clsSiteSettings) HttpContext.Current.Items["SiteSettings"];
				lblType.Text			= "Type:";
				lblId.Text				= "Id:";
				lblSystem.Text			= "System:";
				lblDesktop.Text			= "Desktop:";
				lblTitle.Text			= "Title:";
				lblUrl.Text				= "Url:";
				btnUpdate.Text			= "Update"; 
				ItemInfo.Visible		= false;

				clsModuleDefinition cMD = new clsModuleDefinition(oSite.ActivePage.PageId, ModuleId);

				foreach(DataRow dr in cMD.GetServerModules().Tables[0].Rows)
				{
					ddSystem.Items.Add(new ListItem(dr["mde_name"].ToString(), dr["mde_id"].ToString()));
				}
				foreach(DataRow dr in cMD.GetStandardModules().Tables[0].Rows)
				{
					ddDesktop.Items.Add(new ListItem(dr["mde_name"].ToString(), dr["mde_id"].ToString()));
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString()); 
			}
		}

		private void ddSystem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clsSiteSettings oSite   = (clsSiteSettings) HttpContext.Current.Items["SiteSettings"];
			clsModuleDefinition cMD = new clsModuleDefinition(oSite.ActivePage.PageId, ModuleId);
			DataSet ds				= cMD.GetModule(ddSystem.SelectedValue); 
			txtId.Text				= ds.Tables[0].Rows[0]["mde_id"].ToString();
			txtTitle.Text			= ds.Tables[0].Rows[0]["mde_name"].ToString();
			txtUrl.Text				= ds.Tables[0].Rows[0]["mde_desktopsrc"].ToString();
			txtType.Text			= "Server";
			ItemInfo.Visible		= true;
		}

		private void ddDesktop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			clsSiteSettings oSite   = (clsSiteSettings) HttpContext.Current.Items["SiteSettings"];
			clsModuleDefinition cMD = new clsModuleDefinition(oSite.ActivePage.PageId, ModuleId);
			DataSet ds				= cMD.GetModule(ddDesktop.SelectedValue); 
			txtId.Text				= ds.Tables[0].Rows[0]["mde_id"].ToString();
			txtTitle.Text			= ds.Tables[0].Rows[0]["mde_name"].ToString();
			txtUrl.Text				= ds.Tables[0].Rows[0]["mde_desktopsrc"].ToString();
			txtType.Text			= "Desktop";
			ItemInfo.Visible		= true;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			clsSiteSettings oSite   = (clsSiteSettings) HttpContext.Current.Items["SiteSettings"];
			clsModuleDefinition cMD = new clsModuleDefinition(oSite.ActivePage.PageId, ModuleId);
			if(!cMD.UpdateModule(txtId.Text, txtTitle.Text, txtUrl.Text))
			{
				Response.Write("Error...");
			}
			ItemInfo.Visible		= false;
		}
	}
}
