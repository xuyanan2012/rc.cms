using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Basic
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ColumnAttribute : Attribute
    {
        public ColumnAttribute()
        {

        }

        public ColumnAttribute(string name, object value)
        {
            this._name = name;
            this._value = value;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private object _value;
        public object Value
        {
            get { return _value; }
        }

        #region public SqlDbType SqlDbType 数据类型
        /// <summary>
        /// 数据类型
        /// </summary>
        public SqlDbType SqlDbType
        {
            get;
            set;
        }
        #endregion

        #region public bool Nullable 允许为空
        /// <summary>
        /// 允许为空
        /// </summary>
        public bool Nullable
        {
            get;
            set;
        } = false;
        #endregion

        #region public int MaxLength 最大长度
        /// <summary>
        /// 最大长度
        /// </summary>
        public int Size
        {
            get;
            set;
        }
        #endregion

        #region public byte Precision 精度
        /// <summary>
        /// 精度
        /// </summary>
        public byte Precision
        {
            get;
            set;
        }
        #endregion

        #region public byte Scale 刻度
        /// <summary>
        /// 刻度
        /// </summary>
        public byte Scale
        {
            get;
            set;
        }
        #endregion

        #region public bool PrimaryKey 主键
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool PrimaryKey
        {
            get;
            set;
        } = false;
        #endregion

        #region public bool DbGenerated 自动生成
        /// <summary>
        /// 是否自动生成
        /// </summary>
        public bool DbGenerated
        {
            get;
            set;
        } = false;
        #endregion

        #region public bool IsStateField 是否状态字段
        /// <summary>
        /// 是否状态字段
        /// </summary>
        public bool IsStateField
        {
            get;
            set;
        }
        #endregion

        #region public object StateValid 状态有效值
        /// <summary>
        /// 状态有效值
        /// </summary>
        public object StateValid
        {
            get;
            set;
        }
        #endregion

        #region public object StateInValid 状态无效值
        /// <summary>
        /// 状态无效值
        /// </summary>
        public object StateInValid
        {
            get;
            set;
        }
        #endregion

        public bool IsEditColumn
        {
            get;
            set;
        } = false;

        //private string _name = string.Empty;

        //public string GetName()
        //{
        //    return this._name;
        //}

        //public void SetName(string name)
        //{
        //    this._name = name;
        //}

        //private object _value = null;

        //public object GetValue()
        //{
        //    return this._value;
        //}

        //public void SetValue(object value)
        //{
        //    this._value = value;
        //}

        #region public new Type GetType() 获取当前实例的Type
        /// <summary>
        /// 获取当前实例的Type
        /// </summary>
        /// <returns></returns>
        public new Type GetType()
        {

            switch (this.SqlDbType)
            {
                case SqlDbType.BigInt:
                    return typeof(Int64);
                case SqlDbType.Binary:
                    return typeof(Byte[]);
                case SqlDbType.Bit:
                    return typeof(Boolean);
                case SqlDbType.Char:
                    return typeof(String);
                case SqlDbType.Date:
                    return typeof(DateTime);
                case SqlDbType.DateTime:
                    return typeof(DateTime);
                case SqlDbType.DateTime2:
                    return typeof(DateTime);
                case SqlDbType.DateTimeOffset:
                    return typeof(DateTimeOffset);
                case SqlDbType.Decimal:
                    return typeof(Decimal);
                case SqlDbType.Float:
                    return typeof(Double);
                case SqlDbType.Int:
                    return typeof(Int32);
                case SqlDbType.Money:
                    return typeof(Decimal);
                case SqlDbType.NChar:
                    return typeof(String);
                case SqlDbType.NText:
                    return typeof(String);
                case SqlDbType.NVarChar:
                    return typeof(String);
                case SqlDbType.SmallDateTime:
                    return typeof(DateTime);
                case SqlDbType.SmallInt:
                    return typeof(Int16);
                case SqlDbType.SmallMoney:
                    return typeof(Decimal);
                case SqlDbType.Text:
                    return typeof(String);
                case SqlDbType.Time:
                    return typeof(TimeSpan);
                case SqlDbType.Timestamp:
                    return typeof(Byte[]);
                case SqlDbType.TinyInt:
                    return typeof(Byte);
                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);
                case SqlDbType.VarBinary:
                    return typeof(Byte[]);
                case SqlDbType.VarChar:
                    return typeof(String);
                default:
                    throw new Exception("不支持的数据类型！");
            }
        }
        #endregion
    }
}
