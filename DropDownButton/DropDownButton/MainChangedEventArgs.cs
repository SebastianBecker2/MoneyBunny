using System;

namespace ImbaControls.DropDownButton
{
	public class MainChangedEventArgs : EventArgs
	{
		public Item PreviousItem { get; set; }
		public Item NewItem { get; set; }

		public MainChangedEventArgs(Item previous_item, Item new_item)
		{
			PreviousItem = previous_item;
			NewItem = new_item;
		}
	}
}