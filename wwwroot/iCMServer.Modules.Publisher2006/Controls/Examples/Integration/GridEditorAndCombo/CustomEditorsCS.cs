using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using Telerik.WebControls;

namespace Telerik.IntegrationExamples.GridEidorAndCombo
{
	public class HtmlTextColumnEditor: GridTextColumnEditor
	{
		private RadEditor htmlEditor;

		public RadEditor HtmlEditor
		{
			get
			{
				this.EnsureControlsCreated();
				return this.htmlEditor;
			}
		}

		protected override void CreateControls()
		{
			this.htmlEditor = new RadEditor();
		}

		protected override void AddControlsToContainer()
		{
			this.EnsureControlsCreated();
            htmlEditor.ToolsFile = "~/Editor/Examples/ToolbarMode/ToolsFileLimited.xml";
			htmlEditor.Width = Unit.Pixel(500);
			htmlEditor.Height = Unit.Pixel(200);
			htmlEditor.ShowSubmitCancelButtons = false;
			htmlEditor.Editable = true;
			htmlEditor.Skin="Custom";

			this.ContainerControl.Controls.Add( htmlEditor );
		}

		protected override void LoadControlsFromContainer()
		{
			this.htmlEditor = (RadEditor)this.ContainerControl.Controls[0];
		}

		public override string Text
		{
			get
			{
				return this.HtmlEditor.Html;
			}
			set
			{
				this.HtmlEditor.Html = value;
			}
		}
	}

	public class ComboEditor: GridDropDownColumnEditor
	{
		private RadComboBox combo;

		public RadComboBox ComboControl
		{
			get
			{
				this.EnsureControlsCreated();
				return this.combo;
			}
		}

		protected override void CreateControls()
		{
			this.combo = new RadComboBox();
			this.combo.EnableLoadOnDemand = false;
			this.combo.ShowToggleImage = true;
			this.combo.NoWrap=false;
			this.combo.MarkFirstMatch=true;
			this.combo.AllowCustomText=false;
			this.combo.Skin="ClassicGold";
			this.combo.Width=Unit.Pixel(470);
		}

		protected override void AddControlsToContainer()
		{
			this.EnsureControlsCreated();

			this.ContainerControl.Controls.Add( this.combo );
			this.combo.ID = "combo";
            this.combo.DataMember = this.DataMember;
            this.combo.DataTextField = this.DataTextField;
            this.combo.DataValueField = this.DataValueField;
            this.combo.DataSource = this.DataSource;
            this.combo.DataBind();
        }

