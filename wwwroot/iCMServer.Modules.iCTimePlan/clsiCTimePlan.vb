Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsiCTimePlan

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
#End Region

#Region "Public Function"

    Public Sub New(ByVal ModId As Integer)
        Me.iModId = ModId
    End Sub


#Region "Code"

    Public Function SaveTimeCode(ByVal timeCode As String, ByVal StartTime As String, ByVal breakTime As String, ByVal EndTime As String) As Integer
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("cod_codesICTIME", "", ED, EC, ds) Then
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = oSite.ActivePage.PageId
                .Item("mod_id") = Me.iModId
                .Item("cod_code") = timeCode
                .Item("cod_startTimeAm") = StartTime
                .Item("cod_breakTimeAM") = breakTime
                .Item("cod_endTimeAM") = EndTime
                .Item("cod_createddate") = Now.ToLongDateString
                .Item("cod_createdby") = HttpContext.Current.User.Identity.Name
                .Item("cod_updateddate") = Now.ToLongDateString
                .Item("cod_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("cod_hidden") = 0
                .Item("cod_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
            End If
            Return ds.Tables(0).Rows(0)("cod_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function SaveTripCode(ByVal tripCode As String, ByVal sDate As String, ByVal startTimeAm As String, ByVal breakTimeAm As String, ByVal endTimeAm As String, ByVal usr_id As Integer) As Integer
        Dim ds As New DataSet
        Try
            Dim dsCheck As New DataSet
            Dim sError As String
            Try
                If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND usr_id = " & usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, dsCheck) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If
            Catch ex As Exception
            End Try
            If dsCheck.Tables(0).Rows.Count > 0 Then
                ds.Merge(dsCheck)
                With ds.Tables(0).Rows(0)
                    .Item("rep_code") = tripCode
                    .Item("rep_hidden") = 0
                    .Item("rep_deleted") = 0
                End With
            Else
                If Not oDO.GetEmptyDataSet("rep_reportICTIME", "", ED, EC, ds) Then
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("sit_id") = oSite.SiteId
                        .Item("pag_id") = oSite.ActivePage.PageId
                        .Item("mod_id") = iModId
                        .Item("usr_id") = usr_id
                        .Item("rep_code") = tripCode
                        .Item("rep_date") = sDate
                        .Item("rep_startTimeAm") = startTimeAm
                        .Item("rep_breakTimeAm") = breakTimeAm
                        .Item("rep_endTimeAm") = endTimeAm
                        .Item("rep_hidden") = 0
                        .Item("rep_deleted") = 0
                    End With
                End If
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
            End If
            Return ds.Tables(0).Rows(0)("rep_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function DeleteCode(ByVal sDate As String, ByVal usr_id As Integer) As String
        Dim ds As New DataSet
        Dim sError As String

        If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND usr_id = " & usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                If oSite.SiteSoftDelete Then
                    For Each dr As DataRow In ds.Tables(0).Rows
                        dr("rep_deleted") = 0
                    Next
                Else
                    ds.Tables(0).Rows(0).Delete()
                End If

                If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                End If
                Return ""
            End If
        Catch ex As Exception
            Return ex.ToString()
        End Try
    End Function

    Public Function getTripCode() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("cod_codesICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try

        Return ds
    End Function

    Public Function UpdateCode(ByVal id As Integer, ByVal code As String, ByVal startTimeAM As String, ByVal breakTimeAM As String, ByVal endTimeAM As String) As Boolean
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("cod_codesICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & Me.iModId & " AND cod_id = " & id, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("cod_code") = code
                .Item("cod_startTimeAm") = startTimeAM
                .Item("cod_breakTimeAM") = breakTimeAM
                .Item("cod_endTimeAM") = endTimeAM
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteCodeFromGrid(ByVal id As Integer)
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("cod_codesICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & Me.iModId & " AND cod_id = " & id, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            If oSite.SiteSoftDelete Then
                With ds.Tables(0).Rows(0)
                    .Item("cod_hidden") = 1
                    .Item("cod_deleted") = 1
                End With
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Note"

    Public Function SaveNote(ByVal sDate As String, ByVal sNote As String, ByVal usr_id As Integer) As Integer
        Dim ds As New DataSet
        Try
            Dim sError As String
            Try
                If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If
            Catch ex As Exception
            End Try
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = oSite.ActivePage.PageId
                    .Item("mod_id") = iModId
                    .Item("rep_note") = sNote
                    .Item("rep_hidden") = 0
                    .Item("rep_deleted") = 0
                End With

                If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
                End If
                Return ds.Tables(0).Rows(0)("rep_id")
            Else
                If Not oDO.GetEmptyDataSet("rep_reportICTIME", "", ED, EC, ds) Then
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("sit_id") = oSite.SiteId
                        .Item("pag_id") = oSite.ActivePage.PageId
                        .Item("mod_id") = iModId
                        .Item("usr_id") = usr_id
                        .Item("rep_code") = ""
                        .Item("rep_startTimeAm") = ""
                        .Item("rep_breakTimeAm") = ""
                        .Item("rep_endTimeAm") = ""
                        .Item("rep_date") = sDate
                        .Item("rep_note") = sNote
                        .Item("rep_hidden") = 0
                        .Item("rep_deleted") = 0
                    End With
                    If Not oDO.SaveDataSet("", ED, EC, ds, True) Then
                    End If
                    Return ds.Tables(0).Rows(0)("rep_id")
                End If
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function getNote(ByVal sDate As String, ByVal usr_id As Integer) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " And usr_id= " & usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function DeleteNote(ByVal sDate As String, ByVal usr_id As Integer) As String
        Dim ds As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId & " AND usr_id = " & usr_id & " AND rep_date =  " & "'" & Trim(sDate) & "'", "", sError, ED, EC, ds) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Rows(0)("rep_note") = ""
                If Not oDO.SaveDataSet("", ED, EC, ds, False) Then
                End If
                Return ""
            End If
        Catch ex As Exception
            Return ex.ToString()
        End Try
    End Function

#End Region


    Public Function getTimeReport()

        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("rep_reportICTIME", "sit_id = " & oSite.SiteId & " AND mod_id = " & iModId, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try

        Return ds
    End Function


#End Region


End Class
