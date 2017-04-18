using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace X_Wcf.Administrator.CMSPlatform.Link
{
    public partial class Modify : BasePage
    {
        E_BLL.Link manage = new E_BLL.Link();
        E_Model.Link model = new E_Model.Link();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                Bind();
            }
        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return pName;
        }

        private void Bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtDescription.Text = model.DESCRIPTION;
            txtName.Text = model.LINKENAME;
            txtUrl.Text = model.LINKURL;
            lblPUrl.Text = model.LINKIMAGE;
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
                string url = @"uploads/link/" + pictureName() + fileSuffix;
                lblPUrl.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("标题不能为空");
                return;
            }
            if (txtUrl.Text.Trim() == "")
            {
                Alert.Show("地址不能为空");
                return;
            }
            model.ID = Request["ID"].ToString();
            model.LINKENAME = txtName.Text;
            model.LINKURL = txtUrl.Text;
            model.STATUS = "0";
            model.LINKIMAGE = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = txtDescription.Text;



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