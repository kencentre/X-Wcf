using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Common;
using System.Text.RegularExpressions;
using System.Data;
using FineUI;
using System.IO;

namespace X_Wcf.Administrator.WebSitePlatform.Tag
{
    public partial class Config : BasePage
    {
        E_Model.Tag model = new E_Model.Tag();
        E_BLL.Tag manage = new E_BLL.Tag();
        E_Model.PropertyValue pvModel = new E_Model.PropertyValue();
        E_BLL.PropertyValue mPv = new E_BLL.PropertyValue();
        DataSet ds = new DataSet();
        FineUI.TextBox tb;
        FineUI.FileUpload fl;
        FineUI.HtmlEditor he;
        FineUI.Image img1;
        FineUI.Image img2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        private void Bind()
        {
            FineUI.TextBox tbx = FormPanel.FindControl("txtInput") as FineUI.TextBox;
            FineUI.FileUpload fu1 = FormPanel.FindControl("up1") as FineUI.FileUpload;
            FineUI.FileUpload fu2 = FormPanel.FindControl("up2") as FineUI.FileUpload;
            HtmlEditor html1 = FormPanel.FindControl("he1") as HtmlEditor;
            
            if (ViewState["type"].ToString() == "1")
            {

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = manage.GetSearchList(" t.id= '" + Request["id"].ToString() + "' ");
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ViewState["PROPERTYID"] = ds.Tables[0].Rows[i]["PROPERTYID"].ToString();
                    ViewState["PROPERTYTYPE"] = ds.Tables[0].Rows[i]["PROPERTYTYPE"].ToString();
                    switch (ds.Tables[0].Rows[i]["PROPERTYTYPE"].ToString())
                    {
                        case "0":
                            tb = new FineUI.TextBox();
                            tb.ID = "txtInput";
                            tb.Label = ds.Tables[0].Rows[i]["PROPERTYNAME"].ToString();
                            tb.ShowLabel = true;
                            FormPanel.Items.Add(tb);
                            break;
                        case "1":
                            fl = new FineUI.FileUpload();
                            fl.ID = "up1";
                            fl.Label = "高分辨率BANNER";
                            fl.ShowLabel = true;
                            FormPanel.Items.Add(fl);
                            img1 = new FineUI.Image();
                            img1.ID = "ig1";
                            img1.Hidden = true;
                            FormPanel.Items.Add(img1);
                            fl = new FineUI.FileUpload();
                            fl.ID = "up2";
                            fl.Label = "低分辨率BANNER";
                            fl.ShowLabel = true;
                            FormPanel.Items.Add(fl);
                            img2 = new FineUI.Image();
                            img2.ID = "ig2";
                            img2.Hidden = true;
                            FormPanel.Items.Add(img2);
                            break;
                        case "2":
                            he = new FineUI.HtmlEditor();
                            he.ID = "he1";
                            he.Label = ds.Tables[0].Rows[i]["PROPERTYNAME"].ToString();
                            he.ShowLabel = true;
                            FormPanel.Items.Add(he);
                            break;
                    }
                }
            }
            FineUI.TextBox tbx = FormPanel.FindControl("txtInput") as FineUI.TextBox;
            FineUI.FileUpload fu1 = FormPanel.FindControl("up1") as FineUI.FileUpload;
            FineUI.FileUpload fu2 = FormPanel.FindControl("up2") as FineUI.FileUpload;
            HtmlEditor html1 = FormPanel.FindControl("he1") as HtmlEditor;
            ds = new DataSet();
            ds = mPv.GetList(" cms_property_value.tagid = '"+ Request["id"].ToString() + "'");

            

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["type"] = "1";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ViewState["ID"] = ds.Tables[0].Rows[i]["ID"].ToString();
                    //ViewState["PROPERTYID"] = ds.Tables[0].Rows[i]["PROPERTYID"].ToString();
                    
