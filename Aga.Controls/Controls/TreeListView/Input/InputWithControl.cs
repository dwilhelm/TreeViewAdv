using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	internal class InputWithControl: NormalInputState
	{
		public InputWithControl(TreeListView tree): base(tree)
		{
		}

		protected override void DoMouseOperation(TreeListNodeMouseEventArgs args)
		{
			if (Tree.SelectionMode == TreeSelectionMode.Single)
			{
				base.DoMouseOperation(args);
			}
			else if (CanSelect(args.Node))
			{
				args.Node.IsSelected = !args.Node.IsSelected;
				Tree.SelectionStart = args.Node;
			}
		}

		protected override void MouseDownAtEmptySpace(TreeListNodeMouseEventArgs args)
		{
		}
	}
}
