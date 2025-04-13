namespace ImbaControls.DropDownButton
{
    using System;

    public class MainChangedEventArgs : EventArgs
	{
		public Item PreviousItem { get; set; }
		public Item NewItem { get; set; }

		public MainChangedEventArgs(Item previousItem, Item newItem)
		{
			PreviousItem = previousItem;
			NewItem = newItem;
		}
	}
}