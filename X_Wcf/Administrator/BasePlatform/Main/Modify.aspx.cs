using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Main
{
    public partial class Modify : BasePage
    {
        E_Model.Main model = new E_Model.Main();
        E_BLL.Main manage = new E_BLL.Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/MainChoose.aspx", "选择上级菜单");

                txtIcon.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtIcon.ClientID, txtIconValue.ClientID) + windowSourceCode.GetShowReference("../../tools/IconChoose.aspx", "选择菜单图标");

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();

                Bind();
            }
        }


        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtMainName.Text = model.MAINNAME;
            txtIcon.Text = model.MAINICON;
            txtIconValue.Text = model.MAINICON;
            txtParent.Text = model.PARENTID;
            txtMainUrl.Text = model.MAINURL;
            txtDescription.Text = model.DESCRIPTION;
            txtMainList.Text = model.SORTLIST.ToString();
            if (model.PARENTID != null)
            {
                model = new E_Model.Main();
                txtParentID.Text = manage.GetModel(txtParent.Text).MAINNAME;
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMainName.Text.Trim() == "")
            {
                Alert.ShowInTop("菜单名称不能为空");
                return;
            }
            if (txtIconValue.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择菜单图标");
                return;
            }
            if (txtParent.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择上级菜单");
                return;
            }
            if (txtMainUrl.Text.Trim() == "")
            {
                Alert.ShowInTop("菜单地址不能为空");
                return;
            }
            if (txtMainList.Text.Trim() == "")
            {
                Alert.ShowInTop("菜单排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtMainList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.MAINNAME = txtMainName.Text;
            model.MAINICON = txtIconValue.Text;
            model.PARENTID = txtParent.Text;
            model.MAINURL = txtMainUrl.Text;
            model.DESCRIPTION = txtDescription.Text;
            model.SORTLIST = decimal.Parse(txtMainList.Text);
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