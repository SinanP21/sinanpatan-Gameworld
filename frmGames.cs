using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200305012
{
    public partial class frmGames : Form
    {
        public frmGames()
        {
            InitializeComponent();
        }
   
        private void btncartCOD_Click(object sender, EventArgs e)
        {
            frmCart frmCart = new frmCart();

            // Form2'yi gösterin
            frmCart.Show();

            
        }

        private void btnGOW_Click(object sender, EventArgs e)
        {
            frmGOW frmGOW = new frmGOW();

            // Form2'yi gösterin
            frmGOW.Show();
        }

        private void frmGames_Load(object sender, EventArgs e)
        {

        }
    }
}

