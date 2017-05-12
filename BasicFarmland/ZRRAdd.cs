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
    public partial class ZRRAdd : Form
    {

        string zrrbh = "";
        string zrrmc = "";
        public FarmInfo pt = null;
        public ZRRAdd()
        {
            InitializeComponent();
        }

        private void ZRRAdd_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            zrrbh = dataGridView1.Rows[row].Cells[1].Value.ToString();
            zrrmc = dataGridView1.Rows[row].Cells[2].Value.ToString();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pt.textBox9.Text = zrrbh;
            pt.textBox10.Text = zrrmc;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
