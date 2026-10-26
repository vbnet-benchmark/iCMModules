using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;

namespace Telerik.CallbackIntegrationExamplesCSharp.ComboBox
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		
		protected System.Web.UI.WebControls.TextBox tbNewItem;
		protected Telerik.WebControls.CallbackButton btnAddNewItem;
		protected Telerik.WebControls.CallbackButton btnRemoveItem;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label Label2;
		protected Telerik.WebControls.RadComboBox RadComboBox1;
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected Telerik.WebControls.CallbackRadioButtonList rblSkin;
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackDropDownList CallbackDropDownList1;
	
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
			this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
			this.rblSkin.SelectedIndexChanged += new System.EventHandler(this.rblSkin_SelectedIndexChanged);
			this.RadCallback1.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback1_Callback);
			this.CallbackDropDownList1.SelectedIndexChanged += new System.EventHandler(this.CallbackDropDownList1_SelectedIndexChanged);
			this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadData(int category)
		{
			if (category == 0)
			{
				RadComboBox1.Items.Clear();
				RadComboBox1.Text = String.Empty;
				return;
			}
			string path = Server.MapPath("Countries.mdb");
			OleDbConnection dbCon = new OleDbConnection ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path); 
			dbCon.Open();


			OleDbDataAdapter adapter = null;

			if (category == 1)
			{
				adapter = new OleDbDataAdapter("SELECT * FROM Continents ORDER BY Name", dbCon); 
			}
			else if (category == 2)
			{
				adapter = new OleDbDataAdapter("SELECT * FROM Countries ORDER BY Name", dbCon); 
			}
			else 
			{
				adapter = new OleDbDataAdapter("SELECT * FROM Cities ORDER BY Name", dbCon); 
			}

			DataTable dt = new DataTable();
			adapter.Fill(dt);                        
			dbCon.Close();

			RadComboBox1.DataTextField = "Name";
			RadComboBox1.DataValueField = "ID";
			RadComboBox1.DataSource = dt;
			RadComboBox1.DataBind();
			RadComboBox1.Text = String.Empty;
            
			// RadComboBox1.Items.Insert(0, new RadComboBoxItem("- Select a continent -"));            
			foreach (RadComboBoxItem item in RadComboBox1.Items)
			{
				item.ToolTip = item.Text;
			}

		}
		
		private void UpdateStatusLabel()
		{
			lblStatus.Text = "Combo has " + RadComboBox1.Items.Count.ToString() + " items.";
		}

		private void btnAddNewItem_Click(object sender, System.EventArgs e)
		{
			if (tbNewItem.Text.Length == 0)
			{
				btnAddNewItem.Alert("Please, enter some text.");
				tbNewItem.BackColor = Color.Yellow;
				return;
			}
			RadComboBox1.Items.Add(new RadComboBoxItem(tbNewItem.Text));
			tbNewItem.Text = string.Empty;
			btnRemoveItem.Enabled = true;
			tbNewItem.BackColor = Color.White;			
			RadComboBox1.SelectedIndex = RadComboBox1.Items.Count - 1; 
			UpdateStatusLabel();
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(RadComboBox1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(lblStatus);
		}

		private void btnRemoveItem_Click(object sender, System.EventArgs e)
		{
			if (RadComboBox1.SelectedItem != null)
			{
				RadComboBox1.Items.Remove(RadComboBox1.SelectedIndex);
				tbNewItem.Text = string.Empty;
				if (RadComboBox1.Items.Count == 0)
				{
					btnRemoveItem.Enabled = false;
					
				}
			}
			else
			{
				btnAddNewItem.Alert("Please, select an item!");
			}
			RadComboBox1.Text = String.Empty;
			UpdateStatusLabel();
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(RadComboBox1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(lblStatus);

		}


		private void CallbackDropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			LoadData(CallbackDropDownList1.SelectedIndex);
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(RadComboBox1);
		}

		private void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			tbNewItem.Text = args.Args;
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tbNewItem);
		}

		private void rblSkin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RadComboBox1.Skin = rblSkin.SelectedItem.Value;
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(RadComboBox1);
		}
	}
}
