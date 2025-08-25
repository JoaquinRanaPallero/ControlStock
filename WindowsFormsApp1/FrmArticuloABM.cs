using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmArticuloABM : Form
    {
        public frmArticuloABM()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Close(); 
            var frm = new frmArticuloAlta();
            frm.ShowDialog(); 
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new frmArticuloBaja();
            frm.ShowDialog();
        }

    }
}
