namespace ImbaControls
{
    using System;
    using System.Windows.Forms;

    public class DataGridViewProgressColumn : DataGridViewColumn
	{
		public DataGridViewProgressColumn()
			: base(new DataGridViewProgressCell())
		{
		}

		public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if ((value != null) && (!value.GetType().IsAssignableFrom(typeof(DataGridViewProgressCell))))
                {
                    throw new InvalidCastException("Must be a ImbaDataGridViewProgressCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}