namespace ImbaControls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class DataGridViewProgressCell : DataGridViewTextBoxCell
	{
		public double Progress { get; set; }

		public DataGridViewProgressCell()
		{
			//Style.SelectionForeColor = SystemColors.ControlText;
			Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}

        public override Type EditType => null;

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
			int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
			string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
			DataGridViewPaintParts paintParts)
		{
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
				formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts ^ DataGridViewPaintParts.ContentForeground);

			if (Progress > 0)
			{
                var rectangle = new Rectangle
                {
                    X = cellBounds.X + 2,
                    Y = cellBounds.Y + 2,
                    Width = Convert.ToInt32((cellBounds.Width - 6) * Progress),
                    Height = cellBounds.Height - 6
                };

                if (rectangle.Width > 0)
				{
                    using Brush brush = new LinearGradientBrush(rectangle, Color.LightGreen, Color.Green, LinearGradientMode.Vertical);
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(Pens.DimGray, rectangle);
                }
			}

			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
				formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts ^ DataGridViewPaintParts.Background);
		}
	}
}