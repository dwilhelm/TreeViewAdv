using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Quimron.WinUI.Controls.TreeListView;

namespace Quimron.WinUI.Controls.TreeListView.NodeControls
{
	public class NodeIcon : BindableControl
	{
		public override Size MeasureSize(TreeListNode node, DrawContext context)
		{
			Image image = GetIcon(node);
			if (image != null)
				return image.Size;
			else
				return Size.Empty;
		}

		public override void Draw(TreeListNode node, DrawContext context)
		{
			Image image = GetIcon(node);
			if (image != null)
			{
				Rectangle r = GetBounds(node, context);
				context.Graphics.DrawImage(image, r.Location);
			}
		}

		protected virtual Image GetIcon(TreeListNode node)
		{
			return GetValue(node) as Image;
		}
	}
}
