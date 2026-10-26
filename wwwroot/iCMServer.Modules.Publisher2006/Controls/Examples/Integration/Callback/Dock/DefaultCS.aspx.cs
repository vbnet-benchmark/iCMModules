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
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackIntegrationExamplesCSharp.Dock
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected Telerik.WebControls.CallbackButton btnLoadState;
		protected Telerik.WebControls.CallbackButton btnSaveState;
		protected Telerik.WebControls.RadDockingManager RadDockingManager1;
		protected Telerik.WebControls.RadDockableObject dockObject2;
		protected Telerik.WebControls.RadDockableObject dockObject3;
		protected Telerik.WebControls.RadDockableObject dockObject1;
		protected Telerik.WebControls.RadDockingZone dockZone1;
		protected Telerik.WebControls.RadDockingZone dockZone2;
		protected Telerik.WebControls.RadDockingZone dockZone3;
		protected System.Web.UI.WebControls.TextBox tbConfigName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ListBox lbSavedConfigs;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;

		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.btnLoadState.Click += new System.EventHandler(this.btnLoadState_Click);
			this.btnSaveState.Click += new System.EventHandler(this.btnSaveState_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLoadState_Click(object sender, System.EventArgs e)
		{	
			if (lbSavedConfigs.SelectedIndex > -1)
			{
				dockZone1.DockableObjects.Clear();
				dockZone2.DockableObjects.Clear();
				dockZone3.DockableObjects.Clear();
				if (Session["DockState_" + lbSavedConfigs.SelectedItem.Text] != null)
				{					
					RadDockingManager1.LoadState( (string) Session["DockState_" + lbSavedConfigs.SelectedItem.Text] );
					Label2.Text = "Dock configration " + lbSavedConfigs.SelectedItem.Text + " is loaded.";
					btnLoadState.ControlsToUpdate.Add(Panel1);
					btnLoadState.ControlsToUpdate.Add(Panel2);
					btnLoadState.ControlsToUpdate.Add(Panel3);
					btnLoadState.ControlsToUpdate.Add(Label2);
				}		
				else
				{
					btnLoadState.Alert("No saved dock state!");
				}
			}
			else
			{
				btnLoadState.Alert("Please, select a dock configuratation from the dropdown list.");
			}			
		}

		private void btnSaveState_Click(object sender, System.EventArgs e)
		{
			if (tbConfigName.Text.Length == 0)
			{
				tbConfigName.BackColor = Color.Yellow;
				btnSaveState.ControlsToUpdate.Add(tbConfigName);
				btnSaveState.Alert("Please, enter a name for configuration.");
				return;
			}
			Session["DockState_" + tbConfigName.Text] = RadDockingManager1.SaveState();
			Label2.Text = "State " + tbConfigName.Text + " is saved.";
			lbSavedConfigs.Items.Add(tbConfigName.Text);
			tbConfigName.Text = string.Empty;
			
			btnSaveState.ControlsToUpdate.Add(lbSavedConfigs);
			btnSaveState.ControlsToUpdate.Add(tbConfigName);
			btnSaveState.ControlsToUpdate.Add(Label2);
		}
	
		protected void Button_Click(object sender, System.EventArgs e)
		{	
			CallbackButton button = (CallbackButton) sender;
			System.Web.UI.WebControls.Label control = null;
			if (button.ID.Equals("CallbackButton1"))
			{
				control = (System.Web.UI.WebControls.Label) dockObject2.FindControl("Label21");
				control.Text = DateTime.Now.ToString();
			} 
			else if (button.ID.Equals("CallbackButton2"))
			{
				control = (System.Web.UI.WebControls.Label) dockObject3.FindControl("Label31");
				control.Text = DateTime.Now.ToString();
			}							
			else if (button.ID.Equals("CallbackButton3"))
			{
				control = (System.Web.UI.WebControls.Label) dockObject1.FindControl("Label11");				
				control.Text = DateTime.Now.ToString();
			}
			if (control != null)
				button.ControlsToUpdate.Add(control);	
		}
	}
}
