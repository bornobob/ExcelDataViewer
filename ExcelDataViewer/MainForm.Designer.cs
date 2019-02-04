namespace ExcelDataViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainData = new System.Windows.Forms.DataGridView();
            this.FileSelectionDialog = new System.Windows.Forms.OpenFileDialog();
            this.FiltersButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).BeginInit();
            this.SuspendLayout();
            // 
            // MainData
            // 
            this.MainData.AllowUserToAddRows = false;
            this.MainData.AllowUserToOrderColumns = true;
            this.MainData.AllowUserToResizeRows = false;
            this.MainData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MainData.Location = new System.Drawing.Point(0, 0);
            this.MainData.MultiSelect = false;
            this.MainData.Name = "MainData";
            this.MainData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.MainData.Size = new System.Drawing.Size(863, 573);
            this.MainData.TabIndex = 0;
            this.MainData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MainData_ColumnHeaderMouseClick);
            this.MainData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainData_KeyDown);
            // 
            // FiltersButton
            // 
            this.FiltersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltersButton.Enabled = false;
            this.FiltersButton.Location = new System.Drawing.Point(778, 579);
            this.FiltersButton.Name = "FiltersButton";
            this.FiltersButton.Size = new System.Drawing.Size(75, 23);
            this.FiltersButton.TabIndex = 0;
            this.FiltersButton.Text = "Instellingen";
            this.FiltersButton.UseVisualStyleBackColor = true;
            this.FiltersButton.Click += new System.EventHandler(this.FiltersButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadButton.Enabled = false;
            this.ReloadButton.Location = new System.Drawing.Point(697, 579);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(75, 23);
            this.ReloadButton.TabIndex = 1;
            this.ReloadButton.Text = "Verversen";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 614);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.FiltersButton);
            this.Controls.Add(this.MainData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(672, 460);
            this.Name = "MainForm";
            this.Text = "Excel Data Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainData;
        private System.Windows.Forms.OpenFileDialog FileSelectionDialog;
        private System.Windows.Forms.Button FiltersButton;
        private System.Windows.Forms.Button ReloadButton;
    }
}

