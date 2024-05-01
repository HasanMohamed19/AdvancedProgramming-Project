namespace ServiceTitanApp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tblMain = new TableLayoutPanel();
            tblControls = new TableLayoutPanel();
            comboCategory = new ComboBox();
            btnCategories = new Button();
            tblChart = new TableLayoutPanel();
            chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tblStats = new TableLayoutPanel();
            tblMain.SuspendLayout();
            tblControls.SuspendLayout();
            tblChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartPie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartBar).BeginInit();
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
            tblControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblControls.Controls.Add(btnCategories, 0, 1);
            tblControls.Controls.Add(comboCategory, 0, 0);
            tblControls.Dock = DockStyle.Fill;
            tblControls.Location = new Point(3, 3);
            tblControls.Name = "tblControls";
            tblControls.RowCount = 2;
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblControls.Size = new Size(228, 238);
            tblControls.TabIndex = 0;
            // 
            // comboCategory
            // 
            comboCategory.Anchor = AnchorStyles.None;
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(3, 48);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(222, 38);
            comboCategory.TabIndex = 0;
            // 
            // btnCategories
            // 
            btnCategories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCategories.Location = new Point(3, 156);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(222, 45);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Manage Categories";
            btnCategories.UseVisualStyleBackColor = true;
            // 
            // tblChart
            // 
            tblChart.ColumnCount = 3;
            tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblChart.Controls.Add(chartBar, 2, 0);
            tblChart.Controls.Add(chartLine, 1, 0);
            tblChart.Controls.Add(chartPie, 0, 0);
            tblChart.Dock = DockStyle.Fill;
            tblChart.Location = new Point(0, 0);
            tblChart.Name = "tblChart";
            tblChart.RowCount = 1;
            tblChart.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblChart.Size = new Size(1000, 256);
            tblChart.TabIndex = 1;
            // 
            // chartPie
            // 
            chartArea4.Name = "ChartArea1";
            chartPie.ChartAreas.Add(chartArea4);
            chartPie.Dock = DockStyle.Fill;
            legend4.Name = "Legend1";
            chartPie.Legends.Add(legend4);
            chartPie.Location = new Point(3, 3);
            chartPie.Name = "chartPie";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartPie.Series.Add(series4);
            chartPie.Size = new Size(327, 250);
            chartPie.TabIndex = 0;
            // 
            // chartLine
            // 
            chartArea5.Name = "ChartArea1";
            chartLine.ChartAreas.Add(chartArea5);
            chartLine.Dock = DockStyle.Fill;
            legend5.Name = "Legend1";
            chartLine.Legends.Add(legend5);
            chartLine.Location = new Point(336, 3);
            chartLine.Name = "chartLine";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            chartLine.Series.Add(series5);
            chartLine.Size = new Size(327, 250);
            chartLine.TabIndex = 1;
            // 
            // chartBar
            // 
            chartArea6.Name = "ChartArea1";
            chartBar.ChartAreas.Add(chartArea6);
            chartBar.Dock = DockStyle.Fill;
            legend6.Name = "Legend1";
            chartBar.Legends.Add(legend6);
            chartBar.Location = new Point(669, 3);
            chartBar.Name = "chartBar";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            chartBar.Series.Add(series6);
            chartBar.Size = new Size(328, 250);
            chartBar.TabIndex = 2;
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
            // CategoryDashboard
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(tblChart);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "CategoryDashboard";
            Text = "CategoryDashboard";
            tblMain.ResumeLayout(false);
            tblControls.ResumeLayout(false);
            tblChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartPie).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblControls;
        private ComboBox comboCategory;
        private Button btnCategories;
        private TableLayoutPanel tblChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private TableLayoutPanel tblStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;
    }
}