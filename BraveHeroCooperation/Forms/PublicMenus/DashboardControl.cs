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

namespace BraveHeroCooperation.Forms.PublicMenus
{
    public partial class DashboardControl : UserControl
    {
        Member loggedMember;
        public DashboardControl(Member member)
        {
            this.loggedMember = member;
            InitializeComponent();
        }

       
    }
}
