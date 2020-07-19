using System;

namespace ImbaControls.DropDownButton
{
	public class ItemClickedEventArgs : EventArgs
	{
		public Item Item { get; set; }

		public ItemClickedEventArgs(Item item)
		{
			Item = item;
		}
	}
}