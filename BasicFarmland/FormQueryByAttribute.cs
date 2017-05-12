using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class FormQueryByAttribute : Form
    {
        public FormQueryByAttribute()
        {
            InitializeComponent();
        }

        public IMap currentMap;
        private IFeatureLayer currentFeatureLayer;
        private string currentFieldName;
        private IActiveView acview;

        private void button19_Click(object sender, EventArgs e)
        {
            textBoxWhere.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFields.Items.Clear();
            listBoxValues.Items.Clear();

            IField field;   //设置临时变量存储使用IField接口的对象

            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < compositeLayer.Count; j++)
                    {
                        //判断图层的名称是否与comboBoxLayerName控件中选择的图层名称相同
                        if (compositeLayer.get_Layer(j).Name == comboBox1.SelectedItem.ToString())
                        {
                            //如果相同则设置为整个窗体所使用的IFeatureLayer接口对象
                            currentFeatureLayer = compositeLayer.get_Layer(j) as IFeatureLayer;
                            break;
                        }
                    }
                }
                else
                {
                    //判断图层的名称是否与comboBoxLayerName中选择的图层名称相同
                    if (currentMap.get_Layer(i).Name == comboBox1.SelectedItem.ToString())
                    {
                        //如果相同则设置为整个窗体所使用的IFeatureLayer接口对象
                        currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                        break;
                    }
                }
            }
        }

        private void FormQueryByAttribute_Load(object sender, EventArgs e)
        {
            try
            {
                //将当前图层列表清空
                comboBox1.Items.Clear();

                string layerName;   //设置临时变量存储图层名称

                //对Map中的每个图层进行判断并加载名称
                for (int i = 0; i < currentMap.LayerCount; i++)
                {
                    //如果该图层为图层组类型，则分别对所包含的每个图层进行操作
                    if (currentMap.get_Layer(i) is GroupLayer)
                    {
                        //使用ICompositeLayer接口进行遍历操作
                        ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                        for (int j = 0; j < compositeLayer.Count; j++)
                        {
                            //将图层的名称添加到comboBoxLayerName控件中
                            layerName = compositeLayer.get_Layer(j).Name;
                            comboBox1.Items.Add(layerName);
                        }
                    }
                    //如果图层不是图层组类型，则直接添加名称
                    else
                    {
                        layerName = currentMap.get_Layer(i).Name;
                        comboBox1.Items.Add(layerName);
                    }
                }
                //将comboBoxLayerName控件的默认选项设置为第一个图层的名称
                comboBox1.SelectedIndex = 0;
                //将comboBoxSelectMethod控件的默认选项设置为第一种选择方式
                comboBox2.SelectedIndex = 0;
            }
            catch { }
        }

        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxValues.Items.Clear();
            //将buttonGetUniqeValue按钮控件置为可用状态
            if (buttonGetUniqeValue.Enabled == false)
                buttonGetUniqeValue.Enabled = true;

            //设置整个窗体可用的字段名称
            string str = listBoxFields.SelectedItem.ToString();
            //使用string类中的方法将字段名称中的两个"字符去掉
            //str = str.Substring(1);
            //str = str.Substring(0, str.Length - 1);
            currentFieldName = str;
        }

        private void listBoxFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxWhere.Text += listBoxFields.SelectedItem.ToString();
        }

        private void buttonGetUniqeValue_Click(object sender, EventArgs e)
        {
            try
            {
                //使用FeatureClass对象的IDataset接口来获取dataset和workspace的信息
                IDataset dataset = (IDataset)currentFeatureLayer.FeatureClass;
                //使用IQueryDef接口的对象来定义和查询属性信息。通过IWorkspace接口的CreateQueryDef()方法创建该对象。
                IQueryDef queryDef = ((IFeatureWorkspace)dataset.Workspace).CreateQueryDef();
                //设置所需查询的表格名称为dataset的名称
                queryDef.Tables = dataset.Name;
                //设置查询的字段名称。可以联合使用SQL语言的关键字，如查询唯一值可以使用DISTINCT关键字。
                queryDef.SubFields = "DISTINCT (" + currentFieldName + ")";
                //执行查询并返回ICursor接口的对象来访问整个结果的集合
                ICursor cursor = queryDef.Evaluate();
                //使用IField接口获取当前所需要使用的字段的信息
                IFields fields = currentFeatureLayer.FeatureClass.Fields;
                IField field = fields.get_Field(fields.FindField(currentFieldName));

                //对整个结果集合进行遍历，从而添加所有的唯一值
                //使用IRow接口来操作结果集合。首先定位到第一个查询结果。
                IRow row = cursor.NextRow();
                //如果查询结果非空，则一直进行添加操作
                while (row != null)
                {
                    //对String类型的字段，唯一值的前后添加'和'，以符合SQL语句的要求
                    if (field.Type == esriFieldType.esriFieldTypeString)
                    {
                        listBoxValues.Items.Add("\'" + row.get_Value(0).ToString() + "\'");
                    }
                    else
                    {
                        listBoxValues.Items.Add(row.get_Value(0).ToString());
                    }
                    //继续执行下一个结果的添加
                    row = cursor.NextRow();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + buttonEqual.Text + " ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

                //执行属性查询操作，并关闭窗体
                SelectFeaturesByAttribute();
                //新创建属性查询窗体
                FormSelection formSelection = new FormSelection();
                //将当前主窗体中MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
                formSelection.CurrentMap = currentMap;
                //显示属性查询窗体
               formSelection.Show();
            }
            catch { }
            this.Close();
        }
        private void SelectFeaturesByAttribute()
        {
            //使用FeatureLayer对象的IFeatureSelection接口来执行查询操作。这里有一个接口转换操作。
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;
            //新建IQueryFilter接口的对象来进行where语句的定义
            IQueryFilter queryFilter = new QueryFilterClass();
            //设置where语句内容
            queryFilter.WhereClause = textBoxWhere.Text;
            //通过接口转换使用Map对象的IActiveView接口来部分刷新地图窗口，从而高亮显示查询的结果
            IActiveView activeView = currentMap as IActiveView;
            acview = activeView;
            //根据查询选择方式的不同，得到不同的选择集
            switch (comboBox2.SelectedIndex)
            {
                //在新建选择集的情况下
                case 0:
                    //首先使用IMap接口的ClearSelection()方法清空地图选择集
                    currentMap.ClearSelection();
                    //根据定义的where语句使用IFeatureSelection接口的SelectFeatures方法选择要素，并将其添加到选择集中
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
                //添加到当前选择集的情况
                case 1:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                //从当前选择集中删除的情况
                case 2:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultXOR, false);
                    break;
                //从当前选择集中选择的情况
                case 3:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAnd, false);
                    break;
                //默认为新建选择集的情况
                default:
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
            }

            //部分刷新操作，只刷新地理选择集的内容
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBoxWhere.Text += " " + button13.Text + " ";
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void listBoxValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxWhere.Text += listBoxValues.SelectedItem.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
