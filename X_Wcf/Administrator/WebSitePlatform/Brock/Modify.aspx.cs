using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.WebSitePlatform.Brock
{
    public partial class Modify : BasePage
    {
        E_BLL.Brock manage = new E_BLL.Brock();
        E_Model.Brock model = new E_Model.Brock();
        E_BLL.Template mTemplate = new E_BLL.Template();
        E_Model.Template tempModel = new E_Model.Template();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTepmlateID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtTepmlateID.ClientID, txtTepmlate.ClientID) + windowSourceCode.GetShowReference("../../tools/TemplateChoose.aspx", "选择模版", 1024, 500);

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtName.Text = model.BROCKNAME;
            txtCode.Text = model.BROCKCODE;
            txtList.Text = model.SORTLIST.ToString();
            txtTepmlate.Text = model.TEMPLATEID;
            txtDescription.Text = model.DESCRIPTION;
            tempModel = mTemplate.GetModel(model.TEMPLATEID);
            if (tempModel != null)
            {
                txtTepmlateID.Text = tempModel.TEMPLATENAME;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.ShowInTop("模块名称不能为空");
                return;
            }
            if (txtCode.Text.Trim() == "")
            {
                Alert.ShowInTop("模块编码不能为空");
                return;
            }
            if (txtTepmlateID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择模版");
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
            model.BROCKNAME = txtName.Text;
            model.TEMPLATEID = txtTepmlate.Text;
            model.BROCKCODE = txtCode.Text;
            model.STATUS = "0";
            model.SORTLIST = decimal.Parse(txtList.Text);
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