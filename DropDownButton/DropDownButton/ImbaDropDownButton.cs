namespace ImbaControls.DropDownButton
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

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
        public int ItemHeight { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(DefaultVisibleItemCount)]
        [Description("Sets the number of visible items when drop down list is shown")]
        public int VisibleItemCount { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the items displayed in the drop down list")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BindingList<Item> Items { get; }

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
            get => dgvDrop.Visible;
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
                if (!Items.Any((i) => i.Main))
                {
                    Items[0].Main = true;
                }
                else if (Items.Count((i) => i.Main) > 1)
                {
                    foreach (var item in Items.Where((i) => i.Main).Skip(1))
                    {
                        item.Main = false;
                    }
                }
                return Items.First((i) => i.Main);
            }
        }

        private readonly AnchorStyles btn_drop_anchor;
        private readonly AnchorStyles btn_main_anchor;
        private readonly AnchorStyles lsv_drop_anchor;

        #endregion

        #region Events

        // MainClicked
        public event EventHandler<MainClickedEventArgs> MainClicked;

        protected void OnMainClicked(MainClickedEventArgs args) => MainClicked?.Invoke(this, args);

        protected void OnMainClicked(Item item) => OnMainClicked(new MainClickedEventArgs(item));

        // ItemClicked
        public event EventHandler<ItemClickedEventArgs> ItemClicked;

        protected void OnItemClicked(ItemClickedEventArgs args) => ItemClicked?.Invoke(this, args);

        protected void OnItemClicked(Item item) => OnItemClicked(new ItemClickedEventArgs(item));

        // MainChanged
        public event EventHandler<MainChangedEventArgs> MainReplaced;

        protected void OnMainReplaced(MainChangedEventArgs args) => MainReplaced?.Invoke(this, args);

        protected void OnMainReplaced(Item previousItem, Item newItem) => OnMainReplaced(new MainChangedEventArgs(previousItem, newItem));

        // DropDownVisibleChanged
        public event EventHandler DropDownVisibleChanged;

        protected void OnDropDownVisibleChanged(EventArgs args) => DropDownVisibleChanged?.Invoke(this, args);

        #endregion

        public ImbaDropDownButton()
        {
            InitializeComponent();

            #region Initialize Values

            Items = [];
            Items.ListChanged += ItemsListChanged;
            VisibleItemCount = DefaultVisibleItemCount;
            ReplaceMain = DefaultReplaceMain;
            ShowMainInList = DefaultShowMainInList;
            ItemHeight = DefaultItemHeight;
            DropDownVisible = DefaultDropDownVisible;

            btn_drop_anchor = btnDrop.Anchor;
            btn_main_anchor = btnMain.Anchor;
            lsv_drop_anchor = dgvDrop.Anchor;

            #endregion

            #region Initialize dgvDrop

            ((DataGridViewImageColumn)dgvDrop.Columns[0]).DefaultCellStyle.NullValue = null;
            dgvDrop.CellMouseEnter += DgvDrop_CellMouseEnter;
            dgvDrop.CellMouseClick += DgvDrop_CellMouseClick;
            dgvDrop.VisibleChanged += (s, e) => OnDropDownVisibleChanged(e);

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

            foreach (var item in Items)
            {
                if ((!ShowMainInList) && (item == Items.First((i) => i.Main)))
                {
                    continue;
                }

                var row = new DataGridViewRow
                {
                    Tag = item
                };
                DataGridViewCell cell = new DataGridViewImageCell
                {
                    Value = item.Icon
                };
                if ((item.Icon != null) && (item.Icon.Width > dgvDrop.Columns[0].Width))
                {
                    dgvDrop.Columns[0].Width = item.Icon.Width;
                }
                _ = row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell
                {
                    Value = item.Text
                };
                _ = row.Cells.Add(cell);
                row.Height = ItemHeight;
                _ = dgvDrop.Rows.Add(row);
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
                Height += dgvDrop.Height;
                btnDrop.Anchor = btn_drop_anchor;
                btnMain.Anchor = btn_main_anchor;
                dgvDrop.Anchor = lsv_drop_anchor;

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
                Height -= dgvDrop.Height;
                dgvDrop.Height = 0;
                btnDrop.Anchor = btn_drop_anchor;
                btnMain.Anchor = btn_main_anchor;
                dgvDrop.Anchor = lsv_drop_anchor;
            }
        }

        private void DgvDrop_CellMouseEnter(object sender, DataGridViewCellEventArgs args)
        {
            _ = dgvDrop.Focus();
            dgvDrop.ClearSelection();
            dgvDrop.Rows[args.RowIndex].Selected = true;
        }

        private void DgvDrop_CellMouseClick(object sender, DataGridViewCellMouseEventArgs args)
        {
            HideDropDownList();

            if ((Items == null) || (Items.Count < 0))
            {
                return;
            }

            var item = (Item)dgvDrop.Rows[args.RowIndex].Tag;

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

        private void ItemsListChanged(object sender, EventArgs args) => UpdateMainButton();

        private void UpdateMainButton()
        {
            btnMain.Text = MainItem.Text;
            btnMain.Image = MainItem.Icon;
        }
    }
}
