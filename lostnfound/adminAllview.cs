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
    public partial class adminAllview : UserControl
    {
        public adminAllview()
        {
            InitializeComponent();
        }

        private void btnFound_Click(object sender, EventArgs e)
        {

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
                cbxCategory.SelectedIndex = -1;
                txtDate.Clear();
                txtId.Clear();
                txtLocation.Clear();
                txtName.Clear();
                txtTitle.Clear();
                cbxType.SelectedIndex = -1;
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgView.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string type = row.Cells[1].Value.ToString();
                string date = row.Cells[2].Value.ToString();
                string category = row.Cells[3].Value.ToString();
                string location = row.Cells[4].Value.ToString();

                txtId.Text = id;
                cbxType.SelectedItem = type;
                txtDate.Text = date;
                cbxCategory.SelectedItem = type;
                txtLocation.Text = location;

                try
                {
                    string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                    string sql = "SELECT * FROM items WHERE id = '" + id + "'";

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                string sql = "UPDATE items SET type='" + cbxType.SelectedItem.ToString() + "',category='" + cbxCategory.SelectedItem.ToString() + "',title='" + txtTitle.Text + "',location='" + txtLocation.Text + "',person_name='" + txtName.Text + "',person_contact='" + txtContact.Text + "' WHERE id='" + txtId.Text + "'";
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Succesfully Turn over!!", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            load();
        }

        private void dtgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
