
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Telerik.QuickStart
Imports Telerik.WebControls
Imports System.Drawing


Namespace Telerik.CallbackIntegarationExamplesVBNET.Rotator
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected WithEvents ddlGalery As Telerik.WebControls.CallbackDropDownList
      Protected Label2 As System.Web.UI.WebControls.Label
      Protected WithEvents CallbackRadioButtonList1 As Telerik.WebControls.CallbackRadioButtonList
      Protected Label3 As System.Web.UI.WebControls.Label
      Protected Label4 As System.Web.UI.WebControls.Label
      Protected tbFrameTimeout As System.Web.UI.WebControls.TextBox
      Protected WithEvents btnApply As Telerik.WebControls.CallbackButton
      Protected Label5 As System.Web.UI.WebControls.Label
      Protected RadRotator1 As Telerik.WebControls.RadRotator
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            CallbackRadioButtonList1.Items.Clear()
            Dim s As String
            For Each s In  [Enum].GetNames(GetType(RadRotator.RotatorTransitionEffect))
               CallbackRadioButtonList1.Items.Add(s)
            Next s
            CallbackRadioButtonList1.SelectedIndex = CallbackRadioButtonList1.Items.IndexOf(CallbackRadioButtonList1.Items.FindByText(RadRotator1.TransitionEffect.ToString()))
            LoadGallery(ddlGalery.SelectedIndex)
            tbFrameTimeout.Text = RadRotator1.FrameTimeout.ToString()
         End If
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
      Private Sub LoadGallery(galleryIndex As Integer)
         Dim table As New DataTable()
         table.Columns.Add("Image")
         table.Columns.Add("Descr")
         Dim galleryPrefix As String = "Gallery"
         If galleryIndex = 0 Then
            galleryPrefix = "Gallery1"
         ElseIf galleryIndex = 1 Then
            galleryPrefix = "Gallery2"
         Else
            galleryPrefix = "Gallery3"
         End If
         table.Rows.Add(New String() {galleryPrefix + "/Image1.jpg", "image 1"})
         table.Rows.Add(New String() {galleryPrefix + "/Image2.jpg", "image 2"})
         table.Rows.Add(New String() {galleryPrefix + "/Image3.jpg", "image 3"})
         
         RadRotator1.DataSource = table
         RadRotator1.DataBind()
      End Sub 'LoadGallery
       
      
      Private Sub ddlGalery_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGalery.SelectedIndexChanged
         LoadGallery(ddlGalery.SelectedIndex)
         CType(sender, Telerik.WebControls.CallbackDropDownList).ControlsToUpdate.Add(RadRotator1)
      End Sub 'ddlGalery_SelectedIndexChanged
      
      
      Private Sub CallbackRadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CallbackRadioButtonList1.SelectedIndexChanged
         LoadGallery(ddlGalery.SelectedIndex)
         RadRotator1.TransitionEffect = CType([Enum].Parse(GetType(RadRotator.RotatorTransitionEffect), CallbackRadioButtonList1.SelectedItem.Text), RadRotator.RotatorTransitionEffect)
         CType(sender, Telerik.WebControls.CallbackRadioButtonList).ControlsToUpdate.Add(RadRotator1)
      End Sub 'CallbackRadioButtonList1_SelectedIndexChanged
      
      
      Private Sub btnApply_Click(sender As Object, e As System.EventArgs) Handles btnApply.Click
         Dim frameTimeout As Integer = Integer.Parse(tbFrameTimeout.Text)
         If frameTimeout < 1000 Or frameTimeout > 3000 Then
            btnApply.Alert("Invalid number. Please, select a frame timeout between [1000, 3000].")
            tbFrameTimeout.Text = RadRotator1.FrameTimeout.ToString()
         Else
            RadRotator1.FrameTimeout = frameTimeout
         End If
         LoadGallery(ddlGalery.SelectedIndex)
         CType(sender, Telerik.WebControls.CallbackButton).ControlsToUpdate.Add(RadRotator1)
      End Sub 'btnApply_Click
   End Class 'DefaultVB
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.Rotator