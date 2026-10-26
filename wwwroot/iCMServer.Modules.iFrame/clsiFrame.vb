Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI.Page
Imports System.Web

Public Class clsiFrame

    Protected oDO As New iCDataObject
    Protected oCrypto As New clsCrypto
    Protected ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Protected EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Protected oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function UpdateiFrame(ByVal ModId As Integer, ByVal PagId As Integer, ByVal Title As String, ByVal Description As String, ByVal Url As String, ByVal Target As String, ByVal Width As String, ByVal Height As String) As Boolean
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("ifr_iframe", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND ifr_hidden = 0 AND ifr_deleted = 0", "", "", ED, EC, ds) Then

            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("ifr_title") = Title
                        .Item("ifr_description") = Description
                        .Item("ifr_url") = Url
                        .Item("ifr_target") = Target
                        .Item("ifr_width") = Width
                        .Item("ifr_height") = Height
                        .Item("ifr_updateddate") = Now.ToShortDateString
                        .Item("ifr_updatedby") = HttpContext.Current.User.Identity.Name
                    End With
                Else
                    If Not oDO.GetEmptyDataSet("ifr_iframe", "", ED, EC, ds) Then

                    End If
                    With ds.Tables(0).Rows(0)
                        .Item("sit_id") = oSite.SiteId
                        .Item("mod_id") = ModId
                        .Item("pag_id") = PagId
                        .Item("ifr_title") = Title
                        .Item("ifr_description") = Description
                        .Item("ifr_url") = Url
                        .Item("ifr_target") = Target
                        .Item("ifr_width") = Width
                        .Item("ifr_height") = Height
                        .Item("ifr_createddate") = Now.ToShortDateString
                        .Item("ifr_createdby") = HttpContext.Current.User.Identity.Name
                        .Item("ifr_updateddate") = Now.ToShortDateString
                        .Item("ifr_updatedby") = HttpContext.Current.User.Identity.Name
                        .Item("ifr_hidden") = 0
                        .Item("ifr_deleted") = 0
                    End With
                End If
            Else
                If Not oDO.GetEmptyDataSet("ifr_iframe", "", ED, EC, ds) Then

                End If
                With ds.Tables(0).Rows(0)
                    .Item("sit_id") = oSite.SiteId
                    .Item("mod_id") = ModId
                    .Item("pag_id") = PagId
                    .Item("ifr_title") = Title
                    .Item("ifr_description") = Description
                    .Item("ifr_url") = Url
                    .Item("ifr_target") = Target
                    .Item("ifr_width") = Width
                    .Item("ifr_height") = Height
                    .Item("ifr_createddate") = Now.ToShortDateString
                    .Item("ifr_createdby") = HttpContext.Current.User.Identity.Name
                    .Item("ifr_updateddate") = Now.ToShortDateString
                    .Item("ifr_updatedby") = HttpContext.Current.User.Identity.Name
                    .Item("ifr_hidden") = 0
                    .Item("ifr_deleted") = 0
                End With
            End If
            If Not oDO.SaveDataSet("", ED, EC, ds, False) Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetiFrame(ByVal ModId As Integer, ByVal PagId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("ifr_iframe", "sit_id = " & oSite.SiteId & " AND pag_id = " & PagId & " AND mod_id = " & ModId & " AND ifr_hidden = 0 AND ifr_deleted = 0", "", "", ED, EC, ds) Then

            End If
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

End Class

' Embed-target resolvers, used by iFrame.ascx.vb's admin "quick preview"
' feature (PreviewEmbed/PreviewEmbedSafe querystring values) - the direct
' resolver (below) resolves the raw requested target straight into a virtual
' path; the allow-list resolver maps it through a fixed allow-list instead.
' Both flows pass their resolved path into the same Server.Execute sink
' through a base-typed reference, so which behaviour actually applies
' depends on which concrete resolver was instantiated at the call site.
Public MustInherit Class clsIcmEmbedTargetResolverBase
    Public MustOverride Function ResolveEmbedPath(ByVal RequestedTarget As String) As String
End Class

Public Class clsIcmDirectEmbedTargetResolver
    Inherits clsIcmEmbedTargetResolverBase

    Public Overrides Function ResolveEmbedPath(ByVal RequestedTarget As String) As String
        Return "Server/Modules/" & RequestedTarget & "/Default.aspx"
    End Function
End Class

Public Class clsIcmAllowListEmbedTargetResolver
    Inherits clsIcmEmbedTargetResolverBase

    Public Overrides Function ResolveEmbedPath(ByVal RequestedTarget As String) As String
        Dim oAllowed As New System.Collections.Specialized.NameValueCollection
        oAllowed.Add("calendar", "Server/Modules/Calendar/Default.aspx")
        oAllowed.Add("notice", "Server/Modules/Notice/Default.aspx")
        Return oAllowed(LCase(RequestedTarget))
    End Function
End Class
