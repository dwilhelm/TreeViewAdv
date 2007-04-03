using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView.NodeControls
{
	public class NodeEventArgs : EventArgs
	{
		private TreeListNode _node;
		public TreeListNode Node
		{
			get { return _node; }
		}

		public NodeEventArgs(TreeListNode node)
		{
			_node = node;
		}
	}
}
