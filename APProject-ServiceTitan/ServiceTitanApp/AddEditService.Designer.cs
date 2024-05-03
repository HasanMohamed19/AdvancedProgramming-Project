namespace ServiceTitanApp
{
    partial class AddEditService
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
            tblForm=new TableLayoutPanel();
            lblDescription=new Label();
            lblTechnicians=new Label();
            tblPrice=new TableLayoutPanel();
            lblPrice=new Label();
            txtPrice=new TextBox();
            tblCategory=new TableLayoutPanel();
            lblCategory=new Label();
            txtCategory=new TextBox();
            tblName=new TableLayoutPanel();
            lblName=new Label();
            txtName=new TextBox();
            tblID=new TableLayoutPanel();
            lblServiceID=new Label();
            txtServiceID=new TextBox();
            chklistTechnicians=new CheckedListBox();
            txtDescription=new TextBox();
            pnlTop=new Panel();
            lblTitle=new Label();
            tblBottom=new TableLayoutPanel();
            btnSave=new Button();
            btnCancel=new Button();
            tblForm.SuspendLayout();
            tblPrice.SuspendLayout();
            tblCategory.SuspendLayout();
            tblName.SuspendLayout();
            tblID.SuspendLayout();
            pnlTop.SuspendLayout();
            tblBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tblForm
            // 
            tblForm.ColumnCount=2;
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblForm.Controls.Add(lblDescription, 1, 2);
            tblForm.Controls.Add(lblTechnicians, 0, 2);
            tblForm.Controls.Add(tblPrice, 1, 1);
            tblForm.Controls.Add(tblCategory, 0, 1);
            tblForm.Controls.Add(tblName, 1, 0);
            tblForm.Controls.Add(tblID, 0, 0);
            tblForm.Controls.Add(chklistTechnicians, 0, 3);
            tblForm.Controls.Add(txtDescription, 1, 3);
            tblForm.Dock=DockStyle.Fill;
            tblForm.Location=new Point(0, 42);
            tblForm.Margin=new Padding(0);
            tblForm.Name="tblForm";
            tblForm.Padding=new Padding(10, 0, 10, 0);
            tblForm.RowCount=4;
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2459974F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2459974F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.2459974F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Percent, 60.2620125F));
            tblForm.Size=new Size(644, 350);
            tblForm.TabIndex=0;
            // 
            // lblDescription
            // 
            lblDescription.Dock=DockStyle.Fill;
            lblDescription.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.Location=new Point(325, 92);
            lblDescription.Name="lblDescription";
            lblDescription.Size=new Size(306, 46);
            lblDescription.TabIndex=6;
            lblDescription.Text="Description:";
            lblDescription.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // lblTechnicians
            // 
            lblTechnicians.Dock=DockStyle.Fill;
            lblTechnicians.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTechnicians.Location=new Point(13, 92);
            lblTechnicians.Name="lblTechnicians";
            lblTechnicians.Size=new Size(306, 46);
            lblTechnicians.TabIndex=5;
            lblTechnicians.Text="Technicians (Multiselect):";
            lblTechnicians.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // tblPrice
            // 
            tblPrice.ColumnCount=2;
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.782608F));
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.21739F));
            tblPrice.Controls.Add(lblPrice, 0, 0);
            tblPrice.Controls.Add(txtPrice, 1, 0);
            tblPrice.Dock=DockStyle.Fill;
            tblPrice.Location=new Point(322, 46);
            tblPrice.Margin=new Padding(0);
            tblPrice.Name="tblPrice";
            tblPrice.RowCount=1;
            tblPrice.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPrice.Size=new Size(312, 46);
            tblPrice.TabIndex=4;
            // 
            // lblPrice
            // 
            lblPrice.Dock=DockStyle.Fill;
            lblPrice.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.Location=new Point(3, 0);
            lblPrice.Name="lblPrice";
            lblPrice.Size=new Size(102, 46);
            lblPrice.TabIndex=0;
            lblPrice.Text="Price:";
            lblPrice.TextAlign=ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            txtPrice.Anchor=AnchorStyles.None;
            txtPrice.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrice.Location=new Point(111, 6);
            txtPrice.Name="txtPrice";
            txtPrice.Size=new Size(198, 33);
            txtPrice.TabIndex=4;
            // 
            // tblCategory
            // 
            tblCategory.ColumnCount=2;
            tblCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.782608F));
            tblCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.21739F));
            tblCategory.Controls.Add(lblCategory, 0, 0);
            tblCategory.Controls.Add(txtCategory, 1, 0);
            tblCategory.Dock=DockStyle.Fill;
            tblCategory.Location=new Point(10, 46);
            tblCategory.Margin=new Padding(0);
            tblCategory.Name="tblCategory";
            tblCategory.RowCount=1;
            tblCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblCategory.Size=new Size(312, 46);
            tblCategory.TabIndex=3;
            // 
            // lblCategory
            // 
            lblCategory.Dock=DockStyle.Fill;
            lblCategory.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.Location=new Point(3, 0);
            lblCategory.Name="lblCategory";
            lblCategory.Size=new Size(102, 46);
            lblCategory.TabIndex=0;
            lblCategory.Text="Category:";
            lblCategory.TextAlign=ContentAlignment.MiddleRight;
            // 
            // txtCategory
            // 
            txtCategory.Anchor=AnchorStyles.None;
            txtCategory.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategory.Location=new Point(111, 6);
            txtCategory.Name="txtCategory";
            txtCategory.ReadOnly=true;
            txtCategory.Size=new Size(198, 33);
            txtCategory.TabIndex=3;
            // 
            // tblName
            // 
            tblName.ColumnCount=2;
            tblName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.782608F));
            tblName.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.21739F));
            tblName.Controls.Add(lblName, 0, 0);
            tblName.Controls.Add(txtName, 1, 0);
            tblName.Dock=DockStyle.Fill;
            tblName.Location=new Point(322, 0);
            tblName.Margin=new Padding(0);
            tblName.Name="tblName";
            tblName.RowCount=1;
            tblName.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblName.Size=new Size(312, 46);
            tblName.TabIndex=2;
            // 
            // lblName
            // 
            lblName.Dock=DockStyle.Fill;
            lblName.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location=new Point(3, 0);
            lblName.Name="lblName";
            lblName.Size=new Size(102, 46);
            lblName.TabIndex=0;
            lblName.Text="Name:";
            lblName.TextAlign=ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Anchor=AnchorStyles.None;
            txtName.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location=new Point(111, 6);
            txtName.Name="txtName";
            txtName.Size=new Size(198, 33);
            txtName.TabIndex=2;
            // 
            // tblID
            // 
            tblID.ColumnCount=2;
            tblID.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.782608F));
            tblID.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.21739F));
            tblID.Controls.Add(lblServiceID, 0, 0);
            tblID.Controls.Add(txtServiceID, 1, 0);
            tblID.Dock=DockStyle.Fill;
            tblID.Location=new Point(10, 0);
            tblID.Margin=new Padding(0);
            tblID.Name="tblID";
            tblID.RowCount=1;
            tblID.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblID.Size=new Size(312, 46);
            tblID.TabIndex=0;
            // 
            // lblServiceID
            // 
            lblServiceID.Dock=DockStyle.Fill;
            lblServiceID.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblServiceID.Location=new Point(3, 0);
            lblServiceID.Name="lblServiceID";
            lblServiceID.Size=new Size(102, 46);
            lblServiceID.TabIndex=0;
            lblServiceID.Text="Service ID:";
            lblServiceID.TextAlign=ContentAlignment.MiddleRight;
            // 
            // txtServiceID
            // 
            txtServiceID.Anchor=AnchorStyles.None;
            txtServiceID.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtServiceID.Location=new Point(111, 6);
            txtServiceID.Name="txtServiceID";
            txtServiceID.ReadOnly=true;
            txtServiceID.Size=new Size(198, 33);
            txtServiceID.TabIndex=1;
            // 
            // chklistTechnicians
            // 
            chklistTechnicians.Dock=DockStyle.Fill;
            chklistTechnicians.Font=new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chklistTechnicians.FormattingEnabled=true;
            chklistTechnicians.Location=new Point(13, 141);
            chklistTechnicians.Name="chklistTechnicians";
            chklistTechnicians.Size=new Size(306, 206);
            chklistTechnicians.TabIndex=5;
            // 
            // txtDescription
            // 
            txtDescription.Dock=DockStyle.Fill;
            txtDescription.Font=new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location=new Point(325, 141);
            txtDescription.Multiline=true;
            txtDescription.Name="txtDescription";
            txtDescription.Size=new Size(306, 206);
            txtDescription.TabIndex=7;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock=DockStyle.Top;
            pnlTop.Location=new Point(0, 0);
            pnlTop.Name="pnlTop";
            pnlTop.Size=new Size(644, 42);
            pnlTop.TabIndex=0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize=true;
            lblTitle.Location=new Point(10, 6);
            lblTitle.Name="lblTitle";
            lblTitle.Size=new Size(121, 30);
            lblTitle.TabIndex=0;
            lblTitle.Text="Service Info";
            // 
            // tblBottom
            // 
            tblBottom.ColumnCount=2;
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottom.Controls.Add(btnSave, 0, 0);
            tblBottom.Controls.Add(btnCancel, 0, 0);
            tblBottom.Dock=DockStyle.Bottom;
            tblBottom.Location=new Point(0, 392);
            tblBottom.Name="tblBottom";
            tblBottom.RowCount=1;
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBottom.Size=new Size(644, 73);
            tblBottom.TabIndex=0;
            // 
            // btnSave
            // 
            btnSave.Anchor=AnchorStyles.None;
            btnSave.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location=new Point(396, 15);
            btnSave.Name="btnSave";
            btnSave.Size=new Size(173, 43);
            btnSave.TabIndex=5;
            btnSave.Text="Save";
            btnSave.UseVisualStyleBackColor=true;
            btnSave.Click+=btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor=AnchorStyles.None;
            btnCancel.Font=new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location=new Point(74, 15);
            btnCancel.Name="btnCancel";
            btnCancel.Size=new Size(173, 43);
            btnCancel.TabIndex=4;
            btnCancel.Text="Cancel";
            btnCancel.UseVisualStyleBackColor=true;
            // 
            // AddEditService
            // 
            AutoScaleDimensions=new SizeF(12F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(644, 465);
            Controls.Add(tblForm);
            Controls.Add(tblBottom);
            Controls.Add(pnlTop);
            Font=new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin=new Padding(5, 6, 5, 6);
            Name="AddEditService";
            Text="Add Service";
            Load+=AddEditService_Load;
            tblForm.ResumeLayout(false);
            tblForm.PerformLayout();
            tblPrice.ResumeLayout(false);
            tblPrice.PerformLayout();
            tblCategory.ResumeLayout(false);
            tblCategory.PerformLayout();
            tblName.ResumeLayout(false);
            tblName.PerformLayout();
            tblID.ResumeLayout(false);
            tblID.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            tblBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblForm;
        private Panel pnlTop;
        private TableLayoutPanel tblID;
        private Label lblServiceID;
        private TextBox txtServiceID;
        private Label lblTitle;
        private TableLayoutPanel tblBottom;
        private TableLayoutPanel tblPrice;
        private Label lblPrice;
        private TextBox txtPrice;
        private TableLayoutPanel tblCategory;
        private Label lblCategory;
        private TextBox txtCategory;
        private TableLayoutPanel tblName;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private Label lblTechnicians;
        private CheckedListBox chklistTechnicians;
        private TextBox txtDescription;
        private Button btnCancel;
        private Button btnSave;
    }
}