		public void OnComboBind( object sender, EventArgs args )
		{
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int SelectedIndex
		{
			get
			{
				return this.combo.SelectedIndex;
			}
			set
			{
				int i = 0;
				foreach( RadComboBoxItem item in this.combo.Items )
				{
					if ( i == value )
					{
						item.Selected = true;
						break;
					}

					i++;
				}
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string SelectedValue
		{
			get
			{
				return (SelectedIndex >= 0)? this.combo.SelectedItem.Value : "";
			}
			set
			{
				foreach( RadComboBoxItem item in this.combo.Items )
				{
					if ( item.Value == value )
					{
						item.Selected = true;
						break;
					}
				}
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string SelectedText
		{
			get
			{
				return (SelectedIndex >= 0)? this.combo.SelectedItem.Text : "";
			}
			set
			{
				foreach( RadComboBoxItem item in this.combo.Items )
				{
					if ( item.Text == value )
					{
						item.Selected = true;
						break;
					}
				}
			}
		}

		public override void DataBind()
		{
			this.combo.DataBind();
		}

		protected override void LoadControlsFromContainer()
		{
			this.combo = (RadComboBox)this.ContainerControl.Controls[0];
		}
	}

	public class GridListEditor: GridDropDownColumnEditor
	{
		private RadGrid grid;

		public RadGrid GridControl
		{
			get
			{
				EnsureControlsCreated();
				return grid;
			}
		}

		protected override void CreateControls()
		{
			this.grid = new RadGrid();

			this.grid.AutoGenerateColumns = false;
			this.grid.Width = Unit.Pixel( 500 );

			this.grid.ClientSettings.AllowColumnsReorder = true;
			this.grid.ClientSettings.ReorderColumnsOnClient = true;

			this.grid.ClientSettings.Scrolling.AllowScroll = true;
			this.grid.ClientSettings.Scrolling.ScrollHeight = Unit.Pixel( 100 );
			this.grid.ClientSettings.Scrolling.UseStaticHeaders = true;

			this.grid.ClientSettings.Resizing.AllowRowResize = true;
			this.grid.ClientSettings.Resizing.AllowColumnResize = true;
			this.grid.ClientSettings.Resizing.ClipCellContentOnResize = true;

			this.grid.ClientSettings.Selecting.AllowRowSelect = true;

			this.grid.ClientSettings.ApplyStylesOnClient = true;

			this.grid.SelectedItemStyle.BackColor = Color.CadetBlue;
			this.grid.SelectedItemStyle.ForeColor = Color.White;
			this.grid.HeaderStyle.BackColor = Color.WhiteSmoke;
			this.grid.ItemStyle.BackColor = Color.White;
			this.grid.AlternatingItemStyle.BackColor = Color.White;
		}

		protected override void AddControlsToContainer()
		{
			EnsureControlsCreated();

			this.ContainerControl.Controls.Add( this.grid );

			if ( (this.DataValueField + "") != string.Empty )
			{
				GridBoundColumn column1 = new GridBoundColumn();
				column1.HeaderText = this.DataValueField;
				column1.DataField = this.DataValueField;
				column1.UniqueName = this.DataValueField;
				this.grid.Columns.Add( column1 );
			}
			else
			{
				this.DataValueField = "Item";
			}

			if ( (this.DataTextField + "") != string.Empty )
			{
				GridBoundColumn column1 = new GridBoundColumn();
				column1.HeaderText = this.DataTextField;
				column1.DataField = this.DataTextField;
				column1.UniqueName = this.DataTextField;
				this.grid.Columns.Add( column1 );
			}
			else
			{
				this.DataValueField = "Item";
			}

			if ( grid.Columns.Count == 0 )
			{
				GridBoundColumn column1 = new GridBoundColumn();
				column1.HeaderText = "Item";
				column1.DataField = "Item";
				column1.UniqueName = "Item";
				this.grid.Columns.Add( column1 );
			}

			this.grid.DataBinding += new EventHandler( this.OnGridBind );
		}

		public void OnGridBind( object sender, EventArgs args )
		{
			this.grid.DataMember = this.DataMember;
			this.grid.DataSource = this.DataSource;
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int SelectedIndex
		{
			get
			{
				return (this.grid.SelectedItems.Count > 0)? this.grid.SelectedItems[0].ItemIndex : -1;
			}
			set
			{
				int i = 0;
				foreach( GridDataItem item in this.grid.Items )
				{
					if ( i == value )
					{
						item.Selected = true;
						break;
					}

					i++;
				}
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string SelectedValue
		{
			get
			{
				return (SelectedIndex >= 0)? (this.grid.SelectedItems[0] as GridDataItem)[this.DataValueField].Text : "";
			}
			set
			{
				foreach( GridDataItem item in this.grid.Items )
				{
					if ( item[this.DataValueField].Text == value )
					{
						item.Selected = true;
						break;
					}
				}
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string SelectedText
		{
			get
			{
				return (SelectedIndex >= 0)? (this.grid.SelectedItems[0] as GridDataItem)[this.DataTextField].Text : "";
			}
			set
			{
				foreach( GridDataItem item in this.grid.Items )
				{
					if ( item[DataTextField].Text == value )
					{
						item.Selected = true;
						break;
					}
				}
			}
		}

		public override void DataBind()
		{
			this.grid.DataBind();
		}

		protected override void LoadControlsFromContainer()
		{
			this.grid = (RadGrid)this.ContainerControl.Controls[0];
		}
	}

	public class InputEditor: GridTextColumnEditor
	{
		private Telerik.WebControls.RadDateInput _radDatePicker;

		public RadDateInput radDatePicker
		{
			get
			{
				this.EnsureControlsCreated();
				return this._radDatePicker;
			}
		}

		protected override void CreateControls()
		{
			this._radDatePicker = new RadDateInput();
			this._radDatePicker.ID = "datepicker";
			this._radDatePicker.DateFormat = "d";
		}

		protected override void AddControlsToContainer()
		{
			this.EnsureControlsCreated();
			
			this.ContainerControl.Controls.Add( _radDatePicker );
		}

		protected override void LoadControlsFromContainer()
		{
			this._radDatePicker = (RadDateInput)this.ContainerControl.Controls[0];
		}

		public DateTime SelectedDate
		{
			get
			{
				return this._radDatePicker.SelectedDate;
			}
			set
			{
				this._radDatePicker.SelectedDate= value;
			}
		}
		public override string Text
		{
			get
			{
				return this._radDatePicker.SelectedDate.ToString();
			}
			set
			{
				this._radDatePicker.SelectedDate= DateTime.Parse(value);
			}
		}

	}

	public class ExampleListItem
	{
		private string _a;
		private string _c;
		private int _b;
		private string _d;
		private DateTime _e;

		public ExampleListItem( string a, int b, string c, string d, DateTime e )
		{
			this._a = a;
			this._b = b;
			this._c = c;
			this._d = d;
			this._e = e;
		}

		/// <summary>
		/// Read-write property
		/// </summary>
		public string A
		{
			get
			{
				return this._a;
			}
			set
			{
				this._a = value;
			}
		}

		public string C
		{
			get
			{
				return this._c;
			}
			set
			{
				this._c = value;
			}
		}

		/// <summary>
		/// Read-Only property
		/// </summary>
		public int B
		{
			get
			{
				return this._b;
			}
		}

		public string D
		{
			get
			{
				return this._d;
			}
			set
			{
				this._d = value;
			}
		}

		public DateTime E
		{
			get
			{
				return this._e;
			}
			set
			{
				this._e = value;
			}
		}
	}
}
