using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.WebSitePlatform.Template
{
    public partial class Modify : BasePage
    {
        public string htmlMessage = "";
        E_BLL.Template manage = new E_BLL.Template();
        E_Model.Template model = new E_Model.Template();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());

            txtName.Text = model.TEMPLATENAME;
            lblPUrl.Text = model.TEMPLATEURL;
            htmlMessage = model.DESCRIPTION;
        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return pName;
        }

        protected void txtPicture_FileSelected(object sender, EventArgs e)
        {
            List<string> fileType = new List<string> { "html" };
            string fileSuffix = Path.GetExtension(txtPicture.PostedFile.FileName);
            if (txtPicture.HasFile)
            {
                string fileName = txtPicture.ShortFileName;

                if (!ValidateFileType(fileName, fileType))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                string url = @"~/Template/" + pictureName() + fileSuffix;
                lblPUrl.Text = url;
                txtPicture.SaveAs(Server.MapPath(url));
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("名称不能为空");
                return;
            }
            if (lblPUrl.Text.Trim() == "")
            {
                Alert.Show("请上传模版");
                return;
            }

            model.ID = Request["ID"].ToString();
            model.TEMPLATENAME = txtName.Text;
            model.STATUS = "0";
            model.TEMPLATEURL = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = Request.Form["Editor1"];
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