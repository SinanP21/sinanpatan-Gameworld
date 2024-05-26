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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        string connString  = "Data Source =DESKTOP-9BIK9MN\\SQLEXPRESS; Initial Catalog = GameWorld; Integrated Security = True";
        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gameWorldDataSet.register' table. You can move, or remove it, as needed.
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From register", conn);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
