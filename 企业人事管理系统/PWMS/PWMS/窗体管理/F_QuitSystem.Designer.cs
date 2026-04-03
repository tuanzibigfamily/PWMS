namespace 企业管理.PerForm
{
	partial class F_QuitSystem
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
			System.Windows.Forms.Button button1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_QuitSystem));
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			button1.BackColor = System.Drawing.SystemColors.Info;
			button1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			button1.Location = new System.Drawing.Point(12, 164);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(117, 42);
			button1.TabIndex = 0;
			button1.Text = "确定退出";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.Info;
			this.button3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button3.Location = new System.Drawing.Point(207, 164);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(122, 42);
			this.button3.TabIndex = 2;
			this.button3.Text = "点错了";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FloralWhite;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.textBox1.Location = new System.Drawing.Point(33, 43);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(276, 31);
			this.textBox1.TabIndex = 3;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// F_QuitSystem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(367, 239);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(button1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "F_QuitSystem";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "退出系统";
			this.Load += new System.EventHandler(this.F_QuitSystem_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
	}
}