using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Main
{
    public partial class Add : BasePage
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
            if (txtParentID.Text.Trim() == "")
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
            model.ID = Guid.NewGuid().ToString();
            model.MAINNAME = txtMainName.Text;
            model.MAINICON = txtIconValue.Text;
            model.PARENTID = txtParent.Text;
            model.MAINURL = txtMainUrl.Text;
            model.SORTLIST = decimal.Parse(txtMainList.Text);
            model.STATUS = 0;
            model.DESCRIPTION = txtDescription.Text;
            model.CREATEDATE = DateTime.Now;
            model.CREATEUSER = Session["AccountID"].ToString();
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