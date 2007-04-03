using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Quimron.WinUI.Controls.TreeListView.NodeControls
{
	public abstract class InteractiveControl: BindableControl
	{
		private bool _editEnabled = true;
		[DefaultValue(true)]
		public bool EditEnabled
		{
			get { return _editEnabled; }
			set { _editEnabled = value; }
		}

		protected bool IsEditEnabled(TreeListNode node)
		{
			if (EditEnabled)
			{
				NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
				args.Value = true;
				OnIsEditEnabledValueNeeded(args);
				return Convert.ToBoolean(args.Value);
			}
			else
				return false;
		}

		public event EventHandler<NodeControlValueEventArgs> IsEditEnabledValueNeeded;
		private void OnIsEditEnabledValueNeeded(NodeControlValueEventArgs args)
		{
			if (IsEditEnabledValueNeeded != null)
				IsEditEnabledValueNeeded(this, args);
		}
	}
}
