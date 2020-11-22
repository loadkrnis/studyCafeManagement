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
    public partial class DayPay : Form
    {
        private DataAccess DB;
        private string first;
        public DayPay(DataAccess db)
        {
            InitializeComponent();
            nButton1.Text = nButton1.Text.Replace("#COAST", db.DayCharge);
            first = db.DayCharge;
            DB = db;
        }

        private void DayPay_Load(object sender, EventArgs e)
        {

        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            DB.SelectCharge = first;
            DB.SelectTime = "day";

            Console.WriteLine(DB.SelectCharge);
            Console.WriteLine(DB.SelectTime);
            Dispose();
        }
    }
}
