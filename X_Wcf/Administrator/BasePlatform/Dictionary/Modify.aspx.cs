using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.BasePlatform.Dictionary
{
    public partial class Modify : BasePage
    {
        E_Model.Dictionary model = new E_Model.Dictionary();
        E_BLL.Dictionary manage = new E_BLL.Dictionary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtParentID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtParentID.ClientID, txtParent.ClientID) + windowSourceCode.GetShowReference("../../tools/DictionaryChoose.aspx", "选择上级字典");

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtDictName.Text = model.DICTIONARYNAME;
            txtParent.Text = model.PARENTID;
            txtDictCode.Text = model.DICTIONARYVALUE;
            txtDescription.Text = model.DESCRIPTION;
            txtDictList.Text = model.SORTLIST.ToString();
            if (model.PARENTID != null)
            {
                model = new E_Model.Dictionary();
                txtParentID.Text = manage.GetModel(txtParent.Text).DICTIONARYNAME;
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
            if (txtParent.Text.Trim() == Request["ID"].ToString())
            {
                Alert.ShowInTop("请选择正确的上级字典");
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
            model.ID = Request["ID"].ToString();
            model.DICTIONARYNAME = txtDictName.Text;
            model.DICTIONARYVALUE = txtDictCode.Text;
            model.PARENTID = txtParent.Text;
            model.SORTLIST = decimal.Parse(txtDictList.Text);
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