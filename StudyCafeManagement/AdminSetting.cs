using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCafeManagement
{
    public partial class AdminSetting : Form
    {
        Graphics g;
        List<Sit> SitList = null;
        public Sit[] SitArr;

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
        public ListView SitListView
        {
            get { return listView1; }
            set { listView1 = value; }
        }
        private bool IsOnClick = false;
        private Point MouseOnClickPosition = new Point();

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
            //InfoTextInit
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

            //SitGraphicsInit
            Location = new Point(this.Owner.Location.X, this.Owner.Location.Y + 80);
            Bitmap canvas;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
            SitArr = DB.GetSits();
            ListViewItem item;
            listView1.Items.Clear();
            for (int i = 0; i < SitArr.Length; i++)
            {
                DrawSit(SitArr[i]);
                item = new ListViewItem(SitArr[i].num.ToString());
                item.SubItems.Add(SitArr[i].x.ToString());
                item.SubItems.Add(SitArr[i].y.ToString());
                item.SubItems.Add(SitArr[i].isUsed == 'T' ? "사용중" : "사용가능");
                listView1.Items.Add(item);

            }

            //SitListViewInit
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

        private void DrawSit(Sit sit)
        {
            Pen p = new Pen(Color.Gray, 3);
            Font f = new Font("휴먼둥근헤드라인", 16, FontStyle.Bold);
            if (sit.isUsed == 'T')
            {
                g.FillRectangle(Brushes.DimGray, sit.x, sit.y, 40, 35);
            }
            if (sit.isUsed == 'F')
            {
                g.FillRectangle(Brushes.GreenYellow, sit.x, sit.y, 40, 35);
            }
            g.DrawRectangle(p, sit.x, sit.y, 40, 35);
            if (sit.num < 10)
            {
                g.DrawString(sit.num.ToString(), f, Brushes.Black, sit.x + 8, sit.y + 7);
            }
            else
            {
                g.DrawString(sit.num.ToString(), f, Brushes.Black, sit.x, sit.y + 7);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < SitArr.Length + 1; i++)
            {
                try
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if ((e.X >= SitArr[i].x && e.X <= SitArr[i].x + 40) && (e.Y >= SitArr[i].y && e.Y <= SitArr[i].y + 35))
                        {
                            IsOnClick = true;
                            MouseOnClickPosition.X = e.X;
                            MouseOnClickPosition.Y = e.Y;
                            break;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsOnClick = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item;
            for (int i = 0; i < SitArr.Length + 1; i++)
            {
                try
                {
                    if ((e.X >= SitArr[i].x && e.X <= SitArr[i].x + 40) && (e.Y >= SitArr[i].y && e.Y <= SitArr[i].y + 35))
                    {
                        if (IsOnClick)
                        {
                            Bitmap canvas;
                            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            pictureBox1.Image = canvas;
                            pictureBox1.Size = canvas.Size;
                            g = Graphics.FromImage(pictureBox1.Image);
                            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
                            SitArr[i].x = SitArr[i].x + (e.X - MouseOnClickPosition.X);
                            SitArr[i].y = SitArr[i].y + (e.Y - MouseOnClickPosition.Y);
                            MouseOnClickPosition.X = e.X;
                            MouseOnClickPosition.Y = e.Y;
                            item = new ListViewItem(SitArr[i].num.ToString());
                            listView1.Items[i].SubItems[1].Text = SitArr[i].x.ToString();
                            listView1.Items[i].SubItems[2].Text = SitArr[i].y.ToString();
                            for (int j = 0; j < SitArr.Length; j++)
                            {
                                DrawSit(SitArr[j]);
                            }
                        }

                    }
                }
                catch (Exception) { }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB.ModifySit(listView1.Items);
            MessageBox.Show("저장되었습니다.");
        }

        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SitList = SitArr.ToList<Sit>();

            ListViewItem item = new ListViewItem((listView1.Items.Count + 1).ToString());
            //item.Text = listView1.Items.Count.ToString();
            item.SubItems.Add("10");
            item.SubItems.Add("10");
            item.SubItems.Add("사용가능");
            listView1.Items.Add(item);
            SitList.Add(new Sit(10, 10, listView1.Items.Count, 'F'));
            SitArr = SitList.ToArray();
            Bitmap canvas;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
            for (int i = 0; i < SitArr.Length; i++)
            {
                DrawSit(SitArr[i]);
            }
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = listView1.SelectedItems[0].SubItems[1].Text;
            string y = listView1.SelectedItems[0].SubItems[2].Text;
            int index = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            EditSit es = new EditSit(index, x, y);
            es.Owner = this;
            es.ShowDialog();
            Bitmap canvas;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
            for (int i = 0; i < SitArr.Length; i++)
            {
                DrawSit(SitArr[i]);
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("전체삭제를 하시겠습니까?", "경고", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                listView1.Items.Clear();
                SitArr = new Sit[0];
                Console.Write(SitArr.Length);
                Bitmap canvas;
                canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = canvas;
                pictureBox1.Size = canvas.Size;
                g = Graphics.FromImage(pictureBox1.Image);
                g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
                for (int i = 0; i < SitArr.Length; i++)
                {
                    DrawSit(SitArr[i]);
                }
            }
        }
    }
}
