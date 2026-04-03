using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace 企业管理.PerForm
{
	public partial class F_QuitSystem : Form
	{
		public F_QuitSystem()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			/*textBox1.Text = DataClass.MyMeans.Login_Name+"管理员确定要退出吗"*/;	
		}
		
		private void F_QuitSystem_Load(object sender, EventArgs e)
		{
			//////////////////////////文本在没有点击的情况下自动更改
			textBox1.Text ="[" +DataClass.MyMeans.Login_Name +"]管理员确定要退出吗";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
