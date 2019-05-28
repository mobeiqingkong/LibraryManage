namespace Library
{
    partial class Library
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
            this.components = new System.ComponentModel.Container();
            this.btLogin = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.checkpw = new System.Windows.Forms.CheckBox();
            this.tbDBDataSource = new System.Windows.Forms.TextBox();
            this.tbDBInitialCatalog = new System.Windows.Forms.TextBox();
            this.tbDBUserID = new System.Windows.Forms.TextBox();
            this.tbDBPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDBSub = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.btLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLogin.Location = new System.Drawing.Point(502, 401);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(111, 46);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "登录";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLogin.Location = new System.Drawing.Point(360, 260);
            this.tbLogin.Multiline = true;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(376, 44);
            this.tbLogin.TabIndex = 6;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(360, 322);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(376, 48);
            this.tbPassword.TabIndex = 7;
            // 
            // lbLogin
            // 
            this.lbLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbLogin.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbLogin.Location = new System.Drawing.Point(165, 260);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(177, 44);
            this.lbLogin.TabIndex = 8;
            this.lbLogin.Text = "ID/用户名:";
            this.lbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLogin.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbPassword.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPassword.Location = new System.Drawing.Point(244, 322);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(98, 44);
            this.lbPassword.TabIndex = 9;
            this.lbPassword.Text = "密码:";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPassword.Click += new System.EventHandler(this.label2_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("方正舒体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(12, 102);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(616, 110);
            this.Title.TabIndex = 10;
            this.Title.Text = "图书馆管理系统";
            // 
            // radioButton1
            // 
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(360, 423);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.Text = "管理员";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(360, 393);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "普通用户";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkpw
            // 
            this.checkpw.BackColor = System.Drawing.Color.White;
            this.checkpw.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkpw.Location = new System.Drawing.Point(595, 325);
            this.checkpw.Name = "checkpw";
            this.checkpw.Size = new System.Drawing.Size(141, 44);
            this.checkpw.TabIndex = 14;
            this.checkpw.Text = "显示密码";
            this.checkpw.UseVisualStyleBackColor = false;
            this.checkpw.CheckedChanged += new System.EventHandler(this.checkpw_CheckedChanged);
            // 
            // tbDBDataSource
            // 
            this.tbDBDataSource.Location = new System.Drawing.Point(826, 56);
            this.tbDBDataSource.Name = "tbDBDataSource";
            this.tbDBDataSource.Size = new System.Drawing.Size(164, 25);
            this.tbDBDataSource.TabIndex = 15;
            this.tbDBDataSource.Text = "W05JB3CPPEZWUR2";
            // 
            // tbDBInitialCatalog
            // 
            this.tbDBInitialCatalog.Location = new System.Drawing.Point(826, 87);
            this.tbDBInitialCatalog.Name = "tbDBInitialCatalog";
            this.tbDBInitialCatalog.Size = new System.Drawing.Size(164, 25);
            this.tbDBInitialCatalog.TabIndex = 16;
            this.tbDBInitialCatalog.Text = "BookManageDB";
            // 
            // tbDBUserID
            // 
            this.tbDBUserID.Location = new System.Drawing.Point(826, 118);
            this.tbDBUserID.Name = "tbDBUserID";
            this.tbDBUserID.Size = new System.Drawing.Size(164, 25);
            this.tbDBUserID.TabIndex = 17;
            this.tbDBUserID.Text = "Mobius24";
            // 
            // tbDBPassword
            // 
            this.tbDBPassword.Location = new System.Drawing.Point(826, 150);
            this.tbDBPassword.Name = "tbDBPassword";
            this.tbDBPassword.Size = new System.Drawing.Size(164, 25);
            this.tbDBPassword.TabIndex = 18;
            this.tbDBPassword.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(730, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "数据库名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(714, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "数据库用户ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "数据库用户密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(745, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "数据库源:";
            // 
            // tbDBSub
            // 
            this.tbDBSub.Location = new System.Drawing.Point(902, 181);
            this.tbDBSub.Name = "tbDBSub";
            this.tbDBSub.Size = new System.Drawing.Size(88, 31);
            this.tbDBSub.TabIndex = 23;
            this.tbDBSub.Text = "确认";
            this.tbDBSub.UseVisualStyleBackColor = true;
            this.tbDBSub.Click += new System.EventHandler(this.tbDBSub_Click);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1064, 649);
            this.Controls.Add(this.tbDBSub);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDBPassword);
            this.Controls.Add(this.tbDBUserID);
            this.Controls.Add(this.tbDBInitialCatalog);
            this.Controls.Add(this.tbDBDataSource);
            this.Controls.Add(this.checkpw);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.btLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Library";
            this.Text = "高校图书馆管理系统:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Library_FormClosing);
            this.Load += new System.EventHandler(this.Library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkpw;
        private System.Windows.Forms.TextBox tbDBDataSource;
        private System.Windows.Forms.TextBox tbDBInitialCatalog;
        private System.Windows.Forms.TextBox tbDBUserID;
        private System.Windows.Forms.TextBox tbDBPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tbDBSub;
    }
}

