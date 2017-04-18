using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Account
{
    public partial class UpdatePassword : BasePage
    {
        E_BLL.Account manage = new E_BLL.Account();
        E_Model.Account model = new E_Model.Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            model = manage.GetModel(Session["AccountID"].ToString());
            if (txtPwd.Text.Trim() == "")
            {
                Alert.ShowInTop("密码不能为空");
                return;
            }
            if (E_Common.DEScrypt.Base64Encrypt(txtPwd.Text.Trim()) != model.PASSWORDS)
            {
                Alert.ShowInTop("密码错误");
                return;
            }
            if (txtNewPwd.Text.Trim() == "")
            {
                Alert.ShowInTop("新密码不能为空");
                return;
            }
            if (txtRePwd.Text.Trim() != txtNewPwd.Text.Trim())
            {
                Alert.ShowInTop("两次密码不一致");
                return;
            }
            model = new E_Model.Account();
            model.ID = Session["AccountID"].ToString();
            model.PASSWORDS = E_Common.DEScrypt.Base64Encrypt(txtNewPwd.Text.Trim());
            bool rs = manage.UpdatePwd(model);
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