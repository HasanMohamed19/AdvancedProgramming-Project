namespace ServiceTitanApp
{
    partial class ManageServices
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
            tblTop = new TableLayoutPanel();
            lblCategory = new Label();
            lblSearch = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            comboCategory = new ComboBox();
            tblSide = new TableLayoutPanel();
            btnAddService = new Button();
            btnEditService = new Button();
            btnViewRequests = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            dgvServices = new DataGridView();
            tblTop.SuspendLayout();
            tblSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
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
            tblTop.Controls.Add(lblCategory, 0, 0);
            tblTop.Controls.Add(lblSearch, 2, 0);
            tblTop.Controls.Add(btnRefresh, 5, 0);
            tblTop.Controls.Add(btnSearch, 4, 0);
            tblTop.Controls.Add(txtSearch, 3, 0);
            tblTop.Controls.Add(comboCategory, 1, 0);
            tblTop.Dock = DockStyle.Top;
            tblTop.Location = new Point(0, 0);
            tblTop.Name = "tblTop";
            tblTop.RowCount = 1;
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTop.Size = new Size(1000, 43);
            tblTop.TabIndex = 0;
            // 
            // lblCategory
            // 
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Location = new Point(3, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(164, 43);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Category Filter:";
            lblCategory.TextAlign = ContentAlignment.MiddleRight;
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
            // comboCategory
            // 
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(173, 3);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(176, 38);
            comboCategory.TabIndex = 6;
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(btnAddService, 0, 0);
            tblSide.Controls.Add(btnEditService, 0, 1);
            tblSide.Controls.Add(btnViewRequests, 0, 2);
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
            tblSide.Size = new Size(209, 457);
            tblSide.TabIndex = 1;
            // 
            // btnAddService
            // 
            btnAddService.Anchor = AnchorStyles.None;
            btnAddService.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddService.Location = new Point(18, 11);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(173, 43);
            btnAddService.TabIndex = 3;
            btnAddService.Text = "Add Service";
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // btnEditService
            // 
            btnEditService.Anchor = AnchorStyles.None;
            btnEditService.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditService.Location = new Point(18, 76);
            btnEditService.Name = "btnEditService";
            btnEditService.Size = new Size(173, 43);
            btnEditService.TabIndex = 4;
            btnEditService.Text = "Edit Service";
            btnEditService.UseVisualStyleBackColor = true;
            btnEditService.Click += btnEditService_Click;
            // 
            // btnViewRequests
            // 
            btnViewRequests.Anchor = AnchorStyles.None;
            btnViewRequests.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewRequests.Location = new Point(18, 141);
            btnViewRequests.Name = "btnViewRequests";
            btnViewRequests.Size = new Size(173, 43);
            btnViewRequests.TabIndex = 5;
            btnViewRequests.Text = "View Requests";
            btnViewRequests.UseVisualStyleBackColor = true;
            btnViewRequests.Click += btnViewRequests_Click;
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
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.Location = new Point(209, 43);
            dgvServices.Name = "dgvServices";
            dgvServices.RowHeadersWidth = 51;
            dgvServices.RowTemplate.Height = 25;
            dgvServices.Size = new Size(791, 457);
            dgvServices.TabIndex = 2;
            // 
            // ManageServices
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(dgvServices);
            Controls.Add(tblSide);
            Controls.Add(tblTop);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "ManageServices";
            Text = "ManageServices";
            Load += ManageServices_Load;
            tblTop.ResumeLayout(false);
            tblTop.PerformLayout();
            tblSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblTop;
        private TableLayoutPanel tblSide;
        private DataGridView dgvServices;
        private Label lblCategory;
        private Label lblSearch;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox comboCategory;
        private Button btnAddService;
        private Button btnEditService;
        private Button btnViewRequests;
        private Button btnDelete;
        private Button btnBack;
    }
}