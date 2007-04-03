using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	public class TreeListViewCancelEventArgs : TreeListViewEventArgs
	{
		private bool _cancel;

		public bool Cancel
		{
			get { return _cancel; }
			set { _cancel = value; }
		}

		public TreeListViewCancelEventArgs(TreeListNode node)
			: base(node)
		{
		}

	}
}
