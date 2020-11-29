namespace StudyCafeManagement
{
    partial class HourPay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.nButton2 = new Nevron.UI.WinForm.Controls.NButton();
            this.nButton3 = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // nButton1
            // 
            this.nButton1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nButton1.Location = new System.Drawing.Point(52, 138);
            this.nButton1.Name = "nButton1";
            this.nButton1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Rosemary;
            this.nButton1.Size = new System.Drawing.Size(190, 154);
            this.nButton1.TabIndex = 1;
            this.nButton1.Text = "--------------\r\n#H시간 \r\n#COAST원\r\n--------------";
            this.nButton1.UseVisualStyleBackColor = false;
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // nButton2
            // 
            this.nButton2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nButton2.Location = new System.Drawing.Point(305, 138);
            this.nButton2.Name = "nButton2";
            this.nButton2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Rosemary;
            this.nButton2.Size = new System.Drawing.Size(190, 154);
            this.nButton2.TabIndex = 2;
            this.nButton2.Text = "--------------\r\n#H시간 \r\n#COAST원\r\n--------------";
            this.nButton2.UseVisualStyleBackColor = false;
            this.nButton2.Click += new System.EventHandler(this.nButton2_Click);
            // 
            // nButton3
            // 
            this.nButton3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nButton3.Location = new System.Drawing.Point(553, 138);
            this.nButton3.Name = "nButton3";
            this.nButton3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Rosemary;
            this.nButton3.Size = new System.Drawing.Size(190, 154);
            this.nButton3.TabIndex = 3;
            this.nButton3.Text = "--------------\r\n#H시간 \r\n#COAST원\r\n--------------";
            this.nButton3.UseVisualStyleBackColor = false;
            this.nButton3.Click += new System.EventHandler(this.nButton3_Click);
            // 
            // HourPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nButton3);
            this.Controls.Add(this.nButton2);
            this.Controls.Add(this.nButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HourPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HourPay";
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton nButton1;
        private Nevron.UI.WinForm.Controls.NButton nButton2;
        private Nevron.UI.WinForm.Controls.NButton nButton3;
    }
}