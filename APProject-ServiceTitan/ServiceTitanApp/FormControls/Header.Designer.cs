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
            lblTitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.ControlLight;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 33.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1000, 100);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Service Titan System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Margin = new Padding(0);
            Name = "Header";
            Size = new Size(1000, 100);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
    }
}
