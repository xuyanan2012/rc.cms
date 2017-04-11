using RC.EduCloud.Core;
using RC.EduCloud.Basic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RC.EduCloud.Model;

namespace RC.EduCloud.Test
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBUtility utility = new DBUtility();

            ZhuanYeFenLei entity = new ZhuanYeFenLei() { MC = "1" };
            entity.MC = "2";

            DBUtility.Add(ref entity);
        }
    }
}