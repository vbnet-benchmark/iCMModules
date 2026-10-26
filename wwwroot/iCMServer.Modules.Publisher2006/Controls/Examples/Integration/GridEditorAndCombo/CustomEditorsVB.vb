Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports Telerik.WebControls


Namespace Telerik.IntegrationExamples.GridEidorAndCombo

    Public Class HtmlTextColumnEditor
        Inherits GridTextColumnEditor
        Private _htmlEditor As RadEditor


        Public ReadOnly Property HtmlEditor() As RadEditor
            Get
                Me.EnsureControlsCreated()
                Return Me._htmlEditor
            End Get
        End Property


        Protected Overrides Sub CreateControls()
            Me._htmlEditor = New RadEditor
        End Sub 'CreateControls


        Protected Overrides Sub AddControlsToContainer()
            Me.EnsureControlsCreated()
            HtmlEditor.ToolsFile = "~/Editor/Examples/ToolbarMode/ToolsFileLimited.xml"
            HtmlEditor.Width = Unit.Pixel(500)
            HtmlEditor.Height = Unit.Pixel(200)
            HtmlEditor.ShowSubmitCancelButtons = False
            HtmlEditor.Editable = True
            HtmlEditor.Skin = "Custom"

            Me.ContainerControl.Controls.Add(HtmlEditor)
        End Sub 'AddControlsToContainer


        Protected Overrides Sub LoadControlsFromContainer()
            Me._htmlEditor = CType(Me.ContainerControl.Controls(0), RadEditor)
        End Sub 'LoadControlsFromContainer


        Public Overrides Property [Text]() As String
            Get
                Return Me.HtmlEditor.Html
            End Get
            Set(ByVal Value As String)
                Me.HtmlEditor.Html = Value
            End Set
        End Property
    End Class 'HtmlTextColumnEditor


    Public Class ComboEditor
        Inherits GridDropDownColumnEditor
        Private WithEvents combo As RadComboBox


        Public ReadOnly Property ComboControl() As RadComboBox
            Get
                Me.EnsureControlsCreated()
                Return Me.combo
            End Get
        End Property


        Protected Overrides Sub CreateControls()
            Me.combo = New RadComboBox
            Me.combo.EnableLoadOnDemand = False
            Me.combo.ShowToggleImage = True
            Me.combo.NoWrap = False
            Me.combo.MarkFirstMatch = True
            Me.combo.AllowCustomText = False
            Me.combo.Skin = "ClassicGold"
            Me.combo.Width = Unit.Pixel(470)
        End Sub 'CreateControls


        Protected Overrides Sub AddControlsToContainer()
            Me.EnsureControlsCreated()

            Me.ContainerControl.Controls.Add(Me.combo)
            Me.combo.ID = "combo"
            Me.combo.DataMember = Me.DataMember
            Me.combo.DataTextField = Me.DataTextField
            Me.combo.DataValueField = Me.DataValueField
            Me.combo.DataSource = Me.DataSource
            Me.combo.DataBind()
        End Sub 'AddControlsToContainer


        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedIndex() As Integer
            Get
                Return Me.combo.SelectedIndex
            End Get
            Set(ByVal Value As Integer)
                Dim i As Integer = 0
                Dim item As RadComboBoxItem
                For Each item In Me.combo.Items
                    If i = Value Then
                        item.Selected = True
                        Exit For
                    End If

                    i += 1
                Next item
            End Set
        End Property



        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedValue() As String
            Get
                If (SelectedIndex >= 0) Then
                    Return Me.combo.SelectedItem.Value
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                Dim item As RadComboBoxItem
                For Each item In Me.combo.Items
                    If item.Value = Value Then
                        item.Selected = True
                        Exit For
                    End If
                Next item
            End Set
        End Property


        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedText() As String
            Get
                If (SelectedIndex >= 0) Then
                    Return Me.combo.SelectedItem.Text
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                Dim item As RadComboBoxItem
                For Each item In Me.combo.Items
                    If item.Text = Value Then
                        item.Selected = True
                        Exit For
                    End If
                Next item
            End Set
        End Property


        Public Overrides Sub DataBind()
            Me.combo.DataBind()
        End Sub 'DataBind


        Protected Overrides Sub LoadControlsFromContainer()
            Me.combo = CType(Me.ContainerControl.Controls(0), RadComboBox)
        End Sub 'LoadControlsFromContainer
    End Class 'ComboEditor


    Public Class GridListEditor
        Inherits GridDropDownColumnEditor
        Private WithEvents grid As RadGrid


        Public ReadOnly Property GridControl() As RadGrid
            Get
                EnsureControlsCreated()
                Return grid
            End Get
        End Property


        Protected Overrides Sub CreateControls()
            Me.grid = New RadGrid

            Me.grid.AutoGenerateColumns = False
            Me.grid.Width = Unit.Pixel(500)

            Me.grid.ClientSettings.AllowColumnsReorder = True
            Me.grid.ClientSettings.ReorderColumnsOnClient = True

            Me.grid.ClientSettings.Scrolling.AllowScroll = True
            Me.grid.ClientSettings.Scrolling.ScrollHeight = Unit.Pixel(100)
            Me.grid.ClientSettings.Scrolling.UseStaticHeaders = True

            Me.grid.ClientSettings.Resizing.AllowRowResize = True
            Me.grid.ClientSettings.Resizing.AllowColumnResize = True
            Me.grid.ClientSettings.Resizing.ClipCellContentOnResize = True

            Me.grid.ClientSettings.Selecting.AllowRowSelect = True

            Me.grid.ClientSettings.ApplyStylesOnClient = True

            Me.grid.SelectedItemStyle.BackColor = Color.CadetBlue
            Me.grid.SelectedItemStyle.ForeColor = Color.White
            Me.grid.HeaderStyle.BackColor = Color.WhiteSmoke
            Me.grid.ItemStyle.BackColor = Color.White
            Me.grid.AlternatingItemStyle.BackColor = Color.White
        End Sub 'CreateControls


        Protected Overrides Sub AddControlsToContainer()
            EnsureControlsCreated()

            Me.ContainerControl.Controls.Add(Me.grid)

            If Me.DataValueField + "" <> String.Empty Then
                Dim column1 As New GridBoundColumn
                column1.HeaderText = Me.DataValueField
                column1.DataField = Me.DataValueField
                column1.UniqueName = Me.DataValueField
                Me.grid.Columns.Add(column1)
            Else
                Me.DataValueField = "Item"
            End If

            If Me.DataTextField + "" <> String.Empty Then
                Dim column1 As New GridBoundColumn
                column1.HeaderText = Me.DataTextField
                column1.DataField = Me.DataTextField
                column1.UniqueName = Me.DataTextField
                Me.grid.Columns.Add(column1)
            Else
                Me.DataValueField = "Item"
            End If

            If grid.Columns.Count = 0 Then
                Dim column1 As New GridBoundColumn
                column1.HeaderText = "Item"
                column1.DataField = "Item"
                column1.UniqueName = "Item"
                Me.grid.Columns.Add(column1)
            End If

        End Sub 'AddControlsToContainer


        Public Sub OnGridBind(ByVal sender As Object, ByVal args As EventArgs) Handles grid.DataBinding
            Me.grid.DataMember = Me.DataMember
            Me.grid.DataSource = Me.DataSource
        End Sub 'OnGridBind



        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedIndex() As Integer
            Get
                If (Me.grid.SelectedItems.Count > 0) Then
                    Return Me.grid.SelectedItems(0).ItemIndex
                Else
                    Return -1
                End If
            End Get
            Set(ByVal Value As Integer)
                Dim i As Integer = 0
                Dim item As GridDataItem
                For Each item In Me.grid.Items
                    If i = Value Then
                        item.Selected = True
                        Exit For
                    End If

                    i += 1
                Next item
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedValue() As String
            Get
                If (SelectedIndex >= 0) Then
                    Return CType(Me.grid.SelectedItems(0), GridDataItem)(Me.DataValueField).Text
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                Dim item As GridDataItem
                For Each item In Me.grid.Items
                    If item(Me.DataValueField).Text = Value Then
                        item.Selected = True
                        Exit For
                    End If
                Next item
            End Set
        End Property


        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property SelectedText() As String
            Get
                If (SelectedIndex >= 0) Then
                    Return CType(Me.grid.SelectedItems(0), GridDataItem)(Me.DataValueField).Text
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                Dim item As GridDataItem
                For Each item In Me.grid.Items
                    If item(DataTextField).Text = Value Then
                        item.Selected = True
                        Exit For
                    End If
                Next item
            End Set
        End Property


        Public Overrides Sub DataBind()
            Me.grid.DataBind()
        End Sub 'DataBind


        Protected Overrides Sub LoadControlsFromContainer()
            Me.grid = CType(Me.ContainerControl.Controls(0), RadGrid)
        End Sub 'LoadControlsFromContainer
    End Class 'GridListEditor


    Public Class InputEditor
        Inherits GridTextColumnEditor
        Private _radDatePicker As Telerik.WebControls.RadDateInput


        Public ReadOnly Property radDatePicker() As RadDateInput
            Get
                Me.EnsureControlsCreated()
                Return Me._radDatePicker
            End Get
        End Property


        Protected Overrides Sub CreateControls()
            Me._radDatePicker = New RadDateInput
            Me._radDatePicker.ID = "datepicker"
            Me._radDatePicker.DateFormat = "d"
        End Sub 'CreateControls


        Protected Overrides Sub AddControlsToContainer()
            Me.EnsureControlsCreated()

            Me.ContainerControl.Controls.Add(_radDatePicker)
        End Sub 'AddControlsToContainer


        Protected Overrides Sub LoadControlsFromContainer()
            Me._radDatePicker = CType(Me.ContainerControl.Controls(0), RadDateInput)
        End Sub 'LoadControlsFromContainer


        Public Property SelectedDate() As DateTime
            Get
                Return Me._radDatePicker.SelectedDate
            End Get
            Set(ByVal Value As DateTime)
                Me._radDatePicker.SelectedDate = Value
            End Set
        End Property

        Public Overrides Property [Text]() As String
            Get
                Return Me._radDatePicker.SelectedDate.ToString()
            End Get
            Set(ByVal Value As String)
                Me._radDatePicker.SelectedDate = DateTime.Parse(Value)
            End Set
        End Property
    End Class 'InputEditor


    Public Class ExampleListItem
        Private _a As String
        Private _c As String
        Private _b As Integer
        Private _d As String
        Private _e As DateTime


        Public Sub New(ByVal a As String, ByVal b As Integer, ByVal c As String, ByVal d As String, ByVal e As DateTime)
            Me._a = a
            Me._b = b
            Me._c = c
            Me._d = d
            Me._e = e
        End Sub 'New

        '/ <summary>
        '/ Read-write property
        '/ </summary>

        Public Property A() As String
            Get
                Return Me._a
            End Get
            Set(ByVal Value As String)
                Me._a = Value
            End Set
        End Property


        Public Property C() As String
            Get
                Return Me._c
            End Get
            Set(ByVal Value As String)
                Me._c = Value
            End Set
        End Property

        '/ <summary>
        '/ Read-Only property
        '/ </summary>

        Public ReadOnly Property B() As Integer
            Get
                Return Me._b
            End Get
        End Property


        Public Property D() As String
            Get
                Return Me._d
            End Get
            Set(ByVal Value As String)
                Me._d = Value
            End Set
        End Property


        Public Property E() As DateTime
            Get
                Return Me._e
            End Get
            Set(ByVal Value As DateTime)
                Me._e = Value
            End Set
        End Property
    End Class 'ExampleListItem
End Namespace