
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports Telerik.QuickStart
Imports Telerik.WebControls


Namespace Telerik.CallbackIntegarationExamplesVBNET.RotatorAndCallback
   
   '/ <summary>
   '/ Summary description for _Default.
   '/ </summary>
   Public Class DefaultVB
      Inherits XhtmlPage
      Protected genericCallback As Telerik.WebControls.RadCallback
      Protected panelImagePreviewLoading As System.Web.UI.WebControls.Panel
      Protected imagePreview As Telerik.WebControls.CallbackImage
      Protected labelImageName As System.Web.UI.WebControls.Label
      Protected labelImageKeywords As System.Web.UI.WebControls.Label
      Protected labelImageComments As System.Web.UI.WebControls.Label
      Protected viewPanel As System.Web.UI.WebControls.Panel
      Protected textImageName As System.Web.UI.WebControls.TextBox
      Protected textImageKeywords As System.Web.UI.WebControls.TextBox
      Protected textImageComments As System.Web.UI.WebControls.TextBox
      Protected editPanel As System.Web.UI.WebControls.Panel
      Protected panelLoadingImage As System.Web.UI.WebControls.Panel
      Protected thumbRotator As Telerik.WebControls.RadRotator
      
      
      Private Property imagesArray() As System.Collections.ArrayList
         Get
            Return CType(Session("imagesArray"), System.Collections.ArrayList)
         End Get
         Set
            Session("imagesArray") = value
         End Set
      End Property
      
      Private Structure fileInfo
         Public filename As String
         Public name As String
         Public keywords As String
         Public comments As String
      End Structure 'fileInfo
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         ' Put user code to initialize the page here
         If Not IsPostBack Then
            imagesArray = New System.Collections.ArrayList()
            Dim fileName As String
            For Each fileName In  System.IO.Directory.GetFiles(Server.MapPath((Request.FilePath.Substring(0, Request.FilePath.LastIndexOf("/"c) + 1) + "Images")), "thumb?.gif")
               Dim fInfo As New fileInfo()
               fInfo.name = fileName.Substring((fileName.LastIndexOf("\") + 1))
               fInfo.filename = fInfo.name
               fInfo.keywords = "images, telerik"
               fInfo.comments = "put comments here"
               imagesArray.Add(fInfo)
            Next fileName
            RebindRotator()
         End If
      End Sub 'Page_Load
      
      Private Function FindFileInfo(filePath As String) As fileInfo
         Dim fileName As String = filePath.Substring((filePath.LastIndexOf("/"c) + 1)).Replace("FullSize.jpg", ".gif")
         Dim tempInfo As fileInfo
         For Each tempInfo In  imagesArray
            If tempInfo.filename = fileName Then
               Return tempInfo
            End If
         Next tempInfo
         Return New fileInfo()
      End Function 'FindFileInfo
      
      Private Sub RebindRotator()
         Dim rotatorData As New DataTable()
         rotatorData.Columns.Add("Image")
         rotatorData.Columns.Add("Name")
         Dim tempInfo As fileInfo
         For Each tempInfo In  imagesArray
            rotatorData.Rows.Add(New String() {tempInfo.filename, tempInfo.name})
         Next tempInfo
         thumbRotator.DataSource = rotatorData
         thumbRotator.DataBind()
      End Sub 'RebindRotator
      
      Protected Sub genericCallback_Callback(sender As Object, e As Telerik.WebControls.CallbackEventArgs)
         Dim fInfo As fileInfo
         Select Case e.CallbackEvent
            Case "ShowImage"
               'show the image
               imagePreview.ImageUrl = e.Args.Replace(".gif", "FullSize.jpg")
               'set the image information
               fInfo = FindFileInfo(e.Args.Substring((e.Args.LastIndexOf("/"c) + 1)))
               labelImageComments.Text = fInfo.comments
               labelImageKeywords.Text = fInfo.keywords
               labelImageName.Text = fInfo.name
               textImageComments.Text = fInfo.comments
               textImageKeywords.Text = fInfo.keywords
               textImageName.Text = fInfo.name
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageName)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageKeywords)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageComments)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(textImageComments)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(textImageKeywords)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(textImageName)
               CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(imagePreview)
            Case "UpdateImageSettings"
               If imagePreview.ImageUrl <> "Images/spacer.gif" Then
                  fInfo = FindFileInfo(imagePreview.ImageUrl)
                  imagesArray.Remove(fInfo)
                  fInfo.name = textImageName.Text
                  fInfo.keywords = textImageKeywords.Text
                  fInfo.comments = textImageComments.Text
                  labelImageComments.Text = fInfo.comments
                  labelImageKeywords.Text = fInfo.keywords
                  labelImageName.Text = fInfo.name
                  imagesArray.Add(fInfo)
                  RebindRotator()
                  CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(thumbRotator)
                  CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageName)
                  CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageKeywords)
                  CType(sender, Telerik.WebControls.RadCallback).ControlsToUpdate.Add(labelImageComments)
               End If
            Case Else
         End Select
      End Sub 'genericCallback_Callback
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
End Namespace 'Telerik.CallbackIntegarationExamplesVBNET.RotatorAndCallback