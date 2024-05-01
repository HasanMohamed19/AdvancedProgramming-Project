namespace ServiceTitanApp.FormControls
{
    partial class Statistic
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
            tblStats = new TableLayoutPanel();
            lblValue = new Label();
            lblTitle = new Label();
            picImage = new PictureBox();
            tblStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // tblStats
            // 
            tblStats.ColumnCount = 1;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblStats.Controls.Add(lblValue, 0, 2);
            tblStats.Controls.Add(lblTitle, 0, 1);
            tblStats.Controls.Add(picImage, 0, 0);
            tblStats.Dock = DockStyle.Fill;
            tblStats.Location = new Point(0, 0);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 3;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 70.491806F));
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 12.7049179F));
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3934422F));
            tblStats.Size = new Size(244, 244);
            tblStats.TabIndex = 0;
            // 
            // lblValue
            // 
            lblValue.Dock = DockStyle.Fill;
            lblValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblValue.Location = new Point(3, 203);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(238, 41);
            lblValue.TabIndex = 2;
            lblValue.Text = "Statistic Value";
            lblValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(3, 172);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Statistic Name";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picImage
            // 
            picImage.Anchor = AnchorStyles.None;
            picImage.Location = new Point(39, 3);
            picImage.Name = "picImage";
            picImage.Size = new Size(166, 166);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 3;
            picImage.TabStop = false;
            // 
            // Statistic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblStats);
            Name = "Statistic";
            Size = new Size(244, 244);
            tblStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblStats;
        private Label lblTitle;
        private Label lblValue;
        private PictureBox picImage;
    }
}
