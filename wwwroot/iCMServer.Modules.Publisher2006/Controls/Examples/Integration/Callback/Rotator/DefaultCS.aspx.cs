using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;

namespace Telerik.CallbackIntegarationExamplesCSharp.Rotator
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackDropDownList ddlGalery;
		protected System.Web.UI.WebControls.Label Label2;
		protected Telerik.WebControls.CallbackRadioButtonList CallbackRadioButtonList1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox tbFrameTimeout;
		protected Telerik.WebControls.CallbackButton btnApply;
		protected System.Web.UI.WebControls.Label Label5;
		protected Telerik.WebControls.RadRotator RadRotator1;

		private void Page_Load(object sender, System.EventArgs e)
		{									
			if (!Page.IsPostBack)
			{
				CallbackRadioButtonList1.Items.Clear();
				foreach (string s in Enum.GetNames(typeof(RadRotator.RotatorTransitionEffect)))
				{
					CallbackRadioButtonList1.Items.Add(s);
				}
				CallbackRadioButtonList1.SelectedIndex = CallbackRadioButtonList1.Items.IndexOf(CallbackRadioButtonList1.Items.FindByText(RadRotator1.TransitionEffect.ToString()));			
				LoadGallery(ddlGalery.SelectedIndex);						
				tbFrameTimeout.Text = RadRotator1.FrameTimeout.ToString();
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
			this.ddlGalery.SelectedIndexChanged += new System.EventHandler(this.ddlGalery_SelectedIndexChanged);
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			this.CallbackRadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.CallbackRadioButtonList1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		

		private void LoadGallery(int galleryIndex)
		{			
			DataTable table = new DataTable();
			table.Columns.Add("Image");			
			table.Columns.Add("Descr");
			string galleryPrefix="Gallery";
			if (galleryIndex == 0)
			{
				galleryPrefix = "Gallery1";
			}
			else if (galleryIndex == 1)
			{
				galleryPrefix = "Gallery2";
			}
			else
			{
				galleryPrefix = "Gallery3";
			}
			table.Rows.Add(new string[] { galleryPrefix + "/Image1.jpg", "image 1" });
			table.Rows.Add(new string[] { galleryPrefix + "/Image2.jpg", "image 2" });
			table.Rows.Add(new string[] { galleryPrefix + "/Image3.jpg", "image 3" });															

			RadRotator1.DataSource = table;
			RadRotator1.DataBind();	
			
		}

		private void ddlGalery_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			LoadGallery(ddlGalery.SelectedIndex);
			((Telerik.WebControls.CallbackDropDownList)sender).ControlsToUpdate.Add(RadRotator1);
		}

		private void CallbackRadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadGallery(ddlGalery.SelectedIndex);						
			RadRotator1.TransitionEffect = (RadRotator.RotatorTransitionEffect) Enum.Parse(typeof(RadRotator.RotatorTransitionEffect), CallbackRadioButtonList1.SelectedItem.Text);
			((Telerik.WebControls.CallbackRadioButtonList)sender).ControlsToUpdate.Add(RadRotator1);
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			int frameTimeout = int.Parse(tbFrameTimeout.Text);
			if ((frameTimeout < 1000) || (frameTimeout > 3000))
			{
				btnApply.Alert("Invalid number. Please, select a frame timeout between [1000, 3000].");				
				tbFrameTimeout.Text = RadRotator1.FrameTimeout.ToString();								
			}
			else
			{
				RadRotator1.FrameTimeout = frameTimeout;
			}
			LoadGallery(ddlGalery.SelectedIndex);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(RadRotator1);
		}
	}
}
