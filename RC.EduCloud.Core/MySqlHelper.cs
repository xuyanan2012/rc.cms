using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RC.EduCloud.Basic;

namespace RC.EduCloud.Core
{
    internal class MySqlHelper : IDBHelper
    {
        public MySqlHelper() { }
        public MySqlHelper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString
        {
            get; set;
        }

        private int ExecuteNonQuery(string sqlText, MySqlParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            MySqlCommand command = new MySqlCommand();
            int result = 0;
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = sqlText;
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters);
                result = command.ExecuteNonQuery();
                command.Dispose();
            }
            return result;
        }

        private object ExecuteScalar(string sqlText, MySqlParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            MySqlCommand command = new MySqlCommand();
            object result = null;
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = sqlText;
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters);
                result = command.ExecuteScalar();
                command.Dispose();
            }
            return result;
        }

        public void Insert<T>(T t) where T : EntityBase, new()
        {
            Type type;

            IEnumerable<ColumnAttribute> columnsNotDbGenerated = ReflectionHelper.GetColumns<T>(out type, t).Where(x => x.DbGenerated == false);

            //PropertyInfo[] propertyInfos = type.GetProperties();

            string sqlText = $"INSERT INTO {type.Name} ({string.Join(",", columnsNotDbGenerated.Select(x => x.Name))}) VALUES (@{string.Join(",@", columnsNotDbGenerated.Select(x => x.Name))})";
            MySqlParameter[] parameters = columnsNotDbGenerated.Select(x => new MySqlParameter() { ParameterName = $"@{x.Name}", Value = x.Value }).ToArray();

            ExecuteNonQuery(sqlText, parameters);


            //MySqlParameter[] parameters=new MySqlParameter[columns.le]
            //MySqlCommand command = new MySqlCommand();

            //using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            //{
            //    connection.Open();

            //    command.Connection = connection;
            //    command.CommandText = sqlText;
            //    command.CommandType = CommandType.Text;
            //    foreach (var column in columnsNotDbGenerated)
            //    {
            //        command.Parameters.Add(new MySqlParameter() { ParameterName = $"@{column.Name}", Value = column.Value });
            //    }
            //    //command.Parameters = columns.Select(x => new MySqlParameter() { ParameterName = x.Name, Value = x.Value });
            //    command.ExecuteNonQuery();
            //    command.Dispose();
            //}

            //MySqlConnection connection = new MySqlConnection("");


        }


        public void Insert<T>(ref T t) where T : EntityBase, new()
        {
            Type type;

            IEnumerable<ColumnAttribute> columns = ReflectionHelper.GetColumns<T>(out type, t);
            IEnumerable<ColumnAttribute> columnsDbGenerated = columns.Where(x => x.DbGenerated == true);
            IEnumerable<ColumnAttribute> columnsNotDbGenerated = columns.Where(x => x.DbGenerated == false);


            List<ColumnAttribute> columnsDbGenerated222 = columns.Where(x => x.IsEditColumn == true).ToList();

            //PropertyInfo[] propertyInfos = type.GetProperties();

            string sqlText = $"INSERT INTO {type.Name} ({string.Join(",", columnsNotDbGenerated.Select(x => x.Name))}) VALUES (@{string.Join(",@", columnsNotDbGenerated.Select(x => x.Name))});SELECT LAST_INSERT_ID();";
            MySqlParameter[] parameters = columnsNotDbGenerated.Select(x => new MySqlParameter() { ParameterName = $"@{x.Name}", Value = x.Value }).ToArray();

            object dbGeneratedValue = ExecuteScalar(sqlText, parameters);
            if (columnsDbGenerated.Count() == 1)
            {
                t.SetValue(columnsDbGenerated.FirstOrDefault().Name, dbGeneratedValue);
            }

            //MySqlParameter[] parameters=new MySqlParameter[columns.le]
            //MySqlCommand command = new MySqlCommand();

            //using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            //{
            //    connection.Open();

            //    command.Connection = connection;
            //    command.CommandText = sqlText;
            //    command.CommandType = CommandType.Text;
            //    foreach (var column in columnsNotDbGenerated)
            //    {
            //        command.Parameters.Add(new MySqlParameter() { ParameterName = $"@{column.Name}", Value = column.Value });
            //    }
            //    //command.Parameters = columns.Select(x => new MySqlParameter() { ParameterName = x.Name, Value = x.Value });
            //    command.ExecuteNonQuery();
            //    command.Dispose();
            //}

            //MySqlConnection connection = new MySqlConnection("");


        }

        public void Update<T>(T t) where T : EntityBase, new()
        {

        }
    }
}
