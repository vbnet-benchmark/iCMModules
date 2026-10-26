Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI.htmlControls
Imports System.Web.UI

Public Class Template004 : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Dot As System.Web.UI.WebControls.Image
    Protected WithEvents Navigation As System.Web.UI.WebControls.Table
    Protected WithEvents NextPage As System.Web.UI.WebControls.Table
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Header As System.Web.UI.WebControls.Table
    Protected WithEvents Media As System.Web.UI.WebControls.Table
    Protected WithEvents Content As System.Web.UI.WebControls.Table
    Protected WithEvents HeaderText As System.Web.UI.WebControls.TextBox
    Protected WithEvents ContentText As System.Web.UI.WebControls.Label
    Protected WithEvents MediaButton1 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton2 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton3 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton4 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton5 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton6 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton7 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton8 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton9 As System.Web.UI.WebControls.Image
    Protected WithEvents MediaButton10 As System.Web.UI.WebControls.Image
    Protected WithEvents imgNextPage As System.Web.UI.WebControls.Image
    Protected WithEvents lblNextPage As System.Web.UI.WebControls.Label
    Protected WithEvents NavLink1 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink2 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink3 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink4 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink5 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink6 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink7 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink8 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink9 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink10 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink11 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink12 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink13 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink14 As System.Web.UI.WebControls.Button
    Protected WithEvents NavLink15 As System.Web.UI.WebControls.Button
    Protected WithEvents space1 As System.Web.UI.WebControls.Panel
    Protected WithEvents NavTd1 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd2 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd3 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd4 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd5 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd6 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd7 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd8 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd9 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd10 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd11 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd12 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd13 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd14 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NavTd15 As System.Web.UI.WebControls.TableCell
    Protected WithEvents NextPic As System.Web.UI.WebControls.TableCell
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        Minimizer.ID = ModuleId
        'ContentText.Text = "<b>Johan</b> Olofsson<br><br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop<br>pop3<br>pop<br>pop<br>pop2<br>pop<br>pop4<br>pop2<br>pop<br>pop4"
        Call BindData()
        Call BindNavigation()
    End Sub

    Private Sub BindData()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate004 As New clsTemplate004(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim dst As DataSet = oTemplate004.GetTemplate
            ' Bind Mediafiles...
            MediaButton1.Visible = False
            MediaButton2.Visible = False
            MediaButton3.Visible = False
            MediaButton4.Visible = False
            MediaButton5.Visible = False
            MediaButton6.Visible = False
            MediaButton7.Visible = False
            MediaButton8.Visible = False
            MediaButton9.Visible = False
            MediaButton10.Visible = False
            If dst.Tables.Count > 0 Then
                If dst.Tables(0).Rows.Count > 0 Then
                    HeaderText.Text = dst.Tables(0).Rows(0)("tem_header")
                    ContentText.Text = "<b>" & dst.Tables(0).Rows(0)("tem_ingress") & "</b>" & "<br><br>" & _
                                       TransformToHTML(dst.Tables(0).Rows(0)("tem_text"))
                    lblNextPage.Text = TransformToHTML(dst.Tables(0).Rows(0)("tem_navtext"))

                    Dim i As Integer = 0
                    If CType(dst.Tables(0).Rows(0)("tem_medialink1"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink1"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink2"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink2"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink3"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink3"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink4"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink4"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink5"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink5"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink6"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink6"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink7"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink7"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink8"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink8"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink9"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink9"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If
                    If CType(dst.Tables(0).Rows(0)("tem_medialink10"), String).Length > 0 Then
                        Dim sTemp As String = CType(dst.Tables(0).Rows(0)("tem_medialink10"), String)
                        i += 1 : BindMediaFile(i, sTemp.Substring(0, sTemp.IndexOf(";")), sTemp.Substring(sTemp.IndexOf(";") + 1))
                    End If

                End If
            End If
            Dim ds As DataSet = oTemplate004.GetRedirect(ModuleId, oSite.ActivePage.PageId)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    imgNextPage.Attributes.Add("onclick", "document.location.href='" & ds.Tables(0).Rows(0)("qui_url") & "'")
                    imgNextPage.Style.Add("cursor", "hand")
                    NextPic.Attributes.Add("onclick", "document.location.href='" & ds.Tables(0).Rows(0)("qui_url") & "'")
                    NextPic.Style.Add("cursor", "hand")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindMediaFile(ByVal i As Integer, ByVal Type As String, ByVal Data As String)
        Try
            Dim WindowFunc As String = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no"
            Select Case i
                Case 1
                    MediaButton1.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton1.Attributes.Add("onmouseover", "ShowToolTip(1,'" & Type & "')")
                    MediaButton1.Attributes.Add("onmouseout", "HideToolTip(1)")
                    MediaButton1.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton1.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton1.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton1.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton1.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton1.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton1.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton1.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton1.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton1.Visible = True
                Case 2
                    MediaButton2.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton2.Attributes.Add("onmouseover", "ShowToolTip(2,'" & Type & "')")
                    MediaButton2.Attributes.Add("onmouseout", "HideToolTip(2)")
                    MediaButton2.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton2.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton2.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton2.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton2.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton2.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton2.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton2.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton2.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton2.Visible = True
                Case 3
                    MediaButton3.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton3.Attributes.Add("onmouseover", "ShowToolTip(3,'" & Type & "')")
                    MediaButton3.Attributes.Add("onmouseout", "HideToolTip(3)")
                    MediaButton3.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton3.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton3.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton3.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton3.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton3.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton3.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton3.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton3.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton3.Visible = True
                Case 4
                    MediaButton4.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton4.Attributes.Add("onmouseover", "ShowToolTip(4,'" & Type & "')")
                    MediaButton4.Attributes.Add("onmouseout", "HideToolTip(4)")
                    MediaButton4.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton4.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton4.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton4.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton4.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton4.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton4.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton4.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton4.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton4.Visible = True
                Case 5
                    MediaButton5.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton5.Attributes.Add("onmouseover", "ShowToolTip(5,'" & Type & "')")
                    MediaButton5.Attributes.Add("onmouseout", "HideToolTip(5)")
                    MediaButton5.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton5.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton5.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton5.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton5.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton5.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton5.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton5.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton5.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton5.Visible = True
                Case 6
                    MediaButton6.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton6.Attributes.Add("onmouseover", "ShowToolTip(6,'" & Type & "')")
                    MediaButton6.Attributes.Add("onmouseout", "HideToolTip(6)")
                    MediaButton6.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton6.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton6.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton6.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton6.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton6.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton6.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton6.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton6.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton6.Visible = True
                Case 7
                    MediaButton7.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton7.Attributes.Add("onmouseover", "ShowToolTip(7,'" & Type & "')")
                    MediaButton7.Attributes.Add("onmouseout", "HideToolTip(7)")
                    MediaButton7.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton7.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton7.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton7.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton7.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton7.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton7.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton7.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton7.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton7.Visible = True
                Case 8
                    MediaButton8.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton8.Attributes.Add("onmouseover", "ShowToolTip(8,'" & Type & "')")
                    MediaButton8.Attributes.Add("onmouseout", "HideToolTip(8)")
                    MediaButton8.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton8.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton8.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton8.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton8.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton8.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton8.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton8.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton8.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton8.Visible = True
                Case 9
                    MediaButton9.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton9.Attributes.Add("onmouseover", "ShowToolTip(9,'" & Type & "')")
                    MediaButton9.Attributes.Add("onmouseout", "HideToolTip(9)")
                    MediaButton9.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton9.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton9.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton9.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton9.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton9.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton9.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton9.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton9.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton9.Visible = True
                Case 10
                    MediaButton10.Attributes.Add("onclick", "window.open('" & Data & "','','" & WindowFunc & "')")
                    MediaButton10.Attributes.Add("onmouseover", "ShowToolTip(10,'" & Type & "')")
                    MediaButton10.Attributes.Add("onmouseout", "HideToolTip(10)")
                    MediaButton10.Style.Add("cursor", "hand")
                    Select Case Type
                        Case "page" : MediaButton10.ImageUrl = "Images/link.gif"
                        Case "word" : MediaButton10.ImageUrl = "Images/word.gif"
                        Case "pdf" : MediaButton10.ImageUrl = "Images/pdf.gif"
                        Case "pic" : MediaButton10.ImageUrl = "Images/link.gif"
                        Case "movie" : MediaButton10.ImageUrl = "Images/movie.gif"
                        Case "link" : MediaButton10.ImageUrl = "Images/link.gif"
                        Case "sound" : MediaButton10.ImageUrl = "Images/sound.gif"
                        Case "flash" : MediaButton10.ImageUrl = "Images/plugin.gif"
                    End Select
                    MediaButton10.Visible = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindNavigation()
        Try
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oTemplate004 As New clsTemplate004(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
            Dim ds As DataSet = oTemplate004.GetSubMenuItem
            Dim Max As Integer = 0
            For Each dr As DataRow In ds.Tables(0).Rows
                Max += 1
                If Max <= 15 Then
                    ShowNavigation(Max, dr("pag_name"), "icm.aspx?PageId=" & dr("pag_id"))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowNavigation(ByVal Field As Integer, ByVal Title As String, ByVal Link As String)
        Try
            Dim t As New Table
            t.CellPadding = 0
            t.CellSpacing = 0
            t.Style.Add("cursor", "hand")
            Dim tr As New TableRow
            tr.Style.Add("cursor", "hand")
            Dim td As New TableCell
            td.VerticalAlign = VerticalAlign.Bottom
            td.Style.Add("cursor", "hand")
            Dim NavLink As New Label
            NavLink.ForeColor = Drawing.Color.FromName("#ffffff")
            NavLink.Font.Bold = True
            NavLink.Font.Name = "verdana"
            NavLink.Font.Size = FontUnit.XXSmall
            NavLink.Text = Title
            NavLink.Attributes.Add("onclick", "document.location.href='" & Link & "'")
            td.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
            td.Controls.Add(NavLink)
            tr.Controls.Add(td)
            t.Controls.Add(tr)
            Select Case Field
                Case 1
                    NavTd1.Controls.Add(t)
                    NavTd1.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd1.Style.Add("cursor", "hand")
                Case 2
                    NavTd2.Controls.Add(t)
                    NavTd2.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd2.Style.Add("cursor", "hand")
                Case 3
                    NavTd3.Controls.Add(t)
                    NavTd3.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd3.Style.Add("cursor", "hand")
                Case 4
                    NavTd4.Controls.Add(t)
                    NavTd4.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd4.Style.Add("cursor", "hand")
                Case 5
                    NavTd5.Controls.Add(t)
                    NavTd5.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd5.Style.Add("cursor", "hand")
                Case 6
                    NavTd6.Controls.Add(t)
                    NavTd6.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd6.Style.Add("cursor", "hand")
                Case 7
                    NavTd7.Controls.Add(t)
                    NavTd7.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd7.Style.Add("cursor", "hand")
                Case 8
                    NavTd8.Controls.Add(t)
                    NavTd8.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd8.Style.Add("cursor", "hand")
                Case 9
                    NavTd9.Controls.Add(t)
                    NavTd9.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd9.Style.Add("cursor", "hand")
                Case 10
                    NavTd10.Controls.Add(t)
                    NavTd10.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd10.Style.Add("cursor", "hand")
                Case 11
                    NavTd11.Controls.Add(t)
                    NavTd11.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd11.Style.Add("cursor", "hand")
                Case 12
                    NavTd12.Controls.Add(t)
                    NavTd12.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd12.Style.Add("cursor", "hand")
                Case 13
                    NavTd13.Controls.Add(t)
                    NavTd13.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd13.Style.Add("cursor", "hand")
                Case 14
                    NavTd14.Controls.Add(t)
                    NavTd14.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd14.Style.Add("cursor", "hand")
                Case 15
                    NavTd15.Controls.Add(t)
                    NavTd15.Attributes.Add("onclick", "document.location.href='" & Link & "'")
                    NavTd15.Style.Add("cursor", "hand")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function TransformToHTML(ByVal str As String) As String
        Try
            str = Replace(str, vbCrLf, "<br>")
            str = Replace(str, vbTab, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            'str = Replace(str, " ", "&nbsp;")
            Return str
        Catch ex As Exception
            Return str
        End Try
    End Function

End Class
