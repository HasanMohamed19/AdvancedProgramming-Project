
namespace ServiceTitanApp
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            GoToForm(new CategoryDashboard(this));
        }

        public void GoToForm(Form destinationForm)
        {
            Helper.SetForm(destinationForm, pnlContent);
        }
    }
}