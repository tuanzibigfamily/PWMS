namespace 企业管理
{
    partial class F_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
			this.textPass = new System.Windows.Forms.TextBox();
			this.textName = new System.Windows.Forms.TextBox();
			this.butClose = new System.Windows.Forms.Button();
			this.butLogin = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// textPass
			// 
			this.textPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textPass.Location = new System.Drawing.Point(188, 175);
			this.textPass.Margin = new System.Windows.Forms.Padding(4);
			this.textPass.Name = "textPass";
			this.textPass.Size = new System.Drawing.Size(158, 25);
			this.textPass.TabIndex = 10;
			this.textPass.TextChanged += new System.EventHandler(this.textPass_TextChanged);
			this.textPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPass_KeyPress);
			// 
			// textName
			// 
			this.textName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textName.Location = new System.Drawing.Point(188, 141);
			this.textName.Margin = new System.Windows.Forms.Padding(4);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(158, 25);
			this.textName.TabIndex = 9;
			this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
			this.textName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textName_KeyPress);
			// 
			// butClose
			// 
			this.butClose.Location = new System.Drawing.Point(277, 233);
			this.butClose.Margin = new System.Windows.Forms.Padding(4);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(69, 29);
			this.butClose.TabIndex = 8;
			this.butClose.Text = "取消";
			this.butClose.UseVisualStyleBackColor = true;
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// butLogin
			// 
			this.butLogin.Location = new System.Drawing.Point(177, 233);
			this.butLogin.Margin = new System.Windows.Forms.Padding(4);
			this.butLogin.Name = "butLogin";
			this.butLogin.Size = new System.Drawing.Size(71, 29);
			this.butLogin.TabIndex = 7;
			this.butLogin.Text = "登录";
			this.butLogin.UseVisualStyleBackColor = true;
			this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Window;
			this.label1.Location = new System.Drawing.Point(89, 148);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 11;
			this.label1.Text = "用户名：";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Window;
			this.label2.Location = new System.Drawing.Point(89, 181);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 15);
			this.label2.TabIndex = 12;
			this.label2.Text = "密  码：";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(429, 262);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(58, 141);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(24, 22);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(58, 174);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(24, 22);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 14;
			this.pictureBox3.TabStop = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.button1.Location = new System.Drawing.Point(58, 204);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 25);
			this.button1.TabIndex = 17;
			this.button1.Text = "显示密码";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.button2.Location = new System.Drawing.Point(58, 235);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(90, 25);
			this.button2.TabIndex = 18;
			this.button2.Text = "隐藏密码";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// F_Login
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 262);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textPass);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.butClose);
			this.Controls.Add(this.butLogin);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "F_Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "F_Login";
			this.Activated += new System.EventHandler(this.F_Login_Activated);
			this.Load += new System.EventHandler(this.F_Login_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}