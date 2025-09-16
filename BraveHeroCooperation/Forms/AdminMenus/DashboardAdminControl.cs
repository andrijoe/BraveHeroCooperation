using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BraveHeroCooperation.Models;

namespace BraveHeroCooperation.Forms.AdminMenus
{
    public partial class DashboardAdminControl : UserControl
    {
        private Member? loggedMember;
        public DashboardAdminControl(Member? member )
        {
            loggedMember = member;
            InitializeComponent();
        }

        private void DashboardAdminControl_Load(object sender, EventArgs e)
        {

        }
    }
}
