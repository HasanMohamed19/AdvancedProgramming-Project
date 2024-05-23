using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTitanApp
{
    public partial class Header : UserControl
    {
        public BaseForm parentForm;
        public Header()
        {
            InitializeComponent();
        }

        public void ShowSignOut(bool visible)
        {
            btnSignOut.Visible = visible;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.SignOut();
            }
        }
    }
}
