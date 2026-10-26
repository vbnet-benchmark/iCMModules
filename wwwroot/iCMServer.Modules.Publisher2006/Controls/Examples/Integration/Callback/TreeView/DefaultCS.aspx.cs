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

namespace Telerik.CallbackIntegarationExamplesCSharp.TreeView
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected Telerik.WebControls.RadTreeView tree2;
		protected Telerik.WebControls.RadTreeView tree1;
		protected Telerik.WebControls.RadCallback RadCallback2;
		protected System.Web.UI.WebControls.TextBox tbNodeText;
		protected Telerik.WebControls.CallbackButton btnRename;
		protected Telerik.WebControls.CallbackButton btnAddChild;
		protected Telerik.WebControls.CallbackButton btnAddRoot;
		protected System.Web.UI.WebControls.TextBox tbNewNodeText;
		protected Telerik.WebControls.CallbackButton btnToggleExpand;
		protected Telerik.WebControls.CallbackDropDownList ddlSkin;
		protected Telerik.WebControls.CallbackListBox lbSourceTree2;
		protected Telerik.WebControls.CallbackListBox lbSourceTree1;
		protected Telerik.WebControls.CallbackButton btnRemove;
	
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
			this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
			this.lbSourceTree2.SelectedIndexChanged += new System.EventHandler(this.lbSourceTree2_SelectedIndexChanged);
			this.lbSourceTree1.SelectedIndexChanged += new System.EventHandler(this.lbSource_SelectedIndexChanged);
			this.RadCallback2.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback2_Callback);
			this.btnToggleExpand.Click += new System.EventHandler(this.btnToggleExpand_Click);
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			this.btnAddRoot.Click += new System.EventHandler(this.btnAddRoot_Click);
			this.RadCallback1.Callback += new Telerik.WebControls.RadCallback.CallbackEvent(this.RadCallback1_Callback);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				LoadTree1();
				LoadTree2();
				tree1.ExpandAllNodes();
				tree2.ExpandAllNodes();
			}
		}

		private bool CheckTextBox(CallbackButton button, TextBox textBox)
		{
			if (textBox.Text.Length == 0)
			{
				button.Alert("Text for the node is required!");
				textBox.BackColor = Color.Yellow;
				return false;
			}
			else
			{
				textBox.BackColor = Color.White;
				return true;
			}
		}

		private void btnAddChild_Click(object sender, System.EventArgs e)
		{
			if (tree1.SelectedNode == null)
			{
				btnAddChild.Alert("Please, select an item!");
			}
			else
			{
				if (CheckTextBox(btnAddChild, tbNewNodeText))
				{					
					tree1.SelectedNode.AddNode(new RadTreeNode(tbNewNodeText.Text));					
					tree1.SelectedNode.ExpandChildNodes();
					tbNewNodeText.Text = string.Empty;
				}
				
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tbNewNodeText);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree1);
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if (tree2.SelectedNode != null && !tree2.SelectedNode.Equals(tree2.Nodes[0]))
			{
				tree2.SelectedNode.Remove();
				tbNodeText.Text = string.Empty;
			}
			else
			{
				if (tree2.SelectedNode == null)
				{
					btnRemove.Alert("Please, select an item!");
				}
				else
				{
					btnRemove.Alert("Root element cannot be removed!");
				}
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree2);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tbNodeText);
		}		

		private void AddChilds(RadTreeNode dstNode, RadTreeNode srcNode)
		{
		
			foreach (RadTreeNode srcChildNode in srcNode.Nodes)
			{
				RadTreeNode destChildNode = new RadTreeNode(srcChildNode.Text, srcChildNode.Value);
				dstNode.AddNode(destChildNode);
				AddChilds(destChildNode, srcChildNode);
			}
		}

		private void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			string[] treeIds = args.CallbackEvent.Split(',');

			RadTreeView srcTree = null;
			RadTreeView dstTree = null;
			
			if (tree1.ClientID.Equals(treeIds[0]))
			{
				srcTree = tree1;
			}
			else if (tree2.ClientID.Equals(treeIds[0]))
			{
				srcTree = tree2;
			}

			if (tree1.ClientID.Equals(treeIds[1]))
			{
				dstTree = tree1;
			}
			else if (tree2.ClientID.Equals(treeIds[1]))
			{
				dstTree = tree2;
			}

			string[] nodeIds = args.Args.Split(',');
			RadTreeNode sourceNode = null;
			RadTreeNode destNode = null;
			
			sourceNode = srcTree.FindNodeByText(nodeIds[0]);
			destNode = dstTree.FindNodeByText(nodeIds[1]);												
			
			if (sourceNode.Parent == null)
			{
				((Telerik.WebControls.RadCallback)sender).Alert("Cannot move the root node");
				return;
			}
			RadTreeNode tempNode = destNode;
			while (tempNode != null && !tempNode.Equals(sourceNode))
			{
				tempNode = tempNode.Parent;
			}
			if (tempNode != null)
			{
				((Telerik.WebControls.RadCallback)sender).Alert("Cannot move a node to its child");
				return;
			}
			RadTreeNode newNode = new RadTreeNode(sourceNode.Text, sourceNode.Value);							
			AddChilds(newNode, sourceNode);
			destNode.AddNode(newNode);
			destNode.ExpandChildNodes();				
			if ( !sourceNode.Equals(srcTree.Nodes[0]) )
			{
				sourceNode.Remove();					
			}			
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tree1);
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tree2);
		}

		private void RadCallback2_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{
			tree2.ClearSelectedNodes();
			RadTreeNode node = tree2.FindNodeByText(args.Args);
			node.Selected = true;
			tbNodeText.Text = args.Args;
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tbNodeText);
			((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(tree2);
		}

		private void btnRename_Click(object sender, System.EventArgs e)
		{
			if (CheckTextBox(btnRename, tbNodeText))
			{
				if (tree2.SelectedNode != null)
				{
					tree2.SelectedNode.Text = tbNodeText.Text;
					tbNodeText.Text = string.Empty;
				}
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree2);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tbNodeText);
		}

		private void btnAddRoot_Click(object sender, System.EventArgs e)
		{
			if (CheckTextBox(btnAddRoot, tbNewNodeText))
			{
				tree1.Nodes.Add(new RadTreeNode(tbNewNodeText.Text));
				tbNewNodeText.Text = string.Empty;
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tbNewNodeText);

		}
		
		private void btnToggleExpand_Click(object sender, System.EventArgs e)
		{
			if (btnToggleExpand.Text.Equals("Collapse All Nodes"))
			{				
				btnToggleExpand.Text = "Expand All Nodes";
				tree1.CollapseAllNodes();
				tree2.CollapseAllNodes();
			}	
			else
			{
				btnToggleExpand.Text = "Collapse All Nodes";
				tree1.ExpandAllNodes();
				tree2.ExpandAllNodes();				
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tree2);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(btnToggleExpand);
		}

		protected void ddlSkin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlSkin.SelectedIndex == 0)
			{
				tree1.Skin = "MSDN/Blue";					
				tree2.Skin = "MSDN/Blue";					
			}
			else if (ddlSkin.SelectedIndex == 1)
			{
				tree1.Skin = "MSDN/Classic";
				tree2.Skin = "MSDN/Classic";
			}
			else
			{
				tree1.Skin = "Round/3DBlue";
				tree2.Skin = "Round/3DBlue";
			}
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(tree1);
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(tree2);
		}

		private void GenerateTreeView(RadTreeView tree)
		{
			tree.Nodes.Clear();
			RadTreeNode currentTime = new RadTreeNode("Current Time");
			tree.AddNode(currentTime);

			RadTreeNode currentHour = new RadTreeNode("Hour : " + System.DateTime.Now.Hour.ToString());
			currentTime.AddNode(currentHour);
			RadTreeNode currentMin = new RadTreeNode("Minute : " + System.DateTime.Now.Minute.ToString());
			currentTime.AddNode(currentMin);
			RadTreeNode currentSec = new RadTreeNode("Second : " + System.DateTime.Now.Second.ToString());            
			currentTime.AddNode(currentSec);

			RadTreeNode currentDate = new RadTreeNode("Current Date");
			tree.AddNode(currentDate);

			RadTreeNode currentYear = new RadTreeNode("Year : " + System.DateTime.Now.Year.ToString());
			currentDate.AddNode(currentYear);
			RadTreeNode currentMonth = new RadTreeNode("Month : " + System.DateTime.Now.Month.ToString());
			currentDate.AddNode(currentMonth);
			RadTreeNode currentDay = new RadTreeNode("Day: " + System.DateTime.Now.Day.ToString());
			currentDate.AddNode(currentDay);            
		}   
 
		private void LoadTreeView2(RadTreeView tree)
		{
			tree.Nodes.Clear();
			OleDbConnection dbCon = new OleDbConnection ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Tree.mdb"));
			dbCon.Open();

			OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Links", dbCon);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			tree.DataFieldID = "id";
			tree.DataFieldParentID = "parentId";

			tree.DataSource = ds;
			tree.DataMember = "Links";
            tree.DataTextField = "Text";
			tree.DataBind();         
		}

		private void LoadTree1()
		{
			if (lbSourceTree1.SelectedIndex == 0)
			{
				GenerateTreeView(tree1);
			}
			else if (lbSourceTree1.SelectedIndex == 1)
			{
				LoadTreeView2(tree1);
			}
			else
			{
				tree1.LoadContentFile("tree.xml");
			}
			tree1.ExpandAllNodes();
		}

		private void LoadTree2()
		{
			if (lbSourceTree2.SelectedIndex ==0)
			{
				GenerateTreeView(tree2);
			}
			else if (lbSourceTree2.SelectedIndex ==1)
			{
				LoadTreeView2(tree2);
			}
			else
			{
				tree2.LoadContentFile("tree.xml");
			}
			tree2.ExpandAllNodes();
		}

		private void lbSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadTree1();
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(tree1);
		}

		private void lbSourceTree2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadTree2();
			((Telerik.WebControls.CallbackListBox)sender).ControlsToUpdate.Add(tree2);
		}	
	}
}
