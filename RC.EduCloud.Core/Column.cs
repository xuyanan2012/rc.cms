using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Core
{
    internal class Column
    {
        public Column() { }
        public Column(string name,object Value) { }

        public string Name { get; set; }

        public object Value { get; set; }
    }
}
