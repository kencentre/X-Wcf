using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Dept
{
    public partial class Modify : System.Web.UI.Page
    {
        E_Model.Dept model = new E_Model.Dept();
        E_BLL.Dept manage = new E_BLL.Dept();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/DeptChoose.aspx", "选择上级部门");

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtDeptName.Text = model.DEPTNAME;
            txtParent.Text = model.PARENTID;
            txtDeptCode.Text = model.DEPTCODE;
            txtDescription.Text = model.DESCRIPTION;
            txtDeptList.Text = model.SORTLIST.ToString();
            if (model.PARENTID != null)
            {
                model = new E_Model.Dept();
                txtParentID.Text = manage.GetModel(txtParent.Text).DEPTNAME;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDeptName.Text.Trim() == "")
            {
                Alert.ShowInTop("部门名称不能为空");
                return;
            }
            if (txtDeptCode.Text.Trim() == "")
            {
                Alert.ShowInTop("部门组织机构码不能为空");
                return;
            }
            if (txtParentID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择上级部门");
                return;
            }
            if (txtDeptList.Text.Trim() == "")
            {
                Alert.ShowInTop("部门排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtDeptList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.DEPTNAME = txtDeptName.Text;
            model.DEPTCODE = txtDeptCode.Text;
            model.PARENTID = txtParent.Text;
            if (Request["ID"].ToString() == txtParent.Text)
            {
                Alert.ShowInTop("请选择正确的上级部门");
                return;
            }
            model.SORTLIST = decimal.Parse(txtDeptList.Text);
            model.DESCRIPTION = txtDescription.Text;
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
    }
}