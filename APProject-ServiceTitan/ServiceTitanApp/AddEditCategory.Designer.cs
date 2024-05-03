namespace ServiceTitanApp
{
    partial class AddEditCategory
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
            pnlTop = new Panel();
            lblTitle = new Label();
            tblBottom = new TableLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tblForm = new TableLayoutPanel();
            lblDescription = new Label();
            tblManager = new TableLayoutPanel();
            lblManager = new Label();
            tblName = new TableLayoutPanel();
            lblName = new Label();
            txtName = new TextBox();
            tblID = new TableLayoutPanel();
            lblCategoryID = new Label();
            txtCategoryID = new TextBox();
            txtDescription = new TextBox();
            comboManager = new ComboBox();
            pnlTop.SuspendLayout();
            tblBottom.SuspendLayout();
            tblForm.SuspendLayout();
            tblManager.SuspendLayout();
            tblName.SuspendLayout();
            tblID.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(644, 42);
            pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(139, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Category Info";
            // 
            // tblBottom
            // 
            tblBottom.ColumnCount = 2;
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottom.Controls.Add(btnSave, 0, 0);
            tblBottom.Controls.Add(btnCancel, 0, 0);
            tblBottom.Dock = DockStyle.Bottom;
            tblBottom.Location = new Point(0, 287);
            tblBottom.Name = "tblBottom";
            tblBottom.RowCount = 1;
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBottom.Size = new Size(644, 73);
            tblBottom.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(396, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(173, 43);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(74, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(173, 43);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tblForm
            // 
            tblForm.ColumnCount = 2;
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblForm.Controls.Add(lblDescription, 0, 2);
            tblForm.Controls.Add(tblManager, 0, 1);
            tblForm.Controls.Add(tblName, 1, 0);
            tblForm.Controls.Add(tblID, 0, 0);
            tblForm.Controls.Add(txtDescription, 0, 3);
            tblForm.Dock = DockStyle.Fill;
            tblForm.Location = new Point(0, 42);
            tblForm.Margin = new Padding(0);
            tblForm.Name = "tblForm";
            tblForm.Padding = new Padding(10, 0, 10, 0);
            tblForm.RowCount = 4;
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 19.1308212F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 19.1308212F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 19.1308212F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 42.6075325F));
            tblForm.Size = new Size(644, 245);
            tblForm.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.Location = new Point(13, 92);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(306, 46);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description:";
            lblDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tblManager
            // 
            tblManager.ColumnCount = 2;
            tblManager.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.1025658F));
            tblManager.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.8974342F));
            tblManager.Controls.Add(lblManager, 0, 0);
            tblManager.Controls.Add(comboManager, 1, 0);
            tblManager.Dock = DockStyle.Fill;
            tblManager.Location = new Point(10, 46);
            tblManager.Margin = new Padding(0);
            tblManager.Name = "tblManager";
            tblManager.RowCount = 1;
            tblManager.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblManager.Size = new Size(312, 46);
            tblManager.TabIndex = 3;
            // 
            // lblManager
            // 
            lblManager.Dock = DockStyle.Fill;
            lblManager.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblManager.Location = new Point(3, 0);
            lblManager.Name = "lblManager";
            lblManager.Size = new Size(116, 46);
            lblManager.TabIndex = 0;
            lblManager.Text = "Manager:";
            lblManager.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tblName
            // 
            tblName.ColumnCount = 2;
            tblName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.782608F));
            tblName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.21739F));
            tblName.Controls.Add(lblName, 0, 0);
            tblName.Controls.Add(txtName, 1, 0);
            tblName.Dock = DockStyle.Fill;
            tblName.Location = new Point(322, 0);
            tblName.Margin = new Padding(0);
            tblName.Name = "tblName";
            tblName.RowCount = 1;
            tblName.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblName.Size = new Size(312, 46);
            tblName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(102, 46);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(111, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(198, 33);
            txtName.TabIndex = 2;
            // 
            // tblID
            // 
            tblID.ColumnCount = 2;
            tblID.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.1025658F));
            tblID.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.8974342F));
            tblID.Controls.Add(lblCategoryID, 0, 0);
            tblID.Controls.Add(txtCategoryID, 1, 0);
            tblID.Dock = DockStyle.Fill;
            tblID.Location = new Point(10, 0);
            tblID.Margin = new Padding(0);
            tblID.Name = "tblID";
            tblID.RowCount = 1;
            tblID.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblID.Size = new Size(312, 46);
            tblID.TabIndex = 0;
            // 
            // lblCategoryID
            // 
            lblCategoryID.Dock = DockStyle.Fill;
            lblCategoryID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategoryID.Location = new Point(3, 0);
            lblCategoryID.Name = "lblCategoryID";
            lblCategoryID.Size = new Size(116, 46);
            lblCategoryID.TabIndex = 0;
            lblCategoryID.Text = "Category ID:";
            lblCategoryID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCategoryID
            // 
            txtCategoryID.Anchor = AnchorStyles.None;
            txtCategoryID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryID.Location = new Point(125, 6);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.ReadOnly = true;
            txtCategoryID.Size = new Size(184, 33);
            txtCategoryID.TabIndex = 1;
            // 
            // txtDescription
            // 
            tblForm.SetColumnSpan(txtDescription, 2);
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(13, 141);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(618, 101);
            txtDescription.TabIndex = 7;
            // 
            // comboManager
            // 
            comboManager.FormattingEnabled = true;
            comboManager.Location = new Point(125, 3);
            comboManager.Name = "comboManager";
            comboManager.Size = new Size(184, 38);
            comboManager.TabIndex = 1;
            // 
            // AddEditCategory
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 360);
            Controls.Add(tblForm);
            Controls.Add(tblBottom);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "AddEditCategory";
            Text = "Add Category";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            tblBottom.ResumeLayout(false);
            tblForm.ResumeLayout(false);
            tblForm.PerformLayout();
            tblManager.ResumeLayout(false);
            tblName.ResumeLayout(false);
            tblName.PerformLayout();
            tblID.ResumeLayout(false);
            tblID.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private TableLayoutPanel tblBottom;
        private Button btnSave;
        private Button btnCancel;
        private TableLayoutPanel tblForm;
        private Label lblDescription;
        private TableLayoutPanel tblManager;
        private Label lblManager;
        private TableLayoutPanel tblName;
        private Label lblName;
        private TextBox txtName;
        private TableLayoutPanel tblID;
        private Label lblCategoryID;
        private TextBox txtCategoryID;
        private TextBox txtDescription;
        private ComboBox comboManager;
    }
}