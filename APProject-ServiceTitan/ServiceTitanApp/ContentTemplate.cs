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
using ServiceTitanBusinessObjects;

namespace ServiceTitanApp
{
    public partial class ContentTemplate : Form
    {
        private BaseForm parentForm;
        private ServiceTitanDBContext context;
        public ContentTemplate(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.context = new ServiceTitanDBContext();
        }
    }
}
