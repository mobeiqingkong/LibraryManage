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
    public partial class Admin : Form
    {

        //static string str = "Data Source=W05JB3CPPEZWUR2;Initial Catalog=BookManageDB;User ID=Mobius24;Password=admin;";
        SqlConnection myConn = new SqlConnection(Library.str);//创建数据库连接类的对象
        public Admin()
        {
            InitializeComponent();
        }
        public string adminId, adminName,adminPassword,adminPhone;
        public Admin(string id, string name, string pass, string phone)
        {

            InitializeComponent();
            adminId = id;
            adminName = name;
            adminPassword = pass;
            adminPhone = phone;
            lbWelcom.Text = lbWelcom.Text + adminName;
            MyInfoID.Text = MyInfoID.Text + adminId;
            tbAdminNameChange.Text = adminName;
            tbAdminPhoneChange.Text = adminPhone;

            tbfineDate.Text = DateTime.Now.ToString("yyyy-M-dd");
            tbrepairBook.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            tbBorrowTime.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            tbReturnTime.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            tbReturnMayTime.Text = System.DateTime.Now.AddDays(60).ToString("yyyy-M-dd");
            myConn.Open();
        }
        public void btref_Click(object sender, EventArgs e)
        {
            lvBook.Items.Clear();
            try 
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from book order by bookId";
               
                SqlDataReader re = refre.ExecuteReader();
                while(re.Read())
                {
                    ListViewItem It = new ListViewItem();
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
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }
        public string bookIdtmp;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectCount = lvBook.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                tbbookname.Text = lvBook.SelectedItems[0].SubItems[0].Text;
                tbISBN.Text = lvBook.SelectedItems[0].SubItems[1].Text;
                tbbookId.Text = lvBook.SelectedItems[0].SubItems[2].Text;
                bookIdtmp = lvBook.SelectedItems[0].SubItems[2].Text;
                tbbookAuthor.Text = lvBook.SelectedItems[0].SubItems[3].Text;
                tbpressID.Text = lvBook.SelectedItems[0].SubItems[4].Text;
                tbprice.Text = lvBook.SelectedItems[0].SubItems[5].Text;
            }
        }

        private void btchange_Click(object sender, EventArgs e)
        {
            try{
            String changebook = "update Book set bookname='" + tbbookname.Text + "',ISBN='" + tbISBN.Text + "',bookId='" + tbbookId.Text + "',bookAuthor='" + tbbookAuthor.Text + "',pressID='" + tbpressID.Text + "',price='" + tbprice.Text + "' where bookId='" +bookIdtmp+ "'";
            SqlCommand cmd = new SqlCommand(changebook, myConn);
            cmd.ExecuteNonQuery();
                        }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
            finally
            {
                btref_Click(this, e);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            
            try
            {
                lvBook.Items.Clear();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = myConn.CreateCommand();
                //把输入的数据拼接成sql语句，并交给cmd对象
                cmd.CommandText = "select * from Book where bookName LIKE '%" + tbbookname.Text + "%' AND ISBN LIKE '%" + tbISBN.Text + "%'AND bookId LIKE '%" + tbbookId.Text + "%'AND bookAuthor LIKE '%" + tbbookAuthor.Text + "%'AND pressId LIKE '%" + tbpressID.Text + "%'AND price LIKE '%" + tbprice.Text + "%'order by bookId";
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
                    lvBook.Items.Add(It);
                }
                dr.Close();

            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void btsub_Click(object sender, EventArgs e)
        {

            try
            {
                if (tbbookname.Text == "" || tbISBN.Text == ""|| tbbookId.Text == "" || tbbookAuthor.Text == "" || tbpressID.Text == "" || tbprice.Text == "")
                { MessageBox.Show("请填写完整信息", "提示"); }
                else
                {
                    lvBook.Items.Clear();
                    //执行con对象的函数，返回一个SqlCommand类型的对象
                    SqlCommand cmd = myConn.CreateCommand();
                    //把输入的数据拼接成sql语句，并交给cmd对象
                    cmd.CommandText = "insert into Book values ('" + tbbookname.Text + "','" + tbISBN.Text + "','" + tbbookId.Text + "','" + tbbookAuthor.Text + "','" + tbpressID.Text + "','" + tbprice.Text + "')";
                    //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                    SqlDataReader dr = cmd.ExecuteReader();
                    btref_Click(this,e);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }
//罚款
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectCount = lvFineRec.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                tbSelectFineID.Text = lvFineRec.SelectedItems[0].SubItems[0].Text;
                tbfineUserid.Text = lvFineRec.SelectedItems[0].SubItems[1].Text;
                tbfineDate.Text = lvFineRec.SelectedItems[0].SubItems[2].Text;
                tbfineMoney.Text = lvFineRec.SelectedItems[0].SubItems[3].Text;
                tbNote.Text = lvFineRec.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btfineRef_Click(object sender, EventArgs e)//刷新
        {
            lvFineRec.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from finerec";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["fineId"].ToString();
                    It.SubItems.Add(re["userId"].ToString());
                    It.SubItems.Add(re["fineDate"].ToString()); 
                    It.SubItems.Add(re["fineMoney"].ToString());
                    It.SubItems.Add(re["note"].ToString());
                    //将lt数据添加到listView2控件中
                    lvFineRec.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void btfineSearch_Click(object sender, EventArgs e)//查询
        {
            try
            {
                lvFineRec.Items.Clear();
                SqlCommand cmd = myConn.CreateCommand();
                cmd.CommandText = "select * from FineRec where fineDate LIKE '%" + tbfineDate.Text + "%'";
                SqlDataReader dr = cmd.ExecuteReader();
               while (dr.Read())
                {
                    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                    ListViewItem It = new ListViewItem();
                    //将数据库数据转变成ListView类型的一行数据
                    It.Text = dr["fineId"].ToString();
                    It.SubItems.Add(dr["userId"].ToString());
                    It.SubItems.Add(dr["fineDate"].ToString());
                    It.SubItems.Add(dr["fineMoney"].ToString());
                    //将lt数据添加到listView1控件中
                    lvFineRec.Items.Add(It);
                }
               dr.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void lbbookname_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btfineAdd_Click(object sender, EventArgs e)//添加
        {
            try
            {
                if (tbfineUserid.Text == "" || tbfineDate.Text == "" || tbfineMoney.Text == "")
                { MessageBox.Show("请填写完整信息", "提示"); }
                else
                {
                    //执行con对象的函数，返回一个SqlCommand类型的对象
                    SqlCommand cmd = myConn.CreateCommand();
                    //把输入的数据拼接成sql语句，并交给cmd对象
                    cmd.CommandText = "insert into fineRec(userId,fineDate,fineMoney,note) values ('" + tbfineUserid.Text + "','" + tbfineDate.Text + "','" + tbfineMoney.Text + "','" + tbNote.Text + "')";
                    //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                    SqlDataReader dr = cmd.ExecuteReader();
                    btfineRef_Click(this, e);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
            finally
                {
                myConn.Close();
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            tbfineDate.Text = DateTime.Now.ToString();
            tbrepairBook.Text = System.DateTime.Now.ToString();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
        }
        private void btdamageSearch_Click(object sender, EventArgs e)
        {
            lvBookDamage.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from DamageRec where bookId Like'%" + tbDamageBookId.Text + "%'and bookName Like '%" + tbDamagebookName.Text + "%' and ISBN Like '%" +tbDamageISBN.Text +"%'";
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

        private void btdamageChange_Click(object sender, EventArgs e)
        {
           // update DamageRec set bookRepair='是' where bookId='101-7-2-2-6'
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "update DamageRec set repairTime='" + tbrepairBook.Text + "',note='" + tbDamageNote.Text + "' where bookDamageId='" + tbDamageIdSelect.Text + "'";
                SqlDataReader re = refre.ExecuteReader();
                re.Close();

            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
            btDamageRef_Click(this, e);
        }

        private void lvBookDamage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectCount = lvBookDamage.SelectedItems.Count;
            if (selectCount > 0)
            {
                tbDamageIdSelect.Text = lvBookDamage.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void btUserRef_Click(object sender, EventArgs e)
        {
            lvUser.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from Users order by userId";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["userId"].ToString();
                    It.SubItems.Add(re["userName"].ToString());
                    It.SubItems.Add(re["userSex"].ToString());
                    lvUser.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void lvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectCount = lvUser.SelectedItems.Count;
            if (selectCount > 0)
            {
                tbSelectUserID.Text = lvUser.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void btUserpasswordReset_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "update Users set userPassword='123456'where userId='" + tbSelectUserID.Text + "'";
                SqlDataReader re = refre.ExecuteReader();
                re.Close();
                MessageBox.Show("密码已重置为123456,请及时修改", "提示");
            }
            catch (Exception ex2)
            {
                MessageBox.Show("错误;\n" + ex2.ToString(), "错误！");
            }
           
        }

        private void btUserSearch_Click(object sender, EventArgs e)
        {
            lvUser.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from Users where userId like '%" + tbUserId.Text + "%'and userName like'%"+tbUserName.Text+"%' order by userId";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["userId"].ToString();
                    It.SubItems.Add(re["userName"].ToString());
                    It.SubItems.Add(re["userSex"].ToString());
                    lvUser.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void btUserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "delete from Users where userId='" + tbSelectUserID.Text + "'";
                SqlDataReader re = refre.ExecuteReader();
                re.Close();
            }
            catch (Exception E)
            { MessageBox.Show("不允许的操作\n"+E.ToString(),"提示"); }
            btUserRef_Click(this, e);
        }
        private void btNewUserAdd_Click(object sender, EventArgs e)
        {
            if (tbNewUserID.Text == "" || tbNewUserName.Text == "" || tbNewUserPassword.Text == "" || cbNewUserSex.Text == "")
            {
                MessageBox.Show("请输入完整信息","提示");
            }
            else
            {
                try
                {
                    SqlCommand refre = myConn.CreateCommand();
                    refre.CommandText = "INSERT INTO Users VALUES ('" + tbNewUserID.Text + "','" + tbNewUserPassword.Text + "','" + tbNewUserName.Text + "','" + cbNewUserSex.Text + "')";
                    SqlDataReader re = refre.ExecuteReader();
                    re.Close();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("错误;\n" + ex2.ToString(), "错误！");
                }
                btUserRef_Click(this, e);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Library.MainForm.Show();
            this.Close();
        }

        private void btChangeinfo_Click(object sender, EventArgs e)
        {
            try{
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "update Admin set adminName='"+tbAdminNameChange.Text+"',adminPhone='"+tbAdminPhoneChange.Text+"'where adminId='" + adminId + "'";
            SqlDataReader re = refre.ExecuteReader();
            re.Close();
            MessageBox.Show("修改成功", "提示"); 
            }
                    catch (Exception E)
                    {
                        MessageBox.Show("信息不符合规范" + E.ToString(), "提示");
                    }
        }

        private void tbPassChange_Click(object sender, EventArgs e)
        {
            if (adminPassword != tbOldPass.Text)
            { MessageBox.Show("原密码错误", "提示"); }
            else 
            {

                if (tbNewPass.Text != tbNewPassRe.Text)
                { MessageBox.Show("两次新密码不一致,请重新输入", "提示"); }
                else 
                {
                    try
                    {
                        SqlCommand refre = myConn.CreateCommand();
                        refre.CommandText = "update Admin set adminPassword='" + tbNewPass.Text + "'where adminId='" + adminId + "'";
                        SqlDataReader re = refre.ExecuteReader();
                        re.Close();
                        adminPassword = tbNewPass.Text;
                        MessageBox.Show("修改成功", "提示");
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("信息不符合规范" + E.ToString(), "提示");
                    }
                }
            }
        }

        private void btBorrowRef_Click(object sender, EventArgs e)
        {
            string BookIDLS = tbBorrowBookID.Text;
            string UserIDLS = tbBorrowUserID.Text;
            tbBorrowBookID.Text = "";
            tbBorrowUserID.Text = "";
            tbBorrowBookID.Text = BookIDLS;
            tbBorrowUserID.Text = UserIDLS;
            lvBorrowRec.Items.Clear();
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "select * from BorrowRec";
                SqlDataReader re = refre.ExecuteReader();
                while (re.Read())
                {
                    ListViewItem It = new ListViewItem();
                    It.Text = re["borrowId"].ToString();
                    It.SubItems.Add(re["userId"].ToString());
                    It.SubItems.Add(re["bookId"].ToString());
                    It.SubItems.Add(re["borrowTime"].ToString());
                    It.SubItems.Add(re["returnTimeMay"].ToString());
                    It.SubItems.Add(re["returnTime"].ToString());
                    lvBorrowRec.Items.Add(It);
                }
                re.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("连接远程SQL数据库发生错误：" + ex2.ToString(), "错误！");
            }
        }

        private void btBorrow_Click(object sender, EventArgs e)
        {
            if (tbIfUsersIn.Text == "存在用户" && tbIfCanBorrow.Text == "允许借阅" && tbIfHaveBook.Text == "存在该书" && tbIfBookIn.Text == "未被借阅")
            {
                if (tbReturnMayTime.Text == "")
                { MessageBox.Show("请输入应归还日期"); }
                else
                {
                    try
                    {
                        SqlCommand refre = myConn.CreateCommand();
                        refre.CommandText = "insert into BorrowRec(userId,bookId,borrowTime,returnTimeMay) values ('" + tbBorrowUserID.Text + "','" + tbBorrowBookID.Text + "','" + tbBorrowTime.Text + "','" + tbReturnMayTime.Text + "')";
                        SqlDataReader re = refre.ExecuteReader();
                        re.Close();
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("信息不符合规范" + E.ToString(), "提示");
                    }
                    btBorrowRef_Click(this, e);
                }
            }
            else{
                MessageBox.Show("不符合条件","提示");
            }
        }

        private void lvBorrowRec_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectCount = lvBorrowRec.SelectedItems.Count;
            if (selectCount > 0)
            {
                tbSelectBorrowID.Text = lvBorrowRec.SelectedItems[0].SubItems[0].Text;
                tbBorrowUserID.Text = lvBorrowRec.SelectedItems[0].SubItems[1].Text;
                tbBorrowBookID.Text = lvBorrowRec.SelectedItems[0].SubItems[2].Text;
                tbBorrowTime.Text = lvBorrowRec.SelectedItems[0].SubItems[3].Text;
                tbReturnMayTime.Text = lvBorrowRec.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btBorrowSearch_Click(object sender, EventArgs e)
        {
            lvBorrowRec.Items.Clear();
            SqlCommand refre = myConn.CreateCommand();
            refre.CommandText = "select * from BorrowRec where userId Like '%" + tbBorrowUserID.Text + "%' and bookId Like '%" + tbBorrowBookID.Text + "%'and borrowTime like'%" + tbBorrowTime.Text + "%' and returnTimeMay like '%" + tbReturnMayTime.Text + "%'";
            SqlDataReader re = refre.ExecuteReader();
            while (re.Read())
            {
                ListViewItem It = new ListViewItem();
                It.Text = re["borrowId"].ToString();
                It.SubItems.Add(re["userId"].ToString());
                It.SubItems.Add(re["bookId"].ToString());
                It.SubItems.Add(re["borrowTime"].ToString());
                It.SubItems.Add(re["returnTimeMay"].ToString());
                It.SubItems.Add(re["returnTime"].ToString());
                lvBorrowRec.Items.Add(It);
            }
            re.Close();
        }

        private void btReturnTimeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand refre = myConn.CreateCommand();
                refre.CommandText = "update BorrowRec set returnTime='" + tbReturnTime.Text + "'where borrowId='" + tbSelectBorrowID.Text + "'";
                SqlDataReader re = refre.ExecuteReader();
                re.Close();
            }
            catch (Exception E)
            { MessageBox.Show("不符合条件"+E.ToString(),"提示"); }
            
            btBorrowRef_Click(this, e);
        }

        private void btDeletBook_Click(object sender, EventArgs e)
        {
             try
             {
                 String changebook = "delete from Book where bookId='" + tbbookId.Text + "'";
                 SqlCommand cmd = new SqlCommand(changebook, myConn);
                 cmd.ExecuteNonQuery();
             }
             catch (Exception ex2)
             {
                 MessageBox.Show("错误:" + ex2.ToString(), "错误！");
             }
            btref_Click(this, e);
        }

        private void tbBorrowUserID_TextChanged(object sender, EventArgs e)
        {
            SqlCommand SQLbook = myConn.CreateCommand();
            SQLbook.CommandText = "SELECT COUNT(borrowId) FROM BorrowRec where returnTime IS NULL and userId='" + tbBorrowUserID.Text + "'";
            SqlDataReader bookBorrowNUM = SQLbook.ExecuteReader();
            if (bookBorrowNUM.Read())
            {
                
                if (int.Parse(bookBorrowNUM[""].ToString()) <= 15)
                {
                    bookBorrowNUM.Close();
                    tbIfCanBorrow.Text = "允许借阅";
                    SqlCommand SQLbook11 = myConn.CreateCommand();
                    SQLbook11.CommandText = "SELECT count(userId) FROM Users where userId='" + tbBorrowUserID.Text + "'";
                    SqlDataReader bookBorrowNUM11 = SQLbook11.ExecuteReader();
                    if (bookBorrowNUM11.Read())
                    {
                        if (int.Parse(bookBorrowNUM11[""].ToString()) == 1)
                        {
                            bookBorrowNUM11.Close();
                            tbIfUsersIn.Text = "存在用户";
                        }
                        else
                        {
                            bookBorrowNUM11.Close();
                            tbIfUsersIn.Text = "不存在该用户";
                        }
                    }
                }
                else
                {
                    bookBorrowNUM.Close();
                    tbIfCanBorrow.Text = "不允许借阅";
                    SqlCommand SQLbook11 = myConn.CreateCommand();
                    SQLbook11.CommandText = "SELECT count(userId) FROM Users where userId='" + tbBorrowUserID.Text + "'";
                    SqlDataReader bookBorrowNUM11 = SQLbook11.ExecuteReader();
                    while (bookBorrowNUM11.Read())
                    {
                        if (int.Parse(bookBorrowNUM11[""].ToString()) == 1)
                        {
                            
                            tbIfUsersIn.Text = "存在用户";
                            bookBorrowNUM11.Close();
                        }
                        else
                        {
                            tbIfUsersIn.Text = "不存在该用户";
                            bookBorrowNUM11.Close();
                        }
                        
                    };
                }
            }
            
        }

        private void tbIfCanBorrow_TextChanged(object sender, EventArgs e)
        {
        }

        private void btDeleteBorrow_Click(object sender, EventArgs e)
        {
            try{
            String changebook = "delete from BorrowRec where borrowId='" + tbSelectBorrowID.Text + "'";
            SqlCommand cmd = new SqlCommand(changebook, myConn);
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex2)
             {
                 MessageBox.Show("错误:" + ex2.ToString(), "错误！");
             }
            btBorrowRef_Click(this, e);
        }

        private void btDeleteFine_Click(object sender, EventArgs e)
        {
            String changebook = "delete from FineRec where fineId='" + tbSelectFineID.Text + "'";
            SqlCommand cmd = new SqlCommand(changebook, myConn);
            cmd.ExecuteNonQuery();
            btfineRef_Click(this, e);
        }

        private void btDeleteDamage_Click(object sender, EventArgs e)
        {
            String changebook = "delete from DamageRec where bookDamageId='" + tbDamageIdSelect.Text + "'";
            SqlCommand cmd = new SqlCommand(changebook, myConn);
            cmd.ExecuteNonQuery();
            btDamageRef_Click(btDamageRef, e);
        }

        private void tbBorrowBookID_TextChanged(object sender, EventArgs e)
        {
            SqlCommand SQLbook = myConn.CreateCommand();
            SQLbook.CommandText = "SELECT count(bookId) FROM Book where bookId='" + tbBorrowBookID.Text + "'";
            SqlDataReader bookBorrowNUM = SQLbook.ExecuteReader();
            bookBorrowNUM.Read();
                if (int.Parse(bookBorrowNUM[""].ToString()) != 0)
                {
                    bookBorrowNUM.Close();
                    tbIfHaveBook.Text = "存在该书";
                    SqlCommand SQLbook1 = myConn.CreateCommand();
                    SQLbook1.CommandText = "SELECT count(bookId) FROM BorrowRec where bookId='" + tbBorrowBookID.Text + "' and returnTime IS NULL";
                    SqlDataReader bookBorrowNUM1 = SQLbook1.ExecuteReader();
                    bookBorrowNUM1.Read();
                        if (int.Parse(bookBorrowNUM1[""].ToString()) == 0)
                        {
                            tbIfBookIn.Text = "未被借阅";
                        }
                        else
                        {
                            tbIfBookIn.Text = "已被借阅";
                        }
                    bookBorrowNUM1.Close();
                }
                else
                {
                    bookBorrowNUM.Close();
                    tbIfHaveBook.Text = "不存在该书";
                    tbIfBookIn.Text = "已被借阅";
                }
                
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Library.MainForm.Show();
        }

        private void tbfineDate_TextChanged(object sender, EventArgs e)
        {
            tbfineDate.Text=tbfineDate.Text.Replace('/', '-');
        }

        private void btRefDate_Click(object sender, EventArgs e)
        {
            tbBorrowTime.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            tbReturnTime.Text = System.DateTime.Now.ToString("yyyy-M-dd");
            tbReturnMayTime.Text = System.DateTime.Now.AddDays(60).ToString("yyyy-M-dd");
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            tbbookname.Text = "";
            tbISBN.Text = "";
            tbbookAuthor.Text = "";
            tbpressID.Text = "";
            tbprice.Text = "";
            tbbookId.Text = "";


        }

        
      
    }
}
