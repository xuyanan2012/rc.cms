using RC.EduCloud.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Core
{
    internal class ReflectionHelper
    {
        public static IEnumerable<ColumnAttribute> GetColumns<T>(out Type type, T t) where T : new()
        {
            type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();

            IEnumerable<ColumnAttribute> columns = propertyInfos.Select(x => new ColumnAttribute(x.Name, x.GetValue(t)) { PrimaryKey = x.GetCustomAttribute<ColumnAttribute>().PrimaryKey, DbGenerated = x.GetCustomAttribute<ColumnAttribute>().DbGenerated });
            //Column column;

            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    columns.Add(new Column() { Name = propertyInfo.Name, Value = propertyInfo.GetValue(t) });
            //}
            return columns;
        }
    }
}
