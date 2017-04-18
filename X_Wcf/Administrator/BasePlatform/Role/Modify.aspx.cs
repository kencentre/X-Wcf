using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Role
{
    public partial class Modify : System.Web.UI.Page
    {
        E_Model.Role model = new E_Model.Role();
        E_BLL.Role manage = new E_BLL.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            if (model != null)
            {
                txtRoleName.Text = model.ROLENAME;
                txtRoleCode.Text = model.ROLECODE;
                txtRoleList.Text = model.SORTLIST.ToString();
                txtDescription.Text = model.DESCRIPTION;
                ddlRoleNameType.SelectedValue = model.ROLETYPE;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text.Trim() == "")
            {
                Alert.ShowInTop("角色名称不能为空");
                return;
            }
            if (txtRoleCode.Text.Trim() == "")
            {
                Alert.ShowInTop("角色代码不能为空");
                return;
            }
            if (txtRoleList.Text.Trim() == "")
            {
                Alert.ShowInTop("角色排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtRoleList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.ROLENAME = txtRoleName.Text;
            model.ROLECODE = txtRoleCode.Text;
            model.PARENTID = "";
            model.SORTLIST = decimal.Parse(txtRoleList.Text);
            model.DESCRIPTION = txtDescription.Text;
            model.ROLETYPE = ddlRoleNameType.SelectedItem.Value.ToString();
            bool rs = manage.Update(model);
            if (rs != false)
            {
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }

        protected void txtRoleName_Blur(object sender, EventArgs e)
        {
            txtRoleCode.Text = E_Common.PinYinConverter.GetFirst(txtRoleName.Text);
        }
    }
}