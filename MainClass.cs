using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _20200305012
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source =DESKTOP-9BIK9MN\\SQLEXPRESS; Initial Catalog = GameWorld; Integrated Security = True";
        public static SqlConnection con = new SqlConnection(con_string);

        private static List<Tuple<string, string>> userCredentials = new List<Tuple<string, string>>();

        public static bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            // SQL Enjeksiyonunu önlemek için parametreli sorgu kullanıyoruz
            string qry = "SELECT * FROM register WHERE Username = @Username AND Password = @Password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["UserName"].ToString();
                AddUserCredentials(username, password);
            }

            return isValid;
        }

        public static void AddUserCredentials(string username, string password)
        {
            userCredentials.Add(new Tuple<string, string>(username, password));
        }

        public static List<Tuple<string, string>> GetUserCredentials()
        {
            return userCredentials;
        }

        
        

        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
    }
}
