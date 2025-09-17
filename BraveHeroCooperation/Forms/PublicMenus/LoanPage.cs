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

namespace BraveHeroCooperation.Forms.MemberMenus
{
    public partial class LoanPage : UserControl
    {
        Member loggedMember;
        public LoanPage(Member member)
        {
            loggedMember = member;
            InitializeComponent();
        }
    }
}
