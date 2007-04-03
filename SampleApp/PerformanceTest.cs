using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;

namespace SampleApp
{
	public partial class PerformanceTest : UserControl
	{
		private const int Num = 25000;

		public PerformanceTest()
		{
			InitializeComponent();
		}

		private void SetModel(ITreeModel model, Label label)
		{
			label.Text = "Working";
			Application.DoEvents();

			_treeView.Model = null;
			GC.Collect(3);

			DateTime st = DateTime.Now;

			_treeView.Model = model;

			DateTime en = DateTime.Now;
			label.Text = ((TimeSpan)(en - st)).TotalMilliseconds.ToString();
		}

		private void _load_Click(object sender, EventArgs e)
		{
			ITreeModel model = new PerformaceTestModel(Num);
			SetModel(model, label1);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			label2.Text = "Working";
			Application.DoEvents();

			DateTime st = DateTime.Now;

			treeView1.BeginUpdate();
			for (int i = 0; i < Num; i++ )
				treeView1.Nodes.Add(new TreeNode(i.ToString()));
			treeView1.EndUpdate();

			DateTime en = DateTime.Now;
			label2.Text = ((TimeSpan)(en - st)).TotalMilliseconds.ToString();
		}
	}
}
