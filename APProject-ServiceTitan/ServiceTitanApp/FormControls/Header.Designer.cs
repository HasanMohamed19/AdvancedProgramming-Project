namespace ServiceTitanApp
{
    partial class Header
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            lblTitle = new Label();
            btnSignOut = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.6F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.9F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5F));
            tblMain.Controls.Add(lblTitle, 1, 0);
            tblMain.Controls.Add(btnSignOut, 2, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1000, 100);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.ControlLight;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 33.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(189, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(633, 100);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Service Titan System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSignOut
            // 
            btnSignOut.Anchor = AnchorStyles.None;
            btnSignOut.BackColor = Color.Red;
            btnSignOut.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignOut.ForeColor = SystemColors.ControlLightLight;
            btnSignOut.Location = new Point(860, 24);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(105, 51);
            btnSignOut.TabIndex = 4;
            btnSignOut.Text = "Sign Out";
            btnSignOut.UseVisualStyleBackColor = false;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(tblMain);
            Margin = new Padding(0);
            Name = "Header";
            Size = new Size(1000, 100);
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Button btnSignOut;
    }
}
