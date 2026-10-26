
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


Namespace Telerik.IntegrationExamplesVBNET.Devenv
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits System.Web.UI.Page
      Protected toolbarTop As Telerik.WebControls.RadToolbar
      Protected RadDockingManager1 As Telerik.WebControls.RadDockingManager
      Protected menuTop As Telerik.WebControls.RadMenu
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         ' Put user code to initialize the page here
         toolbarTop.SkinsDir = Me.TemplateSourceDirectory + "/Toolbar/"
         toolbarTop.Skin = "vsnet"
         RadDockingManager1.SkinsPath = Me.TemplateSourceDirectory + "/Dock/"
         RadDockingManager1.Skin = "vsnetoutput"
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
   End Class 'DefaultVB 
End Namespace 'Telerik.IntegrationExamplesVBNET.Devenv