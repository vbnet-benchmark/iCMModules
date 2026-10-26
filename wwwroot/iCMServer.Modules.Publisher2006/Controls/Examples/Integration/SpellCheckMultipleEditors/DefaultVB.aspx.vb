
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


Namespace Telerik.ControlExamplesVBNET.Integration.SpellCheckMultipleEditors
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
      
      ' Put user code to initialize the page here
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
End Namespace 'Telerik.ControlExamplesVBNET.Integration.SpellCheckMultipleEditors