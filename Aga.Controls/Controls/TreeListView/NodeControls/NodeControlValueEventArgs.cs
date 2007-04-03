using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView.NodeControls
{
	public class NodeControlValueEventArgs : NodeEventArgs
	{
		private object _value;
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public NodeControlValueEventArgs(TreeListNode node)
			:base(node)
		{
		}
	}
}
