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
    public partial class ChangeBranchInfo : Form
    {
        AdminSetting admin;
        public string BranchName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Address
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Ceo
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public ChangeBranchInfo(AdminSetting admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin.DB.ChangeBranchInfo(this);
            admin.BranchName = admin.DB.BranchName;
            admin.Address = admin.DB.BrachAddress;
            admin.Ceo = admin.DB.CeoName;
            Dispose();
        }
    }
}
