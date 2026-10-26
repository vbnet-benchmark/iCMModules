using System;
using System.Web.UI.WebControls;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.TreeViewExamplesCSharp.Integration.TreeviewAndMenu
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected RadTreeView RadTreeView1;
		protected RadMenu RadMenu2;
		protected Label Label1;
		protected RadMenu RadMenu1;
	
		private void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.RadTreeView1.NodeEdit += new Telerik.WebControls.RadTreeView.RadTreeViewEventHandler(this.RadTreeView1_NodeEdit);
			this.RadMenu1.ItemClicked += new Telerik.WebControls.RadMenu.RadMenuItemEventHandler(this.RadMenu1_ItemClicked);
			this.RadMenu2.ItemClicked += new Telerik.WebControls.RadMenu.RadMenuItemEventHandler(this.RadMenu2_ItemClicked);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RadMenu1_ItemClicked(object sender, ItemEventArgs e)
		{
			HandleItemClicked(e);
		}

		private void RadMenu2_ItemClicked(object sender, ItemEventArgs e)
		{
			HandleItemClicked(e);
		}

		private void HandleItemClicked(ItemEventArgs e)
		{
			switch (e.Item.Text)
			{
				case "Delete":
					RadTreeView1.SelectedNode.Remove();
					break;
				case "Add":
					RadTreeView1.SelectedNode.AddNode(new RadTreeNode("New Node"));
					break;
			}		
		}
		private void RadTreeView1_NodeEdit(object o, RadTreeNodeEventArgs e)
		{
			RadTreeNode nodeEdited = e.NodeEdited;
			string newText = e.NewText;

			nodeEdited.Text = newText;

		}
	}
}
