using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Aga.Controls.Tree.NodeControls
{
	public abstract class BindableControl: NodeControl
	{
		#region Properties

		private bool _virtualMode = false;
		[DefaultValue(false), Category("Data")]
		public bool VirtualMode
		{
			get { return _virtualMode; }
			set { _virtualMode = value; }
		}

		private string _propertyName = "";
		[DefaultValue(""), Category("Data")]
		public string DataPropertyName
		{
			get { return _propertyName; }
			set 
			{
				if (_propertyName == null)
					_propertyName = string.Empty;
				_propertyName = value; 
			}
		}

		private bool _incrementalSearchEnabled = false;
		[DefaultValue(true)]
		public bool IncrementalSearchEnabled
		{
			get { return _incrementalSearchEnabled; }
			set { _incrementalSearchEnabled = value; }
		}

		#endregion

		public virtual object GetValue(TreeNodeAdv node)
		{
			if (VirtualMode)
			{
				NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
				OnValueNeeded(args);
				return args.Value;
			}
			else
			{
				PropertyInfo pi = GetPropertyInfo(node);
				if (pi != null && pi.CanRead)
					return pi.GetValue(node.Tag, null);
				else
					return null;
			}
		}

		public virtual void SetValue(TreeNodeAdv node, object value)
		{
			if (VirtualMode)
			{
				NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
				args.Value = value;
				OnValuePushed(args);
			}
			else
			{
				PropertyInfo pi = GetPropertyInfo(node);
				if (pi != null && pi.CanWrite)
				{
					try
					{
						pi.SetValue(node.Tag, value, null);
					}
					catch (TargetInvocationException ex)
					{
						if (ex.InnerException != null)
							throw new ArgumentException(ex.InnerException.Message, ex.InnerException);
						else
							throw new ArgumentException(ex.Message);
					}
				}
			}
		}

		public Type GetPropertyType(TreeNodeAdv node)
		{
			if (node.Tag != null && !string.IsNullOrEmpty(DataPropertyName))
			{
				Type type = node.Tag.GetType();
				PropertyInfo pi = type.GetProperty(DataPropertyName);
				if (pi != null)
					return pi.PropertyType;
			}
			return null;
		}

		private PropertyInfo GetPropertyInfo(TreeNodeAdv node)
		{
			if (node.Tag != null && !string.IsNullOrEmpty(DataPropertyName))
			{
				Type type = node.Tag.GetType();
				return type.GetProperty(DataPropertyName);
			}
			return null;
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(DataPropertyName))
				return GetType().Name;
			else
				return string.Format("{0} ({1})", GetType().Name, DataPropertyName);
		}

		public event EventHandler<NodeControlValueEventArgs> ValueNeeded;
		private void OnValueNeeded(NodeControlValueEventArgs args)
		{
			if (ValueNeeded != null)
				ValueNeeded(this, args);
		}

		public event EventHandler<NodeControlValueEventArgs> ValuePushed;
		private void OnValuePushed(NodeControlValueEventArgs args)
		{
			if (ValuePushed != null)
				ValuePushed(this, args);
		}
	}
}
