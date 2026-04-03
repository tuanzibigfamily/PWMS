using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace 企业管理
{
    public partial class F_Login : Form
    {
        DataClass.MyMeans MyClass = new 企业管理.DataClass.MyMeans();
        
        public F_Login()
        {
            InitializeComponent();
			textPass.PasswordChar = '*'; // 设置默认密码字符为 '*'
		}

        private void butClose_Click(object sender, EventArgs e)
        {
            if ((int)(this.Tag) == 1)
            {
                DataClass.MyMeans.Login_n = 3;
                Application.Exit();
            }
            else
                if ((int)(this.Tag) == 2)
                    this.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {
                SqlDataReader temDR = MyClass.getcom("select * from tb_Login where Name='" + textName.Text.Trim() + "' and Pass='" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();
                if (ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);
                    DataClass.MyMeans.My_con.Close();
                    DataClass.MyMeans.My_con.Dispose();
                    DataClass.MyMeans.Login_n = (int)(this.Tag);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                    textName.Focus();
                }
                MyClass.con_close();
            }
            else
            {
                MessageBox.Show("请填写完整的登录信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (textName.Text == "")
					textName.Focus();
				if(textPass.Text == "")
					textPass.Focus();

			}
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                MyClass.con_open();  //连接数据库
                MyClass.con_close();
                textName.Text = "";
                textPass.Text = "";

            }
            catch
            {
                MessageBox.Show("数据库连接失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textPass.Focus();
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
			//if (textName.Text != "" && textPass.Text != ""&& e.KeyChar == '\r')
			//	butLogin.Focus();
			if (e.KeyChar == '\r')
                butLogin.Focus();
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textName_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textPass_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}


        //密码、、、、、、、

		private async void button1_Click(object sender, EventArgs e)
		{
			textPass.Focus();//把准星拉回密码框
			if (textPass.PasswordChar == '*')
			{
                textPass.PasswordChar = '\0'; // 显示密码
			}
			await Task.Delay(2000); // 延时即2秒,使用 Task.Delay 实现延迟
			//Task.Delay 是一种更现代的方法，基于异步编程，可以更简洁地实现延时功能

			// 隐藏密码
			textPass.PasswordChar = '*'; // 隐藏密码
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textPass.Focus();//把准星拉回密码框
			if (textPass.PasswordChar == '\0')
			{
				textPass.PasswordChar = '*'; // 隐藏密码，显示为 '*'// 隐藏密码
			}
		}
	}
}