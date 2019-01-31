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
    public partial class SettingsForm : Form
    {
        private MainForm MainForm;

        public SettingsForm(MainForm main)
        {
            InitializeComponent();
            this.MainForm = main;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillEnableColumnsListbox();
        }

        private void FillEnableColumnsListbox()
        {
            var state = MainForm.GetColumnsEnabledState();
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
            this.Close();
        }
    }
}
