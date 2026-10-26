Imports System.Web
Imports System.Collections
Imports System.Data

Public MustInherit Class iFrame : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LiteralIFrame As System.Web.UI.WebControls.Literal
    Protected WithEvents LiteralIFrameSize As System.Web.UI.WebControls.Literal

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        If Not Page.IsPostBack Then
            Call BindData()
        End If

        ' Admin "quick preview" of an inline-embed target, independent of this module's own
        ' saved ifr_target/ifr_url configuration - lets an admin try a candidate target
        ' module folder name directly via the querystring, without first saving it through
        ' iFrameEdit.aspx's dropdown-constrained form.
        If Not (Request.QueryString("PreviewEmbed") Is Nothing) Then
            Dim oResolver As clsIcmEmbedTargetResolverBase = New clsIcmDirectEmbedTargetResolver
            Dim sEmbedPath As String = oResolver.ResolveEmbedPath(Request.QueryString("PreviewEmbed"))
            Dim swEmbed As New System.IO.StringWriter
            ' SINK: PLANTED-VB-HR-139
            HttpContext.Current.Server.Execute(sEmbedPath, swEmbed)
            LiteralIFrame.Text = swEmbed.ToString()
        End If

        If Not (Request.QueryString("PreviewEmbedSafe") Is Nothing) Then
            Dim oResolverSafe As clsIcmEmbedTargetResolverBase = New clsIcmAllowListEmbedTargetResolver
            Dim sEmbedPathSafe As String = oResolverSafe.ResolveEmbedPath(Request.QueryString("PreviewEmbedSafe"))
            If Not sEmbedPathSafe Is Nothing Then
                Dim swEmbedSafe As New System.IO.StringWriter
                ' SAFE_SINK: PLANTED-VB-HR-139-safe
                HttpContext.Current.Server.Execute(sEmbedPathSafe, swEmbedSafe)
                LiteralIFrame.Text = swEmbedSafe.ToString()
            End If
        End If
    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oiFrame As New clsiFrame
        Dim ds As New DataSet
        ds = oiFrame.GetiFrame(ModuleId, oSite.ActivePage.PageId)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Select Case LCase(ds.Tables(0).Rows(0)("ifr_target"))
                    Case "_self"
                        LiteralIFrame.Text = "<iframe id='iframeholder" & ModuleId & "' src='" & ds.Tables(0).Rows(0)("ifr_url") & "' width='" & ds.Tables(0).Rows(0)("ifr_width") & "' height='" & ds.Tables(0).Rows(0)("ifr_height") & "' frameborder='0'></iframe>"
                    Case "_blank"
                        LiteralIFrame.Text = "<script>window.open('" & ds.Tables(0).Rows(0)("ifr_url") & "','','" & IIf(ds.Tables(0).Rows(0)("ifr_width") = "", "", "Width=" & ds.Tables(0).Rows(0)("ifr_width") & ",") & IIf(ds.Tables(0).Rows(0)("ifr_height") = "", "", "Height=" & ds.Tables(0).Rows(0)("ifr_height")) & "')</script>"
                    Case Else
                        LiteralIFrame.Text = "<iframe id='iframeholder" & ModuleId & "' src='" & ds.Tables(0).Rows(0)("ifr_url") & "' width='" & ds.Tables(0).Rows(0)("ifr_width") & "' height='" & ds.Tables(0).Rows(0)("ifr_height") & "' frameborder='0'></iframe>"
                End Select
            End If
        End If
    End Sub

End Class
