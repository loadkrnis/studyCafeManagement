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
    public partial class MainDashboard : Form
    {
        private DataAccess db;
        public DataAccess DB
        {
            get { return db; }
            set { db = value; }
        }
        public MainDashboard(DataAccess db)
        {
            InitializeComponent();
            DB = db;
            SetSitValue();
        }
        public void SetSitValue()
        {
            label4.Text = DB.BranchName;
            label8.Text = DB.TotalSit;
            label9.Text = DB.UsingSit;
            label10.Text = (int.Parse(DB.TotalSit) - int.Parse(DB.UsingSit)).ToString();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string y = dt.ToString("yyyy년");
            string m = dt.ToString("MM");
            string d = dt.ToString("dd");
            string t = dt.ToString("HH:mm");
            label1.Text = y;
            label2.Text = m + "/" + d;
            label3.Text = t;
        }

        private void nButton8_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "1";
            }
        }

        private void nButton9_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "2";
            }
        }

        private void nButton10_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "3";
            }
        }

        private void nButton11_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "4";
            }
        }

        private void nButton12_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "5";
            }
        }

        private void nButton13_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "6";
            }
        }

        private void nButton14_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "7";
            }
        }

        private void nButton15_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "8";
            }
        }

        private void nButton16_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "9";
            }
        }

        private void nButton17_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length == 4) { }
            else
            {
                if (nTextBox1.Text.Length == 10) { nTextBox1.Text = nTextBox1.Text.Remove(nTextBox1.TextLength - 1); }
                nTextBox1.Text = nTextBox1.Text.Remove(nTextBox1.TextLength - 1);
            }
        }

        private void nButton18_Click(object sender, EventArgs e)
        {
            if (nTextBox1.Text.Length != 13)
            {
                if (nTextBox1.Text.Length == 8) nTextBox1.Text += "-";
                nTextBox1.Text += "0";
            }
        }

        private void nButton19_Click(object sender, EventArgs e)
        {
            nTextBox1.Text = "010-";
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            DayPay dayPay = new DayPay(DB);
            dayPay.Owner = this;
            dayPay.ShowDialog();
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            HourPay hourPay = new HourPay(DB);
            hourPay.Owner = this;
            hourPay.ShowDialog();
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            string number = nTextBox1.Text.Replace("-", "").Replace("-", "").Replace("-", "");
            if (nTextBox1.Text.Length != 13) { MessageBox.Show("하단에 휴대폰번호를 입력해주세요."); }
            else
            {
                if (DB.IsMember(number))
                {
                    if (DB.HasSit(number))
                    {
                        Console.WriteLine("DB.BeforeSit : " + DB.BeforeSit);
                        DB.IsChange = true;
                        SelectSit s = new SelectSit(DB);
                        s.Owner = this;
                        s.ShowDialog();
                    }
                    else { MessageBox.Show("사용중인 고객이 아닙니다."); }
                }
                else
                {
                    MessageBox.Show("사용중인 고객이 아닙니다.");
                }
            }
        }
    }
}
