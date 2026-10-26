Imports iConsulting.iCMServer.iCDataManager
Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsProjectList

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

    Public Function GetAllProjects() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_hidden = 0 AND prl_deleted = 0", "prl_month", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            ''''' Sort new
            ''''Dim First As New System.Collections.ArrayList
            ''''Dim Third As New System.Collections.ArrayList
            ''''For Each dri As DataRow In ds.Tables(0).Rows
            ''''    Dim _d As New DocumentItem
            ''''    _d.ID = dri("doc_id")
            ''''    _d.Name = dri("doc_name")
            ''''    _d.ContentSize = dri("doc_contentsize")
            ''''    _d.UpdatedDate = dri("doc_updateddate")
            ''''    First.Add(_d)
            ''''Next
            ''''Dim FileArray(First.Count - 1) As String
            ''''Dim i As Integer = 0
            ''''For Each d As DocumentItem In First
            ''''    FileArray(i) = d.Name
            ''''    i += 1
            ''''Next
            ''''Array.Sort(FileArray, New IConsultingFileComparer)
            ''''For i = FileArray.GetLowerBound(0) To FileArray.GetUpperBound(0)
            ''''    For Each d As DocumentItem In First
            ''''        If FileArray(i).ToLower = d.Name.ToLower Then
            ''''            Dim _d As New DocumentItem
            ''''            _d.ID = d.ID
            ''''            _d.Name = d.Name
            ''''            _d.ContentSize = d.ContentSize
            ''''            _d.UpdatedDate = d.UpdatedDate
            ''''            Third.Add(_d)
            ''''        End If
            ''''    Next
            ''''Next
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function AddRow()
        Dim ds As New DataSet
        Dim sError As String
        Try
            If Not oDO.GetEmptyDataSet("prl_projectlistGAPRO", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("pag_id") = oSite.ActivePage.PageId
                .Item("mod_id") = Me.ModId
                .Item("prl_number") = 0
                .Item("prl_start") = ""
                .Item("prl_leader") = ""
                .Item("prl_participant") = ""
                .Item("prl_description") = ""
                .Item("prl_aim") = ""
                .Item("prl_month") = ""
                .Item("prl_createddate") = Now.ToLongTimeString
                .Item("prl_createdby") = HttpContext.Current.User.Identity.Name
                .Item("prl_updateddate") = Now.ToLongTimeString
                .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("prl_hidden") = 0
                .Item("prl_deleted") = 0
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function   

    Public Function UpdateProject(ByVal projId As Integer, ByVal nr As Integer, ByVal start As String, ByVal leader As String, ByVal participant As String, ByVal description As String, ByVal aim As String, ByVal month As String) As Boolean
        Dim ds As New DataSet
        Dim sError As String
        Dim pId As Integer = projId

        Try
            If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_id = " & pId, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("prl_number") = nr
                .Item("prl_start") = start
                .Item("prl_leader") = leader
                .Item("prl_participant") = participant
                .Item("prl_description") = description
                .Item("prl_aim") = aim
                .Item("prl_month") = month
                .Item("prl_updateddate") = Now.ToLongTimeString
                .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function DeleteProject(ByVal projId As Integer, ByVal hidden As Integer, ByVal deleted As Integer)
        Dim ds As New DataSet
        Dim sError As String
        Dim pId As Integer = projId

        Try
            If Not oDO.GetDataSet("prl_projectlistGAPRO", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND prl_id = " & pId, "", sError, ED, EC, ds) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            With ds.Tables(0).Rows(0)
                .Item("prl_updateddate") = Now.ToLongTimeString
                .Item("prl_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("prl_hidden") = hidden
                .Item("prl_deleted") = deleted
            End With
            If Not oDO.SaveDataSet(sError, ED, EC, ds, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class

Public Class ProjectItem
    Public ID As String
    Public Name As String
    Public ContentSize As Integer
    Public UpdatedDate As String
End Class