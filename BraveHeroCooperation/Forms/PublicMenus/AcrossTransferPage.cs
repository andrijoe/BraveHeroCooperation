using BraveHeroCooperation.Api.Connectors;
using BraveHeroCooperation.Api.Models;
using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;
using BraveHeroCooperation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BraveHeroCooperation.Forms.MemberMenus
{
    public partial class AcrossTransferPage : UserControl
    {
        Member loggedMember;
        public AcrossTransferPage(Member member)
        {
            loggedMember = member;
            InitializeComponent();
        }

        private void AcrossTransferPage_Load(object sender, EventArgs e)
        {
            if (loggedMember.ReferenceId == null || loggedMember.ReferenceId == "-")
            {
                DialogResult result = MessageBox.Show("You do not have a privilege to Use Across Transfer. Registration Now?", "Invalid", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    loggedMember.ReferenceId = "REQ";
                    AppDbContext db = new AppDbContext();
                    AuthService authService = new AuthService(db);
                    authService.UpdateMember(loggedMember);
                }
            } else
            {
                timerInbox.Enabled = true;
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();
            ConfigurationService configService = new ConfigurationService(db);
            Configuration? config = await configService.GetConfig();
            ConnectorPost connectorPost = new ConnectorPost();
            Double transferAmount = Double.Parse(textAmount.Text);

            TransferApiResponse? response = await connectorPost.TransferAsync(new TransferPayload
            {
                amount = transferAmount,
                benefCode = textBenef.Text,
                coopCode = loggedMember.ReferenceId,
                memberCode = loggedMember.MemberId,
                fee = Double.Parse(config?.transferAcrossFee.ToString()),
                remarks = textRemarks.Text,
                transferRef = textTransRef.Text,
            });

            if (response != null && response.ResponseCode == "00")
            {
                BalanceService balanceService = new BalanceService(db);
                Balance? balance = await balanceService.getBalance(loggedMember.MemberId);
                if (balance != null)
                {
                    balance.Amount -= Decimal.Parse(transferAmount.ToString());
                    balance.UpdateOn = DateTime.Now;
                    balance.TransactionName = "Across Transfer";
                    balance.Flow = "OUT";
                    balanceService.Update(balance);

                    BalanceApiResponse? balanceApiResponse = await connectorPost.BalanceUpdateAsync(new BalancePayload
                    {
                        amount = Double.Parse(balance.Amount.ToString()),
                        memberCode = loggedMember.MemberId,
                    });

                    if (balanceApiResponse != null && balanceApiResponse.ResponseCode == "00")
                    {
                        MessageBox.Show("Transfer Successful", "Success");
                    }
                }
            }
        }

        private void timerInbox_Tick(object sender, EventArgs e)
        {
            timerInbox.Enabled = false;
            if (timerInbox.Enabled)
            {
                timerInbox.Start();
                Console.WriteLine("Retrieving...");
                ConnectorGet connectorGet = new ConnectorGet(); 
                TransferApiResponse? responseOutgoing = connectorGet.GetOutgoingByMemberAsync(loggedMember.MemberId).Result;
                if (responseOutgoing != null && responseOutgoing.ResponseCode == "00")
                {
                    dgvOutgoing.DataSource = responseOutgoing.TransferList;
                    dgvOutgoing.Columns["Id"].Visible = false;
                    dgvOutgoing.Columns["MemberCode"].Visible = false;
                    dgvOutgoing.Columns["BenefCode"].HeaderText = "Beneficiary";
                    dgvOutgoing.Columns["CoopCode"].Visible = false;
                    dgvOutgoing.Columns["updateOn"].Visible = false;
                    dgvOutgoing.Columns["TransferRef"].HeaderText = "Reference";
                    dgvOutgoing.Columns["TransferDate"].HeaderText = "Date";
                    dgvOutgoing.Columns["Amount"].HeaderText = "Amount";
                    dgvOutgoing.Columns["Fee"].HeaderText = "Fee";
                    dgvOutgoing.Columns["Remarks"].HeaderText = "Remarks";
                    dgvOutgoing.Columns["TransactionCode"].HeaderText = "Transaction Code";
                }
                String benefCode = loggedMember.ReferenceId + "-" + loggedMember.MemberId;
                TransferApiResponse? responseIncoming = connectorGet.GetIncomingByMemberAsync(loggedMember.MemberId).Result;
                if (responseOutgoing != null && responseOutgoing.ResponseCode == "00")
                {
                    dgvIncoming.Columns["Id"].Visible = false;
                    dgvIncoming.Columns["MemberCode"].HeaderText = "Member Code";
                    dgvIncoming.Columns["BenefCode"].Visible = false;
                    dgvIncoming.Columns["CoopCode"].HeaderText = "Coop Code";
                    dgvIncoming.Columns["updateOn"].Visible = false;
                    dgvIncoming.Columns["TransferRef"].HeaderText = "Reference";
                    dgvIncoming.Columns["TransferDate"].HeaderText = "Date";
                    dgvIncoming.Columns["Amount"].HeaderText = "Amount";
                    dgvIncoming.Columns["Fee"].HeaderText = "Fee";
                    dgvIncoming.Columns["Remarks"].HeaderText = "Remarks";
                    dgvIncoming.Columns["TransactionCode"].HeaderText = "Transaction Code";
                }
            }
        }
    }
}
