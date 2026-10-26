Imports System.Web
Imports System.Data
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Globalization


Public Class NorskFilmWizard : Inherits clsSiteModuleControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Header1 As System.Web.UI.WebControls.Label
    Protected WithEvents Text1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlStep1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlStep2 As System.Web.UI.WebControls.Panel

    Protected WithEvents pnlStep3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlStep4 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlStep5 As System.Web.UI.WebControls.Panel
    Protected WithEvents lnlStep1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkStep2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkStep3 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkStep4 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkStep5 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents pnlText1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText4 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText5 As System.Web.UI.WebControls.Panel
    Protected WithEvents lnkStep1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbl1Step3 As System.Web.UI.WebControls.Label
    Protected WithEvents Box1Step3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl1Step4 As System.Web.UI.WebControls.Label
    Protected WithEvents Box1Step4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Box1Step5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlStep1Text As System.Web.UI.WebControls.Panel
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlStep4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbl1Step5 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlText1_1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText2_2 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText3_3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText4_4 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText5_5 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlText2 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblStepRub As System.Web.UI.WebControls.Label
    Protected WithEvents btnTest As System.Web.UI.WebControls.Button
    Protected WithEvents pnlAdministrera As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlAnsokningar As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lnkAdministrera As System.Web.UI.WebControls.HyperLink
    Protected WithEvents pnlApplicaton As System.Web.UI.WebControls.Panel
    Protected WithEvents dgAccount As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnGo As System.Web.UI.WebControls.Button
    Protected WithEvents lblApplicaton1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApplication1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblApplicaton2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApplication2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblApplicaton3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApplication3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkApplicationBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Minimizer As System.Web.UI.HtmlControls.HtmlGenericControl

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private selectedWeek As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Minimizer.ID = ModuleId
        Response.Write("<link rel='stylesheet' type='text/css' href='Desktop\Modules\NorskFilmWizard\NorskFilmWizard.css'></link>")

        If Not Page.IsPostBack Then
            setVisible()
            If Request("a") = "true" And Request("nor_id") = Nothing Then
                getApplication()
            ElseIf Request("a") = "true" And Not Request("nor_id") = Nothing Then
                getApplicationDetails()
            End If


        Else
            lblStepRub.Text = "Inngangsside"
        End If

        If Not clsSiteSecurity.HasEditPermissions(ModuleId) Then
            lnkAdministrera.Visible = False
        Else
            lnkAdministrera.Visible = True
            lnkAdministrera.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&a=true"
        End If

        Dim scriptString As String
        scriptString = "<script language=JavaScript> function OPENNEW() { window.open('Desktop/Modules/NorskFilmWizard/LiteDocumentsUpload.aspx?PageId=" & ModuleConfiguration.PageId & "&ModId=" & ModuleId & "','Appointment','width=500,height=200')}</script>"
        If (Not Page.IsClientScriptBlockRegistered("OPENNEWSCRIPT" & ModuleId)) Then
            Page.RegisterClientScriptBlock("OPENNEWSCRIPT" & ModuleId, scriptString)
        End If

        Dim sScript As String
        sScript = "OPENNEW" & ModuleId & "();"
        btnTest.Attributes.Add("onclick", "OPENNEW();")



    End Sub

    Private Sub setVisible()

        'pnlText1.Visible = False
        'pnlText2.Visible = False
        'pnlText3.Visible = False
        'pnlText4.Visible = False
        'pnlText5.Visible = False

        pnlStep1.Visible = True
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = False

        pnlText1.CssClass = "SelectedText"
        pnlText2.CssClass = "NotSelectedText"
        pnlText3.CssClass = "NotSelectedText"
        pnlText4.CssClass = "NotSelectedText"
        pnlText5.CssClass = "NotSelectedText"

        pnlText1_1.CssClass = "SelectedText"
        pnlText2_2.CssClass = "NotSelectedText"
        pnlText3_3.CssClass = "NotSelectedText"
        pnlText4_4.CssClass = "NotSelectedText"
        pnlText5_5.CssClass = "NotSelectedText"

        lnkStep1.CssClass = "SelectedText"
        lnkStep2.CssClass = "NotSelectedText"
        lnkStep3.CssClass = "NotSelectedText"
        lnkStep4.CssClass = "NotSelectedText"
        lnkStep5.CssClass = "NotSelectedText"


    End Sub

    Private Sub BindData()
        Try
            ' Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            ' Dim oBB As New clsBB(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkStep1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkStep1.Click

        lblStepRub.Text = "1. Inngangsside"

        pnlStep1.Visible = True
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = False

        pnlText1.CssClass = "SelectedTextRub"
        pnlText2.CssClass = "NotSelectedText"
        pnlText3.CssClass = "NotSelectedText"
        pnlText4.CssClass = "NotSelectedText"
        pnlText5.CssClass = "NotSelectedText"

        pnlText1_1.CssClass = "SelectedText"
        pnlText2_2.CssClass = "NotSelectedText"
        pnlText3_3.CssClass = "NotSelectedText"
        pnlText4_4.CssClass = "NotSelectedText"
        pnlText5_5.CssClass = "NotSelectedText"

        lnkStep1.CssClass = "SelectedText"
        lnkStep2.CssClass = "NotSelectedText"
        lnkStep3.CssClass = "NotSelectedText"
        lnkStep4.CssClass = "NotSelectedText"
        lnkStep5.CssClass = "NotSelectedText"

    End Sub
 

    Private Sub lnkStep2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkStep2.Click

        lblStepRub.Text = "2. Kontaktinformasjon"

        pnlStep1.Visible = False
        pnlStep2.Visible = True
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = False

        pnlText1.CssClass = "NotSelectedText"
        pnlText2.CssClass = "SelectedTextRub"
        pnlText3.CssClass = "NotSelectedText"
        pnlText4.CssClass = "NotSelectedText"
        pnlText5.CssClass = "NotSelectedText"

        pnlText1_1.CssClass = "NotSelectedText"
        pnlText2_2.CssClass = "SelectedText"
        pnlText3_3.CssClass = "NotSelectedText"
        pnlText4_4.CssClass = "NotSelectedText"
        pnlText5_5.CssClass = "NotSelectedText"

        lnkStep1.CssClass = "NotSelectedText"
        lnkStep2.CssClass = "SelectedText"
        lnkStep3.CssClass = "NotSelectedText"
        lnkStep4.CssClass = "NotSelectedText"
        lnkStep5.CssClass = "NotSelectedText"

    End Sub

    Private Sub lnkStep3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkStep3.Click

        lblStepRub.Text = "3. Fylle inn"

        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = True
        pnlStep4.Visible = False
        pnlStep5.Visible = False

        pnlText1.CssClass = "NotSelectedText"
        pnlText2.CssClass = "NotSelectedText"
        pnlText3.CssClass = "SelectedTextRub"
        pnlText4.CssClass = "NotSelectedText"
        pnlText5.CssClass = "NotSelectedText"

        pnlText1_1.CssClass = "NotSelectedText"
        pnlText2_2.CssClass = "NotSelectedText"
        pnlText3_3.CssClass = "SelectedText"
        pnlText4_4.CssClass = "NotSelectedText"
        pnlText5_5.CssClass = "NotSelectedText"

        lnkStep1.CssClass = "NotSelectedText"
        lnkStep2.CssClass = "NotSelectedText"
        lnkStep3.CssClass = "SelectedText"
        lnkStep4.CssClass = "NotSelectedText"
        lnkStep5.CssClass = "NotSelectedText"

    End Sub

    Private Sub lnkStep4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkStep4.Click

        lblStepRub.Text = "4. Ladde opp"
        pnlText1.CssClass = "NotSelectedText"
        pnlText2.CssClass = "NotSelectedText"
        pnlText3.CssClass = "NotSelectedText"
        pnlText4.CssClass = "SelectedTextRub"
        pnlText5.CssClass = "NotSelectedText"

        pnlText1_1.CssClass = "NotSelectedText"
        pnlText2_2.CssClass = "NotSelectedText"
        pnlText3_3.CssClass = "NotSelectedText"
        pnlText4_4.CssClass = "SelectedText"
        pnlText5_5.CssClass = "NotSelectedText"

        lnkStep1.CssClass = "NotSelectedText"
        lnkStep2.CssClass = "NotSelectedText"
        lnkStep3.CssClass = "NotSelectedText"
        lnkStep4.CssClass = "SelectedText"
        lnkStep5.CssClass = "NotSelectedText"

        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = True
        pnlStep5.Visible = False

    End Sub

    Private Sub lnkStep5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkStep5.Click

        lblStepRub.Text = "5. Oppsummering"

        pnlText1.CssClass = "NotSelectedText"
        pnlText2.CssClass = "NotSelectedText"
        pnlText3.CssClass = "NotSelectedText"
        pnlText4.CssClass = "NotSelectedText"
        pnlText5.CssClass = "SelectedText"

        pnlText1_1.CssClass = "NotSelectedText"
        pnlText2_2.CssClass = "NotSelectedText"
        pnlText3_3.CssClass = "NotSelectedText"
        pnlText4_4.CssClass = "NotSelectedText"
        pnlText5_5.CssClass = "SelectedTextRub"

        lnkStep1.CssClass = "NotSelectedText"
        lnkStep2.CssClass = "NotSelectedText"
        lnkStep3.CssClass = "NotSelectedText"
        lnkStep4.CssClass = "NotSelectedText"
        lnkStep5.CssClass = "SelectedText"

        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = True

    End Sub

    Private Sub getApplicationDetails()
        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = False
        pnlText1.Visible = False
        pnlText1_1.Visible = False
        pnlText2.Visible = False
        pnlText2_2.Visible = False
        pnlText3.Visible = False
        pnlText3_3.Visible = False
        pnlText4.Visible = False
        pnlText4_4.Visible = False
        pnlText5.Visible = False
        pnlText5_5.Visible = False
        lnkStep1.Visible = False
        lnkStep2.Visible = False
        lnkStep3.Visible = False
        lnkStep4.Visible = False
        lnkStep5.Visible = False
        pnlInfo.Visible = False

        pnlAdministrera.Visible = True
        pnlApplicaton.Visible = True
        dgAccount.Visible = False
        PopulateDetails()

        lnkApplicationBack.Visible = True
        lnkApplicationBack.NavigateUrl = "~/icm.aspx?PageId=" & ModuleConfiguration.PageId & "&a=true"


    End Sub

    Private Sub PopulateDetails()

        Dim iStatus As Integer
        Dim ds As New DataSet
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oObj As New clsNorskFilmWizard(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))
        Dim nor_id As Integer
        nor_id = Request("nor_id")
        ds = oObj.GetApplicationDetails(nor_id)

        txtApplication1.Text = ds.Tables(0).Rows(0)("nor_name")

    End Sub

    Private Sub getApplication()
        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = False
        pnlStep4.Visible = False
        pnlStep5.Visible = False
        pnlText1.Visible = False
        pnlText1_1.Visible = False
        pnlText2.Visible = False
        pnlText2_2.Visible = False
        pnlText3.Visible = False
        pnlText3_3.Visible = False
        pnlText4.Visible = False
        pnlText4_4.Visible = False
        pnlText5.Visible = False
        pnlText5_5.Visible = False
        lnkStep1.Visible = False
        lnkStep2.Visible = False
        lnkStep3.Visible = False
        lnkStep4.Visible = False
        lnkStep5.Visible = False
        pnlInfo.Visible = False

        pnlAdministrera.Visible = True
        ' pnlApplicaton.Visible = True
        dgAccount.Visible = True

        PopulateAccountList()

    End Sub


    Sub PopulateAccountList()

        Dim iStatus As Integer
        Dim ds As New DataSet
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oObj As New clsNorskFilmWizard(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))

        If Not IsNothing(Request.Params("cmbOrdrar")) Then
            iStatus = CType(Request.Params("cmbOrdrar"), Integer)
        Else
            iStatus = 1
        End If

        ds = oObj.GetApplication()
        'If iStatus = 1 Then
        '    ' ds = oOrder.GetNewOrder()
        'ElseIf iStatus = 2 Then
        '    ' ds = oOrder.GetShipedOrder()
        'End If
        dgAccount.DataSource = ds
        dgAccount.DataBind()

    End Sub

    Public Sub dgAccount_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        'Dim oAdmOrder As New clsAdminOrder
        'Dim dsOrder As New DataSet
        'Dim dsOrderDetail As New DataSet
        'Dim dr As DataRow
        ''//Delete detail
        'dsOrderDetail = oAdmOrder.GetAdminOrderDetailDataSetByID(dgAccount.DataKeys(e.Item.ItemIndex))
        'For Each dr In dsOrderDetail.Tables(0).Rows
        '    dr.Delete()
        'Next
        'oAdmOrder.SaveAdminOrderDataSet(dsOrderDetail)
        ''//Delete order
        'dsOrder = oAdmOrder.GetAdminOrderDataSetByID(dgAccount.DataKeys(e.Item.ItemIndex))
        'dsOrder.Tables(0).Rows(0).Delete()
        'oAdmOrder.SaveAdminOrderDataSet(dsOrder)
        'DataGrid1.EditItemIndex = -1
        'Call PopulateAccountList()
    End Sub


    Sub dgAccount_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='lavender'")
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            Else
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            End If
        End If
    End Sub

    Function ChangeColor(ByVal value)
        If value = "Owner" Then
            ChangeColor = "<font color=#ff0000>" & value & "</font>"
        ElseIf value = "Sales Representative" Then
            ChangeColor = "<font color=#fff000>" & value & "</font>"
        Else
            ChangeColor = value
        End If
    End Function

    Function ChangeColor2(ByVal value1, ByVal value2)
        If value1 = "Owner" Then
            ChangeColor2 = "<font color=#ff0000>" & value2 & "</font>"
        Else
            ChangeColor2 = value2
        End If
    End Function


#Region "Button"

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Dim iStatus As Integer
        Dim ds As New DataSet
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim oObj As New clsNorskFilmWizard(ModuleId, oSite.ActivePage.PageId, clsSiteSecurity.HasEditPermissions(ModuleId))

        If Not Box1Step5.Text = "" Then
            oObj.newApplication(Box1Step5.Text)
        End If


    End Sub

#End Region




    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click

    End Sub
End Class
