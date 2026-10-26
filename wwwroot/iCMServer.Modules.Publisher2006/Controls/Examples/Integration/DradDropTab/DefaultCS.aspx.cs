using System;
using System.Collections;
using System.Web.UI.WebControls;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.TabStripExamplesCSharp.Integration.Explorer
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : XhtmlPage
	{
		protected Telerik.WebControls.RadCallback genericCallback;
		protected Telerik.WebControls.RadTreeView RadTreeView1;
		protected System.Web.UI.WebControls.Panel panelLoadingImage;
		protected Telerik.WebControls.RadTabStrip RadTabStrip1;
		protected System.Web.UI.WebControls.TextBox TextBoxTo;
		protected Telerik.WebControls.CallbackButton SendEmail;
		protected System.Web.UI.WebControls.TextBox TextBoxCc;
		protected System.Web.UI.WebControls.TextBox TextBoxSubject;
		protected System.Web.UI.WebControls.Label Attachments;
		protected Telerik.WebControls.PageView Page1;
		protected Telerik.WebControls.RadTreeView RadTreeView2;
		protected Telerik.WebControls.PageView Page2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected Telerik.WebControls.PageView Page3;
		protected Telerik.WebControls.RadMultiPage multiPageContent;
	
		private ArrayList GridData
		{
			get 
			{
				return (ArrayList)Session["GridDataArray"];
			}
			set
			{
				Session["GridDataArray"] = value;
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				GridData = new ArrayList();
				GridData.Add("App_Themes");
				GridData.Add("bin");
				GridData.Add("RadControls");
				DataGrid1.DataSource = GridData;
				DataGrid1.DataBind();
			}
		}

		protected void SendEmail_Click(object sender, System.EventArgs e)
		{
			TextBoxTo.Text = String.Empty;
			TextBoxCc.Text = String.Empty;
			TextBoxSubject.Text = String.Empty;
			Attachments.Text = String.Empty;
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(TextBoxTo);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(TextBoxCc);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(TextBoxSubject);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(Attachments);
		}

		protected void genericCallback_Callback(object sender, Telerik.WebControls.CallbackEventArgs e)
		{
			string [] args = e.Args.Split('\n');
			RadTreeNode sourceNode = null, destNode = null;
			if (args.Length>0)
				sourceNode = GetNodeByClientId(RadTreeView1, args[0]);
			else
				return;
			switch (e.CallbackEvent)
			{
				case "TreeDropPage1":
					Attachments.Text += sourceNode.Text + "<br />";
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(Attachments);
					this.RadTabStrip1.SelectedIndex=0;
					this.multiPageContent.SelectedIndex=0;
					break;
				case "TreeDropPage2":
					if (args.Length>1)
					{
						destNode = GetNodeByClientId(RadTreeView2, args[1]);
						if (destNode != null)
						{
							RadTreeNode newNode = new RadTreeNode(sourceNode.Text);
							newNode.Image = "SSFolder.gif";
							destNode.Nodes.Add(newNode);
							destNode.Expanded = true;
						}
					}
					else
					{
						RadTreeNode newNode = new RadTreeNode(sourceNode.Text);
						newNode.Image = "SSFolder.gif";
						RadTreeView2.Nodes[0].Nodes.Add(newNode);
					}
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(RadTreeView2);
					this.RadTabStrip1.SelectedIndex=1;
					this.multiPageContent.SelectedIndex=1;
					break;
				case "TreeDropPage3":
					GridData.Add(sourceNode.Text);
					DataGrid1.DataSource = GridData;
					DataGrid1.DataBind();
					this.RadTabStrip1.SelectedIndex=2;
					this.multiPageContent.SelectedIndex=2;
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(DataGrid1);
					break;
				default:
					break;
			}
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(RadTabStrip1);
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(multiPageContent);
		}

		private RadTreeNode GetNodeByClientId(RadTreeView treeView, string nodeId)
		{
			foreach(RadTreeNode node in treeView.GetAllNodes())
			{
				if (node.ClientID==nodeId)
					return node;
			}
			return null;
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
