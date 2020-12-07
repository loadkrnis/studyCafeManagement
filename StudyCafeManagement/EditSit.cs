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
    public partial class EditSit : Form
    {
        AdminSetting owner;
        ListViewItem item;
        int index;
        string x;
        string y;
        public EditSit(ListViewItem listViewItem)
        {
            InitializeComponent();
            item = listViewItem;
        }
        public EditSit(int index, string x, string y)
        {
            this.index = index;
            this.x = x;
            this.y = y;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            owner.SitListView.Items[index-1].SubItems[1].Text = textBox1.Text;
            owner.SitListView.Items[index-1].SubItems[2].Text = textBox2.Text;
            owner.SitArr[index - 1].x = Convert.ToInt32(textBox1.Text);
            owner.SitArr[index - 1].y = Convert.ToInt32(textBox2.Text);
            Dispose();
        }

        private void EditSit_Load(object sender, EventArgs e)
        {
            owner = (AdminSetting) Owner;
            textBox1.Text = x;
            textBox2.Text = y;
        }
    }
}
