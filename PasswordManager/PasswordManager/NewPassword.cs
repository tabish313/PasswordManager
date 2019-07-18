#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using PasswordManager.Globals;
using PasswordManager.Database;
using PasswordManager.Entities;
using PasswordManager.Services;

namespace PasswordManager
{
    public partial class NewPassword : Syncfusion.Windows.Forms.MetroForm
    {
        public NewPassword()
        {
            InitializeComponent();
            EmbedFont.LoadComfortaaFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[0], 8);

            labelCopyright.Text = "© Copyright - Powered by Tabish Ali";
            this.labelCopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            this.pictureBoxSpinner.Visible = false;
        }

        private void NewPassword_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\PasswordManager.data";
            DB.SetDatabase(path);
        }

        private void pictureBoxPass_Click(object sender, EventArgs e)
        {
            bool check = txtPass.isPassword;

            if (check)
            {
                txtPass.isPassword = false;
                pictureBoxPass.Image = Properties.Resources.Hide_black;
            }
            else
            {
                txtPass.isPassword = true;
                pictureBoxPass.Image = Properties.Resources.Show_black;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!Verifier.Text(txtname.Text) || !Verifier.Text(txtUsername.Text) || !Verifier.Text(txtEmail.Text) || !Verifier.Text(txtPass.Text))
            {
                CustomMessageBox.Show("*Mandatory Fields Missing", "Mandatory fields are required!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Exclamation);
            }
            else
            {
                Passwords passwords = new Passwords();

                passwords.Name = txtname.Text;
                passwords.Username = txtUsername.Text;
                passwords.Email = txtEmail.Text;
                passwords.Text = txtPass.Text;

                if (txtWebsite.Text == "")
                {
                    passwords.Website = "null";
                }
                else
                {
                    passwords.Website = txtWebsite.Text;
                }

                if (txtNotes.Text == "")
                {
                    passwords.Notes = "null";
                }
                else
                {
                    passwords.Notes = txtNotes.Text;
                }

                btnReset.Enabled = false;
                btnSave.Enabled = false;
                pictureBoxSpinner.Visible = true;

                Passwords check = await PasswordsService.Instance().SaveNewUserPasswordsAsync(passwords);

                if (check != null)
                {
                    CustomMessageBox.Show("*Successfully Saved", "Good! Your new password is succesfully saved and encrypted", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Success);
                }
                else
                {
                    CustomMessageBox.Show("*An Error Occured", "Sorry! An error occurred while saving this password", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Error);
                }
                btnReset.Enabled = true;
                btnSave.Enabled = true;
                pictureBoxSpinner.Visible = false;
                btnReset_Click(sender, e);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtWebsite.Text = "";
            txtNotes.Text = "";
        }

        private void NewPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDashboard.activated = true;
        }
    }
}
