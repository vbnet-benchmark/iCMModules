
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Telerik.WebControls


Namespace Telerik.ComboboxExamplesVBNET.Integration.Booking
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      
      Private Property OldIndex() As String
         Get
            Return CStr(ViewState("OldIndex"))
         End Get
         Set
            ViewState("OldIndex") = value
         End Set
      End Property
      
      Protected callbackRadioButtonList As Telerik.WebControls.CallbackRadioButtonList
      Protected panelOptions As System.Web.UI.WebControls.Panel
      Protected callbackSubmit As Telerik.WebControls.CallbackButton
      Protected labelSelection As System.Web.UI.WebControls.Label
      Protected panelLoadingImage As System.Web.UI.WebControls.Panel
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            OldIndex = "Flight"
         End If
         LoadCustomControl(OldIndex)
      End Sub 'Page_Load
      
      
      Private Sub LoadCustomControl(controlIndex As String)
         panelOptions.Controls.Clear()
         Dim customControl As UserControl = CType(Me.LoadControl((controlIndex + "Search.ascx")), UserControl)
         customControl.ID = controlIndex + "search"
         panelOptions.Controls.Add(customControl)
      End Sub 'LoadCustomControl
      
      
      Protected Sub callbackSubmit_Clicked(sender As Object, e As System.EventArgs)
         Dim city1 As String = [String].Empty
         Dim city2 As String = [String].Empty
         Dim date1 As String = [String].Empty
         Dim date2 As String = [String].Empty
         Dim format As String = [String].Empty
         
         If panelOptions.Controls.Count = 0 Then
            Return
         End If 
         Dim dateUp As Telerik.WebControls.RadDatePicker = CType(panelOptions.Controls(0).FindControl("calendarCheckIn"), Telerik.WebControls.RadDatePicker)
         If Not (dateUp Is Nothing) Then
            date1 = dateUp.SelectedDate.ToString("d")
         End If
         Dim dateOff As Telerik.WebControls.RadDatePicker = CType(panelOptions.Controls(0).FindControl("calendarCheckOut"), Telerik.WebControls.RadDatePicker)
         If Not (dateOff Is Nothing) Then
            date2 = dateOff.SelectedDate.ToString("d")
         End If
         
         Select Case callbackRadioButtonList.SelectedItem.Value
            Case "Hotel"
               Dim comboCities As RadComboBox = CType(panelOptions.Controls(0).FindControl("comboCities"), RadComboBox)
               If Not (comboCities Is Nothing) Then
                  city1 = comboCities.Text
                  format = "You have searched for a Hotel in {0} from {2} to {3}"
               End If
            Case "Car"
               Dim comboCarCities As RadComboBox = CType(panelOptions.Controls(0).FindControl("comboCarCities"), RadComboBox)
               If Not (comboCarCities Is Nothing) Then
                  city1 = comboCarCities.Text
                  format = "You have searched for a Car in {0} from {2} to {3}"
               End If
            Case "Flight"
               Dim comboCityFrom As RadComboBox = CType(panelOptions.Controls(0).FindControl("comboCityFrom"), RadComboBox)
               Dim comboCityTo As RadComboBox = CType(panelOptions.Controls(0).FindControl("comboCityTo"), RadComboBox)
               If Not (comboCityFrom Is Nothing) Then
                  city1 = comboCityFrom.Text
                  city2 = comboCityTo.Text
                  format = "You have searched for a Flight from  {0} to {1}, departing on {2} and returning on {3}"
               End If
            Case Else
               format = "Please choose a search criteria"
         End Select
         If city1 = [String].Empty Then
            format = "Please choose a search method first and wait for the search criteria to load."
         End If
         labelSelection.Text = [String].Format(format, city1, city2, date1, date2)
         callbackSubmit.ControlsToUpdate.Add(labelSelection)
      End Sub 'callbackSubmit_Clicked
      
      
      Protected Sub callbackRadioButtonList_IndexChanged(sender As Object, e As System.EventArgs)
         labelSelection.Text = [String].Empty
         OldIndex = callbackRadioButtonList.SelectedItem.Value
         LoadCustomControl(OldIndex)
         callbackRadioButtonList.ControlsToUpdate.Add(panelOptions)
         callbackRadioButtonList.ControlsToUpdate.Add(labelSelection)
      End Sub 'callbackRadioButtonList_IndexChanged
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
   End Class 'DefaultVB 
End Namespace 'Telerik.ComboboxExamplesVBNET.Integration.Booking