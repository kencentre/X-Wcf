using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Common
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString().Trim().Length == 0)
            {
                Response.Redirect("login.html");
            }
            base.OnInit(e);
        }
    }
}
