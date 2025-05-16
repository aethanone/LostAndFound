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
            load();
        }

        private void btnFound_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                string sql = "SELECT * FROM items WHERE id=@id";  // Use parameterized query
                MySqlConnection con = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Add parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Only proceed if item is found
                {
                    // Read data from the "items" table
                    string type = reader.GetString("type");
                    string category = reader.GetString("category");
                    string title = reader.GetString("title");
                    string date = reader.GetString("date");
                    string location = reader.GetString("location");
                    string person_name = reader.GetString("person_name");
                    string person_contact = reader.GetString("person_contact");
                    byte[] imageBytes = reader["image"] as byte[]; // Cast the image bytes

                    reader.Close(); // Close the reader before the next query

                    try
                    {
                        // Insert into "found" table
                        string createSql = "INSERT INTO found(type, category, title, date, location, person_name, person_contact) VALUES(@type, @category, @title, @date, @location, @person_name, @person_contact)";
                        using (MySqlConnection createCon = new MySqlConnection(constring))
                        using (MySqlCommand createCmd = new MySqlCommand(createSql, createCon))
                        {
                            // Add parameters for insertion
                            createCmd.Parameters.AddWithValue("@type", type);
                            createCmd.Parameters.AddWithValue("@category", category);
                            createCmd.Parameters.AddWithValue("@title", title);
                            createCmd.Parameters.AddWithValue("@date", date);
                            createCmd.Parameters.AddWithValue("@location", location);
                            createCmd.Parameters.AddWithValue("@person_name", person_name);
                            createCmd.Parameters.AddWithValue("@person_contact", person_contact);
                            createCmd.Parameters.AddWithValue("@image", imageBytes ?? (object)DBNull.Value);  // Use DBNull.Value if image is null

                            createCon.Open();
                            createCmd.ExecuteNonQuery(); // Insert the record into the "found" table
                        }

                        MessageBox.Show("Item has been transferred to history!!", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error during transfer: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        // Delete from "items" table after insertion
                        string delSql = "DELETE FROM items WHERE id=@id";
                        using (MySqlConnection delCon = new MySqlConnection(constring))
                        using (MySqlCommand delCmd = new MySqlCommand(delSql, delCon))
                        {
                            // Add parameter to delete the item
                            delCmd.Parameters.AddWithValue("@id", txtId.Text);

                            delCon.Open();
                            int rowsAffected = delCmd.ExecuteNonQuery();  // Execute the DELETE query

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item has been successfully removed from the 'items' table.", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No item found to delete.", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error during deletion: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Item not found.", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            load();
        }

        private void load()
        {
            dtgView.Rows.Clear(); // Clear existing rows in DataGridView
            dtgView.Refresh();

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
                string date = row.Cells[3].Value.ToString();
                string category = row.Cells[2].Value.ToString();
                string location = row.Cells[4].Value.ToString();

                txtId.Text = id;
                cbxType.SelectedItem = type;
                txtDate.Text = date;
                cbxCategory.SelectedItem = category;
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
                                    txtTitle.Text = title;
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

        private void txtLoad_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
