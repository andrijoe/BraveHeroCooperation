using BraveHeroCooperation.Forms.AdminMenus;
using BraveHeroCooperation.Models;

namespace BraveHeroCooperation.Forms
{
    public partial class AdminForm : Form
    {
        Member? loggedMember = null;
        public AdminForm(Member member)
        {
            loggedMember = member;
            InitializeComponent();
            
        }

        public void route(System.Windows.Forms.Control control)
        {
            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Dock = DockStyle.Fill;
            this.panelDisplay.Controls.Add(control);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            route(new DashboardAdminControl(loggedMember));
        }

        private void accessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            route(new AccessPage(loggedMember));
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            route(new ConfigPage());
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggedMember = null;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
