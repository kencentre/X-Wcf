using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Desk
{
    public partial class Modify : System.Web.UI.Page
    {
        E_Model.Desk model = new E_Model.Desk();
        E_BLL.Desk manage = new E_BLL.Desk();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        private void bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            if (model != null)
            {
                txtName.Text = model.DESKNAME;
                txtCode.Text = model.DESKCODE;
                txtURL.Text = model.DESKURL;
                txtDescription.Text = model.DESCRIPTION;
                txtList.Text = model.SORTLIST.ToString();
                txtWidth.Text = model.DESKWIDTH;
                txtHeight.Text = model.DESKHEIGHT;
                rblEnableClose.SelectedValue = model.ENABLECLOSE;
                rblEnableCol.SelectedValue = model.ENABLECOL;
                rblEnableMax.SelectedValue = model.ENABLEMAX;
                rblEnableMin.SelectedValue = model.ENABLEMIN;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("模块名称不能为空");
                return;
            }
            if (txtCode.Text.Trim() == "")
            {
                Alert.Show("模块代码不能为空");
                return;
            }
            if (txtURL.Text.Trim() == "")
            {
                Alert.Show("请输入模块地址");
                return;
            }
            if (txtList.Text.Trim() == "")
            {
                Alert.ShowInTop("排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.DESKNAME = txtName.Text;
            model.DESKCODE = txtCode.Text;
            model.DESKURL = txtURL.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = txtDescription.Text;
            model.CREATEUSER = Session["AccountID"].ToString();
            model.DESKTYPE = "0";
            model.SORTLIST = int.Parse(txtList.Text);
            model.DESKWIDTH = txtWidth.Text;
            model.DESKHEIGHT = txtHeight.Text;
            model.ENABLECLOSE = rblEnableClose.SelectedValue;
            model.ENABLECOL = rblEnableCol.SelectedValue;
            model.ENABLEMAX = rblEnableMax.SelectedValue;
            model.ENABLEMIN = rblEnableMin.SelectedValue;
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


        protected void txtDutyName_Blur(object sender, EventArgs e)
        {
            txtCode.Text = E_Common.PinYinConverter.GetFirst(txtName.Text);
        }
    }
}