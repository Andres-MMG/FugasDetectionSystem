using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public partial class FrmConfig : Form
    {
        const string CONFIG_FILE_PATH = "conf/configTools.json";
        public FrmConfig()
        {
            InitializeComponent();
            LoadConfiguration(CONFIG_FILE_PATH);

        }
        private void LoadConfiguration(string jsonFilePath)
        {
            try
            {
                var json = File.ReadAllText(jsonFilePath);
                var configItems = JsonSerializer.Deserialize<List<ConfigurationItem>>(json);

                foreach (var item in configItems)
                {
                    dataGridView.Rows.Add(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading configuration: " + ex.Message);
            }
        }

        private void SaveConfiguration(string jsonFilePath)
        {
            var configItems = new List<ConfigurationItem>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Key"].Value != null && row.Cells["Value"].Value != null)
                {
                    var item = new ConfigurationItem
                    {
                        Key = row.Cells["Key"].Value.ToString(),
                        Value = row.Cells["Value"].Value
                    };
                    configItems.Add(item);
                }
            }

            try
            {
                var json = JsonSerializer.Serialize(configItems, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving configuration: " + ex.Message);
            }
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SaveConfiguration(CONFIG_FILE_PATH);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveConfiguration(CONFIG_FILE_PATH);
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SaveConfiguration(CONFIG_FILE_PATH);
        }
    }
}
