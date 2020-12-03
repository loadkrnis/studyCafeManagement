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

        private void AdminSetting_Load(object sender, EventArgs e)
        {
            SetLoginInfo();
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

        private void SetLoginInfo()
        {
            string pwd = "";
            label1.Text = DB.CeoID;
            for (int i = 0; i < DB.CeoPWD.Length; i++) pwd += "*";
            label4.Text = pwd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeLoginInfo login = new ChangeLoginInfo(DB.CeoID, DB.CeoPWD);
            login.Owner = this;
            login.DB = DB;
            login.ShowDialog();
        }
    }
}
