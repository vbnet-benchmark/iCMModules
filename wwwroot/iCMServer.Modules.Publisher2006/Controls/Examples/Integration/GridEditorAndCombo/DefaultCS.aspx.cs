using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.WebControls;
using System.Web.UI.WebControls;
using Telerik.QuickStart;

namespace Telerik.IntegrationExamples.GridEidorAndCombo
{
	public class DefaultCS : XhtmlPage
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected Telerik.WebControls.RadGrid RadGrid1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RadGrid1.NeedDataSource += new Telerik.WebControls.GridNeedDataSourceEventHandler(this.RadGrid1_NeedDataSource);
			this.RadGrid1.CreateColumnEditor += new Telerik.WebControls.GridCreateColumnEditorEventHandler(this.RadGrid1_CreateColumnEditor);
			this.RadGrid1.PreRender += new System.EventHandler(this.RadGrid1_PreRender);
			this.RadGrid1.UpdateCommand += new Telerik.WebControls.GridCommandEventHandler(this.RadGrid1_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private ArrayList Data
		{
			get
			{
				ArrayList list;
				if ( this.Session[ "ds" ] != null )
				{
					list = (ArrayList)this.Session[ "ds" ];
				}
				else
				{
					list = new ArrayList();
					list.Add( new ExampleListItem("<p>r.a.d.<strong>g</strong>rid ,&nbsp;r.a.d.<strong>e</strong>ditor , r.a.d.<strong>c</strong>ombo&nbsp;&nbsp;integration. This example demonstrates&nbsp;GridBoundColumn and GridDropDowColumn with&nbsp;different custom editors that in this case use r.a.d.<strong>e</strong>ditor, r.a.d.<strong>c</strong>ombo, even r.a.d.<strong>g</strong>rid itself</p>", 0, "1", "1", DateTime.Now) );
					list.Add( new ExampleListItem("Item 1", 1, "2", "2", DateTime.Parse("11/15/2005")) );
					list.Add( new ExampleListItem("Item 2", 2, "3", "3", DateTime.Parse("3/8/2001")) );
					list.Add( new ExampleListItem("Item 3", 3, "", "", DateTime.Parse("12/31/2005")) );

					this.Session[ "ds" ] = list;
				}

				return list;
			}
		}

		private void RadGrid1_NeedDataSource(object source, Telerik.WebControls.GridNeedDataSourceEventArgs e)
		{
			this.RadGrid1.DataSource = this.Data;
		}

		private ArrayList GetComboSource()
		{
			ArrayList itemsList = new ArrayList();
			itemsList.Add( new ListItem("One", "1") );
			itemsList.Add( new ListItem("Two", "2") );
			itemsList.Add( new ListItem("Three", "3") );
			itemsList.Add( new ListItem("Four", "4") );
			itemsList.Add( new ListItem("Five", "5") );
			itemsList.Add( new ListItem("Six", "6") );
			itemsList.Add( new ListItem("Seven", "7") );
			itemsList.Add( new ListItem("Eight", "8") );
			itemsList.Add( new ListItem("Nine", "9") );

			return itemsList;
		}

		private void RadGrid1_CreateColumnEditor(object sender, Telerik.WebControls.GridCreateColumnEditorEventArgs e)
		{
			if ( e.Column.UniqueName == "A" )
			{
				e.ColumnEditor = new HtmlTextColumnEditor();
			}
			else if ( e.Column.UniqueName == "C" )
			{
				ComboEditor comboEditor = new ComboEditor();
				comboEditor.DataSource = GetComboSource();

				e.ColumnEditor = comboEditor;
			}
			else if ( e.Column.UniqueName == "D" )
			{
				GridListEditor gridEditor = new GridListEditor();
				gridEditor.DataSource = GetComboSource();
				e.ColumnEditor = gridEditor;
			}
			else if (e.Column.UniqueName == "E")
			{
				e.ColumnEditor = new InputEditor();
			}
		}

		private ExampleListItem FindItemIn( ArrayList list, int B )
		{
			ExampleListItem res = null;
			for (int i=0;i<list.Count ;i++)
			{
				if (((ExampleListItem)list[i]).B == B)
				{
					res = (ExampleListItem)list[i];
					break;
				}
			}
			if ( res == null )
			{
				throw new InvalidOperationException( "Cannot find item " + B.ToString() );
			}

			return res;
		}

		private void RadGrid1_UpdateCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
		{
			GridEditableItem item = (GridEditableItem)e.Item;
			ExampleListItem edited = this.FindItemIn( this.Data, int.Parse(item["B"].Text) );
			edited.A = ((GridTextColumnEditor)item.EditManager.GetColumnEditor("A")).Text;
			edited.C = ((GridDropDownColumnEditor)item.EditManager.GetColumnEditor("C")).SelectedValue;
			edited.D = ((GridDropDownColumnEditor)item.EditManager.GetColumnEditor("D")).SelectedValue;
			edited.E = ((InputEditor)item.EditManager.GetColumnEditor("E")).SelectedDate;
		}

		private void RadGrid1_PreRender(object sender, System.EventArgs e)
		{
			if ( !IsPostBack )
			{
				this.RadGrid1.Items[0].Edit = true;
				this.RadGrid1.Rebind();
			}
		}
	}
}
