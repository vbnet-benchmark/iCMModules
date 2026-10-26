Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web


Public Class clsCalendar

#Region " Variables "
    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private iModId As Integer = 0
    Private iInnerColumnsCount As Integer = 0
    Private iInnerColumnsWidth As Integer = 0
    Private iMaxAppointmentInView As Integer = 10
    Private m_IsAuthorized As Boolean = False


    Private usr_id As Integer
    Private totNettoTime As Decimal

#End Region

#Region " Public Property "
    Public Property MaxAppointmentInView()
        Get
            Return iMaxAppointmentInView
        End Get
        Set(ByVal Value)
            Me.iMaxAppointmentInView = Value
        End Set
    End Property

    Public Property IsAuthorized() As Boolean
        Get
            Return m_IsAuthorized
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsAuthorized = Value
        End Set
    End Property

    Public ReadOnly Property m_NettoTime() As Decimal
        Get
            Return totNettoTime
        End Get
    End Property

#End Region


#Region " Public Functions "

    Public Sub New(ByVal ModId As Integer)
        Me.iModId = ModId
    End Sub

    Public Function AddAppointment(ByVal Parent As Integer, ByVal Subject As String, ByVal Text As String, ByVal Label As String, ByVal StartDate As String, ByVal EndDate As String, ByVal StartTime As String, ByVal EndTime As String) As Integer
        Dim ds As New DataSet
        Try
            Dim sStartDate As String = StartDate & " " & StartTime
            'Dim sEndDate As String = StartDate & " " & EndTime 'CType(EndTime, Date).AddMinutes(-30).ToShortTimeString
            Dim sEndDate As String = EndDate & " " & EndTime 'CType(EndTime, Date).AddMinutes(-30).ToShortTimeString
            If CType(sStartDate, Date) = CType(sEndDate, Date) Or CType(sStartDate, Date) > CType(sEndDate, Date) Then
                sEndDate = CType(sStartDate, Date).AddMinutes(30).ToString
            End If
            If Not oDO.GetEmptyDataSet("cal_calendar", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = oSite.ActivePage.PageId
                .Item("mod_id") = iModId
                .Item("cal_subject") = Subject
                .Item("cal_text") = Text
                .Item("cal_starttime") = sStartDate
                .Item("cal_endtime") = sEndDate
                .Item("cal_allday") = IIf(Parent > 0, Parent, 0)
                .Item("cal_reminder") = 0
                .Item("cal_reminderlimit") = Now.ToLongDateString
                .Item("cal_attendees") = ""
                .Item("cal_label") = Label
                .Item("cal_createddate") = Now.ToLongDateString
                .Item("cal_createdby") = HttpContext.Current.User.Identity.Name
                .Item("cal_updateddate") = Now.ToLongDateString
                .Item("cal_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("cal_hidden") = 0
                .Item("cal_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return ds.Tables(0).Rows(0)("cal_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateAppointment(ByVal Parent As Integer, ByVal CalId As Integer, ByVal Subject As String, ByVal Text As String, ByVal Label As String, ByVal StartDate As String, ByVal EndDate As String, ByVal StartTime As String, ByVal EndTime As String) As Integer
        Dim ds As New DataSet
        Try
            Dim sStartDate As String = StartDate & " " & StartTime
            'Dim sEndDate As String = StartDate & " " & EndTime 'CType(EndTime, Date).AddMinutes(-30).ToShortTimeString
            Dim sEndDate As String = EndDate & " " & EndTime 'CType(EndTime, Date).AddMinutes(-30).ToShortTimeString
            If CType(sStartDate, Date) = CType(sEndDate, Date) Or CType(sStartDate, Date) > CType(sEndDate, Date) Then
                sEndDate = CType(sStartDate, Date).AddMinutes(30).ToString
            End If
            If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_id = " & CalId, "", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("cal_subject") = Subject
                .Item("cal_text") = Text
                .Item("cal_starttime") = sStartDate
                .Item("cal_endtime") = sEndDate
                .Item("cal_allday") = IIf(Parent > 0, Parent, 0)
                .Item("cal_label") = Label
                .Item("cal_updateddate") = Now.ToLongDateString
                .Item("cal_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return ds.Tables(0).Rows(0)("cal_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetAppointment(ByVal CalId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_id = " & CalId & " OR sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_allday = " & CalId, "cal_id", "", ED, EC, ds) Then

            End If
            If Not ds.Tables(0).Rows(0)("cal_allday") = 0 Then
                Dim Parent As Integer = ds.Tables(0).Rows(0)("cal_allday")
                ds = New DataSet
                If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_id = " & Parent & " OR sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_allday = " & Parent, "cal_id", "", ED, EC, ds) Then

                End If
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteAppointment(ByVal CalId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_id = " & CalId & " OR sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_allday = " & CalId, "cal_id", "", ED, EC, ds) Then

            End If
            If Not ds.Tables(0).Rows(0)("cal_allday") = 0 Then
                Dim Parent As Integer = ds.Tables(0).Rows(0)("cal_allday")
                ds = New DataSet
                If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_id = " & Parent & " OR sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_allday = " & Parent, "cal_id", "", ED, EC, ds) Then

                End If
            End If
            If oSite.SiteSoftDelete Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    dr("cal_deleted") = 0
                Next
            Else
                For Each dr As DataRow In ds.Tables(0).Rows
                    dr.Delete()
                Next
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllAppointmentsInMonth(ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("cal_starttime")
            If Not oDO.GetDefinedDataSet("cal_calendar", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_starttime >= '" & StartDate & "' AND cal_endtime <= '" & EndDate & "' AND cal_hidden = 0 AND cal_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

#End Region

#Region " Private Functions "

#End Region

#Region " Public Render Functions "

    Public Function GetCalendarHeader(ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        Dim sTemp As String
        Dim CenterText As String
        Dim LeftText As String
        Dim RightText As String
        Dim sWidth As String
        Dim i As Integer

        Dim EmptyTable As String = _
                "<table id=""TimeSpan"" bgcolor=""#ffffff"" width=""" & Me.iInnerColumnsWidth.ToString & "%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"">" & _
                "  <tr height=20>" & _
                "    <td style=""WIDTH: 1px"" nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font>" & _
                "    </td>" & _
                "    <td align=""center""  nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font>" & _
                "    </td>" & _
                "  </tr>" & _
                "</table>"

        Dim CenterTable As String = _
                "<table id=""TimeSpan"" bgcolor=""#ffffff"" width=""" & Me.iInnerColumnsWidth.ToString & "%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"">" & _
                "  <tr height=20>" & _
                "    <td style=""WIDTH: 1px"" nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font>" & _
                "    </td>" & _
                "    <td align=""center""  nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">#CENTERTEXT#</font>" & _
                "    </td>" & _
                "  </tr>" & _
                "</table>"

        Dim SplitTable As String = _
                "<table id=""TimeSpan"" bgcolor=""#ffffff"" width=""" & Me.iInnerColumnsWidth.ToString & "%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"">" & _
                "  <tr height=20>" & _
                "    <td style=""WIDTH: 1px"" nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font>" & _
                "    </td>" & _
                "    <td align=""right""  nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">#LEFTTEXT#</font>" & _
                "    </td>" & _
                "  </tr>" & _
                "</table>" & _
                "<table id=""TimeSpan"" bgcolor=""#ffffff"" width=""" & Me.iInnerColumnsWidth.ToString & "%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"">" & _
                "  <tr height=20>" & _
                "    <td style=""WIDTH: 1px"" nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font>" & _
                "    </td>" & _
                "    <td align=""left""  nowrap>" & _
                "      <font color=""#000000"" style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">#RIGHTTEXT#</font>" & _
                "    </td>" & _
                "  </tr>" & _
                "</table>"

        CenterText = SelectedDate.Day.ToString & " " & Format(SelectedDate, "MMM")
        LeftText = SelectedDate.Day.ToString & " "
        RightText = Format(SelectedDate, "MMM")

        For i = 1 To SelectedDates

            Select Case Me.iInnerColumnsCount
                Case 1
                    sTemp += Replace(CenterTable, "#CENTERTEXT#", CenterText)
                Case 2
                    sTemp += Replace(Replace(SplitTable, "#LEFTTEXT#", LeftText), "#RIGHTTEXT#", RightText)
                Case 3
                    sTemp += EmptyTable
                    sTemp += Replace(CenterTable, "#CENTERTEXT#", CenterText)
                    sTemp += EmptyTable
                Case 4
                    sTemp += EmptyTable
                    sTemp += Replace(Replace(SplitTable, "#LEFTTEXT#", LeftText), "#RIGHTTEXT#", RightText)
                    sTemp += EmptyTable
                Case 5
                    sTemp += EmptyTable & EmptyTable
                    sTemp += Replace(CenterTable, "#CENTERTEXT#", CenterText)
                    sTemp += EmptyTable & EmptyTable
                Case 6
                    sTemp += EmptyTable & EmptyTable
                    sTemp += Replace(Replace(SplitTable, "#LEFTTEXT#", LeftText), "#RIGHTTEXT#", RightText)
                    sTemp += EmptyTable & EmptyTable
                Case 7
                    sTemp += EmptyTable & EmptyTable & EmptyTable
                    sTemp += Replace(CenterTable, "#CENTERTEXT#", CenterText)
                    sTemp += EmptyTable & EmptyTable & EmptyTable
                Case 8
                    sTemp += EmptyTable & EmptyTable & EmptyTable
                    sTemp += Replace(Replace(SplitTable, "#LEFTTEXT#", LeftText), "#RIGHTTEXT#", RightText)
                    sTemp += EmptyTable & EmptyTable & EmptyTable
                Case 9
                    sTemp += EmptyTable & EmptyTable & EmptyTable & EmptyTable
                    sTemp += Replace(CenterTable, "#CENTERTEXT#", CenterText)
                    sTemp += EmptyTable & EmptyTable & EmptyTable & EmptyTable
                Case 10
                    sTemp += EmptyTable & EmptyTable & EmptyTable & EmptyTable
                    sTemp += Replace(Replace(SplitTable, "#LEFTTEXT#", LeftText), "#RIGHTTEXT#", RightText)
                    sTemp += EmptyTable & EmptyTable & EmptyTable & EmptyTable
            End Select

            CenterText = SelectedDate.AddDays(i).Day.ToString & " " & Format(SelectedDate.AddDays(i), "MMM")
            LeftText = SelectedDate.AddDays(i).Day.ToString & " "
            RightText = Format(SelectedDate.AddDays(i), "MMM")

        Next
        Return sTemp
    End Function

    Public Function GetCalendarField(ByVal SelectedDate As Date, ByVal DoTimeSpan As Boolean, ByVal TotalColumns As Integer) As DataSet
        Dim dsTimeSpan As New DataSet
        Dim dsAppointments As New DataSet
        Dim dsGeneric As New DataSet
        Dim dsTempTables As New DataSet
        Dim dsCalendar As New DataSet
        Dim TotAllDayApp As Integer

        ' Get the current timespan for this view (ex. 00:00, 00:30, 01:00)
        dsTimeSpan = GetTimeSpan("Default")

        ' Get all appointments for this day from database
        dsAppointments = GetAppointments(SelectedDate)

        ' Get the total amount of allday appointments
        TotAllDayApp = GetTotalAmountOfAlldayAppointment(dsAppointments)

        ' Create all generic tables, like: TimeSpan, Allday field etc...
        If DoTimeSpan Then
            dsGeneric = CreateGenericTables(TotAllDayApp, dsTimeSpan)
        End If

        ' Build temporary day tables, (the day can be slitted up in several tables depending on 
        ' how many appointments that accure at the same time)
        dsTempTables = BuildTempTables(SelectedDate, dsAppointments, dsTimeSpan)
        If dsTempTables.Tables.Count < 1 Then dsTempTables = BuildEmptyTempTable(dsTimeSpan)

        ' Create the Calendar Dataset with all the required information in it.
        dsCalendar = CreateFinal(SelectedDate, dsGeneric, dsTempTables, TotAllDayApp, DoTimeSpan, TotalColumns)

        ' Clean
        dsTimeSpan.Dispose()
        dsAppointments.Dispose()
        dsGeneric.Dispose()
        dsTempTables.Dispose()

        Return dsCalendar

    End Function

#End Region

#Region " Private Render Functions "

    Private Function BuildEmptyTempTable(ByVal dsTimeSpan As DataSet) As DataSet
        Dim dsTempTables As New DataSet
        Dim dtIns As New DataTable
        dtIns.Columns.Add("time")
        dtIns.Columns.Add("cal_id")
        dtIns.Columns.Add("cal_subject")
        dtIns.Columns.Add("cal_label")
        dtIns.Columns.Add("start")
        dtIns.Columns.Add("end")
        dtIns.Columns.Add("spanstart")
        dtIns.Columns.Add("spanin")
        dtIns.Columns.Add("spanend")

        Dim drTS As DataRow
        For Each drTS In dsTimeSpan.Tables("Default").Rows

            Dim drIns As DataRow = dtIns.NewRow

            drIns("time") = drTS("time")
            drIns("cal_id") = "0"
            drIns("cal_subject") = ""
            drIns("cal_label") = "#ffffff"
            drIns("start") = "0"
            drIns("end") = "0"
            drIns("spanstart") = "0"
            drIns("spanin") = "0"
            drIns("spanend") = "0"

            dtIns.Rows.Add(drIns)
        Next
        dsTempTables.Tables.Add(dtIns)
        Return dsTempTables
    End Function

    Private Function CreateFinal(ByVal SelectedDate As Date, ByVal dsGeneric As DataSet, ByVal dsTempTables As DataSet, ByVal TotAllDayApp As Integer, ByVal DoTimeSpan As Boolean, ByVal TotalColumns As Integer) As DataSet
        Dim dsFinal As New DataSet
        Dim dtFinal As DataTable
        Dim IsFirst As Boolean = True
        Dim dtTmp As DataTable
        Dim iCount As Integer
        Dim iSize As Integer = ((CALENDAR_CALCULATE_CONSTANT / dsTempTables.Tables.Count) / TotalColumns)
        Me.iInnerColumnsCount = dsTempTables.Tables.Count
        Me.iInnerColumnsWidth = iSize

        ' Add the Generic Tables...
        If DoTimeSpan Then
            dtFinal = New DataTable("TimeSpan")
            dtFinal = dsGeneric.Tables("TimeSpan").Copy
            dsFinal.Tables.Add(dtFinal)
        End If

        ' Add all tables from dsTempTables with Appointment data
        For Each dtTmp In dsTempTables.Tables
            If iCount >= Me.MaxAppointmentInView Then Exit For
            dtFinal = New DataTable("AppointmentRow")
            dtFinal = GetAppointmentTable(SelectedDate, iSize, iCount, IsFirst, TotAllDayApp, dtTmp)
            dsFinal.Tables.Add(dtFinal)
            IsFirst = False
            iCount += 1
        Next

        Return dsFinal
    End Function

    Private Function GetAppointmentTable(ByVal SelectedDate As Date, ByVal Size As Integer, ByVal iCount As Integer, ByVal IsFirst As Boolean, ByVal TotAllDayApp As Integer, ByVal dtSource As DataTable) As DataTable
        ' This function builds a <table> object for a appointment row.
        Dim dtApp As New DataTable
        Dim drApp As DataRow
        Dim dr As DataRow
        dtApp.Columns.Add("value")

        ' Create the start <table> tag
        drApp = dtApp.NewRow : drApp("value") = "<table id='Appointment" & iCount.ToString & "' width='" & Size.ToString & "%' border='0' cellSpacing='0' cellPadding='0' align='left'>" : dtApp.Rows.Add(drApp)

        ' Create the header code...
        drApp = dtApp.NewRow : drApp("value") = GetAppointmentRowHeaderString(TotAllDayApp + 1) : dtApp.Rows.Add(drApp)

        ' Loop the dtSource table
        For Each dr In dtSource.Rows
            drApp = dtApp.NewRow
            drApp("value") = IIf(Right(dr("time"), 2) = "00", GetAppointmentRowHourString(SelectedDate, dr("time"), IsFirst, dr("cal_id"), dr("cal_subject"), dr("start"), dr("end"), dr("spanstart"), dr("spanin"), dr("spanend"), Size, dr("cal_label")), GetAppointmentRowDelimeterString(SelectedDate, dr("time"), IsFirst, dr("cal_id"), dr("cal_subject"), dr("start"), dr("end"), dr("spanstart"), dr("spanin"), dr("spanend"), Size, dr("cal_label")))
            dtApp.Rows.Add(drApp)
        Next

        ' Create the end </table> tag
        drApp = dtApp.NewRow : drApp("value") = "</table>" : dtApp.Rows.Add(drApp)

        Return dtApp

    End Function

    Private Function IsThereRoom(ByVal Time As Date, ByVal dtTempTable As DataTable) As Boolean
        Dim dr As DataRow
        For Each dr In dtTempTable.Rows
            If CType(dr("time"), Date).ToShortTimeString = Time.ToShortTimeString And Not dr("cal_id") = "0" Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function BuildTempTables(ByVal SelectedDate As Date, ByVal dsAppointments As DataSet, ByVal dsTimeSpan As DataSet) As DataSet
        ' In this function we will create a number of temp tables depending on what we have in the dsAppointments Dataset
        ' We have to do this becouse we want to creta a simular view like Outlook.

        Dim dsTempTables As New DataSet
        Dim dtTempTable As DataTable
        Dim dtTmp As DataTable
        Dim drTmp As DataRow

        Dim tmpId As String
        Dim tmpSubject As String
        Dim tmpLabel As String
        Dim tmpStartTime As Date
        Dim tmpEndTime As Date
        Dim tmpInserted As Boolean
        Dim tmpOneTime As Boolean

        ' Loop the Appointments dataset and create new temp tables with the neaded info.
        Dim drAppointment As DataRow
        For Each drAppointment In dsAppointments.Tables(0).Rows

            ' Set tmp local variables for use when inserting into the dsTempTables DataSet
            tmpId = CType(drAppointment("cal_id"), String)                                              ' 1
            tmpSubject = CType(drAppointment("cal_subject"), String)                                    ' Testdata
            tmpLabel = CType(drAppointment("cal_label"), String)                                        ' #ffffff
            tmpStartTime = CType(drAppointment("cal_starttime"), Date).ToShortTimeString                ' 16:00 
            tmpEndTime = CType(drAppointment("cal_endtime"), Date).AddMinutes(-30).ToShortTimeString    ' 17:30
            If tmpEndTime = "23:29" Then tmpEndTime = "23:59"
            tmpInserted = False
            tmpOneTime = False

            ' Lopp throu the dsTempTables Dataset and check if this appointment can be inserted
            For Each dtTmp In dsTempTables.Tables
                If Not IsThereRoom(tmpStartTime, dtTmp) Then
                    tmpOneTime = True
                    For Each drTmp In dtTmp.Rows
                        ' If there is space for the new appointment in one of the allready created tables
                        ' then insert it.

                        Dim revTime As String

                        If drTmp("cal_id") = "0" Then
                            If CType(drTmp("time"), Date) = tmpStartTime And CType(drTmp("time"), Date) = tmpEndTime Then
                                revTime = drTmp("time")
                                drTmp("cal_id") = tmpId.ToString
                                drTmp("cal_subject") = IIf(tmpInserted, "", tmpSubject)
                                drTmp("cal_label") = tmpLabel
                                drTmp("start") = "1"
                                drTmp("end") = "1"
                                drTmp("spanstart") = "0"
                                drTmp("spanin") = "0"
                                drTmp("spanend") = IIf(tmpInserted, "1", "0")
                            ElseIf CType(drTmp("time"), Date) = tmpStartTime Then
                                revTime = drTmp("time")
                                drTmp("cal_id") = tmpId.ToString
                                drTmp("cal_subject") = IIf(tmpInserted, "", tmpSubject)
                                drTmp("cal_label") = tmpLabel
                                drTmp("start") = "1"
                                drTmp("end") = "0"
                                drTmp("spanstart") = "0"
                                drTmp("spanin") = "0"
                                drTmp("spanend") = IIf(tmpInserted, "1", "0")
                            ElseIf CType(drTmp("time"), Date) > tmpStartTime And CType(drTmp("time"), Date) < tmpEndTime Then
                                revTime = drTmp("time")
                                drTmp("cal_id") = tmpId.ToString
                                drTmp("cal_subject") = ""
                                drTmp("cal_label") = tmpLabel
                                drTmp("start") = "0"
                                drTmp("end") = "0"
                                drTmp("spanstart") = "0"
                                drTmp("spanin") = "0"
                                drTmp("spanend") = IIf(tmpInserted, "1", "0")
                            ElseIf CType(drTmp("time"), Date) = tmpEndTime Then
                                revTime = drTmp("time")
                                drTmp("cal_id") = tmpId.ToString
                                drTmp("cal_subject") = ""
                                drTmp("cal_label") = tmpLabel
                                drTmp("start") = "0"
                                drTmp("end") = "1"
                                drTmp("spanstart") = "0"
                                drTmp("spanin") = "0"
                                drTmp("spanend") = IIf(tmpInserted, "1", "0")
                            End If


                            ' Kolla igenom alla tidigare temptabeller om denna post finns i dem
                            ' om den finns revidera spanstart, spanin, spanend.
                            ' 1. Loopa temptabeller
                            ' 2. Kolla om detta tmpId finns på samma tid.
                            ' 3. Om ja, revidera span info.
                            If tmpInserted Then
                                Dim iRev As Integer
                                Dim drRev As DataRow
                                Dim IsFirst As Boolean = True

                                For iRev = 0 To dsTempTables.Tables.Count - 2
                                    For Each drRev In dsTempTables.Tables(iRev).Rows
                                        If revTime = drRev("time") And tmpId = drRev("cal_id") Then
                                            drRev("spanstart") = IIf(IsFirst, "1", "0")
                                            drRev("spanin") = IIf(IsFirst, "0", "1")
                                            drRev("spanend") = "0"
                                            IsFirst = False
                                        End If
                                    Next
                                Next

                            End If
                        End If
                    Next
                    tmpInserted = True
                Else
                    If tmpOneTime Then Exit For
                End If
            Next

            ' If the current appointment is not yet inserted into a table
            ' create a new temp table and add to the dsTempTables DataSet
            If Not tmpInserted Then
                Dim dtIns As New DataTable
                dtIns.Columns.Add("time")
                dtIns.Columns.Add("cal_id")
                dtIns.Columns.Add("cal_subject")
                dtIns.Columns.Add("cal_label")
                dtIns.Columns.Add("start")
                dtIns.Columns.Add("end")
                dtIns.Columns.Add("spanstart")
                dtIns.Columns.Add("spanin")
                dtIns.Columns.Add("spanend")

                Dim drTS As DataRow
                For Each drTS In dsTimeSpan.Tables("Default").Rows

                    Dim drIns As DataRow = dtIns.NewRow

                    drIns("time") = drTS("time")

                    If CType(drTS("time"), Date) = tmpStartTime And CType(drTS("time"), Date) = tmpEndTime Then
                        drIns("cal_id") = tmpId.ToString
                        drIns("cal_subject") = tmpSubject
                        drIns("cal_label") = tmpLabel
                        drIns("start") = "1"
                        drIns("end") = "1"
                    ElseIf CType(drTS("time"), Date) = tmpStartTime Then
                        drIns("cal_id") = tmpId.ToString
                        drIns("cal_subject") = tmpSubject
                        drIns("cal_label") = tmpLabel
                        drIns("start") = "1"
                        drIns("end") = "0"
                    ElseIf CType(drTS("time"), Date) > tmpStartTime And CType(drTS("time"), Date) < tmpEndTime Then
                        drIns("cal_id") = tmpId.ToString
                        drIns("cal_subject") = ""
                        drIns("cal_label") = tmpLabel
                        drIns("start") = "0"
                        drIns("end") = "0"
                    ElseIf CType(drTS("time"), Date) = tmpEndTime Then
                        drIns("cal_id") = tmpId.ToString
                        drIns("cal_subject") = ""
                        drIns("cal_label") = tmpLabel
                        drIns("start") = "0"
                        drIns("end") = "1"
                    Else
                        drIns("cal_id") = "0"
                        drIns("cal_subject") = ""
                        drIns("cal_label") = tmpLabel
                        drIns("start") = "0"
                        drIns("end") = "0"
                    End If

                    drIns("spanstart") = "0"
                    drIns("spanin") = "0"
                    drIns("spanend") = "0"

                    dtIns.Rows.Add(drIns)
                Next
                dsTempTables.Tables.Add(dtIns)
            End If ' Not tmpInserted

        Next ' Each drAppointment In dsAppointments.Tables(0).Rows

        Return dsTempTables

    End Function

    Private Function GetTotalAmountOfAlldayAppointment(ByVal dsAppointments As DataSet) As Integer
        Dim drAppointment As DataRow
        Dim i As Integer = 0

        ' Get the total amount of allday events
        For Each drAppointment In dsAppointments.Tables(0).Rows
            'If CType(drAppointment("cal_allday"), Boolean) = True Then i += 1
        Next

        Return i
    End Function

    Private Function CreateGenericTables(ByVal TotAllDayApp As Integer, ByVal dsTimeSpan As DataSet) As DataSet

        ' Create the TimeSpan Table
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim dtTime As New DataTable("TimeSpan")
        dtTime.Columns.Add("value")
        Dim drTime As DataRow

        ' Create the start <table> tag
        drTime = dtTime.NewRow : drTime("value") = "<table id=""TimeSpan"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"">" : dtTime.Rows.Add(drTime)

        ' Create the header code...
        drTime = dtTime.NewRow : drTime("value") = GetTimeSpanHeaderString(TotAllDayApp + 1) : dtTime.Rows.Add(drTime)

        ' Loop the dsTimeSpan dataset and create the coded TimeSpan dataset
        For Each dr In dsTimeSpan.Tables("Default").Rows
            drTime = dtTime.NewRow
            drTime("value") = IIf(dr("ishour") = "1", GetTimeSpanHourString(dr("time")), GetTimeSpanDelimeterString(dr("time")))
            dtTime.Rows.Add(drTime)
        Next

        ' Create the end </table> tag
        drTime = dtTime.NewRow : drTime("value") = "</table>" : dtTime.Rows.Add(drTime)

        ds.Tables.Add(dtTime)
        Return ds

    End Function

    Private Function GetAppointments(ByVal SelectedDate As Date) As DataSet
        Dim ds As New DataSet
        Try
            Dim StartDate As String = SelectedDate.Year.ToString & "-" & SelectedDate.Month.ToString & "-" & SelectedDate.Day.ToString
            Dim EndDate As String = SelectedDate.AddDays(1).Year.ToString & "-" & SelectedDate.AddDays(1).Month.ToString & "-" & SelectedDate.AddDays(1).Day.ToString
            If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_starttime >= ' " & StartDate & " '" & " AND cal_endtime <= ' " & EndDate & " ' AND cal_hidden = 0 AND cal_deleted = 0", "cal_starttime", "", ED, EC, ds) Then
                'If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_starttime >= ' " & StartDate & " '" & " AND cal_starttime <= ' " & EndDate & " ' AND cal_hidden = 0 AND cal_deleted = 0", "cal_starttime", "", ED, EC, ds) Then
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Private Function GetTimeSpan(ByVal View As String) As DataSet
        Dim ds As New DataSet("TimeSpan")

        Select Case View
            Case "Default"
                Dim dt As New DataTable("Default")
                Dim dr As DataRow
                dt.Columns.Add("time")
                dt.Columns.Add("ishour")
                dr = dt.NewRow : dr("time") = "00:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "00:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "01:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "01:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "02:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "02:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "03:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "03:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "04:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "04:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "05:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "05:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "06:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "06:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "07:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "07:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "08:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "08:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "09:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "09:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "10:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "10:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "11:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "11:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "12:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "12:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "13:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "13:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "14:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "14:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "15:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "15:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "16:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "16:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "17:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "17:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "18:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "18:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "19:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "19:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "20:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "20:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "21:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "21:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "22:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "22:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "23:00" : dr("ishour") = "1" : dt.Rows.Add(dr)
                dr = dt.NewRow : dr("time") = "23:30" : dr("ishour") = "0" : dt.Rows.Add(dr)
                ds.Tables.Add(dt)
        End Select
        Return ds
    End Function

    Private Function GetAppointmentRowHeaderString(ByVal TotAllDayApp As Integer) As String
        Dim sTemp As String
        Dim i As Integer
        For i = 1 To TotAllDayApp
            sTemp += "<tr height=20>"
            sTemp += "  <td colspan=2 bgcolor=" & CALENDAR_HEADER_COLOR & " background=""Desktop/Modules/Calendar/Images/bar4.gif"">&nbsp;</td>"
            sTemp += "</tr>"
        Next
        Return sTemp
    End Function

    Private Function GetAppointmentRowHourString(ByVal SelectedDate As Date, ByVal Time As String, ByVal isFirst As Boolean, ByVal cal_id As String, ByVal cal_subject As String, ByVal isStart As String, ByVal isEnd As String, ByVal isSpanStart As String, ByVal isSpanIn As String, ByVal isSpanEnd As String, ByVal iWidth As Integer, ByVal Label As String) As String
        Dim sTemp As String

        If cal_id = "0" Then
            ' If there is NO Appointment on this row...
            sTemp += DrawEmptyAppointmentRow(SelectedDate, Time, isFirst, True, Label)
        Else
            ' If there is A Appointment on this row...
            sTemp += DrawAppointmentRow(cal_id, cal_subject, isStart, isEnd, isSpanStart, isSpanIn, isSpanEnd, iWidth, Label)
        End If

        Return sTemp
    End Function

    Private Function GetAppointmentRowDelimeterString(ByVal SelectedDate As Date, ByVal Time As String, ByVal isFirst As Boolean, ByVal cal_id As String, ByVal cal_subject As String, ByVal isStart As String, ByVal isEnd As String, ByVal isSpanStart As String, ByVal isSpanIn As String, ByVal isSpanEnd As String, ByVal iWidth As Integer, ByVal Label As String) As String
        Dim sTemp As String

        If cal_id = "0" Then
            ' If there is NO Appointment on this row...
            sTemp += DrawEmptyAppointmentRow(SelectedDate, Time, isFirst, False, Label)
        Else
            ' If there is A Appointment on this row...
            sTemp += DrawAppointmentRow(cal_id, cal_subject, isStart, isEnd, isSpanStart, isSpanIn, isSpanEnd, iWidth, Label)
        End If

        Return sTemp
    End Function

    Private Function CalculateSubjectString(ByVal Subject As String, ByVal iWidth As Integer) As String
        If Len(Subject) < 1 Then
            Return "&nbsp;"
        Else
            Dim size As Integer = Len(Subject)
            Dim text As String = Mid(Subject, 1, (iWidth / 3))
            Select Case iWidth
                Case 0 To 7
                    Return "&nbsp;"
                Case 8 To 87
                    Return text
            End Select
        End If
    End Function

    Private Function DrawAppointmentRow(ByVal cal_id As String, ByVal cal_subject As String, ByVal isStart As String, ByVal isEnd As String, ByVal isSpanStart As String, ByVal isSpanIn As String, ByVal isSpanEnd As String, ByVal iWidth As Integer, ByVal Label As String) As String
        Dim sTemp As String
        'OVERFLOW: hidden;
        sTemp += "<tr height=20>"
        If isSpanStart = "1" Then
            ' This is a spanned appointment and is the first one...
            sTemp += "  <td bgcolor=" & CALENDAR_PRE_APPOINTMENT_COLOR & " style='" & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " WIDTH: 1px'><font style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana'>&nbsp;</font></td>"
            sTemp += "  <td nowrap " & IIf(Me.m_IsAuthorized, " onclick=""OPENEDIT(" & cal_id & ");""", "") & " bgcolor=" & Label & " style='cursor:hand; OVERFLOW: hidden;" & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " BORDER-LEFT: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid'>"
        ElseIf isSpanIn = "1" Then
            ' This is a spanned appointment and is one in the middle...
            sTemp += "  <td bgcolor=" & Label & " style='" & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " WIDTH: 1px'><font style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana'>&nbsp;</font></td>"
            sTemp += "  <td nowrap " & IIf(Me.m_IsAuthorized, " onclick=""OPENEDIT(" & cal_id & ");""", "") & " bgcolor=" & Label & " style='cursor:hand; OVERFLOW: hidden;" & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & "'>"
        ElseIf isSpanEnd = "1" Then
            ' This is a spanned appointment and is the last one...
            sTemp += "  <td bgcolor=" & Label & " style='" & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " WIDTH: 1px'><font style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana'>&nbsp;</font></td>"
            sTemp += "  <td nowrap " & IIf(Me.m_IsAuthorized, " onclick=""OPENEDIT(" & cal_id & ");""", "") & " bgcolor=" & Label & " style='cursor:hand; OVERFLOW: hidden;BORDER-RIGHT: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid; " & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & "'>"
        Else
            ' This is NOT a spanned appointment ( Standard )...
            sTemp += "  <td bgcolor=" & CALENDAR_PRE_APPOINTMENT_COLOR & " style='" & IIf(isStart = "1", "BORDER-TOP: #000000 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " WIDTH: 1px'><font style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana'>&nbsp;</font></td>"
            sTemp += "  <td nowrap " & IIf(Me.m_IsAuthorized, " onclick=""OPENEDIT(" & cal_id & ");""", "") & " bgcolor=" & Label & " style='cursor:hand; OVERFLOW: hidden;BORDER-RIGHT: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid; " & IIf(isStart = "1", "BORDER-TOP: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & IIf(isEnd = "1", "BORDER-BOTTOM: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid;", "") & " BORDER-LEFT: " & CALENDAR_APPOINTMENT_BORDER_COLOR & " 1px solid'>"
        End If
        sTemp += "    <font style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana'>" & CalculateSubjectString(cal_subject, iWidth) & "</font>"
        sTemp += "  </td>"
        sTemp += "</tr>"
        Return sTemp
    End Function

    Private Function DrawEmptyAppointmentRow(ByVal SelectedDate As Date, ByVal Time As String, ByVal isFirst As Boolean, ByVal isHour As Boolean, ByVal Label As String) As String
        Dim sTemp As String
        SelectedDate = SelectedDate.ToShortDateString & " " & Time
        If isFirst Then
            sTemp += "<tr height=20>"
            sTemp += "  <td bgcolor=" & CALENDAR_APPOINTMENT_COLOR & " style='WIDTH: 1px'><font style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font></td>"
            sTemp += "  <td bgcolor=" & CALENDAR_BACK_COLOR & IIf(Me.m_IsAuthorized, " onclick=""OPENNEW('" & SelectedDate & "');""", "") & " onmouseover=""this.style.backgroundColor='" & CALENDAR_NOAPPOINTMENT_OVERCOLOR & "'"" onmouseout=""this.style.backgroundColor='" & CALENDAR_BACK_COLOR & "'"" style=""cursor:hand;BORDER-TOP: " & IIf(isHour, CALENDAR_BORDER_HOUR_COLOR, CALENDAR_BORDER_HALF_COLOR) & " 1px solid;""><font style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font></td>"
            sTemp += "</tr>"
        Else
            sTemp += "<tr height=20>"
            sTemp += "  <td bgcolor=" & CALENDAR_BACK_COLOR & " style=""BORDER-TOP: " & IIf(isHour, CALENDAR_BORDER_HOUR_COLOR, CALENDAR_BORDER_HALF_COLOR) & " 1px solid; WIDTH: 1px""><font style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font></td>"
            sTemp += "  <td bgcolor=" & CALENDAR_BACK_COLOR & IIf(Me.m_IsAuthorized, " onclick=""OPENNEW('" & SelectedDate & "');""", "") & " onmouseover=""this.style.backgroundColor='" & CALENDAR_NOAPPOINTMENT_OVERCOLOR & "'"" onmouseout=""this.style.backgroundColor='" & CALENDAR_BACK_COLOR & "'"" style=""cursor:hand;BORDER-TOP: " & IIf(isHour, CALENDAR_BORDER_HOUR_COLOR, CALENDAR_BORDER_HALF_COLOR) & " 1px solid;'><font style=""FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: Verdana"">&nbsp;</font></td>"
            sTemp += "</tr>"
        End If
        Return sTemp
    End Function

    Private Function GetTimeSpanHeaderString(ByVal TotAllDayApp As Integer) As String
        Dim sTemp As String
        Dim i As Integer
        For i = 1 To TotAllDayApp
            If i = 1 Then
                sTemp += "<tr height=20>"
                sTemp += "  <td style='WIDTH: " & TIMESPAN_HOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & " background=""Desktop/Modules/Calendar/Images/bar4.gif"">&nbsp;</td>"
                sTemp += "  <td style='WIDTH: " & TIMESPAN_HALFHOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & " background=""Desktop/Modules/Calendar/Images/bar4.gif"">&nbsp;</td>"
                sTemp += "</tr>"
            Else
                sTemp += "<tr height=20>"
                sTemp += "  <td style='WIDTH: " & TIMESPAN_HOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & ">&nbsp;</td>"
                sTemp += "  <td style='WIDTH: " & TIMESPAN_HALFHOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & ">&nbsp;</td>"
                sTemp += "</tr>"
            End If
        Next
        Return sTemp
    End Function

    Private Function GetTimeSpanHourString(ByVal Time As String) As String
        Dim sTemp As String
        sTemp += "<tr height=20>"
        sTemp += "  <td rowSpan=2 valign=top style='BORDER-TOP: " & TIMESPAN_HEADER_COLOR & " 1px solid; WIDTH: " & TIMESPAN_HOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & ">"
        sTemp += "    <font color=" & TIMESPAN_TEXT_COLOR & " style='FONT-SIZE: large; FONT-FAMILY: " & TIMESPAN_TEXT_FAMILY & "'>" & Left(Time, 2) & "</font>"
        sTemp += "  </td>"
        sTemp += "  <td style='BORDER-TOP: " & TIMESPAN_HEADER_COLOR & " 1px solid; WIDTH: " & TIMESPAN_HALFHOUR_WIDTH & "' bgcolor=" & TIMESPAN_BG_COLOR & ">"
        sTemp += "    <font color=" & TIMESPAN_TEXT_COLOR & " style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: " & TIMESPAN_TEXT_FAMILY & "'>00</font>"
        sTemp += "  </td>"
        sTemp += "</tr>"
        Return sTemp
    End Function

    Private Function GetTimeSpanDelimeterString(ByVal Time As String) As String
        Dim sTemp As String
        sTemp += "<tr height=20>"
        sTemp += "  <td width=" & TIMESPAN_HALFHOUR_WIDTH & " bgcolor=" & TIMESPAN_BG_COLOR & ">"
        sTemp += "    <font color=" & TIMESPAN_TEXT_COLOR & " style='FONT-WEIGHT: normal; FONT-SIZE: x-small; FONT-FAMILY: " & TIMESPAN_TEXT_FAMILY & "'>" & Right(Time, 2) & "</font>"
        sTemp += "  </td>"
        sTemp += "</tr>"
        Return sTemp
    End Function

#End Region

    Public Function GetTimeline(ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        Try
            Dim sHtml As String = String.Empty
            sHtml += GetTimelineMonthBar(SelectedDate, SelectedDates)
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetTimelineMonthBar(ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        Try
            Dim sHtml As String = String.Empty
            sHtml += "<table height=""20px"" width=""700"" class=MonthBarBack border=""0"" cellSpacing=""2"" cellPadding=""2"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 2px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"
            sHtml += "  <tr>"
            sHtml += "    <td width=""70""><font class=MonthBar>Vecka</font></td>"
            sHtml += "    <td width=""20""></td>"
            sHtml += "    <td width=""75"">&nbsp;</td>"
            sHtml += "    <td width=""70""><font class=MonthBar>Ledig</font></td>"
            sHtml += "    <td width=""70""><font class=MonthBar>TurKod</font></td>"
            sHtml += "    <td width=""70""><font class=MonthBar>Start</font></td>"
            sHtml += "    <td width=""70""><font class=MonthBar>Rast</font></td>"
            sHtml += "    <td width=""70""><font class=MonthBar>Slut</font></td>"
            sHtml += "    <td width=""70""><font class=MonthBar>Netto -tid</font></td>"
            sHtml += "    <td width=""120""><font class=MonthBar>Anteckning</font></td>"
            sHtml += "  </tr>"
            sHtml += "</table>"
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetTimelineWeekBar(ByRef c As System.web.ui.Control, ByVal SelectedDate As Date, ByVal SelectedDates As Integer, ByVal usr_id As Integer) As String
        Try
            Dim sHtml As String = String.Empty
            Dim Days As Integer = SelectedDate.DaysInMonth(SelectedDate.Year, SelectedDate.Month)
            Dim Width As String = String.Format("{0:n0}", (100 / Days))
            sHtml += "<table width=""700"" border=""0"" cellSpacing=""1"" cellPadding=""0"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"

            '   sHtml += "  <tr>"
            '   Week numbers...
            '   Width builder...
            '   HttpContext.Current.Response.Write("<br><br><br>")
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
            '   System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("sv-SE")

            Me.usr_id = usr_id
            Dim dsCode As New DataSet
            Dim sError As String

            '// If you use week count
            'Select Case SelectedDate.DayOfWeek
            '    Case DayOfWeek.Monday : SelectedDate = SelectedDate.AddDays(0)
            '    Case DayOfWeek.Tuesday : SelectedDate = SelectedDate.AddDays(-1)
            '    Case DayOfWeek.Wednesday : SelectedDate = SelectedDate.AddDays(-2)
            '    Case DayOfWeek.Thursday : SelectedDate = SelectedDate.AddDays(-3)
            '    Case DayOfWeek.Friday : SelectedDate = SelectedDate.AddDays(-4)
            '    Case DayOfWeek.Saturday : SelectedDate = SelectedDate.AddDays(-5)
            '    Case DayOfWeek.Sunday : SelectedDate = SelectedDate.AddDays(-6)
            'End Select

            Dim sBColor As String = "#BDBFCB"

            For i As Integer = 0 To Days - 1
                sHtml += "  <tr>"
                'HttpContext.Current.Response.Write(IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), i & "=Ja, " & "Sel=" & SelectedDate.AddDays(i) & " Now=" & Now, i & "=Nej, " & "Sel=" & SelectedDate.AddDays(i) & " Now=" & Now))
                Select Case SelectedDate.AddDays(i).DayOfWeek
                    Case DayOfWeek.Monday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#efefef"" align=""center"">" & DatePart(DateInterval.WeekOfYear, SelectedDate.AddDays(i), Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System) & "</td>"
                        sHtml += "<td BGColor=""#efefef""  align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana""  align=""center"" width=""70"" width=""" & Width & "px""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 2px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "m", "m") & "</td>"
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;cursor:hand;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Tuesday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "t", "t") & "</td>"
                        sHtml += "<td BGColor=""#EAEBEF"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Wednesday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "w", "o") & "</td>"
                        sHtml += "<td BGColor=""#EAEBEF"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Thursday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "t", "t") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Friday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "f", "f") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Saturday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "s", "l") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                    Case DayOfWeek.Sunday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "s", "s") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#E4E6EA""></td>"    'Start
                        sHtml += "<td width=""70"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#D1D3DD"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#D1D3DD" & "'" & """   onclick=""OPENNEW" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(0) & " </td>"
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(1) & "</td>"    'Start
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(2) & "</td>"    'Rast
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & al(3) & "</td>"    'Slut
                        sHtml += "<td width=""70px"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""C1C4D1"">" & getNettoTime(al(1), al(2), al(3)) & "</td>"  'Slut
                        sHtml += "<td width=""120"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana;cursor:hand"" BGColor=""#ACAFC0"" onmouseover=""this.style.backgroundColor= " & "'" & sBColor & "'" & """ onmouseout=""this.style.backgroundColor= " & "'" & "#ACAFC0" & "'" & """   onclick=""OPENNOTE" & iModId & "('" & SelectedDate.AddDays(i) & "');"">" & al(4) & " </td>"
                End Select
                sHtml += "  </tr>"

            Next
            'sHtml += "  </tr>"

            ' Bar builder...
            Dim ds As DataSet = GetTimelineAppointments(SelectedDate, Days + 1)
            Dim Rows As Integer = 0
            'HttpContext.Current.Response.Write("ds.Tables.Count: " & ds.Tables.Count & "<br>")
            'HttpContext.Current.Response.Write(ds.GetXml)
            'HttpContext.Current.Response.Write("ds.Tables(0).rows.count: " & ds.Tables(0).Rows.Count & "<br>")
            For Each dr As DataRow In ds.Tables(0).Rows
                If CType(dr("cal_allday"), Integer) = 0 Then
                    Rows += 1
                    'HttpContext.Current.Response.Write(dr("cal_subject") & "<br>")
                End If
            Next

            ' Loopar antalet unika inlägg under denna period...
            Dim bIs As Boolean = False
            Dim bFirst As Boolean = False
            Dim bLast As Boolean = False
            Dim ii As Integer = 0
            Dim tHtml As String = String.Empty
            Dim bShowRow As Boolean = False
            For j As Integer = 0 To Rows - 1
                tHtml = "<tr>"
                bShowRow = False
                For i As Integer = 0 To Days - 1
                    bIs = False
                    bFirst = False
                    bLast = False
                    ii = 0
                    For Each dr As DataRow In ds.Tables(0).Rows
                        If CType(ds.Tables(0).Rows(j)("cal_id"), Integer) = CType(dr("cal_id"), Integer) Or CType(ds.Tables(0).Rows(j)("cal_id"), Integer) = CType(dr("cal_allday"), Integer) Then
                            If SelectedDate.AddDays(i) = CType(dr("cal_starttime"), DateTime) Or SelectedDate.AddDays(i) = CType(dr("cal_endtime"), DateTime) Then
                                If CType(dr("cal_allday"), Integer) = 0 Then
                                    Try
                                        If Rows - 1 = 0 And ds.Tables(0).Rows.Count = 1 Then bLast = True
                                        If IsLonely(CType(ds.Tables(0).Rows(j)("cal_id"), Integer), ds) Then bLast = True
                                    Catch ex As Exception
                                    End Try
                                    bFirst = True
                                End If
                                If Not CType(dr("cal_allday"), Integer) = 0 Then
                                    Try
                                        If Not ds.Tables(0).Rows(ii)("cal_allday") = ds.Tables(0).Rows(ii + 1)("cal_allday") Then bLast = True
                                    Catch ex As Exception
                                        bLast = True
                                    End Try
                                End If
                                bIs = True
                                Exit For
                            End If
                        End If
                        ii += 1
                    Next
                    If bIs Then
                        tHtml += "<td width=""" & Width & "%" & """ bgcolor=""" & CType(ds.Tables(0).Rows(j)("cal_label"), String) & """ style=""BORDER-TOP: #ffffff 1px solid;BORDER-BOTTOM: #ffffff 1px solid;"">"
                        tHtml += "<span " & IIf(m_IsAuthorized, "onclick=""OPENEDIT" & iModId & "(" & CType(ds.Tables(0).Rows(j)("cal_id"), Integer) & ");""", "") & " style=""BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;" & IIf(bFirst, "BORDER-LEFT: #000000 1px solid;", "") & IIf(bLast, "BORDER-RIGHT: #000000 1px solid;", "") & IIf(m_IsAuthorized, "cursor:hand;", "") & "background-color:" & CType(ds.Tables(0).Rows(j)("cal_label"), String) & ";width:100%"" title=""" & ds.Tables(0).Rows(j)("cal_subject") & vbCrLf & ds.Tables(0).Rows(j)("cal_text") & """></span>"
                        tHtml += "</td>"
                        bShowRow = True
                    Else
                        tHtml += "<td width=""" & Width & "%" & """ bgcolor=""white"" style=""BORDER-TOP: #ffffff 1px solid;BORDER-BOTTOM: #ffffff 1px solid;"">"
                        tHtml += "&nbsp;"
                        tHtml += "</td>"
                    End If
                Next
                tHtml += "</tr>"
                If bShowRow Then
                    sHtml += tHtml
                    tHtml = String.Empty
                    Dim l As New System.Web.UI.WebControls.Label
                    l.Width = l.Width.Pixel(4)
                    l.Height = l.Height.Pixel(8)
                    l.BackColor = l.BackColor.FromName(CType(ds.Tables(0).Rows(j)("cal_label"), String))
                    l.BorderColor = l.BorderColor.Black
                    l.BorderStyle = l.BorderStyle.Solid
                    l.BorderWidth = l.BorderWidth.Pixel(1)
                    c.Controls.Add(New System.Web.UI.LiteralControl("<br>"))
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(l)
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(New System.Web.UI.LiteralControl(CType(ds.Tables(0).Rows(j)("cal_subject"), String)))
                End If
            Next
            c.Controls.Add(New System.Web.UI.LiteralControl("<br>"))
            sHtml += "</table>"
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function IsLonely(ByVal CalId As Integer, ByVal ds As DataSet) As Boolean
        Try
            For Each dr As DataRow In ds.Tables(0).Rows
                If CalId = dr("cal_allday") Then Return False
            Next
            Return True
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Function GetTimelineAppointments(ByVal SelectedDate As Date, ByVal Span As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim Days As Integer = SelectedDate.DaysInMonth(SelectedDate.Year, SelectedDate.Month)
            Dim sStartDate As String = SelectedDate.Year.ToString & "-" & SelectedDate.Month.ToString & "-" & SelectedDate.Day.ToString
            Dim sEndDate As String = SelectedDate.AddDays(Span).Year.ToString & "-" & SelectedDate.AddDays(Span).Month.ToString & "-" & SelectedDate.AddDays(Span).Day.ToString
            Dim sMinDate As String = SelectedDate.AddDays(-Span).Year.ToString & "-" & SelectedDate.AddDays(-Span).Month.ToString & "-" & SelectedDate.AddDays(-Span).Day.ToString
            If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_endtime <= ' " & sEndDate & " ' AND cal_hidden = 0 AND cal_deleted = 0", "cal_allday, cal_starttime", "", ED, EC, ds) Then
                'If Not oDO.GetDataSet("cal_calendar", "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_starttime >= ' " & sStartDate & " '" & " AND cal_endtime <= ' " & sEndDate & " ' AND cal_hidden = 0 AND cal_deleted = 0", "cal_allday, cal_starttime", "", ED, EC, ds) Then
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetAllAppointmentsInMonthTimeline(ByVal StartDate As String) As DataSet
        Dim ds As New DataSet
        Try
            StartDate = CType(StartDate, DateTime).AddDays(-1)
            Dim EndDate As String = CType(StartDate, DateTime).AddDays(2 + CType(StartDate, DateTime).DaysInMonth(CType(StartDate, DateTime).Year, CType(StartDate, DateTime).Month))
            Dim oDefine As New clsDefinedDataList
            'oDefine.AddDefinedTableColumn("cal_starttime")
            oDefine.AddDefinedTableColumn("cal_endtime")
            If Not oDO.GetDefinedDataSet("cal_calendar", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & oSite.ActivePage.PageId & " AND mod_id = " & iModId & " AND cal_starttime > '" & StartDate & "' AND cal_endtime < '" & EndDate & "' AND cal_hidden = 0 AND cal_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

#Region "TimePlan"

    Public Function getTripCode(ByVal sDate As String)
        Dim code As String
        Dim al As New System.Collections.ArrayList
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND usr_id = " & Me.usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try

        If ds.Tables(0).Rows.Count > 0 Then
            al.Add(ds.Tables(0).Rows(0)("rep_code"))
            al.Add(ds.Tables(0).Rows(0)("rep_startTimeAm"))
            al.Add(ds.Tables(0).Rows(0)("rep_breakTimeAm"))
            al.Add(ds.Tables(0).Rows(0)("rep_endTimeAm"))
            al.Add(ds.Tables(0).Rows(0)("rep_note"))
        Else
            al.Add("")
            al.Add("")
            al.Add("")
            al.Add("")
            al.Add("")
        End If

        Return al

    End Function


    Private Function getNettoTime(ByVal startTime As String, ByVal Break As String, ByVal endTime As String) As String

        Dim sNetto As String
        Dim iNetto As Decimal
        Dim dStart As Decimal
        Dim dEnd As Decimal
        Dim dNetto As Decimal
        Dim dTot As Decimal
        Dim dBreak As Decimal
        Dim sHalf As Decimal

        sNetto = ""

        Try
            dStart = CType(Split(startTime, ":")(0), Decimal)
            dBreak = CType(Break, Decimal)
            dEnd = CType(Split(endTime, ":")(0), Decimal)
            If (Split(startTime, ":")(1) = "30") Then
                dStart = dStart + 0.5
            End If

            If (Split(endTime, ":")(1) = "30") Then
                dEnd = dEnd + 0.5
            End If

            If (Split(endTime, ":")(0)) > (Split(startTime, ":")(0)) Then
                dNetto = dEnd - dStart
                dTot = dNetto - 0.5
            End If

            sNetto = CType(dTot, Decimal)

            totNettoTime = totNettoTime + sNetto
            'totNettoTime = sNetto
        Catch ex As Exception
        End Try

        Return sNetto

    End Function


    'Public Function GetNettoTime() As Decimal
    '    Return totNettoTime
    'End Function


#End Region

#Region " Timesheet Functions "

    Private Function GetWeek(ByVal SelectedDate As Date) As String
        Try
            If System.Threading.Thread.CurrentThread.CurrentCulture.Name = "en-US" Then
                Return "Week " & CType(DatePart(DateInterval.WeekOfYear, SelectedDate, Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System), String)
            Else
                Return "Vecka " & CType(DatePart(DateInterval.WeekOfYear, SelectedDate, Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System), String)
            End If
        Catch ex As Exception
            Return "Week " & CType(DatePart(DateInterval.WeekOfYear, Now, Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System), String)
        End Try
    End Function

    Private Function GetWeekNumber(ByVal SelectedDate As Date) As String
        Try
            Return CType(DatePart(DateInterval.WeekOfYear, SelectedDate, Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System), String)
        Catch ex As Exception
            Return CType(DatePart(DateInterval.WeekOfYear, Now, Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System), String)
        End Try
    End Function

    Public Function GetTimesheetMonthBar(ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        Try
            Dim sHtml As String = String.Empty
            sHtml += "<table height=""23px"" width=""100%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 2px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"
            sHtml += "  <tr>"
            sHtml += "    <td align=""center"" style=""FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & GetWeek(SelectedDate) & "</td>"
            sHtml += "  </tr>"
            sHtml += "</table>"
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetTimesheetWeekBar(ByRef c As System.web.ui.Control, ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String

        ' Get the week from the date...
        ' Loop throu all days in this week...
        ' Loop throu all users and check for appointments on the selected day in week...

        Try
            Dim sHtml As String = String.Empty
            Select Case SelectedDate.DayOfWeek
                Case DayOfWeek.Monday : SelectedDate = SelectedDate.AddDays(0)
                Case DayOfWeek.Tuesday : SelectedDate = SelectedDate.AddDays(-1)
                Case DayOfWeek.Wednesday : SelectedDate = SelectedDate.AddDays(-2)
                Case DayOfWeek.Thursday : SelectedDate = SelectedDate.AddDays(-3)
                Case DayOfWeek.Friday : SelectedDate = SelectedDate.AddDays(-4)
                Case DayOfWeek.Saturday : SelectedDate = SelectedDate.AddDays(-5)
                Case DayOfWeek.Sunday : SelectedDate = SelectedDate.AddDays(-6)
            End Select
            Dim Days As Integer = 5
            Dim Width As String = String.Format("{0:n0}", (100 / Days))
            sHtml += "<table width=""100%"" border=""0"" cellSpacing=""0"" cellPadding=""0"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"
            sHtml += "  <tr>"
            sHtml += "    <td align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">&nbsp;</td>"
            sHtml += "    <td align=""center"" width=""" & Width & "%""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & IIf(oSite.Language = 1, "<b>M</b>", "<b>M</b>") & " " & SelectedDate.AddDays(0).ToString("dd MMM") & "</td>"
            sHtml += "    <td align=""center"" width=""" & Width & "%""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & IIf(oSite.Language = 1, "<b>T</b>", "<b>T</b>") & " " & SelectedDate.AddDays(1).ToString("dd MMM") & "</td>"
            sHtml += "    <td align=""center"" width=""" & Width & "%""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & IIf(oSite.Language = 1, "<b>W</b>", "<b>O</b>") & " " & SelectedDate.AddDays(2).ToString("dd MMM") & "</td>"
            sHtml += "    <td align=""center"" width=""" & Width & "%""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & IIf(oSite.Language = 1, "<b>T</b>", "<b>T</b>") & " " & SelectedDate.AddDays(3).ToString("dd MMM") & "</td>"
            sHtml += "    <td align=""center"" width=""" & Width & "%""" & """ style=""BORDER-RIGHT: #000000 0px solid;BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & IIf(oSite.Language = 1, "<b>F</b>", "<b>F</b>") & " " & SelectedDate.AddDays(4).ToString("dd MMM") & "</td>"
            sHtml += "  </tr>"

            ' /// Users
            Dim dsUsers As DataSet = GetAllUsers()
            Dim dsApp As DataSet = GetTimelineAppointments(SelectedDate.AddDays(0), 6)
            Dim Users() As String
            For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
                If _mod.ModuleId = Me.iModId Then Users = Split(_mod.EditSrc, ";")
            Next
            For Each s As String In Users
                For Each dru As DataRow In dsUsers.Tables(0).Rows
                    If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                        Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                        sHtml += "<tr>"
                        sHtml += "<td valign=""top"" align=""left"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & CType(dru("usr_firstname"), String) & "&nbsp;" & IIf(CType(dru("usr_lastname"), String).Length > 0, CType(dru("usr_lastname"), String).Substring(0, 2), "") & "&nbsp;</td>"
                        sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(0), s, Width, Max)
                        sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(1), s, Width, Max)
                        sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(2), s, Width, Max)
                        sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(3), s, Width, Max)
                        sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(4), s, Width, Max)
                        sHtml += "</tr>"
                    End If
                Next
            Next

            sHtml += "</table>"
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function CalculateMaxRowsOnUser(ByVal dsApp As DataSet, ByVal SelectedDate As Date, ByVal UsrId As String) As Integer
        Try
            Dim Max As Integer = 0
            Dim tMax As Integer = 0
            tMax = 0
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.AddDays(0).ToShortDateString Then
                    tMax += 1
                End If
            Next
            If tMax > Max Then Max = tMax
            tMax = 0
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.AddDays(1).ToShortDateString Then
                    tMax += 1
                End If
            Next
            If tMax > Max Then Max = tMax
            tMax = 0
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.AddDays(2).ToShortDateString Then
                    tMax += 1
                End If
            Next
            If tMax > Max Then Max = tMax
            tMax = 0
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.AddDays(3).ToShortDateString Then
                    tMax += 1
                End If
            Next
            If tMax > Max Then Max = tMax
            tMax = 0
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.AddDays(4).ToShortDateString Then
                    tMax += 1
                End If
            Next
            If tMax > Max Then Max = tMax
            Return Max
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Private Function CreateAppointmentHolder(ByVal dsApp As DataSet, ByVal SelectedDate As Date, ByVal UsrId As String, ByVal iWidth As Integer, ByVal Max As Integer) As String
        Dim sHtml As String
        Dim sHtmlStart As String
        Dim Exist As Boolean = False
        Dim tMax As Integer = 0
        Try
            sHtml += "<table border=""0"" cellSpacing=""0"" cellPadding=""0"" width=""100%"" >"
            For Each drt As DataRow In dsApp.Tables(0).Rows
                If CType(drt("cal_attendees"), String) = UsrId And CType(drt("cal_endtime"), Date).ToShortDateString = SelectedDate.ToShortDateString Then
                    Exist = True
                    tMax += 1
                    sHtml += "<tr height=""20"">"
                    sHtml += " <td height=""20"" " & IIf(m_IsAuthorized, " onclick=""OPENEDIT" & iModId & "(" & CType(drt("cal_id"), Integer) & ");""", "") & " style=""BORDER-BOTTOM: #000000 " & IIf(tMax < Max, "1", "0") & "px solid;" & IIf(m_IsAuthorized, "cursor:hand;""", "") & """ title=""" & drt("cal_subject") & vbCrLf & drt("cal_text") & """ align=""left"" width=""" & iWidth & "%"" bgcolor=""" & CType(drt("cal_label"), String) & """>"
                    sHtml += "&nbsp;" & Mid(CType(drt("cal_subject"), String), 1, (iWidth / 3))
                    sHtml += " </td>"
                    sHtml += "</tr>"
                End If
            Next
            If Not Exist Then
                If tMax < Max Then
                    For i As Integer = tMax To Max - 1
                        sHtml += "<tr height=""20""><td height=""20"">&nbsp;</td></tr>"
                    Next
                End If
                sHtml = "<td height=""20"" " & IIf(m_IsAuthorized, " onclick=""OPENNEWX" & iModId & "('" & SelectedDate.ToShortDateString & "', " & UsrId & ");""", "") & " valign=""top"" align=""center"" width=""" & iWidth & "%""" & " style=""" & IIf(m_IsAuthorized, "cursor:hand;", "") & "BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & sHtml
            Else
                If tMax < Max Then
                    For i As Integer = tMax To Max - 1
                        sHtml += "<tr height=""20""><td height=""20"" " & IIf(m_IsAuthorized, " onclick=""OPENNEWX" & iModId & "('" & SelectedDate.ToShortDateString & "', " & UsrId & ");""", "") & ">&nbsp;</td></tr>"
                    Next
                Else
                End If
                sHtml = "<td height=""20"" valign=""top"" align=""center"" width=""" & iWidth & "%""" & " style=""" & IIf(m_IsAuthorized, "cursor:hand;", "") & "BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & sHtml
            End If
            ' Denna komentaren lägger till en klickbar ruta under varje inlägg...
            'sHtml += "<tr><td bgcolor=green " & IIf(m_IsAuthorized, " onclick=""OPENNEWX" & iModId & "('" & SelectedDate.ToShortDateString & "', " & UsrId & ");""", "") & ">&nbsp;</td></tr>"
            sHtml += "</table>"
            sHtml += "    </td>"
            Return sHtml
        Catch ex As Exception
            Return "<td valign=""top"" align=""center"" width=""" & iWidth & "%""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana""><table border=""0"" cellSpacing=""0"" cellPadding=""0""><tr><td>&nbsp;</td></tr></table></td>"
        End Try
    End Function

    Public Function GetAllUsers() As DataSet
        Dim dsRoles As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("usr_users", "usr_hidden = 0 AND usr_deleted = 0 AND sit_id = " & oSite.SiteId, "usr_firstname,usr_loginname", sError, ED, EC, dsRoles) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Return dsRoles
    End Function

    Public Function GetAllUsersOnModule() As DataTable 'DataSet
        Dim dsRoles As New DataSet
        Dim dsUsers As New DataSet
        Dim sError As String
        Dim Users() As String
        For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
            If _mod.ModuleId = Me.iModId Then Users = Split(_mod.EditSrc, ";")
        Next

        If Not oDO.GetDataSet("usr_users", "usr_hidden = 0 AND usr_deleted = 0 AND sit_id = " & oSite.SiteId, "usr_firstname,usr_loginname", sError, ED, EC, dsUsers) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If

        Dim i As Integer = 0
        Dim ss As String

        Dim dt As New DataTable
        Dim dr As DataRow

        Dim dcID As New DataColumn("id")
        dcID.AutoIncrement = True
        dcID.Unique = True
        dt.Columns.Add(dcID)

        Dim usr_id As New DataColumn("usr_id")
        dt.Columns.Add(usr_id)
        dcID.Unique = False

        Dim usr_name As New DataColumn("usr_name")
        dt.Columns.Add(usr_name)

        Dim usr_jobtime As New DataColumn("usr_jobtime")
        dt.Columns.Add(usr_jobtime)

        'Dim usr_name As New DataColumn("usr_name")
        'dt.Columns.Add(usr_name)


        For Each s As String In Users
            For Each dru As DataRow In dsUsers.Tables(0).Rows
                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                    dr = dt.NewRow()
                    dr("usr_id") = dru("usr_id")
                    dr("usr_name") = CType(dru("usr_firstname"), String).ToLower & " " & CType(dru("usr_lastname"), String).ToLower
                    dr("usr_jobtime") = dru("usr_jobtime")
                    dt.Rows.Add(dr)
                End If
            Next
        Next

        Return dt
    End Function




    Public Function UpdateModuleUsers(ByVal PagId As Integer, ByVal ModId As Integer, ByVal Users As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("mod_modules", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0)("mod_editsrc") = Users
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Calender 2"

    Public Function GetTimelineMonthBar2(ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        '''Try
        '''    Dim sHtml As String = String.Empty
        '''    sHtml += "<table height=""20px"" width=""700"" border=""0"" cellSpacing=""2"" cellPadding=""2"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 2px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"
        '''    sHtml += "  <tr BGColor=""#9497A5"" >"
        '''    sHtml += "    <td width=""70""><font color=white><b>Vecka</b></font></td>"
        '''    sHtml += "    <td width=""20""></td>"
        '''    sHtml += "    <td width=""75"">&nbsp;</td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Anna</b></font></td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Petter</b></font></td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Adam</b></font></td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Rast</b></font></td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Slut</b></font></td>"
        '''    sHtml += "    <td width=""70""><font color=white><b>Netto -tid</b></font></td>"
        '''    sHtml += "    <td width=""120""><font color=white><b>Anteckning</b></font></td>"
        '''    sHtml += "  </tr>"
        '''    sHtml += "</table>"
        '''    Return sHtml
        '''Catch ex As Exception
        '''    Return String.Empty
        '''End Try
    End Function

    Public Function GetTimelineWeekBar2(ByRef c As System.web.ui.Control, ByVal SelectedDate As Date, ByVal SelectedDates As Integer) As String
        Try
            Dim sHtml As String = String.Empty
            Dim Days As Integer = SelectedDate.DaysInMonth(SelectedDate.Year, SelectedDate.Month)
            Dim Width As String = String.Format("{0:n0}", (100 / Days))
            'width=""700""
            Dim sBackColor As String
            sBackColor = "#E4E6EA"
            sHtml += "<table  border=""0""  cellSpacing=""1"" cellPadding=""0"" align=""left"" style=""BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;"">"
            'sHtml += "  <tr>"

            ' Week numbers...

            ' Width builder...
            'HttpContext.Current.Response.Write("<br><br><br>")
            'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("sv-SE")
            'System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("sv-SE")

            'Width = "40"
            'jobi getCode
            Dim dsCode As New DataSet
            Dim sError As String


            Select Case SelectedDate.DayOfWeek
                Case DayOfWeek.Monday : SelectedDate = SelectedDate.AddDays(0)
                Case DayOfWeek.Tuesday : SelectedDate = SelectedDate.AddDays(-1)
                Case DayOfWeek.Wednesday : SelectedDate = SelectedDate.AddDays(-2)
                Case DayOfWeek.Thursday : SelectedDate = SelectedDate.AddDays(-3)
                Case DayOfWeek.Friday : SelectedDate = SelectedDate.AddDays(-4)
                Case DayOfWeek.Saturday : SelectedDate = SelectedDate.AddDays(-5)
                Case DayOfWeek.Sunday : SelectedDate = SelectedDate.AddDays(-6)
            End Select

            Dim sBColor As String = "#BDBFCB"

            ' /// Users
            Dim dsUsers As DataSet = GetAllUsers()
            Dim dsApp As DataSet = GetTimelineAppointments(SelectedDate.AddDays(0), 6)
            Dim Users() As String
            For Each _mod As clsModuleSettings In oSite.ActivePage.Modules
                If _mod.ModuleId = Me.iModId Then Users = Split(_mod.EditSrc, ";")
            Next

            sHtml += "<td bgcolor=""#264E81""></td><td bgcolor=""#264E81""></td><td bgcolor=""#264E81""></td>"

            For Each s As String In Users
                For Each dru As DataRow In dsUsers.Tables(0).Rows
                    If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                        Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                        'sHtml += "<tr>"
                        sHtml += "<td valign=""top"" bgcolor=""#264E81""  align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: bold; Color: ghostwhite; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & CType(dru("usr_firstname"), String) & "&nbsp;" & IIf(CType(dru("usr_lastname"), String).Length > 0, CType(dru("usr_lastname"), String).Substring(0, 3), "") & "&nbsp;</td>"
                        'sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(0), s, Width, Max)
                        'sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(1), s, Width, Max)
                        'sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(2), s, Width, Max)
                        'sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(3), s, Width, Max)
                        'sHtml += CreateAppointmentHolder(dsApp, SelectedDate.AddDays(4), s, Width, Max)
                        'sHtml += "</tr>"
                    End If
                Next
            Next

            For i As Integer = 0 To Days - 1
                sHtml += "  <tr>"
                'HttpContext.Current.Response.Write(IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), i & "=Ja, " & "Sel=" & SelectedDate.AddDays(i) & " Now=" & Now, i & "=Nej, " & "Sel=" & SelectedDate.AddDays(i) & " Now=" & Now))
                Select Case SelectedDate.AddDays(i).DayOfWeek
                    Case DayOfWeek.Monday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td width=""70"" BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & DatePart(DateInterval.WeekOfYear, SelectedDate.AddDays(i), Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System) & "</td>"
                        sHtml += "<td BGColor=""#efefef""  align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""70"" width=""" & Width & "px""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 2px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "m", "m") & "</td>"
                        sHtml += "<td width=""100"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh

                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    'sHtml += "<td valign=""top"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                End If
                            Next
                        Next

                    Case DayOfWeek.Tuesday

                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "t", "t") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    ' sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                End If
                            Next
                        Next

                    Case DayOfWeek.Wednesday

                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "w", "o") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    ' sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                End If
                            Next
                        Next

                    Case DayOfWeek.Thursday

                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "t", "t") & "</td>"
                        sHtml += "<td BGColor=""#EAEBEF"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    ' sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"

                                End If
                            Next
                        Next

                    Case DayOfWeek.Friday
                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "f", "f") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    '  sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"

                                End If
                            Next
                        Next

                    Case DayOfWeek.Saturday

                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "s", "l") & "</td>"
                        sHtml += "<td BGColor=""#EAEBEF"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    ' sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"

                                End If
                            Next
                        Next

                    Case DayOfWeek.Sunday

                        Dim al As System.Collections.ArrayList
                        al = getTripCode(SelectedDate.AddDays(i))
                        sHtml += "<td></td>"
                        sHtml += "<td BGColor=""#efefef"" align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" width=""" & Width & "%""" & IIf(SelectedDate.AddDays(i).Day.Equals(Now.Day), " bgcolor=""#F5F5F5", "") & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;"">" & IIf(oSite.Language = 1, "s", "s") & "</td>"
                        sHtml += "<td align=""center"" valign=""middle"" style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"" BGColor=""#EAEBEF"">" & SelectedDate.AddDays(i).ToString("dd MMM") & "</td>" 'Ledigh
                        For Each s As String In Users
                            For Each dru As DataRow In dsUsers.Tables(0).Rows
                                If s.Length > 0 And CType(dru("usr_id"), String).ToLower = s.ToLower Then
                                    Dim Max As Integer = CalculateMaxRowsOnUser(dsApp, SelectedDate, s)
                                    '   sHtml += "<td valign=""top"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 1px solid;BORDER-RIGHT: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"
                                    sHtml += "<td valign=""middle"" BGColor=""#BDBFCB"" align=""center"" width=""100px""" & """ style=""BORDER-LEFT: #000000 0px solid;BORDER-RIGHT: #000000 0px solid;BORDER-TOP: #000000 0px solid;BORDER-BOTTOM: #000000 0px solid;FONT-WEIGHT: normal; FONT-SIZE: xx-small; FONT-FAMILY: Verdana"">" & getUserCodeForDay(dru("usr_id"), SelectedDate.AddDays(i)) & "</td>"

                                End If
                            Next
                        Next
                End Select
                sHtml += "  </tr>"

            Next

            ' Bar builder...
            Dim ds As DataSet = GetTimelineAppointments(SelectedDate, Days + 1)
            Dim Rows As Integer = 0
            'HttpContext.Current.Response.Write("ds.Tables.Count: " & ds.Tables.Count & "<br>")
            'HttpContext.Current.Response.Write(ds.GetXml)
            'HttpContext.Current.Response.Write("ds.Tables(0).rows.count: " & ds.Tables(0).Rows.Count & "<br>")
            For Each dr As DataRow In ds.Tables(0).Rows
                If CType(dr("cal_allday"), Integer) = 0 Then
                    Rows += 1
                    'HttpContext.Current.Response.Write(dr("cal_subject") & "<br>")
                End If
            Next

            ' Loopar antalet unika inlägg under denna period...
            Dim bIs As Boolean = False
            Dim bFirst As Boolean = False
            Dim bLast As Boolean = False
            Dim ii As Integer = 0
            Dim tHtml As String = String.Empty
            Dim bShowRow As Boolean = False
            For j As Integer = 0 To Rows - 1
                tHtml = "<tr>"
                bShowRow = False
                For i As Integer = 0 To Days - 1
                    bIs = False
                    bFirst = False
                    bLast = False
                    ii = 0
                    For Each dr As DataRow In ds.Tables(0).Rows
                        If CType(ds.Tables(0).Rows(j)("cal_id"), Integer) = CType(dr("cal_id"), Integer) Or CType(ds.Tables(0).Rows(j)("cal_id"), Integer) = CType(dr("cal_allday"), Integer) Then
                            If SelectedDate.AddDays(i) = CType(dr("cal_starttime"), DateTime) Or SelectedDate.AddDays(i) = CType(dr("cal_endtime"), DateTime) Then
                                If CType(dr("cal_allday"), Integer) = 0 Then
                                    Try
                                        If Rows - 1 = 0 And ds.Tables(0).Rows.Count = 1 Then bLast = True
                                        If IsLonely(CType(ds.Tables(0).Rows(j)("cal_id"), Integer), ds) Then bLast = True
                                    Catch ex As Exception
                                    End Try
                                    bFirst = True
                                End If
                                If Not CType(dr("cal_allday"), Integer) = 0 Then
                                    Try
                                        If Not ds.Tables(0).Rows(ii)("cal_allday") = ds.Tables(0).Rows(ii + 1)("cal_allday") Then bLast = True
                                    Catch ex As Exception
                                        bLast = True
                                    End Try
                                End If
                                bIs = True
                                Exit For
                            End If
                        End If
                        ii += 1
                    Next
                    If bIs Then
                        tHtml += "<td width=""" & Width & "%" & """ bgcolor=""" & CType(ds.Tables(0).Rows(j)("cal_label"), String) & """ style=""BORDER-TOP: #ffffff 1px solid;BORDER-BOTTOM: #ffffff 1px solid;"">"
                        tHtml += "<span " & IIf(m_IsAuthorized, "onclick=""OPENEDIT" & iModId & "(" & CType(ds.Tables(0).Rows(j)("cal_id"), Integer) & ");""", "") & " style=""BORDER-TOP: #000000 1px solid;BORDER-BOTTOM: #000000 1px solid;" & IIf(bFirst, "BORDER-LEFT: #000000 1px solid;", "") & IIf(bLast, "BORDER-RIGHT: #000000 1px solid;", "") & IIf(m_IsAuthorized, "cursor:hand;", "") & "background-color:" & CType(ds.Tables(0).Rows(j)("cal_label"), String) & ";width:100%"" title=""" & ds.Tables(0).Rows(j)("cal_subject") & vbCrLf & ds.Tables(0).Rows(j)("cal_text") & """></span>"
                        tHtml += "</td>"
                        bShowRow = True
                    Else
                        tHtml += "<td width=""" & Width & "%" & """ bgcolor=""white"" style=""BORDER-TOP: #ffffff 1px solid;BORDER-BOTTOM: #ffffff 1px solid;"">"
                        tHtml += "&nbsp;"
                        tHtml += "</td>"
                    End If
                Next
                tHtml += "</tr>"
                If bShowRow Then
                    sHtml += tHtml
                    tHtml = String.Empty
                    Dim l As New System.Web.UI.WebControls.Label
                    l.Width = l.Width.Pixel(4)
                    l.Height = l.Height.Pixel(8)
                    l.BackColor = l.BackColor.FromName(CType(ds.Tables(0).Rows(j)("cal_label"), String))
                    l.BorderColor = l.BorderColor.Black
                    l.BorderStyle = l.BorderStyle.Solid
                    l.BorderWidth = l.BorderWidth.Pixel(1)
                    c.Controls.Add(New System.Web.UI.LiteralControl("<br>"))
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(l)
                    c.Controls.Add(New System.Web.UI.LiteralControl("&nbsp;"))
                    c.Controls.Add(New System.Web.UI.LiteralControl(CType(ds.Tables(0).Rows(j)("cal_subject"), String)))
                End If
            Next
            c.Controls.Add(New System.Web.UI.LiteralControl("<br>"))
            sHtml += "</table>"
            Return sHtml
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function getUserCodeForDay(ByVal usr_id As Integer, ByVal sDate As String) As String

        Dim code As String
        Dim al As New System.Collections.ArrayList
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND usr_id = " & usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try

        If ds.Tables(0).Rows.Count > 0 Then
            code = ds.Tables(0).Rows(0)("rep_code")
        Else
            code = "&nbsp"
        End If
        'code = CType(usr_id, String)
        Return code '& "::" & sDate


    End Function


#End Region

End Class
