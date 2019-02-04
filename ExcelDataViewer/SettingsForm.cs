using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace ExcelDataViewer
{
    public partial class SettingsForm : Form
    {
        private class Columns
        {
            public const string Column = "ColumnCol";
            public const string Filter = "FilterCol";
            public const string ExactMatch = "ExactMatchCol";
            public const string Negate = "NegCol";
            public const string RowCell = "RowCellCol";
            public const string ApplyTo = "ApplyToCol";
            public const string Action = "ActionCol";
            public const string Value = "ValueCol";
        }

        private MainForm MainForm;
        private SettingsController Controller;

        public SettingsForm(MainForm main, SettingsController controller)
        {
            InitializeComponent();
            this.MainForm = main;
            this.Controller = controller;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillEnableColumnsListbox();
            SetComplexFilterValues();
            FillComplexFilterGrid();
        }

        private void FillComplexFilterGrid()
        {
            foreach (SettingsController.Filter f in Controller.Filters)
            {
                int newIdx = FiltersGrid.Rows.Add();
                DataGridViewRow row = FiltersGrid.Rows[newIdx];
                row.Cells[Columns.Column].Value = f.Column;
                row.Cells[Columns.Filter].Value = f.FilterWord;
                row.Cells[Columns.ExactMatch].Value = f.ExactMatch;
                row.Cells[Columns.Negate].Value = f.Negate;
                row.Cells[Columns.RowCell].Value = f.RowCell.ToString();
                row.Cells[Columns.ApplyTo].Value = f.ApplyToCol;
                row.Cells[Columns.Action].Value = (f.RowCell == SettingsController.RowCell.Cell ? f.CellArguments.ToString() : f.RowArguments.ToString());
                if (row.Cells[Columns.Action].Value.ToString() == SettingsController.RowArguments.Colour.ToString())
                {
                    row.Cells[Columns.Value].Style.BackColor = (Color)new ColorConverter().ConvertFromString(f.Value);
                }
                else
                {
                    row.Cells[Columns.Value].Value = f.Value;
                }
            }
        }

        private void SetComplexFilterValues()
        {
            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)FiltersGrid.Columns[Columns.Column];
            col.DataSource = MainForm.GetColumns();

            col = (DataGridViewComboBoxColumn)FiltersGrid.Columns[Columns.ApplyTo];
            col.DataSource = MainForm.GetColumns();

            col = (DataGridViewComboBoxColumn)FiltersGrid.Columns[Columns.RowCell];
            col.DataSource = new List<string>() { SettingsController.RowCell.Cell.ToString(), SettingsController.RowCell.Row.ToString()};
        }

        private void FillEnableColumnsListbox()
        {
            var state = Controller.EnabledColumns;
            foreach (string col in state.Keys)
            {
                EnableColumnsListbox.Items.Add(col, state[col] ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        public Dictionary<string, bool> GetEnableColumnsValues()
        {
            var result = new Dictionary<string, bool>();

            for (int i = 0; i < EnableColumnsListbox.Items.Count; i ++)
            {
                string col = (string)EnableColumnsListbox.Items[i];
                result.Add(col, EnableColumnsListbox.GetItemChecked(i));
            }

            return result;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFiltersFromGrid();
            this.Close();
        }

        private void SaveFiltersFromGrid()
        {
            //Todo: Filter validation so this function is not a mess anymore
            Controller.Filters.Clear();
            foreach (DataGridViewRow row in FiltersGrid.Rows)
            {
                if (row.IsNewRow) continue;

                string col = row.Cells[Columns.Column].Value.ToString();

                if (col.Trim() == "") continue;

                string filter = row.Cells[Columns.Filter].Value == null ? "" : row.Cells[Columns.Filter].Value.ToString();
                bool exact = row.Cells[Columns.ExactMatch].Value != null && (bool)row.Cells[Columns.ExactMatch].Value;
                bool negate = row.Cells[Columns.Negate].Value != null && (bool)row.Cells[Columns.Negate].Value;

                string rowcell = row.Cells[Columns.RowCell].Value.ToString();

                if (rowcell.Trim() == "") continue;

                if (rowcell == SettingsController.RowCell.Row.ToString())
                {
                    string action = row.Cells[Columns.Action].Value.ToString();

                    if (action.Trim() == "") continue;

                    switch (action)
                    {
                        case "Hide":
                            Controller.Filters.Add(new SettingsController.Filter(SettingsController.RowArguments.Hide, col, filter, "", exact, negate));
                            break;
                        case "Colour":
                            Color c = row.Cells[Columns.Value].Style.BackColor;
                            string colour = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");

                            Controller.Filters.Add(new SettingsController.Filter(SettingsController.RowArguments.Colour, col, filter, colour, exact, negate));
                            break;
                    }
                }
                else
                {
                    string applyToCol = row.Cells[Columns.ApplyTo].Value.ToString();

                    if (applyToCol.Trim() == "") continue;

                    string action = row.Cells[Columns.Action].Value.ToString();

                    if (action.Trim() == "") continue;

                    switch (action)
                    {
                        case "Colour":
                            string colour = row.Cells[Columns.Value].Value.ToString();

                            if (colour.Trim() == "") continue;

                            Controller.Filters.Add(new SettingsController.Filter(SettingsController.CellArguments.Colour, col, filter, applyToCol, colour, exact, negate));
                            break;
                    }
                }

            }
        }

        private void FiltersGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow row = FiltersGrid.Rows[e.RowIndex];
            switch (FiltersGrid.Columns[e.ColumnIndex].Name)
            {
                case Columns.RowCell:
                    row.Cells[Columns.Action].ReadOnly = false;
                    if ((string)row.Cells[Columns.RowCell].Value == SettingsController.RowCell.Cell.ToString())
                    {
                        row.Cells[Columns.ApplyTo].ReadOnly = false;

                        ((DataGridViewComboBoxCell)row.Cells[Columns.Action]).DataSource = new List<string>() { SettingsController.CellArguments.Colour.ToString() };
                    }
                    else
                    {
                        row.Cells[Columns.ApplyTo].ReadOnly = true;
                        row.Cells[Columns.ApplyTo].Value = "";

                        ((DataGridViewComboBoxCell)row.Cells[Columns.Action]).DataSource = new List<string>() { SettingsController.RowArguments.Colour.ToString(), SettingsController.RowArguments.Hide.ToString() };
                    }
                    break;
                case Columns.Action:
                    if ((string)row.Cells[Columns.Action].Value == SettingsController.RowArguments.Colour.ToString())
                    {
                        row.Cells[Columns.Value].ReadOnly = true;
                    }
                    else
                    {
                        row.Cells[Columns.Value].ReadOnly = true;
                        row.Cells[Columns.Value].Value = "";
                    }
                    break;
            }
        }

        private void FiltersGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != FiltersGrid.Columns[Columns.Value].Index) return;

            DataGridViewRow row = FiltersGrid.Rows[e.RowIndex];
            if (row.Cells[Columns.Action].Value != null && row.Cells[Columns.Action].Value.ToString() == SettingsController.RowArguments.Colour.ToString())
            {
                if (ColorSelection.ShowDialog() == DialogResult.OK)
                {
                    Color c = ColorSelection.Color;
                    string hex = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                    row.Cells[Columns.Value].Style.BackColor = c;
                }
            }
        }
    }
}
