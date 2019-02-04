using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace ExcelDataViewer
{
    public partial class MainForm : Form
    {
        List<string> Columns;
        Dictionary<string, Dictionary<string, bool>> Values;
        SettingsController Settings;
        HashSet<int> HiddenRows;

        public MainForm()
        {
            InitializeComponent();

            Columns = new List<string>();
            Values = new Dictionary<string, Dictionary<string, bool>>();
            HiddenRows = new HashSet<int>();
        }

        public List<string> GetColumns()
        {
            return Columns;
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
            Settings = new SettingsController(this);
            ApplySettings();
        }

        private void LoadSettings()
        {
            string filename = Properties.Settings.Default.File;
            if (filename.Trim() != "")
            {
                LoadData(filename);
            }
        }

        private void SelectFile()
        {
            this.Text = "Excel Data Viewer";

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

                FiltersButton.Enabled = true;
                ReloadButton.Enabled = true;

                this.Text = "Excel Data Viewer - " + Path.GetFileNameWithoutExtension(filename);
            }
            else
            {
                MessageBox.Show("Het opgegeven pad bestaat niet, kies een ander bestand");
                SelectFile();
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
                    if (row.Cells[col].Value != null && !Values[col].ContainsKey((string)row.Cells[col].Value))
                    {
                        Values[col].Add((string)row.Cells[col].Value, true);
                    }
                }
            }
        }

        private List<string> ReadData(string filename)
        {
            string line;
            using (var file = new StreamReader(filename))
            {
                List<string> data = new List<string>();

                while ((line = file.ReadLine()) != null)
                {
                    data.Add(line);
                }

                return data;
            }
        }

        private void FillGrid(List<string> data)
        {
            MainData.Rows.Clear();
            MainData.Columns.Clear();
            string[] cols = data[0].Split(',');
            AddColumns(cols);
            data.RemoveAt(0);
            AddRows(data);
        }

        private void AddColumns(IEnumerable<string> columns)
        {
            foreach (string col in columns)
            {
                string colname = col.Trim();
                int colNr = MainData.Columns.Add(colname, colname);
                MainData.Columns[colNr].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.Columns.Add(colname);
            }
        }

        private void AddRows(List<string> data)
        {
            foreach (string rawRow in data)
            {
                var row = rawRow.Split(',');
                for (int i = 0; i < row.Length; i++)
                {
                    row[i] = row[i].Trim();
                }
                MainData.Rows.Add(row);
            }
        }

        private void FiltersButton_Click(object sender, EventArgs e)
        {
            Settings.LaunchSettingsForm();

            ApplySettings();

            FilterColumnValues();
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

                FilterColumnValues();
            }
        }

        private void FilterColumnValues()
        {
            MainData.Enabled = false;
            foreach (DataGridViewRow row in MainData.Rows)
            {
                bool visible = true;
                foreach (string col in Columns)
                {
                    string val = (string)row.Cells[col].Value;
                    visible = visible && Values[col][val];
                }
                row.Visible = visible && !HiddenRows.Contains(row.Index);
            }
            MainData.Enabled = true;
        }

        public void ApplySettings()
        {
            MainData.Enabled = false;

            foreach (string col in Settings.EnabledColumns.Keys)
            {
                MainData.Columns[col].Visible = Settings.EnabledColumns[col];
            }

            ApplyFilters();

            MainData.Enabled = true;
        }

        private void ApplyFilters()
        {
            HiddenRows.Clear();
            foreach (SettingsController.Filter f in Settings.Filters)
            {
                foreach (DataGridViewRow row in MainData.Rows)
                {
                    bool passFilter = false;
                    string content = ((string)row.Cells[f.Column].Value).ToLower();
                    if (f.ExactMatch)
                    {
                        passFilter = content.Equals(f.FilterWord.ToLower());
                    }
                    else
                    {
                        passFilter = content.Contains(f.FilterWord.ToLower());
                    }

                    if (f.Negate) passFilter = !passFilter;

                    if (passFilter)
                    {
                        if (f.RowCell == SettingsController.RowCell.Cell)
                        {
                            switch (f.CellArguments)
                            {
                                case SettingsController.CellArguments.Colour:
                                    row.Cells[f.ApplyToCol].Style.BackColor = (Color)new ColorConverter().ConvertFromString(f.Value);
                                    break;
                            }
                        }
                        else
                        {
                            switch (f.RowArguments)
                            {
                                case SettingsController.RowArguments.Colour:
                                    var style = new DataGridViewCellStyle();
                                    style.BackColor = (Color)new ColorConverter().ConvertFromString(f.Value);
                                    row.DefaultCellStyle = style;
                                    break;
                                case SettingsController.RowArguments.Hide:
                                    row.Visible = false;
                                    HiddenRows.Add(row.Index);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            Columns = new List<string>();
            Values = new Dictionary<string, Dictionary<string, bool>>();
            HiddenRows = new HashSet<int>();

            FiltersButton.Enabled = false;
            ReloadButton.Enabled = false;

            LoadSettings();
            Settings = new SettingsController(this);
            ApplySettings();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ReloadButton.PerformClick();
            }

            if (e.KeyCode == Keys.L && e.Modifiers == Keys.Shift)
            {
                Columns = new List<string>();
                Values = new Dictionary<string, Dictionary<string, bool>>();
                HiddenRows = new HashSet<int>();

                FiltersButton.Enabled = false;
                ReloadButton.Enabled = false;

                SelectFile();
                Settings = new SettingsController(this);
                ApplySettings();
            }
        }

        private void MainData_KeyDown(object sender, KeyEventArgs e)
        {
            MainForm_KeyDown(sender, e);
        }
    }
}
