using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

/*通过C#winform程序访问数据库数据

用到的命名空间和变量类型：

using System.Data.SqlClient;

SqlConnection；数据库连接类

SqlCommand；数据库操作类

SqlDataReader：读取 */
namespace Library
{
    public partial class Library : Form
    {
        public static Library MainForm=new Library();
        public Library()
        {
            InitializeComponent();
            MainForm = this;
            tbLogin.Text = "201610311180";
            tbPassword.Text = "second";
            this.DoubleBuffered = true;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public static string str = "Data Source=W05JB3CPPEZWUR2;Initial Catalog=BookManageDB;User ID=Mobius24;Password=admin;";
        static SqlConnection myConn = new SqlConnection(str);//创建数据库连接类的对象
        public static string DBDataSource, DBInitialCatalog, DBUserID, DBPassword;
        private void button2_Click(object sender, EventArgs e)
        {

        }
        public static string Id, name, pass,phone,sex;
        public void btLogin_Click(object sender, EventArgs e)
        {

            if (tbLogin.Text == "")
            { MessageBox.Show("用户名不能为空！", "提示"); }
            else if (tbPassword.Text == "")
            { MessageBox.Show("密码不能为空！", "提示"); }
            else
            {
                try //try...catch...异常处理语句
                {
                    myConn.Open(); //将连接打开
                    if (radioButton1.Checked)
                    {//SQL语句：从数据库的登录表中搜索登录名，密码
                        string sqlstring = "select * from Admin where (adminId='" + tbLogin.Text + "'or adminName='" + tbLogin.Text + "') and adminPassword='" + tbPassword.Text + "'";
                        //执行con对象的函数，返回一个SqlCommand类型的对象
                        SqlCommand command = new SqlCommand(sqlstring, myConn);
                        //用cmd的函数执行语句，返回SqlDataReader对象thisReader,thisReader就是返回的结果集（也就是数据库中查询到的表数据）
                        SqlDataReader thisReader = command.ExecuteReader();
                        //判断用户名及密码是否正确，对flag进行赋值
                        if (thisReader.Read())
                        {
                                Id = thisReader.GetValue(0).ToString().Trim();
                                name = thisReader.GetValue(1).ToString();
                                pass = thisReader.GetValue(2).ToString().Trim();
                                phone = thisReader.GetValue(3).ToString().Trim();
                            myConn.Close();
                            Admin AD = new Admin(Id,name,pass,phone); //显示主页面
                            AD.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("请检查你的用户名和密码!");
                            tbLogin.Focus();
                            myConn.Close();
                        }
                    }
                    else
                    {
                        string sqlstring = "select * from Users where (userId='" + tbLogin.Text + "'or userName='" + tbLogin.Text + "') and userPassword='" + tbPassword.Text + "'";
                        //执行con对象的函数，返回一个SqlCommand类型的对象
                        SqlCommand command = new SqlCommand(sqlstring, myConn);
                        //用cmd的函数执行语句，返回SqlDataReader对象thisReader,thisReader就是返回的结果集（也就是数据库中查询到的表数据）
                        SqlDataReader thisReader = command.ExecuteReader();
                        //判断用户名及密码是否正确，对flag进行赋值
                        if (thisReader.Read())
                        {
                            Id = thisReader.GetValue(0).ToString().Trim();
                            pass = thisReader.GetValue(1).ToString();
                            name = thisReader.GetValue(2).ToString().Trim();
                            sex = thisReader.GetValue(3).ToString().Trim();
                            myConn.Close();
                            Users US = new Users(Id, name, pass,sex); //显示主页面
                            US.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("请检查你的用户名和密码!");
                            tbLogin.Focus();
                            myConn.Close();
                        }
                    }

                }
                catch (Exception ex2)
                {
                    MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Library_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkpw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpw.Checked)
            { tbPassword.PasswordChar = '\0'; }
            else { tbPassword.PasswordChar = '*'; }
        }

        private void Library_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tbDBSub_Click(object sender, EventArgs e)
        {
            DBDataSource = tbDBDataSource.Text;
            DBInitialCatalog = tbDBInitialCatalog.Text;
            DBUserID = tbDBUserID.Text;
            DBPassword = tbDBPassword.Text;
         str = "Data Source="+DBDataSource+";Initial Catalog="+DBInitialCatalog+";User ID="+DBUserID+";Password="+DBPassword+";";
        myConn = new SqlConnection(str);//创建数据库连接类的对象
        try { myConn.Open(); }
            catch (Exception)
        { MessageBox.Show("连接失败","提示"); }
        finally { 
            myConn.Close(); }
        }
    }
}
