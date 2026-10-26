using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackIntegarationExamplesCSharp.RotatorAndCallback
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected Telerik.WebControls.RadCallback genericCallback;
		protected System.Web.UI.WebControls.Panel panelImagePreviewLoading;
		protected Telerik.WebControls.CallbackImage imagePreview;
		protected System.Web.UI.WebControls.Label labelImageName;
		protected System.Web.UI.WebControls.Label labelImageKeywords;
		protected System.Web.UI.WebControls.Label labelImageComments;
		protected System.Web.UI.WebControls.Panel viewPanel;
		protected System.Web.UI.WebControls.TextBox textImageName;
		protected System.Web.UI.WebControls.TextBox textImageKeywords;
		protected System.Web.UI.WebControls.TextBox textImageComments;
		protected System.Web.UI.WebControls.Panel editPanel;
		protected System.Web.UI.WebControls.Panel panelLoadingImage;
		protected Telerik.WebControls.RadRotator thumbRotator;
		
		private System.Collections.ArrayList imagesArray
		{
			get { return (System.Collections.ArrayList)Session["imagesArray"];}
			set { Session["imagesArray"] = value;}
		}
		private struct fileInfo
		{
			public string filename;
			public string name;
			public string keywords;
			public string comments;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				imagesArray = new System.Collections.ArrayList();
				foreach (string fileName in System.IO.Directory.GetFiles(Server.MapPath(Request.FilePath.Substring(0,Request.FilePath.LastIndexOf('/')+1)+"Images"),"thumb?.gif"))
				{
					fileInfo fInfo = new fileInfo();
					fInfo.name = fileName.Substring(fileName.LastIndexOf("\\")+1);
					fInfo.filename = fInfo.name;
					fInfo.keywords = "images, telerik";
					fInfo.comments = "put comments here";
					imagesArray.Add(fInfo);
				}
				RebindRotator();
			}
		}
		private fileInfo FindFileInfo(string filePath)
		{
			string fileName = filePath.Substring(filePath.LastIndexOf('/')+1).Replace("FullSize.jpg",".gif");
			foreach (fileInfo tempInfo in imagesArray)
			{
				if (tempInfo.filename == fileName)
					return tempInfo;
			}
			return new fileInfo();
		}
		private void RebindRotator()
		{
			DataTable rotatorData = new DataTable();
			rotatorData.Columns.Add("Image");
			rotatorData.Columns.Add("Name");
			foreach (fileInfo tempInfo in imagesArray)
			{
				rotatorData.Rows.Add(new string[] {tempInfo.filename, tempInfo.name});
			}
			thumbRotator.DataSource = rotatorData;
			thumbRotator.DataBind();
		}
		protected void genericCallback_Callback(object sender, Telerik.WebControls.CallbackEventArgs e)
		{
			fileInfo fInfo;
			switch (e.CallbackEvent)
			{
				case "ShowImage":
					//show the image
					imagePreview.ImageUrl=e.Args.Replace(".gif","FullSize.jpg");
					//set the image information
					fInfo = FindFileInfo(e.Args.Substring(e.Args.LastIndexOf('/')+1));
					labelImageComments.Text = fInfo.comments;
					labelImageKeywords.Text = fInfo.keywords;
					labelImageName.Text = fInfo.name;
					textImageComments.Text = fInfo.comments;
					textImageKeywords.Text = fInfo.keywords;
					textImageName.Text = fInfo.name;
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageName);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageKeywords);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageComments);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(textImageComments);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(textImageKeywords);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(textImageName);
					((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(imagePreview);
					break;
				case "UpdateImageSettings":
					if (imagePreview.ImageUrl != "Images/spacer.gif")
					{
						fInfo = FindFileInfo(imagePreview.ImageUrl);
						imagesArray.Remove(fInfo);
						fInfo.name = textImageName.Text;
						fInfo.keywords = textImageKeywords.Text;
						fInfo.comments = textImageComments.Text;
						labelImageComments.Text = fInfo.comments;
						labelImageKeywords.Text = fInfo.keywords;
						labelImageName.Text = fInfo.name;
						imagesArray.Add(fInfo);
						RebindRotator();
						((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(thumbRotator);
						((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageName);
						((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageKeywords);
						((Telerik.WebControls.RadCallback)sender).ControlsToUpdate.Add(labelImageComments);
					}
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

		}
		#endregion

	}
}
