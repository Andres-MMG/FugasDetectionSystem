using System.Data;
using System.Text.Json;


namespace FugasDetectionSystem.SQLGeneratorTools
{
    public partial class FrmMain : Form
    {
        SQLExecutor sqlExecutor = new SQLExecutor();
        private static readonly string FILE_PATH = "path_to_your_file.json";
        string selectedTableName = string.Empty;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (File.Exists(FILE_PATH))
            {
                // Si el archivo existe, carga la estructura del TreeView desde el archivo JSON
                LoadTreeViewFromJson(treeView1, FILE_PATH);
            }
            else
            {
                CreateTreeViewFromDatabaseAsync(FILE_PATH);
            }

        }




        private void LoadTreeViewFromJson(System.Windows.Forms.TreeView treeView, string filePath)
        {
            treeView.Nodes.Clear();

            string json = File.ReadAllText(filePath);
            var treeData = DeserializeJson(json);

            foreach (var table in treeData)
            {
                TreeNode tableNode = new TreeNode(table.TableName);
                foreach (var procName in table.StoredProcedures)
                {
                    TreeNode procedureNode = new TreeNode(procName);
                    tableNode.Nodes.Add(procedureNode);
                }
                treeView.Nodes.Add(tableNode);
            }
        }


        public static List<TableData> DeserializeJson(string json)
        {
            return JsonSerializer.Deserialize<List<TableData>>(json);
        }



        private void SaveTreeViewToJson(System.Windows.Forms.TreeView treeView, string filePath)
        {
            var treeData = treeView.Nodes.Cast<TreeNode>()
                              .Select(node => new
                              {
                                  TableName = node.Text,
                                  StoredProcedures = node.Nodes.Cast<TreeNode>()
                                                      .Select(n => n.Text).ToList()
                              }).ToList();

            string json = JsonSerializer.Serialize(treeData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTreeViewFromDatabaseAsync(FILE_PATH); // Ahora es una tarea asincrónica
        }

        private async void CreateTreeViewFromDatabaseAsync(string filePath)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // Establece el cursor de espera
                treeView1.BeginUpdate(); // Mejora el rendimiento al agregar nodos al TreeView
                treeView1.Nodes.Clear();

                // Carga asincrónicamente la estructura del TreeView desde la base de datos
                var tables = await sqlExecutor.GetTablesAsync(); // Suponiendo que GetTables tiene una versión asincrónica

                foreach (DataRow row in tables.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    TreeNode tableNode = new TreeNode(tableName);

                    // De nuevo, esperamos que exista una versión asincrónica de GetStoredProcedures
                    var procedures = await sqlExecutor.GetStoredProceduresAsync(tableName);

                    foreach (DataRow procRow in procedures.Rows)
                    {
                        string procedureName = procRow["name"].ToString();
                        TreeNode procedureNode = new TreeNode(procedureName);
                        tableNode.Nodes.Add(procedureNode);
                    }

                    treeView1.Nodes.Add(tableNode);
                }

                SaveTreeViewToJson(treeView1, filePath); // Esto puede seguir siendo síncrono a menos que quieras cambiarlo también

                treeView1.EndUpdate(); // Finaliza la actualización del TreeView
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción aquí
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    selectedTableName = e.Node.Text;
                    var columnDetailsList = await sqlExecutor.GetTableColumnsAsync(selectedTableName);
                    DGVColumnas.DataSource = columnDetailsList; // Asumiendo que tu DataGridView se llama dgvColumnas
                    var crud = await sqlExecutor.CreateProceduresForTableAsync(selectedTableName);
                    ConfigureTabControl(crud);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al cargar columnas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Item clicked and unchequeado");
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBInsert.Checked = insertToolStripMenuItem.Checked;
            CheckedByChecked();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBUpdate.Checked = updateToolStripMenuItem.Checked;
            CheckedByChecked();
        }

