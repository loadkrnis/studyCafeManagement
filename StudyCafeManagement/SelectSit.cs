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
        
        public SelectSit()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color c = Color.FromArgb(0, 0, 0);
            g.DrawRectangle(new Pen(c), 40, 30, 30, 30);
        }

        private void SelectSit_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g;
            Bitmap canvas;
            
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = canvas;
            pictureBox1.Size = canvas.Size;
            g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(Image.FromFile(Path.Combine("C:\\kyu\\StudyCafeManagement\\StudyCafeManagement\\Image", "201", "sitImage.png")),new Rectangle(0, 0, canvas.Width, canvas.Height));
            Color c = Color.FromArgb(0, 0, 0);
            Console.WriteLine("X : " +e.X + "  Y : " + e.Y);
            g.DrawRectangle(new Pen(c), e.X, e.Y, 30, 30);
            
        }

        private void SelectSit_Load(object sender, EventArgs e)
        {
        }
    }
}
