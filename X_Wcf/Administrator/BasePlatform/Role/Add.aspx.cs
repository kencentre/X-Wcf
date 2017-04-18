using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Role
{
    public partial class Add : BasePage
    {
        E_Model.Role model = new E_Model.Role();
        E_BLL.Role manage = new E_BLL.Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
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
                Alert.ShowInTop("部门排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtRoleList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Guid.NewGuid().ToString();
            model.ROLENAME = txtRoleName.Text;
            model.ROLECODE = txtRoleCode.Text;
            model.PARENTID = "";
            model.SORTLIST = decimal.Parse(txtRoleList.Text);
            model.STATUS = 0;
            model.DESCRIPTION = txtDescription.Text;
            model.CREATEDATE = DateTime.Now;
            model.CREATEUSER = Session["AccountID"].ToString();
            model.ROLETYPE = ddlRoleNameType.SelectedItem.Value.ToString();
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

        protected void txtRoleName_Blur(object sender, EventArgs e)
        {
            txtRoleCode.Text = E_Common.PinYinConverter.GetFirst(txtRoleName.Text);
        }
    }
}