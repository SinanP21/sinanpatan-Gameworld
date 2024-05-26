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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();

            // Form2'yi gösterin
            form2.Show();

            
            
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (MainClass.IsValidUser(txtUsername.Text, txtPassword.Text) == false)
            {
                MessageBox.Show("invalid username or password");
                return;
            }
            else
            {
                Form3 form3 = new Form3();

                // Form2'yi gösterin
                form3.Show();

                // Şu anki formu gizleyin (isteğe bağlı)
                this.Hide();
               
            }

            

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "sinan21" && txtPassword.Text == "123")
            {
                AdminForm AdminForm = new AdminForm();

                // Form2'yi gösterin
                AdminForm.Show();

                // Şu anki formu gizleyin (isteğe bağlı)
                this.Hide();
            }
            else
            {
                return;
            }
        }
    }
}
