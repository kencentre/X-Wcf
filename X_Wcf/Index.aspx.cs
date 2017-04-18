using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int a = 1 % 9%3;
                int b = 2 % 9%3;
                int c = 3 % 9 % 3;
                int d = 4 % 9 % 3;
                int f = 5 % 9 % 3;
                int g = 6 % 9 % 3;
                int h = 7 % 9 % 3;
                int i = 8 % 9 % 3;
                int j = 9 % 9 % 3;
                string html = a+"<br />"+ b + "<br />" + c + "<br />" + d + "<br />" + f + "<br />" + g + "<br />" + h + "<br />" + i + "<br />" +j;
                Response.Write("<script>alert('" + html + "')</script>");
            }


            
        }
    }
}