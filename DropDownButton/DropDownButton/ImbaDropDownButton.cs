using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ImbaControls.DropDownButton
{
	public partial class ImbaDropDownButton : UserControl
	{
		#region Members

		//private readonly static string DownArrow = "▼";
		//private readonly static string LeftArrow = "◀";
		//private readonly static string RightArrow = "▶";
		//private readonly static string UpArrow = "▲";
		//[Browsable(true)]
		//[DefaultValue("Down")]
		//[Category("Appearance")]
		//[Description("Sets the direction in which the DropDown box is displayed")]
		//public Direction DropDirection {
		//  get { return m_drop_direction; }
		//  set {
		//    m_drop_direction = value;
		//    switch (DropDirection) {
		//      case Direction.Down:
		//        btnDrop.Text = DownArrow;
		//        break;
		//      case Direction.Left:
		//        btnDrop.Text = LeftArrow;
		//        break;
		//      case Direction.Right:
		//        btnDrop.Text = RightArrow;
		//        break;
		//      case Direction.Up:
		//        btnDrop.Text = UpArrow;
		//        break;
		//    }
		//  }
		//}
		//private Direction m_drop_direction = Direction.Down;
		private const int DefaultVisibleItemCount = 3;

		private const bool DefaultReplaceMain = false;
		private const bool DefaultShowMainInList = false;
		private const bool DefaultDropDownVisible = false;
		private const int DefaultItemHeight = 50;

		//[Browsable(true)]
		//[Category("Appearance")]
		//[Description("Sets the text of the main button")]
		//public override string Text {
		//  get { return btnMain.Text; }
		//  set { btnMain.Text = value; }
		//}

		[Browsable(true)]
		[Category("Appearance")]
		[DefaultValue(DefaultItemHeight)]
		[Description("Sets the height of a single item in the drop down list")]
		public int ItemHeight
		{
			get { return m_item_height; }
			set { m_item_height = value; }
		}

		private int m_item_height;

		[Browsable(true)]
		[Category("Appearance")]
		[DefaultValue(DefaultVisibleItemCount)]
		[Description("Sets the number of visible items when drop down list is shown")]
		public int VisibleItemCount { get; set; }

		[Browsable(true)]
		[Category("Appearance")]
		[Description("Sets the items displayed in the drop down list")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public BindingList<Item> Items
		{
			get { return m_items; }
		}

		private BindingList<Item> m_items;

		[Browsable(true)]
		[Category("Behavior")]
		[DefaultValue(DefaultReplaceMain)]
		[Description("If true, switches the main item with the recently selected item " +
			"from the drop down list")]
		public bool ReplaceMain { get; set; }

		[Browsable(true)]
		[Category("Behavior")]
		[DefaultValue(DefaultShowMainInList)]
		[Description("If true, displays the main item in the drop down list too")]
		public bool ShowMainInList { get; set; }

		[Browsable(true)]
		[Category("Appearance")]
		[DefaultValue(DefaultDropDownVisible)]
		[Description("Sets or gets wether the drop down list is visible")]
		public bool DropDownVisible
		{
			get { return dgvDrop.Visible; }
			set
			{
				if (value)
				{
					ShowDropDownList();
				}
				else
				{
					HideDropDownList();
				}
			}
		}

		[Browsable(false)]
		public Item MainItem
		{
			get
			{
				if ((Items == null) || (Items.Count < 1))
				{
					return null;
				}
				if (Items.Count((i) => i.Main) == 0)
				{
					Items[0].Main = true;
				}
				else if (Items.Count((i) => i.Main) > 1)
				{
					foreach (Item item in Items.Where((i) => i.Main).Skip(1))
					{
						item.Main = false;
					}
				}
				return Items.First((i) => i.Main);
			}
		}

		private AnchorStyles m_btn_drop_anchor;
		private AnchorStyles m_btn_main_anchor;
		private AnchorStyles m_lsv_drop_anchor;

		#endregion

		#region Events

		// MainClicked
		public event EventHandler<MainClickedEventArgs> MainClicked;

		protected void OnMainClicked(MainClickedEventArgs args)
		{
			MainClicked?.Invoke(this, args);
		}

		protected void OnMainClicked(Item item)
		{
			OnMainClicked(new MainClickedEventArgs(item));
		}

		// ItemClicked
		public event EventHandler<ItemClickedEventArgs> ItemClicked;

		protected void OnItemClicked(ItemClickedEventArgs args)
		{
			ItemClicked?.Invoke(this, args);
		}

		protected void OnItemClicked(Item item)
		{
			OnItemClicked(new ItemClickedEventArgs(item));
		}

		// MainChanged
		public event EventHandler<MainChangedEventArgs> MainReplaced;

		protected void OnMainReplaced(MainChangedEventArgs args)
		{
			MainReplaced?.Invoke(this, args);
		}

		protected void OnMainReplaced(Item previous_item, Item new_item)
		{
			OnMainReplaced(new MainChangedEventArgs(previous_item, new_item));
		}

		// DropDownVisibleChanged
		public event EventHandler DropDownVisibleChanged;

		protected void OnDropDownVisibleChanged(EventArgs args)
		{
			DropDownVisibleChanged?.Invoke(this, args);
		}

		#endregion

		public ImbaDropDownButton()
		{
			InitializeComponent();

			#region Initialize Values

			m_items = new BindingList<Item>();
			m_items.ListChanged += ItemsListChanged;
			VisibleItemCount = DefaultVisibleItemCount;
			ReplaceMain = DefaultReplaceMain;
			ShowMainInList = DefaultShowMainInList;
			ItemHeight = DefaultItemHeight;
			DropDownVisible = DefaultDropDownVisible;

			m_btn_drop_anchor = btnDrop.Anchor;
			m_btn_main_anchor = btnMain.Anchor;
			m_lsv_drop_anchor = dgvDrop.Anchor;

			#endregion

			#region Initialize dgvDrop

			((DataGridViewImageColumn)dgvDrop.Columns[0]).DefaultCellStyle.NullValue = null;
			dgvDrop.CellMouseEnter += dgvDrop_CellMouseEnter;
			dgvDrop.CellMouseClick += dgvDrop_CellMouseClick;
			dgvDrop.VisibleChanged += (s, e) =>
			{
				OnDropDownVisibleChanged(e);
			};

			#endregion

			#region Initialize btnDrop

			btnDrop.Click += (s, e) => DropDownVisible = !DropDownVisible;

			#endregion

			#region Initialize btnMain

			btnMain.Click += (s, e) =>
			{
				HideDropDownList();
				if (MainItem != null)
				{
					OnMainClicked(MainItem);
					MainItem.OnClicked();
				}
			};

			#endregion

			Leave += (s, e) => HideDropDownList();
		}

		private void UpdateDropDownList()
		{
			dgvDrop.Rows.Clear();

			foreach (Item item in Items)
			{
				if ((!ShowMainInList) && (item == Items.First((i) => i.Main)))
				{
					continue;
				}

				var row = new DataGridViewRow();
				row.Tag = item;
				DataGridViewCell cell = new DataGridViewImageCell();
				cell.Value = item.Icon;
				if ((item.Icon != null) && (item.Icon.Width > dgvDrop.Columns[0].Width))
				{
					dgvDrop.Columns[0].Width = item.Icon.Width;
				}
				row.Cells.Add(cell);
				cell = new DataGridViewTextBoxCell();
				cell.Value = item.Text;
				row.Cells.Add(cell);
				row.Height = ItemHeight;
				dgvDrop.Rows.Add(row);
			}
		}

		public void ShowDropDownList()
		{
			if (!dgvDrop.Visible)
			{
				UpdateDropDownList();

				btnDrop.Anchor = AnchorStyles.Top;
				btnMain.Anchor = AnchorStyles.Top;
				dgvDrop.Anchor = AnchorStyles.Top;
				dgvDrop.Height = (Math.Min(dgvDrop.Rows.Count, VisibleItemCount) * ItemHeight) + 2;
				Height = Height + dgvDrop.Height;
				btnDrop.Anchor = m_btn_drop_anchor;
				btnMain.Anchor = m_btn_main_anchor;
				dgvDrop.Anchor = m_lsv_drop_anchor;

				dgvDrop.Visible = true;
				BringToFront();
			}
		}

		public void HideDropDownList()
		{
			if (dgvDrop.Visible)
			{
				dgvDrop.Visible = false;

				btnDrop.Anchor = AnchorStyles.Top;
				btnMain.Anchor = AnchorStyles.Top;
				dgvDrop.Anchor = AnchorStyles.Top;
				Height = Height - dgvDrop.Height;
				dgvDrop.Height = 0;
				btnDrop.Anchor = m_btn_drop_anchor;
				btnMain.Anchor = m_btn_main_anchor;
				dgvDrop.Anchor = m_lsv_drop_anchor;
			}
		}

		private void dgvDrop_CellMouseEnter(object sender, DataGridViewCellEventArgs args)
		{
			dgvDrop.Focus();
			dgvDrop.ClearSelection();
			dgvDrop.Rows[args.RowIndex].Selected = true;
		}

		private void dgvDrop_CellMouseClick(object sender, DataGridViewCellMouseEventArgs args)
		{
			HideDropDownList();

			if ((Items == null) || (Items.Count < 0))
			{
				return;
			}

			var item = (Item)(dgvDrop.Rows[args.RowIndex].Tag);

			if (ReplaceMain)
			{
				var prev_item = MainItem;
				prev_item.Main = false;
				item.Main = true;
				OnMainReplaced(prev_item, item);
				UpdateMainButton();
			}

			OnItemClicked(item);
			item.OnClicked();
		}

		private void ItemsListChanged(object sender, EventArgs args)
		{
			UpdateMainButton();
		}

		private void UpdateMainButton()
		{
			btnMain.Text = MainItem.Text;
			btnMain.Image = MainItem.Icon;
		}
	}
}