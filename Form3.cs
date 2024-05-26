using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200305012
{
    public partial class Form3 : Form
    {

       

        public Form3()
        {
            InitializeComponent();
        }






        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
        }

        private void CloseAllChildForms()
        {
            foreach (Control control in ControlsPanel.Controls)
            {
                if (control is Form)
                {
                    control.Dispose(); // Dispose the form
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            CloseAllChildForms(); // Önceki formları kapat
            frmHome child = new frmHome()
            { TopLevel = false, TopMost = true };

            child.FormBorderStyle = FormBorderStyle.None;
            ControlsPanel.Controls.Add(child);
            child.Show();


        }


        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void UpperPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Check if the click was on the title bar
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            CloseAllChildForms(); // Önceki formları kapat
            frmGames child = new frmGames()
            { TopLevel = false, TopMost = true };

            child.FormBorderStyle = FormBorderStyle.None;
            ControlsPanel.Controls.Add(child);
            child.Show();
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            // Form2'yi gösterin
            form1.Show();

            MessageBox.Show("Hesaptan Çıkış yapıldı");

            // Şu anki formu gizleyin (isteğe bağlı)
            this.Hide();

            
        }

        




    }
}


