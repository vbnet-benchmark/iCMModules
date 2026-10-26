
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackIntegarationExamplesVBNET.WizardCV
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      Private countryList() As String = {"United States", "Afghanistan", "Akrotiri", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Arctic Ocean", "Argentina", "Armenia", "Aruba", "Ashmore and Cartier Islands", "Atlantic Ocean", "Australia", "Austria", "Azerbaijan", "Bahamas, The", "Bahrain", "Baker Island", "Bangladesh", "Barbados", "Bassas da India", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Clipperton Island", "Cocos Islands", "Colombia", "Comoros", "Congo", "Cook Islands", "Coral Sea Islands", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Dhekelia", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Europa Island", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "Gabon", "Gambia, The", "Gaza Strip", "Georgia", "Germany", "Ghana", "Gibraltar", "Glorioso Islands", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Island", "Vatican City", "Honduras", "Hong Kong", "Howland Island", "Hungary", "Iceland", "India", "Indian Ocean", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Jan Mayen", "Japan", "Jarvis Island", "Jersey", "Johnston Atoll", "Jordan", "Juan de Nova Island", "Kazakhstan", "Kenya", "Kingman Reef", "Kiribati", "Korea, North", "Korea, South", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Man, Isle of", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia, Federated States of", "Midway Islands", "Moldova", "Monaco", "Mongolia", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nauru", "Navassa Island", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pacific Ocean", "Pakistan", "Palau", "Palmyra Atoll", "Panama", "Papua New Guinea", "Paracel Islands", "Paraguay", "Peru", "Philippines", "Pitcairn Islands", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia", "Rwanda", "Saint Helena", "Saint Kitts", "Saint Lucia", "Saint Pierre", "Saint Vincent", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia and Montenegro", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia", "Southern Ocean", "Spain", "Spratly Islands", "Sri Lanka", "Sudan", "Suriname", "Svalbard", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tromelin Island", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Virgin Islands", "Wake Island", "Wallis and Futuna", "West Bank", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"}
      
      Protected tabWizard As Telerik.WebControls.RadTabStrip
      Protected multipageWizard As Telerik.WebControls.RadMultiPage
      Protected labelMotivation As System.Web.UI.WebControls.Label
      Protected labelEducation As System.Web.UI.WebControls.Label
      Protected labelPersonal As System.Web.UI.WebControls.Label
      Protected labelEmployment As System.Web.UI.WebControls.Label
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         tabWizard.SkinsPath = Me.TemplateSourceDirectory + "/Skins"
         tabWizard.Skin = "HorizontalTabs"
         If CType(tabWizard.FindControl("tabPersonal"), Tab).Enabled Then
            multipageWizard.PageViews(0).Controls.Add(LoadControl("Personal.ascx"))
            Dim comboCountry As System.Web.UI.WebControls.DropDownList = CType(multipageWizard.Controls(0).Controls(0).FindControl("comboCountry"), System.Web.UI.WebControls.DropDownList)
            If comboCountry.Items.Count = 0 Then
               comboCountry.DataSource = countryList
               comboCountry.DataBind()
            End If
            Dim comboNationality As System.Web.UI.WebControls.DropDownList = CType(multipageWizard.Controls(0).Controls(0).FindControl("comboNationality"), System.Web.UI.WebControls.DropDownList)
            If comboNationality.Items.Count = 0 Then
               comboNationality.DataSource = countryList
               comboNationality.DataBind()
            End If
         End If
         If CType(tabWizard.FindControl("tabEducation"), Tab).Enabled Then
            multipageWizard.PageViews(1).Controls.Add(LoadControl("Education.ascx"))
         End If
         If CType(tabWizard.FindControl("tabProfessional"), Tab).Enabled Then
            multipageWizard.PageViews(2).Controls.Add(LoadControl("Employment.ascx"))
         End If
      End Sub 'Page_Load
      
      
      Private Sub UpdatePreview()
         Dim sbText As New System.Text.StringBuilder()
         If CType(tabWizard.FindControl("tabPersonal"), Tab).Enabled Then
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Title:", CType(multipageWizard.Controls(0).Controls(0).FindControl("listTitle"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "First Name:", CType(multipageWizard.Controls(0).Controls(0).FindControl("textFirstName"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Second Name:", CType(multipageWizard.Controls(0).Controls(0).FindControl("textSecondName"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Street Address:", CType(multipageWizard.Controls(0).Controls(0).FindControl("textStreetAddress"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Country:", CType(multipageWizard.Controls(0).Controls(0).FindControl("comboCountry"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "E-mail:", CType(multipageWizard.Controls(0).Controls(0).FindControl("textEmail"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Birthday:", CType(multipageWizard.Controls(0).Controls(0).FindControl("listMonth"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text + "/" + CType(multipageWizard.Controls(0).Controls(0).FindControl("listDay"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text + "/" + CType(multipageWizard.Controls(0).Controls(0).FindControl("listYear"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Nationality:", CType(multipageWizard.Controls(0).Controls(0).FindControl("comboNationality"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Martial Status:", CType(multipageWizard.Controls(0).Controls(0).FindControl("radioMartial"), System.Web.UI.WebControls.RadioButtonList).SelectedItem.Text))
         End If
         labelPersonal.Text = sbText.ToString()
         sbText.Length = 0
         If CType(tabWizard.FindControl("tabEducation"), Tab).Enabled Then
            Dim majorsList As String = String.Empty
            Dim _listItem As System.Web.UI.WebControls.ListItem
            For Each _listItem In  CType(multipageWizard.Controls(1).Controls(0).FindControl("listMajor"), System.Web.UI.WebControls.ListBox).Items
               If _listItem.Selected Then
                  majorsList += " " + _listItem.Text
               End If
            Next _listItem
            Dim minorsList As String = String.Empty
            Dim _listItem2 As System.Web.UI.WebControls.ListItem
            For Each _listItem2 In  CType(multipageWizard.Controls(1).Controls(0).FindControl("listMinor"), System.Web.UI.WebControls.ListBox).Items
               If _listItem2.Selected Then
                  minorsList += " " + _listItem2.Text
               End If
            Next _listItem2
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Education Type:", CType(multipageWizard.Controls(1).Controls(0).FindControl("listEducationType"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "School/University Name:", CType(multipageWizard.Controls(1).Controls(0).FindControl("textSchoolName"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Address:", CType(multipageWizard.Controls(1).Controls(0).FindControl("textSchoolAddress"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Graduation Year:", CType(multipageWizard.Controls(1).Controls(0).FindControl("listGraduationYear"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Major Fields Of study:", majorsList))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Minor Fields Of study:", minorsList))
         End If
         labelEducation.Text = sbText.ToString()
         sbText.Length = 0
         
         If CType(tabWizard.FindControl("tabProfessional"), Tab).Enabled Then
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Company name:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textCompanyName"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Address:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textCompanyAddress"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Contact person:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textContactPerson"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Position held:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textPosition"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Start date:", CType(multipageWizard.Controls(2).Controls(0).FindControl("listStartDateMonth"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text + "/" + CType(multipageWizard.Controls(2).Controls(0).FindControl("listStartDateYear"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "End date:", CType(multipageWizard.Controls(2).Controls(0).FindControl("listEndDateMonth"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text + "/" + CType(multipageWizard.Controls(2).Controls(0).FindControl("listEndDateYear"), System.Web.UI.WebControls.DropDownList).SelectedItem.Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Responsibilities:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textResponsibilities"), System.Web.UI.WebControls.TextBox).Text))
            sbText.Append([String].Format("<span class='label'>{0}</span> {1}<br />", "Projects Worked on:", CType(multipageWizard.Controls(2).Controls(0).FindControl("textProjects"), System.Web.UI.WebControls.TextBox).Text))
         End If
         labelEmployment.Text = sbText.ToString()
         
         
         labelMotivation.Text = CType(multipageWizard.FindControl("editorMotivation"), Telerik.WebControls.RadEditor).Xhtml
      End Sub 'UpdatePreview
       
      Protected Sub submitCV(sender As Object, e As System.EventArgs)
         UpdatePreview()
         Dim selectedTab As Telerik.WebControls.Tab = tabWizard.SelectedTab
         Dim tempTab As Telerik.WebControls.Tab
         If Not (selectedTab Is Nothing) Then
            Select Case selectedTab.ID
               Case "tabPersonal"
                  tempTab = CType(tabWizard.FindControl("tabEducation"), Tab)
                  If Not tempTab.Enabled Then
                     tempTab.Enabled = True
                     multipageWizard.PageViews(1).Controls.Add(LoadControl("Education.ascx"))
                  End If
                  CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelPersonal)
                  tabWizard.SelectedIndex = 1
                  multipageWizard.SelectedIndex = 1
               Case "tabEducation"
                  tempTab = CType(tabWizard.FindControl("tabProfessional"), Tab)
                  If Not tempTab.Enabled Then
                     tempTab.Enabled = True
                     multipageWizard.PageViews(2).Controls.Add(LoadControl("Employment.ascx"))
                  End If
                  CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelEducation)
                  tabWizard.SelectedIndex = 2
                  multipageWizard.SelectedIndex = 2
               Case "tabProfessional"
                  tempTab = CType(tabWizard.FindControl("tabMotivation"), Tab)
                  If Not tempTab.Enabled Then
                     tempTab.Enabled = True
                  End If
                  CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelEmployment)
                  tabWizard.SelectedIndex = 3
                  multipageWizard.SelectedIndex = 3
               Case "tabMotivation"
                  Dim tTab As Tab
                  For Each tTab In  tabWizard.Tabs
                     tTab.Enabled = False
                  Next tTab
                  CType(sender, Telerik.WebControls.CallbackButton).Style.Add("display", "none")
                  CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(CType(sender, Telerik.WebControls.CallbackButton))
                  CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelMotivation)
                  tabWizard.SelectedIndex = - 1
                  multipageWizard.SelectedIndex = 4
            End Select
         End If
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(tabWizard)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(multipageWizard)
      End Sub 'submitCV
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/		Required method for Designer support - do not modify
      '/		the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
   End Class 'DefaultVB 
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.WizardCV