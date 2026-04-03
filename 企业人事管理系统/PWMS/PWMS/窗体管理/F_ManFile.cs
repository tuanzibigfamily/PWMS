using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
namespace 企业管理.PerForm
{
    public partial class F_ManFile : Form
    {
        public F_ManFile()
        {
            InitializeComponent();
        }

        #region  当前窗体的所有共公变量
        DataClass.MyMeans MyDataClass = new 企业管理.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new 企业管理.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string tem_Field = "";
        public static string tem_Value = "";
        public static string tem_ID = "";
        public static int hold_n = 0;
        public static byte[] imgBytesIn;  //用来存储图片的二进制数
        public static int Ima_n = 0;  //判断是否对图片进行了操作
        public static string Part_ID = "";  //存储数据表的ID信息
        #endregion

        public void ShowData_Image(byte[] DI, PictureBox Ima)  //显示数据库图片
        {
            byte[] buffer = DI;
            MemoryStream ms = new MemoryStream(buffer);
            Ima.Image = Image.FromStream(ms);
        }

        #region  显示“职工基本信息”表中的指定记录
        /// <summary>
        /// 动态读取指定的记录行，并进行显示.
        /// </summary>
        /// <param name="DGrid">DataGridView控件</param>
        /// <returns>返回string对象</returns> 
        public string Grid_Inof(DataGridView DGrid)
        {
            byte[] pic; //定义一个字节数组
            //当DataGridView控件的记录>1时，将当前行中信息显示在相应的控件上
            if (DGrid.RowCount > 1)
            {
                S_0.Text = DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_1.Text = DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_2.Text = Convert.ToString(DGrid[2, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_3.Text = MyMC.Date_Format(Convert.ToString(DGrid[3, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_4.Text = Convert.ToString(DGrid[4, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_5.Text = DGrid[5, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_6.Text = DGrid[6, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_7.Text = DGrid[7, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_8.Text = DGrid[8, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_9.Text = DGrid[9, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_10.Text = MyMC.Date_Format(Convert.ToString(DGrid[10, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_11.Text = Convert.ToString(DGrid[11, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_12.Text = DGrid[12, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_13.Text = DGrid[13, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_14.Text = DGrid[14, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_15.Text = DGrid[15, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_16.Text = DGrid[16, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_17.Text = DGrid[17, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_18.Text = DGrid[18, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_19.Text = DGrid[19, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_20.Text = DGrid[20, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_21.Text = MyMC.Date_Format(Convert.ToString(DGrid[21, DGrid.CurrentCell.RowIndex].Value).Trim());
				S_22.Text = DGrid[22, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_23.Text = DGrid[24, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_24.Text = DGrid[25, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_25.Text = Convert.ToString(DGrid[26, DGrid.CurrentCell.RowIndex].Value).Trim();
                S_26.Text = DGrid[27, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_27.Text = MyMC.Date_Format(Convert.ToString(DGrid[28, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_28.Text = MyMC.Date_Format(Convert.ToString(DGrid[29, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_29.Text = Convert.ToString(DGrid[30, DGrid.CurrentCell.RowIndex].Value).Trim();
                tem_ID = S_0.Text.Trim();   //获取当前职伯编号
                return DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();   //返回当前职工的姓名
            }
            else
            {
                //使用MyMeans公共类中的Clear_Control()方法清空指定控件集中的相应控件
                MyMC.Clear_Control(tabControl1.TabPages[0].Controls);
                tem_ID = "";
                return "";
            }
        }
        #endregion

        #region  按条件显示“职工基本信息”表的内容
        /// <summary>
        /// 通过公共变量动态进行查询.
        /// </summary>
        /// <param name="C_Value">条件值</param>
        public void Condition_Lookup(string C_Value)
        {
            MyDS_Grid = MyDataClass.getDataSet("Select * from tb_Stuffbasic where " + tem_Field + "='" + tem_Value + "'", "tb_Stuffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的当前记录            
        }
        #endregion

      

        private void F_ManFile_Load(object sender, EventArgs e)
        {
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_Stuffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)  //隐藏dataGridView1控件中不需要的列字段
            {
                dataGridView1.Columns[i].Visible = false;
            }

            MyMC.MaskedTextBox_Format(S_3);  //指定MaskedTextBox控件的格式
            MyMC.MaskedTextBox_Format(S_10);
            MyMC.MaskedTextBox_Format(S_27);
            MyMC.MaskedTextBox_Format(S_28);
		    MyMC.MaskedTextBox_Format(S_21);
			
            MyMC.CoPassData(S_2, "tb_Folk");  //向“民族类别”列表框中添加信息
            MyMC.CoPassData(S_5, "tb_Kultur");  //向"文化程度”列表框中添加信息
            MyMC.CoPassData(S_8, "tb_Visage");  //向"正治面貌”列表框中添加信息
            MyMC.CoPassData(S_12, "tb_EmployeeGenre");  //向"职工类别”列表框中添加信息
            MyMC.CoPassData(S_13, "tb_Business");  //向"职务类别”列表框中添加信息
            MyMC.CoPassData(S_14, "tb_Laborage");  //向"生理状况”列表框中添加信息
            MyMC.CoPassData(S_15, "tb_Branch");  //向"部门类别”列表框中添加信息
            MyMC.CoPassData(S_16, "tb_Duthcall");  //向"职称类别”列表框中添加信息
			MyMC.CoPassData(S_20, "tb_Major");
			MyMC.CityInfo(S_23, "select distinct beaware from tb_City", 0);

            S_23.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  //使S_BeAware控件具有查询功能
            S_23.AutoCompleteSource = AutoCompleteSource.ListItems;

            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的首记录
            DataClass.MyMeans.AllSql = "Select * from tb_Stuffbasic";

        }

        private void Sut_Add_Click(object sender, EventArgs e)
        {
            MyMC.Clear_Control(tabControl1.TabPages[0].Controls);   //清空职工基本信息的相应文本框
            S_0.Text = MyMC.GetAutocoding("tb_Stuffbasic", "ID");  //自动添加编号
            hold_n = 1;  //用于记录添加操作的标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 0, 0, 1, 1);
            groupBox5.Text = "当前正在添加信息";
            //Img_Clear.Enabled = true;   //使图片选择按钮为可用状态
            //Img_Save.Enabled = true;
        }

        private void S_BeAware_TextChanged(object sender, EventArgs e)
        {
            S_24.Items.Clear();
            MyMC.CityInfo(S_24, "select beaware,city from tb_City where beaware='" + S_23.Text.Trim() + "'", 1);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = true;
            Sut_Delete.Enabled = true;
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 1, 1, 0, 0);
            if (tabControl1.SelectedTab.Name == "tabPage1") //如果选择的是“职工基本信息”选项卡
            {
                hold_n = 0;  //恢复原始标识
                MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 1, 1, 0, 0);  //
                groupBox5.Text = "";
                Sub_Excel.Enabled = true;
            }
            //如果选择的是“加班出差”、“家庭关系”、“培训记录”和“奖惩记录”选项卡
            if (tabControl1.SelectedTab.Name == "tabPage2" | tabControl1.SelectedTab.Name == "tabPage3" | tabControl1.SelectedTab.Name == "tabPage4" | tabControl1.SelectedTab.Name == "tabPage5")
            {
                groupBox5.Enabled = false;  //使窗体中的操作按钮为不可用状态
                //Sub_Table.Enabled = false;
                Sub_Excel.Enabled = false;
                if (tabControl1.SelectedTab.Name == "tabPage2") //“加班出差”选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage2;
                    MyMC.MaskedTextBox_Format(Word_2);  //指定MaskedTextBox控件的格式
                    MyMC.MaskedTextBox_Format(Word_3);
                }
                if (tabControl1.SelectedTab.Name == "tabPage4") //“培训记录”选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage4;
                    MyMC.MaskedTextBox_Format(TrainNote_3);
                    MyMC.MaskedTextBox_Format(TrainNote_4);
                }
                if (tabControl1.SelectedTab.Name == "tabPage5") //“奖惩记录”选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage5;
                    MyMC.MaskedTextBox_Format(RANDP_3);
                    MyMC.MaskedTextBox_Format(RANDP_5);
                    MyMC.CoPassData(RANDP_2, "tb_RPKind");  //向“奖惩类别”列表框中添加信息
                }
                MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 1, 1, 0, 0);
            }
            if (tabControl1.SelectedTab.Name == "tabPage6") //“个人简历”选项卡
            {
                MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Delete, 0, 0, 0, 0);    //使窗体中的操作按钮为不可用
                Sut_Save.Enabled = true;    //将窗体中的“保存”按钮设为可用状态
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)  //向comboBox2控件中添加相应的查询条件
            {
                case 0:
                    {
                        MyMC.CityInfo(comboBox2, "select distinct StuffName from tb_Stuffbasic", 0);  //职工姓名
                        tem_Field = "StuffName";
                        break;
                    }
                case 1:  //性别
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("男");
                        comboBox2.Items.Add("女");
                        tem_Field = "Sex";
                        break;

                    }
                case 2:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Folk");  //民族类别
                        tem_Field = "Folk";
                        break;
                    }
                case 3:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Kultur");  //文化程度
                        tem_Field = "Kultur";
                        break;
                    }
                case 4:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Visage");  //正治面貌
                        tem_Field = "Visage";
                        break;
                    }
                case 5:
                    {
                        MyMC.CoPassData(comboBox2, "tb_EmployeeGenre");  //职工类别
                        tem_Field = "Employee";
                        break;
                    }
                case 6:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Business");  //职务类别
                        tem_Field = "Business";
                        break;
                    }
                case 7:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Branch");  //部门类别
                        tem_Field = "Branch";
                        break;
                    }
                case 8:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Duthcall");  //职称类别
                        tem_Field = "Duthcall";
                        break;
                    }
                case 9:
                    {
                        MyMC.CoPassData(comboBox2, "tb_Laborage");  //生理状况
                        tem_Field = "Laborage";
                        break;
                    }

			}

        }
        private void N_First_Click(object sender, EventArgs e)
        {
            int ColInd = 0;
            if (dataGridView1.CurrentCell.ColumnIndex == -1 || dataGridView1.CurrentCell.ColumnIndex > 1)
                ColInd = 0;
            else
                ColInd = dataGridView1.CurrentCell.ColumnIndex;
            if ((((Button)sender).Name) == "N_First")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, 0];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 0, 0, 1, 1);
            }
            if ((((Button)sender).Name) == "N_Previous")
            {
                if (dataGridView1.CurrentCell.RowIndex == 0)
                {
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 0, 0, 1, 1);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex - 1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "N_Next")
            {
                if (dataGridView1.CurrentCell.RowIndex == dataGridView1.RowCount - 2)
                {
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 0, 0);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex + 1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "N_Cauda")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.RowCount - 2];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 0, 0);
            }

        }

        private void N_Previous_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Next_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Cauda_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex > -1)
                {
                    textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的当前记录
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);  //使窗体中的编辑按钮可用
                    //获取加班出差表中的信息
                    DataSet WDset = MyDataClass.getDataSet("select Stu_ID,ID,BeginDate as 开始时间,EndDate as 结束时间, Branch as 部门, Business as 职务, WordUnit as 工作单位 from tb_WordResume where Stu_ID='" + tem_ID + "'", "tb_WordResume");
                    MyMC.Correlation_Table(WDset, dataGridView2);   //将WDset存储的信息显示在dataGridView2控件中
                    if (WDset.Tables[0].Rows.Count < 1) //当WDset中没有信息时
                        //清空相应的控件
                        MyMC.Clear_Grids(WDset.Tables[0].Columns.Count, groupBox7.Controls, "Word_");
                    //获取家庭关系表中的信息
                    //DataSet FDset = MyDataClass.getDataSet("select Stu_ID,ID,LeaguerName as 家庭成员名称,Nexus as 与本人的关系, BirthDate as 出生日期, WordUnit as 工作单位, Business as 职务, Visage as 政治面貌, Phone as 电话 from tb_Family where Stu_ID='" + tem_ID + "'", "tb_Family");
                    //MyMC.Correlation_Table(FDset, dataGridView3);
                    //if (FDset.Tables[0].Rows.Count < 1)
                    //    MyMC.Clear_Grids(FDset.Tables[0].Columns.Count, groupBox10.Controls, "Famity_");
                    //获取加班出差表中的信息
                    DataSet TDset = MyDataClass.getDataSet("select Stu_ID,ID,TrainFashion as 培训方式,BeginDate as 培训开始时间, EndDate as 培训结束时间, Speciality as 培训专业, TrainUnit as 培训单位, KulturMemo as 培训内容, Charge as 费用, Effect as 效果 from tb_TrainNote where Stu_ID='" + tem_ID + "'", "tb_TrainNote");
                    MyMC.Correlation_Table(TDset, dataGridView4);
                    if (TDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(TDset.Tables[0].Columns.Count, groupBox12.Controls, "TrainNote_");
                    //获取奖惩记录表中的信息
                    DataSet RDset = MyDataClass.getDataSet("select Stu_ID,ID,RPKind as 奖惩种类,RPDate as 奖惩时间, SealMan as 奖惩内容, QuashDate as 撤消时间, QuashWhys as 撤消原因 from tb_RANDP where Stu_ID='" + tem_ID + "'", "tb_RANDP");
                    MyMC.Correlation_Table(RDset, dataGridView5);
                    if (RDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(RDset.Tables[0].Columns.Count, groupBox14.Controls, "RANDP_");
                    //获取个人简历表中的信息
                    SqlDataReader Read_Memo = MyDataClass.getcom("Select * from tb_Individual where ID='" + tem_ID + "'");
                    if (Read_Memo.Read())
                        Ind_Mome.Text = Read_Memo[1].ToString();
                    else
                        Ind_Mome.Clear();

                    //MyMC.Show_DGrid(dataGridView2, groupBox7.Controls, "Word_");
                }
            }
            catch { }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tem_Value = comboBox2.SelectedItem.ToString();
                Condition_Lookup(tem_Value);
            }
            catch
            {
                comboBox2.Text = "";
                MessageBox.Show("只能以选择方式查询。");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tem_Field = "";
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_Stuffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的当前记录
        }

        private void Sut_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;  //用于记录修改操作的标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 0, 0, 1, 1);
            groupBox5.Text = "当前正在修改信息";
            //Img_Clear.Enabled = true;   //使图片选择按钮为可用状态
            //Img_Save.Enabled = true;
        }

        private void Sut_Cancel_Click(object sender, EventArgs e)
        {
            hold_n = 0;  //恢复原始标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 1, 1, 0, 0);
            groupBox5.Text = "";
            Ima_n = 0;
            if (tem_Field == "")
                button1_Click(sender, e);
            else
                Condition_Lookup(tem_Value);
            //Img_Clear.Enabled = false;
            //Img_Save.Enabled = false;
        }

        private void Sut_Save_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage6") //如果当前是“个人简历”选项卡
            {
                //通过MyMeans公共类中的getcom()方法查询当前职工是否添加了个人简历
                SqlDataReader Read_Memo = MyDataClass.getcom("Select * from tb_Individual where ID='" + tem_ID + "'");
                if (Read_Memo.Read())   //如果有记录
                    //将当前设置的个人简历进行修改
                    MyDataClass.getsqlcom("update tb_Individual set Memo='" + Ind_Mome.Text + "' where ID='" + tem_ID + "'");
                else
                    //如果没有记录，则进行添加操作
                    MyDataClass.getsqlcom("insert into tb_Individual (ID,Memo) values('" + tem_ID + "','" + Ind_Mome.Text + "')");
            }
            else //如果当前是“职工基本信息”选项卡
            {
                //定义字符串变量，并存储“职工基本信息表”中的所有字段
                string All_Field = "ID,StuffName,Folk,Birthday,Age,Kultur,Marriage,Sex,Visage,IDCard,Workdate,WorkLength,Employee,Business,Laborage,Branch,Duthcall,Phone,Handset,School,Speciality,GraduateDate,Address,BeAware,City,M_Pay,Bank,Pact_B,Pact_E,Pact_Y";
                try
                {
                    if (hold_n == 1 || hold_n == 2) //判断当前是添加，还是修改操作
                    {
                        ModuleClass.MyModule.ADDs = ""; //清空MyModule公共类中的ADDs变量
                        //用MyModule公共类中的Part_SaveClass()方法组合添加或修改的SQL语句
                        MyMC.Part_SaveClass(All_Field, S_0.Text.Trim(), "", tabControl1.TabPages[0].Controls, "S_", "tb_Stuffbasic", 30, hold_n);
                        //如果ADDs变量不为空，则通过MyMeans公共类中的getsqlcom()方法执行添加、修改操作
                        if (ModuleClass.MyModule.ADDs != "")
                            MyDataClass.getsqlcom(ModuleClass.MyModule.ADDs);
					}


					//string inputIdCard = S_9.Text.Trim();
					//if(inputIdCard.Equals(S_9.Text))
					//	// 如果结果大于 0，说明身份证号重复
					//	MessageBox.Show("身份证号不能重复！");
					
					if (S_9.Text == "")
					MessageBox.Show("请输入正确的身份证号！");
					if (S_9.Text.Length > 18)
					{
						MessageBox.Show("身份证号不能超过 18 位！", "输入限制", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						S_9.Focus(); // 阻止焦点丢失
					}
					if (S_17.Text == "")
						MessageBox.Show("请输入正确的手机号！");
					if (S_18.Text == "")
						MessageBox.Show("请输入正确的微信号！");
					if (S_26.Text == "")
						MessageBox.Show("请输入正确的银行账号！");
					Sut_Cancel_Click(sender, e);    //调用“取消”按钮的单击事件
                }
				catch 
				{
					MessageBox.Show("请输入正确的职工信息！");              				              
                }
			}
        }


        private void button2_Click(object sender, EventArgs e)
        {
            hold_n = 1;
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                MyMC.Clear_Control(this.groupBox7.Controls);
                Part_ID = MyMC.GetAutocoding("tb_WordResume", "ID");  //自动添加编号;
            }
            if (tabControl1.SelectedTab.Name == "tabPage4")
            {
                MyMC.Clear_Control(this.groupBox12.Controls);
                Part_ID = MyMC.GetAutocoding("tb_TrainNote", "ID");  //自动添加编号;
            }
            if (tabControl1.SelectedTab.Name == "tabPage5")
            {
                MyMC.Clear_Control(this.groupBox14.Controls);
                Part_ID = MyMC.GetAutocoding("tb_RANDP", "ID");  //自动添加编号;
            }
            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 1, 0, 1, 1);
        }

        private void Part_Save_Click(object sender, EventArgs e)
        {
            string s = "";
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                s = "ID,Stu_ID,BeginDate,EndDate,Branch,Business,WordUnit";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView2.RowCount < 2)
                    {
                        MessageBox.Show("该员工加班出差信息为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                }
                MyMC.Part_SaveClass(s, tem_ID, Part_ID, this.groupBox7.Controls, "Word_", "tb_WordResume", 7, hold_n);
            }
            if (tabControl1.SelectedTab.Name == "tabPage4")
			{//Speciality
				s = "ID,Stu_ID,TrainFashion,BeginDate,EndDate,Speciality,TrainUnit,KulturMemo,Charge,Effect,Major";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView4.RowCount < 2)
                    {
                        MessageBox.Show("该员工培训记录为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView4[1, dataGridView4.CurrentCell.RowIndex].Value.ToString();
                }
                MyMC.Part_SaveClass(s, tem_ID, Part_ID, this.groupBox12.Controls, "TrainNote_", "tb_TrainNote", 10, hold_n);
            }
            if (tabControl1.SelectedTab.Name == "tabPage5")
            {
                s = "ID,Stu_ID,RPKind,RPDate,SealMan,QuashDate,QuashWhys";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView5.RowCount < 2)
                    {
                        MessageBox.Show("该员工奖惩记录为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString();
                }
                MyMC.Part_SaveClass(s, tem_ID, Part_ID, this.groupBox14.Controls, "RANDP_", "tb_RANDP", 7, hold_n);
            }
            if (ModuleClass.MyModule.ADDs != "")
                MyDataClass.getsqlcom(ModuleClass.MyModule.ADDs);
            Part_Cancel_Click(sender, e);
        }

        private void Part_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;
            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 0, 1, 1, 1);
        }

        private void Part_Cancel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                DataSet WDset = MyDataClass.getDataSet("select Stu_ID,ID,BeginDate as 开始时间,EndDate as 结束时间, Branch as 部门, Business as 职务, WordUnit as 工作单位 from tb_WordResume where Stu_ID='" + tem_ID + "'", "tb_WordResume");
                MyMC.Correlation_Table(WDset, dataGridView2);
            }
            //if (tabControl1.SelectedTab.Name == "tabPage3")
            //{
            //    DataSet FDset = MyDataClass.getDataSet("select Stu_ID,ID,LeaguerName as 家庭成员名称,Nexus as 与本人的关系, BirthDate as 出生日期, WordUnit as 工作单位, Business as 职务, Visage as 政治面貌, Phone as 电话 from tb_Family where Stu_ID='" + tem_ID + "'", "tb_Family");
            //    MyMC.Correlation_Table(FDset, dataGridView3);
            //}
            if (tabControl1.SelectedTab.Name == "tabPage4")
            {
                DataSet TDset = MyDataClass.getDataSet("select Stu_ID,ID,TrainFashion as 培训方式,BeginDate as 培训开始时间, EndDate as 培训结束时间, Speciality as 培训专业, TrainUnit as 培训单位, KulturMemo as 培训内容, Charge as 费用, Effect as 效果 from tb_TrainNote where Stu_ID='" + tem_ID + "'", "tb_TrainNote");
                MyMC.Correlation_Table(TDset, dataGridView4);
            }
            if (tabControl1.SelectedTab.Name == "tabPage5")
            {
                DataSet RDset = MyDataClass.getDataSet("select Stu_ID,ID,RPKind as 奖惩种类,RPDate as 奖惩时间, SealMan as 奖惩内容, QuashDate as 撤消时间, QuashWhys as 撤消原因 from tb_RANDP where Stu_ID='" + tem_ID + "'", "tb_RANDP");
                MyMC.Correlation_Table(RDset, dataGridView5);
            }
            hold_n = 0;  //恢复原始标识
            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 1, 1, 0, 0);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView2, groupBox7.Controls, "Word_");
        }

        private void S_Pact_B_Leave(object sender, EventArgs e)
        {
            MyMC.Estimate_Date((MaskedTextBox)sender);
        }

        private void S_Pact_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_Pact_E_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_Pact_E_Leave(object sender, EventArgs e)
        {
            bool TDate = MyMC.Estimate_Date((MaskedTextBox)sender);
            if (TDate == true)
                if (MyMC.Date_Format(S_27.Text) != "" && MyMC.Date_Format(S_28.Text) != "")
                {
                    if (Convert.ToDateTime(S_28.Text) <= Convert.ToDateTime(S_27.Text))
                        MessageBox.Show("当前日期必须大于它前一个日期。");
                }
        }

        private void S_GraduateDate_Leave(object sender, EventArgs e)
        {
            MyMC.Estimate_Date((MaskedTextBox)sender);
        }

        private void S_GraduateDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_Workdate_Leave(object sender, EventArgs e)
        {
            MyMC.Estimate_Date((MaskedTextBox)sender);
        }

        private void S_Workdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_M_Pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, ((TextBox)sender).Text, 1);
        }

        private void S_Pact_Y_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void S_WorkLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void Part_Delete_Click(object sender, EventArgs e)
        {
            string Delete_Table = "";
            string Delete_ID = "";
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                if (dataGridView2.RowCount < 2)
                {
                    MessageBox.Show("数据表为空，不可以删除。");
                    return;
                }
                MyMC.Clear_Control(this.groupBox7.Controls);
                Delete_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                Delete_Table = "tb_WordResume";
            }
            if (tabControl1.SelectedTab.Name == "tabPage4")
            {
                if (dataGridView4.RowCount < 2)
                {
                    MessageBox.Show("数据表为空，不可以删除。");
                    return;
                }
                MyMC.Clear_Control(this.groupBox12.Controls);
                Delete_ID = dataGridView4[1, dataGridView4.CurrentCell.RowIndex].Value.ToString();
                Delete_Table = "tb_TrainNote";
            }
            if (tabControl1.SelectedTab.Name == "tabPage5")
            {
                if (dataGridView5.RowCount < 2)
                {
                    MessageBox.Show("数据表为空，不可以删除。");
                    return;
                }
                MyMC.Clear_Control(this.groupBox14.Controls);
                Delete_ID = dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString();
                Delete_Table = "tb_RANDP";
            }
            if ((Delete_ID.Trim()).Length > 0)
            {
                MyDataClass.getsqlcom("Delete " + Delete_Table + " where ID='" + Delete_ID + "'");
                Part_Cancel_Click(sender, e);
            }
        }

        private void Sut_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2) //判断dataGridView1控件中是否有记录
            {
                MessageBox.Show("数据表为空，不可以删除。");
                return;
            }
            //删除职工信息表中的当前记录，及其他相关表中的信息
            MyDataClass.getsqlcom("Delete tb_Stuffbasic where ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_WordResume where Stu_ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_Family where Stu_ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_TrainNote where Stu_ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_RANDP where Stu_ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_WordResume where Stu_ID='" + S_0.Text.Trim() + "'");
            MyDataClass.getsqlcom("Delete tb_Individual where ID='" + S_0.Text.Trim() + "'");
            Sut_Cancel_Click(sender, e);    //调用“取消”按钮的单击事件
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView4, groupBox12.Controls, "TrainNote_");
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView5, groupBox14.Controls, "RANDP_");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_Stuffbasic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)  //隐藏dataGridView1控件中不需要的列字段
            {
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void TrainNote_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, ((TextBox)sender).Text, 1);
        }

		    private void Sub_Excel_Click(object sender, EventArgs e)
		    {
		        object rng = Type.Missing;
		        //创建Excel对象
		        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
		        Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
		        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)(workbook.Worksheets[1]);
		        Microsoft.Office.Interop.Excel.Range range = null;

		        //获取除第一行之外的所有单元格范围
		        range = worksheet.Range[excel.Cells[2, 1], excel.Cells[15, 6]];

		        range.ColumnWidth = 15;//设置单元格宽度
		        range.RowHeight = 30;//设置单元格高度
		        range.Borders.LineStyle = 1;//设置边框线的宽度
		        //设置边框线的样式
		        range.BorderAround2(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black, Type.Missing);
		        range.Font.Size = 12;//设置字体大小
		        range.Font.Name = "宋体";//设置字体
		        //设置对齐格式为左对齐
		        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;

		        PictureBox pp = new PictureBox();//新建一个PictureBox控件

		        for (int i = 0; i < MyDS_Grid.Tables[0].Rows.Count; i++)
		        {

				S_1.Text = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				//MyDS_Grid.Tables[0].Rows[i][1].ToString()
					//设置标题名称
					string strInfo = "晨光稀土职工基本信息表" + "(" + S_1.Text + ")";
		            //设置第1行要合并的表格
                   
                    range.NumberFormat = "@";  // 设置单元格为文本格式，防止excel格式化丢失数字

		            range = worksheet.Range[excel.Cells[1, 1], excel.Cells[1, 6]];//\\\\\\\\\\\\\
		            range.Merge();//合并单元格
		            range.Font.Size = 30;//设置第一行的字体大小
		            range.Font.Name = "宋体";//设置第一行的字体
		            range.Font.FontStyle = "Bold";//设置第一行字体为粗体
		            //设置标题居中显示
		            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
		            excel.Cells[1, 1] = strInfo;//设置标题
		            range = worksheet.Range[excel.Cells[2, 5], excel.Cells[6, 6]];
		            range.Merge(true);
		            //第7行显示
		            range = worksheet.Range[excel.Cells[7, 5], excel.Cells[7, 6]];
		            range.Merge(true);
		            //第10行显示
		            range = worksheet.Range[excel.Cells[10, 4], excel.Cells[10, 6]];
		            range.Merge(true);
		            //第13行显示
		            range = worksheet.Range[excel.Cells[13, 2], excel.Cells[13, 6]];
		            range.Merge(true);
		            //第14行显示
		            range = worksheet.Range[excel.Cells[14, 2], excel.Cells[14, 6]];
		            range.Merge(true);
		            //第15行显示
		            range = worksheet.Range[excel.Cells[15, 2], excel.Cells[15, 6]];
		            range.Merge(true);
		    //使用Excel.Range设置单元格的水平对齐和垂直对齐为居中（xlHAlignCenter 和 xlVAlignCenter）
		    Excel.Range range13 = worksheet.Range["B13"];
		    range13.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		    range13.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
		    Excel.Range range14 = worksheet.Range["B14"];
		    range14.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		    range14.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
		    Excel.Range range15 = worksheet.Range["B15"];
		    range15.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
		    range15.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
		    //第1行赋值
		    excel.Cells[2, 1] = "职工编号：";

				     
				    excel.Cells[2, 2] = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[2, 3] = "职工姓名：";
		            excel.Cells[2, 4] = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    //第2行赋值
			    	excel.Cells[3, 1] = "民族类别：";
		            excel.Cells[3, 2] = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
				    excel.Cells[3, 3] = "出生日期：";
		            try
		            {
		                excel.Cells[3, 4] = MyMC.Date_Format(Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim());
				}
		            catch { excel.Cells[3, 4] = ""; }
		            //第3行赋值
		            excel.Cells[4, 1] = "年龄：";
		            excel.Cells[4, 2] = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
			    	excel.Cells[4, 3] = "文化程度：";
		            excel.Cells[4, 4] = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    //第4行赋值
				    excel.Cells[5, 1] = "婚姻：";
		            excel.Cells[5, 2] = dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[5, 3] = "性别：";
		            excel.Cells[5, 4] = dataGridView1[7, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            //第5行赋值
		            excel.Cells[6, 1] = "政治面貌：";
		            excel.Cells[6, 2] = dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[6, 3] = "工作时间：";
		            try
		            {
		                excel.Cells[6, 4] = MyMC.Date_Format(Convert.ToString(dataGridView1[10, dataGridView1.CurrentCell.RowIndex].Value).Trim());
				}
		            catch { excel.Cells[6, 4] = ""; }
		            //第6行赋值
		            excel.Cells[7, 1] = "籍贯：";
		            excel.Cells[7, 2] = dataGridView1[24, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[7, 3] = dataGridView1[25, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[7, 4] = "身份证号：";
		
		            excel.Cells[7, 5]= dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    //第7行赋值
			    	excel.Cells[8, 1] = "工龄年数：";
		            excel.Cells[8, 2] = Convert.ToString(dataGridView1[11, dataGridView1.CurrentCell.RowIndex].Value).Trim();
			    	excel.Cells[8, 3] = "职工类别：";
		            excel.Cells[8, 4] = dataGridView1[12, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    excel.Cells[8, 5] = "职务类别：";
		            excel.Cells[8, 6] = dataGridView1[13, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            //第8行赋值
		            excel.Cells[9, 1] = "生理状况：";
		            excel.Cells[9, 2] = dataGridView1[14, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    excel.Cells[9, 3] = "部门类别：";
		            excel.Cells[9, 4] = dataGridView1[15, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[9, 5] = "职称类别：";
		            excel.Cells[9, 6] = dataGridView1[16, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				    excel.Cells[10, 1] = "月工资：";
		            excel.Cells[10, 2] = Convert.ToString(dataGridView1[26, dataGridView1.CurrentCell.RowIndex].Value).Trim();
				    excel.Cells[10, 3] = "银行账号：";
		            excel.Cells[10, 4] = dataGridView1[27, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            //第10行赋值
		            excel.Cells[11, 1] = "合同起始日期：";
		            try
		            {
		                excel.Cells[11, 2] = MyMC.Date_Format(Convert.ToString(dataGridView1[28, dataGridView1.CurrentCell.RowIndex].Value).Trim());
				}
		            catch { excel.Cells[11, 2] = ""; }
		            excel.Cells[11, 3] = "合同结束日期：";
		            try
		            {
		                excel.Cells[11, 4] = MyMC.Date_Format(Convert.ToString(dataGridView1[29, dataGridView1.CurrentCell.RowIndex].Value).Trim());
				}
		            catch { excel.Cells[11, 4] = ""; }
		            excel.Cells[11, 5] = "合同年限：";
		            excel.Cells[11, 6] = Convert.ToString(dataGridView1[30, dataGridView1.CurrentCell.RowIndex].Value).Trim();
				//第11行赋值
				excel.Cells[12, 1] = "手机号：";
		            excel.Cells[12, 2] = dataGridView1[17, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[12, 3] = "微信：";
		            excel.Cells[12, 4] = dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            excel.Cells[12, 5] = "毕业时间：";
		            try
		            {
		                excel.Cells[12, 6] = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Tables[0].Rows[i][21]).ToShortDateString());
		            }
		            catch { excel.Cells[12, 6] = ""; }
		            //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][21]);
		            //第12行赋值
		            excel.Cells[13, 1] = "毕业院校：";
		            excel.Cells[13, 2] = dataGridView1[19, dataGridView1.CurrentCell.RowIndex].Value.ToString();
		            //第13行赋值
		            excel.Cells[14, 1] = "主修专业：";
		            excel.Cells[14, 2] = dataGridView1[20, dataGridView1.CurrentCell.RowIndex].Value.ToString();
			    	//第14行赋值
			    	excel.Cells[15, 1] = "家庭地址：";
		            excel.Cells[15, 2] = dataGridView1[22, dataGridView1.CurrentCell.RowIndex].Value.ToString();




                //保存文件
				// 创建一个 SaveFileDialog 实例
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx";  // 只允许选择 Excel 文件
				saveFileDialog.FileName = strInfo + ".xlsx";  // 默认文件名


				string filePath = "C:\\Users\\Administrator\\Desktop\\9.30后余事\\信息管理综合实验\\Excel文件\\" + strInfo + ".xlsx";

				// 检查是否已存在同名文件
				if (System.IO.File.Exists(filePath))
				{
					// 如果文件已存在
					
						try
						{
							// 尝试保存文件并覆盖原有文件
							worksheet.SaveAs(filePath);
							MessageBox.Show("文件已保存: " + filePath, "成功");
							// 在保存后，确保正确释放 Excel 资源
							System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
							worksheet = null;
							GC.Collect();
							GC.WaitForPendingFinalizers();

						}
						catch (Exception ex)
						{
							// 捕获可能的异常并显示错误消息
							MessageBox.Show("保存失败: " + ex.Message, "错误");
						}
					
					
				}
				else
				{
					// 文件不存在，直接保存文件
					try
					{
						worksheet.SaveAs(filePath);
						MessageBox.Show("文件已保存为: " + filePath, "成功");
						// 在保存后，确保正确释放 Excel 资源
						System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
						worksheet = null;
						GC.Collect();
						GC.WaitForPendingFinalizers();
					}
					catch (Exception ex)
					{
						// 捕获可能的异常并显示错误消息
						MessageBox.Show("保存失败: " + ex.Message, "错误");
					}
				}
				//// 检查是否已存在同名文件
				//if (System.IO.File.Exists("C:\\Users\\Administrator\\Desktop\\9.30后余事\\信息管理综合实验\\Excel文件\\" + strInfo + ".xlsx"))
				//{
				//	// 如果文件已存在			
				//		// 弹出保存文件对话框让用户选择新文件名
				//		if (saveFileDialog.ShowDialog() == DialogResult.OK)
				//		{
				//			// 用户选择了新路径，保存文件
				//			worksheet.SaveAs(saveFileDialog.FileName);
				//			MessageBox.Show("文件已保存为: " + saveFileDialog.FileName, "成功");
				//		}
				//		else
				//		{
				//			// 用户取消保存
				//			MessageBox.Show("保存操作已取消", "提示");
				//		}						
				//}
				//else
				//{
				//	// 文件不存在，直接保存
				//	worksheet.SaveAs("C:\\Users\\Administrator\\Desktop\\9.30后余事\\信息管理综合实验\\Excel文件\\" + strInfo + ".xlsx");
				//	MessageBox.Show("文件已保存为: C:\\Users\\Administrator\\Desktop\\9.30后余事\\信息管理综合实验\\Excel文件\\" + strInfo + ".xlsx", "成功");
				//}

				// 保存工作簿并关闭
				workbook.Save();
				workbook.Close(false, Type.Missing, Type.Missing);
			}
	}


		private void S_2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_5_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_6_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_Photo_Click(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void S_17_TextChanged(object sender, EventArgs e)
		{

		}

		private void S_28_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void label26_Click(object sender, EventArgs e)
		{

		}

		private void S_21_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_14_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_18_TextChanged(object sender, EventArgs e)
		{

		}

		private void Word_6_TextChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void S_12_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label20_Click(object sender, EventArgs e)
		{

		}

		private void S_21_TextChanged(object sender, EventArgs e)
		{

		}

		private void S_29_TextChanged(object sender, EventArgs e)
		{

		}

		private void S_21_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void S_9_TextChanged(object sender, EventArgs e)
		{

		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void RANDP_4_TextChanged(object sender, EventArgs e)
		{

		}

		private void S_0_TextChanged(object sender, EventArgs e)
		{

		}

		private void S_13_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void S_23_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label17_Click(object sender, EventArgs e)
		{

		}
	}
}