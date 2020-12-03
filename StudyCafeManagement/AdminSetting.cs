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
    public partial class AdminSetting : Form
    {
        DataAccess db;
        public DataAccess DB
        {
            get { return db; }
            set { db = value; }
        }
        public AdminSetting(DataAccess DB)
        {
            InitializeComponent();
            db = DB;
        }
        public string CeoID
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string CeoPWD
        {
            set { label4.Text = value; }
        }
        public string BranchName
        {
            get { return label20.Text; }
            set { label20.Text = value; }
        }
        public string Address
        {
            get { return label18.Text; }
            set { label18.Text = value; }

        }
        public string Ceo
        {
            get { return label16.Text; }
            set { label16.Text = value; }
        }
        public string HourPay1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string HourPay2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string HourPay3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string DayPay
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        private void AdminSetting_Load(object sender, EventArgs e)
        {
            SetInfo();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void SetInfo()
        {
            string pwd = "";
            label1.Text = DB.CeoID;
            for (int i = 0; i < DB.CeoPWD.Length; i++) pwd += "*";
            label4.Text = pwd;
            label20.Text = DB.BranchName;
            label18.Text = DB.BrachAddress;
            label16.Text = DB.CeoName;
            textBox1.Text = DB.HourCharge[0];
            textBox2.Text = DB.HourCharge[1];
            textBox3.Text = DB.HourCharge[2];
            textBox4.Text = DB.DayCharge;
        }
        private void button1_Click(object sender, EventArgs e) //Owner를 이용한 객체 전달
        {
            ChangeLoginInfo login = new ChangeLoginInfo(DB.CeoID, DB.CeoPWD);
            login.Owner = this;
            login.DB = DB;
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //생성자를 이용한 객체 전달
        {
            ChangeBranchInfo branch = new ChangeBranchInfo(this);
            branch.BranchName = DB.BranchName;
            branch.Address = DB.BrachAddress;
            branch.Ceo = DB.CeoName;
            branch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB.ChangeChargeInfo(this);
        }
    }
}
