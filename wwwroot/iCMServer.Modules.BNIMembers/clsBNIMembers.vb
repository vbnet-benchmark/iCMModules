Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsBNIMembers

    Private oDO As New iCDataObject
    Private oCrypto As New clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function Exists(ByVal PagId As Integer, ByVal ModId As Integer) As Integer
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("bme_id")
            If Not oDO.GetDefinedDataSet("bme_bnimembers", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId, "", "", ED, EC, ds) Then

            End If
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)("bme_id")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetMember(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("bme_id")
            oDefine.AddDefinedTableColumn("sit_id")
            oDefine.AddDefinedTableColumn("pag_id")
            oDefine.AddDefinedTableColumn("mod_id")
            oDefine.AddDefinedTableColumn("bme_name")
            oDefine.AddDefinedTableColumn("bme_phone")
            oDefine.AddDefinedTableColumn("bme_mail")
            oDefine.AddDefinedTableColumn("bme_web")
            oDefine.AddDefinedTableColumn("bme_street")
            oDefine.AddDefinedTableColumn("bme_pcode")
            oDefine.AddDefinedTableColumn("bme_city")
            oDefine.AddDefinedTableColumn("bme_text")
            oDefine.AddDefinedTableColumn("bme_hook")
            oDefine.AddDefinedTableColumn("bme_updateddate")
            oDefine.AddDefinedTableColumn("bme_logocontentsize")
            oDefine.AddDefinedTableColumn("bme_mecontentsize")
            If Not oDO.GetDefinedDataSet("bme_bnimembers", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function GetPicture(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer, ByVal Type As String) As DataSet
        Dim ds As New DataSet
        Try
            Select Case LCase(Type)
                Case "logo"
                    Dim oDefine As New clsDefinedDataList
                    oDefine.AddDefinedTableColumn("bme_logocontent")
                    oDefine.AddDefinedTableColumn("bme_logocontenttype")
                    oDefine.AddDefinedTableColumn("bme_logocontentsize")
                    If Not oDO.GetDefinedDataSet("bme_bnimembers", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

                    End If
                Case "me"
                    Dim oDefine As New clsDefinedDataList
                    oDefine.AddDefinedTableColumn("bme_mecontent")
                    oDefine.AddDefinedTableColumn("bme_mecontenttype")
                    oDefine.AddDefinedTableColumn("bme_mecontentsize")
                    If Not oDO.GetDefinedDataSet("bme_bnimembers", oDefine.DataSet, "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

                    End If
            End Select
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function DeletePicture(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer, ByVal Type As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("bme_bnimembers", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

            End If
            Select Case LCase(Type)
                Case "logo"
                    With ds.Tables(0).Rows(0)
                        '.Item("bme_logocontent") = Nothing
                        '.Item("bme_logocontenttype") = 0
                        .Item("bme_logocontentsize") = 0
                    End With
                Case "me"
                    With ds.Tables(0).Rows(0)
                        '.Item("bme_mecontent") = Nothing
                        '.Item("bme_mecontenttype") = 0
                        .Item("bme_mecontentsize") = 0
                    End With
            End Select
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateLogo(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentSize As Integer) As Integer
        Dim ds As New DataSet
        Try
            If BmeId = 0 Then
                If Not oDO.GetEmptyDataSet("bme_bnimembers", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = PagId
                    .Item("mod_id") = ModId
                    .Item("bme_logocontent") = Content
                    .Item("bme_logocontenttype") = ContentType
                    .Item("bme_logocontentsize") = ContentSize
                    .Item("bme_mecontentsize") = 0
                End With
            Else
                If Not oDO.GetDataSet("bme_bnimembers", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("bme_logocontent") = Content
                    .Item("bme_logocontenttype") = ContentType
                    .Item("bme_logocontentsize") = ContentSize
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return ds.Tables(0).Rows(0)("bme_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateMe(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer, ByVal Content As Byte(), ByVal ContentType As String, ByVal ContentSize As Integer) As Integer
        Dim ds As New DataSet
        Try
            If BmeId = 0 Then
                If Not oDO.GetEmptyDataSet("bme_bnimembers", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = PagId
                    .Item("mod_id") = ModId
                    .Item("bme_logocontentsize") = 0
                    .Item("bme_mecontent") = Content
                    .Item("bme_mecontenttype") = ContentType
                    .Item("bme_mecontentsize") = ContentSize
                End With
            Else
                If Not oDO.GetDataSet("bme_bnimembers", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("bme_mecontent") = Content
                    .Item("bme_mecontenttype") = ContentType
                    .Item("bme_mecontentsize") = ContentSize
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return ds.Tables(0).Rows(0)("bme_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function UpdateText(ByVal PagId As Integer, ByVal ModId As Integer, ByVal BmeId As Integer, ByVal Name As String, ByVal Phone As String, ByVal Mail As String, ByVal Web As String, ByVal Street As String, ByVal Pcode As String, ByVal City As String, ByVal Text As String, ByVal Hook As String, ByVal User As String) As Integer
        Dim ds As New DataSet
        Try
            If BmeId = 0 Then
                If Not oDO.GetEmptyDataSet("bme_bnimembers", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("pag_id") = PagId
                    .Item("mod_id") = ModId
                    .Item("bme_name") = Name
                    .Item("bme_phone") = Phone
                    .Item("bme_mail") = Mail
                    .Item("bme_web") = Web
                    .Item("bme_street") = Street
                    .Item("bme_pcode") = Pcode
                    .Item("bme_city") = City
                    .Item("bme_text") = Text
                    .Item("bme_hook") = Hook
                    .Item("bme_logocontentsize") = 0
                    .Item("bme_mecontentsize") = 0
                    .Item("bme_createddate") = Now.ToLongTimeString
                    .Item("bme_createdby") = User
                    .Item("bme_updateddate") = Now.ToLongTimeString
                    .Item("bme_updatedby") = User
                End With
            Else
                If Not oDO.GetDataSet("bme_bnimembers", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND bme_id = " & BmeId, "", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("bme_name") = Name
                    .Item("bme_phone") = Phone
                    .Item("bme_mail") = Mail
                    .Item("bme_web") = Web
                    .Item("bme_street") = Street
                    .Item("bme_pcode") = Pcode
                    .Item("bme_city") = City
                    .Item("bme_text") = Text
                    .Item("bme_hook") = Hook
                    .Item("bme_updateddate") = Now.ToLongTimeString
                    .Item("bme_updatedby") = User
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, True) Then

            End If
            Return ds.Tables(0).Rows(0)("bme_id")
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class
