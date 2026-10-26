Imports iConsulting
Imports iConsulting.iCMServer
Imports iConsulting.iCMServer.iCDataManager
Imports System.Web
Imports System.Web.Security

Public Class AutoLogin
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim _user As String = Request.Params("user").Substring(0, Request.Params("user").IndexOf(":"))
            Dim _pass As String = Request.Params("user").Substring(Request.Params("user").IndexOf(":") + 1)
            If Not IsNothing(_user) Then
                Dim oSignIn As New clsSignIn
                Dim sUserEmail As String = oSignIn.Login(_user, _pass)
                If Not (sUserEmail Is Nothing) And sUserEmail <> "" Then
                    Try
                        FormsAuthentication.SignOut()
                        Response.Cookies("siteroles").Value = Nothing
                        Response.Cookies("siteroles").Path = "/"
                        Response.Cookies("siteroles").Expires = New System.DateTime(1999, 10, 12)
                    Catch ex As Exception

                    Finally
                        FormsAuthentication.SetAuthCookie(sUserEmail, False)
                        Response.Redirect("~/Default.aspx", True)
                    End Try
                Else
                    Response.Redirect("~/Default.aspx", True)
                End If
            End If
        Catch ex As Exception
            Response.Redirect("~/Default.aspx", True)
        End Try
    End Sub

End Class
