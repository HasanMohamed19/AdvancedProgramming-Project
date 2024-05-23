namespace ServiceTitanApp
{
    partial class ManageCategories
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
            dgvCategories = new DataGridView();
            tblSide = new TableLayoutPanel();
            btnAddCategory = new Button();
            btnEditCategory = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            tblTop = new TableLayoutPanel();
            lblManager = new Label();
            lblSearch = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            comboManager = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            tblSide.SuspendLayout();
            tblTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(209, 43);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowTemplate.Height = 25;
            dgvCategories.Size = new Size(791, 457);
            dgvCategories.TabIndex = 3;
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(btnAddCategory, 0, 0);
            tblSide.Controls.Add(btnEditCategory, 0, 1);
            tblSide.Controls.Add(btnDelete, 0, 3);
            tblSide.Controls.Add(btnBack, 0, 6);
            tblSide.Dock = DockStyle.Left;
            tblSide.Location = new Point(0, 43);
            tblSide.Name = "tblSide";
            tblSide.RowCount = 7;
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblSide.Size = new Size(209, 457);
            tblSide.TabIndex = 4;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.None;
            btnAddCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCategory.Location = new Point(18, 11);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(173, 43);
            btnAddCategory.TabIndex = 3;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Anchor = AnchorStyles.None;
            btnEditCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditCategory.Location = new Point(18, 76);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(173, 43);
            btnEditCategory.TabIndex = 4;
            btnEditCategory.Text = "Edit Category";
            btnEditCategory.UseVisualStyleBackColor = true;
            btnEditCategory.Click += btnEditCategory_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(18, 206);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(173, 43);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.None;
            btnBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(18, 402);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(173, 43);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // tblTop
            // 
            tblTop.ColumnCount = 6;
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.0488529F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.2452621F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2691917F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5084743F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.9641075F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.9641075F));
            tblTop.Controls.Add(lblManager, 0, 0);
            tblTop.Controls.Add(lblSearch, 2, 0);
            tblTop.Controls.Add(btnRefresh, 5, 0);
            tblTop.Controls.Add(btnSearch, 4, 0);
            tblTop.Controls.Add(txtSearch, 3, 0);
            tblTop.Controls.Add(comboManager, 1, 0);
            tblTop.Dock = DockStyle.Top;
            tblTop.Location = new Point(0, 0);
            tblTop.Name = "tblTop";
            tblTop.RowCount = 1;
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTop.Size = new Size(1000, 43);
            tblTop.TabIndex = 8;
            // 
            // lblManager
            // 
            lblManager.Dock = DockStyle.Fill;
            lblManager.Location = new Point(3, 0);
            lblManager.Name = "lblManager";
            lblManager.Size = new Size(164, 43);
            lblManager.TabIndex = 7;
            lblManager.Text = "Manager Filter:";
            lblManager.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSearch
            // 
            lblSearch.Dock = DockStyle.Fill;
            lblSearch.Location = new Point(355, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(96, 43);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search:";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRefresh.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(881, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(116, 37);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(762, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(113, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(457, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(299, 35);
            txtSearch.TabIndex = 4;
            // 
            // comboManager
            // 
            comboManager.FormattingEnabled = true;
            comboManager.Location = new Point(173, 3);
            comboManager.Name = "comboManager";
            comboManager.Size = new Size(176, 38);
            comboManager.TabIndex = 6;
            // 
            // ManageCategories
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(dgvCategories);
            Controls.Add(tblSide);
            Controls.Add(tblTop);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "ManageCategories";
            Text = "ManageCategories";
            Load += ManageCategories_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            tblSide.ResumeLayout(false);
            tblTop.ResumeLayout(false);
            tblTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategories;
        private TableLayoutPanel tblSide;
        private Button btnAddCategory;
        private Button btnEditCategory;
        private Button btnDelete;
        private Button btnBack;
        private TableLayoutPanel tblTop;
        private Label lblManager;
        private Label lblSearch;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox comboManager;
    }
}