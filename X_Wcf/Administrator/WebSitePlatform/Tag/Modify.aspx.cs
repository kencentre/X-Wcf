using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace X_Wcf.Administrator.WebSitePlatform.Tag
{
    public partial class Modify : BasePage
    {
        DataSet ds = new DataSet();
        E_BLL.Tag manage = new E_BLL.Tag();
        E_Model.Tag model = new E_Model.Tag();
        E_BLL.Property mProperty = new E_BLL.Property();
        E_BLL.TagProperty mTagProperty = new E_BLL.TagProperty();
        E_Model.TagProperty tagPropertyModel = new E_Model.TagProperty();
        E_BLL.Brock mBrock = new E_BLL.Brock();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBrockID.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtBrockID.ClientID, txtBrock.ClientID) + windowSourceCode.GetShowReference("../../tools/BrockChoose.aspx", "选择模块", 1024, 550);

                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();

                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());


            txtName.Text = model.TAGNAEM;
            txtDescription.Text = model.DESCRIPTION;
            txtBrock.Text = model.BROCKID;
            if (!string.IsNullOrEmpty(model.BROCKID))
            {
                txtBrockID.Text = mBrock.GetModel(model.BROCKID).BROCKNAME;
            }
            ds = mProperty.GetList(" ");
            cblProperty.DataTextField = "PROPERTYNAME";
            cblProperty.DataValueField = "ID";
            cblProperty.DataSource = ds;
            cblProperty.DataBind();

            DataSet source = new DataSet();
            source = mTagProperty.GetList(" tagid = '" + Request["ID"].ToString() + "'");
            
            if (source.Tables[0].Rows.Count > 0)
            {
                foreach (FineUI.RadioItem DutyItem in cblProperty.Items)
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        if (source.Tables[0].Rows[i]["PropertyID"].ToString() == DutyItem.Value)
                        {
                            DutyItem.Selected = true;
                        }
                    }
                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.ShowInTop("标签名称不能为空");
                return;
            }
            if (txtBrockID.Text.Trim() == "")
            {
                Alert.ShowInTop("请选择所属模块");
                return;
            }

            model.ID = Request["ID"].ToString();
            model.TAGNAEM = txtName.Text;
            model.BROCKID = txtBrock.Text;

            model.STATUS = "0";
            model.TAGTYPE = "0";
            model.DESCRIPTION = txtDescription.Text;
            model.CREATEDATE = DateTime.Now;
            model.CREATEUSER = Session["AccountID"].ToString();
            bool rs = manage.Update(model);
            if (rs != false)
            {
                //if (cblProperty.SelectedItemArray.Length > 0)
                //{
                //删除TagProperty表
                mTagProperty.Delete(Request["ID"].ToString());
                    //循环写入TagProperty表
                    //foreach (FineUI.CheckItem DutyItem in cblProperty.SelectedItemArray)
                    //{
                        tagPropertyModel.TAGID = model.ID;
                        tagPropertyModel.PROPERTYID = cblProperty.SelectedValue;
                        mTagProperty.Add(tagPropertyModel);
                    //}
                //}
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }
    }
}