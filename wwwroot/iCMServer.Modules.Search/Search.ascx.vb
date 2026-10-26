Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls

Public Class Search : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents ResultHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents ScriptHolder As System.Web.UI.WebControls.PlaceHolder

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private sModules As String
    Private sResultCount As String
    Private sHeader1 As String
    Private sHeader2 As String
    Private sHeader3 As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Call BindData()
        Call RenderScript()
    End Sub

    Private Sub RenderScript()
        Dim Script As String
        Script += "<script language=""javascript"">" & vbCrLf
        Script += "  function SetSearchField(){" & vbCrLf
        Script += "    if(document.all){" & vbCrLf
        Script += "      if(event.keyCode == 13){" & vbCrLf
        Script += "        var e1 = document.all(""" & btnSearch.ClientID.ToString & """);" & vbCrLf
        Script += "        e1.focus();" & vbCrLf
        Script += "      }" & vbCrLf
        Script += "    }" & vbCrLf
        Script += "  }" & vbCrLf
        Script += "  try{" & vbCrLf
        Script += "    var e1 = document.all(""" & txtSearch.ClientID.ToString & """);" & vbCrLf
        Script += "    e1.focus();" & vbCrLf
        Script += "  }" & vbCrLf
        Script += "  catch(e){}" & vbCrLf
        Script += "</script>"
        ScriptHolder.Controls.Add(New System.Web.UI.LiteralControl(Script))
    End Sub

    Private Sub BindData()
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oLang As New clsLanguageText
        Dim al As New ArrayList
        al = oLang.GetLanguageTextByLocation(oSite.Language, "iConsulting.iCMServer.Modules.Search")

        btnSearch.Text = Server.HtmlDecode(oLang.Find(al, "search_search"))
        sModules = Server.HtmlDecode(oLang.Find(al, "search_modules"))
        sResultCount = Server.HtmlDecode(oLang.Find(al, "search_resultcount"))
        sHeader1 = Server.HtmlDecode(oLang.Find(al, "search_header1"))
        sHeader2 = Server.HtmlDecode(oLang.Find(al, "search_header2"))
        sHeader3 = Server.HtmlDecode(oLang.Find(al, "search_header3"))

        txtSearch.Attributes.Add("onkeydown", "SetSearchField()")

    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim oSea As New clsSearch(ModuleId, clsSiteSecurity.HasEditPermissions(ModuleId))
        If Not txtSearch.Text = "" Then
            Dim ds As DataSet = oSea.GenericSearch(txtSearch.Text)
            Dim TotalCount As Integer = 0
            Dim sTemp As String = ""
            Dim myTable As Table
            Dim myRow As TableRow
            Dim myCell As TableCell
            For Each dt As DataTable In ds.Tables
                For Each dr As DataRow In dt.Rows
                    TotalCount += dr("WordCount")
                Next
            Next
            If Not TotalCount = 0 Then
                myTable = New Table
                myTable.Width = Unit.Percentage(98)
                myTable.BorderWidth = Unit.Point(0)
                myTable.BackColor = System.Drawing.Color.White
                myRow = New TableRow
                myCell = New TableCell
                myCell.BackColor = System.Drawing.Color.White 'System.Drawing.Color.Blue
                myCell.ForeColor = System.Drawing.Color.Black  'System.Drawing.Color.White
                myCell.Style.Add("BORDER-BOTTOM", "black 1px solid")
                myCell.Style.Add("BORDER-TOP", "black 1px solid")
                myCell.Style.Add("BORDER-LEFT", "black 1px solid")
                myCell.Style.Add("BORDER-RIGHT", "black 1px solid")
                myCell.Font.Name = "Verdana"
                myCell.Font.Size = FontUnit.XSmall
                myCell.Text = sHeader1 & " <b>" & TotalCount.ToString & "</b> " & sHeader2 & " <b>" & txtSearch.Text & "</b> " & sHeader3 & "..."
                myRow.Controls.Add(myCell)
                myTable.Controls.Add(myRow)
                myRow = New TableRow
                myCell = New TableCell
                myCell.Text = "&nbsp;"
                myRow.Controls.Add(myCell)
                myTable.Controls.Add(myRow)
                myRow = New TableRow
                myCell = New TableCell
                myCell.Text = "&nbsp;"
                myRow.Controls.Add(myCell)
                myTable.Controls.Add(myRow)
                ResultHolder.Controls.Add(myTable)
            End If
            For Each dt As DataTable In ds.Tables
                For Each dr As DataRow In dt.Rows
                    Dim sPage As String = Mid(dt.TableName, 1, InStr(dt.TableName, "-") - 1)
                    sTemp = CType(dr("EncodedDisplayText"), String)
                    sTemp = Replace(sTemp, txtSearch.Text, "<b>" & txtSearch.Text & "</b>")

                    myTable = New Table
                    myTable.Width = Unit.Percentage(98)
                    myTable.BorderWidth = Unit.Point(0)
                    myTable.BackColor = System.Drawing.Color.White

                    ' Rubrik
                    myRow = New TableRow
                    myCell = New TableCell
                    myCell.ColumnSpan = 2
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Blue
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.Small
                    myCell.Font.Underline = True
                    myCell.Text = "<a href=""icm.aspx?PageId=" & dr("PagId") & """ style=""color:Blue;text-decoration:underline;"">" & sPage & "</a>"
                    myRow.Controls.Add(myCell)
                    myTable.Controls.Add(myRow)

                    ' Text
                    myRow = New TableRow
                    myCell = New TableCell
                    myCell.ColumnSpan = 2
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Black
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.XSmall
                    myCell.Text = IIf(sTemp.Length <= 300, sTemp & "...", Left(sTemp, 300) & "...")
                    myRow.Controls.Add(myCell)
                    myTable.Controls.Add(myRow)

                    ' Modul
                    myRow = New TableRow
                    myCell = New TableCell
                    myCell.Width = Unit.Percentage(20)
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Black
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.XSmall
                    myCell.Text = sModules & ": "
                    myRow.Controls.Add(myCell)
                    myCell = New TableCell
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Green
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.XSmall
                    myCell.Font.Underline = True
                    myCell.Text = "<a href=""icm.aspx?PageId=" & dr("PagId") & """ style=""color:Green;text-decoration:underline;"">" & Mid(dt.TableName, InStr(dt.TableName, "-") + 1, ((Len(dt.TableName) - InStr(dt.TableName, "-") + 1) - InStr(StrReverse(dt.TableName), "-") + 1) - 2) & "</a>"
                    myRow.Controls.Add(myCell)
                    myTable.Controls.Add(myRow)

                    ' Antal träffar
                    myRow = New TableRow
                    myCell = New TableCell
                    myCell.Width = Unit.Percentage(20)
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Black
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.XSmall
                    myCell.Text = sResultCount & ": "
                    myRow.Controls.Add(myCell)
                    myCell = New TableCell
                    myCell.BackColor = System.Drawing.Color.White
                    myCell.ForeColor = System.Drawing.Color.Gray
                    myCell.Font.Name = "Verdana"
                    myCell.Font.Size = FontUnit.XSmall
                    myCell.Text = dr("WordCount")
                    myRow.Controls.Add(myCell)
                    myTable.Controls.Add(myRow)

                    ' Space
                    myRow = New TableRow
                    myCell = New TableCell
                    myCell.ColumnSpan = 2
                    myCell.Text = "&nbsp;"
                    myRow.Controls.Add(myCell)
                    myTable.Controls.Add(myRow)
                    ResultHolder.Controls.Add(myTable)

                Next
            Next
        End If

    End Sub

End Class
