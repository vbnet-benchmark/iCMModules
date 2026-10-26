using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.CallbackIntegrationExamplesCSharp.Panelbar
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		protected Telerik.WebControls.RadPanelbar RadPanelbar1;

		protected Telerik.WebControls.RadCallback RadCallback1;
		protected Telerik.WebControls.RadPanelbar RadPanelbar2;
		protected Telerik.WebControls.CallbackDropDownList ddlDataSource;

		
		
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
			this.ddlDataSource.SelectedIndexChanged += new System.EventHandler(this.ddlDataSource_SelectedIndexChanged);
			this.RadPanelbar2.PanelItemDataBound += new Telerik.WebControls.RadPanelbar.RadPanelbarPanelItemDataBoundEventHandler(this.RadPanelbar2_PanelItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	
		
		private Control GetPanelbarControl(string ID)
		{
			return RadPanelbar1.FindControl(ID);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{			
			if (!Page.IsPostBack)
			{
				LoadData();
			}
		}
	
		private void LoadFromContentFile(RadPanelbar panelbar)
		{
			RadPanelbar2.AfterClientPanelItemClicked = "itemClick";
			RadPanelbar2.LoadContentFromXmlFile("panelbar.xml");			
		}

		private void LoadFromDatabase(RadPanelbar panelbar)
		{
			RadPanelbar2.AfterClientPanelItemClicked = string.Empty;
			OleDbConnection OldDbCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath("Panelbar.mdb") + ";User ID=;Password=;");
			OleDbDataAdapter adpPanelBar = new OleDbDataAdapter("SELECT * FROM Panelbar", OldDbCon);
			DataSet dsPanelBar = new DataSet();
			adpPanelBar.Fill(dsPanelBar);
			panelbar.DataFieldID = "ID";
			panelbar.DataFieldParentID = "ParentID";
			panelbar.DataSource = dsPanelBar;
			panelbar.DataBind();
		}

		private void LoadData()
		{
			
			if (ddlDataSource.SelectedIndex == 0)
			{				
				LoadFromContentFile(RadPanelbar2);
			}
			else
			{
				LoadFromDatabase(RadPanelbar2);
			}
			foreach (PanelItem item in RadPanelbar2.PanelItems)
			{				
				item.SubGroupCssClass = "panelbarItemGroup";
			}
		}

			

		protected void btnCallbackSubmit_Click(object sender, System.EventArgs e)
		{		
			Label label = (Label) RadPanelbar1.FindControl("lSubmittedText");
			TextBox textBox =  (TextBox) RadPanelbar1.FindControl("tbTextToSubmit");
			
			string text = textBox.Text;
			if (text.Length == 0)
			{
				text = "[empty]";
				textBox.BackColor = Color.Yellow;
			}	
			else
			{
				textBox.BackColor = Color.White;
			}
			label.Text = text;		
			textBox.Text = string.Empty;
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(RadPanelbar1);
		}

		protected void clbSelectedItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Label label  = (Label) GetPanelbarControl("lSelectedItems"); 			
			CallbackCheckBoxList callbackCheckListBox = (CallbackCheckBoxList) GetPanelbarControl("cblSelectedItems");			
			string text = string.Empty;
			foreach (ListItem item in callbackCheckListBox.Items)
			{
				if (item.Selected)
				{
					text += item.Text + " ";
				}
			}
			if (text.Length == 0)
			{
				text = "[No Selected Items]";
			}
			label.Text = text;
			((Telerik.WebControls.CallbackCheckBoxList)sender).ControlsToUpdate.Add(RadPanelbar1);
		}

		protected void lbItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CallbackListBox listBox = (CallbackListBox) GetPanelbarControl("lbItems");
			Label			label = (Label) GetPanelbarControl("lSelectedItems2");			
			string text = string.Empty;
			foreach (ListItem item in listBox.Items)
			{
				if (item.Selected)
				{
					text += item.Text + " ";
				}
			}
			if (text.Length == 0)
			{
				text = "[No Selected Items]";
			}
			label.Text = text;
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(RadPanelbar1);			
		}

		private void RadPanelbar2_PanelItemDataBound(object sender, Telerik.WebControls.RadPanelbarPanelItemDataBoundEventArgs e)
		{
			if (!e.DataBoundDataRow.IsNull("Label"))
				e.DataBoundPanelItem.Text = e.DataBoundDataRow["Label"].ToString();			
		}

		private void ddlDataSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadData();
			ddlDataSource.ControlsToUpdate.Add(RadPanelbar2);
		}

		private void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{	
			PanelItem item = RadPanelbar2.FindPanelItemById(args.Args);

			if (item != null)
			{
				switch (item.Value)
				{
					case "Remove":					
						PanelItem parent = (PanelItem) item.ParentItem;
						parent.PanelItems.Remove(item);						
						break;
					case "Disable":
						item.Enabled = false;						
						RadPanelbar2.SelectedPanelItem = null;
						break;
					case "Add":
						PanelItem newItem = new PanelItem(RadPanelbar2.PanelItems[2], RadPanelbar2);
						newItem.ID = "Panel3_" + RadPanelbar2.PanelItems[2].PanelItems.Count.ToString() + "2";
						newItem.Text = "Copy of " + item.Text;
						RadPanelbar2.PanelItems[2].PanelItems.Add(newItem);
						RadPanelbar1.SelectedPanelItem = null;
						break;
					default:
						RadCallback1.Alert("Action canceled!");
						break;
				}	
				RadCallback1.ControlsToUpdate.Add(RadPanelbar2);
			}			
		}		
	}
}
