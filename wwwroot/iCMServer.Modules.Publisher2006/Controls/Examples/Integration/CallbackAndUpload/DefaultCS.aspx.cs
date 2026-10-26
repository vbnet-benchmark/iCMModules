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
using Telerik.WebControls;

namespace Telerik.CallbackExamplesCS.Integration.CallbackAndUpload
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : Telerik.QuickStart.XhtmlPage
	{
		protected Telerik.WebControls.RadUpload upload1;
		protected Telerik.WebControls.RadUploadProgressArea progressArea1;
		protected Telerik.WebControls.CallbackRadioButtonList rblLanguages;
		protected System.Web.UI.WebControls.Label lblNoResults;
		protected System.Web.UI.WebControls.Repeater rptReqults;
		protected System.Web.UI.WebControls.Button btnSubmit;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		protected void rblLanguages_SelectedIndexChanged(object sender, EventArgs e)
		{
			upload1.Language = rblLanguages.SelectedItem.Value;
			progressArea1.Language = rblLanguages.SelectedItem.Value;
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(upload1);
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(progressArea1);
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			BindResults();
		}

		private void BindResults()
		{
			bool resultsExist = upload1.UploadedFiles.Count > 0 && !progressArea1.RequestCancelled;
			lblNoResults.Visible = !resultsExist;
			rptReqults.Visible = resultsExist;
			if (resultsExist)
			{
				rptReqults.DataSource = upload1.UploadedFiles;
				rptReqults.DataBind();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
        
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

