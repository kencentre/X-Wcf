using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Dictionary
{
    public partial class Add : BasePage
    {
        E_Model.Dictionary model = new E_Model.Dictionary();
        E_BLL.Dictionary manage = new E_BLL.Dictionary();
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/DictionaryChoose.aspx", "选择上级字典");

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDictName.Text.Trim() == "")
            {
                Alert.ShowInTop("字典名称不能为空");
                return;
            }
            if (txtDictCode.Text.Trim() == "")
            {
                Alert.ShowInTop("字典数值不能为空");
                return;
            }
            if (txtParentID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择上级字典");
                return;
            }
            if (txtDictList.Text.Trim() == "")
            {
                Alert.ShowInTop("排序不能为空");
                return;
            }
            if (E_Common.FormValidate.IsNumber(txtDictList.Text.Trim()) == false)
            {
                Alert.Show("请对输入正确的数字");
                return;
            }
            model.ID = Guid.NewGuid().ToString();
            model.DICTIONARYNAME = txtDictName.Text;
            model.DICTIONARYVALUE = txtDictCode.Text;
            model.PARENTID = txtParent.Text;
            model.SORTLIST = decimal.Parse(txtDictList.Text);
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