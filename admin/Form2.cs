using lostnfound;
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
    public partial class Form2 : Form
    {
        adminAllview view = new adminAllview();
        Home home = new Home();
        Report report = new Report();
        res reciept = new res();
        public Form2()
        {
            InitializeComponent();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
            home.Dock = DockStyle.Fill;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(home);
            home.Dock = DockStyle.Fill;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(view);
            view.Dock = DockStyle.Fill;
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(report);
            report.Dock = DockStyle.Fill;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            res res = new res();
            res.Show();
            res.ExportAsImage("C:\\Users\\Jed\\OneDrive\\Documents\\history.png");
        }
    }
}
