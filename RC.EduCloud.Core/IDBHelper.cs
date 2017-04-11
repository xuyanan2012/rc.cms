using RC.EduCloud.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Core
{


    internal interface IDBHelper
    {
        string ConnectionString
        {
            get; set;
        }

        void Insert<T>(T t) where T : EntityBase, new();
        void Insert<T>(ref T t) where T : EntityBase, new();

        void Update<T>(T t) where T : EntityBase, new();
    }
}
