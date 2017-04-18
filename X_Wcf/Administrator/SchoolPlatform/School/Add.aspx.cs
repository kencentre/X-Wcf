using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.SchoolPlatform.School
{
    public partial class Add : BasePage
    {
        E_BLL.School manage = new E_BLL.School();
        E_Model.School model = new E_Model.School();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString()+ DateTime.Now.Month.ToString()+ DateTime.Now.Day.ToString()+ DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString()+ DateTime.Now.Millisecond.ToString();
            return pName;
        }

        protected void txtPicture_FileSelected(object sender, EventArgs e)
        {
            List<string> fileType = new List<string> { "jpg", "bmp", "gif", "jpeg", "png" };
            string fileSuffix = Path.GetExtension(txtPicture.PostedFile.FileName);
            if (txtPicture.HasFile)
            {
                string fileName = txtPicture.ShortFileName;

                if (!ValidateFileType(fileName,fileType))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                string url = @"uploads/school/" + pictureName() + fileSuffix;
                lblPUrl.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }

        protected void txtImage_FileSelected(object sender, EventArgs e)
        {
            List<string> fileType = new List<string> { "jpg", "bmp", "gif", "jpeg", "png" };
            string fileSuffix = Path.GetExtension(txtImage.PostedFile.FileName);
            if (txtImage.HasFile)
            {
                string fileName = txtImage.ShortFileName;

                if (!ValidateFileType(fileName, fileType))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                string url = @"uploads/school/" + pictureName() + fileSuffix;
                lblIURL.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSchoolName.Text.Trim() == "")
            {
                Alert.Show("学校名称不能为空");
                return;
            }
            if (txtEName.Text.Trim() == "")
            {
                Alert.Show("学校英文名称不能为空");
                return;
            }
            if (txtADress.Text.Trim() == "")
            {
                Alert.Show("学校地址不能为空");
                return;
            }
            
            model.ID = Guid.NewGuid().ToString();
            model.SCHOOLNAME = txtSchoolName.Text;
            model.SCHOOLENAME = txtEName.Text;
            model.SCHOOLADRESS  = txtADress.Text;
            model.STATUS = "0";
            model.SCHOOLIMAGE = lblPUrl.Text;
            model.SHOWPICTURE = lblIURL.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = Request.Form["Editor1"];
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