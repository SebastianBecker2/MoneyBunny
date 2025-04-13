namespace ImbaControls.DropDownButton
{
    using System;

    public class ItemClickedEventArgs : EventArgs
	{
		public Item Item { get; set; }

		public ItemClickedEventArgs(Item item)
		{
			Item = item;
		}
	}
}