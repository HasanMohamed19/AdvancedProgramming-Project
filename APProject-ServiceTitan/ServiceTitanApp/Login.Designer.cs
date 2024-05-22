namespace ServiceTitanApp
{
    partial class Login
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
            tblLoginForm = new TableLayoutPanel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            btnLogin = new Button();
            txtUsername = new TextBox();
            tblLoginForm.SuspendLayout();
            SuspendLayout();
            // 
            // tblLoginForm
            // 
            tblLoginForm.ColumnCount = 4;
            tblLoginForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.29688F));
            tblLoginForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.499999F));
            tblLoginForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.9062481F));
            tblLoginForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2968731F));
            tblLoginForm.Controls.Add(txtPassword, 2, 2);
            tblLoginForm.Controls.Add(lblPassword, 1, 2);
            tblLoginForm.Controls.Add(lblUsername, 1, 1);
            tblLoginForm.Controls.Add(btnLogin, 1, 3);
            tblLoginForm.Controls.Add(txtUsername, 2, 1);
            tblLoginForm.Dock = DockStyle.Fill;
            tblLoginForm.Location = new Point(0, 0);
            tblLoginForm.Name = "tblLoginForm";
            tblLoginForm.RowCount = 5;
            tblLoginForm.RowStyles.Add(new RowStyle(SizeType.Percent, 27.10843F));
            tblLoginForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6506023F));
            tblLoginForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6506023F));
            tblLoginForm.RowStyles.Add(new RowStyle(SizeType.Percent, 20.4819279F));
            tblLoginForm.RowStyles.Add(new RowStyle(SizeType.Percent, 27.1084347F));
            tblLoginForm.Size = new Size(1000, 500);
            tblLoginForm.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(419, 212);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(283, 35);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.Dock = DockStyle.Fill;
            lblPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(295, 198);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(118, 63);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUsername
            // 
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(295, 135);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(118, 63);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            lblUsername.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            tblLoginForm.SetColumnSpan(btnLogin, 2);
            btnLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(367, 287);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(262, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(419, 149);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(283, 35);
            txtUsername.TabIndex = 1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(tblLoginForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            tblLoginForm.ResumeLayout(false);
            tblLoginForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLoginForm;
        private Label lblUsername;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label lblPassword;
    }
}