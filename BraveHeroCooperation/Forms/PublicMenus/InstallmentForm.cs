using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;
using BraveHeroCooperation.Services;

namespace BraveHeroCooperation.Forms.PublicMenus
{
    public partial class InstallmentForm : Form
    {
        Member loggedMember;
        int _IdLoan;
        public InstallmentForm(Member member, int IdLoan)
        {
            this.loggedMember = member;
            this._IdLoan = IdLoan;
            InitializeComponent();
        }

        public void SetLoan(int idLoan)
        {
            this._IdLoan = idLoan;
            LoadInstallment();
        }

        private async void LoadInstallment()
        {
            if (_IdLoan > 0)
            {
                this.Show();
                AppDbContext db = new AppDbContext();
                LoanService loanService = new LoanService(db);
                Loan? loan = await loanService.findById(this._IdLoan);
                if (loan != null)
                {
                    installmentBindingSource.DataSource = await loanService.LoadInstallmentsGrid(this._IdLoan);
                    dataGridViewInstallment.Columns[0].DataPropertyName = "Id";
                    dataGridViewInstallment.Columns[1].DataPropertyName = "amount";
                    dataGridViewInstallment.Columns[2].DataPropertyName = "PaymentDate";
                    dataGridViewInstallment.Columns[3].DataPropertyName = "ProofPath";

                    dataGridViewInstallment.Columns[0].Visible = false;
                    dataGridViewInstallment.Columns[3].Visible = false;
                }
            }
            else
            {
                this.Hide();
            }
        }

        private async void InstallmentForm_Load(object sender, EventArgs e)
        {
            LoadInstallment();
        }
    }
}
