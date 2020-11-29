using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCafeManagement
{
    public partial class HourPay : Form
    {
        private DataAccess DB;
        private string first;
        public HourPay(DataAccess db)
        {
            InitializeComponent();
            DB = db;
            nButton1.Text = nButton1.Text.Replace("#COAST", DB.HourCharge[0]);
            nButton2.Text = nButton2.Text.Replace("#COAST", DB.HourCharge[1]);
            nButton3.Text = nButton3.Text.Replace("#COAST", DB.HourCharge[2]);
            nButton1.Text = nButton1.Text.Replace("#H", DB.HourTime[0]);
            nButton2.Text = nButton2.Text.Replace("#H", DB.HourTime[1]);
            nButton3.Text = nButton3.Text.Replace("#H", DB.HourTime[2]);
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            DB.SelectCharge = DB.HourCharge[0];
            DB.SelectTime = DB.HourTime[0];
            SelectSit s = new SelectSit(DB);
            s.Owner = this.Owner;
            s.ShowDialog();
            Dispose();
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            DB.SelectCharge = DB.HourCharge[1];
            DB.SelectTime = DB.HourTime[1];
            SelectSit s = new SelectSit(DB);
            s.Owner = this.Owner;
            s.ShowDialog();
            Dispose();
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            DB.SelectCharge = DB.HourCharge[2];
            DB.SelectTime = DB.HourTime[2];
            SelectSit s = new SelectSit(DB);
            s.Owner = this.Owner;
            s.ShowDialog();
            Dispose();
        }
    }
}
