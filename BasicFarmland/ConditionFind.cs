using BasicFarmland.DataBaseManager;
using ESRI.ArcGIS.Carto;
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
    public partial class ConditionFind : Form
    {
        public ConditionFind()
        {
            InitializeComponent();
        }
        public IMap map = null;
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "" && comboBox4.Text.Trim() == "" && textBox5.Text.Trim() == "" && textBox6.Text.Trim() == "" && comboBox1.Text.Trim() == "" && comboBox2.Text.Trim() == "" && comboBox3.Text.Trim() == "" && textBox10.Text.Trim() == ""&& textBox1.Text.Trim() == "")
            {
                MessageBox.Show("全为空，无法查询!");
                return;
            }

            string sql = "select * from JBNT where ZRRBH <> '0'";
              if (textBox2.Text.Trim() != "")
              {
                  sql = sql + " and TBBH ='" + textBox2.Text.Trim() + "'";
              }
              if (textBox3.Text.Trim() != "")
              {
                  sql = sql + " and DLMC ='" + textBox3.Text.Trim() + "'";
              }
              if (comboBox4.Text.Trim() != "")
              {
                  sql = sql + " and QSXZ ='" + comboBox4.Text.Trim() + "'";
              }
              if (textBox5.Text.Trim() != "")
              {
                  sql = sql + " and QSDWMC ='" + textBox5.Text.Trim() + "'";
              }
              if (textBox6.Text.Trim() != "")
              {
                  sql = sql + " and ZLDWMC ='" + textBox6.Text.Trim() + "'";
              }
              if (comboBox1.Text.Trim() != "")
              {
                  sql = sql + " and JBNTLX ='" + comboBox1.Text.Trim() + "'";
              }
              if (comboBox2.Text.Trim() != "")
              {
                  sql = sql + " and ZLDJDM ='" + comboBox2.Text.Trim() + "'";
              }
              if (comboBox3.Text.Trim() != "")
              {
                  sql = sql + " and PDJB ='" + comboBox3.Text.Trim() + "'";
              }
              if (textBox10.Text.Trim() != "")
              {
                  sql = sql + " and ZRRMC ='" + textBox10.Text.Trim() + "'";
              }
              if (textBox1.Text.Trim() != "")
              {
                  sql = sql + " and JBNTBH ='" + textBox1.Text.Trim() + "'";
              }
              
              DataSet dataset = null;
              dataset = Dao.query(sql);
              FarmInfo fi = new FarmInfo(dataset);
              fi.currentMap = map;
              fi.ShowDialog();
             // this.Close();
        }
    }
}
