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
using PasswordManager.Database;
using PasswordManager.Entities;
using PasswordManager.Services;
using PasswordManager.Hash;

namespace PasswordManager
{
    public partial class FormDashboard : Syncfusion.Windows.Forms.MetroForm
    {
        public static bool activated = false;

        private DB Database = DB.Instance();
        public FormDashboard()
        {
            InitializeComponent();
            EmbedFont.LoadComfortaaFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[0], 8);

            labelCopyright.Text = "© Copyright - Powered by Tabish Ali";
            this.labelCopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            this.labelAppName.Font = new Font(EmbedFont.private_fonts.Families[0], 10);

            

        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            this.btnDashboard.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnNew.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnSearch.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnImport.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnExport.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnAbout.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnSetting.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);
            this.btnLogOut.TextFont = new Font(EmbedFont.private_fonts.Families[0], 9);


            string path = Application.StartupPath + @"\PasswordManager.data";
            DB.SetDatabase(path);
            
        }

        private void PasswordsGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (sender as DataGridView);

            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                dataGridView.Cursor = Cursors.Default;
            }
            else
            {
                if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                    dataGridView.Cursor = Cursors.Hand;
                else
                    dataGridView.Cursor = Cursors.Default;
            }
        }

        bool show = false;
        private void PasswordsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColShow")
                {
                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());

                    if (!show)
                    {
                        PasswordsGridView.Rows[e.RowIndex].Cells["ColPassword"].Value = PasswordsService.Instance().GetPasswordByID(ID);

                        PasswordsGridView.Rows[e.RowIndex].Cells["ColShow"].Value = Properties.Resources.Hide;
                        show = true;
                    }
                    else
                    {
                        PasswordsGridView.Rows[e.RowIndex].Cells["ColPassword"].Value = "•••••••••••";
                        PasswordsGridView.Rows[e.RowIndex].Cells["ColShow"].Value= Properties.Resources.Show;
                        show = false;
                    }
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColCopy")
                {
                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());
                    Clipboard.Clear();
                    string hash = Database.GetPassHash(ID);
                    Clipboard.SetText(hash);
                    PasswordsGridView.Rows[e.RowIndex].Cells["ColCopy"].Value = Properties.Resources.Check;

                    wait(3000);

                    PasswordsGridView.Rows[e.RowIndex].Cells["ColCopy"].Value = Properties.Resources.page_copy;
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColUpdate")
                {
                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());
                    MessageBox.Show(ID.ToString());

                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColDelete")
                {

                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());
                    DialogResult dialog = CustomMessageBox.Show("Confirmation", "Are you sure you want to delete this password? \nYou can't be never restore this?", CustomMessageBox.eDialogButtons.YesNo, CustomMessageBox.eDialogImages.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        switch(PasswordsService.Instance().DeletePassword(ID))
                        {
                            case 0:
                                CustomMessageBox.Show("An Error Occurred", "An error occured while deleting this password!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Error);
                                break;
                            case 1:
                                CustomMessageBox.Show("Successfull Deleted", "Password successful deleted!", CustomMessageBox.eDialogButtons.OK, CustomMessageBox.eDialogImages.Success);
                                break;
                        }
                    }
                }
            }
        }

        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void FormDashboard_Activated(object sender, EventArgs e)
        {
            if (activated)
            {
                ShowPasswords();
                activated = false;
            }

        }

        private async void ShowPasswords()
        {
            pictureBoxLoading.Visible = true;
            PasswordsGridView.Rows.Clear();
            List<Passwords> passwords = await PasswordsService.Instance().RetrieveUserPasswordsAsync();

            foreach (Passwords password in passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.Name, password.Email, password.Username);
            }

            for (int i = 0; i <= passwords.Count - 1; i++)
            {
                PasswordsGridView.Rows[i].Cells["ColPassword"].Value = "•••••••••••";
            }
            pictureBoxLoading.Visible = false ;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewPassword newPassword = new NewPassword();
            newPassword.ShowDialog();
        }

        private void FormDashboard_Shown(object sender, EventArgs e)
        {
            ShowPasswords();
           
        }
    }
}
