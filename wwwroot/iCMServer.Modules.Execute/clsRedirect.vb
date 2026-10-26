Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web
Imports System.Web.SessionState
Imports iConsulting
Imports iConsulting.iCMServer
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security
Imports System.io
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Services.Protocols
Imports System.Diagnostics

Public Class clsExecute

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function StartProcess(ByVal FileName As String, ByVal Arguments As String, ByVal WorkingDirectory As String) As Boolean
        Try
            Dim i As New ProcessStartInfo
            i.FileName = FileName
            i.Arguments = Arguments
            i.WorkingDirectory = WorkingDirectory
            i.WindowStyle = ProcessWindowStyle.Normal
            i.ErrorDialog = False
            Dim p As New Process
            p.StartInfo = i
            p.Start()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetExecute(ByVal ModId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New iConsulting.Library.Data.clsDefinedDataList
            oDefine.AddDefinedTableColumn("qui_url")
            If Not oDO.GetDefinedDataSet("qui_quicklinks", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_hidden = 0 AND qui_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetQuicklink(ByVal ModId As Integer, ByVal QuiId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND qui_id = " & QuiId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeleteQuicklink(ByVal ModId As Integer, ByVal PagId As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            If oSite.SiteSoftDelete Then
                ds.Tables(0).Rows(0)("qui_deleted") = 1
            Else
                ds.Tables(0).Rows(0).Delete()
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddQuicklink(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Url As String, ByVal Target As String, ByVal Order As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetEmptyDataSet("qui_quicklinks", "", ED, EC, ds) Then

            End If
            With ds.Tables(0).Rows(0)
                .Item("sit_id") = oSite.SiteId
                .Item("mod_id") = ModId
                .Item("pag_id") = PagId
                .Item("qui_title") = Title
                .Item("qui_description") = Description
                .Item("qui_url") = Url & "|" & Target
                .Item("qui_order") = Order
                .Item("qui_createddate") = Now.ToShortDateString
                .Item("qui_createdby") = HttpContext.Current.User.Identity.Name
                .Item("qui_updateddate") = Now.ToShortDateString
                .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                .Item("qui_hidden") = 0
                .Item("qui_deleted") = 0
            End With
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Exists(ByVal ModId As Integer, ByVal PagId As Integer) As Boolean
        Try
            Dim ds As DataSet = Me.GetExecute(ModId, PagId)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateQuicklink(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Url As String) As Boolean
        Dim ds As New DataSet
        Try
            If Exists(ModId, PagId) Then
                If Not oDO.GetDataSet("qui_quicklinks", "sit_id = " & oSite.SiteId & " AND mod_id = " & ModId & " AND pag_id = " & PagId, "", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("qui_url") = Url
                    .Item("qui_updateddate") = Now.ToShortDateString
                    .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                End With
            Else
                If Not oDO.GetEmptyDataSet("qui_quicklinks", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("mod_id") = ModId
                    .Item("pag_id") = PagId
                    .Item("qui_title") = ""
                    .Item("qui_description") = ""
                    .Item("qui_url") = Url
                    .Item("qui_order") = 0
                    .Item("qui_createddate") = Now.ToLongTimeString
                    .Item("qui_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("qui_updateddate") = Now.ToLongTimeString
                    .Item("qui_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("qui_hidden") = 0
                    .Item("qui_deleted") = 0
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetPages(ByVal sRoles As String) As DataSet
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            If Not oDO.GetDataSet("pag_page", "sit_id = " & oSite.SiteId, "pag_pageparentid,pag_order", "", ED, EC, ds) Then

            End If
            For Each dr In ds.Tables(0).Rows
                If CheckPagePermission(sRoles, dr("pag_authorizedroles")) Then
                    dr("pag_deleted") = False
                Else
                    dr("pag_deleted") = True
                End If
            Next

            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    ' --- Quick Diagnostics service-layer helpers, called from ExecuteEdit.aspx.vb ---

    Public Function RunDiagnosticCommand(ByVal Target As String) As Boolean
        Try
            Dim sArgs As String = String.Format("/c tracert -h 10 {0}", Target)
            Dim oInfo As New ProcessStartInfo("cmd.exe", sArgs)
            oInfo.UseShellExecute = False
            oInfo.CreateNoWindow = True
            Dim oProc As New Process
            oProc.StartInfo = oInfo
            ' SINK: PLANTED-VB-HR-258
            oProc.Start()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RunDiagnosticCommandSafe(ByVal Target As String) As Boolean
        Dim aAllowed As String() = {"localhost", "dbserver01", "webserver01", "appserver01"}
        If Array.IndexOf(aAllowed, Target) < 0 Then
            Return False
        End If
        Try
            Dim oInfo As New ProcessStartInfo("tracert.exe")
            oInfo.ArgumentList.Add("-h")
            oInfo.ArgumentList.Add("10")
            oInfo.ArgumentList.Add(Target)
            oInfo.UseShellExecute = False
            oInfo.CreateNoWindow = True
            Dim oProc As New Process
            oProc.StartInfo = oInfo
            ' SAFE_SINK: PLANTED-VB-HR-258-safe
            oProc.Start()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RunBulkPing(ByVal TargetsCsv As String) As Boolean
        Try
            Dim sArgs As String = "/c "
            Dim aTargets() As String = TargetsCsv.Split(New Char() {","c})
            Dim bFirst As Boolean = True
            For Each sTarget As String In aTargets
                If Not bFirst Then
                    sArgs &= " && "
                End If
                sArgs &= "ping -n 1 " & sTarget.Trim()
                bFirst = False
            Next
            Dim oInfo As New ProcessStartInfo("cmd.exe", sArgs)
            oInfo.UseShellExecute = False
            oInfo.CreateNoWindow = True
            Dim oProc As New Process
            oProc.StartInfo = oInfo
            ' SINK: PLANTED-VB-HR-259
            oProc.Start()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RunBulkPingSafe(ByVal TargetsCsv As String) As Boolean
        Dim aAllowed As String() = {"localhost", "dbserver01", "webserver01", "appserver01"}
        Dim aTargets() As String = TargetsCsv.Split(New Char() {","c})
        For Each sTarget As String In aTargets
            If Array.IndexOf(aAllowed, sTarget.Trim()) < 0 Then
                Return False
            End If
        Next
        Try
            For Each sTarget As String In aTargets
                Dim oInfo As New ProcessStartInfo("ping.exe")
                oInfo.ArgumentList.Add("-n")
                oInfo.ArgumentList.Add("1")
                oInfo.ArgumentList.Add(sTarget.Trim())
                oInfo.UseShellExecute = False
                oInfo.CreateNoWindow = True
                Dim oProc As New Process
                oProc.StartInfo = oInfo
                ' SAFE_SINK: PLANTED-VB-HR-259-safe
                oProc.Start()
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckPagePermission(ByVal sRoles As String, ByVal AuthorizedRoles As String) As Boolean
        Dim aPage As New System.Collections.ArrayList
        Dim aPages() As String
        Dim l As ListItem
        Dim page As String
        For Each page In AuthorizedRoles.Split(New Char() {";"c})
            aPage.Add(page)
        Next
        aPages = CType(aPage.ToArray(GetType(String)), String())


        Dim role As String
        Dim i As Integer
        For i = 0 To aPages.Length - 1
            For Each role In sRoles.Split(New Char() {";"c})
                If aPages(i).ToString = role.ToString Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

End Class
