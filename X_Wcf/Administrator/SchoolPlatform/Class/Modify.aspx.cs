using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.SchoolPlatform.Class
{
    public partial class Modify : BasePage
    {
        E_BLL.Class manage = new E_BLL.Class();
        E_Model.Class model = new E_Model.Class();
        public string htmlMessage = "";
        DataSet ds = new DataSet();
        E_BLL.Brand mBrand = new E_BLL.Brand();
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
            model = manage.GetModel(Request["ID"].ToString());
            txtName.Text = model.CLASSNAME;
            lblPUrl.Text = model.CONTENTPICTURE;
            
            htmlMessage = model.CONTENTBODY;

            ds = mBrand.GetList(" status = '1'");
            ddlBrand.DataSource = ds.Tables[0].DefaultView;
            ddlBrand.DataTextField = "BRANDNAME";
            ddlBrand.DataValueField = "ID";
            ddlBrand.DataBind();
            ddlBrand.SelectedValue = model.BRANDID;
        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return pName;
        }

        protected void txtPicture_FileSelected(object sender, EventArgs e)
        {
            List<string> fileType = new List<string> { "jpg", "bmp", "gif", "jpeg", "png" };
            string fileSuffix = Path.GetExtension(txtPicture.PostedFile.FileName);
            if (txtPicture.HasFile)
            {
                string fileName = txtPicture.ShortFileName;

                if (!ValidateFileType(fileName, fileType))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                string url = @"uploads/class/" + pictureName() + fileSuffix;
                lblPUrl.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("名称不能为空");
                return;
            }

            model.ID = Request["ID"].ToString();
            model.CLASSNAME = txtName.Text;
            model.BRANDID = ddlBrand.SelectedValue;
            model.STATUS = "0";
            model.CONTENTPICTURE = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.CONTENTBODY = Request.Form["Editor1"];
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