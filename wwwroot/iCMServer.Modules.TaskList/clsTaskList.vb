Imports iConsulting.iCMServer.iCDataManager
Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports iConsulting.iCMServer

Public Class clsTaskList

    Private oDO As New iCDataManager.iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private ModId As Integer = 0
    Private m_IsAuthorized As Boolean = False

    Public Sub New(ByVal iModId As Integer)
        Me.ModId = iModId
        'Me.IsAuthorized = bAuthorized
    End Sub

    Public Property IsAuthorized() As Boolean 'behs ev ej???!!!
        Get
            Return m_IsAuthorized
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsAuthorized = Value
        End Set
    End Property

    ' /////

    Public Function GetTasksDependingOnUser() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Dim sWhere As String
        Try
            If clsSiteSecurity.IsInRole("Admins") Then
                Dim oUsr As New clsUser
                Dim roleStr As String = oUsr.GetRoles(HttpContext.Current.User.Identity.Name)
                sWhere = String.Empty
                For Each role As String In roleStr.Split(";")
                    If role.Length > 1 And role.ToLower <> "admins" Then sWhere += "sit_id = " & oSite.SiteId & " AND rol_hidden = 0 AND rol_deleted = 0 AND rol_name = '" & role & "' OR "
                Next
                If sWhere.Length > 3 Then sWhere = sWhere.Substring(0, sWhere.Length - 3)

                ds = New DataSet
                If Not oDO.GetDataSet("rol_roles", sWhere, String.Empty, sError, ED, EC, ds) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If

                sWhere = String.Empty
                For Each dt As DataTable In ds.Tables
                    For Each dr As DataRow In dt.Rows
                        sWhere += "sit_id = " & oSite.SiteId & " AND uro_hidden = 0 AND uro_deleted = 0 AND rol_id = " & dr("rol_id") & " OR "
                    Next
                Next
                If sWhere.Length > 3 Then sWhere = sWhere.Substring(0, sWhere.Length - 3)

                ds = New DataSet
                If Not oDO.GetDataSet("uro_userroles", sWhere, String.Empty, sError, ED, EC, ds) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If

                sWhere = String.Empty
                For Each dt As DataTable In ds.Tables
                    For Each dr As DataRow In dt.Rows
                        sWhere += "sit_id = " & oSite.SiteId & " AND usr_hidden = 0 AND usr_deleted = 0 AND usr_id = " & dr("usr_id") & " OR "
                    Next
                Next
                If sWhere.Length > 3 Then sWhere = sWhere.Substring(0, sWhere.Length - 3)

                ds = New DataSet
                If Not oDO.GetDataSet("usr_users", sWhere, String.Empty, sError, ED, EC, ds) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If

                sWhere = String.Empty
                For Each dt As DataTable In ds.Tables
                    For Each dr As DataRow In dt.Rows
                        sWhere += "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_hidden = 0 AND tas_deleted = 0" & _
                    " AND tas_createdby = '" & dr("usr_loginname") & "' OR "
                    Next
                Next
                If sWhere.Length > 3 Then sWhere = sWhere.Substring(0, sWhere.Length - 3)
            Else
                sWhere += "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_hidden = 0 AND tas_deleted = 0" & _
                    " AND tas_createdby = '" & HttpContext.Current.User.Identity.Name & "'"
            End If
            ds = New DataSet
            If Not oDO.GetDataSet("tas_tasklist", sWhere, "tas_duedate", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetTasks() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("tas_tasklist", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_hidden = 0 AND tas_deleted = 0", "tas_duedate", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetSingleTask(ByVal TasId As Integer) As DataRow
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("tas_tasklist", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_id = " & TasId.ToString(), "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0)
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub DeleteTask(ByVal TasId As Integer)
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("tas_tasklist", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_id = " & TasId.ToString(), "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("tas_deleted") = 1
                    End With
                End If
            End If
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddTask(ByVal moduleId As Integer, ByVal TasId As Integer, ByVal userName As String, ByVal title As String, ByVal startDate As DateTime, ByVal description As String, ByVal status As String, ByVal priority As String, ByVal assignedto As String, ByVal dueDate As DateTime, ByVal percentComplete As Integer) As Integer
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetEmptyDataSet("tas_tasklist", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId.ToString()
                .Item("pag_id") = oSite.ActivePage.PageId.ToString()
                .Item("mod_id") = moduleId.ToString()
                .Item("tas_title") = title
                .Item("tas_description") = description
                .Item("tas_assignedto") = assignedto
                .Item("tas_status") = status
                .Item("tas_priority") = priority
                .Item("tas_percentcomplete") = percentComplete
                .Item("tas_startdate") = startDate.ToString()
                .Item("tas_duedate") = dueDate.ToString()
                .Item("tas_createddate") = Now.ToString()
                .Item("tas_createdby") = HttpContext.Current.User.Identity.Name
                .Item("tas_updateddate") = Now.ToString()
                .Item("tas_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("tas_hidden") = 0
                .Item("tas_deleted") = 0
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Sub UpdateTask(ByVal moduleId As Integer, ByVal TasId As Integer, ByVal userName As String, ByVal title As String, ByVal startDate As DateTime, ByVal description As String, ByVal status As String, ByVal priority As String, ByVal assignedto As String, ByVal dueDate As DateTime, ByVal percentComplete As Integer)
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("tas_tasklist", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND tas_id = " & TasId.ToString(), "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("tas_title") = title
                .Item("tas_description") = description
                .Item("tas_assignedto") = assignedto
                .Item("tas_status") = status
                .Item("tas_priority") = priority
                .Item("tas_percentcomplete") = percentComplete
                .Item("tas_startdate") = startDate.ToString()
                .Item("tas_duedate") = dueDate.ToString()
                .Item("tas_updateddate") = Now.ToString()
                .Item("tas_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '/////

    'Public Function GetAllProjects() As DataSet
    '    Dim ds As New DataSet
    '    Dim sError As String
    '    Try
    '        If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_hidden = 0 AND prl_deleted = 0", "prl_month", sError, ED, EC, ds) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        ''''' Sort new
    '        ''''Dim First As New System.Collections.ArrayList
    '        ''''Dim Third As New System.Collections.ArrayList
    '        ''''For Each dri As DataRow In ds.Tables(0).Rows
    '        ''''    Dim _d As New DocumentItem
    '        ''''    _d.ID = dri("doc_id")
    '        ''''    _d.Name = dri("doc_name")
    '        ''''    _d.ContentSize = dri("doc_contentsize")
    '        ''''    _d.UpdatedDate = dri("doc_updateddate")
    '        ''''    First.Add(_d)
    '        ''''Next
    '        ''''Dim FileArray(First.Count - 1) As String
    '        ''''Dim i As Integer = 0
    '        ''''For Each d As DocumentItem In First
    '        ''''    FileArray(i) = d.Name
    '        ''''    i += 1
    '        ''''Next
    '        ''''Array.Sort(FileArray, New IConsultingFileComparer)
    '        ''''For i = FileArray.GetLowerBound(0) To FileArray.GetUpperBound(0)
    '        ''''    For Each d As DocumentItem In First
    '        ''''        If FileArray(i).ToLower = d.Name.ToLower Then
    '        ''''            Dim _d As New DocumentItem
    '        ''''            _d.ID = d.ID
    '        ''''            _d.Name = d.Name
    '        ''''            _d.ContentSize = d.ContentSize
    '        ''''            _d.UpdatedDate = d.UpdatedDate
    '        ''''            Third.Add(_d)
    '        ''''        End If
    '        ''''    Next
    '        ''''Next
    '        Return ds
    '    Catch ex As Exception
    '        Return New DataSet
    '    End Try
    'End Function

    'Public Function AddRow()
    '    Dim ds As New DataSet
    '    Dim sError As String
    '    Try
    '        If Not oDO.GetEmptyDataSet("prl_projectlistGAPRO", sError, ED, EC, ds) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        With ds.Tables(0).Rows(0)
    '            .Item("sit_id") = oSite.SiteId
    '            .Item("pag_id") = oSite.ActivePage.PageId
    '            .Item("mod_id") = Me.ModId
    '            .Item("prl_number") = 0
    '            .Item("prl_start") = ""
    '            .Item("prl_leader") = ""
    '            .Item("prl_participant") = ""
    '            .Item("prl_description") = ""
    '            .Item("prl_aim") = ""
    '            .Item("prl_month") = ""
    '            .Item("prl_createddate") = Now.ToLongTimeString
    '            .Item("prl_createdby") = HttpContext.Current.User.Identity.Name
    '            .Item("prl_updateddate") = Now.ToLongTimeString
    '            .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
    '            .Item("prl_hidden") = 0
    '            .Item("prl_deleted") = 0
    '        End With
    '        If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function UpdateProject(ByVal projId As Integer, ByVal nr As Integer, ByVal start As String, ByVal leader As String, ByVal participant As String, ByVal description As String, ByVal aim As String, ByVal month As String) As Boolean
    '    Dim ds As New DataSet
    '    Dim sError As String
    '    Dim pId As Integer = projId

    '    Try
    '        If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_id = " & pId, "", sError, ED, EC, ds) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        With ds.Tables(0).Rows(0)
    '            .Item("prl_number") = nr
    '            .Item("prl_start") = start
    '            .Item("prl_leader") = leader
    '            .Item("prl_participant") = participant
    '            .Item("prl_description") = description
    '            .Item("prl_aim") = aim
    '            .Item("prl_month") = month
    '            .Item("prl_updateddate") = Now.ToLongTimeString
    '            .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
    '        End With
    '        If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Function DeleteProject(ByVal projId As Integer, ByVal hidden As Integer, ByVal deleted As Integer)
    'Dim ds As New DataSet
    '    Dim sError As String
    '    Dim pId As Integer = projId

    '    Try
    '        If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_id = " & pId, "", sError, ED, EC, ds) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        With ds.Tables(0).Rows(0)
    '            .Item("prl_updateddate") = Now.ToLongTimeString
    '            .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
    '            .Item("prl_hidden") = hidden
    '            .Item("prl_deleted") = deleted
    '        End With
    '        If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
    '            System.Diagnostics.Debug.WriteLine(sError)
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

End Class

'Public Class ProjectItem
'    Public ID As String
'    Public Name As String
'    Public ContentSize As Integer
'    Public UpdatedDate As String
'End Class