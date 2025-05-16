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

namespace lostnfound
{
    public partial class Form1 : Form
    {
        Home home = new Home();
        view view = new view();
        Report report = new Report();
        public Form1()
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
    }
}
