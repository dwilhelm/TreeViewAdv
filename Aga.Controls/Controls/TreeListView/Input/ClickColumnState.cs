using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Quimron.WinUI.Controls.TreeListView
{
	internal class ClickColumnState : ColumnState
	{
		private Point _location;

		public ClickColumnState(TreeListView tree, TreeColumn column, Point location)
			: base(tree, column)
		{
			_location = location;
		}

		public override void KeyDown(KeyEventArgs args)
		{
		}

		public override void MouseDown(TreeListNodeMouseEventArgs args)
		{
		}

		public override bool MouseMove(MouseEventArgs args)
		{
			if (TreeListView.Dist(_location, args.Location) > TreeListView.ItemDragSensivity
				&& Tree.AllowColumnReorder)
			{
				Tree.Input = new ReorderColumnState(Tree, Column);
				Tree.UpdateView();
			}
			return true;
		}

		public override void MouseUp(TreeListNodeMouseEventArgs args)
		{
			Tree.ChangeInput();
			Tree.UpdateView();
			Tree.OnColumnClicked(Column);
		}
	}
}
