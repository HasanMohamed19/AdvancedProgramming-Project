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
            tblMain = new TableLayoutPanel();
            btnManageServices = new Button();
            btnMonitor = new Button();
            tblSide.SuspendLayout();
            SuspendLayout();
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(btnManageCategories, 0, 1);
            tblSide.Controls.Add(btnManageServices, 0, 2);
            tblSide.Controls.Add(btnMonitor, 0, 3);
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
            // btnManageServices
            // 
            btnManageServices.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnManageServices.Location = new Point(3, 220);
            btnManageServices.Name = "btnManageServices";
            btnManageServices.Size = new Size(244, 57);
            btnManageServices.TabIndex = 1;
            btnManageServices.Text = "Manage Services";
            btnManageServices.UseVisualStyleBackColor = true;
            // 
            // btnMonitor
            // 
            btnMonitor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnMonitor.Location = new Point(3, 299);
            btnMonitor.Name = "btnMonitor";
            btnMonitor.Size = new Size(244, 57);
            btnMonitor.TabIndex = 2;
            btnMonitor.Text = "Monitor and Report";
            btnMonitor.UseVisualStyleBackColor = true;
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
            tblSide.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblSide;
        private Button btnManageCategories;
        private TableLayoutPanel tblMain;
        private Button btnManageServices;
        private Button btnMonitor;
    }
}