Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.IO
Imports System.Web.HttpRequest



Public Class iCTimePlan : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents cal As System.Web.UI.WebControls.Calendar
    Private Const ENGLISH As Integer = 12
    Private Const SWEDISH As Integer = 24
    Protected WithEvents TimeHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents CalendarHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents imgNewAppointment As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkNew As System.Web.UI.WebControls.LinkButton
    Protected WithEvents BarHolder As System.Web.UI.WebControls.PlaceHolder
      Protected WithEvents pnlTimeReport As System.Web.UI.WebControls.Panel
    Protected WithEvents lblAddCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtTimeCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddStartTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddEndTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSaveCode As System.Web.UI.WebControls.Button
    Protected WithEvents pnlTimeCode As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddBreakTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents pnlMonthPlan As System.Web.UI.WebControls.Panel
    Protected WithEvents cal2 As System.Web.UI.WebControls.Calendar
    Protected WithEvents BarHolder2 As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents TimeHolder2 As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents CalendarHolder2 As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PanelAddddl_User As System.Web.UI.WebControls.Panel
    Protected WithEvents lblFlexTid As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexInsaldo As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexNettoTid As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexTjanst As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexKompTid As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerTidInsaldo As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerTidMerTid As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerTidKontantUttag As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerTidKomptidsUttag As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerTidUtsaldo As System.Web.UI.WebControls.Label
    Protected WithEvents lblSemesterInsaldo As System.Web.UI.WebControls.Label
    Protected WithEvents lblSemesterSemester As System.Web.UI.WebControls.Label
    Protected WithEvents lblSemesterKontantUttag As System.Web.UI.WebControls.Label
    Protected WithEvents lblSemesterAvdrag As System.Web.UI.WebControls.Label
    Protected WithEvents lblSemesterUtsaldo As System.Web.UI.WebControls.Label
    Protected WithEvents lblOvrigtManadsFlex As System.Web.UI.WebControls.Label
    Protected WithEvents lblOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblJour As System.Web.UI.WebControls.Label
    Protected WithEvents lblBil As System.Web.UI.WebControls.Label
    Protected WithEvents lblSa As System.Web.UI.WebControls.Label
    Protected WithEvents lblDayOfToday1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexInsaldoRes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexNettoTidRes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexTjanstRes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexKompTidRes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexUtSaldo As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexUtsaldoRes As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexInsaldoRes2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexNettoTidRes2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexTjanstRes2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexKompTidRes2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFlexUtsaldoRes2 As System.Web.UI.WebControls.Label
    Protected WithEvents dgProjList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkMonthPlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkTimeReport As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkTimeCode As System.Web.UI.WebControls.HyperLink
    Protected WithEvents picICTime As System.Web.UI.WebControls.Image

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected SelectedDay As String
    Private AllDays As DataSet
    Private IsFirstDay As Boolean = False
    Protected IsAuthorized As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim usr_id As Integer
        Dim s_id As Integer

        Minimizer.ID = ModuleId
        SelectedDay = ViewState.Item("iCMServer.Modules.Calendar.SelectedDay" & ModuleId)
        Response.Write("<link rel='stylesheet' type='text/css' href='Desktop\Modules\iCTimePlan\iCTimePlan.css'></link>")

        Call SetCulture()

        lblDayOfToday1.Text = Now.ToLongDateString
        
        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            IsAuthorized = True
        End If

        lnkMonthPlan.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&IC=Plan"
        lnkTimeReport.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&IC=Report"
        lnkTimeCode.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&IC=Code"

        If Not Request("usr_id") = Nothing Or Request("usr_id") = "" Then
            ViewState("usr_id") = Request("usr_id")
        End If

        If Not Request("s_id") = Nothing Or Request("s_id") = "" Then
            ViewState("s_id") = Request("s_id")
        End If

        picICTime.Visible = False

        If Page.IsPostBack Then
            'If Not (Request("_ctl13:ddl_User") Is Nothing) Then    'Utv
            If Not (Request("_ctl15:ddl_User") Is Nothing) Then     'Flee
                Try
                    usr_id = getUser()
                    s_id = ViewState("s_id")
                Catch ex As Exception
                End Try
                Call BindData()
            End If
        Else
            pnlMonthPlan.Visible = False
            pnlTimeReport.Visible = False
            pnlTimeCode.Visible = False

            If Not (Request.Params("IC") Is Nothing) Then
                If Request.Params("IC") = "Plan" Then
                    pnlMonthPlan.Visible = True
                    pnlTimeReport.Visible = False
                    pnlTimeCode.Visible = False
                    cal.Visible = True
                    Call BindDataMonthPlan()
                End If
                If Request.Params("IC") = "Report" Then
                    Try
                        usr_id = getUser()
                        s_id = ViewState("s_id")
                    Catch ex As Exception
                    End Try
                    pnlTimeReport.Visible = True
                    pnlMonthPlan.Visible = False
                    pnlTimeCode.Visible = False
                    Call BindData()
                End If
                If Request.Params("IC") = "Code" Then
                    pnlTimeCode.Visible = True
                    pnlTimeReport.Visible = False
                    pnlMonthPlan.Visible = False
                    Call BindGridData()
                End If
            Else
                picICTime.Visible = True
            End If
        End If

        IsFirstDay = False

        Dim scriptString As String
        scriptString = "<script language=JavaScript> function OPENEDIT" & ModuleId & "(CalId) {window.open('Desktop/Modules/iCTimePlan/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CalId='+CalId,'Appointment','width=600,height=420')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("EDITSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("EDITSCRIPT" & ModuleId, scriptString)
        End If
        scriptString = "<script language=JavaScript> function OPENNEW" & ModuleId & "(date) {window.open('Desktop/Modules/iCTimePlan/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&usr_id=" & usr_id & "&s_id=" & s_id & "&SelectedDate='+date,'Appointment','width=500,height=140')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNEWSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("OPENNEWSCRIPT" & ModuleId, scriptString)
        End If

        scriptString = "<script language=JavaScript> function OPENNOTE" & ModuleId & "(datum, user) {window.open('Desktop/Modules/iCTimePlan/Note.aspx?PageId=" & ModuleConfiguration.PageId & "&X='+datum+'" & "&usr_id=" & usr_id & "&s_id=" & s_id & "&ModId=" & ModuleId & "&SelectedDate='+datum,'Appointment','width=600,height=320')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNOTESCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("OPENNOTESCRIPT" & ModuleId, scriptString)
        End If

    End Sub

    Private Sub SetCulture()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")
        Dim lang As String = Server.HtmlDecode(oLang.Find(al, "calendar_lang"))
        Select Case lang
            Case "english"
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Case "swedish"
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
            Case Else
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        End Select
    End Sub


