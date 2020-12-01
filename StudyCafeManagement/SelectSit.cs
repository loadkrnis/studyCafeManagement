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
    public partial class SelectSit : Form
    {
        Graphics g;
        DataAccess DB;
        Sit[] SitArr;
        Sit[] FalseSitArr;

        public SelectSit(DataAccess db)
        {
            InitializeComponent();
            DB = db;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SelectSit_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            DrawSit(new Sit(e.X, e.Y, 7, 'T'));

            for (int i = 0; i < FalseSitArr.Length+1; i++)
            {
                if ((e.X >= FalseSitArr[i].x && e.X <= FalseSitArr[i].x + 40) && (e.Y >= FalseSitArr[i].y && e.Y <= FalseSitArr[i].y + 35))
                {
                    MessageBox.Show(FalseSitArr[i].num + "번 좌석을 선택하였습니다.");
                    DB.SelectSitNumber = FalseSitArr[i].num.ToString();
                    if (DB.IsChange == true)
                    {
                        DB.ChangeSit();
                        DB.IsChange = false;
                    }
                    else if (DB.IsChange == false)
                    {
                        PhoneAuth p = new PhoneAuth(DB);
                        p.Owner = this.Owner;
                        p.ShowDialog();
                    }
                    Dispose();
                    break;
                }
            }


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

        private void SelectSit_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Owner.Location.X, this.Owner.Location.Y + 80);
            Bitmap canvas;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
            SitArr = DB.GetSits();
            FalseSitArr = DB.GetFalseSits();
            for (int i = 0; i < SitArr.Length; i++)
            {
                DrawSit(SitArr[i]);
            }
        }
    }
}
