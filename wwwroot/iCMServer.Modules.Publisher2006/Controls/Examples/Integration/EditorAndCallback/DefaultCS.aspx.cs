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

namespace Telerik.IntegrationExamplesCSharp.EditorAndCallback
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : Telerik.QuickStart.XhtmlPage
	{
		protected Telerik.WebControls.RadEditor Editor1;
		protected System.Web.UI.WebControls.Label statusLabel;
		protected Telerik.WebControls.CallbackTimer Timer1;
		protected System.Web.UI.WebControls.Label labelPreview;
		protected System.Web.UI.WebControls.Label labelLastChanged;
		protected Telerik.WebControls.CallbackButton showDraft;

		private string savedText
		{
			get { if (ViewState["editorDraftText"] != null) return (string)ViewState["editorDraftText"]; else return string.Empty;}
			set { ViewState["editorDraftText"] = value;}
		}
		private DateTime lastSavedTime
		{
			get { if (ViewState["lastSavedTime"] != null) return (DateTime)ViewState["lastSavedTime"]; else return DateTime.Now;}
			set { ViewState["lastSavedTime"] = value;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Editor1.Html= "Enter your text here... The editor content will be auto saved each minute. Press the 'Show saved text' button to see the last saved draft. ";
			}
		}

		protected void Timer1_Tick(object sender, EventArgs e)
		{
			this.savedText = Editor1.Html;
			this.lastSavedTime = DateTime.Now;
			((Telerik.WebControls.CallbackTimer)sender).StatusLabel.ReadyMessage="Draft saved at "+DateTime.Now.ToString("HH:mm");
		}

		protected void showDraft_Click(object sender, EventArgs e)
		{
			labelPreview.Text = this.savedText;
			labelLastChanged.Text = "Showing draft from " + this.lastSavedTime.ToString("HH:mm:ss");
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelPreview);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelLastChanged);
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
