Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Public Class Template007 : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTo As System.Web.UI.WebControls.Label
    Protected WithEvents ddTo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblFrom As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNote As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubject As System.Web.UI.WebControls.Label
    Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents txtText As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSend As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        If Not Page.IsPostBack Then
            Call BindData()
        End If
        Panel1.Visible = False
    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oLanguageText As New clsLanguageText
            Dim al As ArrayList = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template007")
            Dim oTemplate007 As New clsTemplate007(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate007.GetTemplate

            ddTo.Items.Clear()
            txtFrom.Text = String.Empty
            txtSubject.Text = String.Empty
            txtText.Text = String.Empty

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim Users() As String = CType(ds.Tables(0).Rows(0)("tem_users"), String).Split(vbCrLf)
                    For Each user As String In Users
                        If user.Length > 3 Then ddTo.Items.Add(New ListItem(user.Substring(0, user.IndexOf(";")), user.Substring(user.IndexOf(";") + 1)))
                    Next
                End If
            End If


            lblTo.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_to"))
            lblFrom.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_from"))
            lblSubject.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_subject"))
            lblText.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_text"))
            lblNote.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_who"))
            btnSend.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_send"))

        Catch ex As Exception

        End Try
    End Sub

    Private Function SendMail() As Boolean
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oLanguageText As New clsLanguageText
            Dim al As ArrayList = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template007")
            Dim oTemplate007 As New clsTemplate007(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate007.GetTemplate
            Dim oMail As New iConsulting.Library.Mail.clsSmtpMail
            Dim tmpFrom As String
            Dim tmpBody As String

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then

                    If txtFrom.Text.Length < 4 Then
                        tmpFrom = ds.Tables(0).Rows(0)("tem_smtpmail")
                        tmpBody = Server.HtmlDecode(oLanguageText.Find(al, "template007_fromspec")) & txtFrom.Text & vbCrLf & txtText.Text
                    Else
                        If txtFrom.Text.IndexOf("@", 1) > 0 And txtFrom.Text.IndexOf(".", 3) > 0 Then '   Not InStr(txtFrom.Text, "@") = 0 Then
                            tmpFrom = txtFrom.Text
                            tmpBody = txtText.Text
                        Else
                            tmpFrom = ds.Tables(0).Rows(0)("tem_smtpmail")
                            tmpBody = Server.HtmlDecode(oLanguageText.Find(al, "template007_fromspec")) & txtFrom.Text & vbCrLf & txtText.Text
                        End If
                    End If

                    oMail.MailServer = ds.Tables(0).Rows(0)("tem_smtpserver")
                    oMail.MailFrom = tmpFrom
                    oMail.MailTo = ddTo.SelectedValue
                    oMail.MailSubject = ds.Tables(0).Rows(0)("tem_subjectprefix") & " - " & txtSubject.Text
                    oMail.MailBody = tmpBody
                    oMail.MailFormat = 1
                    Return oMail.Send()

                End If
            End If
            Return False
        Catch ex As Exception
            Response.Write(ex)
            Return False
        End Try
    End Function

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLanguageText As New clsLanguageText
        Dim al As ArrayList = oLanguageText.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Template007")
        If SendMail() Then
            lblMessage.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_messageok"))
        Else
            lblMessage.Text = Server.HtmlDecode(oLanguageText.Find(al, "template007_messageerror"))
        End If
        txtFrom.Text = String.Empty
        txtSubject.Text = String.Empty
        txtText.Text = String.Empty
        Panel1.Visible = True
    End Sub

End Class
