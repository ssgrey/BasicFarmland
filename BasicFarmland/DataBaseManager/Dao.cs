using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFarmland.DataBaseManager
{
    class Dao
    {
        private Dao()
        {
        }

        private static DBManager dbm = DBManager.getDBNanager();
        private static OleDbConnection conn = null;
        private static OleDbCommand cmd = null;
        private static OleDbDataAdapter oda = null;
        private static DataSet dataset = null;
        //数据库查询
        public static DataSet query(String str)
        {
            conn = dbm.getConnection();
            conn.Open();
            oda = new OleDbDataAdapter(str, conn);
            dataset = new DataSet();
            oda.Fill(dataset);
            conn.Close();
            return dataset;
        }
        //数据库操作
        public static int dml(String str)
        {
            conn = dbm.getConnection();
            conn.Open();
            cmd = new OleDbCommand(str, conn);
            int rsnum = cmd.ExecuteNonQuery();
            conn.Close();
            return rsnum;
        }

    }
}
