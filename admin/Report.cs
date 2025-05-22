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
using System.IO;

namespace lostnfound
{
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
           
            
        

    }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            DateTime currentDateTime = DateTime.Now;
            string formattedDate = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Step 2: Convert image to byte array
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                try
                {


                    string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
                    string sql = "INSERT INTO items( type, category, title, date, location, person_name, person_contact, image) VALUES ('" + cbxType.SelectedItem.ToString() + "','" + cbxCategory.SelectedItem.ToString() + "','" + txtTitle.Text + "','" + formattedDate + "','" + txtLocation.Text + "','" + txtName.Text + "','" + txtContact.Text + "',@photo)";
                    MySqlConnection con = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader reader;
                    cmd.Parameters.AddWithValue("@photo", imageBytes);
                    con.Open();
                    reader = cmd.ExecuteReader();
                    con.Close();

                    MessageBox.Show("Succesfully Turn over!!", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception error)
                {
                    MessageBox.Show("Connection error: " + error.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Format the DateTime as a string
           
            
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
