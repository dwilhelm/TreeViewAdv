namespace SampleApp
{
    partial class ColumnHandling
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewAdv1 = new Aga.Controls.Tree.TreeViewAdv();
            this.treeColumn1 = new Aga.Controls.Tree.TreeColumn();
            this.treeColumn2 = new Aga.Controls.Tree.TreeColumn();
            this.treeColumn3 = new Aga.Controls.Tree.TreeColumn();
            this.treeColumn4 = new Aga.Controls.Tree.TreeColumn();
            this.treeColumn5 = new Aga.Controls.Tree.TreeColumn();
            this.SuspendLayout();
            // 
            // treeViewAdv1
            // 
            this.treeViewAdv1.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAdv1.Columns.Add(this.treeColumn1);
            this.treeViewAdv1.Columns.Add(this.treeColumn2);
            this.treeViewAdv1.Columns.Add(this.treeColumn3);
            this.treeViewAdv1.Columns.Add(this.treeColumn4);
            this.treeViewAdv1.Columns.Add(this.treeColumn5);
            this.treeViewAdv1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewAdv1.DefaultToolTipProvider = null;
            this.treeViewAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAdv1.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeViewAdv1.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeViewAdv1.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv1.Model = null;
            this.treeViewAdv1.Name = "treeViewAdv1";
            this.treeViewAdv1.Search.BackColor = System.Drawing.Color.Pink;
            this.treeViewAdv1.Search.FontColor = System.Drawing.Color.Black;
            this.treeViewAdv1.SelectedNode = null;
            this.treeViewAdv1.Size = new System.Drawing.Size(626, 406);
            this.treeViewAdv1.TabIndex = 0;
            this.treeViewAdv1.Text = "treeViewAdv1";
            this.treeViewAdv1.UseColumns = true;
            // 
            // treeColumn1
            // 
            this.treeColumn1.Header = "Can be width 0";
            this.treeColumn1.Left = 0;
            this.treeColumn1.MinColumnWidth = 0;
            this.treeColumn1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn1.Width = 100;
            // 
            // treeColumn2
            // 
            this.treeColumn2.Header = "Can not be width 0";
            this.treeColumn2.Left = 100;
            this.treeColumn2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn2.Width = 150;
            // 
            // treeColumn3
            // 
            this.treeColumn3.Header = "Fixed";
            this.treeColumn3.Left = 250;
            this.treeColumn3.MaxColumnWidth = 100;
            this.treeColumn3.MinColumnWidth = 100;
            this.treeColumn3.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn3.Width = 100;
            // 
            // treeColumn4
            // 
            this.treeColumn4.Header = "Can be max width 150";
            this.treeColumn4.Left = 350;
            this.treeColumn4.MaxColumnWidth = 150;
            this.treeColumn4.MinColumnWidth = 0;
            this.treeColumn4.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn4.Width = 150;
            // 
            // treeColumn5
            // 
            this.treeColumn5.Header = "Can be 0";
            this.treeColumn5.Left = 500;
            this.treeColumn5.MinColumnWidth = 0;
            this.treeColumn5.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeColumn5.Width = 75;
            // 
            // ColumnHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewAdv1);
            this.Name = "ColumnHandling";
            this.Size = new System.Drawing.Size(626, 406);
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.TreeViewAdv treeViewAdv1;
        private Aga.Controls.Tree.TreeColumn treeColumn1;
        private Aga.Controls.Tree.TreeColumn treeColumn2;
        private Aga.Controls.Tree.TreeColumn treeColumn3;
        private Aga.Controls.Tree.TreeColumn treeColumn4;
        private Aga.Controls.Tree.TreeColumn treeColumn5;
    }
}
