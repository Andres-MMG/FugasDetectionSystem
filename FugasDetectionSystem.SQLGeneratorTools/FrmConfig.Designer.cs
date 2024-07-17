namespace FugasDetectionSystem.SQLGeneratorTools
{
    partial class FrmConfig
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
            tableDataBindingSource = new BindingSource(components);
            dataGridView = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tableDataBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tableDataBindingSource
            // 
            tableDataBindingSource.DataSource = typeof(TableData);
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Key, Value });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(601, 293);
            dataGridView.TabIndex = 0;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            dataGridView.RowsAdded += dataGridView_RowsAdded;
            dataGridView.UserDeletedRow += dataGridView_UserDeletedRow;
            // 
            // Key
            // 
            Key.Frozen = true;
            Key.HeaderText = "Key";
            Key.Name = "Key";
            Key.Width = 150;
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.Width = 350;
            // 
            // FrmConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 293);
            Controls.Add(dataGridView);
            Name = "FrmConfig";
            Text = "Configuración";
            ((System.ComponentModel.ISupportInitialize)tableDataBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource tableDataBindingSource;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Value;
    }
}