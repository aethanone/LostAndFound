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
    public partial class view : UserControl
    {
        public view()
        {
            InitializeComponent();
            load();
            
        }

        private void view_Load(object sender, EventArgs e)
        {
            
        }





        private void dtgView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgView.SelectedRows) {
                string id = row.Cells[0].Value.ToString();
                string type = row.Cells[1].Value.ToString();
                string date = row.Cells[2].Value.ToString();
                string category = row.Cells[3].Value.ToString();
                string location = row.Cells[4].Value.ToString();

                txtId.Text = id;
                txtType.Text = type;
                txtDate.Text = date;
                txtCategory.Text = category;
                txtLocation.Text = location;

                try
                {
                    string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                    string sql = "SELECT * FROM items WHERE id = '"+id+"'";

                    using (MySqlConnection con = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            con.Open();
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string title = reader.GetString("title");
                                    string person_name = reader.GetString("person_name");
                                    string person_contact = reader.GetString("person_contact");


 

                                    byte[] imageBytes = (byte[])reader["image"]; // Assuming 'photo' is the BLOB column
                                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                                    {
                                        picPhoto.Image = Image.FromStream(ms);
                                        picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                    txtName.Text = person_name;
                                    txtContact.Text = person_contact;
                                    txtTitle.Text = title;
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
        }
        private void load()
        {
            dtgView.Rows.Clear(); // Clear existing rows in DataGridView

            string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
            string sql = "SELECT id, type, category, date, location FROM items"; // Be explicit in selecting columns

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
                            int id = reader.GetInt32("id");
                            string type = reader.GetString("type");
                            string category = reader.GetString("category");
                            string date = reader.GetString("date");
                          
                            // Handle location (NULL check)
                            string location = reader.IsDBNull(reader.GetOrdinal("location")) ? "" : reader.GetString("location");

                            // Add row to DataGridView
                            dtgView.Rows.Add(id, type, category, date, location);
                        }
                    }
                }

                // Clear input fields
                txtContact.Clear();
                txtCategory.Clear();
                txtDate.Clear();
                txtId.Clear();
                txtLocation.Clear();
                txtName.Clear();
                txtTitle.Clear();
                txtType.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox1.SelectedItem.ToString(); // "ALL", "LOST", or "FOUND"
            dtgView.Rows.Clear(); // Clear current rows

            string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
            string sql;

            if (selectedType == "All")
            {
                sql = "SELECT id, type, category, date, location FROM items";
            }
            else
            {
                sql = "SELECT id, type, category, date, location FROM items WHERE type = @type";
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    if (selectedType != "All")
                    {
                        cmd.Parameters.AddWithValue("@type", selectedType);
                    }

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string type = reader.GetString("type");
                            string category = reader.GetString("category");
                            string date = reader.GetString("date");
                            string location = reader.IsDBNull(reader.GetOrdinal("location")) ? "" : reader.GetString("location");

                            dtgView.Rows.Add(id, type, category, date, location);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Filter error: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
