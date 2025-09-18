using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BraveHeroCooperation.Forms.AdminMenus
{
    public partial class ApprovalForm : Form
    {
        int _idLoan;
        public ApprovalForm(int idLoan)
        {
            _idLoan = idLoan;
            InitializeComponent();
        }

        private void ApprovalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
