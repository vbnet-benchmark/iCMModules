using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Telerik.QuickStart;
using Telerik.WebControls;

namespace Telerik.CallbackIntegarationExamplesCSharp.WizardCV
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: Telerik.QuickStart.XhtmlPage
	{
		string [] countryList = new string [] {"United States","Afghanistan","Akrotiri","Albania","Algeria","American Samoa","Andorra","Angola","Anguilla",
												  "Antarctica","Antigua and Barbuda","Arctic Ocean","Argentina","Armenia","Aruba","Ashmore and Cartier Islands","Atlantic Ocean",
												  "Australia","Austria","Azerbaijan","Bahamas, The","Bahrain","Baker Island","Bangladesh","Barbados",
												  "Bassas da India","Belarus","Belgium","Belize","Benin","Bermuda","Bhutan","Bolivia",
												  "Bosnia and Herzegovina","Botswana","Bouvet Island","Brazil","Brunei","Bulgaria","Burkina Faso","Burma",
												  "Burundi","Cambodia","Cameroon","Canada","Cape Verde","Cayman Islands","Central African Republic","Chad",
												  "Chile","China","Christmas Island","Clipperton Island","Cocos Islands","Colombia","Comoros","Congo",
												  "Cook Islands","Coral Sea Islands","Costa Rica","Cote d'Ivoire","Croatia","Cuba","Cyprus","Czech Republic",
												  "Denmark","Dhekelia","Djibouti","Dominica","Dominican Republic","East Timor","Ecuador","Egypt",
												  "El Salvador","Equatorial Guinea","Eritrea","Estonia","Ethiopia","Europa Island","Falkland Islands","Faroe Islands",
												  "Fiji","Finland","France","French Guiana","French Polynesia","Gabon","Gambia, The","Gaza Strip",
												  "Georgia","Germany","Ghana","Gibraltar","Glorioso Islands","Greece","Greenland","Grenada",
												  "Guadeloupe","Guam","Guatemala","Guernsey","Guinea","Guinea-Bissau","Guyana","Haiti",
												  "Heard Island","Vatican City","Honduras","Hong Kong","Howland Island","Hungary","Iceland","India",
												  "Indian Ocean","Indonesia","Iran","Iraq","Ireland","Israel","Italy","Jamaica",
												  "Jan Mayen","Japan","Jarvis Island","Jersey","Johnston Atoll","Jordan","Juan de Nova Island","Kazakhstan",
												  "Kenya","Kingman Reef","Kiribati","Korea, North","Korea, South","Kuwait","Kyrgyzstan","Laos",
												  "Latvia","Lebanon","Lesotho","Liberia","Libya","Liechtenstein","Lithuania","Luxembourg",
												  "Macau","Macedonia","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta",
												  "Man, Isle of","Marshall Islands","Martinique","Mauritania","Mauritius","Mayotte","Mexico","Micronesia, Federated States of",
												  "Midway Islands","Moldova","Monaco","Mongolia","Montserrat","Morocco","Mozambique","Namibia",
												  "Nauru","Navassa Island","Nepal","Netherlands","Netherlands Antilles","New Caledonia","New Zealand","Nicaragua",
												  "Niger","Nigeria","Niue","Norfolk Island","Northern Mariana Islands","Norway","Oman","Pacific Ocean",
												  "Pakistan","Palau","Palmyra Atoll","Panama","Papua New Guinea","Paracel Islands",
												  "Paraguay","Peru","Philippines","Pitcairn Islands","Poland","Portugal","Puerto Rico","Qatar",
												  "Reunion","Romania","Russia","Rwanda","Saint Helena","Saint Kitts","Saint Lucia","Saint Pierre",
												  "Saint Vincent","Samoa","San Marino","Sao Tome and Principe","Saudi Arabia","Senegal","Serbia and Montenegro","Seychelles",
												  "Sierra Leone","Singapore","Slovakia","Slovenia","Solomon Islands","Somalia","South Africa","South Georgia",
												  "Southern Ocean","Spain","Spratly Islands","Sri Lanka","Sudan","Suriname","Svalbard","Swaziland",
												  "Sweden","Switzerland","Syria","Taiwan","Tajikistan","Tanzania","Thailand","Togo",
												  "Tokelau","Tonga","Trinidad and Tobago","Tromelin Island","Tunisia","Turkey","Turkmenistan","Turks and Caicos Islands",
												  "Tuvalu","Uganda","Ukraine","United Arab Emirates","United Kingdom","Uruguay","Uzbekistan",
												  "Vanuatu","Venezuela","Vietnam","Virgin Islands","Wake Island","Wallis and Futuna","West Bank","Western Sahara",
												  "Yemen","Zambia","Zimbabwe"};

		protected Telerik.WebControls.RadTabStrip tabWizard;
		protected Telerik.WebControls.RadMultiPage multipageWizard;
		protected System.Web.UI.WebControls.Label labelMotivation;
		protected System.Web.UI.WebControls.Label labelEducation;
		protected System.Web.UI.WebControls.Label labelPersonal;
		protected System.Web.UI.WebControls.Label labelEmployment;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			tabWizard.SkinsPath= this.TemplateSourceDirectory + "/Skins";
			tabWizard.Skin = "HorizontalTabs";
			if (((Tab)tabWizard.FindControl("tabPersonal")).Enabled)
			{
				multipageWizard.PageViews[0].Controls.Add(LoadControl("Personal.ascx"));
				System.Web.UI.WebControls.DropDownList comboCountry = ((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("comboCountry"));
				if (comboCountry.Items.Count==0)
				{
					comboCountry.DataSource = countryList;
					comboCountry.DataBind();
				}
				System.Web.UI.WebControls.DropDownList comboNationality = ((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("comboNationality"));
				if (comboNationality.Items.Count==0)
				{
					comboNationality.DataSource = countryList;
					comboNationality.DataBind();
				}
			}
			if (((Tab)tabWizard.FindControl("tabEducation")).Enabled)
			{
				multipageWizard.PageViews[1].Controls.Add(LoadControl("Education.ascx"));
			}
			if (((Tab)tabWizard.FindControl("tabProfessional")).Enabled)
			{
				multipageWizard.PageViews[2].Controls.Add(LoadControl("Employment.ascx"));
			}
		}

		private void UpdatePreview()
		{
			System.Text.StringBuilder sbText = new System.Text.StringBuilder();
			if (((Tab)tabWizard.FindControl("tabPersonal")).Enabled)
			{
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Title:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("listTitle")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","First Name:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[0].Controls[0].FindControl("textFirstName")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Second Name:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[0].Controls[0].FindControl("textSecondName")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Street Address:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[0].Controls[0].FindControl("textStreetAddress")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Country:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("comboCountry")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","E-mail:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[0].Controls[0].FindControl("textEmail")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Birthday:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("listMonth")).SelectedItem.Text+"/"+
					((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("listDay")).SelectedItem.Text+"/"+
					((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("listYear")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Nationality:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[0].Controls[0].FindControl("comboNationality")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Martial Status:",((System.Web.UI.WebControls.RadioButtonList)multipageWizard.Controls[0].Controls[0].FindControl("radioMartial")).SelectedItem.Text));
			}
			labelPersonal.Text = sbText.ToString();
			sbText.Length = 0;
			if (((Tab)tabWizard.FindControl("tabEducation")).Enabled)
			{
				string majorsList = string.Empty;
				foreach (System.Web.UI.WebControls.ListItem _listItem in ((System.Web.UI.WebControls.ListBox)multipageWizard.Controls[1].Controls[0].FindControl("listMajor")).Items)
				{
					if (_listItem.Selected)
					{
						majorsList +=" "+_listItem.Text;
					}
				}
				string minorsList = string.Empty;
				foreach (System.Web.UI.WebControls.ListItem _listItem2 in ((System.Web.UI.WebControls.ListBox)multipageWizard.Controls[1].Controls[0].FindControl("listMinor")).Items)
				{
					if (_listItem2.Selected)
					{
						minorsList +=" "+_listItem2.Text;
					}
				}
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Education Type:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[1].Controls[0].FindControl("listEducationType")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","School/University Name:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[1].Controls[0].FindControl("textSchoolName")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Address:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[1].Controls[0].FindControl("textSchoolAddress")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Graduation Year:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[1].Controls[0].FindControl("listGraduationYear")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Major Fields Of study:",majorsList));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Minor Fields Of study:",minorsList));
			}
			labelEducation.Text = sbText.ToString();
			sbText.Length = 0;

			if (((Tab)tabWizard.FindControl("tabProfessional")).Enabled)
			{
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Company name:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textCompanyName")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Address:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textCompanyAddress")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Contact person:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textContactPerson")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Position held:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textPosition")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Start date:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[2].Controls[0].FindControl("listStartDateMonth")).SelectedItem.Text+"/"+
					((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[2].Controls[0].FindControl("listStartDateYear")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","End date:",((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[2].Controls[0].FindControl("listEndDateMonth")).SelectedItem.Text+"/"+
					((System.Web.UI.WebControls.DropDownList)multipageWizard.Controls[2].Controls[0].FindControl("listEndDateYear")).SelectedItem.Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Responsibilities:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textResponsibilities")).Text));
				sbText.Append(String.Format("<span class='label'>{0}</span> {1}<br />","Projects Worked on:",((System.Web.UI.WebControls.TextBox)multipageWizard.Controls[2].Controls[0].FindControl("textProjects")).Text));
			}
			labelEmployment.Text = sbText.ToString();


			labelMotivation.Text=((Telerik.WebControls.RadEditor)multipageWizard.FindControl("editorMotivation")).Xhtml;
			
		}
		protected void submitCV(object sender, System.EventArgs e)
		{
			UpdatePreview();
			Telerik.WebControls.Tab selectedTab = tabWizard.SelectedTab;
			Telerik.WebControls.Tab tempTab;
			if (selectedTab != null)
			{
				switch (selectedTab.ID)
				{
					case "tabPersonal":
						tempTab = (Tab)tabWizard.FindControl("tabEducation");
						if (!tempTab.Enabled)
						{
							tempTab.Enabled = true;
							multipageWizard.PageViews[1].Controls.Add(LoadControl("Education.ascx"));
						}
						((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelPersonal);
						tabWizard.SelectedIndex = 1;
						multipageWizard.SelectedIndex = 1;
						break;
					case "tabEducation":
						tempTab = (Tab)tabWizard.FindControl("tabProfessional");
						if (!tempTab.Enabled)
						{
							tempTab.Enabled = true;
							multipageWizard.PageViews[2].Controls.Add(LoadControl("Employment.ascx"));
						}
						((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelEducation);
						tabWizard.SelectedIndex = 2;
						multipageWizard.SelectedIndex = 2;
						break;
					case "tabProfessional":
						tempTab = (Tab)tabWizard.FindControl("tabMotivation");
						if (!tempTab.Enabled)
						{
							tempTab.Enabled = true;
						}
						((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelEmployment);
						tabWizard.SelectedIndex = 3;
						multipageWizard.SelectedIndex = 3;
						break;
					case "tabMotivation":
						foreach (Tab tTab in tabWizard.Tabs)
						{
							tTab.Enabled = false;
						}
						((Telerik.WebControls.CallbackButton)sender).Style.Add("display","none");
						((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add((Telerik.WebControls.CallbackButton)sender);
						((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(labelMotivation);
						tabWizard.SelectedIndex = -1;
						multipageWizard.SelectedIndex = 4;
						break;
				}
			}
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(tabWizard);
			((Telerik.WebControls.CallbackButton)sender).ControlsToUpdate.Add(multipageWizard);
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
