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
            this.MainData = new System.Windows.Forms.DataGridView();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.FileSelectionDialog = new System.Windows.Forms.OpenFileDialog();
            this.FiltersButton = new System.Windows.Forms.Button();
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
            this.MainData.Location = new System.Drawing.Point(1, 100);
            this.MainData.MultiSelect = false;
            this.MainData.Name = "MainData";
            this.MainData.Size = new System.Drawing.Size(655, 321);
            this.MainData.TabIndex = 0;
            this.MainData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MainData_ColumnHeaderMouseClick);
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(93, 12);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 2;
            this.LoadDataButton.Text = "Load [F2]";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // FileSelectionDialog
            // 
            this.FileSelectionDialog.FileName = "openFileDialog1";
            // 
            // FiltersButton
            // 
            this.FiltersButton.Location = new System.Drawing.Point(12, 12);
            this.FiltersButton.Name = "FiltersButton";
            this.FiltersButton.Size = new System.Drawing.Size(75, 23);
            this.FiltersButton.TabIndex = 0;
            this.FiltersButton.Text = "Instellingen";
            this.FiltersButton.UseVisualStyleBackColor = true;
            this.FiltersButton.Click += new System.EventHandler(this.FiltersButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 421);
            this.Controls.Add(this.FiltersButton);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.MainData);
            this.MinimumSize = new System.Drawing.Size(672, 460);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainData;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.OpenFileDialog FileSelectionDialog;
        private System.Windows.Forms.Button FiltersButton;
    }
}

