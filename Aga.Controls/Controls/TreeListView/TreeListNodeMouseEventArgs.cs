using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Quimron.WinUI.Controls.TreeListView.NodeControls;

namespace Quimron.WinUI.Controls.TreeListView
{
	public class TreeListNodeMouseEventArgs : MouseEventArgs
	{
		private TreeListNode _node;
		public TreeListNode Node
		{
			get { return _node; }
			internal set { _node = value; }
		}

		private NodeControl _control;
		public NodeControl Control
		{
			get { return _control; }
			internal set { _control = value; }
		}

		private Point _viewLocation;
		public Point ViewLocation
		{
			get { return _viewLocation; }
			internal set { _viewLocation = value; }
		}

		private Keys _modifierKeys;
		public Keys ModifierKeys
		{
			get { return _modifierKeys; }
			internal set { _modifierKeys = value; }
		}

		private bool _handled;
		public bool Handled
		{
			get { return _handled; }
			set { _handled = value; }
		}

		private Rectangle _controlBounds;
		public Rectangle ControlBounds
		{
			get { return _controlBounds; }
			internal set { _controlBounds = value; }
		}

		public TreeListNodeMouseEventArgs(MouseEventArgs args)
			: base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
		{
		}
	}
}
