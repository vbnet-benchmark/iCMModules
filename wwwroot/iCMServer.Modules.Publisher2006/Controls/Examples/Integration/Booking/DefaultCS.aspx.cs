using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.WebControls;

namespace Telerik.ComboboxExamplesCSharp.Integration.Booking
{
	/// <summary>
	/// Summary description for DefaultCS.
	/// </summary>
	public class DefaultCS : Telerik.QuickStart.XhtmlPage
	{
		private string OldIndex
		{
			get
			{
				return (string)ViewState["OldIndex"];
			}
			set
			{
				ViewState["OldIndex"] = value;
			}
		}

		protected Telerik.WebControls.CallbackRadioButtonList callbackRadioButtonList;
		protected System.Web.UI.WebControls.Panel panelOptions;
		protected Telerik.WebControls.CallbackButton callbackSubmit;
		protected System.Web.UI.WebControls.Label labelSelection;
		protected System.Web.UI.WebControls.Panel panelLoadingImage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				OldIndex = "Flight";
			}
			LoadCustomControl(OldIndex);
		}

		private void LoadCustomControl(string controlIndex)
		{
			panelOptions.Controls.Clear();
			UserControl customControl = (UserControl)this.LoadControl(controlIndex+"Search.ascx");
			customControl.ID= controlIndex+"search";
			panelOptions.Controls.Add(customControl);
		}

		protected void callbackSubmit_Clicked(object sender, System.EventArgs e)
		{
			string city1=String.Empty, city2=String.Empty, date1=String.Empty, date2 = String.Empty, format = String.Empty;

			if (panelOptions.Controls.Count==0)
				return;

			Telerik.WebControls.RadDatePicker dateUp = (Telerik.WebControls.RadDatePicker)panelOptions.Controls[0].FindControl("calendarCheckIn");
			if (dateUp != null)
			{
				date1 = dateUp.SelectedDate.ToString("d");
			}
			Telerik.WebControls.RadDatePicker dateOff = (Telerik.WebControls.RadDatePicker)panelOptions.Controls[0].FindControl("calendarCheckOut");
			if (dateOff != null)
			{
				date2 = dateOff.SelectedDate.ToString("d");
			}

			switch (callbackRadioButtonList.SelectedItem.Value)
			{
				case "Hotel":
					RadComboBox comboCities = (RadComboBox)panelOptions.Controls[0].FindControl("comboCities");
					if (comboCities != null)
					{
						city1 = comboCities.Text;
						format = "You have searched for a Hotel in {0} from {2} to {3}";
					}
					break;
				case "Car":
					RadComboBox comboCarCities = (RadComboBox)panelOptions.Controls[0].FindControl("comboCarCities");
					if (comboCarCities != null)
					{
						city1 = comboCarCities.Text;
						format = "You have searched for a Car in {0} from {2} to {3}";
					}
					break;
				case "Flight":
					RadComboBox comboCityFrom = (RadComboBox)panelOptions.Controls[0].FindControl("comboCityFrom");
					RadComboBox comboCityTo = (RadComboBox)panelOptions.Controls[0].FindControl("comboCityTo");
					if (comboCityFrom != null)
					{
						city1 = comboCityFrom.Text;
						city2 = comboCityTo.Text;
						format = "You have searched for a Flight from  {0} to {1}, departing on {2} and returning on {3}";
					}
					break;
				default:
					format = "Please choose a search criteria";
					break;
			}
			if (city1 == String.Empty)
			{
				format = "Please choose a search method first and wait for the search criteria to load.";
			}
			labelSelection.Text = String.Format(format, city1, city2, date1, date2);
			callbackSubmit.ControlsToUpdate.Add(labelSelection);
		}

		protected void callbackRadioButtonList_IndexChanged(object sender, System.EventArgs e)
		{
			labelSelection.Text = String.Empty;
			OldIndex = callbackRadioButtonList.SelectedItem.Value;
			LoadCustomControl(OldIndex);
			callbackRadioButtonList.ControlsToUpdate.Add(panelOptions);
			callbackRadioButtonList.ControlsToUpdate.Add(labelSelection);
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
