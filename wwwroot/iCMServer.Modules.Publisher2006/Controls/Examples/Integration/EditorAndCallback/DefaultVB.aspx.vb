
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Namespace Telerik.IntegrationExamplesVBNET.EditorAndCallback
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      Protected Editor1 As Telerik.WebControls.RadEditor
      Protected statusLabel As System.Web.UI.WebControls.Label
      Protected Timer1 As Telerik.WebControls.CallbackTimer
      Protected labelPreview As System.Web.UI.WebControls.Label
      Protected labelLastChanged As System.Web.UI.WebControls.Label
      Protected showDraft As Telerik.WebControls.CallbackButton
      
      
      Private Property savedText() As String
         Get
            If Not (ViewState("editorDraftText") Is Nothing) Then
               Return CStr(ViewState("editorDraftText"))
            Else
               Return String.Empty
            End If
         End Get
         Set
            ViewState("editorDraftText") = value
         End Set
      End Property
      
      Private Property lastSavedTime() As DateTime
         Get
            If Not (ViewState("lastSavedTime") Is Nothing) Then
               Return CType(ViewState("lastSavedTime"), DateTime)
            Else
               Return DateTime.Now
            End If
         End Get
         Set
            ViewState("lastSavedTime") = value
         End Set
      End Property
       
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         ' Put user code to initialize the page here
         If Not IsPostBack Then
            Editor1.Html = "Enter your text here... The editor content will be auto saved each minute. Press the 'Show saved text' button to see the last saved draft. "
         End If
      End Sub 'Page_Load
      
      
      Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
         Me.savedText = Editor1.Html
         Me.lastSavedTime = DateTime.Now
         CType(sender, Telerik.WebControls.CallbackTimer).StatusLabel.ReadyMessage = "Draft saved at " + DateTime.Now.ToString("HH:mm")
      End Sub 'Timer1_Tick
      
      
      Protected Sub showDraft_Click(sender As Object, e As EventArgs)
         labelPreview.Text = Me.savedText
         labelLastChanged.Text = "Showing draft from " + Me.lastSavedTime.ToString("HH:mm:ss")
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelPreview)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(labelLastChanged)
      End Sub 'showDraft_Click
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
End Namespace 'Telerik.IntegrationExamplesVBNET.EditorAndCallback