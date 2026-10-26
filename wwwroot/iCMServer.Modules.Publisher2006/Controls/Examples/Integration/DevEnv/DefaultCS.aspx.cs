using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Telerik.IntegrationExamplesCSharp.Devenv
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : System.Web.UI.Page
	{
		protected Telerik.WebControls.RadToolbar toolbarTop;
		protected Telerik.WebControls.RadDockingManager RadDockingManager1;
		protected Telerik.WebControls.RadMenu menuTop;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			toolbarTop.SkinsDir = this.TemplateSourceDirectory+"/Toolbar/";
			toolbarTop.Skin = "vsnet";
			RadDockingManager1.SkinsPath = this.TemplateSourceDirectory+"/Dock/";
			RadDockingManager1.Skin = "vsnetoutput";
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
