using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;
using Aga.Controls;

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

		private void button2_Click(object sender, EventArgs e)
		{
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear();
			for (int i = 0; i < 50; i++)
			{
				treeView1.Nodes.Add(i.ToString());
				for (int n = 0; n < 50; n++)
				{
					treeView1.Nodes[i].Nodes.Add(n.ToString());
					for (int k = 0; k < 10; k++)
						treeView1.Nodes[i].Nodes[n].Nodes.Add(k.ToString());
				}
			}
			treeView1.EndUpdate();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			TimeCounter.Start();

			treeView1.BeginUpdate();
			if (treeView1.Nodes[0].IsExpanded)
				treeView1.CollapseAll();
			else
				treeView1.ExpandAll();
			treeView1.EndUpdate();

			label2.Text = TimeCounter.Finish().ToString();
		}
	}
}
