﻿using ServiceTitanBusinessObjects;
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
    public partial class Login : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public Login(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
        }
    }
}
