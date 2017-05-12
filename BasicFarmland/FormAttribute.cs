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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
namespace BasicFarmland
{
    public partial class FormAttribute : Form
    {
        public FormAttribute(IMapControl3 m)
        {
            InitializeComponent();
            mapControl = m;
        }
        private IMapControl3 mapControl;
        public DataTable attributeTable;
        ILayer m_Layer;
        RowAndCol[] pRowAndCol = new RowAndCol[10000];
        int count = 0; 

        #region 根据图层字段创建一个只含字段的空DataTable
        /// <summary>
        /// 根据图层字段创建一个只含字段的空DataTable
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
        {
            //创建一个DataTable表
            DataTable pDataTable = new DataTable(tableName);

            //取得ITable接口
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;
            //根据每个字段的属性建立DataColumn对象
            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                //新建一个DataColumn并设置其属性
                pDataColumn = new DataColumn(pField.Name);
                if (pField.Name == pTable.OIDFieldName)
                {
                    pDataColumn.Unique = true;//字段值是否唯一
                }
                //字段值是否允许为空
                pDataColumn.AllowDBNull = pField.IsNullable;
                //字段别名
                pDataColumn.Caption = pField.AliasName;
                //字段数据类型
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                //字段默认值
                pDataColumn.DefaultValue = pField.DefaultValue;

                //当字段为String类型是设置字段长度
                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                //字段添加到表中
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }
            return pDataTable;
        }

        //因为GeoDatabase的数据类型与.NET的数据类型不同，故要进行转换。转换函数如下：
        /// <summary>
        /// 将GeoDatabase字段类型转换成.Net相应的数据类型
        /// </summary>
        /// <param name="fieldType">字段类型</param>
        /// <returns></returns>
        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.String";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }
        #endregion

