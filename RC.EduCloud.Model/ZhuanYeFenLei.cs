using RC.EduCloud.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.EduCloud.Model
{
    public class ZhuanYeFenLei : EntityBase
    {

        [Column(PrimaryKey = true, DbGenerated = true)]
        public int ID
        {
            get
            {
                
                return this["ID"];
            }
            set
            {
                this["ID"] = value;
            }
        }

        [Column(Size = 60, Nullable = true)]
        public string MC
        {
            get
            {
                return this["MC"];
            }
            set
            {
                this["MC"] = value;
            }
        }

        [Column(Nullable = true)]
        public Boolean JLSFYX //{ get; set; }
        {
            get
            {
                return this["JLSFYX"];
            }
            set
            {
                this["JLSFYX"] = value;
            }
        }


    }
}
