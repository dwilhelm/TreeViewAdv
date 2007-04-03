using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Quimron.WinUI.Controls.TreeListView
{
	[Serializable]
	public sealed class TreeListNode: ISerializable
	{
		#region NodeCollection
		private class NodeCollection : Collection<TreeListNode>
		{
			private TreeListNode _owner;

			public NodeCollection(TreeListNode owner)
			{
				_owner = owner;
			}

			protected override void ClearItems()
			{
				while (this.Count != 0)
					this.RemoveAt(this.Count - 1);
			}

			protected override void InsertItem(int index, TreeListNode item)
			{
				if (item == null)
					throw new ArgumentNullException("item");

				if (item.Parent != _owner)
				{
					if (item.Parent != null)
						item.Parent.Nodes.Remove(item);
					item._parent = _owner;
					item._index = index;
					for (int i = index; i < Count; i++)
						this[i]._index++;
					base.InsertItem(index, item);
				}
			}

			protected override void RemoveItem(int index)
			{
				TreeListNode item = this[index];
				item._parent = null;
				item._index = -1;
				for (int i = index + 1; i < Count; i++)
					this[i]._index--;
				base.RemoveItem(index);
			}

			protected override void SetItem(int index, TreeListNode item)
			{
				if (item == null)
					throw new ArgumentNullException("item");
				RemoveAt(index);
				InsertItem(index, item);
			}
		}
		#endregion


		#region Properties

		private TreeListView _tree;
		internal TreeListView Tree
		{
			get { return _tree; }
		}

		private int _row;
		internal int Row
		{
			get { return _row; }
			set { _row = value; }
		}

		private int _index = -1;
		public int Index
		{
			get
			{
				return _index;
			}
		}

		private bool _isSelected;
		public bool IsSelected
		{
			get { return _isSelected; }
			set 
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					if (Tree.IsMyNode(this))
					{
						if (_isSelected)
						{
							if (!_tree.Selection.Contains(this))
								_tree.Selection.Add(this);

							if (_tree.Selection.Count == 1)
								_tree.CurrentNode = this;
						}
						else
							_tree.Selection.Remove(this);
						_tree.UpdateView();
						_tree.OnSelectionChanged();
					}
				}
			}
		}

		private bool _isLeaf;
		public bool IsLeaf
		{
			get { return _isLeaf; }
			internal set { _isLeaf = value; }
		}

		private bool _isExpandedOnce;
		public bool IsExpandedOnce
		{
			get { return _isExpandedOnce; }
			internal set { _isExpandedOnce = value; }
		}

		private bool _isExpanded;
		public bool IsExpanded
		{
			get { return _isExpanded; }
			set 
			{
				if (Tree == null)
					_isExpanded = value;
				else if (Tree.IsMyNode(this) && _isExpanded != value)
					AssignIsExpanded(value);
			}
		}

		private TreeListNode _parent;
		public TreeListNode Parent
		{
			get { return _parent; }
			//internal set { _parent = value; }
		}

		public int Level
		{
			get
			{
				if (_parent == null)
					return 0;
				else
					return _parent.Level + 1;
			}
		}

		public TreeListNode NextNode
		{
			get
			{
				if (_parent != null)
				{
					int index = Index;
					if (index < _parent.Nodes.Count - 1)
						return _parent.Nodes[index + 1];
				}
				return null;
			}
		}

		internal TreeListNode BottomNode
		{
			get
			{
				TreeListNode parent = this.Parent;
				if (parent != null)
				{
					if (parent.NextNode != null)
						return parent.NextNode;
					else
						return parent.BottomNode;
				}
				return null;
			}
		}

		internal TreeListNode NextVisibleNode
		{
			get
			{
				if (IsExpanded && Nodes.Count > 0)
					return Nodes[0];
				else
				{
					TreeListNode nn = NextNode;
					if (nn != null)
						return nn;
					else
						return BottomNode;
				}
			}
		}

		public bool CanExpand
		{
			get
			{
				return (Nodes.Count > 0 || (!IsExpandedOnce && !IsLeaf));
			}
		}

		private object _tag;
		public object Tag
		{
			get { return _tag; }
		}

		private Collection<TreeListNode> _nodes;
		internal Collection<TreeListNode> Nodes
		{
			get { return _nodes; }
		}

		private ReadOnlyCollection<TreeListNode> _children;
		public ReadOnlyCollection<TreeListNode> Children
		{
			get
			{
				return _children;
			}
		}

		#endregion

		public TreeListNode(object tag): this(null, tag)
		{
		}

		internal TreeListNode(TreeListView tree, object tag)
		{
			_row = -1;
			_tree = tree;
			_nodes = new NodeCollection(this);
			_children = new ReadOnlyCollection<TreeListNode>(_nodes);
			_tag = tag;
		}

		public override string ToString()
		{
			if (Tag != null)
				return Tag.ToString();
			else
				return base.ToString();
		}

		private void AssignIsExpanded(bool value)
		{
			if (value)
				Tree.OnExpanding(this);
			else
				Tree.OnCollapsing(this);

			if (value && !_isExpandedOnce)
			{
				Cursor oldCursor = Tree.Cursor;
				try
				{
					Tree.Cursor = Cursors.WaitCursor;
					Tree.ReadChilds(this);
				}
				finally
				{
					Tree.Cursor = oldCursor;
				}
			}
			_isExpanded = value;
			Tree.SmartFullUpdate();

			if (value)
				Tree.OnExpanded(this);
			else
				Tree.OnCollapsed(this);
		}

		#region ISerializable Members

        private TreeListNode(SerializationInfo info, StreamingContext context): this(null, null)
        {
			int nodesCount = 0;
			nodesCount = info.GetInt32("NodesCount");
			_isExpanded = info.GetBoolean("IsExpanded");
			_tag = info.GetValue("Tag", typeof(object));

			for (int i = 0; i < nodesCount; i++)
			{
				TreeListNode child = (TreeListNode)info.GetValue("Child" + i, typeof(TreeListNode));
				Nodes.Add(child);
			}

        }

		[SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("IsExpanded", IsExpanded);
			info.AddValue("NodesCount", Nodes.Count);
			if ((Tag != null) && Tag.GetType().IsSerializable)
				info.AddValue("Tag", Tag, Tag.GetType());

			for (int i = 0; i < Nodes.Count; i++)
				info.AddValue("Child" + i, Nodes[i], typeof(TreeListNode));

		}

		#endregion
	}
}
