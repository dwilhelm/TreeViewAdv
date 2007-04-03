using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Drawing;

namespace Quimron.WinUI.Controls.TreeListView
{
	internal class ResizeColumnState: ColumnState
	{
		//private const int MinColumnWidth = 10;

		private Point _initLocation;
		private int _initWidth;

		public ResizeColumnState(TreeListView tree, TreeColumn column, Point p)
			: base(tree, column)
		{
			_initLocation = p;
			_initWidth = column.Width;
		}

		public override void KeyDown(KeyEventArgs args)
		{
			args.Handled = true;
			if (args.KeyCode == Keys.Escape)
				FinishResize();
		}

		public override void MouseDown(TreeListNodeMouseEventArgs args)
		{
		}

		public override void MouseUp(TreeListNodeMouseEventArgs args)
		{
			FinishResize();
		}

		private void FinishResize()
		{
			Tree.ChangeInput();
			Tree.FullUpdate();
			Tree.OnColumnWidthChanged(Column);
		}

        public override bool MouseMove(MouseEventArgs args)
        {
            int w = _initWidth + args.Location.X - _initLocation.X;
            Column.Width = Math.Max(Column.MinColumnWidth, w);
            Tree.UpdateView();
            return true;
        }
	}
}
