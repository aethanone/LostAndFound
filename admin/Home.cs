using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lostnfound
{
    public partial class Home : UserControl
    {
        public Home()
        {

            InitializeComponent();
            load();
        }

        public void load() {
            try
            {
                string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                string sql = "SELECT COUNT(id) AS total FROM items WHERE type = 'Lost'";

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        con.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int total = reader.GetInt32("total");
                                lbnLost.Text = "Reported Lost Item: \n" + "             " + total;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                string sql = "SELECT COUNT(id) AS total FROM items WHERE type = 'Found'";

                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        con.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int total = reader.GetInt32("total");
                                lbnFound.Text = "Reported Found Item: \n" + "             " + total;
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void lbnFound_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
