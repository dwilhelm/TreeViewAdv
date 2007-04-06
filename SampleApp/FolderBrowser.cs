using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Tree;
using System.Collections;

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

            cboxGrid.DataSource = System.Enum.GetValues(typeof(GridLineStyle));

            cbLines.Checked = _treeView.ShowLines;
            cbGrid.Checked = _treeView.GridLineVisible;

			_name.ToolTipProvider = new ToolTipProvider();
			_name.EditorShowing += new CancelEventHandler(_name_EditorShowing);

			_treeView.Model = new SortedTreeModel(new FolderBrowserModel());

            _treeView.GridChanged += new EventHandler<TreeViewAdvEventArgs>(_treeView_GridChanged);

		}

        void _treeView_GridChanged(object sender, TreeViewAdvEventArgs e)
        {
            cbGrid.Checked = _treeView.GridLineVisible;
            cboxGrid.SelectedItem = _treeView.GridLine;
            Console.WriteLine(DateTime.Now);
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
				}
			}
		}

		private void _treeView_ColumnClicked(object sender, TreeColumnEventArgs e)
		{
            TreeColumn clicked = e.Column;
            if (clicked.SortOrder == SortOrder.Ascending)
                clicked.SortOrder = SortOrder.Descending;
            else
                clicked.SortOrder = SortOrder.Ascending;

            (_treeView.Model as SortedTreeModel).Comparer = new FolderItemSorter(clicked.Header, clicked.SortOrder);
		}

        private void cboxGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            _treeView.GridLine = (GridLineStyle)cboxGrid.SelectedItem;
        }

        private void cbGrid_CheckedChanged(object sender, EventArgs e)
        {
            _treeView.GridLineVisible = cbGrid.Checked;
        }

        private void cbLines_CheckedChanged(object sender, EventArgs e)
        {
            _treeView.ShowLines = cbLines.Checked;
        }
	}
}
