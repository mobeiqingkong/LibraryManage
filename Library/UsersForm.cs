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

namespace Library
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection myConn = new SqlConnection(Library.str);//创建数据库连接类的对象
        public String userId, userPassword, userName, userSex;

        public Users(String Id,String na,String pa,String sex)
        {
            InitializeComponent();
            userId = Id;
            userName = na;
            userPassword = pa;
            tboldpassword.Text = pa;
            userSex = sex;
            lbwelcom.Text = lbwelcom.Text +userName;
            lbID.Text = lbID.Text+userId;
            lbBorrowHaveReturnNum.Text = "";
            myConn.Open(); 
            SqlCommand SQLbook1 = myConn.CreateCommand();
            SQLbook1.CommandText = "SELECT COUNT(borrowId) FROM BorrowRec where returnTime IS NULL and userId='" + userId + "'";
            SqlDataReader bookBorrowNUM1 = SQLbook1.ExecuteReader();
            while (bookBorrowNUM1.Read())
            {
                lbBorrowHaveReturnNum.Text = bookBorrowNUM1[""].ToString();
            }
            myConn.Close();
            myConn.Open();
            SqlCommand SQLbook2 = myConn.CreateCommand();
            SQLbook2.CommandText = "SELECT COUNT(borrowId) FROM BorrowRec where returnTime IS not NULL and userId='" + userId + "'";
            SqlDataReader bookBorrowNUM2 = SQLbook2.ExecuteReader();
            while (bookBorrowNUM2.Read())
            {
                lbBorrowNotReturnNum.Text = bookBorrowNUM2[""].ToString();
            }
            myConn.Close();
            myConn.Open();
            SqlCommand SQLbook3 = myConn.CreateCommand();
            SQLbook3.CommandText = "SELECT COUNT(borrowId) FROM BorrowRec where userId='" + userId + "'";
            SqlDataReader bookBorrowNUM3 = SQLbook3.ExecuteReader();
            while (bookBorrowNUM3.Read())
            {
                lbAllBorrowNum.Text = bookBorrowNUM3[""].ToString();
            }
            myConn.Close();
            tbDamageTime.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            myConn.Open(); //将连接打开
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            try 
            {
                lvAllBook.Items.Clear();
                SqlCommand cmd = myConn.CreateCommand();
                //把输入的数据拼接成sql语句，并交给cmd对象
                cmd.CommandText = "select * from Book where bookName LIKE '%" + tbbookName.Text + "%' AND ISBN LIKE '%"+tbISBN.Text+"%'AND bookAuthor LIKE '%"+tbbookAuthor.Text+"%'AND pressId LIKE '%"+tbpressID.Text+"%'order by bookId";
           
                //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                SqlDataReader dr = cmd.ExecuteReader();
                //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
                while (dr.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem It = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    It.Text = dr["bookName"].ToString();
                    It.SubItems.Add(dr["ISBN"].ToString());
                    It.SubItems.Add(dr["bookId"].ToString());
                    It.SubItems.Add(dr["bookAuthor"].ToString());
                    It.SubItems.Add(dr["pressID"].ToString());
                    It.SubItems.Add(dr["price"].ToString());
                    
                     
                     //将lt数据添加到listView1控件中
                    lvAllBook.Items.Add(It);
                }

                
                dr.Close(); //用完后关闭连接，以免影响其他程序访问
            
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void btchange_Click(object sender, EventArgs e)
        {
            try
            {
                if (tboldpassword.Text.Trim() == userPassword.Trim())
                { 
                    if (tbnewpassword.Text != tbconfirmnewpassword.Text)
                    { MessageBox.Show("两次新密码不一致,请重新输入", "提示"); }
                    else
                    {
                        String changeif = "update users set userPassword='" + tbnewpassword.Text + "' where userId='" + userId + "'";
                        SqlCommand cmd = new SqlCommand(changeif, myConn);
                        int count = cmd.ExecuteNonQuery();
                        userPassword = tbnewpassword.Text;
                        MessageBox.Show("修改成功", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("原密码错误", "提示");
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lvBook.Items.Clear();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = myConn.CreateCommand();
                //把输入的数据拼接成sql语句，并交给cmd对象
                cmd.CommandText = "select userId,userName,userPassword from users";
                //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                SqlDataReader dr = cmd.ExecuteReader();
                //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
                while (dr.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem It = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    It.Text = dr["userId"].ToString();
                    It.SubItems.Add(dr["userName"].ToString());
                    It.SubItems.Add(dr["userPassword"].ToString());
                    //将lt数据添加到listView1控件中
                    lvBook.Items.Add(It);
                }
                dr.Close();
            

            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void tbbookAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvAllBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectCount = lvAllBook.SelectedItems.Count;
            if (selectCount > 0)
            {
                tbSelectBookId.Text = lvAllBook.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Library.MainForm.Show();
            this.Close();
        }

        private void lbBorrowNum_Click(object sender, EventArgs e)
        {
           /* refre = myConn.CreateCommand();
            refre.CommandText = "SELECT COUNT(bookId) FROM BorrowRec where returnTime IS NULL and userId='" + userId + "'";
            SqlDataReader re = refre.ExecuteReader();*/
            lvBook.Items.Clear();
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "Select Book.bookName,Book.ISBN,BorrowRec.bookId,Book.bookAuthor,Book.pressID,Book.price FROM Book,BorrowRec where BorrowRec.returnTime IS NULL and BorrowRec.userId='"+userId+"'and BorrowRec.bookId=Book.bookId";
            SqlDataReader re = refre.ExecuteReader();
            while (re.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem It = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                It.Text = re["bookName"].ToString();
                It.SubItems.Add(re["ISBN"].ToString());
                It.SubItems.Add(re["bookId"].ToString());
                It.SubItems.Add(re["bookAuthor"].ToString());
                It.SubItems.Add(re["pressID"].ToString());
                It.SubItems.Add(re["price"].ToString());
                //将lt数据添加到listView1控件中
                lvBook.Items.Add(It);
            }
            re.Close();
        }

        private void lbBorrowNum_Click_1(object sender, EventArgs e)
        {
            lvBook.Items.Clear();
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "Select Book.bookName,Book.ISBN,BorrowRec.bookId,Book.price,BorrowRec.borrowTime,BorrowRec.returnTimeMay FROM Book,BorrowRec where BorrowRec.returnTime IS NULL and BorrowRec.userId='" + userId + "'and BorrowRec.bookId=Book.bookId order by borrowTime";
            SqlDataReader re = refre.ExecuteReader();
            while (re.Read())
            {
                ListViewItem It = new ListViewItem();
                It.Text = re["bookName"].ToString();
                It.SubItems.Add(re["ISBN"].ToString());
                It.SubItems.Add(re["bookId"].ToString());
                It.SubItems.Add(re["price"].ToString());
                It.SubItems.Add(re["borrowTime"].ToString());
                It.SubItems.Add(re["returnTimeMay"].ToString());
                lvBook.Items.Add(It);
            }
            re.Close();
        }

        private void btSearchBorrow_Click(object sender, EventArgs e)
        {
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "select BorrowRec.borrowTime,BorrowRec.returnTimeMay from BorrowRec where bookId='" + tbSelectBookId .Text+ "'and returnTime is null";
            SqlDataReader re = refre.ExecuteReader();
            if (re.Read())
            {
                tbIfborrow.Text = "已被借阅";
                tbBorrowTime.Text = re["borrowTime"].ToString();
                tbReturnMayTime.Text = re["returnTimeMay"].ToString();
            }
            else
            {
                tbIfborrow.Text = "在馆";
                tbBorrowTime.Text = "";
                tbReturnMayTime.Text = "";
            }
            re.Close();
            
        }

        private void tbSelectBookId_TextChanged(object sender, EventArgs e)
        {
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "select count(borrowId) from BorrowRec where bookId='" + tbSelectBookId.Text + "'";
            SqlDataReader re = refre.ExecuteReader();
            if (re.Read())
            {
                tbBorrowNum.Text = re[""].ToString();
            }
            else
            {
                tbBorrowNum.Text = "0";
            }
            re.Close();
        }

        private void lbBorrowNotReturnNum_Click(object sender, EventArgs e)
        {

            lvBook.Items.Clear();
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "Select Book.bookName,Book.ISBN,BorrowRec.bookId,Book.price,BorrowRec.borrowTime,BorrowRec.returnTimeMay FROM Book,BorrowRec where BorrowRec.returnTime IS not NULL and BorrowRec.userId='" + userId + "'and BorrowRec.bookId=Book.bookId order by borrowTime";
            SqlDataReader re = refre.ExecuteReader();
            while (re.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem It = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                It.Text = re["bookName"].ToString();
                It.SubItems.Add(re["ISBN"].ToString());
                It.SubItems.Add(re["bookId"].ToString());
                It.SubItems.Add(re["price"].ToString());
                It.SubItems.Add(re["borrowTime"].ToString());
                It.SubItems.Add(re["returnTimeMay"].ToString());
                //将lt数据添加到listView1控件中
                lvBook.Items.Add(It);
            }
            re.Close();
        }

        private void lbAllBorrowNum_Click(object sender, EventArgs e)
        {
            lvBook.Items.Clear();
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "Select Book.bookName,Book.ISBN,BorrowRec.bookId,Book.price,BorrowRec.borrowTime,BorrowRec.returnTimeMay FROM Book,BorrowRec where BorrowRec.userId='" + userId + "'and BorrowRec.bookId=Book.bookId order by borrowTime";
            SqlDataReader re = refre.ExecuteReader();
            while (re.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem It = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                It.Text = re["bookName"].ToString();
                It.SubItems.Add(re["ISBN"].ToString());
                It.SubItems.Add(re["bookId"].ToString());
                It.SubItems.Add(re["price"].ToString());
                It.SubItems.Add(re["borrowTime"].ToString());
                It.SubItems.Add(re["returnTimeMay"].ToString());
                //将lt数据添加到listView1控件中
                lvBook.Items.Add(It);
            }
            re.Close();
        }

        private void btDamagebookSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDamagebook.Text == "" || tbDamageTime.Text == "")
                { MessageBox.Show("请填写完整信息", "提示"); }
                else
                {
                    myConn.Open(); //将连接打开
                    //执行con对象的函数，返回一个SqlCommand类型的对象
                    SqlCommand cmd = myConn.CreateCommand();
                    //把输入的数据拼接成sql语句，并交给cmd对象
                    cmd.CommandText = "insert into DamageRec(bookName,ISBN,bookId,bookDamage,damageTime) select bookName,ISBN,bookId,'" + tbDamageInfo.Text + "','" +tbDamageTime.Text  + "' from Book where bookId='" + tbDamagebook.Text + "'";
                    //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    btDamageRef_Click(this, e);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("错误,日期格式为yyyy-M-dd,如2018-06-25\n" + ex2.ToString(), "错误！");
            }
        }

        private void btDamageRef_Click(object sender, EventArgs e)
        {
            lvBookDamage.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from DamageRec";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["bookDamageId"].ToString();
                    It.SubItems.Add(re["bookName"].ToString());
                    It.SubItems.Add(re["ISBN"].ToString());
                    It.SubItems.Add(re["bookId"].ToString());
                    It.SubItems.Add(re["bookDamage"].ToString());
                    It.SubItems.Add(re["damageTime"].ToString());
                    It.SubItems.Add(re["RepairTime"].ToString());
                    It.SubItems.Add(re["note"].ToString());
                    //将lt数据添加到listView2控件中
                    lvBookDamage.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
                
            
        
        }

        private void btdamageSearch_Click(object sender, EventArgs e)
        {

            lvBookDamage.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from DamageRec where bookId Like'%" + tbDamageBookId.Text + "%'and bookName Like '%" + tbDamagebookName.Text + "%' and ISBN Like '%" + tbDamageISBN.Text + "%'";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["bookDamageId"].ToString();
                    It.SubItems.Add(re["bookName"].ToString());
                    It.SubItems.Add(re["ISBN"].ToString());
                    It.SubItems.Add(re["bookId"].ToString());
                    It.SubItems.Add(re["bookDamage"].ToString());
                    It.SubItems.Add(re["damageTime"].ToString());
                    It.SubItems.Add(re["repairTime"].ToString());
                    It.SubItems.Add(re["note"].ToString());
                    //将lt数据添加到listView2控件中
                    lvBookDamage.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.MainForm.Show();
        }
    }
}
