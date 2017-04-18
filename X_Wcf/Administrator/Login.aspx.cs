using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator
{
    public partial class Login : System.Web.UI.Page
    {
        E_BLL.Account manage = new E_BLL.Account();
        E_Model.Account model = new E_Model.Account();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                E_Common.ImageHandler.imageCut(@"C:\Users\kence\Pictures\39.PNG", 50, @"C:\Users\kence\Pictures\");

                E_Common.ImageHandler.getThumImage(@"C:\Users\kence\Pictures\2600.jpg",50,5, @"C:\Users\kence\Pictures\123.jpg");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ds = manage.GetList(" (username = '" + txtUserName.Text + "' or usercode ='" + txtUserName.Text + "')");
            if (txtUserName.Text.Trim() == "")
            {
                //Alert.ShowInTop("用户名不能为空");
                
                Response.Write("<script>alert('用户名不能为空');window.location.href=window.location.href</script>");
                return;
            }
            if (ds.Tables[0].Rows.Count == 1)
            {
                if (txtPassword.Text.Trim() == "")
                {
                    //Alert.ShowInTop("密码不能为空");
                    Response.Write("<script>alert('密码不能为空');window.location.href=window.location.href</script>");
                    return;
                }
                if (E_Common.DEScrypt.Base64Encrypt(txtPassword.Text) != ds.Tables[0].Rows[0]["passwords"].ToString())
                {
                    Response.Write("<script>alert('密码错误');window.location.href=window.location.href</script>");
                    return;
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "1")
                {
                    Response.Write("<script>alert('该帐号已被禁用');window.location.href=window.location.href</script>");
                    return;
                }
                model = manage.GetModel(ds.Tables[0].Rows[0]["id"].ToString());
                Session["User"] = model;
                Session["AccountID"] = ds.Tables[0].Rows[0]["id"].ToString();
                Session["AccountCode"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                Session["AccountName"] = ds.Tables[0].Rows[0]["TrueName"].ToString();
                Session["AccountDept"] = ds.Tables[0].Rows[0]["Dept"].ToString();
                
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("<script>alert('该登录帐号不存在');window.location.href=window.location.href</script>");
                return;
            }
        }
    }
}