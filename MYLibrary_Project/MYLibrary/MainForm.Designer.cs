namespace Library // Ensure this namespace matches your project's default namespace
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageBooks = new System.Windows.Forms.TabPage();
            this.groupBoxBookFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterBooks = new System.Windows.Forms.Button();
            this.txtFilterMaxYear = new System.Windows.Forms.TextBox();
            this.lblFilterMaxYear = new System.Windows.Forms.Label();
            this.txtFilterMinYear = new System.Windows.Forms.TextBox();
            this.lblFilterMinYear = new System.Windows.Forms.Label();
            this.txtFilterAuthor = new System.Windows.Forms.TextBox();
            this.lblFilterAuthor = new System.Windows.Forms.Label();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabPageBorrowers = new System.Windows.Forms.TabPage();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnDeleteBorrower = new System.Windows.Forms.Button();
            this.btnEditBorrower = new System.Windows.Forms.Button();
            this.btnAddBorrower = new System.Windows.Forms.Button();
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            this.tabPageIssuedBooks = new System.Windows.Forms.TabPage();
            this.dgvIssuedBooks = new System.Windows.Forms.DataGridView();
            this.tabPageOverdueBooks = new System.Windows.Forms.TabPage();
            this.dgvOverdueBooks = new System.Windows.Forms.DataGridView();
            this.tabControlMain.SuspendLayout();
            this.tabPageBooks.SuspendLayout();
            this.groupBoxBookFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabPageBorrowers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.tabPageIssuedBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).BeginInit();
            this.tabPageOverdueBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageBooks);
            this.tabControlMain.Controls.Add(this.tabPageBorrowers);
            this.tabControlMain.Controls.Add(this.tabPageIssuedBooks);
            this.tabControlMain.Controls.Add(this.tabPageOverdueBooks);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 550);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageBooks
            // 
            this.tabPageBooks.Controls.Add(this.groupBoxBookFilter);
            this.tabPageBooks.Controls.Add(this.btnDeleteBook);
            this.tabPageBooks.Controls.Add(this.btnEditBook);
            this.tabPageBooks.Controls.Add(this.btnAddBook);
            this.tabPageBooks.Controls.Add(this.dgvBooks);
            this.tabPageBooks.Location = new System.Drawing.Point(4, 26);
            this.tabPageBooks.Name = "tabPageBooks";
            this.tabPageBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBooks.Size = new System.Drawing.Size(792, 520);
            this.tabPageBooks.TabIndex = 0;
            this.tabPageBooks.Text = "Books Management";
            this.tabPageBooks.UseVisualStyleBackColor = true;
            // 
            // groupBoxBookFilter
            // 
            this.groupBoxBookFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBookFilter.Controls.Add(this.btnFilterBooks);
            this.groupBoxBookFilter.Controls.Add(this.txtFilterMaxYear);
            this.groupBoxBookFilter.Controls.Add(this.lblFilterMaxYear);
            this.groupBoxBookFilter.Controls.Add(this.txtFilterMinYear);
            this.groupBoxBookFilter.Controls.Add(this.lblFilterMinYear);
            this.groupBoxBookFilter.Controls.Add(this.txtFilterAuthor);
            this.groupBoxBookFilter.Controls.Add(this.lblFilterAuthor);
            this.groupBoxBookFilter.Location = new System.Drawing.Point(8, 6);
            this.groupBoxBookFilter.Name = "groupBoxBookFilter";
            this.groupBoxBookFilter.Size = new System.Drawing.Size(776, 70);
            this.groupBoxBookFilter.TabIndex = 4;
            this.groupBoxBookFilter.TabStop = false;
            this.groupBoxBookFilter.Text = "Filter Books";
            // 
            // btnFilterBooks
            // 
            this.btnFilterBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterBooks.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilterBooks.FlatAppearance.BorderSize = 0;
            this.btnFilterBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterBooks.ForeColor = System.Drawing.Color.White;
            this.btnFilterBooks.Location = new System.Drawing.Point(660, 28);
            this.btnFilterBooks.Name = "btnFilterBooks";
            this.btnFilterBooks.Size = new System.Drawing.Size(100, 28);
            this.btnFilterBooks.TabIndex = 6;
            this.btnFilterBooks.Text = "Apply Filter";
            this.btnFilterBooks.UseVisualStyleBackColor = false;
            this.btnFilterBooks.Click += new System.EventHandler(this.btnFilterBooks_Click);
            // 
            // txtFilterMaxYear
            // 
            this.txtFilterMaxYear.Location = new System.Drawing.Point(540, 30);
            this.txtFilterMaxYear.Name = "txtFilterMaxYear";
            this.txtFilterMaxYear.Size = new System.Drawing.Size(80, 25);
            this.txtFilterMaxYear.TabIndex = 5;
            // 
            // lblFilterMaxYear
            // 
            this.lblFilterMaxYear.AutoSize = true;
            this.lblFilterMaxYear.Location = new System.Drawing.Point(470, 33);
            this.lblFilterMaxYear.Name = "lblFilterMaxYear";
            this.lblFilterMaxYear.Size = new System.Drawing.Size(65, 17);
            this.lblFilterMaxYear.TabIndex = 4;
            this.lblFilterMaxYear.Text = "Max Year:";
            // 
            // txtFilterMinYear
            // 
            this.txtFilterMinYear.Location = new System.Drawing.Point(384, 25);
            this.txtFilterMinYear.Name = "txtFilterMinYear";
            this.txtFilterMinYear.Size = new System.Drawing.Size(80, 25);
            this.txtFilterMinYear.TabIndex = 3;
            // 
            // lblFilterMinYear
            // 
            this.lblFilterMinYear.AutoSize = true;
            this.lblFilterMinYear.Location = new System.Drawing.Point(310, 33);
            this.lblFilterMinYear.Name = "lblFilterMinYear";
            this.lblFilterMinYear.Size = new System.Drawing.Size(62, 17);
            this.lblFilterMinYear.TabIndex = 2;
            this.lblFilterMinYear.Text = "Min Year:";
            // 
            // txtFilterAuthor
            // 
            this.txtFilterAuthor.Location = new System.Drawing.Point(120, 30);
            this.txtFilterAuthor.Name = "txtFilterAuthor";
            this.txtFilterAuthor.Size = new System.Drawing.Size(129, 25);
            this.txtFilterAuthor.TabIndex = 1;
            // 
            // lblFilterAuthor
            // 
            this.lblFilterAuthor.AutoSize = true;
            this.lblFilterAuthor.Location = new System.Drawing.Point(60, 33);
            this.lblFilterAuthor.Name = "lblFilterAuthor";
            this.lblFilterAuthor.Size = new System.Drawing.Size(50, 17);
            this.lblFilterAuthor.TabIndex = 0;
            this.lblFilterAuthor.Text = "Author:";
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBook.BackColor = System.Drawing.Color.RosyBrown;
            this.btnDeleteBook.FlatAppearance.BorderSize = 0;
            this.btnDeleteBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBook.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBook.Location = new System.Drawing.Point(684, 470);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteBook.TabIndex = 3;
            this.btnDeleteBook.Text = "Delete Book";
            this.btnDeleteBook.UseVisualStyleBackColor = false;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBook.BackColor = System.Drawing.Color.LightGreen;
            this.btnEditBook.FlatAppearance.BorderSize = 0;
            this.btnEditBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBook.ForeColor = System.Drawing.Color.White;
            this.btnEditBook.Location = new System.Drawing.Point(578, 470);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(100, 35);
            this.btnEditBook.TabIndex = 2;
            this.btnEditBook.Text = "Edit Book";
            this.btnEditBook.UseVisualStyleBackColor = false;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBook.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(53, 477);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(100, 35);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(8, 82);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(776, 380);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabPageBorrowers
            // 
            this.tabPageBorrowers.Controls.Add(this.btnReturnBook);
            this.tabPageBorrowers.Controls.Add(this.btnIssueBook);
            this.tabPageBorrowers.Controls.Add(this.btnDeleteBorrower);
            this.tabPageBorrowers.Controls.Add(this.btnEditBorrower);
            this.tabPageBorrowers.Controls.Add(this.btnAddBorrower);
            this.tabPageBorrowers.Controls.Add(this.dgvBorrowers);
            this.tabPageBorrowers.Location = new System.Drawing.Point(4, 26);
            this.tabPageBorrowers.Name = "tabPageBorrowers";
            this.tabPageBorrowers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBorrowers.Size = new System.Drawing.Size(792, 520);
            this.tabPageBorrowers.TabIndex = 1;
            this.tabPageBorrowers.Text = "Borrowers Management";
            this.tabPageBorrowers.UseVisualStyleBackColor = true;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturnBook.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReturnBook.FlatAppearance.BorderSize = 0;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.ForeColor = System.Drawing.Color.White;
            this.btnReturnBook.Location = new System.Drawing.Point(114, 470);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(100, 35);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIssueBook.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnIssueBook.FlatAppearance.BorderSize = 0;
            this.btnIssueBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueBook.ForeColor = System.Drawing.Color.White;
            this.btnIssueBook.Location = new System.Drawing.Point(8, 470);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(100, 35);
            this.btnIssueBook.TabIndex = 4;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.UseVisualStyleBackColor = false;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnDeleteBorrower
            // 
            this.btnDeleteBorrower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBorrower.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteBorrower.FlatAppearance.BorderSize = 0;
            this.btnDeleteBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBorrower.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBorrower.Location = new System.Drawing.Point(684, 470);
            this.btnDeleteBorrower.Name = "btnDeleteBorrower";
            this.btnDeleteBorrower.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteBorrower.TabIndex = 3;
            this.btnDeleteBorrower.Text = "Delete Borrower";
            this.btnDeleteBorrower.UseVisualStyleBackColor = false;
            this.btnDeleteBorrower.Click += new System.EventHandler(this.btnDeleteBorrower_Click);
            // 
            // btnEditBorrower
            // 
            this.btnEditBorrower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBorrower.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditBorrower.FlatAppearance.BorderSize = 0;
            this.btnEditBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBorrower.ForeColor = System.Drawing.Color.White;
            this.btnEditBorrower.Location = new System.Drawing.Point(578, 470);
            this.btnEditBorrower.Name = "btnEditBorrower";
            this.btnEditBorrower.Size = new System.Drawing.Size(100, 35);
            this.btnEditBorrower.TabIndex = 2;
            this.btnEditBorrower.Text = "Edit Borrower";
            this.btnEditBorrower.UseVisualStyleBackColor = false;
            this.btnEditBorrower.Click += new System.EventHandler(this.btnEditBorrower_Click);
            // 
            // btnAddBorrower
            // 
            this.btnAddBorrower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBorrower.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddBorrower.FlatAppearance.BorderSize = 0;
            this.btnAddBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBorrower.ForeColor = System.Drawing.Color.White;
            this.btnAddBorrower.Location = new System.Drawing.Point(472, 470);
            this.btnAddBorrower.Name = "btnAddBorrower";
            this.btnAddBorrower.Size = new System.Drawing.Size(100, 35);
            this.btnAddBorrower.TabIndex = 1;
            this.btnAddBorrower.Text = "Add Borrower";
            this.btnAddBorrower.UseVisualStyleBackColor = false;
            this.btnAddBorrower.Click += new System.EventHandler(this.btnAddBorrower_Click);
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.AllowUserToAddRows = false;
            this.dgvBorrowers.AllowUserToDeleteRows = false;
            this.dgvBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Location = new System.Drawing.Point(8, 6);
            this.dgvBorrowers.MultiSelect = false;
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.ReadOnly = true;
            this.dgvBorrowers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowers.Size = new System.Drawing.Size(776, 458);
            this.dgvBorrowers.TabIndex = 0;
            // 
            // tabPageIssuedBooks
            // 
            this.tabPageIssuedBooks.Controls.Add(this.dgvIssuedBooks);
            this.tabPageIssuedBooks.Location = new System.Drawing.Point(4, 26);
            this.tabPageIssuedBooks.Name = "tabPageIssuedBooks";
            this.tabPageIssuedBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIssuedBooks.Size = new System.Drawing.Size(792, 520);
            this.tabPageIssuedBooks.TabIndex = 2;
            this.tabPageIssuedBooks.Text = "Issued Books";
            this.tabPageIssuedBooks.UseVisualStyleBackColor = true;
            // 
            // dgvIssuedBooks
            // 
            this.dgvIssuedBooks.AllowUserToAddRows = false;
            this.dgvIssuedBooks.AllowUserToDeleteRows = false;
            this.dgvIssuedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIssuedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuedBooks.Location = new System.Drawing.Point(8, 6);
            this.dgvIssuedBooks.MultiSelect = false;
            this.dgvIssuedBooks.Name = "dgvIssuedBooks";
            this.dgvIssuedBooks.ReadOnly = true;
            this.dgvIssuedBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIssuedBooks.Size = new System.Drawing.Size(776, 508);
            this.dgvIssuedBooks.TabIndex = 0;
            // 
            // tabPageOverdueBooks
            // 
            this.tabPageOverdueBooks.Controls.Add(this.dgvOverdueBooks);
            this.tabPageOverdueBooks.Location = new System.Drawing.Point(4, 26);
            this.tabPageOverdueBooks.Name = "tabPageOverdueBooks";
            this.tabPageOverdueBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverdueBooks.Size = new System.Drawing.Size(792, 520);
            this.tabPageOverdueBooks.TabIndex = 3;
            this.tabPageOverdueBooks.Text = "Overdue Books";
            this.tabPageOverdueBooks.UseVisualStyleBackColor = true;
            // 
            // dgvOverdueBooks
            // 
            this.dgvOverdueBooks.AllowUserToAddRows = false;
            this.dgvOverdueBooks.AllowUserToDeleteRows = false;
            this.dgvOverdueBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverdueBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueBooks.Location = new System.Drawing.Point(8, 6);
            this.dgvOverdueBooks.MultiSelect = false;
            this.dgvOverdueBooks.Name = "dgvOverdueBooks";
            this.dgvOverdueBooks.ReadOnly = true;
            this.dgvOverdueBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverdueBooks.Size = new System.Drawing.Size(776, 508);
            this.dgvOverdueBooks.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(816, 589);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageBooks.ResumeLayout(false);
            this.groupBoxBookFilter.ResumeLayout(false);
            this.groupBoxBookFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabPageBorrowers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.tabPageIssuedBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).EndInit();
            this.tabPageOverdueBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBooks;
        private System.Windows.Forms.TabPage tabPageBorrowers;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.DataGridView dgvBorrowers;
        private System.Windows.Forms.Button btnDeleteBorrower;
        private System.Windows.Forms.Button btnEditBorrower;
        private System.Windows.Forms.Button btnAddBorrower;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.GroupBox groupBoxBookFilter;
        private System.Windows.Forms.Button btnFilterBooks;
        private System.Windows.Forms.TextBox txtFilterMaxYear;
        private System.Windows.Forms.Label lblFilterMaxYear;
        private System.Windows.Forms.TextBox txtFilterMinYear;
        private System.Windows.Forms.Label lblFilterMinYear;
        private System.Windows.Forms.TextBox txtFilterAuthor;
        private System.Windows.Forms.Label lblFilterAuthor;
        private System.Windows.Forms.TabPage tabPageIssuedBooks;
        private System.Windows.Forms.DataGridView dgvIssuedBooks;
        private System.Windows.Forms.TabPage tabPageOverdueBooks;
        private System.Windows.Forms.DataGridView dgvOverdueBooks;
    }
}
