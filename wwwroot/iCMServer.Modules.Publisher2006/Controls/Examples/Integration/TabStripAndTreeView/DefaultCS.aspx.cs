using System;
using System.Web.UI.WebControls;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.TabStripExamplesCSharp.Integration.TabstripAndTreeView
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : XhtmlPage
	{
		protected RadTabStrip TabStrip1;
		protected RadTreeView RadTree1;
		protected CallbackButton Button1;
		protected TextBox TextBox1;
		protected Label Label2;
		protected RadMultiPage MultiPage1;
		protected Label Label1;

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
			TextBox1 = (TextBox)MultiPage1.FindControl("TextBox1");
			Label1 = (Label)MultiPage1.FindControl("Label1");
			RadTree1 = (RadTreeView)MultiPage1.FindControl("RadTree1");
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		protected void Button1_Click(object sender, EventArgs e)
		{
			RadTreeNode node = RadTree1.FindNodeByText(TextBox1.Text);
			if (node != null)
			{
				if (RadTree1.SelectedNode != null)
				{
					RadTree1.SelectedNode.Selected = false;	
				}
				
				node.ExpandParentNodes();
				node.Expanded = true;
				node.Selected = true;
				MultiPage1.SelectedIndex = 1;
				TabStrip1.SelectedIndex = 1;
			}
			else
			{
				MultiPage1.SelectedIndex = 0;
				TabStrip1.SelectedIndex = 0;
				Label1.Text = "No match!";
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(RadTree1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(TabStrip1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(MultiPage1);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(Label1);
		}
	}
}
