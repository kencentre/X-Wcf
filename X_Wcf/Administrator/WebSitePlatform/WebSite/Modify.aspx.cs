using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.WebSitePlatform.WebSite
{
    public partial class Modify : BasePage
    {
        E_BLL.WebSite manage = new E_BLL.WebSite();
        E_Model.WebSite model = new E_Model.WebSite();
        E_Model.Template tModel = new E_Model.Template();
        E_BLL.Template mTemplate = new E_BLL.Template();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/WebSiteChoose.aspx", "选择上级", 550, 450);
                txtTepmlateID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtTepmlateID.ClientID, txtTepmlate.ClientID) + windowSourceCode.GetShowReference("../../tools/TemplateChoose.aspx", "选择模版", 1024, 500);
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = new E_Model.WebSite();
            model = manage.GetModel(Request["ID"].ToString());
            txtChannelName.Text = model.WEBNAME;
            txtParent.Text = model.PARENTID;
            txtDescription.Text = model.DESCRIPTION;
            
            if (model.STATUS == "0")
            {
                cblStatus.Checked = false;
            }
            if (model.STATUS == "1")
            {
                cblStatus.Checked = true;
            }
           
            txtParent.Text = model.PARENTID;
            if (!string.IsNullOrEmpty(model.TEMPLATEID))
            {
                txtTepmlateID.Text = mTemplate.GetModel(model.TEMPLATEID).TEMPLATENAME;
            }
            txtTepmlate.Text = model.TEMPLATEID;
            if (model.PARENTID != "00000000-0000-0000-0000-000000000000")
            {
                model = new E_Model.WebSite();
                txtParentID.Text = manage.GetModel(txtParent.Text).WEBNAME;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtChannelName.Text.Trim() == "")
            {
                Alert.ShowInTop("栏目名称不能为空");
                return;
            }
            if (txtParentID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择上级菜单");
                return;
            }
            if (txtTepmlateID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择模版");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.WEBNAME = txtChannelName.Text;
            model.TEMPLATEID = txtTepmlate.Text;
            model.PARENTID = txtParent.Text;

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