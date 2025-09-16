using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BraveHeroCooperation.Forms.PublicMenus;
using BraveHeroCooperation.Models;

namespace BraveHeroCooperation.Forms
{
    public partial class HomeForm : Form
    {
        Member loggedMember;
        public HomeForm(Member member)
        {
            loggedMember = member;
            InitializeComponent();
            this.Text = this.Text + " - User: " + loggedMember.FullName + " (" + loggedMember.MemberId + ")";
            route(new DashboardControl(member));
        }

        public void route(System.Windows.Forms.Control control)
        {
            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Dock = DockStyle.Fill;
            this.panelDisplay.Controls.Add(control);
        }

        private void definitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

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
