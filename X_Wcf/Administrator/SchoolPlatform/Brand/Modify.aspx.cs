using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.SchoolPlatform.Brand
{
    public partial class Modify : BasePage
    {
        E_BLL.Brand manage = new E_BLL.Brand();
        E_Model.Brand model = new E_Model.Brand();
        public string htmlMessage = "";
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
            txtName.Text = model.BRANDNAME;
            txtEName.Text = model.BRANDENAME;
            txtSlogan.Text = model.SLOGAN;
            //model.STATUS = "0";
            lblPUrl.Text = model.SHOWPICTURE;
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
                string url = @"uploads/brand/" + pictureName() + fileSuffix;
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
            if (txtEName.Text.Trim() == "")
            {
                Alert.Show("英文名称不能为空");
                return;
            }
            if (txtSlogan.Text.Trim() == "")
            {
                Alert.Show("标语不能为空");
                return;
            }

            model.ID = Request["ID"].ToString();
            model.BRANDNAME = txtName.Text;
            model.BRANDENAME = txtEName.Text;
            model.SLOGAN = txtSlogan.Text;
            model.STATUS = "0";
            model.SHOWPICTURE = lblPUrl.Text;
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