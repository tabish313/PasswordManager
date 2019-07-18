using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using PasswordManager.Database;
using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Services;
using PasswordManager.Hash;

namespace PasswordManager
{
    public partial class FormLogin : MetroForm
    {
        public FormLogin()
        {
            InitializeComponent();
            EmbedFont.LoadComfortaaFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[0], 8);

            labelCopyright.Text = "© Copyright - Powered by Tabish Ali";
            this.labelCopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            this.label1.Font = new Font(EmbedFont.private_fonts.Families[0], 14);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path =Application.StartupPath+ @"\PasswordManager.data";
            DB.SetDatabase(path);
            
        }

        private void txtpass_OnValueChanged(object sender, EventArgs e)
        {
            this.txtpass.isPassword = true;
        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verifier.Text(txtuser.Text))
                {
                    CustomMessageBox.Show("Credentials Missing", "Enter your username!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Exclamation);
                }
                else if (!Verifier.Text(txtpass.Text))
                {
                    CustomMessageBox.Show("Credentials Missing", "Enter your password!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Exclamation);
                }
                else
                {
                    pictureBox1.Visible = true;
                    Users user = new Users()
                    {
                        Username = txtuser.Text,
                        Master = Gulipso.DataEncrypt(txtpass.Text)
                    };
                    Users Checkuser = await UsersService.Instance().LoginUserAsync(user);

                    if (Checkuser != null)
                    {
                        this.Hide();
                        CustomMessageBox.Show("Login Successfull", "You have succesfully Logged On to your app!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Success);
                        FormDashboard das = new FormDashboard();
                        das.Show();
                    }
                    else
                    {
                        CustomMessageBox.Show("Invalid Credentials", "You have entered an incorrect username and password!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Error);

                        pictureBox1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("An Error Occurred", ex.Message.ToString(), CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Error);
            }
        }
    }
}