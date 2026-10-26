Imports System.Web
Imports System.Data
Imports System.Collections

Public Class Timesheet : Inherits clsSiteModuleControl

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
        Minimizer.ID = ModuleId
        SelectedDay = ViewState.Item("iCMServer.Modules.Timesheet.SelectedDay" & ModuleId)

        Call SetCulture()

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            IsAuthorized = True
        End If

        'If Not Page.IsPostBack Then
        Call BindData()
        'End If

        IsFirstDay = False

        Dim scriptString As String
        scriptString = "<script language=JavaScript> function OPENEDIT" & ModuleId & "(CalId) {window.open('Desktop/Modules/Timesheet/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CalId='+CalId,'Appointment','width=600,height=420')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("EDITSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("EDITSCRIPT" & ModuleId, scriptString)
        End If
        scriptString = "<script language=JavaScript> function OPENNEW" & ModuleId & "(date) {window.open('Desktop/Modules/Timesheet/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate='+date,'Appointment','width=600,height=420')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNEWSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("OPENNEWSCRIPT" & ModuleId, scriptString)
        End If
        scriptString = "<script language=JavaScript> function OPENNEWX" & ModuleId & "(datum, user) {window.open('Desktop/Modules/Timesheet/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&X='+datum+'" & "&UsrId='+user+'" & "&ModId=" & ModuleId & "&SelectedDate='+datum,'Appointment','width=600,height=420')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNEWXSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("OPENNEWXSCRIPT" & ModuleId, scriptString)
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

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Calendar")

        imgNewAppointment.AlternateText = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        imgNewAppointment.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))
        lnkNew.Text = Server.HtmlDecode(oLang.Find(al, "calendar_new"))
        lnkNew.ToolTip = Server.HtmlDecode(oLang.Find(al, "calendar_newapp"))

        lnkNew.Visible = IsAuthorized

        ' Calendar properties
        If Not SelectedDay = "" Then
            If IsDate(SelectedDay) Then
                cal.SelectedDate = CType(SelectedDay, Date).ToLongDateString
            Else
                cal.SelectedDate = Now.ToLongDateString
            End If
        Else
            cal.SelectedDate = Now.ToLongDateString
        End If

        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)

        ViewState.Item("iCMServer.Modules.Timesheet.SelectedDay" & ModuleId) = cal.SelectedDate

    End Sub

    Private Sub lnkNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNew.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Timesheet/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub imgNewAppointment_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNewAppointment.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Timesheet/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub cal_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cal.SelectionChanged
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
        'ViewState.Item("iCMServer.Modules.Calendar.SelectedDay") = cal.SelectedDate
    End Sub

    Private Sub LoadCalendar(ByVal SelectedDate As Date, ByVal SelectedDates As Integer)
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

            TimeHolder.Controls.Clear()
            CalendarHolder.Controls.Clear()
            BarHolder.Controls.Clear()

            Dim Bar As New System.Web.UI.WebControls.Literal
            Bar.Text = oCal.GetTimesheetMonthBar(SelectedDate, SelectedDates)
            BarHolder.Controls.Add(Bar)
            Dim Bar2 As New System.Web.UI.WebControls.Literal
            Bar2.Text = oCal.GetTimesheetWeekBar(CalendarHolder, SelectedDate, SelectedDates)
            TimeHolder.Controls.Add(Bar2)

        Catch ex As Exception
            Response.Write("<script>alert('" & ex.ToString & "');</script>")
        End Try
    End Sub

    Private Sub cal_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal.VisibleMonthChanged
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
        'ViewState.Item("iCMServer.Modules.Calendar.SelectedDay" & ModuleId) = cal.SelectedDate
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

End Class