                    switch (ds.Tables[0].Rows[i]["PROPERTYTYPE"].ToString())
                    {
                        case "0":
                            tbx.Text = ds.Tables[0].Rows[i]["PROPERTYVALUE"].ToString();
                            break;
                        case "1":
                            if (ds.Tables[0].Rows[i]["PROPERTYTYPE"] != null && ds.Tables[0].Rows[i]["PROPERTYTYPE"].ToString() != "")
                            {
                                string[] strUpload = ds.Tables[0].Rows[i]["PROPERTYVALUE"].ToString().Split(',');
                                
                                ViewState["up1"] = strUpload[0].ToString();
                                ViewState["up2"] = strUpload[1].ToString();
                                img1.ImageUrl = strUpload[0].ToString();
                                img2.ImageUrl = strUpload[1].ToString();
                                img1.Hidden = false;
                                img2.Hidden = false;
                            }
                            else
                            {
                                ViewState["up1"] = "";
                                ViewState["up2"] = "";
                            }
                            break;
                        case "2":
                            html1.Text = ds.Tables[0].Rows[i]["PROPERTYVALUE"].ToString();
                            break;
                    }
                }
            }
            else
            {
                ViewState["type"] = "0";
            }
            

        }

        private string pictureName()
        {
            string pName = "";
            pName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return pName;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            FineUI.TextBox tbx = FormPanel.FindControl("txtInput") as FineUI.TextBox;
            FineUI.FileUpload fu1 = FormPanel.FindControl("up1") as FineUI.FileUpload;
            FineUI.FileUpload fu2 = FormPanel.FindControl("up2") as FineUI.FileUpload;
            HtmlEditor html1 = FormPanel.FindControl("he1") as HtmlEditor;
           
            switch (ViewState["type"].ToString())
            {
                case "0":
                    pvModel.ID = Guid.NewGuid().ToString(); 
                    pvModel.TAGID = Request["id"].ToString();
                    pvModel.PROPERTYID = ViewState["PROPERTYID"].ToString();
                    switch (ViewState["PROPERTYTYPE"].ToString())
                    {
                        case "0":
                            pvModel.PROPERTYVALUE = tbx.Text;
                            break;
                        case "1":
                            if (fu1.HasFile && fu2.HasFile)
                            {
                                string url1 = @"Uploads/Others/High/" + pictureName() + Path.GetExtension(fu1.PostedFile.FileName);
                                string url2 = @"Uploads/Others/Low/" + pictureName() + Path.GetExtension(fu2.PostedFile.FileName);
                                fu1.SaveAs(Server.MapPath("~/"+url1));
                                fu2.SaveAs(Server.MapPath("~/" + url2));
                                pvModel.PROPERTYVALUE = url1 + "," + url2;
                            }
                            else
                            {
                                pvModel.PROPERTYVALUE = ViewState["up1"].ToString() + "," + ViewState["up2"].ToString();
                            }
                            break;
                        case "2":
                            pvModel.PROPERTYVALUE = html1.Text;
                            break;
                    }
                    bool rs = mPv.Add(pvModel);
                    if (rs != false)
                    {
                        Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
                    }
                    else
                    {
                        Alert.ShowInParent("提交失败");
                    }
                    break;
                case "1":
                    pvModel.ID = ViewState["ID"].ToString();
                    pvModel.TAGID = Request["id"].ToString();
                    pvModel.PROPERTYID = ViewState["PROPERTYID"].ToString();
                    switch (ViewState["PROPERTYTYPE"].ToString())
                    {
                        case "0":
                            pvModel.PROPERTYVALUE = tbx.Text;
                            break;
                        case "1":
                            
                                string url1 = @"~/Uploads/Others/" + pictureName() + Path.GetExtension(fu1.PostedFile.FileName);
                                string url2 = @"~/Uploads/Others/" + pictureName() + Path.GetExtension(fu2.PostedFile.FileName);
                                fu1.SaveAs(Server.MapPath(url1));
                                fu2.SaveAs(Server.MapPath(url2));
                                pvModel.PROPERTYVALUE = url1 + "," + url2;
                            
                            break;
                        case "2":
                            pvModel.PROPERTYVALUE = html1.Text;
                            break;
                    }
                    bool rx = mPv.Update(pvModel);
                    if (rx != false)
                    {
                        Alert.ShowInParent("保存成功。", string.Empty, ActiveWindow.GetHidePostBackReference());
                    }
                    else
                    {
                        Alert.ShowInParent("提交失败");
                    }
                    break;
            }

            //Alert.Show(tbx.Text);
        }
    }
}