
namespace ServiceTitanApp
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            GoToForm(new Login(this));
            header.parentForm = this;
        }

        public void GoToForm(Form destinationForm)
        {
            Helper.SetForm(destinationForm, pnlContent);
        }

        public void ShowSignOut(bool visible)
        {
            header.ShowSignOut(visible);
        }

        public void SignOut()
        {
            Global.SignOut();
            GoToForm(new Login(this));
        }
    }
}