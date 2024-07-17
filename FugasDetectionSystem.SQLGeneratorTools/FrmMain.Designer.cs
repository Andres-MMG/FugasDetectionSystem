namespace FugasDetectionSystem.SQLGeneratorTools
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cRUDToolStripMenuItem = new ToolStripMenuItem();
            todos5ToolStripMenuItem = new ToolStripMenuItem();
            insertToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deteleToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            selectByIdToolStripMenuItem = new ToolStripMenuItem();
            repositoryToolStripMenuItem = new ToolStripMenuItem();
            splitContainer2 = new SplitContainer();
            DGVColumnas = new DataGridView();
            splitContainer3 = new SplitContainer();
            gBoxTableName = new GroupBox();
            cBALLSp = new CheckBox();
            groupBox1 = new GroupBox();
            cBById = new CheckBox();
            cBAll = new CheckBox();
            cBDelete = new CheckBox();
            cBUpdate = new CheckBox();
            cBInsert = new CheckBox();
            tabControl1 = new TabControl();
            tabScript = new TabPage();
            RTBInsert = new RichTextBox();
            menuStrip1 = new MenuStrip();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            playToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVColumnas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            gBoxTableName.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabScript.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(775, 487);
            splitContainer1.SplitterDistance = 256;
            splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.ContextMenuStrip = contextMenuStrip1;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(256, 487);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cRUDToolStripMenuItem, repositoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(131, 48);
            // 
            // cRUDToolStripMenuItem
            // 
            cRUDToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { todos5ToolStripMenuItem, insertToolStripMenuItem, updateToolStripMenuItem, deteleToolStripMenuItem, selectAllToolStripMenuItem, selectByIdToolStripMenuItem });
            cRUDToolStripMenuItem.Name = "cRUDToolStripMenuItem";
            cRUDToolStripMenuItem.Size = new Size(130, 22);
            cRUDToolStripMenuItem.Text = "CRUD";
            // 
            // todos5ToolStripMenuItem
            // 
            todos5ToolStripMenuItem.Checked = true;
            todos5ToolStripMenuItem.CheckOnClick = true;
            todos5ToolStripMenuItem.CheckState = CheckState.Checked;
            todos5ToolStripMenuItem.Name = "todos5ToolStripMenuItem";
            todos5ToolStripMenuItem.Size = new Size(134, 22);
            todos5ToolStripMenuItem.Text = "ALL SP (5)";
            todos5ToolStripMenuItem.Click += todos5ToolStripMenuItem_Click;
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Checked = true;
            insertToolStripMenuItem.CheckOnClick = true;
            insertToolStripMenuItem.CheckState = CheckState.Checked;
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new Size(134, 22);
            insertToolStripMenuItem.Text = "Insert";
            insertToolStripMenuItem.Click += insertToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Checked = true;
            updateToolStripMenuItem.CheckOnClick = true;
            updateToolStripMenuItem.CheckState = CheckState.Checked;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(134, 22);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // deteleToolStripMenuItem
            // 
            deteleToolStripMenuItem.Checked = true;
            deteleToolStripMenuItem.CheckOnClick = true;
            deteleToolStripMenuItem.CheckState = CheckState.Checked;
            deteleToolStripMenuItem.Name = "deteleToolStripMenuItem";
            deteleToolStripMenuItem.Size = new Size(134, 22);
            deteleToolStripMenuItem.Text = "Detele";
            deteleToolStripMenuItem.Click += deteleToolStripMenuItem_Click;
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Checked = true;
            selectAllToolStripMenuItem.CheckOnClick = true;
            selectAllToolStripMenuItem.CheckState = CheckState.Checked;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(134, 22);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // selectByIdToolStripMenuItem
            // 
            selectByIdToolStripMenuItem.Checked = true;
            selectByIdToolStripMenuItem.CheckOnClick = true;
            selectByIdToolStripMenuItem.CheckState = CheckState.Checked;
            selectByIdToolStripMenuItem.Name = "selectByIdToolStripMenuItem";
            selectByIdToolStripMenuItem.Size = new Size(134, 22);
            selectByIdToolStripMenuItem.Text = "Select by Id";
            selectByIdToolStripMenuItem.Click += selectByIdToolStripMenuItem_Click;
            // 
            // repositoryToolStripMenuItem
            // 
            repositoryToolStripMenuItem.Name = "repositoryToolStripMenuItem";
            repositoryToolStripMenuItem.Size = new Size(130, 22);
            repositoryToolStripMenuItem.Text = "Repository";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(DGVColumnas);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(515, 487);
            splitContainer2.SplitterDistance = 188;
            splitContainer2.TabIndex = 0;
            // 
            // DGVColumnas
            // 
            DGVColumnas.AllowUserToAddRows = false;
            DGVColumnas.AllowUserToDeleteRows = false;
            DGVColumnas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVColumnas.Dock = DockStyle.Fill;
            DGVColumnas.Location = new Point(0, 0);
            DGVColumnas.Name = "DGVColumnas";
            DGVColumnas.ReadOnly = true;
            DGVColumnas.Size = new Size(515, 188);
            DGVColumnas.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(gBoxTableName);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(tabControl1);
            splitContainer3.Size = new Size(515, 295);
            splitContainer3.SplitterDistance = 87;
            splitContainer3.TabIndex = 0;
            // 
            // gBoxTableName
            // 
            gBoxTableName.Controls.Add(cBALLSp);
            gBoxTableName.Controls.Add(groupBox1);
            gBoxTableName.Dock = DockStyle.Fill;
            gBoxTableName.Location = new Point(0, 0);
            gBoxTableName.Name = "gBoxTableName";
            gBoxTableName.Size = new Size(515, 87);
            gBoxTableName.TabIndex = 0;
            gBoxTableName.TabStop = false;
            gBoxTableName.Text = "Table Name";
            // 
            // cBALLSp
            // 
            cBALLSp.AutoSize = true;
            cBALLSp.Checked = true;
            cBALLSp.CheckState = CheckState.Checked;
            cBALLSp.Location = new Point(19, 13);
            cBALLSp.Name = "cBALLSp";
            cBALLSp.Size = new Size(56, 19);
            cBALLSp.TabIndex = 5;
            cBALLSp.Text = "All Sp";
            cBALLSp.UseVisualStyleBackColor = true;
            cBALLSp.Click += cBALLSp_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cBById);
            groupBox1.Controls.Add(cBAll);
            groupBox1.Controls.Add(cBDelete);
            groupBox1.Controls.Add(cBUpdate);
            groupBox1.Controls.Add(cBInsert);
            groupBox1.Location = new Point(0, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(515, 67);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // cBById
            // 
            cBById.AutoSize = true;
            cBById.Checked = true;
            cBById.CheckState = CheckState.Checked;
            cBById.Location = new Point(411, 28);
            cBById.Name = "cBById";
            cBById.Size = new Size(83, 19);
            cBById.TabIndex = 9;
            cBById.Text = "Select ById";
            cBById.UseVisualStyleBackColor = true;
            cBById.Click += cBById_Click;
            // 
            // cBAll
            // 
            cBAll.AutoSize = true;
            cBAll.Checked = true;
            cBAll.CheckState = CheckState.Checked;
            cBAll.Location = new Point(305, 28);
            cBAll.Name = "cBAll";
            cBAll.Size = new Size(74, 19);
            cBAll.TabIndex = 8;
            cBAll.Text = "Select All";
            cBAll.UseVisualStyleBackColor = true;
            cBAll.Click += cBAll_Click;
            // 
            // cBDelete
            // 
            cBDelete.AutoSize = true;
            cBDelete.Checked = true;
            cBDelete.CheckState = CheckState.Checked;
            cBDelete.Location = new Point(214, 28);
            cBDelete.Name = "cBDelete";
            cBDelete.Size = new Size(59, 19);
            cBDelete.TabIndex = 7;
            cBDelete.Text = "Delete";
            cBDelete.UseVisualStyleBackColor = true;
            cBDelete.Click += cBDelete_Click;
            // 
            // cBUpdate
            // 
            cBUpdate.AutoSize = true;
            cBUpdate.Checked = true;
            cBUpdate.CheckState = CheckState.Checked;
            cBUpdate.Location = new Point(118, 28);
            cBUpdate.Name = "cBUpdate";
            cBUpdate.Size = new Size(64, 19);
            cBUpdate.TabIndex = 6;
            cBUpdate.Text = "Update";
            cBUpdate.UseVisualStyleBackColor = true;
            cBUpdate.Click += cBUpdate_Click;
            // 
            // cBInsert
            // 
            cBInsert.AutoSize = true;
            cBInsert.Checked = true;
            cBInsert.CheckState = CheckState.Checked;
            cBInsert.Location = new Point(31, 28);
            cBInsert.Name = "cBInsert";
            cBInsert.Size = new Size(55, 19);
            cBInsert.TabIndex = 5;
            cBInsert.Text = "Insert";
            cBInsert.UseVisualStyleBackColor = true;
            cBInsert.Click += cBInsert_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabScript);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(515, 204);
            tabControl1.TabIndex = 1;
            // 
            // tabScript
            // 
            tabScript.Controls.Add(RTBInsert);
            tabScript.Location = new Point(4, 24);
            tabScript.Name = "tabScript";
            tabScript.Padding = new Padding(3);
            tabScript.Size = new Size(507, 176);
            tabScript.TabIndex = 0;
            tabScript.Text = "TabScript";
            tabScript.UseVisualStyleBackColor = true;
            // 
            // RTBInsert
            // 
            RTBInsert.Dock = DockStyle.Fill;
            RTBInsert.Location = new Point(3, 3);
            RTBInsert.Name = "RTBInsert";
            RTBInsert.Size = new Size(501, 170);
            RTBInsert.TabIndex = 0;
            RTBInsert.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, playToolStripMenuItem, configToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(775, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(58, 20);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(41, 20);
            playToolStripMenuItem.Text = "Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(55, 20);
            configToolStripMenuItem.Text = "Config";
            configToolStripMenuItem.Click += configToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 511);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(700, 400);
            Name = "FrmMain";
            Text = "FormMain";
            Load += FormMain_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVColumnas).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            gBoxTableName.ResumeLayout(false);
            gBoxTableName.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabScript.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private SplitContainer splitContainer2;
        private DataGridView DGVColumnas;
        private DataGridViewCheckBoxColumn IsIdentity;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn DataType;
        private DataGridViewCheckBoxColumn AllowNulls;
        private SplitContainer splitContainer3;
        private GroupBox gBoxTableName;
        private TabControl tabControl1;
        private TabPage tabScript;
        private RichTextBox RTBInsert;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cRUDToolStripMenuItem;
        private ToolStripMenuItem todos5ToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deteleToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem selectByIdToolStripMenuItem;
        private ToolStripMenuItem repositoryToolStripMenuItem;
        private CheckBox cBALLSp;
        private GroupBox groupBox1;
        private CheckBox cBById;
        private CheckBox cBAll;
        private CheckBox cBDelete;
        private CheckBox cBUpdate;
        private CheckBox cBInsert;
        private ToolStripMenuItem configToolStripMenuItem;
    }
}