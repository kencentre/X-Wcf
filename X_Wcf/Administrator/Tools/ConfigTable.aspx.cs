using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.Tools
{
    public partial class ConfigTable : BasePage
    {
        DataSet ds = new DataSet();
        E_BLL.Desk manage = new E_BLL.Desk();


        E_BLL.DeskAccount mDA = new E_BLL.DeskAccount();
        E_Model.DeskAccount model = new E_Model.DeskAccount();
        DataSet dt = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                btnCancle.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }

        private void Bind()
        {
            ds = manage.GetList(" status = '1'");
            cblDesk.DataSource = ds;
            cblDesk.DataTextField = "deskname";
            cblDesk.DataValueField = "id";
            cblDesk.DataBind();

            ds = new DataSet();
            ds = mDA.GetSearchList("", Session["AccountID"].ToString());
            foreach(FineUI.CheckItem li in cblDesk.Items)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (li.Value == ds.Tables[0].Rows[i]["DESKID"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            mDA.Delete(Session["AccountID"].ToString());

            foreach (FineUI.CheckItem li in cblDesk.Items)
            {
                if (li.Selected == true)
                {
                    model.DESKID = li.Value;
                    model.USERID = Session["AccountID"].ToString();
                    mDA.Add(model);
                }
            }
            Alert.ShowInParent("配置完毕。", string.Empty, ActiveWindow.GetHidePostBackReference());
            
        }
    }
}