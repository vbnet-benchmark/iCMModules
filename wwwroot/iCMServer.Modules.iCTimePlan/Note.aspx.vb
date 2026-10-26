Imports System.Data
Imports System.Web.UI.WebControls

Public Class Note
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents txtText As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLabel As System.Web.UI.WebControls.Label
    Protected WithEvents ddLabel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTripCode As System.Web.UI.WebControls.DropDownList

    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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

    Private CalId As Integer = 0
    Protected ModId As Integer = 0
    Private usr_id As Integer = 0
    Private s_id As Integer = 0

    Private PageId As Integer = 0
    Private SelectedDate As String = ""
    Private oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
        Response.Write("<link rel='stylesheet' type='text/css' href='Desktop\Modules\iCTimePlan\iCTimePlan.css'></link>")

        If Not (Request.Params("CalId") Is Nothing) Then
            CalId = Int32.Parse(Request.Params("CalId"))
        End If

        If Not (Request.Params("ModId") Is Nothing) Then
            ModId = Int32.Parse(Request.Params("ModId"))
        End If

        If Not (Request.Params("usr_id") Is Nothing) Then
            usr_id = Int32.Parse(Request.Params("usr_id"))
        End If

        If Not (Request.Params("s_id") Is Nothing) Then
            s_id = Int32.Parse(Request.Params("s_id"))
        End If

        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = Int32.Parse(Request.Params("PageId"))
        End If

        If Not (Request.Params("SelectedDate") Is Nothing) Then
            SelectedDate = Request.Params("SelectedDate")
        End If

        If Not Page.IsPostBack Then
            Call BindData()
            Call BindData2()
        End If

    End Sub


    Private Sub BindData2()
        Dim ds As New DataSet
        Dim oTime As New clsiCTimePlan(ModId)
        ds = oTime.getTripCode()

        'ddlTripCode.Items.Add("")
        'ddlTripCode.DataTextField = "trp_code"
        'ddlTripCode.DataValueField = "trp_id"
        'ddlTripCode.DataSource = ds
        'ddlTripCode.DataBind()

        Dim myRow As DataRow

        For Each myRow In ds.Tables(0).Rows
            ddlTripCode.Items.Add(New ListItem(myRow("cod_code"), myRow("cod_id") & ";" & myRow("cod_startTimeAm") & ";" & myRow("cod_breakTimeAm") & ";" & myRow("cod_endTimeAm")))
        Next

        Dim dsNote As New DataSet
        dsNote = oTime.getNote(Me.SelectedDate, Me.usr_id)

        If dsNote.Tables(0).Rows.Count > 0 Then
            txtText.Text = dsNote.Tables(0).Rows(0)("rep_note")
        Else
            txtText.Text = ""
        End If
       
    End Sub

    Private Sub BindData()

        Dim oLang As New clsLanguageText
        Dim al As New System.Collections.ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")

        lblHeader.Text = IIf(CalId = 0, Server.HtmlDecode(oLang.Find(al, "calendar_newapp")), Server.HtmlDecode(oLang.Find(al, "calendar_newedit"))) '"Appointment" 'Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))'"Appointment" 'Server.HtmlDecode(oLang.Find(al, "calendar_newedit"))
        'lblSubject.Text = Server.HtmlDecode(oLang.Find(al, "calendar_subject")) & "&nbsp;"
        lblText.Text = Server.HtmlDecode(oLang.Find(al, "calendar_text")) & "&nbsp;"
        'lblStartTime.Text = Server.HtmlDecode(oLang.Find(al, "calendar_datefrom")) & "&nbsp;"
        'lblEndTime.Text = Server.HtmlDecode(oLang.Find(al, "calendar_dateto")) & "&nbsp;"
        'lblStart.Text = Server.HtmlDecode(oLang.Find(al, "calendar_start")) & "&nbsp;"
        'lblEnd.Text = Server.HtmlDecode(oLang.Find(al, "calendar_end")) & "&nbsp;"
        lblLabel.Text = Server.HtmlDecode(oLang.Find(al, "calendar_label")) & "&nbsp;"
        btnUpdate.Text = Server.HtmlDecode(oLang.Find(al, "calendar_update"))
        btnCancel.Text = Server.HtmlDecode(oLang.Find(al, "calendar_cancel"))
        btnDelete.Text = Server.HtmlDecode(oLang.Find(al, "calendar_delete"))
        'lblError.Text = Server.HtmlDecode(oLang.Find(al, "calendar_errordate"))
        'lblError.Visible = False 'calendar_text
        'lblError2.Text = Server.HtmlDecode(oLang.Find(al, "calendar_errordate"))
        'lblError2.Visible = False 'calendar_text

        Dim sConfirm As String = Server.HtmlDecode(oLang.Find(al, "calendar_confirmdelete"))
        btnDelete.Attributes.Add("onclick", "return confirm('" & sConfirm & "');")

        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_none")), "#FFFFFF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_important")), "#FF9999"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_business")), "#6699CC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_personal")), "#99CC66"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_vacation")), "#CCCCCC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_mustattend")), "#FF9966"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_travelrequired")), "#99FFFF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_needspreperation")), "#CCCC99"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_birthday")), "#CC99FF"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_anniversary")), "#99CCCC"))
        ddLabel.Items.Add(New ListItem(Server.HtmlDecode(oLang.Find(al, "calendar_label_phonecall")), "#FFCC66"))
        ddLabel.SelectedValue = "#FFFFFF"

        If CalId = 0 Then
            If IsDate(SelectedDate) Then
                Call RenderDateBoxes(SelectedDate)
                Try
                    'ddYear.SelectedValue = CType(SelectedDate, Date).Year.ToString
                    'ddMonth.SelectedValue = Format(CType(SelectedDate, Date).Month, "00")
                    'ddDay.SelectedValue = Format(CType(SelectedDate, Date).Day, "00")
                    'ddYear2.SelectedValue = CType(SelectedDate, Date).Year.ToString
                    'ddMonth2.SelectedValue = Format(CType(SelectedDate, Date).Month, "00")
                    'ddDay2.SelectedValue = Format(CType(SelectedDate, Date).Day, "00")
                Catch ex As Exception
                    'ddYear.SelectedValue = CType(Now, Date).Year.ToString
                    'ddMonth.SelectedValue = Format(CType(Now, Date).Month, "00")
                    'ddDay.SelectedValue = Format(CType(Now, Date).Day, "00")
                    'ddYear2.SelectedValue = CType(Now, Date).Year.ToString
                    'ddMonth2.SelectedValue = Format(CType(Now, Date).Month, "00")
                    'ddDay2.SelectedValue = Format(CType(Now, Date).Day, "00")
                End Try
            Else
                Call RenderDateBoxes(Now.ToString)
                'ddYear.SelectedValue = Now.Year.ToString
                'ddMonth.SelectedValue = Format(Now.Month, "00")
                'ddDay.SelectedValue = Format(Now.Day, "00")
                'ddYear2.SelectedValue = Now.Year.ToString
                'ddMonth2.SelectedValue = Format(Now.Month, "00")
                'ddDay2.SelectedValue = Format(Now.Day, "00")
            End If
            'Try
            '    If IsDate(SelectedDate) And Not CType(SelectedDate, Date).ToShortTimeString = "00:00:00" Then
            '        'ddStartTime.SelectedValue = Format(CType(SelectedDate, Date).Hour, "00") & ":" & Format(CType(SelectedDate, Date).Minute, "00")
            '        'ddEndTime.SelectedValue = Format(CType(SelectedDate, Date).AddMinutes(30).Hour, "00") & ":" & Format(CType(SelectedDate, Date).AddMinutes(30).Minute, "00")
            '    Else
            '        Dim s1 As String = Now.Hour.ToString & ":00"
            '        Dim s2 As String = Now.Hour.ToString & ":30"
            '        If CType(s1, Date) >= CType("23:30", Date) Then
            '            s1 = "23:30"
            '            s2 = "24:00"
            '        ElseIf Now.ToShortTimeString >= CType(s2, Date) Then
            '            s1 = Now.Hour.ToString & ":30"
            '            s2 = Now.AddHours(1).Hour.ToString & ":00"
            '        End If
            '        'ddStartTime.SelectedValue = s1
            '        'ddEndTime.SelectedValue = s2
            '    End If
            'Catch ex As Exception

            'End Try
        Else
            Dim oCal As New clsCalendar(ModId)
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
            If ds.Tables(0).Rows.Count > 1 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Dim dr2 As DataRow = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)
                Call RenderDateBoxes(dr("cal_starttime"))
                Dim p1 As String = CType(dr("cal_starttime"), Date).ToLongTimeString
                Dim p2 As String = CType(dr2("cal_endtime"), Date).ToLongTimeString
                Subject = dr("cal_subject")
                Text = dr("cal_text")
                sStartYear = CType(dr("cal_starttime"), Date).Year.ToString
                sStartMonth = Format(CType(dr("cal_starttime"), Date).Month, "00")
                sStartDay = Format(CType(dr("cal_starttime"), Date).Day, "00")
                sStartTime = Format(CType(p1, Date).Hour, "00") & ":" & Format(CType(p1, Date).Minute, "00")
                sEndYear = CType(dr2("cal_endtime"), Date).Year.ToString
                sEndMonth = Format(CType(dr2("cal_endtime"), Date).Month, "00")
                sEndDay = Format(CType(dr2("cal_endtime"), Date).Day, "00")
                sEndTime = Format(CType(p2, Date).Hour, "00") & ":" & Format(CType(p2, Date).Minute, "00")
                sLabel = CType(dr("cal_label"), String)
            Else
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Call RenderDateBoxes(dr("cal_starttime"))
                Dim p1 As String = CType(dr("cal_starttime"), Date).ToLongTimeString
                Dim p2 As String = CType(dr("cal_endtime"), Date).ToLongTimeString
                Subject = dr("cal_subject")
                Text = dr("cal_text")
                sStartYear = CType(dr("cal_starttime"), Date).Year.ToString
                sStartMonth = Format(CType(dr("cal_starttime"), Date).Month, "00")
                sStartDay = Format(CType(dr("cal_starttime"), Date).Day, "00")
                sStartTime = Format(CType(p1, Date).Hour, "00") & ":" & Format(CType(p1, Date).Minute, "00")
                sEndYear = CType(dr("cal_starttime"), Date).Year.ToString
                sEndMonth = Format(CType(dr("cal_starttime"), Date).Month, "00")
                sEndDay = Format(CType(dr("cal_starttime"), Date).Day, "00")
                sEndTime = Format(CType(p2, Date).Hour, "00") & ":" & Format(CType(p2, Date).Minute, "00")
                sLabel = CType(dr("cal_label"), String)
            End If

            '    txtSubject.Text = Subject
            txtText.Text = Text
            Try
                'ddYear.SelectedValue = sStartYear
                'ddMonth.SelectedValue = sStartMonth
                'ddDay.SelectedValue = sStartDay
                'ddYear2.SelectedValue = sEndYear
                'ddMonth2.SelectedValue = sEndMonth
                'ddDay2.SelectedValue = sEndDay
                ddLabel.SelectedValue = sLabel
            Catch ex As Exception
                'ddYear.SelectedValue = CType(Now, Date).Year.ToString
                'ddMonth.SelectedValue = Format(CType(Now, Date).Month, "00")
                'ddDay.SelectedValue = Format(CType(Now, Date).Day, "00")
                'ddYear2.SelectedValue = CType(Now, Date).Year.ToString
                'ddMonth2.SelectedValue = Format(CType(Now, Date).Month, "00")
                'ddDay2.SelectedValue = Format(CType(Now, Date).Day, "00")
                ddLabel.SelectedValue = "#FFFFFF"
            End Try

        End If

    End Sub

    Private Sub RenderDateBoxes(ByVal RenderDate As String)
        Try
            'ddYear.Items.Clear()
            'For i As Integer = CType(RenderDate, Date).Year To CType(RenderDate, Date).AddYears(1).Year
            '    ddYear.Items.Add(New ListItem(i.ToString, i.ToString))
            'Next
            'ddMonth.Items.Clear()
            'For i As Integer = CType(RenderDate, Date).Month To 12
            '    ddMonth.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            'Next
            'ddDay.Items.Clear()
            'For i As Integer = CType(RenderDate, Date).Day To CType(RenderDate, Date).DaysInMonth(CType(RenderDate, Date).Year, CType(RenderDate, Date).Month)
            '    ddDay.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            'Next
            'ddYear2.Items.Clear()
            'For i As Integer = CType(RenderDate, Date).Year To CType(RenderDate, Date).AddYears(1).Year
            '    ddYear2.Items.Add(New ListItem(i.ToString, i.ToString))
            'Next
            'ddMonth2.Items.Clear()
            'For i As Integer = 1 To 12
            '    ddMonth2.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            'Next
            'ddDay2.Items.Clear()
            'For i As Integer = 1 To 31 'CType(SelectedDate, Date).DaysInMonth(CType(SelectedDate, Date).Year, CType(SelectedDate, Date).Month)
            '    ddDay2.Items.Add(New ListItem(Format(i, "00"), Format(i, "00")))
            'Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>this.close();</SCRIPT>")
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        '   Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/note.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true"
        Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/note.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true&usr_id=" & usr_id & "&IC=Report&s_id=" & s_id

        'Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/appointment.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true&IC=Report&usr_id=" & usr_id & "&s_id=" & s_id

        Dim oTime As New clsiCTimePlan(ModId)
        Dim id As String

        Response.Write(oTime.SaveNote(SelectedDate, txtText.Text, Me.usr_id))

        Response.Write("<SCRIPT LANGUAGE=javaScript>window.opener.location.href='" & strParentUrl & "'; this.close();</script>")

    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Not Me.usr_id = 0 Then
            'Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/appointment.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true&usr_id=" & usr_id & "&s_id=" & s_id
            'Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/Note.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true&IC=Report&usr_id=" & usr_id & "&s_id=" & s_id

            Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/ictimeplan/note.aspx") - 1) & "iCM.aspx?PageId=" & PageId & "&MonthPlan=true&IC=Report&usr_id=" & usr_id & "&s_id=" & s_id

            Dim oTime As New clsiCTimePlan(ModId)
            Dim s As String
            s = oTime.DeleteNote(SelectedDate, Me.usr_id)
            Response.Write("<SCRIPT LANGUAGE=javaScript>window.opener.location.href='" & strParentUrl & "'; this.close();</script>")
        End If

        'Dim oCal As New clsCalendar(ModId)
        'Dim sDate As String = ddYear.SelectedValue & "-" & ddMonth.SelectedValue & "-" & ddDay.SelectedValue
        'If Not oCal.DeleteAppointment(CalId) Then

        'End If
        'Dim strParentUrl As String = Left(Request.Url.ToString, InStr(LCase(Request.Url.ToString), "desktop/modules/timeline/appointment.aspx") - 1) & "iCM.aspx?PageId=" & PageId
        'ViewState.Item("iCMServer.Modules.Calendar.SelectedDay" & ModId) = sDate
        'Response.Write("<SCRIPT LANGUAGE=javaScript>window.opener.location.href='" & strParentUrl & "'; this.close();</script>")
    End Sub

End Class
