using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace ExcelDataViewer
{
    public partial class MainForm : Form
    {
        List<string> Columns = new List<string>();
        Dictionary<string, Dictionary<string, bool>> Values = new Dictionary<string, Dictionary<string, bool>>();

        public MainForm()
        {
            InitializeComponent();
        }

        public Dictionary<string, bool> GetColumnsEnabledState()
        {
            var result = new Dictionary<string, bool>();

            foreach (string col in Columns)
            {
                result.Add(col, MainData.Columns[col].Visible);
            }

            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            string filename = Properties.Settings.Default.File;
            if (filename.Trim() != "")
            {

            }
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            FileSelectionDialog.Multiselect = false;
            FileSelectionDialog.Filter = "Comma separated values|*.csv";
            if (FileSelectionDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(FileSelectionDialog.FileName);
            }
        }

        private void LoadData(string filename)
        {
            if (File.Exists(filename))
            {
                var data = ReadData(filename);

                FillGrid(data);

                ReadValues();

                Properties.Settings.Default.File = filename;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Het opgegeven pad bestaat niet, kies een ander bestand");
                LoadDataButton.PerformClick();
            }
        }

        private void ReadValues()
        {
            foreach (string col in Columns)
            {
                Values.Add(col, new Dictionary<string, bool>());
            }
            foreach (DataGridViewRow row in MainData.Rows)
            {
                foreach (string col in Columns)
                {
                    if (!Values[col].ContainsKey((string)row.Cells[col].Value))
                    {
                        Values[col].Add((string)row.Cells[col].Value, true);
                    }
                }
            }
        }

        private List<string> ReadData(string filename)
        {
            string line;
            var file = new StreamReader(filename);

            List<string> data = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                data.Add(line);
            }

            file.Close();

            return data;
        }

        private void FillGrid(List<string> data)
        {
            string[] cols = data[0].Split(',');
            AddColumns(cols);
            data.RemoveAt(0);
            AddRows(data);
        }

        private void AddColumns(IEnumerable<string> columns)
        {
            foreach (string col in columns)
            {
                int colNr = MainData.Columns.Add(col, col);
                MainData.Columns[colNr].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.Columns.Add(col);
            }
        }

        private void AddRows(List<string> data)
        {
            foreach (string rawRow in data)
            {
                var row = rawRow.Split(',');
                MainData.Rows.Add(row);
            }
        }

        private void FiltersButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                var colEnabled = settingsForm.GetEnableColumnsValues();
                foreach (string col in this.Columns)
                {
                    MainData.Columns[col].Visible = colEnabled[col];
                }
            }

        }

        private void MainData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colName = MainData.Columns[e.ColumnIndex].Name;
            var filterForm = new ColumnFilterForm(Values[colName]);
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                var newstate = filterForm.GetEnabledValues();

                foreach (string val in new List<string>(Values[colName].Keys))
                {
                    Values[colName][val] = newstate.Contains(val);
                }

                FilterColumnValues(colName);
            }
        }

        private void FilterColumnValues(string col)
        {
            MainData.Enabled = false;
            foreach (DataGridViewRow row in MainData.Rows)
            {
                string val = (string)row.Cells[col].Value;
                row.Visible = Values[col][val];
            }
            MainData.Enabled = true;
        }
    }
}
