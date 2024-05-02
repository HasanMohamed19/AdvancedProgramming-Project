using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTitanApp.FormControls
{
    public partial class Statistic : UserControl
    {
        public enum StatImages
        {
            services = 0,
            requests = 1,
            clients = 2,
            topCategory = 3,
            topService = 4,
            sales = 5
        }
        public Statistic(string statTitle, string statValue, StatImages imgNum)
        {
            InitializeComponent();
            lblTitle.Text = statTitle;
            lblValue.Text = statValue;
            // use StatImages to select appropriate image
            picImage.Image = GetImage(imgNum);
        }

        public void updateValues(string newValue)
        {
            this.lblValue.Text = newValue;
        }

        private Image? GetImage(StatImages imgNum)
        {
            return Image.FromFile("Images\\"+imgNum.ToString()+".png");
        }

    }
}
