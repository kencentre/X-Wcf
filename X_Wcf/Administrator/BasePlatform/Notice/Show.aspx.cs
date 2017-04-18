using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Notice
{
    public partial class Show : BasePage
    {
        E_Model.Notice model = new E_Model.Notice();
        E_BLL.Notice manage = new E_BLL.Notice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            if (model != null)
            {
                txtTitle.Text = model.TITLE;
                txtCode.Text = "关键字：" + model.KEYWORD + "      发布时间：" + model.CREATEDATE.ToShortDateString();
                txtDescription.Text = model.DESCRIPTION;
            }
        }
    }
}