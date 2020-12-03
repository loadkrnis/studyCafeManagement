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
    public partial class ChangeLoginInfo : Form
    {
        AdminSetting admin;
        DataAccess db;
        public DataAccess DB
        {
            get { return db; }
            set { db = value; }
        }
        public ChangeLoginInfo(string id, string pwd)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = pwd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.ChangeLoginInfo(textBox1.Text, textBox2.Text);
            string temp = "";
            for (int i = 0; i < DB.CeoPWD.Length; i++) temp += "*";
            admin.CeoID = DB.CeoID;
            admin.CeoPWD = temp;
            MessageBox.Show("변경이 완료되었습니다.");
            Dispose();
        }

        private void ChangeLoginInfo_Load(object sender, EventArgs e)
        {
            admin = (AdminSetting)Owner;
        }
    }
}
