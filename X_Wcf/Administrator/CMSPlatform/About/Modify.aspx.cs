using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace X_Wcf.Administrator.CMSPlatform.About
{
    public partial class Modify : BasePage
    {
        public string message = "";
        E_BLL.About manage = new E_BLL.About();
        E_Model.About model = new E_Model.About();
        DataSet ds = new DataSet();
        E_BLL.Dictionary md = new E_BLL.Dictionary();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                bind();
                //txtChannel.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtChannel.ClientID, txtChannelID.ClientID) + windowSourceCode.GetShowReference("../../tools/ChooseChannel.aspx", "选择新闻栏目");
            }
        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return pName;
        }

        private void bind()
        {
            model = manage.GetModel(Request["ID"].ToString());
            txtName.Text = model.TITLE;
            message = model.DESCRIPTION;
            lblPUrl.Text = model.IMAGESHOW;


            ds = md.GetList(" PARENTID = 'c320740e-12a9-4603-b2be-f49b5ab194db' ");

            ddlChannel.DataTextField = "DICTIONARYNAME";
            ddlChannel.DataValueField = "id";
            ddlChannel.DataSource = ds;
            ddlChannel.DataBind();
            ddlChannel.SelectedValue = model.CHANNEL;
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
                string url = @"uploads/news/" + pictureName() + fileSuffix;
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

            model.ID = Request["ID"].ToString();
            model.TITLE = txtName.Text;

            model.STATUS = "0";
            model.IMAGESHOW = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = Request.Form["Editor1"];
            model.CREATEUSER = Session["AccountID"].ToString();
            model.CHANNEL = ddlChannel.SelectedValue;


            string url = CreateHtml(ddlChannel.Text, txtName.Text, model.CREATEDATE.ToShortDateString(), Request.Form["Editor1"]);

            model.PATHURL = url;
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

        private string CreateHtml(string newschannel, string title, string createdate, string body)
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/Template/news.html"), System.Text.Encoding.Default);
            String input = sr.ReadToEnd();
            sr.Close();
            if (input.Contains("$newsChannel$"))
            {
                input = input.Replace("$newsChannel$", newschannel);
            }
            if (input.Contains("$title$"))
            {
                input = input.Replace("$title$", title);
            }
            if (input.Contains("$createdate$"))
            {
                input = input.Replace("$createdate$", createdate);
            }
            if (input.Contains("$body$"))
            {
                input = input.Replace("$body$", body);
            }
            if (input.Contains("$Brand_class$"))
            {

                input = input.Replace("$Brand_class$", "");
            }
            string url = "News/" + pictureName() + ".html";
            StreamWriter sw = new StreamWriter(Server.MapPath("~/News/" + pictureName() + ".html"), false);
            sw.Write(input);
            sw.Close();

            return url;
        }
    }
}