using ServiceTitanBusinessObjects;
using ServiceTitanApp.FormControls;
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
    public partial class MainMenu : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public MainMenu(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
            CreateStatistics();

            //
        }

        private void CreateStatistics()
        {
            // get data and display


            tblMain.Controls.Add(new Statistic("Total Services", "100", Statistic.StatImages.services));
            tblMain.Controls.Add(new Statistic("Total Service Requests", "100", Statistic.StatImages.requests));
            tblMain.Controls.Add(new Statistic("Total Clients", "100", Statistic.StatImages.clients));
            tblMain.Controls.Add(new Statistic("Top Selling Category", "100", Statistic.StatImages.topCategory));
            tblMain.Controls.Add(new Statistic("Top Selling Service", "100", Statistic.StatImages.topService));
            tblMain.Controls.Add(new Statistic("Total Sales", "100", Statistic.StatImages.sales));
        }
    }
}
