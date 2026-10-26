Imports System.Web
Imports System.Data
Imports System.Collections

Public Class Calendar : Inherits clsSiteModuleControl

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
    Protected SimpleViewState As Boolean = False
    Protected SimpleViewAltText As String = ""
    Protected WithEvents chkSimpleViewState As System.Web.UI.WebControls.CheckBox

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
        SelectedDay = Session.Item("iCMServer.Modules.Calendar.SelectedDay")

        Call SetCulture()

        If clsSiteSecurity.HasEditPermissions(ModuleId) Then
            IsAuthorized = True
        End If

        'If Not Page.IsPostBack Then
        Call BindData()
        'End If

        IsFirstDay = False

        Dim scriptString As String
        scriptString = "<script language=JavaScript> function OPENEDIT(CalId) {window.open('Desktop/Modules/Calendar/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CalId='+CalId,'Appointment','width=600,height=400')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("EDITSCRIPT")) Then
            Page.RegisterClientScriptBlock("EDITSCRIPT", scriptString)
        End If
        scriptString = "<script language=JavaScript> function OPENNEW(date) {window.open('Desktop/Modules/Calendar/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate='+date,'Appointment','width=600,height=400')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNEWSCRIPT")) Then
            Page.RegisterClientScriptBlock("OPENNEWSCRIPT", scriptString)
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
        chkSimpleViewState.Text = Server.HtmlDecode(oLang.Find(al, "calendar_simpleviewstate"))
        chkSimpleViewState.ForeColor = Drawing.Color.Black
        chkSimpleViewState.Visible = clsSiteSecurity.HasEditPermissions(ModuleId)

        lnkNew.Visible = IsAuthorized

        If Not Page.IsPostBack Then
            ' Read the SimpleViewState from ModuleConfiguration.EditSrc....
            Try
                SimpleViewState = CType(ModuleConfiguration.EditSrc, Boolean)
                chkSimpleViewState.Checked = SimpleViewState
            Catch ex As Exception
                SimpleViewState = False
                chkSimpleViewState.Checked = False
            End Try
        Else
            SimpleViewState = chkSimpleViewState.Checked
            chkSimpleViewState.Checked = chkSimpleViewState.Checked
        End If

        'Response.Write("chkSimpleViewState = " & Request.Params("chkSimpleViewState"))

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

        If Not IsNothing(Session.Item("iCMServer.Modules.Calendar.SelectedStyle" & ModuleId)) Then
            If Session.Item("iCMServer.Modules.Calendar.SelectedStyle" & ModuleId) = "1" Then
                ' markera hela veckan 
                Select Case cal.SelectedDate.DayOfWeek
                    Case DayOfWeek.Monday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -1, 0))
                    Case DayOfWeek.Tuesday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -2, -1))
                    Case DayOfWeek.Wednesday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -3, -2))
                    Case DayOfWeek.Thursday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -4, -3))
                    Case DayOfWeek.Friday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -5, -4))
                    Case DayOfWeek.Saturday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -6, -5))
                    Case DayOfWeek.Saturday : cal.SelectedDate = cal.SelectedDate.AddDays(IIf(Server.HtmlDecode(oLang.Find(al, "calendar_lang")) = "english", -7, -6))
                End Select
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(1))
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(2))
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(3))
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(4))
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(5))
                cal.SelectedDates.Add(cal.SelectedDate.AddDays(6))
            End If
        End If

        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
        Session.Item("iCMServer.Modules.Calendar.SelectedDay") = cal.SelectedDate

    End Sub

    Private Sub chkSimpleViewState_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSimpleViewState.CheckedChanged
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        SimpleViewState = chkSimpleViewState.Checked
        Dim oCal As New clsCalendar(ModuleId)
        If Not oCal.UpdateModuleViewState(oSite.ActivePage.PageId, ModuleId, SimpleViewState) Then

        End If
        Response.Redirect("~/icm.aspx?PageId=" & oSite.ActivePage.PageId & "&ExpId=" & ModuleId)
    End Sub

    Private Sub lnkNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNew.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Calendar/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub imgNewAppointment_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNewAppointment.Click
        Response.Write("<SCRIPT LANGUAGE=javaScript>var Appointment = window.open('Desktop/Modules/Calendar/Appointment.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&SelectedDate=" & cal.SelectedDate & "','Appointment','width=600,height=400')</SCRIPT>")
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
    End Sub

    Private Sub cal_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cal.SelectionChanged
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
        Session.Item("iCMServer.Modules.Calendar.SelectedDay") = cal.SelectedDate
        Session.Item("iCMServer.Modules.Calendar.SelectedStyle" & ModuleId) = IIf(cal.SelectedDates.Count > 1, "1", "0")
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
            Dim View As String = IIf(SimpleViewState, "Work", "Default") '"Default" '"Work" '"Default"

            If SelectedDates > 1 Then
                oCal.MaxAppointmentInView = 4
            Else
                oCal.MaxAppointmentInView = 8
            End If

            oCal.IsAuthorized = IsAuthorized

            TimeHolder.Controls.Clear()
            CalendarHolder.Controls.Clear()
            BarHolder.Controls.Clear()

            ' Loop the dsCalendar Tables (TimeSpan, Appointments, etc)...
            dsCalendar = oCal.GetCalendarField(SelectedDate, True, SelectedDates, View)
            For Each dt In dsCalendar.Tables
                TimeSpan = New System.Web.UI.WebControls.Literal
                TimeSpan.EnableViewState = True
                If FirstTable Then
                    For Each dr In dt.Rows
                        TimeSpan.Text += dr("value") & vbCrLf
                    Next
                    TimeHolder.Controls.Add(TimeSpan)
                    FirstTable = False
                Else
                    For Each dr In dt.Rows
                        TimeSpan.Text += dr("value") & vbCrLf
                    Next
                    CalendarHolder.Controls.Add(TimeSpan)
                End If
            Next

            ' Loop the rest of the dsCalendar Tables (Appointments)...
            For i = 1 To SelectedDates - 1
                dsCalendar = oCal.GetCalendarField(SelectedDate.AddDays(i), False, SelectedDates, View)
                For Each dt In dsCalendar.Tables
                    TimeSpan = New System.Web.UI.WebControls.Literal
                    For Each dr In dt.Rows
                        TimeSpan.Text += dr("value") & vbCrLf
                    Next
                    CalendarHolder.Controls.Add(TimeSpan)
                Next
            Next

            ' Create the Header For The Calendar Based On The Selected Date...
            Header = New System.Web.UI.WebControls.Literal
            Header.EnableViewState = True
            Header.Text += "<TABLE cellSpacing=""0"" cellPadding=""0"" align=""left"" border=""0""><TR height=""20""><TD width=""62"" bgColor=""#ffffff"">&nbsp;</TD></TR></TABLE>"
            Header.Text += oCal.GetCalendarHeader(SelectedDate, SelectedDates)
            BarHolder.Controls.Add(Header)

        Catch ex As Exception
            Response.Write("<script>alert('" & ex.ToString & "');</script>")
        End Try
    End Sub

    Private Sub cal_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles cal.VisibleMonthChanged
        LoadCalendar(cal.SelectedDate, cal.SelectedDates.Count)
        Session.Item("iCMServer.Modules.Calendar.SelectedDay") = cal.SelectedDate
        Session.Item("iCMServer.Modules.Calendar.SelectedStyle" & ModuleId) = IIf(cal.SelectedDates.Count > 1, "1", "0")
    End Sub

    Private Sub cal_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal.DayRender
        If Not IsFirstDay Then
            If Not e.Day.IsOtherMonth Then
                Dim oCal As New clsCalendar(ModuleId)
                AllDays = oCal.GetAllAppointmentsInMonth(e.Day.Date.Year.ToString & "-" & Format(e.Day.Date.Month, "00") & "-01", e.Day.Date.Year.ToString & "-" & Format(e.Day.Date.Month, "00") & "-" & Format(e.Day.Date.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month), "00"))
                IsFirstDay = True
            End If
        Else
            For Each dr As DataRow In AllDays.Tables(0).Rows
                If CType(dr("cal_starttime"), Date).Day = e.Day.Date.Day Then
                    e.Cell.Font.Bold = True
                    Exit For
                End If
            Next
        End If
    End Sub

End Class
