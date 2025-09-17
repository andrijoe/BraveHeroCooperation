﻿using BraveHeroCooperation.Data;
using BraveHeroCooperation.Models;
using BraveHeroCooperation.Services;

namespace BraveHeroCooperation.Forms.AdminMenus
{
    public partial class MemberPage : UserControl
    {
        public MemberPage()
        {
            InitializeComponent();
        }

        private void MemberPage_Load(object sender, EventArgs e)
        {
            loadGridMember();
            string? id = labelId.Text;
            if (id == null || id == "" || id == "...")
            {
                buttonUpdate.Visible = false;
            }
        }

        private void loadGridMember()
        {
            AppDbContext db = new AppDbContext();
            MemberService service = new MemberService(db);
            memberBindingSource.DataSource = service.setGrid();
            dataGridViewMember.Columns[0].DataPropertyName = "Id";
            dataGridViewMember.Columns[0].Visible = false;
            dataGridViewMember.Columns[1].DataPropertyName = "MemberId";
            dataGridViewMember.Columns[2].DataPropertyName = "Fullname";
            dataGridViewMember.Columns[3].DataPropertyName = "ModDate";

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AppDbContext db = new AppDbContext();
            MemberService service = new MemberService(db);
            int memberId = int.Parse(labelId.Text);
            Member? member = service.findById(memberId);
            if (member != null)
            {
                if (comboStatus.SelectedIndex == 0)
                    member.IsActive = true;
                else
                    member.IsActive = false;

                member.ModDate = DateTime.UtcNow;
                service.update(member);
            }
            loadGridMember();
        }

        private void dataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int memberId = int.Parse(dataGridViewMember.Rows[e.RowIndex].Cells[0].Value.ToString());
                AppDbContext db = new AppDbContext();
                MemberService service = new MemberService(db);
                Member? member = service.findById(memberId);
                if (member != null)
                {
                    labelFullName.Text = member.FullName;
                    labelEmail.Text = member.Email;
                    labelPhone.Text = member.Phone;
                    labelPhoneAlt.Text = member.PhoneAlt;
                    labelAddress.Text = member.Address;
                    labelJoinDate.Text = member.JoinDate.ToString("f");
                    labelMemberId.Text = member.MemberId;
                    labelCardId.Text = member.IdCard;
                    labelId.Text = member.Id.ToString();
                    if (member.IsActive)
                        comboStatus.SelectedIndex = 0;
                    else
                        comboStatus.SelectedIndex = 1;

                    buttonUpdate.Visible = true;
                }
                else
                {
                    buttonUpdate.Visible = false;
                }
            }
        }
    }
}