#Region "Calender 2"

    Private Sub BindDataMonthPlan()

        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        Dim sTemp As String
        Dim sArray() As String
        Dim d As Date

        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")

        imgNewAppointment.AlternateText = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        imgNewAppointment.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        lnkNew.Text = Server.HtmlDecode(oLang.Find(al, "calendar_new"))
        lnkNew.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        lnkNew.Visible = IsAuthorized

        If Not SelectedDay = "" Then
            If IsDate(SelectedDay) Then
                cal2.SelectedDate = CType(SelectedDay, Date).ToLongDateString
            Else
                cal2.SelectedDate = Now.ToLongDateString
            End If
        Else
            cal2.SelectedDate = Now.ToLongDateString
        End If
        sTemp = CType(cal2.SelectedDate, String)
        sArray = sTemp.Split("-")
        d = sArray(0) & "-" & sArray(1) & "-01"
        LoadCalendar2(d, cal2.SelectedDates.Count)
        ViewState.Item("iCMServer.Modules.Calendar.SelectedDay" & ModuleId) = cal2.SelectedDate
    End Sub

    Private Sub cal_SelectionChanged2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cal2.SelectionChanged
        LoadCalendar2(cal2.SelectedDate, cal2.SelectedDates.Count)
     End Sub

    Private Sub LoadCalendar2(ByVal SelectedDate As Date, ByVal SelectedDates As Integer)
        Try
            Dim oCal As New clsCalendar(ModuleId)
            Dim Header As System.Web.UI.WebControls.Literal
            Dim TimeSpan As System.Web.UI.WebControls.Literal
            Dim i As Integer
            Dim dsCalendar As DataSet
            Dim dt As DataTable
            Dim dr As DataRow
            Dim FirstTable As Boolean = True

            If SelectedDates > 1 Then
                oCal.MaxAppointmentInView = 4
            Else
                oCal.MaxAppointmentInView = 8
            End If
            oCal.IsAuthorized = IsAuthorized
            TimeHolder2.Controls.Clear()
            CalendarHolder2.Controls.Clear()
            BarHolder2.Controls.Clear()
            Dim Bar2 As New System.Web.UI.WebControls.Literal
            Bar2.Text = oCal.GetTimelineWeekBar2(CalendarHolder, SelectedDate, SelectedDates)
            TimeHolder2.Controls.Add(Bar2)

        Catch ex As Exception
            Response.Write("<script>alert('" & ex.ToString & "');</script>")
        End Try
        TimeHolder2.Visible = True
        pnlTimeReport.Visible = False
        pnlMonthPlan.Visible = True
        pnlTimeCode.Visible = False

    End Sub

    Private Sub cal_VisibleMonthChanged2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal2.VisibleMonthChanged
        Dim sTemp As String
        Dim sArray() As String
        Dim d As Date
        sTemp = CType(cal2.SelectedDate, String)
        sArray = sTemp.Split("-")
        d = sArray(0) & "-" & e.NewDate.Month & "-01"
        LoadCalendar2(d, cal2.SelectedDates.Count)
        pnlTimeReport.Visible = False
    End Sub

    Private Sub cal_DayRender2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal2.DayRender
        If Not IsFirstDay Then
            If Not e.Day.IsOtherMonth Then
                Dim oCal As New clsCalendar(ModuleId)
                AllDays = oCal.GetAllAppointmentsInMonthTimeline(e.Day.Date.Year.ToString & "-" & Format(e.Day.Date.Month, "00") & "-01")
                IsFirstDay = True
                For Each dr As DataRow In AllDays.Tables(0).Rows
                    If CType(dr("cal_endtime"), Date).Month = e.Day.Date.Month And CType(dr("cal_endtime"), Date).Day = e.Day.Date.Day Then
                        e.Cell.Font.Bold = True
                        Exit For
                    End If
                Next
            End If
        Else
            If Not e.Day.IsOtherMonth Then
                For Each dr As DataRow In AllDays.Tables(0).Rows
                    If CType(dr("cal_endtime"), Date).Month = e.Day.Date.Month And CType(dr("cal_endtime"), Date).Day = e.Day.Date.Day Then
                        e.Cell.Font.Bold = True
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