        private void deteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBDelete.Checked = deteleToolStripMenuItem.Checked;
            CheckedByChecked();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBAll.Checked = selectAllToolStripMenuItem.Checked;
            CheckedByChecked();
        }

        private void selectByIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cBById.Checked = selectByIdToolStripMenuItem.Checked;
            CheckedByChecked();
        }

        private void CheckedByChecked()
        {
            if (cBInsert.Checked && cBUpdate.Checked && cBDelete.Checked && cBAll.Checked && cBById.Checked)
            {
                cBALLSp.Checked = true;
                todos5ToolStripMenuItem.Checked = true;
            }
            else
            {
                cBALLSp.Checked = false;
                todos5ToolStripMenuItem.Checked = false;
            }
            //ConfigureTabControl();
        }

        private void CheckedAndUnCheckedAll(bool ck)
        {
            cBALLSp.Checked = ck;
            todos5ToolStripMenuItem.Checked = ck;
            insertToolStripMenuItem.Checked = ck;
            updateToolStripMenuItem.Checked = ck;
            deteleToolStripMenuItem.Checked = ck;
            selectAllToolStripMenuItem.Checked = ck;
            selectByIdToolStripMenuItem.Checked = ck;
            cBInsert.Checked = ck;
            cBUpdate.Checked = ck;
            cBDelete.Checked = ck;
            cBAll.Checked = ck;
            cBById.Checked = ck;
        }
        // Asegúrate de ejecutar este código después de InitializeComponent() o en algún evento después de que el formulario se haya cargado.

        private void ConfigureTabControl(CRUDOperationResult OpResult)
        {
            // Primero, puedes limpiar las pestañas existentes si es necesario
            tabControl1.TabPages.Clear();
            gBoxTableName.Text = selectedTableName;

            if (cBInsert.Checked)
            {
                TabPage newTabPage = new TabPage("Insert");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.Text = OpResult.QuerysString["Insert"].ToString();
                newTabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newTabPage);
            }


            if (cBUpdate.Checked)
            {
                TabPage newTabPage = new TabPage("Update");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.Text = OpResult.QuerysString["Update"].ToString();
                newTabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newTabPage);
            }

            if (cBDelete.Checked)
            {
                TabPage newTabPage = new TabPage("Delete");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.Text = OpResult.QuerysString["Delete"].ToString();
                newTabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newTabPage);
            }

            if (cBAll.Checked)
            {
                TabPage newTabPage = new TabPage("Select All");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.Text = OpResult.QuerysString["SelectAll"].ToString();
                newTabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newTabPage);
            }

            if (cBById.Checked)
            {
                TabPage newTabPage = new TabPage("Select By Id");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.Text = OpResult.QuerysString["SelectById"].ToString();
                newTabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newTabPage);
            }
            Cursor.Current = Cursors.Default;
        }

        private void todos5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedAndUnCheckedAll(todos5ToolStripMenuItem.Checked);
        }

        private void cBInsert_Click(object sender, EventArgs e)
        {
            insertToolStripMenuItem.Checked = cBInsert.Checked;
            CheckedByChecked();
        }

        private void cBALLSp_Click(object sender, EventArgs e)
        {
            CheckedAndUnCheckedAll(cBALLSp.Checked);
            CheckedByChecked();
        }

        private void cBUpdate_Click(object sender, EventArgs e)
        {
            updateToolStripMenuItem.Checked = cBUpdate.Checked;
            CheckedByChecked();
        }

        private void cBDelete_Click(object sender, EventArgs e)
        {
            deteleToolStripMenuItem.Checked = cBDelete.Checked;
            CheckedByChecked();
        }

        private void cBAll_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem.Checked = cBAll.Checked;
            CheckedByChecked();
        }

        private void cBById_Click(object sender, EventArgs e)
        {
            selectByIdToolStripMenuItem.Checked = cBById.Checked;
            CheckedByChecked();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                sqlExecutor.ExecuteScriptWithGO(tabPage.Controls[0].Text);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog();
        }
    }
}


