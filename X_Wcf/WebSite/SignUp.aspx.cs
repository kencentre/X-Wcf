using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace X_Wcf.WebSite
{
    public partial class SignUp : System.Web.UI.Page
    {
        E_BLL.Signup manage = new E_BLL.Signup();
        E_Model.Signup model = new E_Model.Signup();
        DataSet ds = new DataSet();
        DataSet dv = new DataSet();
        E_BLL.School mSchool = new E_BLL.School();
        E_BLL.Brand mBrand = new E_BLL.Brand();
        E_BLL.SignupBrand mSignupBrand = new E_BLL.SignupBrand();
        E_Model.SignupBrand SignupBrandModel = new E_Model.SignupBrand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                bind();
            }
        }

        private void bind()
        {
            ds = mSchool.GetList(" status = '1'");
            ddlSchool.DataSource = ds.Tables[0].DefaultView;
            ddlSchool.DataTextField = "SCHOOLNAME";
            ddlSchool.DataValueField = "ID";
            ddlSchool.DataBind();


            dv = mBrand.GetList(" status = '1'");
            ddlBrand.DataSource = dv.Tables[0].DefaultView;
            ddlBrand.DataTextField = "BRANDNAME";
            ddlBrand.DataValueField = "ID";
            ddlBrand.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("姓名不能为空");
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                Alert.Show("联系电话不能为空");
                return;
            }

            if (txtQQ.Text.Trim() == "")
            {
                Alert.Show("联系QQ不能为空");
                return;
            }
            if (txtEMail.Text.Trim() == "")
            {
                Alert.Show("电子邮箱不能为空");
                return;
            }
            model.ID = Guid.NewGuid().ToString();
            model.USERNAME = txtName.Text;
            model.QQ = txtQQ.Text;
            model.ADRESS = txtAdress.Text;
            model.STATUS = "0";
            model.PHONE = txtPhone.Text;
            model.CREATEDATE = DateTime.Now;
            model.SCHOOLID = ddlSchool.SelectedValue;
            model.DESCRIPTION = txtDescription.Text;
            model.EMAIL = txtEMail.Text;
            bool rs = manage.Add(model);
            if (rs != false)
            {
                ///写入品牌信息
                foreach (FineUI.ListItem DutyItem in ddlBrand.SelectedItemArray)
                {
                    SignupBrandModel.SIGNUOID = model.ID;
                    SignupBrandModel.BRANDID = DutyItem.Value;
                    mSignupBrand.Add(SignupBrandModel);
                }
                Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("提交失败");
            }
        }
    }
}