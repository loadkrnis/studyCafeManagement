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
        public EditSit(ListViewItem listViewItem)
        {
            InitializeComponent();
            item = listViewItem;
        }
        public EditSit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Dispose();
        }

        private void EditSit_Load(object sender, EventArgs e)
        {
            owner = (AdminSetting) Owner;
            //owner.SitListView.Items[owner.SitListView.SelectedIndexChanged]
        }
    }
}
