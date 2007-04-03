using System;
using System.Collections.Generic;
using System.Text;
using Quimron.WinUI.Controls.TreeListView.NodeControls;

namespace Quimron.WinUI.Controls.TreeListView
{
	public interface IToolTipProvider
	{
		string GetToolTip(TreeListNode node, NodeControl nodeControl);
	}
}