#End Region

#Region "Calender 1"

    Private Sub BindData()

        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        Dim sTemp As String
        Dim sArray() As String
        Dim d As Date
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")
        imgNewAppointment.AlternateText = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        imgNewAppointment.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        lnkNew.Text = Server.HtmlDecode(oLang.Find(al, "calendar_new"))
        lnkNew.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        lnkNew.Visible = IsAuthorized

        If Not SelectedDay = "" Then
            If IsDate(SelectedDay) Then
                cal.SelectedDate = CType(SelectedDay, Date).ToLongDateString
            Else
                cal.SelectedDate = Now.ToLongDateString
            End If
        Else
            cal.SelectedDate = Now.ToLongDateString
        End If

        sArray = CType(cal.SelectedDate, String).Split("-")
        d = sArray(0) & "-" & sArray(1) & "-01"
        LoadCalendar(d, cal.SelectedDates.Count)
        ViewState.Item("iCMServer.Modules.Calendar.SelectedDay" & ModuleId) = cal.SelectedDate
    End Sub

    Private Sub lnkNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNew.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Timeline/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub imgNewAppointment_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNewAppointment.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Timeline/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub cal_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cal.SelectionChanged
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Function getUser()

        Dim oCal As New clsCalendar(ModuleId)
        Dim ddl_User As New DropDownList
        Dim myRow As DataRow
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim usr_id As Integer
        Dim id As Integer = 1

        dt = oCal.GetAllUsersOnModule()
        ds.Merge(dt)
        ddl_User.Items.Add(New ListItem("* Välj Personal *", 0))
        For Each myRow In ds.Tables(0).Rows
            ddl_User.Items.Add(New ListItem(myRow("usr_name"), id & ";" & myRow("usr_id") & ";" & myRow("usr_jobtime")))
            id = id + 1
        Next
        ddl_User.ID = "ddl_User"
        ddl_User.AutoPostBack = True
        ddl_User.Width = ddl_User.Width.Pixel(130)
        ddl_User.EnableViewState = True

        PanelAddddl_User.Controls.Add(ddl_User)
        Try
            If Page.IsPostBack Then
                Dim sValue As String
                'sValue = Request("_ctl13:ddl_User")
                sValue = Request("_ctl15:ddl_User")
                Dim myArray() As String = Split(sValue, ";")
                ViewState("s_id") = myArray(0)
                ViewState("usr_id") = myArray(1)
                Session("usr_jobtime") = myArray(2)
                usr_id = myArray(1)
            Else
                ddl_User.SelectedIndex = CType(ViewState("s_id"), Integer)
                usr_id = CType(ViewState("usr_id"), Integer)
            End If
        Catch ex As Exception
        End Try
        Return usr_id
    End Function

    Private Sub LoadCalendar(ByVal SelectedDate As Date, ByVal SelectedDates As Integer)
        Dim usr_id As Integer
        usr_id = Viewstate("usr_id")
        Response.Write("usr_id:" & usr_id)
        Try
            Dim oCal As New clsCalendar(ModuleId)
            Dim Header As System.Web.UI.WebControls.Literal
            Dim TimeSpan As System.Web.UI.WebControls.Literal
            Dim i As Integer
            Dim dsCalendar As DataSet
            Dim dt As DataTable
            Dim dr As DataRow
            Dim FirstTable As Boolean = True
            Dim oTime As New clsiCTimePlan(Me.ModuleId)
            'Dim workedHour As Integer = 0
            Dim workedHour As Decimal = 0.0

            Dim jobPercent As Decimal
            Dim jobHour As Long
            Dim totPercent As Decimal
            Dim totSum As Long
            Dim totDif As Decimal
            Dim totPercentSum As Decimal

            lblFlexNettoTidRes.Text = ""
            lblFlexNettoTidRes2.Text = ""
            lblFlexTjanstRes.Text = ""
            lblFlexTjanstRes2.Text = ""

            If SelectedDates > 1 Then
                oCal.MaxAppointmentInView = 4
            Else
                oCal.MaxAppointmentInView = 8
            End If
            oCal.IsAuthorized = IsAuthorized
            TimeHolder.Controls.Clear()
            CalendarHolder.Controls.Clear()
            BarHolder.Controls.Clear()

            Dim Bar As New System.Web.UI.WebControls.Literal
            Bar.Text = oCal.GetTimelineMonthBar(SelectedDate, SelectedDates)
            BarHolder.Controls.Add(Bar)
            Dim Bar2 As New System.Web.UI.WebControls.Literal
            Bar2.Text = oCal.GetTimelineWeekBar(CalendarHolder, SelectedDate, SelectedDates, usr_id)
            TimeHolder.Controls.Add(Bar2)

            workedHour = oCal.m_NettoTime()
            'workedHour = CType(oCal.getNettoTime(), Integer)
            jobPercent = CType(Session("usr_jobtime"), Long)
            Try
                totPercentSum = jobPercent / 100
                jobHour = totPercentSum * 160
            Catch ex As Exception
            End Try
            Try
                If Not workedHour = 0 Then
                    totDif = CType(jobHour, Decimal) / CType(workedHour, Decimal)
                    totPercent = jobPercent / totDif
                    lblFlexNettoTidRes.Text = workedHour
                    lblFlexNettoTidRes2.Text = Left(totPercent, 4) & " %"
                    lblFlexTjanstRes.Text = jobHour
                    lblFlexTjanstRes2.Text = Left(jobPercent, 4) & " %"
                    lblFlexUtsaldoRes.Text = jobHour - workedHour
                End If
            Catch ex As Exception
                lblFlexNettoTidRes.Text = ""
                lblFlexNettoTidRes2.Text = ""
                lblFlexTjanstRes.Text = ""
                lblFlexTjanstRes2.Text = ""
            End Try
        Catch ex As Exception
            Response.Write("<script>alert('" & ex.ToString & "');</script>")
        End Try
        pnlTimeReport.Visible = True

    End Sub

    Private Sub cal_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal.VisibleMonthChanged
        Dim sTemp As String
        Dim sArray() As String
        Dim d As Date
        sTemp = CType(cal.SelectedDate, String)
        sArray = sTemp.Split("-")
        d = sArray(0) & "-" & e.NewDate.Month & "-01"
        LoadCalendar(d, cal.SelectedDates.Count)
        Session("d") = d
        pnlTimeReport.Visible = True
    End Sub

    Private Sub cal_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal.DayRender
        If Not IsFirstDay Then
            If Not e.Day.IsOtherMonth Then
                Dim oCal As New clsCalendar(ModuleId)
                AllDays = oCal.GetAllAppointmentsInMonthTimeline(e.Day.Date.Year.ToString & "-" & Format(e.Day.Date.Month, "00") & "-01")
                IsFirstDay = True
                For Each dr As DataRow In AllDays.Tables(0).Rows
                    If CType(dr("cal_endtime"), Date).Month = e.Day.Date.Month And CType(dr("cal_endtime"), Date).Day = e.Day.Date.Day Then
                        e.Cell.Font.Bold = True
                        Exit For
                    End If
                Next
            End If
        Else
            If Not e.Day.IsOtherMonth Then
                For Each dr As DataRow In AllDays.Tables(0).Rows
                    If CType(dr("cal_endtime"), Date).Month = e.Day.Date.Month And CType(dr("cal_endtime"), Date).Day = e.Day.Date.Day Then
                        e.Cell.Font.Bold = True
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnSaveCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCode.Click
        Dim oTime As New clsiCTimePlan(ModuleId)
        oTime.SaveTimeCode(txtTimeCode.Text, ddStartTime.SelectedValue, ddBreakTime.SelectedValue, ddEndTime.SelectedValue)
        pnlTimeCode.Visible = True
        Call BindGridData()
    End Sub

