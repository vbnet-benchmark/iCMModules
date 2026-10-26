using System;
using System.Collections;
using System.Data;
using System.Xml;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.CallbackIntegrationExamplesCSharp.TabStrip
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackDropDownList ddlDataSource;
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected System.Web.UI.WebControls.Label Label2;
		protected Telerik.WebControls.CallbackListBox lbActiveTab;
		protected Telerik.WebControls.RadMultiPage RadMultiPage1;
		protected Telerik.WebControls.RadTabStrip RadTabStrip2;
		protected Telerik.WebControls.CallbackButton btnSubmit;
		protected System.Web.UI.WebControls.TextBox tbSubmitText;
		protected System.Web.UI.WebControls.Label lSubmittedText;
		protected System.Web.UI.WebControls.Label lSelectedItems;
		protected Telerik.WebControls.CallbackCheckBoxList cblItems;
		protected Telerik.WebControls.CallbackListBox lbItems;
		protected System.Web.UI.WebControls.Label llbItems;
		protected Telerik.WebControls.RadTabStrip RadTabStrip1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				LoadData();
			}	
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
			this.lbActiveTab.SelectedIndexChanged += new System.EventHandler(this.lbActiveTab_SelectedIndexChanged);
			this.RadCallback1.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback1_Callback);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadData()
		{
			if (ddlDataSource.SelectedIndex == 0)
			{
				LoadFromXml(RadTabStrip1);
			}
			else
			{
				LoadFromDatabase(RadTabStrip1);
			}
			lbActiveTab.Items.Clear();
			foreach (Tab tab in RadTabStrip1.Tabs)
			{
				lbActiveTab.Items.Add(new ListItem(tab.Text, tab.Value));
			}
		}

		private void LoadFromXml(RadTabStrip tabStrip)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Request.MapPath("TabStrip.xml"));
			tabStrip.Tabs.Clear();
			tabStrip.SelectedIndex = -1;
			FillTabs(tabStrip.Tabs, xmlDoc.DocumentElement);
			tabStrip.OnClientTabSelected = "onTabClick";
		}
		private void FillTabs(TabCollection tabCollection, XmlElement rootElement)
		{
			foreach (XmlNode child in rootElement.ChildNodes)
			{
				if (child.NodeType == XmlNodeType.Element)
				{
					if (child.Name == "Tab")
					{
						Tab tab = new Tab();
						tab.ID = child.Attributes["ID"].Value;
						tab.Text = child.Attributes["Text"].Value;
						tab.Value = child.Attributes["Value"].Value;
						tabCollection.Add(tab);
						FillTabs(tab.Tabs, (XmlElement)child);
					}
				}
			}
		}

		private void LoadFromDatabase(RadTabStrip tabStrip)
		{
			OleDbConnection OldDbCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath("TabStrip.mdb") + ";User ID=;Password=;");
			OleDbDataAdapter adpTabStrip = new OleDbDataAdapter("SELECT * FROM TabStrip", OldDbCon);
			DataSet dsTabStrip = new DataSet();
			adpTabStrip.Fill(dsTabStrip);
			tabStrip.DataFieldID = "ID";
			tabStrip.DataValueField = "ID";
			tabStrip.DataFieldParentID = "ParentID";
			tabStrip.DataTextField = "Text";
			tabStrip.DataSource = dsTabStrip;
			tabStrip.DataBind();
			tabStrip.OnClientTabSelected = string.Empty;
			tabStrip.SelectedIndex = -1;
		}

		protected void ddlDataSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadData();
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(RadTabStrip1);
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(lbActiveTab);
		}

		protected void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			Tab tab = (Tab)RadTabStrip1.FindTabByText(args.Args);
			if (tab != null)
			{
				if (tab.Value == "Add")
				{
					Tab newTab = new Tab("Copy of " + tab.Text);
					newTab.Width = Unit.Pixel(100);
					RadTabStrip1.Tabs[0].Tabs.Add(newTab);
				}
				else if (tab.Value == "Remove")
				{
					RadTabStrip1.Tabs[1].SelectedIndex = -1;
					RadTabStrip1.Tabs[1].Tabs.Remove(tab);
				}
				else if (tab.Value == "Disable")
				{
					tab.Enabled = false;
				}
				else
				{
					if (tab.Tabs.Count == 0)
					{
						RadCallback1.Alert("Action not applicable!");
					}
				}
				((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(RadTabStrip1);
			}
		}

		protected void lbActiveTab_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Tab tab = (Tab)RadTabStrip1.FindTabByValue(lbActiveTab.SelectedItem.Value);
			RadTabStrip1.SelectedIndex = RadTabStrip1.Tabs.IndexOf(tab);
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(RadTabStrip1);
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string text = tbSubmitText.Text;
			if (text == string.Empty)
			{
				tbSubmitText.BackColor = Color.Yellow;
				text = "[empty]";			
			}
			else
			{
				tbSubmitText.BackColor = Color.White;
			}
			lSubmittedText.Text = text;
			tbSubmitText.Text = string.Empty;
			this.RadTabStrip2.SelectedIndex = 0;
			this.RadMultiPage1.SelectedIndex = 0;
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tbSubmitText);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(lSubmittedText);
		}

		protected void cblItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			string text = string.Empty;
			foreach (ListItem item in cblItems.Items)
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
			lSelectedItems.Text = text;			
			this.RadTabStrip2.SelectedIndex = 1;
			this.RadMultiPage1.SelectedIndex = 1;
			((Telerik.WebControls.CallbackCheckBoxList)sender).ControlsToUpdate.Add(RadTabStrip2);
			((Telerik.WebControls.CallbackCheckBoxList)sender).ControlsToUpdate.Add(RadMultiPage1);
		}

		
		protected void lbItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string text = string.Empty;
			foreach (ListItem item in lbItems.Items)
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
			llbItems.Text = text;			
			this.RadTabStrip2.SelectedIndex = 2;
			this.RadMultiPage1.SelectedIndex = 2;
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(RadTabStrip2);
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(RadMultiPage1);
		}
	}
}
