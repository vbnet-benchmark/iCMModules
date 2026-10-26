Imports System.Data
Imports System.Web.UI.WebControls

Public Class Appointment3
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents lblSubject As System.Web.UI.WebControls.Label
    Protected WithEvents lblStartTime As System.Web.UI.WebControls.Label
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtText As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddDay As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblEndTime As System.Web.UI.WebControls.Label
    Protected WithEvents ddYear2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddMonth2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddDay2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblError2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabel As System.Web.UI.WebControls.Label
    Protected WithEvents ddLabel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUsers As System.Web.UI.WebControls.Label
    Protected WithEvents ddUsers As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private CalId As Integer = 0
    Protected ModId As Integer = 0
    Private PageId As Integer = 0
    Private UsrId As String = String.Empty
    Private SelectedDate As String = ""
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")

        If Not (Request.Params("CalId") Is Nothing) Then
            CalId = Int32.Parse(Request.Params("CalId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not (Request.Params("UsrId") Is Nothing) Then
            UsrId = Int32.Parse(Request.Params("UsrId"))
        End If

        If Not (Request.Params("SelectedDate") Is Nothing) Then
            SelectedDate = Request.Params("SelectedDate")
        End If

        If Not Page.IsPostBack Then
            Call BindData()
        End If

    End Sub

    Private Sub BindData()

        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Timesheet3")

        lblHeader.Text = IIf(CalId = 0, Server.HtmlDecode(oLang.Find(al, "timesheet3_newapp")), Server.HtmlDecode(oLang.Find(al, "timesheet3_newedit"))) '"Appointment" 'Server.HtmlDecode(oLang.Find(al, "timesheet3_newapp"))'"Appointment" 'Server.HtmlDecode(oLang.Find(al, "timesheet3_newedit"))
        lblSubject.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_subject")) & "&nbsp;"
        lblText.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_text")) & "&nbsp;"
        lblStartTime.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_datefrom")) & "&nbsp;"
        lblEndTime.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_dateto")) & "&nbsp;"
        'lblStart.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_start")) & "&nbsp;"
        'lblEnd.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_end")) & "&nbsp;"
        lblLabel.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_label")) & "&nbsp;"
        lblUsers.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_users")) & "&nbsp;"
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_delete"))
        lblError.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_errordate"))
        lblError.Visible = False 'timesheet3_text
        lblError2.Text = Server.HtmlDecode(oLang.Find(al, "timesheet3_errordate"))
        lblError2.Visible = False 'timesheet3_text

        Dim sConfirm As String = Server.HtmlDecode(oLang.Find(al, "timesheet3_confirmdelete"))
        btnDelete.Attributes.Add("onclick", "return confirm('" & sConfirm & "');")

        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_none")), "#FFFFFF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_important")), "#FF9999"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_business")), "#6699CC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_personal")), "#99CC66"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_vacation")), "#CCCCCC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_mustattend")), "#FF9966"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_travelrequired")), "#99FFFF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_needspreperation")), "#CCCC99"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_birthday")), "#CC99FF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_anniversary")), "#99CCCC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "timesheet3_label_phonecall")), "#FFCC66"))
        ddLabel.SelectedValue = "#FFFFFF"

        If CalId = 0 Then
            If IsDate(SelectedDate) Then
                Call RenderDateBoxes(SelectedDate)
                Try
                    ddYear.SelectedValue = CType(SelectedDate, Date).Year.ToString
                    ddMonth.SelectedValue = Format(CType(SelectedDate, Date).Month, "00")
                    ddDay.SelectedValue = Format(CType(SelectedDate, Date).Day, "00")
                    ddYear2.SelectedValue = CType(SelectedDate, Date).Year.ToString
                    ddMonth2.SelectedValue = Format(CType(SelectedDate, Date).Month, "00")
                    ddDay2.SelectedValue = Format(CType(SelectedDate, Date).Day, "00")
                Catch ex As Exception
                    ddYear.SelectedValue = CType(Now, Date).Year.ToString
                    ddMonth.SelectedValue = Format(CType(Now, Date).Month, "00")
                    ddDay.SelectedValue = Format(CType(Now, Date).Day, "00")
                    ddYear2.SelectedValue = CType(Now, Date).Year.ToString
                    ddMonth2.SelectedValue = Format(CType(Now, Date).Month, "00")
                    ddDay2.SelectedValue = Format(CType(Now, Date).Day, "00")
                End Try
            Else
                Call RenderDateBoxes(Now.ToString)
                ddYear.SelectedValue = Now.Year.ToString
                ddMonth.SelectedValue = Format(Now.Month, "00")
                ddDay.SelectedValue = Format(Now.Day, "00")
                ddYear2.SelectedValue = Now.Year.ToString
                ddMonth2.SelectedValue = Format(Now.Month, "00")
                ddDay2.SelectedValue = Format(Now.Day, "00")
            End If

            ' /// Users
            Dim oTimesheet3 As New clsTimesheet3(ModId)
            Dim dsUserRoles As New System.data.DataSet
            dsUserRoles = oTimesheet3.GetAllUsers3
            Dim l As ListItem
            Dim dra As DataRow
            ddUsers.Items.Clear()
            Dim Users() As String
            For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
                If _mod.ModuleId = ModId Then Users = Split(_mod.EditSrc, ";")
            Next
            For Each dra In dsUserRoles.Tables(0).Rows
                For Each s As String In Users
                    If s.Length > 0 And s.ToLower = CType(dra("usr_id"), String).ToLower Then
                        l = New ListItem
                        l.Text = IIf(IsDBNull(dra("usr_firstname")), "", dra("usr_firstname")) & " " & IIf(IsDBNull(dra("usr_lastname")), "", dra("usr_lastname"))
                        l.Value = dra("usr_id")
                        ddUsers.Items.Add(l)
                    End If
                Next
            Next
            If UsrId.Length > 0 Then
                Try
                    ddUsers.SelectedValue = UsrId
                Catch ex As Exception
                    ddUsers.SelectedIndex = 0
                End Try
            Else
                ddUsers.SelectedIndex = 0
            End If


        Else
            Dim oCal As New clsTimesheet3(ModId)
            Dim ds As DataSet = oCal.GetAppointment(CalId)

            Dim Subject As String
            Dim Text As String
            Dim sStartYear As String
            Dim sStartMonth As String
            Dim sStartDay As String
            Dim sStartTime As String
            Dim sEndYear As String
            Dim sEndMonth As String
            Dim sEndDay As String
            Dim sEndTime As String
            Dim sLabel As String
            Dim sUser As String
            If ds.Tables(0).Rows.Count > 1 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Dim dr2 As DataRow = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)
                Call RenderDateBoxes(dr("tim_starttime"))
                Dim p1 As String = CType(dr("tim_starttime"), Date).ToLongTimeString
                Dim p2 As String = CType(dr2("tim_endtime"), Date).ToLongTimeString
                Subject = dr("tim_subject")
                Text = dr("tim_text")
                sStartYear = CType(dr("tim_starttime"), Date).Year.ToString
                sStartMonth = Format(CType(dr("tim_starttime"), Date).Month, "00")
                sStartDay = Format(CType(dr("tim_starttime"), Date).Day, "00")
                sStartTime = Format(CType(p1, Date).Hour, "00") & ":" & Format(CType(p1, Date).Minute, "00")
                sEndYear = CType(dr2("tim_endtime"), Date).Year.ToString
                sEndMonth = Format(CType(dr2("tim_endtime"), Date).Month, "00")
                sEndDay = Format(CType(dr2("tim_endtime"), Date).Day, "00")
                sEndTime = Format(CType(p2, Date).Hour, "00") & ":" & Format(CType(p2, Date).Minute, "00")
                sLabel = CType(dr("tim_label"), String)
                sUser = CType(dr("tim_attendees"), String)
            Else
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Call RenderDateBoxes(dr("tim_starttime"))
                Dim p1 As String = CType(dr("tim_starttime"), Date).ToLongTimeString
                Dim p2 As String = CType(dr("tim_endtime"), Date).ToLongTimeString
                Subject = dr("tim_subject")
                Text = dr("tim_text")
                sStartYear = CType(dr("tim_starttime"), Date).Year.ToString
                sStartMonth = Format(CType(dr("tim_starttime"), Date).Month, "00")
                sStartDay = Format(CType(dr("tim_starttime"), Date).Day, "00")
                sStartTime = Format(CType(p1, Date).Hour, "00") & ":" & Format(CType(p1, Date).Minute, "00")
                sEndYear = CType(dr("tim_endtime"), Date).Year.ToString
                sEndMonth = Format(CType(dr("tim_endtime"), Date).Month, "00")
                sEndDay = Format(CType(dr("tim_endtime"), Date).Day, "00")
                sEndTime = Format(CType(p2, Date).Hour, "00") & ":" & Format(CType(p2, Date).Minute, "00")
                sLabel = CType(dr("tim_label"), String)
                sUser = CType(dr("tim_attendees"), String)
            End If

            txtSubject.Text = Server.HtmlDecode(Subject)
            txtText.Text = Server.HtmlDecode(Text)
            Try
                ddYear.SelectedValue = sStartYear
                ddMonth.SelectedValue = sStartMonth
                ddDay.SelectedValue = sStartDay
                ddYear2.SelectedValue = sEndYear
                ddMonth2.SelectedValue = sEndMonth
                ddDay2.SelectedValue = sEndDay
                ddLabel.SelectedValue = sLabel
            Catch ex As Exception
                ddYear.SelectedValue = CType(Now, Date).Year.ToString
                ddMonth.SelectedValue = Format(CType(Now, Date).Month, "00")
                ddDay.SelectedValue = Format(CType(Now, Date).Day, "00")
                ddYear2.SelectedValue = CType(Now, Date).Year.ToString
                ddMonth2.SelectedValue = Format(CType(Now, Date).Month, "00")
                ddDay2.SelectedValue = Format(CType(Now, Date).Day, "00")
                ddLabel.SelectedValue = "#FFFFFF"
            End Try

            ' /// Users
            Dim oTimesheet3 As New clsTimesheet3(ModId)
            Dim dsUserRoles As New System.data.DataSet
            dsUserRoles = oTimesheet3.GetAllUsers3
            Dim l As ListItem
            Dim drb As DataRow
            ddUsers.Items.Clear()
            Dim Users() As String
            For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
                If _mod.ModuleId = ModId Then Users = Split(_mod.EditSrc, ";")
            Next
            For Each drb In dsUserRoles.Tables(0).Rows
                For Each s As String In Users
                    If s.Length > 0 And s.ToLower = CType(drb("usr_id"), String).ToLower Then
                        l = New ListItem
                        l.Text = IIf(IsDBNull(drb("usr_firstname")), "", drb("usr_firstname")) & " " & IIf(IsDBNull(drb("usr_lastname")), "", drb("usr_lastname"))
                        l.Value = drb("usr_id")
                        ddUsers.Items.Add(l)
                    End If
                Next
            Next
            ddUsers.SelectedIndex = 0
            If sUser.Length > 0 Then ddUsers.SelectedValue = sUser
        End If

    End Sub

    Private Sub RenderDateBoxes(ByVal RenderDate As String)
        Try
            ddYear.Items.Clear()
            For i As Integer = CType(RenderDate, Date).Year To CType(RenderDate, Date).AddYears(10).Year
                ddYear.Items.Add(New ListItem(i.ToString, i.ToString))
            Next
            ddMonth.Items.Clear()
            For i As Integer = CType(RenderDate, Date).Month To 12
                ddMonth.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            Next
            ddDay.Items.Clear()
            For i As Integer = CType(RenderDate, Date).Day To CType(RenderDate, Date).DaysInMonth(CType(RenderDate, Date).Year, CType(RenderDate, Date).Month)
                ddDay.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            Next
            ddYear2.Items.Clear()
            For i As Integer = CType(RenderDate, Date).Year To CType(RenderDate, Date).AddYears(10).Year
                ddYear2.Items.Add(New ListItem(i.ToString, i.ToString))
            Next
            ddMonth2.Items.Clear()
            For i As Integer = 1 To 12
                ddMonth2.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            Next
            ddDay2.Items.Clear()
            For i As Integer = 1 To 31 'CType(SelectedDate, Date).DaysInMonth(CType(SelectedDate, Date).Year, CType(SelectedDate, Date).Month)
                ddDay2.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>this.close();</SCRIPT>")
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        btnUpdate.Enabled = False
        btnCancel.Enabled = False
        btnDelete.Enabled = False

        Dim oCal As New clsTimesheet3(ModId)

        Dim sDate As String = ddYear.SelectedValue & "-" & ddMonth.SelectedValue & "-" & ddDay.SelectedValue
        Dim sDate2 As String = ddYear2.SelectedValue & "-" & ddMonth2.SelectedValue & "-" & ddDay2.SelectedValue



        If IsDate(sDate) And IsDate(sDate2) Then
            If (CType(sDate, Date) <= CType(sDate2, Date)) Then
                If CalId = 0 Then
                    Dim none As Integer = oCal.AddAppointment3(Server.HtmlEncode(txtSubject.Text), Server.HtmlEncode(txtText.Text), ddLabel.SelectedValue, sDate, sDate2, "00:00", "23:59", ddUsers.SelectedValue)
                Else
                    Dim none As Integer = oCal.UpdateAppointment3(CalId, Server.HtmlEncode(txtSubject.Text), Server.HtmlEncode(txtText.Text), ddLabel.SelectedValue, sDate, sDate2, "00:00", "23:59", ddUsers.SelectedValue)
                End If
                Dim sUrl As String = Request.Url.ToString
                If sUrl.IndexOf("Desktop/Modules/Timesheet3/Appointment3.aspx") > 0 Then
                    Dim strParentUrl As String = Left(sUrl, InStr(sUrl, "Desktop/Modules/Timesheet3/Appointment3.aspx") - 1) & "iCM.aspx?PageId=" & PageId
                    ViewState.Item("iCMServer.Modules.Timesheet3.SelectedDay" & ModId) = sDate
                    Response.Write("<SCRIPT LANGUAGE=javaScript>window.opener.location.href='" & strParentUrl & "'; this.close();</script>")
                End If
            Else
                lblError.Visible = True
                lblError2.Visible = True
            End If

        Else
            If IsDate(sDate) Then
                lblError2.Visible = True
            Else
                lblError.Visible = True
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oCal As New clsTimesheet3(ModId)
        Dim sDate As String = ddYear.SelectedValue & "-" & ddMonth.SelectedValue & "-" & ddDay.SelectedValue
        Dim none As Integer = oCal.DeleteAppointment3(CalId)
        Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/timesheet3/appointment3.aspx") - 1) & "iCM.aspx?PageId=" & PageId
        ViewState.Item("iCMServer.Modules.Timesheet3.SelectedDay" & ModId) = sDate
        Response.Write("<SCRIPT LANGUAGE=javaScript>window.opener.location.href='" & strParentUrl & "'; this.close();</script>")
    End Sub

End Class
