using BasicFarmland.DataBaseManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFarmland
{
    public partial class UserAdd : Form
    {
        public UserAdd()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if(username.Text == null || username.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空!");
                return ;
            }
            if(psw1.Text == null || psw1.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空!");
                return ;
            }
            if(psw1.Text != psw2.Text)
            {
                MessageBox.Show("两次密码不一致!");
                return ;
            }
            String sqlstr;
            sqlstr = "insert into UserManager(username,psw)values ('" + username.Text + "','" + psw1.Text + "')";
          
            int rs = Dao.dml(sqlstr);
            if (rs > 0)
                MessageBox.Show("数据添加成功");
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
