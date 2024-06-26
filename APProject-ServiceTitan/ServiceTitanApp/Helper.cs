﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        // function to get the source of the event for logging
        public static string GetLogSource(Form form)
        {
            string source = "Form: " + form.Name;
            return source;
        }
    }
}
