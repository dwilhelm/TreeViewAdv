namespace SampleApp
{
	partial class PerformanceTest
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._load = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._treeView = new Aga.Controls.Tree.TreeViewAdv();
			this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _load
			// 
			this._load.Location = new System.Drawing.Point(3, 332);
			this._load.Name = "_load";
			this._load.Size = new System.Drawing.Size(142, 23);
			this._load.TabIndex = 1;
			this._load.Text = "Load";
			this._load.UseVisualStyleBackColor = true;
			this._load.Click += new System.EventHandler(this._load_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "TreeViewAdv";
			// 
			// _treeView
			// 
			this._treeView.BackColor = System.Drawing.SystemColors.Window;
			this._treeView.Cursor = System.Windows.Forms.Cursors.Default;
			this._treeView.DefaultToolTipProvider = null;
			this._treeView.DragDropMarkColor = System.Drawing.Color.Black;
			this._treeView.LineColor = System.Drawing.SystemColors.ControlDark;
			this._treeView.LoadOnDemand = true;
			this._treeView.Location = new System.Drawing.Point(3, 32);
			this._treeView.Model = null;
			this._treeView.Name = "_treeView";
			this._treeView.NodeControls.Add(this.nodeTextBox1);
			this._treeView.SelectedNode = null;
			this._treeView.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.Multi;
			this._treeView.Size = new System.Drawing.Size(269, 294);
			this._treeView.TabIndex = 0;
			this._treeView.Text = "treeViewAdv1";
			// 
			// nodeTextBox1
			// 
			this.nodeTextBox1.DataPropertyName = "Text";
			this.nodeTextBox1.IncrementalSearchEnabled = true;
			this.nodeTextBox1.ParentColumn = null;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(273, 332);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(142, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Load";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(273, 32);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(269, 294);
			this.treeView1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(275, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Windows.Forms.TreeView";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(421, 332);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(502, 332);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// PerformanceTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._load);
			this.Controls.Add(this._treeView);
			this.Name = "PerformanceTest";
			this.Size = new System.Drawing.Size(598, 387);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Aga.Controls.Tree.TreeViewAdv _treeView;
		private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
		private System.Windows.Forms.Button _load;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}
