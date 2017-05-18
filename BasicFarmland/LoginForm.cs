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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string psw = textBox2.Text.Trim();
            string sql = "select*from UserManager where username ='" + user + "' and psw = '" + psw + "';";
            DataSet rs = Dao.query(sql);
            if (rs == null)
            {
                MessageBox.Show("账户或密码错误！");
                return;
            }
            else
            {
                this.Visible = false;
                MainFrame main = new MainFrame();
                main.par = this;
                main.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
