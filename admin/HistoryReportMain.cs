using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lostnfound;

namespace admin
{
    public partial class HistoryReportMain : Form
    {
        History_report report = new History_report();
        public HistoryReportMain()
        {
            InitializeComponent();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(report);
            report.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            History_report report = new History_report();
            report.ExportAsImage("C:\\Users\\chris\\Documents\\history.png");
            MessageBox.Show("Print successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