        #region 填充DataTable中的数据
        /// <summary> 
        /// 填充DataTable中的数据
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable CreateDataTable(ILayer pLayer, string tableName)
        {
            //创建空DataTable,并确定表头的名称
            DataTable pDataTable = CreateDataTableByLayer(pLayer, tableName);

            //取得图层类型,如果是shape字段,则表的数据里放该类型名称
            string shapeType = getShapeType(pLayer);

            //创建DataTable的行对象
            DataRow pDataRow = null;
            //从ILayer查询到ITable
            ITable pTable = pLayer as ITable;
            ICursor pCursor = pTable.Search(null, false);
            //取得ITable中的行信息
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                //新建DataTable的行对象
                pDataRow = pDataTable.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                    if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        pDataRow[i] = shapeType;
                    }
                    //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                    //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                    else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        pDataRow[i] = "Element";
                    }
                    else
                    {
                        pDataRow[i] = pRow.get_Value(i);
                    }
                }
                //添加DataRow到DataTable
                pDataTable.Rows.Add(pDataRow);
                pDataRow = null;
                n++;
                //为保证效率，一次只装载最多条记录
                if (n == 2000)
                {
                    pRow = null;
                }
                else
                {
                    pRow = pCursor.NextRow();
                }
            }

         /*   //开始链接外部数据
            DataSet MyDs = new DataSet();
            if (getOutData(tableName, "ID", ref MyDs) == true)
            {
                DataTable MyJionedTbl;
                MyJionedTbl = JionOutData(pDataTable, MyDs.Tables[0]);
                return MyJionedTbl;
            }
            else
            {
                return pDataTable;
            }*/
            return pDataTable;
        }


    /*    //进行外部链接
        private static DataTable JionOutData(DataTable InTable, DataTable OutTable)
        {
            DataTable JoinedTable;
            GISDemo.MegerTable MyMerger = new GISDemo.MegerTable();
            string[] keyFields = new string[1];
            string[] megerFields = new string[3];
            int i;
            keyFields[0] = "ID";

            for (i = 1; i < OutTable.Columns.Count; i++)
            {
                megerFields[i - 1] = OutTable.Columns[i].ColumnName;
            }
            JoinedTable = MyMerger.LeftJoinTabel(InTable, OutTable, keyFields, megerFields);

            return JoinedTable;
        }

        

        //寻找链接的外部数据
        //Join(flyr.Name, Application.StartupPath, "DBPoint.mdb", "ID"))
        private static bool getOutData(string strTblName, string JoinFieldName, ref DataSet ReturnDs)
        {
            ReturnDs = new DataSet();
            if (strTblName == "包头" && JoinFieldName == "ID")
            {
                string sqlstr;
                WinInrush.Class.Database MyDB = new WinInrush.Class.Database();
                DataSet MyDs = new DataSet();
                sqlstr = "SELECT * FROM " + strTblName + " ORDER BY " + JoinFieldName;

                ReturnDs = MyDB.GetDataFromDB(sqlstr);

                return true;
            }
            else
            {
                return false;
            }
        }
        */


        //上面的代码中涉及到一个获取图层类型的函数getShapeTape，此函数是通过ILayer判断图层类型的，代码如下：
        /// <summary>
        /// 获得图层的Shape类型
        /// </summary>
        /// <param name="pLayer">图层</param>
        /// <returns></returns>
        public static string getShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return "";
            }
        }
        #endregion

        #region 绑定DataTable到DataGridView
        ///<summary> 
        /// 绑定DataTable到DataGridView
        /// </summary>
        /// <param name="player"></param>
        public void CreateAttributeTable(ILayer player)
        {
            m_Layer = player;
            string tableName;
            tableName = getValidFeatureClassName(player.Name);
            attributeTable = CreateDataTable(player, tableName);

            //gridview的东西不允许用户进行修改
            attributeTable.DefaultView.AllowNew = false;

            //设置数据源
            this.dataGridView.DataSource = attributeTable;

            this.Text = "属性表[" + tableName + "] " + "记录数：" + attributeTable.Rows.Count.ToString();
        }

        //因为DataTable的表名不允许含有“.”，因此我们用“_”替换。函数如下：
        /// <summary>
        /// 替换数据表名中的点
        /// </summary>
        /// <param name="FCname"></param>
        /// <returns></returns>
        public static string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }
        #endregion

        private void editButton_Click(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = false;
            this.dataGridView.CurrentCell = this.dataGridView.Rows[this.dataGridView.Rows.Count - 2].Cells[0]; 
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = true;
            //ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
            IFeatureLayer pFLayer = m_Layer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFLayer.FeatureClass;
            ITable pTable;
            //pTable = pFeatureClass.CreateFeature().Table;//很重要的一种获取shp表格的一种方式           
            pTable = pFLayer as ITable;
            //将改变的记录值传给shp中的表  
            int i = 0;
            while (pRowAndCol[i].Column != 0 || pRowAndCol[i].Row != 0)
            {
                IRow pRow;
                pRow = pTable.GetRow(pRowAndCol[i].Row);
                pRow.set_Value(pRowAndCol[i].Column, pRowAndCol[i].Value);
                pRow.Store();
                i++;
            }
            count = 0;
            for (int j = 0; j < i; j++)
            {
                pRowAndCol[j].Row = 0;
                pRowAndCol[j].Column = 0;
                pRowAndCol[j].Value = null;
            }
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK);  
        }


        public struct RowAndCol
        {
            //字段  
            private int row;
            private int column;
            private string _value;

            //行属性  
            public int Row
            {
                get
                {
                    return row;
                }
                set
                {
                    row = value;
                }
            }
            //列属性  
            public int Column
            {
                get
                {
                    return column;
                }
                set
                {
                    column = value;
                }
            }
            //值属性  
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pRowAndCol[count].Row = dataGridView.CurrentCell.RowIndex;
            pRowAndCol[count].Column = dataGridView.CurrentCell.ColumnIndex;
            pRowAndCol[count].Value = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[dataGridView.CurrentCell.ColumnIndex].Value.ToString();
            count++;  
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (((MessageBox.Show("确定要删除吗", "警告", MessageBoxButtons.YesNo)) == DialogResult.Yes))
            {
                
                //ILayer pLayer = (ILayer)m_mapControl.CustomProperty;
                IFeatureLayer pFLayer = m_Layer as IFeatureLayer;
                ITable pTable = pFLayer as ITable;

                int row_num = dataGridView.SelectedRows.Count;
                for(int i = 0 ; i < row_num ; i++ )
                {
                    int row_index = dataGridView.SelectedRows[i].Index;
                    IRow pRow = pTable.GetRow(row_index);
                    pRow.Delete();
                }
                this.CreateAttributeTable(m_Layer);
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK);
                mapControl.ActiveView.Refresh();
                
            }  
        }  



    }
}
