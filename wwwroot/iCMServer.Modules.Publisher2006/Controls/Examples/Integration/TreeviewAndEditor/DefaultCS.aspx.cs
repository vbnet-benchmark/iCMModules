using System;
using System.IO;
using System.Text.RegularExpressions;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.TreeViewExamplesCSharp.Integration.TreeviewAndEditor
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected RadTreeView RadTreeView1;
		protected RadEditor RadEditor1;

		private void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PopulateTreeViewFromDirectory(RadTreeView1.Nodes, Server.MapPath("~/Editor/Img/UserDir"));
				RadTreeView1.Nodes[0].Expanded = true;
			}
		}

		private void PopulateTreeViewFromDirectory(RadTreeNodeCollection nodes,
			string _path)
		{
			string[] _directories = Directory.GetDirectories(_path);
			foreach (string _directory in _directories)
			{
				RadTreeNode node = new RadTreeNode();
				node.Text = Path.GetFileName(_directory);
				node.Image = "folder.gif";
				node.Category = "Folder";
				nodes.Add(node);
				PopulateTreeViewFromDirectory(node.Nodes, _directory);
			}
			string [] _files = Directory.GetFiles(_path);
			foreach ( string _file in _files )
			{
				if (IsSupportedFileType(_file))
				{
					RadTreeNode node = new RadTreeNode();
					node.Text = Path.GetFileName(_file);
					node.Image = Path.GetExtension(_file).Substring(1) + ".gif";
					node.Value = ConvertAbsoluteToRelative(_file);
					nodes.Add(node);
				}
			}
		}

		private bool IsSupportedFileType(string file)
		{
			string pat = "(\\.gif|\\.jpg|\\.jpeg|\\.png)$";
			return Regex.IsMatch(file, pat, RegexOptions.IgnoreCase);
		}
		
		private string  ConvertAbsoluteToRelative(string absolute)
		{
			string relative = absolute.Replace(MapPath(Request.ApplicationPath), Request.ApplicationPath);
			return relative.Replace("\\", "/");
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
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

	}
}
