using System;
using System.Collections;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.WebControls;
using System.Web.UI.WebControls;
using Telerik.QuickStart;

namespace Telerik.GridExamplesCSharp.Integration.GridAndTreeView
{
	public class DefaultCS : XhtmlPage
	{
		protected RadTreeView RadTree1;
		protected RadGrid RadGrid1;
		protected RadCallback genericCallback;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadTreeView(Server.MapPath("~/Controls/Examples/Integration"));
			}
		}


		private void LoadGrid(string directory)
		{
			DirectoryInfo dir = new DirectoryInfo(directory);
			DataTable filesAndFolders = new DataTable();
			filesAndFolders.Columns.Add("Name");
			filesAndFolders.Columns.Add("Size");
			filesAndFolders.Columns.Add("FullPath");
			foreach(DirectoryInfo subDir in dir.GetDirectories())
			{
				filesAndFolders.Rows.Add(new string[] {subDir.Name, "-1", subDir.FullName});
			}
			foreach(FileInfo file in dir.GetFiles())
			{
				filesAndFolders.Rows.Add(new string[] {file.Name, file.Length.ToString(), file.FullName});
			}

			RadGrid1.DataSource = filesAndFolders;
		}


		private void LoadTreeView(string folder)
		{
			RadTreeNode rootNode = new RadTreeNode(folder);
			rootNode.Image = "Folder.gif";
			rootNode.Expanded = true;
			rootNode.Category = "Folder";
			rootNode.Value = folder;
			RadTree1.AddNode(rootNode);

			BindDirectory(folder, rootNode.Nodes);	

			RadTree1.LoadingMessagePosition = LoadingMessagePosition.BeforeNodeText; 
			RadTree1.LoadingMessageCssClass = "LoadingMessageBlue";
			RadTree1.LoadingMessage = "(loading ..)";
		}


		protected void RadTree1_NodeExpand(object o, RadTreeNodeEventArgs e)
		{
			RadTreeNode folderNode = e.NodeClicked;	
			string path = folderNode.Value;
			folderNode.Nodes.Clear();
			BindDirectory(path, folderNode.Nodes);
		}


		private void BindDirectory(string dirPath, RadTreeNodeCollection collection)
		{			
			string[] dirs = Directory.GetDirectories(dirPath);
			foreach (string path in dirs)
			{
				string[] parts = path.Split('\\');
				string name = parts[parts.Length-1];
				RadTreeNode node = new RadTreeNode(name);
				node.Image = "Folder.gif";
				node.Value = path;
				node.Category = "Folder";

				if (Directory.GetDirectories(path).Length > 0)
				{
					node.ExpandMode = ExpandMode.ServerSideCallBack;
				}
				collection.Add(node);
			}
		}


		private string GetImageForExtension(string fileName)
		{
			string image = "File.gif";
			switch(Path.GetExtension(fileName))
			{
				case ".cs" : image = "cs.gif"; break;
				case ".css" : image = "css.gif"; break;
				case ".html" : image = "html.gif"; break;
				case ".resx" : image = "resx.gif"; break;
				case ".vb" : image = "vb.gif"; break;
				case ".xml" : image = "xml.gif"; break;
				case ".ascx" : image = "ascx.gif"; break;
				case ".gif" : 
				case ".jpg" : image = "gif.gif"; break;
				case "": image = "folder.gif";break;
			}
			return image;
		}


		private bool GridItemSelected(string path)
		{
			if (System.IO.Directory.Exists(path))
			{
				RadTreeNode node = RadTree1.FindNodeByValue(path), tempNode = null;
			
				if (node == null && RadTree1.Nodes.Count>0)
				{
					node = RadTree1.Nodes[0];
					string dirParts = path.Replace(node.Value,"");
					if (dirParts.StartsWith("\\")) dirParts = dirParts.Remove(0,1);

					foreach (string folder in dirParts.Split('\\'))
					{	
						tempNode = RadTree1.FindNodeByValue(node.Value+"\\"+folder);
						if (tempNode==null)
						{
							BindDirectory(node.Value, node.Nodes);
							node = RadTree1.FindNodeByValue(node.Value+"\\"+folder);
						}
						else 
						{
							node = tempNode;
						}
					}
				}

				if (node != null)
				{
					BindDirectory(path, node.Nodes);
					node.Expanded = true;
					if (RadTree1.SelectedNode != null)
					{
						RadTree1.SelectedNode.Selected = false;
					}
					node.Selected = true;
					node.ExpandParentNodes();
					LoadGrid(path);
					RadGrid1.DataBind();
				}
			}
			else if (System.IO.File.Exists(path))
			{
				//do something with the file
				//currently nothing to do so we return false and do not update anything
				return false;
			}
			return true;			
		}


		protected void genericCallback_Callback(object o, CallbackEventArgs e)
		{
			switch (e.CallbackEvent)
			{
				case "NodeClick":
					LoadGrid(e.Args);
					RadGrid1.DataBind();
					genericCallback.ControlsToUpdate.Add(RadGrid1);
					break;
				case "GridDblClick":
					int itemIndex = int.Parse(e.Args);
					GridItem item = (GridItem)(((Table)RadGrid1.MasterTableView.Controls[0] ).Rows[itemIndex]);
					string fullPath = ((Label)item.FindControl("pathLabel")).Text;
					if (GridItemSelected(fullPath))
					{
						genericCallback.ControlsToUpdate.Add(RadTree1);
						genericCallback.ControlsToUpdate.Add(RadGrid1);
					}
					break;
				default:
					break;
			}
		}


		protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridDataItem)
			{
				System.Web.UI.WebControls.Image icon = (System.Web.UI.WebControls.Image)e.Item.FindControl("icon");
				icon.ImageUrl = RadTree1.ImagesBaseDir + GetImageForExtension((string)DataBinder.Eval(e.Item.DataItem, "Name"));
				icon.AlternateText = "icon";
				//icon.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsMiddle;
				icon.Style.Add("vertical-align","middle");
				icon.BorderWidth = Unit.Pixel(0);
				GridDataItem dataItem = (GridDataItem)e.Item;

				string fileLength = (string)DataBinder.Eval(e.Item.DataItem, "Size");
				if (fileLength != "-1")
					dataItem["Size"].Text = fileLength;
				else
					dataItem["Size"].Text = "";
			}
		}


		protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			if (RadTree1.SelectedNode != null)
			{
				LoadGrid(RadTree1.SelectedNode.Value);	
			}
			else
			{
				LoadGrid(Server.MapPath("~/Controls/Examples/Integration"));
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
			this.RadTree1.NodeExpand += new Telerik.WebControls.RadTreeView.RadTreeViewEventHandler(this.RadTree1_NodeExpand);
			this.RadGrid1.NeedDataSource += new Telerik.WebControls.GridNeedDataSourceEventHandler(this.RadGrid1_NeedDataSource);
			this.RadGrid1.ItemDataBound += new Telerik.WebControls.GridItemEventHandler(this.RadGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

	}
}
