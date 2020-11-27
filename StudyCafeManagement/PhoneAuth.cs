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
    public partial class PhoneAuth : Form
    {
        int flag;
        Nevron.UI.WinForm.Controls.NTextBox target;
        string authNumber;
        DataAccess DB;

        public PhoneAuth(DataAccess db)
        { 
            InitializeComponent();
            flag = 0;
            target = nTextBox1;
            DB = db;
        }

        private void nButton7_Click(object sender, EventArgs e)
        {
            if (flag == 0) //휴대폰번호 입력 완료
            {
                if (nTextBox1.Text.Length == 13)
                {
                    if (DB.IsMember(nTextBox1.Text.Replace("-", "").Replace("-", "").Replace("-", "")))
                    {
                        MessageBox.Show("회원입니다.");
                        DB.InsertSale();
                        MainDashboard ds = (MainDashboard) Owner;
                        ds.DB = DB;
                        //sale 테이블 insert
                        //영수증 출력 
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("회원이 아닙니다.\n인증번호를 발송하였습니다.");
                        nTextBox1.Location = new System.Drawing.Point(nTextBox1.Location.X, nTextBox1.Location.Y - 66);
                        nTextBox1.Enabled = false;
                        nTextBox2.Visible = true;
                        nTextBox2.Enabled = true;
                        nButton7.Text = "인증번호 인증";
                        target = nTextBox2;
                        flag = 1;
                        Random random = new Random();
                        for (int i = 0; i < 6; i++)
                        {
                            authNumber += random.Next(0, 10).ToString();
                        }
                        Console.WriteLine(authNumber);
                    }

                }
                else
                {
                    MessageBox.Show("올바른 번호를 입력하세요.");
                }
            }
            else if (flag == 1)  // 인증번호 입력 완료
            {
                if (nTextBox2.Text == authNumber)
                {
                    MessageBox.Show("인증이 완료되었습니다.");
                    if (DB.InsertMember(nTextBox1.Text.Replace("-", "").Replace("-", "").Replace("-", "")))
                    {
                        //sale 테이블 insert
                        //영수증 출력
                    }
                    else
                    {
                        MessageBox.Show("알 수 없는 오류가 발생하였습니다. 관리자에게 문의하세요. (InsertMember Method Error)");
                    }

                    Dispose();
                }
                else
                {
                    MessageBox.Show("잘못입력하였습니다.\n다시 입력바랍니다.");
                }
            }
        }

        private void nButton8_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "1";
            }
        }

        private void nButton9_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "2";
            }
        }

        private void nButton10_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "3";
            }
        }

        private void nButton11_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "4";
            }
        }

        private void nButton12_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "5";
            }
        }

        private void nButton13_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "6";
            }
        }

        private void nButton14_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "7";
            }
        }

        private void nButton15_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "8";
            }
        }

        private void nButton16_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "9";
            }
        }

        private void nButton18_Click(object sender, EventArgs e)
        {
            if (target.Text.Length != 13)
            {
                if (target.Text.Length == 8) target.Text += "-";
                target.Text += "0";
            }
        }

        private void nButton17_Click(object sender, EventArgs e)
        {
            if (target == nTextBox1)
            {
                if (target.Text.Length == 4) { }
                else
                {
                    if (target.Text.Length == 10) { target.Text = target.Text.Remove(target.TextLength - 1); }
                    target.Text = target.Text.Remove(target.TextLength - 1);
                }
            }
            else
            {
                if (target.Text.Length != 0)
                    target.Text = target.Text.Remove(target.TextLength - 1);
            }
        }

        private void nButton19_Click(object sender, EventArgs e)
        {
            if (target == nTextBox1)
            {
                target.Text = "010-";
            }
            else if (target == nTextBox2)
            {
                target.Text = "";
            }
        }

        private void PhoneAuth_Load(object sender, EventArgs e)
        {
            target.Focus();
            this.Location = new Point(this.Owner.Location.X, this.Owner.Location.Y + 80);
        }
    }
}
