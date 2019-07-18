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

namespace PasswordManager
{
    public partial class DialogForm : MetroForm
    {
        public DialogForm()
        {
            InitializeComponent();
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[0], 8);

            this.labelDetails.Font = new Font(EmbedFont.private_fonts.Families[1], 9);
            this.labelTop.Font = new Font(EmbedFont.private_fonts.Families[1], 12);
            this.labelTop.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E5A404");
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            
    
        }
    }
}
