using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.WebControls.RadEditorUtils;

namespace Telerik.CallbackIntegrationExamplesCSharp.Editor
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		protected Telerik.WebControls.RadEditor editor1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackButton btnToggleEditorVisibility;
		protected Telerik.WebControls.CallbackListBox lbArticles;
		protected Telerik.WebControls.CallbackCheckBoxList cblToolbars;
		protected Telerik.WebControls.CallbackRadioButtonList rblSkin;
		protected HtmlInputHidden EditedNews;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				cblToolbars.Items.Clear();				
				foreach (Toolbar toolBar in editor1.Toolbars)
				{
					cblToolbars.Items.Add(toolBar.Name);
					cblToolbars.Items[cblToolbars.Items.Count - 1].Selected = true;
				}				
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		protected void editor1_EditableChanged(object src, Telerik.WebControls.EditableChangedEventArgs e)
		{
			btnToggleEditorVisibility.Text = btnToggleText(e.Editable);
		}
		private string btnToggleText(bool editorVisible)
		{
			if (editorVisible)
			{
				return "Hide Editor";
			}
			else
			{
				return "Show Editor";
			}
		}
		protected void btnToggleEditorVisibility_Click(object sender, System.EventArgs e)
		{
			editor1.Editable = !editor1.Editable;
			btnToggleEditorVisibility.Text = btnToggleText(editor1.Editable);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(editor1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(btnToggleEditorVisibility);
		}

		protected void cblToolbars_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			foreach (System.Web.UI.WebControls.ListItem item in cblToolbars.Items)
			{
				Toolbar toolBar = editor1.Toolbars[item.Text];
				toolBar.IsEnabled = item.Selected;
			}
			((Telerik.WebControls.CallbackCheckBoxList)sender).ControlsToUpdate.Add(editor1);
		}

		private OleDbConnection CreateConnection()
		{
			OleDbConnection connection = new OleDbConnection();
			connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Request.MapPath(this.TemplateSourceDirectory + "\\News.mdb") + ";User ID=;Password=;";
			connection.Open();
			return connection;
		}

		protected void rblSkin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			editor1.Skin = rblSkin.SelectedItem.Text;
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(editor1);
		}

		protected void lbArticles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = CreateConnection();

			OleDbCommand command = new OleDbCommand("SELECT NewsText FROM News WHERE NewsID = @nid", connection);
			command.Parameters.Add("nid", lbArticles.SelectedItem.Value);
			OleDbDataReader record = command.ExecuteReader();
			if (record.Read())
			{
				editor1.Html = record.GetString(0);
				EditedNews.Value = lbArticles.SelectedItem.Value;
			}
			else
			{
				editor1.Html = "";
				EditedNews.Value = "";
			}
			record.Close();
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(editor1);
		}
	}
}
