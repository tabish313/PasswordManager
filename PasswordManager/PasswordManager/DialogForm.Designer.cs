namespace PasswordManager
{
    partial class DialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNo = new Syncfusion.WinForms.Controls.SfButton();
            this.btnYes = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnOK = new Syncfusion.WinForms.Controls.SfButton();
            this.labelDetails = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTop = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Controls.Add(this.btnYes);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnNo
            // 
            this.btnNo.AccessibleName = "Button";
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnNo.Location = new System.Drawing.Point(81, 7);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(80, 25);
            this.btnNo.Style.BackColor = System.Drawing.Color.Silver;
            this.btnNo.Style.FocusedBackColor = System.Drawing.Color.Silver;
            this.btnNo.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnNo.Style.HoverBackColor = System.Drawing.Color.Silver;
            this.btnNo.Style.PressedBackColor = System.Drawing.Color.Silver;
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            // 
            // btnYes
            // 
            this.btnYes.AccessibleName = "Button";
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnYes.Location = new System.Drawing.Point(4, 7);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(80, 25);
            this.btnYes.Style.BackColor = System.Drawing.Color.Silver;
            this.btnYes.Style.FocusedBackColor = System.Drawing.Color.Silver;
            this.btnYes.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnYes.Style.HoverBackColor = System.Drawing.Color.Silver;
            this.btnYes.Style.PressedBackColor = System.Drawing.Color.Silver;
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnCancel.Location = new System.Drawing.Point(260, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.Style.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Style.FocusedBackColor = System.Drawing.Color.Silver;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnCancel.Style.HoverBackColor = System.Drawing.Color.Silver;
            this.btnCancel.Style.PressedBackColor = System.Drawing.Color.Silver;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleName = "Button";
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnOK.Location = new System.Drawing.Point(167, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.Style.BackColor = System.Drawing.Color.Silver;
            this.btnOK.Style.FocusedBackColor = System.Drawing.Color.Silver;
            this.btnOK.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnOK.Style.HoverBackColor = System.Drawing.Color.Silver;
            this.btnOK.Style.PressedBackColor = System.Drawing.Color.Silver;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            // 
            // labelDetails
            // 
            this.labelDetails.Location = new System.Drawing.Point(105, 48);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(229, 53);
            this.labelDetails.TabIndex = 2;
            this.labelDetails.Text = "Please Enter a User name!";
            this.labelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::PasswordManager.Properties.Resources.exclamation;
            this.pictureBoxIcon.Location = new System.Drawing.Point(30, 47);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelTop
            // 
            this.labelTop.Location = new System.Drawing.Point(18, 18);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(322, 23);
            this.labelTop.TabIndex = 3;
            this.labelTop.Text = "Credentials Missing!";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(164)))), ((int)(((byte)(4)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(164)))), ((int)(((byte)(4)))));
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 161);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(164)))), ((int)(((byte)(4)))));
            this.Name = "DialogForm";
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBoxIcon;
        public System.Windows.Forms.Label labelDetails;
        public Syncfusion.WinForms.Controls.SfButton btnOK;
        public Syncfusion.WinForms.Controls.SfButton btnCancel;
        public Syncfusion.WinForms.Controls.SfButton btnYes;
        public Syncfusion.WinForms.Controls.SfButton btnNo;
        public System.Windows.Forms.Label labelTop;
    }
}