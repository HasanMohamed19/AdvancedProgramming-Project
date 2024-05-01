using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTitanApp
{
    public class Helper
    {
        public static void SetForm(Form frm, Panel pnl)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnl.Controls.Add(frm);
            pnl.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }
    }
}
