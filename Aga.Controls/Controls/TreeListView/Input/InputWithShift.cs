using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	internal class InputWithShift: NormalInputState
	{
		public InputWithShift(TreeListView tree): base(tree)
		{
		}

		protected override void FocusRow(TreeListNode node)
		{
			Tree.SuspendSelectionEvent = true;
			try
			{
				if (Tree.SelectionMode == TreeSelectionMode.Single || Tree.SelectionStart == null)
					base.FocusRow(node);
				else if (CanSelect(node))
				{
					SelectAllFromStart(node);
					Tree.CurrentNode = node;
					Tree.ScrollTo(node);
				}
			}
			finally
			{
				Tree.SuspendSelectionEvent = false;
			}
		}

		protected override void DoMouseOperation(TreeListNodeMouseEventArgs args)
		{
			if (Tree.SelectionMode == TreeSelectionMode.Single || Tree.SelectionStart == null)
			{
				base.DoMouseOperation(args);
			}
			else if (CanSelect(args.Node))
			{
				Tree.SuspendSelectionEvent = true;
				try
				{
					SelectAllFromStart(args.Node);
				}
				finally
				{
					Tree.SuspendSelectionEvent = false;
				}
			}
		}

		protected override void MouseDownAtEmptySpace(TreeListNodeMouseEventArgs args)
		{
		}

		private void SelectAllFromStart(TreeListNode node)
		{
			Tree.ClearSelection();
			int a = node.Row;
			int b = Tree.SelectionStart.Row;
			for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
			{
				if (Tree.SelectionMode == TreeSelectionMode.Multi || Tree.RowMap[i].Parent == node.Parent)
					Tree.RowMap[i].IsSelected = true;
			}
		}
	}
}
