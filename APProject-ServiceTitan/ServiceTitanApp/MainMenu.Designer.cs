namespace ServiceTitanApp
{
    partial class MainMenu
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
            tblSide = new TableLayoutPanel();
            btnManageCategories = new Button();
            btnManageServices = new Button();
            btnViewCategories = new Button();
            tblMain = new TableLayoutPanel();
            tblSide.SuspendLayout();
            SuspendLayout();
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(btnManageCategories, 0, 1);
            tblSide.Controls.Add(btnManageServices, 0, 3);
            tblSide.Controls.Add(btnViewCategories, 0, 2);
            tblSide.Dock = DockStyle.Left;
            tblSide.Location = new Point(0, 0);
            tblSide.Name = "tblSide";
            tblSide.RowCount = 5;
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 26.0440865F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 15.9706068F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 15.9706068F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 15.9706068F));
            tblSide.RowStyles.Add(new RowStyle(SizeType.Percent, 26.0440865F));
            tblSide.Size = new Size(250, 500);
            tblSide.TabIndex = 0;
            tblSide.Paint += tblSide_Paint;
            // 
            // btnManageCategories
            // 
            btnManageCategories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnManageCategories.Location = new Point(3, 141);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(244, 57);
            btnManageCategories.TabIndex = 0;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.UseVisualStyleBackColor = true;
            btnManageCategories.Click += btnManageCategories_Click;
            // 
            // btnManageServices
            // 
            btnManageServices.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnManageServices.Location = new Point(3, 299);
            btnManageServices.Name = "btnManageServices";
            btnManageServices.Size = new Size(244, 57);
            btnManageServices.TabIndex = 1;
            btnManageServices.Text = "Manage Services";
            btnManageServices.UseVisualStyleBackColor = true;
            btnManageServices.Click += btnManageServices_Click;
            // 
            // btnViewCategories
            // 
            btnViewCategories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnViewCategories.Location = new Point(3, 220);
            btnViewCategories.Name = "btnViewCategories";
            btnViewCategories.Size = new Size(244, 57);
            btnViewCategories.TabIndex = 2;
            btnViewCategories.Text = "View Categories";
            btnViewCategories.UseVisualStyleBackColor = true;
            btnViewCategories.Click += btnViewCategories_Click;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(250, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(750, 500);
            tblMain.TabIndex = 1;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(tblMain);
            Controls.Add(tblSide);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            tblSide.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblSide;
        private Button btnManageCategories;
        private TableLayoutPanel tblMain;
        private Button btnManageServices;
        private Button btnViewCategories;
    }
}