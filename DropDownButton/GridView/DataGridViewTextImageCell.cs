namespace ImbaControls
{
    using System.Drawing;
    using System.Windows.Forms;

    public class DataGridViewTextImageCell : DataGridViewTextBoxCell
	{
		private Image imageValue;
		private Size imageSize;

		public override object Clone()
		{
			var c = base.Clone() as DataGridViewTextImageCell;
			c.imageValue = this.imageValue;
			c.imageSize = this.imageSize;
			return c;
		}

		public Image Image
		{
			get
			{
				if (this.OwningColumn == null ||
			this.OwningTextAndImageColumn == null)
				{
					return imageValue;
				}
				else if (this.imageValue != null)
				{
					return this.imageValue;
				}
				else
				{
					return this.OwningTextAndImageColumn.Image;
				}
			}
			set
			{
				if (this.imageValue != value)
				{
					this.imageValue = value;
					this.imageSize = value.Size;

					this.Style.Padding = new Padding(imageSize.Width,
					this.Style.Padding.Top, this.Style.Padding.Right,
					this.Style.Padding.Bottom);
				}
			}
		}

		protected override void Paint(Graphics graphics, Rectangle clipBounds,
			Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
			object value, object formattedValue, string errorText,
			DataGridViewCellStyle cellStyle,
			DataGridViewAdvancedBorderStyle advancedBorderStyle,
			DataGridViewPaintParts paintParts)
		{
			// Paint the base content
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
			   value, formattedValue, errorText, cellStyle,
			   advancedBorderStyle, paintParts);

			if (this.Image != null)
			{
				// Draw the image clipped to the cell.
				var container =
					graphics.BeginContainer();

				graphics.SetClip(cellBounds);
				if (this.Image.Height < cellBounds.Height)
				{
					var padding = (cellBounds.Height - this.Image.Height) / 2;
					graphics.DrawImageUnscaled(this.Image, cellBounds.Location.X, cellBounds.Location.Y + padding);
				}
				else
				{
					graphics.DrawImageUnscaled(this.Image, cellBounds.Location);
				}

				graphics.EndContainer(container);
			}
		}

        private DataGridViewTextImageColumn OwningTextAndImageColumn => this.OwningColumn as DataGridViewTextImageColumn;
    }
}