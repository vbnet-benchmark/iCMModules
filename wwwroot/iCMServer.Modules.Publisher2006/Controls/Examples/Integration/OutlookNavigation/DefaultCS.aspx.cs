using System;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.PanelbarExamplesCSharp.Integration
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : XhtmlPage
	{
		protected RadPanelbar RadPanelbar1;

	
		protected void TreeDrop(object sender, RadTreeNodeEventArgs NodeEvent)
		{
			// Fetch event data
			RadTreeNode sourceNode = NodeEvent.SourceDragNode;
			RadTreeNode destNode = NodeEvent.DestDragNode;    

			RadTreeView RadTreeView1 = sourceNode.TreeViewParent;
			
            
			string result = string.Empty;
			if (RadTreeView1.SelectedNodes.Count > 0)
			{
				foreach (RadTreeNode node in RadTreeView1.SelectedNodes)
				{   

					if (!node.Equals(destNode.Parent))
					{
						RadTreeNodeCollection nodeCollection = null;
						if (!node.Parent.Equals(null))
							nodeCollection=  node.Parent.Nodes;
						else
							nodeCollection = node.TreeViewParent.Nodes;
						nodeCollection.Remove(node);
						destNode.AddNode(node);
					}
					node.Selected = false;
				}
			}
			else 
			{
				if (!sourceNode.Equals(destNode.Parent))
				{
					RadTreeNodeCollection nodeCollection = null;
					if (!sourceNode.Parent.Equals(null))
						nodeCollection = sourceNode.Parent.Nodes;
					else
						nodeCollection = sourceNode.TreeViewParent.Nodes;
					nodeCollection.Remove(sourceNode);
					destNode.AddNode(sourceNode);
				}

				sourceNode.Selected = false;
			}
			destNode.Expanded = true;
			RadTreeView1.ClearSelectedNodes();   
		}
	   
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
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

	}
}
