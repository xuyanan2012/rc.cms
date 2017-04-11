using RC.EduCloud.Basic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Core
{
    public class DBUtility
    {
        private static DataBaseType dataBaseType
        {
            get; set;
        }

        private static string connectionString
        {
            get; set;
        }

        private static IDBHelper dbHelper;

        static DBUtility()
        {
            ConnectionConfigSection connectionConfigSection = ConfigurationManager.GetSection("rc.core") as ConnectionConfigSection;
            dataBaseType = connectionConfigSection.DataBase.Type;
            connectionString = connectionConfigSection.DataBase.ConnectionString;
            switch (dataBaseType)
            {
                case DataBaseType.MySql:
                    dbHelper = new MySqlHelper(connectionString);
                    break;
                default:
                    break;
            }
        }

        public static void Add<T>(T t) where T : EntityBase, new()
        {
            dbHelper.Insert<T>(t);
        }

        public static void Add<T>(ref T t) where T : EntityBase, new()
        {
            dbHelper.Insert<T>(ref t);
        }
    }
}
