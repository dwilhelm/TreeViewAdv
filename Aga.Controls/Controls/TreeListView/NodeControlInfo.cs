using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Quimron.WinUI.Controls.TreeListView.NodeControls;

namespace Quimron.WinUI.Controls.TreeListView
{
	public struct NodeControlInfo
	{
		public static readonly NodeControlInfo Empty = new NodeControlInfo(null, Rectangle.Empty, null);

		private NodeControl _control;
		public NodeControl Control
		{
			get { return _control; }
		}

		private Rectangle _bounds;
		public Rectangle Bounds
		{
			get { return _bounds; }
		}

		private TreeListNode _node;
		public TreeListNode Node
		{
			get { return _node; }
		}

		public NodeControlInfo(NodeControl control, Rectangle bounds, TreeListNode node)
		{
			_control = control;
			_bounds = bounds;
			_node = node;
		}
	}
}
