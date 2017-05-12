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
    public partial class UserDelete : Form
    {
        public UserDelete()
        {
            InitializeComponent();
        }

        private void UserDelete_Load(object sender, EventArgs e)
        {
            String sqlstr;
            sqlstr = "SELECT * FROM USERManager";
            DataSet rs = Dao.query(sqlstr);
            for (int intI = 0; intI < rs.Tables[0].Rows.Count; intI++)
            {
                listBox1.Items.Add(rs.Tables[0].Rows[intI]["USERNAME"]);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            String strSQL = "DELETE * FROM USERManager WHERE USERNAME='" + listBox1.SelectedItem.ToString() + "'";
            int rs = Dao.dml(strSQL);
            if (rs > 0)
            {
                MessageBox.Show("删除用户" + listBox1.SelectedItem.ToString() + "成功!");
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            this.Close();
        }
    }
}
