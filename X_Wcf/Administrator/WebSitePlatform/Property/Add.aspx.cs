using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.WebSitePlatform.Property
{
    public partial class Add : BasePage
    {
        E_BLL.Property manage = new E_BLL.Property();
        E_Model.Property model = new E_Model.Property();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.ShowInTop("模块名称不能为空");
                return;
            }
            
            model.ID = Guid.NewGuid().ToString();
            model.PROPERTYNAME = txtName.Text;
            model.PROPERTYTYPE = ddlType.SelectedValue;
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