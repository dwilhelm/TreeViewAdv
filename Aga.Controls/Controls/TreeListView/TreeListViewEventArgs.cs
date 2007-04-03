using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	public class TreeListViewEventArgs: EventArgs
	{
		private TreeListNode _node;

		public TreeListNode Node
		{
			get { return _node; }
		}

		public TreeListViewEventArgs(TreeListNode node)
		{
			_node = node;
		}
	}
}
