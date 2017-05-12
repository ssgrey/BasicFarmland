using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFarmland.DataBaseManager
{
    class DBManager
    {
        private DBManager()
        {

        }
        private static DBManager db = new DBManager();

        public OleDbConnection getConnection()
        {
            OleDbConnection conn = null;
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"D:\我的文档\毕设项目\数据库\BasicFarmLand.mdb");
            return conn;
        }

        public static DBManager getDBNanager()
        {
            return db;
        }
    }
}
