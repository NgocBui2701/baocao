namespace baocao.GUI
{
    partial class fBackupRestore
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
            txtDatabaseName = new TextBox();
            txtBackupPath = new TextBox();
            btnSelectBackup = new Button();
            btnBackup = new Button();
            btnRestore = new Button();
            lstBackupFiles = new ListBox();
            progressBar = new ProgressBar();
            labelDb = new Label();
            labelPathBackup = new Label();
            label3 = new Label();
            iconButtonExit = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // txtDatabaseName
            // 
            txtDatabaseName.Anchor = AnchorStyles.None;
            txtDatabaseName.Location = new Point(184, 33);
            txtDatabaseName.Margin = new Padding(4, 5, 4, 5);
            txtDatabaseName.Name = "txtDatabaseName";
            txtDatabaseName.Size = new Size(427, 31);
            txtDatabaseName.TabIndex = 0;
            // 
            // txtBackupPath
            // 
            txtBackupPath.Anchor = AnchorStyles.None;
            txtBackupPath.Location = new Point(184, 100);
            txtBackupPath.Margin = new Padding(4, 5, 4, 5);
            txtBackupPath.Name = "txtBackupPath";
            txtBackupPath.ReadOnly = true;
            txtBackupPath.Size = new Size(427, 31);
            txtBackupPath.TabIndex = 1;
            // 
            // btnSelectBackup
            // 
            btnSelectBackup.Anchor = AnchorStyles.None;
            btnSelectBackup.FlatStyle = FlatStyle.Flat;
            btnSelectBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectBackup.Location = new Point(628, 98);
            btnSelectBackup.Margin = new Padding(4, 5, 4, 5);
            btnSelectBackup.Name = "btnSelectBackup";
            btnSelectBackup.Size = new Size(107, 42);
            btnSelectBackup.TabIndex = 2;
            btnSelectBackup.Text = "Chọn";
            btnSelectBackup.UseVisualStyleBackColor = true;
            btnSelectBackup.Click += btnSelectBackup_Click;
            // 
            // btnBackup
            // 
            btnBackup.Anchor = AnchorStyles.None;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.Location = new Point(232, 160);
            btnBackup.Margin = new Padding(4, 5, 4, 5);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(143, 50);
            btnBackup.TabIndex = 3;
            btnBackup.Text = "Sao lưu";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.None;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestore.Location = new Point(390, 160);
            btnRestore.Margin = new Padding(4, 5, 4, 5);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(143, 50);
            btnRestore.TabIndex = 4;
            btnRestore.Text = "Khôi phục";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // lstBackupFiles
            // 
            lstBackupFiles.Anchor = AnchorStyles.None;
            lstBackupFiles.FormattingEnabled = true;
            lstBackupFiles.Location = new Point(29, 267);
            lstBackupFiles.Margin = new Padding(4, 5, 4, 5);
            lstBackupFiles.Name = "lstBackupFiles";
            lstBackupFiles.Size = new Size(706, 254);
            lstBackupFiles.TabIndex = 5;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(29, 550);
            progressBar.Margin = new Padding(4, 5, 4, 5);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(706, 38);
            progressBar.TabIndex = 6;
            // 
            // labelDb
            // 
            labelDb.Anchor = AnchorStyles.None;
            labelDb.AutoSize = true;
            labelDb.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDb.Location = new Point(29, 38);
            labelDb.Margin = new Padding(4, 0, 4, 0);
            labelDb.Name = "labelDb";
            labelDb.Size = new Size(129, 25);
            labelDb.TabIndex = 7;
            labelDb.Text = "Tên database:";
            // 
            // labelPathBackup
            // 
            labelPathBackup.Anchor = AnchorStyles.None;
            labelPathBackup.AutoSize = true;
            labelPathBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPathBackup.Location = new Point(29, 105);
            labelPathBackup.Margin = new Padding(4, 0, 4, 0);
            labelPathBackup.Name = "labelPathBackup";
            labelPathBackup.Size = new Size(159, 25);
            labelPathBackup.TabIndex = 8;
            labelPathBackup.Text = "Thư mục backup:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(29, 237);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 25);
            label3.TabIndex = 9;
            label3.Text = "Danh sách backup:";
            // 
            // iconButtonExit
            // 
            iconButtonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonExit.BackColor = Color.Transparent;
            iconButtonExit.FlatAppearance.BorderSize = 0;
            iconButtonExit.FlatStyle = FlatStyle.Flat;
            iconButtonExit.IconChar = FontAwesome.Sharp.IconChar.X;
            iconButtonExit.IconColor = Color.Black;
            iconButtonExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonExit.IconSize = 32;
            iconButtonExit.Location = new Point(739, 0);
            iconButtonExit.Name = "iconButtonExit";
            iconButtonExit.Size = new Size(53, 37);
            iconButtonExit.TabIndex = 10;
            iconButtonExit.UseVisualStyleBackColor = false;
            iconButtonExit.Click += iconButtonExit_Click;
            // 
            // fBackupRestore
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.logo40Opa;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(786, 667);
            Controls.Add(iconButtonExit);
            Controls.Add(label3);
            Controls.Add(labelPathBackup);
            Controls.Add(labelDb);
            Controls.Add(progressBar);
            Controls.Add(lstBackupFiles);
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
            Controls.Add(btnSelectBackup);
            Controls.Add(txtBackupPath);
            Controls.Add(txtDatabaseName);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "fBackupRestore";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sao lưu và khôi phục SQL Server";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnSelectBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ListBox lstBackupFiles;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.Label labelPathBackup;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButtonExit;
    }
}