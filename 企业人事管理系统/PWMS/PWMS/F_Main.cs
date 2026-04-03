using 企业管理.PerForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Data.Common;

namespace 企业管理
{
    public partial class F_Main : Form
    {
        DataClass.MyMeans MyClass = new 企业管理.DataClass.MyMeans();
        ModuleClass.MyModule MyMenu = new 企业管理.ModuleClass.MyModule();
        public F_Main()
        {
            InitializeComponent();
        
			timer1.Interval = 1000;  // 设置计时器每秒触发一次
			timer1.Tick += Timer1_Tick;  // 绑定 Tick 事件
			timer1.Start();  // 启动计时器
        }
		#region  显示当前日期时间
		// Timer 的 Tick 事件，每秒触发一次
		//private void Timer1_Tick(object sender, EventArgs e)
		//{
		//	// 更新 labelTime 控件，显示当前时间
		//	textBoxNowTime.Text ="现在是" +DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // 格式化时间为 "小时:分钟:秒"
		//}
		private void Timer1_Tick(object sender, EventArgs e)
		{
			// 获取当前日期
			DateTime now = DateTime.Now;

			// 获取星期几的中文表示
			string dayOfWeek = GetChineseDayOfWeek(now.DayOfWeek);

			// 格式化时间为 "yyyy-MM-dd HH:mm:ss" 格式，并显示星期几
			textBoxNowTime.Text = $"{now:yyyy-MM-dd HH:mm:ss}{dayOfWeek}";
		}

		// 根据 DayOfWeek 返回中文星期几
		private string GetChineseDayOfWeek(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case DayOfWeek.Sunday: return "星期天";
				case DayOfWeek.Monday: return "星期一";
				case DayOfWeek.Tuesday: return "星期二";
				case DayOfWeek.Wednesday: return "星期三";
				case DayOfWeek.Thursday: return "星期四";
				case DayOfWeek.Friday: return "星期五";
				case DayOfWeek.Saturday: return "星期六";
				default: return "";
			}
		}

		#endregion
		#region  通过权限对主窗体进行初始化
		/// <summary>
		/// 对主窗体初始化
		/// </summary>
		private void Preen_Main()
        {
          
            treeView1.Nodes.Clear();
            MyMenu.GetMenu(treeView1, menuStrip1);  //调用公共类MyModule下的GetMenu()方法，将menuStrip1控件的子菜单添加到treeView1控件中
            MyMenu.MainMenuF(menuStrip1);   //将菜单栏中的各子菜单项设为不可用状态
            MyMenu.MainPope(menuStrip1, DataClass.MyMeans.Login_Name);  //根据权限设置相应子菜单的可用状态
        }
		#endregion


		public static string AllSqlWORDPAD = "select ID,BlotterDate as 日志时间,BlotterSort as 部门类别,Motif as 主题,Wordpad as 内容 from tb_DayWordPad";
		public static DataSet MyDS_Grid;  //存储数据表信息
        public static string AllSqlTotalNumberOfPeople = "SELECT COUNT(ID) as 公司人数 FROM tb_Stuffbasic";
		


