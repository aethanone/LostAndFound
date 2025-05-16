using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class res : Form
    {
        public res()
        {
            InitializeComponent();
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         private void load()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows in DataGridView
            dataGridView1.Refresh();

            string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
            string sql = "SELECT * FROM found"; // Be explicit in selecting columns

            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("found id");
                            string type = reader.GetString("type");
                            string category = reader.GetString("category");
                            string Title = reader.GetString("title");
                            string date = reader.GetString("date");
                            string location = reader.GetString("location");
                            string name = reader.GetString("person_name");
                            string contact = reader.GetString("Person_contact");

                            // Handle location (NULL check)


                            // Add row to DataGridView
                            dataGridView1.Rows.Add(id, type, category, Title, date, location, name,contact);
                        }
                    }
                }


            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
