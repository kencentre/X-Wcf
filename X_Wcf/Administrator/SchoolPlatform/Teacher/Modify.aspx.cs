using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.SchoolPlatform.Teacher
{
    public partial class Modify : BasePage
    {
        E_BLL.Teacher manage = new E_BLL.Teacher();
        E_Model.Teacher model = new E_Model.Teacher();
        DataSet ds = new DataSet();
        E_BLL.School mSchool = new E_BLL.School();
        E_BLL.Brand mBrand = new E_BLL.Brand();
        E_BLL.BrandTeacher mBrandTeacher = new E_BLL.BrandTeacher();
        E_Model.BrandTeacher brandTeacherModel = new E_Model.BrandTeacher();
        E_BLL.SchoolTeacher mSchoolTeacher = new E_BLL.SchoolTeacher();
        E_Model.SchoolTeacher schoolTeacherModel = new E_Model.SchoolTeacher();
        public string htmlMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
                bind();
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
            txtName.Text = model.CHNNAME;
            txtEName.Text = model.ENGNAME;
            txtRank.Text = model.RANK;
            lblPUrl.Text = model.TPICTURE;
            htmlMessage = model.DESCRIPTION;
            ds = mSchool.GetList(" status = '1'");
            ddlSchool.DataSource = ds.Tables[0].DefaultView;
            ddlSchool.DataTextField = "SCHOOLNAME";
            ddlSchool.DataValueField = "ID";
            ddlSchool.DataBind();
            DataSet source = new DataSet();
            source = mSchoolTeacher.GetList(" TEACHERID = '" + Request["ID"].ToString() + "'");
            if (source.Tables[0].Rows.Count > 0)
            {
                foreach (FineUI.ListItem DutyItem in ddlSchool.Items)
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        if (source.Tables[0].Rows[i]["SCHOOLID"].ToString() == DutyItem.Value)
                        {
                            DutyItem.Selected = true;
                        }
                    }
                }
            }

            ds = new DataSet();
            ds = mBrand.GetList(" status = '1'");
            ddlBrand.DataSource = ds.Tables[0].DefaultView;
            ddlBrand.DataTextField = "BRANDNAME";
            ddlBrand.DataValueField = "ID";
            ddlBrand.DataBind();

            source = new DataSet();
            source = mBrandTeacher.GetList(" TEACHERID = '" + Request["ID"].ToString() + "'");
            if (source.Tables[0].Rows.Count > 0)
            {
                foreach (FineUI.ListItem DutyItem in ddlBrand.Items)
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        if (source.Tables[0].Rows[i]["BRANDID"].ToString() == DutyItem.Value)
                        {
                            DutyItem.Selected = true;
                        }
                    }
                }
            }
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
                string url = @"uploads/teacher/" + pictureName() + fileSuffix;
                lblPUrl.Text = url;
                txtPicture.SaveAs(Server.MapPath("~/" + url));
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                Alert.Show("姓名不能为空");
                return;
            }
            if (txtEName.Text.Trim() == "")
            {
                Alert.Show("英文昵称不能为空");
                return;
            }


            model.ID = Request["ID"].ToString();
            model.CHNNAME = txtName.Text;
            model.ENGNAME = txtEName.Text;
            model.RANK = txtRank.Text.Trim().Replace(System.Environment.NewLine, "<br />"); 
            model.STATUS = "0";
            model.TPICTURE = lblPUrl.Text;
            model.CREATEDATE = DateTime.Now;
            model.DESCRIPTION = Request.Form["Editor1"]; ;
            model.CREATEUSER = Session["AccountID"].ToString();
            bool rs = manage.Update(model);
            if (rs != false)
            {
                mBrandTeacher.Delete(Request["ID"].ToString());
                ///写入品牌信息
                foreach (FineUI.ListItem DutyItem in ddlBrand.SelectedItemArray)
                {
                    brandTeacherModel.TEACHERID = model.ID;
                    brandTeacherModel.BRANDID = DutyItem.Value;
                    mBrandTeacher.Add(brandTeacherModel);
                }
                mSchoolTeacher.Delete(Request["ID"].ToString());
                foreach (FineUI.ListItem DutyItem in ddlSchool.SelectedItemArray)
                {
                    schoolTeacherModel.TEACHERID = model.ID;
                    schoolTeacherModel.SCHOOLID = DutyItem.Value;
                    mSchoolTeacher.Add(schoolTeacherModel);
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