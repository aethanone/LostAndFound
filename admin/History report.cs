using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class History_report : UserControl
    {
        public History_report()
        {
            InitializeComponent();

            string constring = "Server=localhost;Database=lostnfound;Uid=root;Pwd=";
            string sql = "SELECT category, date, location, person_name, person_contact FROM found"; 
            using (MySqlConnection con = new MySqlConnection(constring))
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                      
                        string type = "Claimed";
                        string category = reader.GetString("category");
                        string date = reader.GetString("date");
                        string location = reader.GetString("location");
                        string person_name = reader.GetString("person_name");
                        int person_contact = reader.GetInt32("person_contact");

                       
                        Panel panelItem = new Panel();
                        panelItem.Width = 855;
                        panelItem.Height = 15;
                        panelItem.Margin = new Padding(5);
                        panelItem.BorderStyle = BorderStyle.None;

                       
                        FlowLayoutPanel innerLayout = new FlowLayoutPanel();
                        innerLayout.FlowDirection = FlowDirection.LeftToRight;
                        innerLayout.Dock = DockStyle.Fill;
                        innerLayout.WrapContents = false;

                        
                        Font boldFont = new Font("Segoe UI", 9, FontStyle.Bold);

                       
                        innerLayout.Controls.Add(new Label() { Text = $"Type: {type}", AutoSize = true, Font = boldFont });
                        innerLayout.Controls.Add(new Label() { Text = $"Category: {category}", AutoSize = true, Font = boldFont });
                        innerLayout.Controls.Add(new Label() { Text = $"Date: {date}", AutoSize = true, Font = boldFont });
                        innerLayout.Controls.Add(new Label() { Text = $"Location: {location}", AutoSize = true, Font = boldFont });
                        innerLayout.Controls.Add(new Label() { Text = $"Name: {person_name}", AutoSize = true, Font = boldFont });
                        innerLayout.Controls.Add(new Label() { Text = $"Contact: {person_contact}", AutoSize = true, Font = boldFont });

                     

                        panelItem.Controls.Add(innerLayout);

                        
                        pnlReport.Controls.Add(panelItem);
                    }
                }
            }

            
            pnlReport.FlowDirection = FlowDirection.TopDown;
            pnlReport.WrapContents = true;
            pnlReport.AutoScroll = true;

        }
        public void ExportAsImage(string path) {
            using (Bitmap bmp = new Bitmap(this.Width, this.Height)) {
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                bmp.Save(path);
            
            }
        
        }

        private void History_report_Load(object sender, EventArgs e)
        {

        }

        private void pnlReport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
