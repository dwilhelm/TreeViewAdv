using System;
using System.Windows.Forms;
namespace Quimron.WinUI.Controls.TreeListView
{
	internal abstract class InputState
	{
		private TreeListView _tree;

		public TreeListView Tree
		{
			get { return _tree; }
		}

		public InputState(TreeListView tree)
		{
			_tree = tree;
		}

		public abstract void KeyDown(System.Windows.Forms.KeyEventArgs args);
		public abstract void MouseDown(TreeListNodeMouseEventArgs args);
		public abstract void MouseUp(TreeListNodeMouseEventArgs args);

		/// <summary>
		/// handle OnMouseMove event
		/// </summary>
		/// <param name="args"></param>
		/// <returns>true if event was handled and should be dispatched</returns>
		public virtual bool MouseMove(MouseEventArgs args)
		{
			return false;
		}
	}
}
