using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Notice
{
    public partial class Add : BasePage
    {
        E_Model.Notice model = new E_Model.Notice();
        E_BLL.Notice manage = new E_BLL.Notice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("公告标题不能为空");
                return;
            }
            if (txtCode.Text.Trim() == "")
            {
                Alert.Show("关键字不能为空");
                return;
            }

            model.ID = Guid.NewGuid().ToString();
            model.TITLE = txtName.Text;
            model.KEYWORD = txtCode.Text;

            model.STATUS = "0";
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = txtDescription.Text;
            model.CREATEUSER = Session["AccountID"].ToString();
            model.ANNEXGROUP = "";

            bool rs = manage.Add(model);
            if (rs != false)
            {
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }
    }
}