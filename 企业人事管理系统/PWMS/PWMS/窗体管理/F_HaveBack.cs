using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace 企业管理.PerForm
{
    public partial class F_HaveBack : Form
    {
        public F_HaveBack()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new 企业管理.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new 企业管理.ModuleClass.MyModule();

        private void button1_Click(object sender, EventArgs e)
        {
            string Str_dar = "";
            if (radioButton1.Checked == true)
				//应用程序的当前工作目录（即应用程序启动时的目录）
				Str_dar = System.Environment.CurrentDirectory + "\\bar\\";         
			if (radioButton2.Checked == true)
                Str_dar = textBox2.Text+ "\\";
            if (textBox2.Text == "" & radioButton2.Checked == true)
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {///数据库数据库
                Str_dar = "backup database db_企业人事管理系统 to disk='" + Str_dar+System.DateTime.Now.ToShortDateString().Replace("/","")+MyMC.Time_Format(System.DateTime.Now.ToString())+".bak" + "'";
                MyDataClass.getsqlcom(Str_dar);
                MessageBox.Show("数据备份成功！文件路径"+ Str_dar, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {
                if (DataClass.MyMeans.My_con.State == ConnectionState.Open)
                {
                    DataClass.MyMeans.My_con.Close();
                }
                SqlConnection Tem_con = new SqlConnection(DataClass.MyMeans.M_str_sqlcon);
                Tem_con.Open();////数据库
                SqlCommand SQLcom = new SqlCommand("use master restore database db_企业人事管理系统 from disk='"
                    + textBox3.Text.Trim() + "' with replace", Tem_con);
                SQLcom.ExecuteNonQuery();
                SQLcom.Dispose();
                Tem_con.Close();
                Tem_con.Dispose();
                MessageBox.Show("数据还原成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyDataClass.con_open();
                MyDataClass.con_close();
                MessageBox.Show("为了避免数据丢失，在数据库还原后将关闭整个系统。");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bak|*.bak";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void F_HaveBack_Load(object sender, EventArgs e)
		{

		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}