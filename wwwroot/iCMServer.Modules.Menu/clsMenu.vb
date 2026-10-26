Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls

Public Class clsMenu

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))

    Public Function GetSourceSubMenu(ByVal PageId As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   GetSourceSubMenu
        'Parameters:    -
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2003-02-26, Created 
        '               Johan Olofsson 2003-05-22, Edited
        '-------------------------------------------------------------------------

        Return SearchForSourceSubMenu(PageId)

    End Function

    Private Function SearchForSourceSubMenu(ByVal PageId As Integer) As String
        '-------------------------------------------------------------------------
        'Description:   SearchForSourceSubMenu
        'Parameters:    -
        'Returns:       String
        'Comments:      -
        'ToDo:          -
        'Revision:      Johan Olofsson 2003-02-26, Created 
        '               Johan Olofsson 2003-05-22, Edited
        '-------------------------------------------------------------------------

        ' Standard variables
        Dim Auth As String
        Dim dsPage As New DataSet
        Dim sError As String

        If Not oDO.GetDataSet("pag_page", "pag_id = " & PageId & " AND pag_deleted = 0", "", sError, ED, EC, dsPage) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If

        If dsPage.Tables.Count > 0 Then
            If dsPage.Tables(0).Rows.Count > 0 Then
                If dsPage.Tables(0).Rows(0)("pag_pageparentid") = 0 Then
                    Return dsPage.Tables(0).Rows(0)("pag_authorizedroles")
                Else
                    Auth = SearchForSourceSubMenu(dsPage.Tables(0).Rows(0)("pag_pageparentid"))
                End If
            Else
                Auth = "Superadmin;"
            End If
        Else
            Auth = "Superadmin;"
        End If

        Return Auth

    End Function

    Private Function SearchForSourceSubMenu2(ByVal PageId As Integer) As String

    End Function

End Class

