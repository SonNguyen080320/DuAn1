using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLNH.FORMS
{
    public partial class frmThongkeTheoThang : Form
    {
        public frmThongkeTheoThang()
        {
            InitializeComponent();
        }

        private void frmThongkeTheoThang_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }
    }
}
