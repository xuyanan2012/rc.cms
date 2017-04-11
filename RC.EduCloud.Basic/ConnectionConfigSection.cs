using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Basic
{
    public class ConnectionConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("sqlserver")]
        public SqlServerElement SqlServer
        {
            get
            {
                return this["sqlserver"] as SqlServerElement;
            }
            set
            {
                this["sqlserver"] = value;
            }
        }

        //[ConfigurationProperty("mysql")]
        //public DataBaseElements DataBase
        //{
        //    get
        //    {
        //        return this["mysql"] as DataBaseElements;
        //    }
        //    set
        //    {
        //        this["mysql"] = value;
        //    }
        //}

        [ConfigurationProperty("database")]
        public DataBaseElement DataBase
        {
            get
            {
                return this["database"] as DataBaseElement;
            }
            set
            {
                this["database"] = value;
            }
        }
    }

    #region SqlServerElements&SqlServerElement

    public class SqlServerElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("connection")]
        public string Connection
        {
            get
            {
                return this["connection"] as string;
            }
            set
            {
                this["connection"] = value;
            }
        }


        [ConfigurationProperty("isdefault")]
        public Nullable<bool> IsDefault
        {
            get
            {
                return this["isdefault"] as Nullable<bool>;
            }
            set
            {
                this["isdefault"] = value;
            }
        }
    }

    public class SqlServerElements : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SqlServerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SqlServerElement)element).Name;
        }

        public new SqlServerElement this[string name]
        {
            get
            {
                return BaseGet(name) as SqlServerElement;
            }
        }

        public object[] AllKeys
        {
            get
            {
                return BaseGetAllKeys();
            }
        }
    }
    #endregion




    #region DataBaseElements&DataBaseElement

    public class DataBaseElement : ConfigurationElement
    {
        [ConfigurationProperty("type")]
        public DataBaseType Type
        {
            get
            {
                return (DataBaseType)Enum.Parse(typeof(DataBaseType), this["type"].ToString());
            }
            set
            {
                this["type"] = value;
            }
        }

        [ConfigurationProperty("connectionstring")]
        public string ConnectionString
        {
            get
            {
                return this["connectionstring"] as string;
            }
            set
            {
                this["connectionstring"] = value;
            }
        }
    }

    public class DataBaseElements : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DataBaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DataBaseElement)element).Type;
        }

        public new DataBaseElement this[string name]
        {
            get
            {
                return BaseGet(name) as DataBaseElement;
            }
        }

        public object[] AllKeys
        {
            get
            {
                return BaseGetAllKeys();
            }
        }
    }
    #endregion

    public enum DataBaseType
    {
        SqlServer,
        MySql
    }
}
