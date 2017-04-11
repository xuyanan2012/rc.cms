using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Core
{
    public interface IDBUtility
    {
        void Add<T>(T t) where T : new();
    }
}
