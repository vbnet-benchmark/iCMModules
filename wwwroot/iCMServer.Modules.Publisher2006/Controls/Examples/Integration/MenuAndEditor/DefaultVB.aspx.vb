
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


Namespace Telerik.MenuExamplesVBNET.Integration.MenuAndEditor
   
   '/ <summary>
   '/ Summary description for DefaultCS.
   '/ </summary>
   Public Class DefaultVB
      Inherits Telerik.QuickStart.XhtmlPage
      Protected RadMenu1 As Telerik.WebControls.RadMenu
      Protected editor1 As Telerik.WebControls.RadEditor
      
      
      Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      End Sub 'Page_Load
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/		Required method for Designer support - do not modify
      '/		the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
   End Class 'DefaultVB 
End Namespace 'Telerik.MenuExamplesVBNET.Integration.MenuAndEditor