using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Account
{
    public partial class ChangeUserInfo : BasePage
    {
        DataSet ds = new DataSet();
        E_BLL.Account manage = new E_BLL.Account();
        E_Model.Account model = new E_Model.Account();
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
            model = manage.GetModel(Session["AccountID"].ToString());
            txtAdress.Text = model.ADRESS;
            txtDescription.Text = model.DESCRIPTION;
            txtIDCard.Text = model.EMAIL;
            txtMail.Text = model.EMAIL;
            txtPhone.Text = model.PHONE;
            txtTrueName.Text = model.TRUENAME;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTrueName.Text.Trim() == "")
            {
                Alert.ShowInTop("真实姓名不能为空");
                return;
            }
            if (txtIDCard.Text.Trim() != "")
            {
                if (E_Common.IDCardValid.CheckIDCard(txtIDCard.Text.Trim()) == false)
                {
                    Alert.ShowInTop("请输入正确的身份证号码");
                    return;
                }
            }
            if (txtPhone.Text.Trim() == "")
            {
                Alert.ShowInTop("联系电话不能为空");
                return;
            }
            if (E_Common.FormValidate.IsPhone(txtPhone.Text.Trim()) == false)
            {
                Alert.ShowInTop("请输入正确的电话号码");
                return;
            }
            if (txtMail.Text.Trim() != "")
            {
                if (E_Common.FormValidate.IsEmail(txtMail.Text.Trim()) == false)
                {
                    Alert.ShowInTop("请输入正确的电子邮箱");
                    return;
                }
            }
            model.ID = Session["AccountID"].ToString();
            model.TRUENAME = txtTrueName.Text;
            model.PHONE = txtPhone.Text;
            model.IDCARD = txtIDCard.Text;
            model.ADRESS = txtAdress.Text;
            model.DESCRIPTION = txtDescription.Text;
            bool rs = manage.UpdateUserInfo(model);
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