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
    public partial class AdminLogin : Form
    {
        private DataAccess db;
        public DataAccess DB
        {
            get { return db; }
            set { db = value; }
        }

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db = new DataAccess("park1", "park1");
            if(db.CheckIdPwd(textBox1.Text.ToString(), textBox2.Text.ToString()))
            {
                this.Visible = false;
                MainDashboard dash = new MainDashboard(db);
                dash.Owner = this;
                dash.ShowDialog();
            }
            else {
            MessageBox.Show("아이디 또는 비밀번호 오류입니다.");
            }
        }

        private void AdminLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }
    }
}
