Imports iConsulting.iCMServer.iCDataManager
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Collections

Public MustInherit Class Mediagallery : Inherits clsSiteModuleControl

    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents TR1 As System.Web.UI.WebControls.TableRow
    Protected WithEvents TD1 As System.Web.UI.WebControls.TableCell
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
    Private oLang As New clsLanguageText
    Private al As New ArrayList
    Protected WithEvents SiteHeader As System.Web.UI.WebControls.PlaceHolder
    Public sEditText As String
    Protected Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Dim oMed As New clsMediagallery
        Dim oThumb As clsThumbnail
        Dim ds As New DataSet
        Dim dr As DataRow
        Try
            ds = oMed.GetDefinedDocuments(ModuleConfiguration.PageId, ModuleId, 0)
            Dim sSrc As String = Left(Request.Url.AbsoluteUri, (Len(Request.Url.AbsoluteUri) - InStr(StrReverse(Request.Url.AbsoluteUri), "/"))) & "/Desktop/Modules/Mediagallery/MediagalleryView.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CatId=0&DocId="
            Dim sDelete As String = Left(Request.Url.AbsoluteUri, (Len(Request.Url.AbsoluteUri) - InStr(StrReverse(Request.Url.AbsoluteUri), "/"))) & "/Desktop/Modules/Mediagallery/MediaGalleryEdit.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "&CatId=0&DocId="
            Dim sText As String
            Dim sCT As String
            Dim iWidth As Integer
            Dim iHeight As Integer
            al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Mediagallery")

            Dim co As Integer
            Dim by As Byte()
            Dim bb As System.Drawing.Bitmap
            Dim ss As System.IO.MemoryStream


            ' video, image, audio
            If clsSiteSecurity.HasEditPermissions(ModuleId) Then
                For Each dr In ds.Tables(0).Rows
                    ' Standard code
                    sText += "<IMG "
                    sText += "OnClick=window.open('" & sSrc & dr("doc_id") & "') "
                    Select Case Left(dr("doc_contenttype"), InStr(dr("doc_contenttype"), "/") - 1)
                        Case "image"
                            sText += "SRC='" & sSrc & dr("doc_id") & "' "

                            co = CType(dr("doc_contentsize"), Int32)
                            by = CType(dr("doc_content"), Byte())
                            If by.Length > 0 & co > 0 Then
                                ss = New System.IO.MemoryStream(CType(dr("doc_content"), Byte()), 0, dr("doc_contentsize"))
                                bb = New System.Drawing.Bitmap(ss)
                                oThumb = New clsThumbnail(100, 100, bb)
                                iWidth = oThumb.GetThumbWidth
                                iHeight = oThumb.GetThumbHeight
                            Else
                                sText += "SRC='Desktop/Modules/Mediagallery/Images/notmedia.gif' "
                                iWidth = 100
                                iHeight = 100
                            End If
                        Case "video"
                            sText += "SRC='Desktop/Modules/Mediagallery/Images/video.gif' "
                            iWidth = 100
                            iHeight = 100
                        Case "audio"
                            sText += "SRC='Desktop/Modules/Mediagallery/Images/audio.gif' "
                            iWidth = 100
                            iHeight = 100
                        Case Else
                            sText += "SRC='Desktop/Modules/Mediagallery/Images/notmedia.gif' "
                            iWidth = 100
                            iHeight = 100
                    End Select
                    sText += "ALT='" & dr("doc_name") & "' "
                    sText += "STYLE='cursor: hand' "
                    sText += "BORDER=0 WIDTH=" & iWidth.ToString & " HEIGHT=" & iHeight.ToString
                    sText += "> "
                    ' Delete code
                    sText += "<A "
                    sText += "HREF='" & sDelete & dr("doc_id") & "' "
                    sText += "> "
                    sText += Server.HtmlDecode(oLang.Find(al, "mediagallery_delete"))
                    sText += "</A> "
                Next
            Else
                For Each dr In ds.Tables(0).Rows
                    ' Standard code
                    sText += "<IMG "
                    sText += "OnClick=window.open('" & sSrc & dr("doc_id") & "') "
                    Select Case Left(dr("doc_contenttype"), InStr(dr("doc_contenttype"), "/") - 1)
                        Case "image"
                            sText += "SRC='" & sSrc & dr("doc_id") & "' "

                            co = CType(dr("doc_contentsize"), Int32)
                            by = CType(dr("doc_content"), Byte())
                            If by.Length > 0 & co > 0 Then
                                ss = New System.IO.MemoryStream(CType(dr("doc_content"), Byte()), 0, dr("doc_contentsize"))
                                bb = New System.Drawing.Bitmap(ss)
                                oThumb = New clsThumbnail(100, 100, bb)
                                iWidth = oThumb.GetThumbWidth
                                iHeight = oThumb.GetThumbHeight
                            Else
                                sText += "SRC='Desktop/Modules/Mediagallery/Images/notmedia.gif' "
                                iWidth = 100
                                iHeight = 100
                            End If
                        Case "video"
                                sText += "SRC='Desktop/Modules/Mediagallery/Images/video.gif' "
                                iWidth = 100
                                iHeight = 100
                        Case "audio"
                                sText += "SRC='Desktop/Modules/Mediagallery/Images/audio.gif' "
                                iWidth = 100
                                iHeight = 100
                        Case Else
                                sText += "SRC='Desktop/Modules/Mediagallery/Images/notmedia.gif' "
                                iWidth = 100
                                iHeight = 100
                    End Select
                    sText += "ALT='" & dr("doc_name") & "' "
                    sText += "STYLE='cursor: hand' "
                    sText += "BORDER=0 WIDTH=" & iWidth.ToString & " HEIGHT=" & iHeight.ToString
                    sText += "> "
                Next
            End If

            TD1.Text = sText
        Catch ex As Exception
            Response.Write(ex)
        End Try

    End Sub

End Class
