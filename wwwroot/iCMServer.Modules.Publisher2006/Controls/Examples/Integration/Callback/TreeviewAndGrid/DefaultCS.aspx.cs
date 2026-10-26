using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackIntegarationExamplesCSharp.TreeviewAndGrid
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: Telerik.QuickStart.XhtmlPage
	{
		protected Telerik.WebControls.RadCallback callbackOutlook;
		protected Telerik.WebControls.RadTreeView treeFolders;
		protected Telerik.WebControls.RadGrid RadGrid1;
		protected System.Web.UI.WebControls.Label labelFrom;
		protected System.Web.UI.WebControls.Label labelSubject;
		protected System.Web.UI.WebControls.Label labelDate;
		protected System.Web.UI.WebControls.Label labelMessage;
		

		
		private DataSet dataSource 
		{
			get { return (DataSet)Session["dataSource"];}
			set { Session["dataSource"] = value;}
		}

		private string folderName 
		{
			get { return (string)Session["folderName"];}
			set { Session["folderName"] = value;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				folderName = "inbox";
				Session["dataSource"] = new DataSet();
				OleDbConnection MyOleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath(Request.FilePath.Substring(0,Request.FilePath.LastIndexOf('/'))+"/Mail.mdb"));
				OleDbDataAdapter MyOleDbDataAdapter = new OleDbDataAdapter();
				MyOleDbDataAdapter.SelectCommand = new OleDbCommand("Select * from Mails", MyOleDbConnection);
				MyOleDbConnection.Open();
				try
				{
					MyOleDbDataAdapter.Fill(dataSource);
				}
				finally
				{
					MyOleDbConnection.Close();
				}
			}
		}
		private void RadGrid1_NeedDataSource(object source, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			if (dataSource != null)
			{
				RadGrid1.DataSource = dataSource.Tables[0];
				RadGrid1.MasterTableView.FilterExpression = "FolderName = '"+folderName+"'";
				RadGrid1.MasterTableView.DataKeyNames = new string[] {"mailID"};
			}
			else
			{
				labelMessage.Text = "<div style='color:red;'>Your session has expired. Please reload the page.</div>";
			}
		}
		private void GetMessage(int mailID)
		{
			if (dataSource != null)
			{
				DataRow[] dtRows = dataSource.Tables[0].Select("mailID = '"+mailID.ToString()+"'");
				if (dtRows.Length>0)
				{
					labelFrom.Text = (string)dtRows[0]["Name"] + " (" + (string)dtRows[0]["From"] + ")";
					labelDate.Text = ((DateTime)dtRows[0]["Received"]).ToString("MM/dd/yyyy");
					labelSubject.Text = (string)dtRows[0]["Subject"];
					labelMessage.Text = (string)dtRows[0]["Content"];
				}
				else 
				{
					labelFrom.Text = String.Empty;
					labelDate.Text = String.Empty;
					labelSubject.Text = String.Empty;
					labelMessage.Text = String.Empty;
				}
			}
			else
			{
				labelMessage.Text = "<div style='color:red;'>Your session has expired. Please reload the page.</div>";
			}
		}
		private int GetDataKey(Telerik.WebControls.RadGrid grid, int rowIndex)
		{
			Telerik.WebControls.GridItem item = (Telerik.WebControls.GridItem)((System.Web.UI.WebControls.Table)grid.MasterTableView.Controls[0]).Rows[rowIndex];

			return (int)grid.MasterTableView.DataKeyValues[item.ItemIndex]["mailID"];
		}
		protected void outlookCallback_Callback(object sender, Telerik.WebControls.CallbackEventArgs e)
		{
			switch (e.CallbackEvent)
			{
				case "OpenFolder":
					folderName = e.Args;
					RadGrid1.CurrentPageIndex = 0;
					RadGrid1.Rebind();
					labelFrom.Text = String.Empty;
					labelDate.Text = String.Empty;
					labelSubject.Text = String.Empty;
					labelMessage.Text = String.Empty;
					((RadCallback)sender).ControlsToUpdate.Add(RadGrid1);
					((RadCallback)sender).ControlsToUpdate.Add(labelMessage);
					((RadCallback)sender).ControlsToUpdate.Add(labelFrom);
					((RadCallback)sender).ControlsToUpdate.Add(labelDate);
					((RadCallback)sender).ControlsToUpdate.Add(labelSubject);
					break;
				case "OpenMail":
					int mailID = GetDataKey(RadGrid1, int.Parse(e.Args));
					GetMessage(mailID);
					((RadCallback)sender).ControlsToUpdate.Add(labelMessage);
					((RadCallback)sender).ControlsToUpdate.Add(labelFrom);
					((RadCallback)sender).ControlsToUpdate.Add(labelDate);
					((RadCallback)sender).ControlsToUpdate.Add(labelSubject);
					break;
				default:
					break;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.RadGrid1.NeedDataSource += new Telerik.WebControls.GridNeedDataSourceEventHandler(this.RadGrid1_NeedDataSource);
		}
		#endregion
			
	}
}
