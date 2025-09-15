using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using BraveHeroCooperation.Data;
using BraveHeroCooperation.Forms.Alerts;
using BraveHeroCooperation.Models;
using BraveHeroCooperation.Services;

namespace BraveHeroCooperation.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            var auth = new AuthService(db);
            var member = auth.RegisterAsync(textAddress.Text, textCardId.Text, 
                textEmail.Text, textFullname.Text, textPassword.Text, 
                textPhone.Text, textPhoneAlt.Text, textReferenceId.Text, 
                textUsername.Text, textQuest1.Text, textQuest2.Text);
            if (member != null)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.setSuccessAlert("Registration Success! Please Login...");
                loginForm.ShowDialog();
            } else
            {
                labelError.Text = "Registration Failed!";
                labelError.Visible = true;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
