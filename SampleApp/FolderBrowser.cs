using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Tree;

namespace SampleApp
{
	public partial class FolderBrowser : UserControl
	{
		private class ToolTipProvider: IToolTipProvider
		{
			public string GetToolTip(TreeNodeAdv node, NodeControl nodeControl)
			{
				if (node.Tag is RootItem)
					return null;
				else
					return "Second click to rename node";
			}
		}

		public FolderBrowser()
		{
			InitializeComponent();
			
			_name.ToolTipProvider = new ToolTipProvider();
			_name.EditorShowing += new CancelEventHandler(_name_EditorShowing);

			_treeView.Model = new FolderBrowserModel();
		}

		void _name_EditorShowing(object sender, CancelEventArgs e)
		{
			if (_treeView.CurrentNode.Tag is RootItem)
				e.Cancel = true;
		}

		private void _treeView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				NodeControlInfo info = _treeView.GetNodeControlInfoAt(e.Location);
				if (info.Control != null)
				{
					Console.WriteLine(info.Bounds);
					//TODO: Show specific context menu for Node and NodeControl
				}
			}
		}
	}
}
