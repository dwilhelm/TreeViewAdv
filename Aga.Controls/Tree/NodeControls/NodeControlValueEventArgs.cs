using System;
using System.Collections.Generic;
using System.Text;

namespace Aga.Controls.Tree.NodeControls
{
	public class NodeControlValueEventArgs: EventArgs
	{
		private TreeNodeAdv _node;
		public TreeNodeAdv Node
		{
			get { return _node; }
		}

		private object _value;
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public NodeControlValueEventArgs(TreeNodeAdv node)
		{
			_node = node;
		}
	}
}
