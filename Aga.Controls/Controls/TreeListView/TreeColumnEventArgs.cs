using System;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView
{
	public class TreeColumnEventArgs: EventArgs
	{
		private TreeColumn _column;
		public TreeColumn Column
		{
			get { return _column; }
		}

		public TreeColumnEventArgs(TreeColumn column)
		{
			_column = column;
		}
	}
}
