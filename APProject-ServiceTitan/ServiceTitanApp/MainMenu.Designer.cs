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
            btnCategories = new Button();
            btnServices = new Button();
            btnMonitor = new Button();
            tblMain = new TableLayoutPanel();
            tblSide.SuspendLayout();
            SuspendLayout();
            // 
            // tblSide
            // 
            tblSide.ColumnCount = 1;
            tblSide.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSide.Controls.Add(btnCategories, 0, 1);
            tblSide.Controls.Add(btnServices, 0, 2);
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
            // btnCategories
            // 
            btnCategories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCategories.Location = new Point(3, 141);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(244, 57);
            btnCategories.TabIndex = 0;
            btnCategories.Text = "Manage Categories";
            btnCategories.UseVisualStyleBackColor = true;
            // 
            // btnServices
            // 
            btnServices.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnServices.Location = new Point(3, 220);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(244, 57);
            btnServices.TabIndex = 1;
            btnServices.Text = "Manage Services";
            btnServices.UseVisualStyleBackColor = true;
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
            tblSide.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblSide;
        private Button btnCategories;
        private TableLayoutPanel tblMain;
        private Button btnServices;
        private Button btnMonitor;
    }
}