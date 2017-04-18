using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.UserDesk
{
    public partial class Notice : BasePage
    {
        DataSet source;
        E_Model.Notice model = new E_Model.Notice();
        E_BLL.Notice manage = new E_BLL.Notice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitGrid();

            }
        }
        
        private void InitGrid()
        {
            
            source = new DataSet();
            source = manage.GetTopList("",5);
            Grid1.DataSource = source;
            Grid1.DataBind();
        }



        protected void windowSourceCode_Close(object sender, EventArgs e)
        {
            InitGrid();
        }
    }
}