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
    public partial class PersonInfo : Form
    {
        public PersonInfo()
        {
            InitializeComponent();
        }

        private void PersonInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            initialData();
        }
        private void initialData()
        {
            
            DataSet dataset = null;
            dataset = Dao.query("select*from ZRRXX");
            dataGridView1.DataSource = dataset.Tables[0];
            dataGridView1.Columns[1].HeaderText = "责任人编号";
            dataGridView1.Columns[2].HeaderText = "责任人名称";
            dataGridView1.Columns[3].HeaderText = "证件类型";
            dataGridView1.Columns[4].HeaderText = "证件号码";
            dataGridView1.Columns[5].HeaderText = "联系电话";
            dataGridView1.Columns[6].HeaderText = "居住地址";
            dataGridView1.Columns[7].HeaderText = "上级单位名称";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearContent();
            DataSet dataset = null;
            dataset = Dao.query("select max(ZRRBH)from ZRRXX");
            string rs = dataset.Tables[0].Rows[0][0] as string;
            int a = Convert.ToInt32(rs);
            int c = a + 1;
            textBox1.Text = c.ToString();
            button4.Enabled = true;
            button4.Text = "确认添加";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "确认添加")
            {
                string sql = "insert into ZRRXX(ZRRBH,ZRRMC,ZJLX,ZJHM,LXDH,JZDZ,SJDWMC) values('" +
                    textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" +
                        textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','"
                         + textBox7.Text.Trim() + "')";
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && comboBox1.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
                {
                    Dao.dml(sql);
                    MessageBox.Show("添加成功");
                    button4.Enabled = false;
                    initialData();

                }
                else
                {
                    MessageBox.Show("填写信息不完整");
                }
            }
            if (button4.Text == "确认修改")
            {
                string sql2 = "update ZRRXX set ZRRMC='" + textBox2.Text.Trim() + "',ZJLX='" + comboBox1.Text.Trim() + "',ZJHM='" + textBox4.Text.Trim() + "',LXDH='" + textBox5.Text.Trim() + 
                    "',JZDZ='" + textBox6.Text.Trim() + "',SJDWMC='" + textBox7.Text.Trim() + "' where ZRRBH='" + textBox1.Text.Trim()+"'";
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && comboBox1.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
                {
                    Dao.dml(sql2);
                    MessageBox.Show("修改成功！");
                    button4.Enabled = false;
                    initialData();
                }
                else
                {
                    MessageBox.Show("填写信息不完整");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            int row = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[row].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[row].Cells[7].Value.ToString();
        }
        private void clearContent()
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from ZRRXX where ZRRBH = '" + textBox1.Text + "'";
            Dao.dml(sql);
            MessageBox.Show("删除成功！");
            clearContent();
            textBox1.Text = "";
            initialData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Text = "确认修改";
            button4.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
