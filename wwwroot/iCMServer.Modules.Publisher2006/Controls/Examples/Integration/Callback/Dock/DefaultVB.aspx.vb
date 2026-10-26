
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
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackIntegrationExamplesVBNET.Dock
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected WithEvents btnLoadState As Telerik.WebControls.CallbackButton
      Protected WithEvents btnSaveState As Telerik.WebControls.CallbackButton
      Protected RadDockingManager1 As Telerik.WebControls.RadDockingManager
      Protected dockObject2 As Telerik.WebControls.RadDockableObject
      Protected dockObject3 As Telerik.WebControls.RadDockableObject
      Protected dockObject1 As Telerik.WebControls.RadDockableObject
      Protected dockZone1 As Telerik.WebControls.RadDockingZone
      Protected dockZone2 As Telerik.WebControls.RadDockingZone
      Protected dockZone3 As Telerik.WebControls.RadDockingZone
      Protected tbConfigName As System.Web.UI.WebControls.TextBox
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected lbSavedConfigs As System.Web.UI.WebControls.ListBox
      Protected Panel1 As System.Web.UI.WebControls.Panel
      Protected Panel2 As System.Web.UI.WebControls.Panel
      Protected Panel3 As System.Web.UI.WebControls.Panel
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
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
      Private Sub btnLoadState_Click(sender As Object, e As System.EventArgs) Handles btnLoadState.Click
         If lbSavedConfigs.SelectedIndex > - 1 Then
            dockZone1.DockableObjects.Clear()
            dockZone2.DockableObjects.Clear()
            dockZone3.DockableObjects.Clear()
            If Not (Session(("DockState_" + lbSavedConfigs.SelectedItem.Text)) Is Nothing) Then
               RadDockingManager1.LoadState(CStr(Session(("DockState_" + lbSavedConfigs.SelectedItem.Text))))
               Label2.Text = "Dock configration " + lbSavedConfigs.SelectedItem.Text + " is loaded."
               btnLoadState.ControlsToUpdate.Add(Panel1)
               btnLoadState.ControlsToUpdate.Add(Panel2)
               btnLoadState.ControlsToUpdate.Add(Panel3)
               btnLoadState.ControlsToUpdate.Add(Label2)
            Else
               btnLoadState.Alert("No saved dock state!")
            End If
         Else
            btnLoadState.Alert("Please, select a dock configuratation from the dropdown list.")
         End If
      End Sub 'btnLoadState_Click
      
      
      Private Sub btnSaveState_Click(sender As Object, e As System.EventArgs) Handles btnSaveState.Click
         If tbConfigName.Text.Length = 0 Then
            tbConfigName.BackColor = Color.Yellow
            btnSaveState.ControlsToUpdate.Add(tbConfigName)
            btnSaveState.Alert("Please, enter a name for configuration.")
            Return
         End If
         Session(("DockState_" + tbConfigName.Text)) = RadDockingManager1.SaveState()
         Label2.Text = "State " + tbConfigName.Text + " is saved."
         lbSavedConfigs.Items.Add(tbConfigName.Text)
         tbConfigName.Text = String.Empty
         
         btnSaveState.ControlsToUpdate.Add(lbSavedConfigs)
         btnSaveState.ControlsToUpdate.Add(tbConfigName)
         btnSaveState.ControlsToUpdate.Add(Label2)
      End Sub 'btnSaveState_Click
      
      
      Protected Sub Button_Click(sender As Object, e As System.EventArgs)
         Dim button As CallbackButton = CType(sender, CallbackButton)
         Dim control As System.Web.UI.WebControls.Label = Nothing
         If button.ID.Equals("CallbackButton1") Then
            control = CType(dockObject2.FindControl("Label21"), System.Web.UI.WebControls.Label)
            control.Text = DateTime.Now.ToString()
         ElseIf button.ID.Equals("CallbackButton2") Then
            control = CType(dockObject3.FindControl("Label31"), System.Web.UI.WebControls.Label)
            control.Text = DateTime.Now.ToString()
         ElseIf button.ID.Equals("CallbackButton3") Then
            control = CType(dockObject1.FindControl("Label11"), System.Web.UI.WebControls.Label)
            control.Text = DateTime.Now.ToString()
         End If
         If Not (control Is Nothing) Then
            button.ControlsToUpdate.Add(control)
         End If
      End Sub 'Button_Click
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegrationExamplesVBNET.Dock