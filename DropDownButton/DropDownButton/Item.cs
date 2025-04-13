namespace ImbaControls.DropDownButton
{
    using System;
    using System.Drawing;

    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public class Item
	{
		public Image Icon { get; set; }
		public string Text { get; set; }
		public bool Main { get; set; }

		public event EventHandler<ClickedEventArgs> Clicked;

        internal virtual void OnClicked(ClickedEventArgs args) => Clicked?.Invoke(this, args);

        internal virtual void OnClicked() => OnClicked(new ClickedEventArgs());

        public Item()
		{
			Main = false;
		}

		public Item(string text)
			: this()
		{
			Text = text;
		}

		public Item(Image icon, string text)
			: this(text)
		{
			Icon = icon;
		}

		public Item(string text, EventHandler<ClickedEventArgs> callback)
			: this(text)
		{
			Clicked += callback;
		}

		public Item(Image icon, string text, EventHandler<ClickedEventArgs> callback)
			: this(icon, text)
		{
			Clicked += callback;
		}
	}
}