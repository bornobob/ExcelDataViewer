namespace ExcelDataViewer
{
    partial class SettingsForm
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
            this.EnableColumnsListbox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FiltersGrid = new System.Windows.Forms.DataGridView();
            this.ColumnCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FilterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExactMatchCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NegCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RowCellCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ApplyToCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ActionCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ColorSelection = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltersGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnableColumnsListbox
            // 
            this.EnableColumnsListbox.CheckOnClick = true;
            this.EnableColumnsListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableColumnsListbox.FormattingEnabled = true;
            this.EnableColumnsListbox.Location = new System.Drawing.Point(3, 16);
            this.EnableColumnsListbox.Name = "EnableColumnsListbox";
            this.EnableColumnsListbox.Size = new System.Drawing.Size(194, 437);
            this.EnableColumnsListbox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.EnableColumnsListbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 456);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kolommen aan/uit zetten";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(880, 474);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Opslaan";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FiltersGrid
            // 
            this.FiltersGrid.AllowUserToResizeRows = false;
            this.FiltersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FiltersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCol,
            this.FilterCol,
            this.ExactMatchCol,
            this.NegCol,
            this.RowCellCol,
            this.ApplyToCol,
            this.ActionCol,
            this.ValueCol});
            this.FiltersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersGrid.Location = new System.Drawing.Point(3, 16);
            this.FiltersGrid.MultiSelect = false;
            this.FiltersGrid.Name = "FiltersGrid";
            this.FiltersGrid.Size = new System.Drawing.Size(734, 437);
            this.FiltersGrid.TabIndex = 3;
            this.FiltersGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FiltersGrid_CellMouseDown);
            this.FiltersGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FiltersGrid_CellValueChanged);
            // 
            // ColumnCol
            // 
            this.ColumnCol.HeaderText = "Kolom";
            this.ColumnCol.Name = "ColumnCol";
            this.ColumnCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FilterCol
            // 
            this.FilterCol.HeaderText = "Filterwoord";
            this.FilterCol.Name = "FilterCol";
            this.FilterCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExactMatchCol
            // 
            this.ExactMatchCol.HeaderText = "Exacte match";
            this.ExactMatchCol.Name = "ExactMatchCol";
            this.ExactMatchCol.Width = 80;
            // 
            // NegCol
            // 
            this.NegCol.HeaderText = "Bevat niet";
            this.NegCol.Name = "NegCol";
            this.NegCol.Width = 70;
            // 
            // RowCellCol
            // 
            this.RowCellCol.HeaderText = "Rij of cell";
            this.RowCellCol.Name = "RowCellCol";
            this.RowCellCol.Width = 60;
            // 
            // ApplyToCol
            // 
            this.ApplyToCol.HeaderText = "Toepassen op";
            this.ApplyToCol.Name = "ApplyToCol";
            this.ApplyToCol.ReadOnly = true;
            // 
            // ActionCol
            // 
            this.ActionCol.HeaderText = "Actie";
            this.ActionCol.Name = "ActionCol";
            this.ActionCol.ReadOnly = true;
            this.ActionCol.Width = 60;
            // 
            // ValueCol
            // 
            this.ValueCol.HeaderText = "Waarde";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.ReadOnly = true;
            this.ValueCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.FiltersGrid);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 456);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Complexe filters";
            // 
            // ColorSelection
            // 
            this.ColorSelection.SolidColorOnly = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(986, 548);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instellingen";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FiltersGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox EnableColumnsListbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridView FiltersGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilterCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExactMatchCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NegCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn RowCellCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn ApplyToCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn ActionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.ColorDialog ColorSelection;
    }
}