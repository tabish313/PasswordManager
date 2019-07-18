using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string TopMessage,string BodyMessage, eDialogButtons buttons,eDialogImages images)
        {
            DialogForm dialogForm = new DialogForm();
            
            dialogForm.labelTop.Text = TopMessage;

            string successcolor = "#0C8A44";
            string exclamationColor = "#E5A404";
            string ErrorColor = "#ff0000";
            string QuestionColor = "#149DFF";

            switch (images)
            {
                case eDialogImages.Error:
                    dialogForm.pictureBoxIcon.Image = PasswordManager.Properties.Resources.error;
                    dialogForm.labelTop.ForeColor = ColorTranslator.FromHtml(ErrorColor);

                    dialogForm.BorderColor = ColorTranslator.FromHtml(ErrorColor);
                    dialogForm.CaptionBarColor = ColorTranslator.FromHtml(ErrorColor);
                    dialogForm.MetroColor = ColorTranslator.FromHtml(ErrorColor);
                    SystemSounds.Hand.Play();
                    break;
                case eDialogImages.Exclamation:
                    dialogForm.pictureBoxIcon.Image = PasswordManager.Properties.Resources.exclamation;
                    dialogForm.labelTop.ForeColor = ColorTranslator.FromHtml(exclamationColor);

                    dialogForm.BorderColor = ColorTranslator.FromHtml(exclamationColor);
                    dialogForm.CaptionBarColor = ColorTranslator.FromHtml(exclamationColor);
                    dialogForm.MetroColor = ColorTranslator.FromHtml(exclamationColor);
                    SystemSounds.Exclamation.Play();
                    break;
                case eDialogImages.Success:
                    dialogForm.pictureBoxIcon.Image = PasswordManager.Properties.Resources.tick;
                    dialogForm.labelTop.ForeColor = ColorTranslator.FromHtml(successcolor);

                    dialogForm.BorderColor = ColorTranslator.FromHtml(successcolor);
                    dialogForm.CaptionBarColor = ColorTranslator.FromHtml(successcolor);
                    dialogForm.MetroColor = ColorTranslator.FromHtml(successcolor);
                    SystemSounds.Asterisk.Play();
                    break;
                case eDialogImages.Question:
                    dialogForm.pictureBoxIcon.Image = PasswordManager.Properties.Resources.question;
                    dialogForm.labelTop.ForeColor = ColorTranslator.FromHtml(QuestionColor);

                    dialogForm.BorderColor = ColorTranslator.FromHtml(QuestionColor);
                    dialogForm.CaptionBarColor = ColorTranslator.FromHtml(QuestionColor);
                    dialogForm.MetroColor = ColorTranslator.FromHtml(QuestionColor);
                    SystemSounds.Asterisk.Play();
                    break;
            }


            

            dialogForm.labelDetails.Text = BodyMessage;

            switch(buttons)
            {
                case eDialogButtons.OK:
                    dialogForm.btnYes.Visible = false;
                    dialogForm.btnNo.Visible = false;
                    dialogForm.btnCancel.Visible = false;
                    dialogForm.btnOK.Location = dialogForm.btnCancel.Location;
                    break;
                case eDialogButtons.OKCancel:
                    dialogForm.btnYes.Visible = false;
                    dialogForm.btnNo.Visible = false;
                    break;
                case eDialogButtons.YesNo:
                    dialogForm.btnOK.Visible = false;
                    dialogForm.btnCancel.Visible = false;
                    dialogForm.btnYes.Location = dialogForm.btnOK.Location;
                    dialogForm.btnNo.Location = dialogForm.btnCancel.Location;
                    break;
            }
            
            return dialogForm.ShowDialog();
        }

        public enum eDialogButtons
        {
            OK,
            OKCancel,
            YesNo
        }

        public enum eDialogImages
        {
            Error,
            Exclamation,
            Success,
            Question

        }
    }
}
