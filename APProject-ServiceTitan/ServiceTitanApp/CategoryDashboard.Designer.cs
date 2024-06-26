﻿namespace ServiceTitanApp
{
    partial class CategoryDashboard
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
            tblMain = new TableLayoutPanel();
            tblControls = new TableLayoutPanel();
            comboCategory = new ComboBox();
            lblSelect = new Label();
            btnBack = new Button();
            btnCategories = new Button();
            tblStats = new TableLayoutPanel();
            tblBigStats = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblValue = new Label();
            lblTitle = new Label();
            tblMain.SuspendLayout();
            tblControls.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.4F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.6F));
            tblMain.Controls.Add(tblControls, 0, 0);
            tblMain.Controls.Add(tblStats, 1, 0);
            tblMain.Dock = DockStyle.Bottom;
            tblMain.Location = new Point(0, 256);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 36.4F));
            tblMain.Size = new Size(1000, 244);
            tblMain.TabIndex = 0;
            // 
            // tblControls
            // 
            tblControls.ColumnCount = 1;
            tblControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblControls.Controls.Add(comboCategory, 0, 1);
            tblControls.Controls.Add(lblSelect, 0, 0);
            tblControls.Controls.Add(btnBack, 0, 4);
            tblControls.Controls.Add(btnCategories, 0, 3);
            tblControls.Dock = DockStyle.Fill;
            tblControls.Location = new Point(3, 3);
            tblControls.Name = "tblControls";
            tblControls.RowCount = 5;
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6137915F));
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 22.9614582F));
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3090506F));
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 25.5578537F));
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 25.5578537F));
            tblControls.Size = new Size(228, 238);
            tblControls.TabIndex = 0;
            // 
            // comboCategory
            // 
            comboCategory.Anchor = AnchorStyles.None;
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(3, 52);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(222, 38);
            comboCategory.TabIndex = 0;
            comboCategory.SelectedIndexChanged += comboCategory_SelectedIndexChanged;
            comboCategory.SelectionChangeCommitted += comboCategory_SelectionChangeCommitted;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Dock = DockStyle.Fill;
            lblSelect.Location = new Point(3, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(222, 37);
            lblSelect.TabIndex = 3;
            lblSelect.Text = "Select Category";
            lblSelect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnBack.Location = new Point(3, 184);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(222, 45);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCategories
            // 
            btnCategories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCategories.Location = new Point(3, 122);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(222, 45);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Manage Categories";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // tblStats
            // 
            tblStats.ColumnCount = 3;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.Dock = DockStyle.Fill;
            tblStats.Location = new Point(234, 0);
            tblStats.Margin = new Padding(0);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStats.Size = new Size(766, 244);
            tblStats.TabIndex = 1;
            // 
            // tblBigStats
            // 
            tblBigStats.ColumnCount = 3;
            tblBigStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblBigStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblBigStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblBigStats.Dock = DockStyle.Fill;
            tblBigStats.Location = new Point(0, 0);
            tblBigStats.Name = "tblBigStats";
            tblBigStats.RowCount = 1;
            tblBigStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBigStats.Size = new Size(1000, 256);
            tblBigStats.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblValue, 0, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblValue
            // 
            lblValue.Dock = DockStyle.Fill;
            lblValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblValue.Location = new Point(3, 40);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(194, 60);
            lblValue.TabIndex = 2;
            lblValue.Text = "Statistic Value";
            lblValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Statistic Name";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CategoryDashboard
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(tblBigStats);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "CategoryDashboard";
            Text = "CategoryDashboard";
            Load += CategoryDashboard_Load;
            tblMain.ResumeLayout(false);
            tblControls.ResumeLayout(false);
            tblControls.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblControls;
        private ComboBox comboCategory;
        private Button btnCategories;
        private TableLayoutPanel tblBigStats;
        private TableLayoutPanel tblStats;
        private Button btnBack;
        private Label lblSelect;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblValue;
        private Label lblTitle;
    }
}