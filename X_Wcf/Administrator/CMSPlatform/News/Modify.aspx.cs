using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace X_Wcf.Administrator.CMSPlatform.News
{
    public partial class Modify : BasePage
    {
        public string htmlMessage = "";
        E_BLL.News manage = new E_BLL.News();
        E_Model.News model = new E_Model.News();
        E_BLL.NewsChannel mChannel = new E_BLL.NewsChannel();
        E_Model.NewsChannel channelModel = new E_Model.NewsChannel();
        DataSet ds = new DataSet();
        DataSet dv = new DataSet();
        E_BLL.School mSchool = new E_BLL.School();
        E_BLL.Brand mBrand = new E_BLL.Brand();
        E_BLL.BrandStudent mBrandStudent = new E_BLL.BrandStudent();
        E_Model.BrandStudent brandStudentModel = new E_Model.BrandStudent();
        
        E_BLL.Class mClass = new E_BLL.Class();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                bind();
                txtChannel.OnClientTriggerClick = windowSourceCode.GetSaveStateReference(txtChannel.ClientID, txtChannelID.ClientID) + windowSourceCode.GetShowReference("../../tools/ChooseChannel.aspx", "选择新闻栏目");
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
            txtChannelID.Text = model.CHANNEL;

            channelModel = mChannel.GetModel(model.CHANNEL);
            if (channelModel != null)
            {
                txtChannel.Text = channelModel.CHANNELNAME;
            }

            txtKeywords.Text = model.KEYWORDS;
            txtName.Text = model.TITLE;
            lblPUrl.Text = model.IMAGESHOW;
            lblVideo.Text = model.VIDEOSHOW;
            htmlMessage = model.NEWSTEXT;
            ds = mSchool.GetList(" status = '1'");
            ddlSchool.DataSource = ds.Tables[0].DefaultView;
            ddlSchool.DataTextField = "SCHOOLNAME";
            ddlSchool.DataValueField = "ID";
            ddlSchool.DataBind();
            ddlSchool.SelectedValue = model.SCHOOLID;

            dv = mBrand.GetList(" status = '1'");
            ddlBrand.DataSource = dv.Tables[0].DefaultView;
            ddlBrand.DataTextField = "BRANDNAME";
            ddlBrand.DataValueField = "ID";
            ddlBrand.DataBind();
            ddlBrand.SelectedValue = model.BRANDID;
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
                Alert.Show("新闻标题不能为空");
                return;
            }
            if (txtChannel.Text.Trim() == "")
            {
                Alert.Show("新闻栏目不能为空");
                return;
            }

            model.ID = Request["ID"].ToString();
            model.TITLE = txtName.Text;
            model.KEYWORDS = txtKeywords.Text;
            //model.NEWSURL = "";
            model.STATUS = "0";
            model.IMAGESHOW = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.NEWSTEXT = Request.Form["Editor1"];
            model.CREATEUSER = Session["AccountID"].ToString();
            model.BRANDID = ddlBrand.SelectedValue;
            model.SCHOOLID = ddlSchool.SelectedValue;
            model.CHANNEL = txtChannelID.Text;
            string url = CreateHtml(txtChannel.Text, txtName.Text, model.CREATEDATE.ToShortDateString(), Request.Form["Editor1"], ddlBrand.SelectedValue, lblPUrl.Text, lblVideo.Text);
            model.VIDEOSHOW = lblVideo.Text;
            model.NEWSURL = url;
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

        private string CreateHtml(string newschannel, string title, string createdate, string body, string brand, string image, string video)
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
            if (input.Contains("$Image$"))
            {
                if (string.IsNullOrEmpty(image))
                {
                    input = input.Replace("$Image$", "");
                }
                else
                {
                    input = input.Replace("$Image$", "<div style='text-align:center'><img src = '../" + image + "'  width ='50%' height='50%'/></div>");
                }
            }
            if (input.Contains("$Video$"))
            {
                if (string.IsNullOrEmpty(video))
                {
                    input = input.Replace("$Video$", "");
                }
                else
                {
                    input = input.Replace("$Video$", "<div style='text-align:center'><video height='90% ' width='100%' controls='controls' autoplay='autoplay'><source  src = '../" + video + "' type='video/mp4'></video></div>");
                }
            }
            if (input.Contains("$body$"))
            {
                input = input.Replace("$body$", body);
            }
            if (input.Contains("$Brand_class$"))
            {
                string x = "";
                ds = new DataSet();
                ds = mClass.GetList(" brandid = '" + brand + "' ");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    x += "<ul>";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        x += "<li><a href='javascript:; '><img src='../" + ds.Tables[0].Rows[i]["CONTENTPICTURE"].ToString() + "' width='270' height='300' /></a></li>";
                        x += "";
                        x += "";
                        x += "";
                    }
                    x += "</ul>";
                }

                input = input.Replace("$Brand_class$", x);
            }

            
            string url = "News/" + pictureName() + ".html";
            StreamWriter sw = new StreamWriter(Server.MapPath("~/News/" + pictureName() + ".html"), false);
            sw.Write(input);
            sw.Close();

            return url;
        }

        protected void txtVideo_FileSelected(object sender, EventArgs e)
        {
            List<string> fileType = new List<string> { "flv", "mp4", "avi", "rm", "rmvb" };
            string fileSuffix = Path.GetExtension(txtPicture.PostedFile.FileName);
            if (txtPicture.HasFile)
            {
                string fileName = txtPicture.ShortFileName;

                if (!ValidateFileType(fileName, fileType))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                string url = @"uploads/video/" + pictureName() + fileSuffix;
                lblVideo.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }
    }
}