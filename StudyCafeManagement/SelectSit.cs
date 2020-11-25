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
        int[,] arr = new int[,]
{
        { 121, 122 },
        { 221, 222 },
        { 321, 322 }
};

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

            Bitmap canvas;

            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")), new Rectangle(0, 0, canvas.Width, canvas.Height));
            DrawSit(e.X, e.Y, "7", 'T');
        }

        private void DrawSit(int x, int y, string sitNumber, char isUsed)
        {
            Console.WriteLine("X : " + x + "  Y : " + y);
            Pen p = new Pen(Color.Gray, 3);
            Font f = new Font("휴먼둥근헤드라인", 16, FontStyle.Bold);
            if (isUsed == 'T')
            {
                g.FillRectangle(Brushes.DimGray, x, y, 40, 35);
            }
            if (isUsed == 'F')
            {
                g.FillRectangle(Brushes.GreenYellow, x, y, 40, 35);
            }
            g.DrawRectangle(p, x, y, 40, 35);
            if (sitNumber.Length == 1)
            {
                g.DrawString(sitNumber, f, Brushes.Black, x + 8, y + 7);
            }
            else
            {
                g.DrawString(sitNumber, f, Brushes.Black, x, y + 7);
            }
        }

        private void SelectSit_Load(object sender, EventArgs e)
        {
            DB.GetSits();
        }
    }
}
