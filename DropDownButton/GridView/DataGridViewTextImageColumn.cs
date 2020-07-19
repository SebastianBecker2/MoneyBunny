using System.Drawing;
using System.Windows.Forms;

namespace ImbaControls
{
	public class DataGridViewTextImageColumn : DataGridViewTextBoxColumn
	{
		private Image imageValue;
		private Size imageSize;

		public DataGridViewTextImageColumn()
		{
			this.CellTemplate = new DataGridViewTextImageCell();
		}

		public override object Clone()
		{
			var c = base.Clone() as DataGridViewTextImageColumn;
			c.imageValue = this.imageValue;
			c.imageSize = this.imageSize;
			return c;
		}

		public Image Image
		{
			get { return this.imageValue; }
			set
			{
				if (this.Image != value)
				{
					this.imageValue = value;
					this.imageSize = value.Size;

					if (this.InheritedStyle != null)
					{
						Padding inheritedPadding = this.InheritedStyle.Padding;
						this.DefaultCellStyle.Padding = new Padding(imageSize.Width,
					 inheritedPadding.Top, inheritedPadding.Right,
					 inheritedPadding.Bottom);
					}
				}
			}
		}

		private DataGridViewTextImageCell TextAndImageCellTemplate
		{
			get { return this.CellTemplate as DataGridViewTextImageCell; }
		}

		internal Size ImageSize
		{
			get { return imageSize; }
		}
	}
}