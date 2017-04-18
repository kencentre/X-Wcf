using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace X_Wcf.Administrator.UserDesk
{
    public partial class Default : BasePage
    {
        DataSet ds = new DataSet();
        DataSet dv = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnConfig.OnClientClick = windowSourceCode.GetShowReference("../Tools/ConfigTable.aspx", "设置");

                InitPanel();
            }
        }


        private void InitPanel()
        {
            if (ViewState["colWidth"] == null)
            {
                ViewState["colWidth"] = 2;
            }
            BindDesk(p1,int.Parse(ViewState["colWidth"].ToString()),Session["AccountID"].ToString());
        }

        protected void windowSourceCode_Close(object sender, WindowCloseEventArgs e)
        {
            InitPanel();
            PageContext.RegisterStartupScript("history.go(0)");
        }
    }
}