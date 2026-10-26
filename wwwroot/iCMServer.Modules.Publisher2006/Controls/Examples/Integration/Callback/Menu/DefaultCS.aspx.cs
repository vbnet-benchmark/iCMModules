using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using Telerik.QuickStart;
using Telerik.WebControls;
using System.Drawing;

namespace Telerik.CallbackIntegrationExamplesCSharp.Menu
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class DefaultCS: XhtmlPage
	{		
		protected Telerik.WebControls.RadCallback RadCallback1;
		protected System.Web.UI.WebControls.ListBox lbShoppingCart;
		protected Telerik.WebControls.CallbackListBox lbDataSource;
		protected System.Web.UI.WebControls.Label lBreadCrumb;
		protected System.Web.UI.WebControls.TextBox tbItemText;
		protected System.Web.UI.WebControls.Label Label1;
		protected Telerik.WebControls.CallbackButton btnRemove;
		protected Telerik.WebControls.CallbackButton btnDisable;
		protected Telerik.WebControls.CallbackButton btnAddChild;
		protected Telerik.WebControls.CallbackButton btnAddRoot;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Panel pCart;
		protected Telerik.WebControls.RadMenu RadMenu1;

		private string LastItem
		{
			get
			{
				return (string) ViewState["LastItem"];
			}
			set
			{
				ViewState["LastItem"] = value;
			}
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{				
			if (!Page.IsPostBack)
			{
				LoadData();
			}
			RadMenu1.ExpandToID = string.Empty;
		}

		protected void RadCallback1_Callback(object sender, Telerik.WebControls.CallbackEventArgs args)
		{							
			string[] subArgs = Server.UrlDecode(args.Args).Split('\n');

			Telerik.WebControls.MenuItem clickedItem = null;
			if (2 == subArgs.Length)
				clickedItem = GetMenuItem(subArgs[0], subArgs[1]);

			if (clickedItem != null)
			{
				MakeBreadCrumb(clickedItem);
				UpdateShoppingCart(clickedItem);
				LastItem = clickedItem.Text;
				((RadCallback)sender).ControlsToUpdate.Add(lBreadCrumb);
				((RadCallback)sender).ControlsToUpdate.Add(pCart);
			}
		}

		protected void btnAddChild_Click(object sender, System.EventArgs e)
		{	
			if (CheckTextBox((CallbackButton)sender, tbItemText))
			{
				if (LastItem != null)
				{
					Telerik.WebControls.MenuItem _lastItem = GetMenuItem(LastItem, "");
						
					if (_lastItem != null)
					{
						AddNewItem(_lastItem, tbItemText.Text);					
						RadMenu1.ExpandToID = tbItemText.Text;
						tbItemText.Text = string.Empty;
						((CallbackButton)sender).ControlsToUpdate.Add(RadMenu1);
						((CallbackButton)sender).ControlsToUpdate.Add(tbItemText);
					}
				}
				else
				{
					((CallbackButton)sender).Alert("There is no last selected menu item!");
				}
			}					
		}

		protected void btnRemove_Click(object sender, System.EventArgs e)
		{
			if (LastItem != null)
			{
				Telerik.WebControls.MenuItem _menuItem = GetMenuItem(LastItem, "");
				if (_menuItem != null)
				{
					if (_menuItem.ParentItem != null)
					{
						_menuItem.ParentItem.Items.Remove(_menuItem);
					}
					else
					{
						RadMenu1.RootGroup.RemoveItem(_menuItem);
					}
					((CallbackButton)sender).ControlsToUpdate.Add(RadMenu1);
					((CallbackButton)sender).ControlsToUpdate.Add(lBreadCrumb);
					lBreadCrumb.Text = null;
				}
			}
			else
			{
				((CallbackButton)sender).Alert("There is no last selected menu item!");
			}
		}

		protected void lbDataSource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadData();
			UpdateElements();
			((CallbackListBox)sender).ControlsToUpdate.Add(RadMenu1);
			((CallbackListBox)sender).ControlsToUpdate.Add(pCart);
		}

		protected void btnAddRoot_Click(object sender, System.EventArgs e)
		{
			if (CheckTextBox((CallbackButton)sender, tbItemText))
			{
				Telerik.WebControls.MenuItem newItem = new Telerik.WebControls.MenuItem();
				newItem.Text = tbItemText.Text;
				newItem.CssClass = "MainItem";
				newItem.CssClassOver = "MainItemOver";
				newItem.CssClassClicked = "MainItemOver";

				processMainItems(RadMenu1);

				RadMenu1.RootGroup.Items.Add(newItem);

				tbItemText.Text = string.Empty;
				((CallbackButton)sender).ControlsToUpdate.Add(RadMenu1);
				((CallbackButton)sender).ControlsToUpdate.Add(tbItemText);
			}
		}

		protected void btnDisable_Click(object sender, System.EventArgs e)
		{
			if (LastItem != null)
			{
				Telerik.WebControls.MenuItem _menuItem = GetMenuItem(LastItem, "");
				if (_menuItem != null)
				{
					_menuItem.Enabled = false;
					((CallbackButton)sender).ControlsToUpdate.Add(RadMenu1);
				}
			}		
			else
			{
				((CallbackButton)sender).Alert("There is no last selected menu item!");
			}

		}			

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadData()
		{
			if (lbDataSource.SelectedIndex ==0)
			{
				Load1(RadMenu1);					
			}
			else if (lbDataSource.SelectedIndex ==1)
			{
				Load2(RadMenu1);					
			}
			else
			{
				Load3(RadMenu1);					
			}
			processMainItems(RadMenu1);
		}
		private void MakeBreadCrumb(Telerik.WebControls.MenuItem item)
		{
			string bc = string.Empty;

			while (item != null)
			{
				if (bc.Length == 0)
				{
					bc = item.Text;
				}
				else
				{
					bc = item.Text + " > " + bc;
				}				
				item = (Telerik.WebControls.MenuItem) item.ParentItem;
			}			
			lBreadCrumb.Text = bc;
		}

		private void UpdateShoppingCart(Telerik.WebControls.MenuItem item)
		{		
			if (item.ParentItem == null) return;
			if (item.Category == string.Empty) return;

			if (lbDataSource.SelectedIndex == 1)
			{				
				string text = item.Text;
				ListItem cartItem = lbShoppingCart.Items.FindByText(text);
				if (item.Category.Equals("Add"))
				{
					if (cartItem == null)
					{
						lbShoppingCart.Items.Add(text);
					}
					else
					{
						RadCallback1.Alert("Item already exists in the shopping cart!");
					}
				}
				else
				{	
					if (cartItem != null)
					{
						lbShoppingCart.Items.Remove(cartItem);
					}
					else
					{
						RadCallback1.Alert("Item already removed from the shopping cart!");
					}
				} 
			}	
		}
		
		private void AddNewItem(Telerik.WebControls.MenuItem item, string text)
		{
			Telerik.WebControls.MenuItem newItem = new Telerik.WebControls.MenuItem();
			newItem.Text = text;
			newItem.CssClass = "MainItem";
			newItem.CssClassOver = "MainItemOver";
			newItem.CssClassClicked = "MainItemOver";
			newItem.ID = text;
			item.Items.Add(newItem);			
		}

		private Telerik.WebControls.MenuItem GetMenuItem(string text, string category)
		{
			ArrayList array = RadMenu1.FindItemByText(text, false);

			if ((array.Count > 1) || (array.Count == 0))
			{
				foreach (Telerik.WebControls.MenuItem item in array)
				{
					if (item.Category.Equals(category))
					{
						return item;
					}
				}
			}

			if (array.Count > 0)
			{
				return (Telerik.WebControls.MenuItem) array[0];						
			}
			else
			{
				return null;
			}
		}
		private void UpdateElements()
		{
			if (lbDataSource.SelectedIndex == 1)
			{
				foreach (Control ctrlv in pCart.Controls)
				{
					ctrlv.Visible = true;
				}
			}
			else
			{
				foreach (Control ctrlnv in pCart.Controls)
				{
					ctrlnv.Visible = false;
				}
			}
		}
		private bool CheckTextBox(CallbackButton button, TextBox textBox)
		{
			button.ControlsToUpdate.Add(textBox);
			if (textBox.Text.Length == 0)
			{
				textBox.BackColor = Color.Yellow;
				button.Alert("Name for the item is reqired.");
				return false;
			}
			else
			{
				textBox.BackColor = Color.White;
				return true;
			}
		}

		private DataSet GetMenuDataSource(string inputDSN)
		{
			OleDbConnection OldDbCon = new OleDbConnection(inputDSN);
			OldDbCon.Open();
			OleDbDataAdapter MenuDataAdaptor = new OleDbDataAdapter("SELECT Text,idtext,parentIdtext FROM Links", OldDbCon);
			DataSet MenuDataLoader = new DataSet();
			MenuDataAdaptor.Fill(MenuDataLoader);
			OldDbCon.Close();
			return MenuDataLoader; 
		}

		private void MenuRealBind(RadMenu menu)
		{			
			string DefaultDSN = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("menudata.mdb");			
			menu.EnableGroupChildrenImage = true;
			menu.DataFieldID = "idtext";//idtext
			menu.DataFieldParentID = "parentIdtext";//parentIdtext
			menu.DataSource = GetMenuDataSource(DefaultDSN).Tables[0].DefaultView;
			menu.DataBind();
			menu.RootGroup.Flow = PresentationDirection.Horizontal;			
		}

		private void processMainItems(RadMenu menu)
		{
			if (menu.RootGroup != null && menu.RootGroup.Items.Count > 0)
			{
				foreach (Telerik.WebControls.MenuItem item in menu.RootGroup.Items)
				{
					item.CssClass = "MainItem";
					item.CssClassOver = "MainItemOver";					
					item.CssClassClicked = "MainItemOver";				
				}
			}
		}

		private void Load1(RadMenu menu)
		{
			MenuGroup TopGroup = new MenuGroup();
			TopGroup.Flow = PresentationDirection.Horizontal;            
			menu.RootGroup = TopGroup;
                
			Telerik.WebControls.MenuItem TimeHeadItem = new Telerik.WebControls.MenuItem();
			TimeHeadItem.Text = "Current Time";
			TimeHeadItem.CssClass = "MainItem";
			TimeHeadItem.CssClassOver = "MainItemOver";
			TopGroup.AddItem(TimeHeadItem);

			MenuGroup TimeGroup = new MenuGroup();
			TimeGroup.Width = 130;
			TimeGroup.LeftCellWidth = 10;
			TimeHeadItem.ChildGroup = TimeGroup;

			Telerik.WebControls.MenuItem HourItem = new Telerik.WebControls.MenuItem();
			HourItem.Text = "Hours : " + System.DateTime.Now.Hour.ToString();
			TimeGroup.AddItem(HourItem);

			Telerik.WebControls.MenuItem MinuteItem = new Telerik.WebControls.MenuItem();
			MinuteItem.Text = "Minutes : " + System.DateTime.Now.Minute.ToString();
			TimeGroup.AddItem(MinuteItem);

			Telerik.WebControls.MenuItem SecondItem = new Telerik.WebControls.MenuItem();
			SecondItem.Text = "Seconds : " + System.DateTime.Now.Second.ToString();
			TimeGroup.AddItem(SecondItem);

			Telerik.WebControls.MenuItem DateHeadItem = new Telerik.WebControls.MenuItem();
			DateHeadItem.Text = "Current Date";
			DateHeadItem.CssClass = "MainItem";
			DateHeadItem.CssClassOver = "MainItemOver";
			TopGroup.AddItem(DateHeadItem);

			MenuGroup DateGroup = new MenuGroup();
			DateGroup.Width = 130;
			DateGroup.LeftCellWidth = 10;
			DateHeadItem.ChildGroup = DateGroup;

			Telerik.WebControls.MenuItem YearItem = new Telerik.WebControls.MenuItem();
			YearItem.Text = "Year : " + System.DateTime.Now.Year.ToString();
			DateGroup.AddItem(YearItem);

			Telerik.WebControls.MenuItem MonthItem = new Telerik.WebControls.MenuItem();
			MonthItem.Text = "Month : " + System.DateTime.Now.Month.ToString();
			DateGroup.AddItem(MonthItem);

			Telerik.WebControls.MenuItem DayItem = new Telerik.WebControls.MenuItem();
			DayItem.Text = "Day : " + System.DateTime.Now.Day.ToString();
			DayItem.ID = "DayItem";
			DateGroup.AddItem(DayItem);
		}

		private void Load2(RadMenu menu)
		{
			menu.LoadContentFile("menu.xml");			
		}

		private void Load3(RadMenu menu)
		{
			MenuRealBind(menu);					
		}
	}
}