#End Region

#Region "Time Code"

    Private Sub BindGridData()
        Dim ds As New DataSet
        Dim oTime As New clsiCTimePlan(ModuleId)
        ds = oTime.getTripCode()

        dgProjList.DataSource = ds
        dgProjList.DataBind()

        ViewState("TimeCode") = True

        'dgProjList.Visible = True
        'DataGrid2.DataSource = ds
        'DataGrid2.DataBind()

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                ' dgProjList.DataSource = ds
                ' dgProjList.DataBind()
            End If
        End If

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            'dgProjList.Columns(5).Visible = True
            'dgProjList.Columns(6).Visible = True
            '  btnAddRow.Visible = True
        Else
            'dgProjList.Columns(5).Visible = False
            'dgProjList.Columns(6).Visible = False
            ' btnAddRow.Visible = False
        End If

    End Sub

    Sub dgProjList_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        dgProjList.EditItemIndex = CType(e.Item.ItemIndex, Integer)
        BindGridData()
    End Sub

    Sub dgProjList_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If Not e.Item.FindControl("lblNr") Is Nothing Then

            Dim id As Integer
            Dim oTime As New clsiCTimePlan(ModuleId)
            id = dgProjList.DataKeys(e.Item.ItemIndex)
            If Not oTime.DeleteCodeFromGrid(id) Then
                Response.Write("Not Deleted")
            End If
            dgProjList.EditItemIndex = -1
            BindGridData()
        Else
            ' lblError.Text = "Vänligen avsluta editeringen innan du raderar objekt."
        End If
    End Sub

    Sub dgProjList_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        dgProjList.EditItemIndex = -1
        BindGridData()
    End Sub

    Sub dgProjList_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If Page.IsValid Then
            Dim code As String = CType(CType(e.Item.FindControl("txtCode"), TextBox).Text, String)
            Dim startTimeAM As String = CType(CType(e.Item.FindControl("txtStartTimeAM"), TextBox).Text, String)
            Dim breakTimeAM As String = CType(CType(e.Item.FindControl("txtBreakTimeAM"), TextBox).Text, String)
            Dim endTimeAM As String = CType(CType(e.Item.FindControl("txtEndTimeAM"), TextBox).Text, String)
            Dim id As Integer
            Dim oTime As New clsiCTimePlan(ModuleId)
            id = dgProjList.DataKeys(e.Item.ItemIndex)
            If Not (oTime.UpdateCode(id, code, startTimeAM, breakTimeAM, endTimeAM)) Then
                Response.Write("Something is wron:: Not Updated")
            End If
            dgProjList.EditItemIndex = -1
            BindGridData()

        End If
    End Sub

    'Private Sub btnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
    '    Dim oProjList As New clsiCTimePlan(ModuleId)
    '    '   oProjList.AddRow()
    '    BindGridData()
    'End Sub

#End Region

    Private Sub ddlUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class
