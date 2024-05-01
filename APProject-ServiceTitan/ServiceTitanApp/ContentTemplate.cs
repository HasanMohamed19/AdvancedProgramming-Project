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
    public partial class ContentTemplate : Form
    {
        private BaseForm parentForm;
        public ContentTemplate(BaseForm parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }
    }
}
