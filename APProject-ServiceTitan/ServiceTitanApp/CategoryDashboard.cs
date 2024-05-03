using ServiceTitanApp.FormControls;
using ServiceTitanBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ServiceTitanApp
{
    public partial class CategoryDashboard : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public CategoryDashboard(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            CreateStatistics();
        }

        private void CreateStatistics()
        {
            tblStats.Controls.Add(new Statistic("Total Sales", "150.450 BHD", Statistic.StatImages.sales));
            tblStats.Controls.Add(new Statistic("Pending Requests", "6", Statistic.StatImages.requests));
            tblStats.Controls.Add(new Statistic("Top Selling Service", "Wall Painting", Statistic.StatImages.topService));
        }
    }
}
