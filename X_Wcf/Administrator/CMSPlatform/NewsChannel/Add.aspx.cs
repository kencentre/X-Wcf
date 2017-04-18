using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.CMSPlatform.NewsChannel
{
    public partial class Add : BasePage
    {
        E_BLL.NewsChannel manage = new E_BLL.NewsChannel();
        E_Model.NewsChannel model = new E_Model.NewsChannel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/NewsChannelChoose.aspx", "选择上级菜单");
                                
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtChannelName.Text.Trim() == "")
            {
                Alert.ShowInTop("栏目名称不能为空");
                return;
            }
            if (txtChannelCode.Text.Trim() == "")
            {
                Alert.ShowInTop("栏目编码不能为空");
                return;
            }
            if (txtParentID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择上级菜单");
                return;
            }
            if (txtMainList.Text.Trim() == "")
            {
                Alert.ShowInTop("排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtMainList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Guid.NewGuid().ToString();
            model.CHANNELNAME = txtChannelName.Text;
            model.CHANNELCODE = txtChannelCode.Text;
            model.PARENTID = txtParent.Text;
            model.SORTLIST = decimal.Parse(txtMainList.Text);

            if (cblStatus.Checked == true)
            {
                model.STATUS = "1";
            }
            else
            {
                model.STATUS = "0";
            }
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