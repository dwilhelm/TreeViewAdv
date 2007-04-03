using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	public struct DropPosition
	{
		private TreeListNode _node;
		public TreeListNode Node
		{
			get { return _node; }
			set { _node = value; }
		}

		private NodePosition _position;
		public NodePosition Position
		{
			get { return _position; }
			set { _position = value; }
		}
	}
}
