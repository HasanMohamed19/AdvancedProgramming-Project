namespace ServiceTitanApp
{
    partial class ViewRequests
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
            lblSearch = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblCategory = new Label();
            comboCategory = new ComboBox();
            dgvRequests = new DataGridView();
            tblSide = new TableLayoutPanel();
            comboClient = new ComboBox();
            lblClient = new Label();
            comboService = new ComboBox();
            lblService = new Label();
            btnBack = new Button();
            tblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            tblSide.SuspendLayout();
            SuspendLayout();
            // 
            // tblTop
            // 
            tblTop.ColumnCount = 4;
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.1479139F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.4070778F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1899557F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1899557F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblTop.Controls.Add(lblSearch, 0, 0);
            tblTop.Controls.Add(btnRefresh, 3, 0);
            tblTop.Controls.Add(btnSearch, 2, 0);
            tblTop.Controls.Add(txtSearch, 1, 0);
            tblTop.Dock = DockStyle.Top;
            tblTop.Location = new Point(209, 0);
            tblTop.Name = "tblTop";
            tblTop.RowCount = 1;
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTop.Size = new Size(791, 43);
            tblTop.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.Dock = DockStyle.Fill;
            lblSearch.Location = new Point(3, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(98, 43);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search:";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRefresh.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(681, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(107, 37);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(569, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(107, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(456, 35);
            txtSearch.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Location = new Point(3, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(203, 45);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Category Filter:";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboCategory
            // 
            comboCategory.Dock = DockStyle.Fill;
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(3, 48);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(203, 38);
            comboCategory.TabIndex = 6;
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Location = new Point(209, 43);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowTemplate.Height = 25;
            dgvRequests.Size = new Size(791, 457);
            dgvRequests.TabIndex = 3;
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(comboClient, 0, 5);
            tblSide.Controls.Add(lblClient, 0, 4);
            tblSide.Controls.Add(comboService, 0, 3);
            tblSide.Controls.Add(lblService, 0, 2);
            tblSide.Controls.Add(lblCategory, 0, 0);
            tblSide.Controls.Add(btnBack, 0, 6);
            tblSide.Controls.Add(comboCategory, 0, 1);
            tblSide.Dock = DockStyle.Left;
            tblSide.Location = new Point(0, 0);
            tblSide.Name = "tblSide";
            tblSide.RowCount = 7;
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 9.115374F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1410122F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 9.115374F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1410122F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 9.115374F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 35.9030037F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4688463F));
            tblSide.Size = new Size(209, 500);
            tblSide.TabIndex = 4;
            // 
            // comboClient
            // 
            comboClient.Dock = DockStyle.Fill;
            comboClient.FormattingEnabled = true;
            comboClient.Location = new Point(3, 248);
            comboClient.Name = "comboClient";
            comboClient.Size = new Size(203, 38);
            comboClient.TabIndex = 11;
            // 
            // lblClient
            // 
            lblClient.Dock = DockStyle.Fill;
            lblClient.Location = new Point(3, 200);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(203, 45);
            lblClient.TabIndex = 10;
            lblClient.Text = "Client Filter:";
            lblClient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboService
            // 
            comboService.Dock = DockStyle.Fill;
            comboService.FormattingEnabled = true;
            comboService.Location = new Point(3, 148);
            comboService.Name = "comboService";
            comboService.Size = new Size(203, 38);
            comboService.TabIndex = 9;
            // 
            // lblService
            // 
            lblService.Dock = DockStyle.Fill;
            lblService.Location = new Point(3, 100);
            lblService.Name = "lblService";
            lblService.Size = new Size(203, 45);
            lblService.TabIndex = 8;
            lblService.Text = "Service Filter:";
            lblService.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.None;
            btnBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(18, 440);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(173, 43);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // ViewRequests
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(dgvRequests);
            Controls.Add(tblTop);
            Controls.Add(tblSide);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "ViewRequests";
            Text = "ViewRequests";
            tblTop.ResumeLayout(false);
            tblTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            tblSide.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblTop;
        private Label lblCategory;
        private Label lblSearch;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox comboCategory;
        private DataGridView dgvRequests;
        private TableLayoutPanel tblSide;
        private ComboBox comboClient;
        private Label lblClient;
        private ComboBox comboService;
        private Label lblService;
        private Button btnBack;
    }
}