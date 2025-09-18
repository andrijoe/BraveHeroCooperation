using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;
using BraveHeroCooperation.Services;

namespace BraveHeroCooperation.Forms.AdminMenus
{
    public partial class ApprovalPage : UserControl
    {
        Member loggedMember;
        public ApprovalPage(Member member)
        {
            loggedMember = member;
            InitializeComponent();
        }

        private void ApprovalPage_Load(object sender, EventArgs e)
        {
            comboProduct.SelectedIndex = 0;
        }

        private async void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            AppDbContext db = new AppDbContext();
            if (comboProduct.SelectedIndex == 1)
            {
                LoanService loanService = new LoanService(db);
                dataGridViewApproval.AutoGenerateColumns = true;
                dataGridViewApproval.DataSource = await loanService.LoadsApproval();
                
                dataGridViewApproval.Columns[0].DataPropertyName = "Id";
                dataGridViewApproval.Columns[1].DataPropertyName = "LoanId";
                dataGridViewApproval.Columns[2].DataPropertyName = "CreatedOn";
                dataGridViewApproval.Columns[3].DataPropertyName = "Amount";
                dataGridViewApproval.Columns[4].DataPropertyName = "Amount";
                dataGridViewApproval.Columns[5].DataPropertyName = "Outstanding";
                dataGridViewApproval.Columns[6].DataPropertyName = "Interest";
                dataGridViewApproval.Columns[7].DataPropertyName = "Tenor";
                dataGridViewApproval.Columns[8].DataPropertyName = "KtpPath";
                dataGridViewApproval.Columns[9].DataPropertyName = "KkPath";
                dataGridViewApproval.Columns[10].DataPropertyName = "SlipGajiPath";
                dataGridViewApproval.Columns[11].DataPropertyName = "Amount";

                dataGridViewApproval.Columns[0].Visible = false;
                dataGridViewApproval.Columns[1].HeaderText = "Loan Id";
                dataGridViewApproval.Columns[2].HeaderText = "Created On";
                dataGridViewApproval.Columns[3].HeaderText = "Member";
                dataGridViewApproval.Columns[4].HeaderText = "Amount";
                dataGridViewApproval.Columns[5].HeaderText = "Outstanding";
                dataGridViewApproval.Columns[6].HeaderText = "Interest";
                dataGridViewApproval.Columns[7].HeaderText = "Tenor";
                dataGridViewApproval.Columns[8].HeaderText = "Ktp";
                dataGridViewApproval.Columns[9].HeaderText = "Kk";
                dataGridViewApproval.Columns[10].HeaderText = "Slip";
                dataGridViewApproval.Columns[11].HeaderText = "Join Date";

                for (int i = 11; i < dataGridViewApproval.Columns.Count; i++)
                {
                    dataGridViewApproval.Columns[i].Visible = false;
                }
            }
        }

        private void dataGridViewApproval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AppDbContext db = new AppDbContext();
            if (comboProduct.SelectedIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    string path;
                    if (e.ColumnIndex == 8)
                    {
                        path = dataGridViewApproval.Rows[e.RowIndex].Cells[8].Value.ToString();
                        ShowFile(path);
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        path = dataGridViewApproval.Rows[e.RowIndex].Cells[8].Value.ToString();
                        ShowFile(path);
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        path = dataGridViewApproval.Rows[e.RowIndex].Cells[8].Value.ToString();
                        ShowFile(path);
                    }
                    else
                    {
                        LoanService loanService = new LoanService(db);            
                        DialogResult result = MessageBox.Show("Approve?", "Decision", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        int idLoan = int.Parse(dataGridViewApproval.Rows[e.RowIndex].Cells[0].Value.ToString());
                        if (result == DialogResult.Yes)
                            loanService.SetApproval(idLoan, true);
                        else if (result == DialogResult.No)
                            loanService.SetApproval(idLoan, false);

                        comboProduct.SelectedIndex = 0;
                        comboProduct.SelectedIndex = 1;
                    }
                }
            } else
            {

            }
        }
        private void ShowFile(string path)
        {
            // Ambil path dari TextBox
            var filePath = path.Trim();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Path file kosong.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File tidak ditemukan:\n" + filePath, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Buka file dengan aplikasi default di Windows
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true   // Penting untuk Windows 10/11
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka file:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
