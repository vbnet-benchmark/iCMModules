
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


Namespace Telerik.CallbackExamplesVB.Integration.CallbackAndUpload
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      Protected upload1 As Telerik.WebControls.RadUpload
      Protected progressArea1 As Telerik.WebControls.RadUploadProgressArea
      Protected rblLanguages As Telerik.WebControls.CallbackRadioButtonList
      Protected lblNoResults As System.Web.UI.WebControls.Label
      Protected rptReqults As System.Web.UI.WebControls.Repeater
      Protected btnSubmit As System.Web.UI.WebControls.Button
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
      
      ' Put user code to initialize the page here
      Protected Sub rblLanguages_SelectedIndexChanged(sender As Object, e As EventArgs)
         upload1.Language = rblLanguages.SelectedItem.Value
         progressArea1.Language = rblLanguages.SelectedItem.Value
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(upload1)
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(progressArea1)
      End Sub 'rblLanguages_SelectedIndexChanged
      
      
      Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
         BindResults()
      End Sub 'btnSubmit_Click
      
      
      Private Sub BindResults()
         Dim resultsExist As Boolean = upload1.UploadedFiles.Count > 0 And Not progressArea1.RequestCancelled
         lblNoResults.Visible = Not resultsExist
         rptReqults.Visible = resultsExist
         If resultsExist Then
            rptReqults.DataSource = upload1.UploadedFiles
            rptReqults.DataBind()
         End If
      End Sub 'BindResults
      Protected Overrides Sub OnInit(e As EventArgs)
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
   End Class 'DefaultVB 
End Namespace 'Telerik.CallbackExamplesVB.Integration.CallbackAndUpload
