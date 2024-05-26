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
    public partial class Form2 : Form
    {
        static string connectionString = "Data Source =DESKTOP-9BIK9MN\\SQLEXPRESS; Initial Catalog = GameWorld; Integrated Security = True";
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //TextBoxlara girilenleri eksiklerine göre yönlendiren sorgu bölümü
            if (txtEmail.Text == "" || txtPasswordConfirm.Text == "")
            {
                MessageBox.Show("Please fill the marked fields");
            }
            else if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Passwords does not match");
            }
            else
            {



                //Sign Up ekranına girilen verileri Database'e aktarır

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO [dbo].[register]
(
[Name],
[Surname],
[UserName],
[Email],
[Password]
)Values
('" + txtName.Text + "','" + txtSurname.Text + "','" + txtUsername.Text + "','" + txtEmail.Text + "','" + txtPasswordConfirm.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SignUp Successful");
                    conn.Close();

                    

                    // Şu anki formu gizler
                    this.Hide();


                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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
    }
}