		private void F_Main_Load(object sender, EventArgs e)
		{
			F_Login FrmLogin = new F_Login();   //声时登录窗体，进行调用
            FrmLogin.Tag = 1;   //将登录窗体的Tag属性设为1，表示调用的是登录窗体
            FrmLogin.ShowDialog();
            FrmLogin.Dispose();
			Preen_Main();
			//当调用的是登录窗体时      
			DataClass.MyMeans.Login_n = 3;  //将公共变量设为3，便于控制登录窗体的关闭
            Tool_Help.Enabled = true;
			//////////////////////////文本在没有点击的情况下自动更改
			toolStripStatusLabel3.Text= DataClass.MyMeans.Login_Name;

			ModuleClass.MyModule MyMC = new 企业管理.ModuleClass.MyModule();
			DataClass.MyMeans MyDataClass = new 企业管理.DataClass.MyMeans();




			SqlConnection Tem_conTotalNumberOfPeople = new SqlConnection(DataClass.MyMeans.M_str_sqlcon);
			Tem_conTotalNumberOfPeople.Open();
			SqlCommand SQLcomTotalNumberOfPeople = new SqlCommand(AllSqlTotalNumberOfPeople, Tem_conTotalNumberOfPeople);
			object result = SQLcomTotalNumberOfPeople.ExecuteScalar();
			// 如果返回结果不是 null
			if (result != DBNull.Value)
			{
				int totalPeople = Convert.ToInt32(result);  // 转换为 int
				TotalNumberOfPeople.Text = "企业人数：" + totalPeople.ToString();  // 显示在 TextBox 上
			}
			else
			{
				TotalNumberOfPeople.Text = "企业人数：0";  // 如果查询结果为空，则显示 0
			}

			//日志文件
			MyDS_Grid = MyDataClass.getDataSet(AllSqlWORDPAD, "tb_DayWordPad");
			dataGridView1.DataSource = MyDS_Grid.Tables[0];
			dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
			dataGridView1.Columns[1].Width = 80;
			dataGridView1.Columns[2].Width = 100;
			dataGridView1.Columns[3].Width = 100;
			dataGridView1.Columns[4].Width = 500;
			//隐藏dataGridView1控件中不需要的列字段
			dataGridView1.Columns[0].Visible = false;
		}
		private void button1_Click(object sender, EventArgs e)
		{
            //刷新日志文件
			DataClass.MyMeans MyDataClass = new 企业管理.DataClass.MyMeans();
			//日志文件
			MyDS_Grid = MyDataClass.getDataSet(AllSqlWORDPAD, "tb_DayWordPad");
			dataGridView1.DataSource = MyDS_Grid.Tables[0];
			dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
			dataGridView1.Columns[1].Width = 80;
			dataGridView1.Columns[2].Width = 100;
			dataGridView1.Columns[3].Width = 100;
			dataGridView1.Columns[4].Width = 500;
			//隐藏dataGridView1控件中不需要的列字段
			dataGridView1.Columns[0].Visible = false;

			SqlConnection Tem_conTotalNumberOfPeople = new SqlConnection(DataClass.MyMeans.M_str_sqlcon);
			Tem_conTotalNumberOfPeople.Open();
			SqlCommand SQLcomTotalNumberOfPeople = new SqlCommand(AllSqlTotalNumberOfPeople, Tem_conTotalNumberOfPeople);
			object result = SQLcomTotalNumberOfPeople.ExecuteScalar();
			// 如果返回结果不是 null
			if (result != DBNull.Value)
			{
				int totalPeople = Convert.ToInt32(result);  // 转换为 int
				TotalNumberOfPeople.Text = "企业人数：" + totalPeople.ToString();  // 显示在 TextBox 上
			}
			else
			{
				TotalNumberOfPeople.Text = "企业人数：0";  // 如果查询结果为空，则显示 0
			}
		}
		private void F_Main_Activated(object sender, EventArgs e)
        {
            if (DataClass.MyMeans.Login_n == 2) //当调用的是重新登录窗体时
                Preen_Main();   //自定义方法，通过权限对窗体进行初始化
            DataClass.MyMeans.Login_n = 3;
        }

        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			PerForm.F_QuitSystem FrmQuitSystem = new 企业管理.PerForm.F_QuitSystem();
			FrmQuitSystem.Text = "退出系统";
			FrmQuitSystem.ShowDialog();
			FrmQuitSystem.Dispose();
			//Application.Exit();
		}
        public void Tool_Folk_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }
        private void Tool_Stuffbusic_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);   //用MyModule公共类中的Show_Form()方法调用各窗体
        }
        private void Tool_Stufind_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_Stusum_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_DayWordPad_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_AddressBook_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_Back_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_Clear_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_NewLogon_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_Setup_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Trim() == "系统退出")   //如果当前节点的文本为“系统退出”
            {
				PerForm.F_QuitSystem FrmQuitSystem = new 企业管理.PerForm.F_QuitSystem();
				FrmQuitSystem.Text = "系统退出";
				FrmQuitSystem.ShowDialog();
				FrmQuitSystem.Dispose();
				//Application.Exit(); //关闭应用程序
			}
            MyMenu.TreeMenuF(menuStrip1, e);   //用MyModule公共类中的TreeMenuF()方法调用各窗体
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
			MyMenu.Show_Form(sender.ToString().Trim(), 1);        			
		}
        private void Button_Stuffbusic_Click(object sender, EventArgs e)
        {
            if (Tool_Stuffbusic.Enabled==true)
                Tool_Stuffbusic_Click(sender, e);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }
        private void Button_Stufind_Click(object sender, EventArgs e)
        {
            if (Tool_Stufind.Enabled == true)
                Tool_Stufind_Click(sender, e);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }
        private void Botton_AddressBook_Click(object sender, EventArgs e)
        {
            if (Tool_AddressBook.Enabled == true)
                Tool_AddressBook_Click(sender, e);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }
        private void Botton_DayWordPad_Click(object sender, EventArgs e)
        {
            if (Tool_DayWordPad.Enabled == true)
                Tool_DayWordPad_Click(sender, e);
            else
                MessageBox.Show("当前用户无权限调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }
        private void Tool_WordBook_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
        private void Tool_Help_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }
		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{   }
		private void toolStripStatusLabel3_Click(object sender, EventArgs e)
		{
        }
		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{	}
		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{	}
		private void Menu_1_Click(object sender, EventArgs e)
		{	}
		private void Menu_2_Click(object sender, EventArgs e)
		{	}
		private void Menu_10_Click(object sender, EventArgs e)
		{	}
		private void Menu_4_Click(object sender, EventArgs e)
		{	}
		private void Menu_7_Click(object sender, EventArgs e)
		{	}
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{	}
		private void Menu_6_Click(object sender, EventArgs e)
		{	}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void toolStripStatusLabel3_Click_1(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void textBoxNowTime_TextChanged(object sender, EventArgs e)
		{

		}
	}
}