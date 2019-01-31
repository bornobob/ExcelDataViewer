using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelDataViewer
{
    public partial class ColumnFilterForm : Form
    {
        public ColumnFilterForm(Dictionary<string, bool> state)
        {
            InitializeComponent();

            foreach (string val in state.Keys)
            {
                FilterListBox.Items.Add(val, state[val]);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FilterListBox.Items.Count; i++)
            {
                FilterListBox.SetItemChecked(i, true);
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FilterListBox.Items.Count; i++)
            {
                FilterListBox.SetItemChecked(i, false);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public HashSet<string> GetEnabledValues()
        {
            var result = new HashSet<string>();

            foreach (int val in FilterListBox.CheckedIndices)
            {
                result.Add((string)FilterListBox.Items[val]);
            }

            return result;
        }
    }
}
