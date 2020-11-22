namespace StudyCafeManagement
{
    partial class DayPay
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
            this.SuspendLayout();
            // 
            // nButton1
            // 
            this.nButton1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nButton1.Location = new System.Drawing.Point(143, 140);
            this.nButton1.Name = "nButton1";
            this.nButton1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Rosemary;
            this.nButton1.Size = new System.Drawing.Size(190, 154);
            this.nButton1.TabIndex = 0;
            this.nButton1.Text = "--------------\r\n1일 (24시간) \r\n#COAST원\r\n--------------";
            this.nButton1.UseVisualStyleBackColor = false;
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // DayPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.nButton1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DayPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DayPay";
            this.Load += new System.EventHandler(this.DayPay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton nButton1;
    }
}