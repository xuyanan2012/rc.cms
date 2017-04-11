using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Basic
{
    public abstract class EntityBase
    {
        private Dictionary<string, dynamic> _ = new Dictionary<string, dynamic>();

        protected dynamic this[string name]
        {
            get
            {
                if (this._.ContainsKey(name))
                {
                    return this._[name];
                }
                else
                {
                    Type type = this.GetType().GetProperty(name).PropertyType;
                    if (type == typeof(Int32) || type == typeof(Int16) || type == typeof(Int64))
                    {
                        return 0;
                    }
                    else if (type == typeof(bool))
                    {
                        return false;
                    }
                    else if (type == typeof(Guid)) {
                        return Guid.Empty;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            set
            {
                if ((this._.ContainsKey(name) && this._[name] != value) || (!this._.ContainsKey(name)))
                {
                    this._[name] = value;
                }
            }
        }

        public object GetValue(string name)
        {
            return this._[name];
            //PropertyInfo p = this.GetType().GetProperty(name);
            //return p.GetValue(this);
        }

        public void SetValue(string name, object value)
        {
            this._[name] = value;
            //if ((this._.ContainsKey(name) && this._[name] != value) || (!this._.ContainsKey(name)))
            //{
            //    this._[name] = value;
            //}
            //PropertyInfo p = this.GetType().GetProperty(name);
            //if (p.PropertyType.IsGenericType)
            //{
            //    p.SetValue(this, Convert.ChangeType(value, p.PropertyType.GetGenericArguments()[0]), null);
            //}
            //else
            //{
            //    p.SetValue(this, Convert.ChangeType(value, p.PropertyType), null);
            //}
        }


        //public event PropertyChangedEventHandler PropertyChanged;


        //private IList<string> changedColumns = new List<string>();

        //protected virtual void SendPropertyChanged(String propertyName)
        //{
        //    //if ((this.PropertyChanged != null))
        //    //{
        //    //    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        //    //PropertyInfo p = this.GetType().GetProperty(propertyName);

        //    //p.GetCustomAttribute<ColumnAttribute>().IsEditColumn = true;

        //    changedColumns.Add(propertyName);
        //    //}
        //}

        //public void a() {
        //    this.
        //}
    }
}
