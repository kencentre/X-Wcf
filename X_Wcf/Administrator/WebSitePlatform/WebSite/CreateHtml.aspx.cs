using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace X_Wcf.Administrator.WebSitePlatform.WebSite
{
    public partial class CreateHtml : BasePage
    {
        string str = "";
        E_Model.WebSite model = new E_Model.WebSite();
        E_BLL.WebSite manage = new E_BLL.WebSite();
        E_BLL.Brock mBrock = new E_BLL.Brock();
        E_HtmlTemplate.HtmlCode mhc = new E_HtmlTemplate.HtmlCode();
        DataSet ds = new DataSet();
        DataSet dv = new DataSet();
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MainList.Nodes.Clear();
                InitWebsiteWithCheckBox("00000000-0000-0000-0000-000000000000", MainList, (FineUI.TreeNode)null);
            }
        }


        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            
            FineUI.TreeNode Node = MainList.Nodes[0];
            SetTreeValue(Node);
            //Alert.Show(ViewState["HTML"].ToString());
            Alert.ShowInParent("生成完毕。", string.Empty, ActiveWindow.GetHidePostBackReference());
        }

        protected void MainList_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                MainList.CheckAllNodes(e.Node.Nodes);
            }
            else
            {
                MainList.UncheckAllNodes(e.Node.Nodes);
            }
        }

        private void SetTreeValue(FineUI.TreeNode pNode)
        {
            StringBuilder sb = new StringBuilder();
            string html = "";
            if (html.Length > 0)
            {
                html = "";
            }
            ds = new DataSet();
            ds = manage.GetSearchList("   CMS_WEBSITE.status = '1' and CMS_WEBSITE.ID='"+pNode.NodeID+"' ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                    if (ds.Tables[0].Rows[0]["id"].ToString() == "A8C9876A-7ECB-495C-836A-EC69143A63DE")
                    {
                        //continue;
                    }
                    else
                    {
                        dv = mBrock.GetList(" status= '1' and templateid= '"+ ds.Tables[0].Rows[0]["TEMPLATEID"].ToString() + "' ");
                        if (dv.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dv.Tables[0].Rows.Count; j++)
                            {
                                html = mhc.replaceHtml(Server.MapPath(ds.Tables[0].Rows[0]["TEMPLATEURL"].ToString()), dv.Tables[0].Rows[j]["ID"].ToString(), dv.Tables[0].Rows[j]["BROCKCODE"].ToString());
                            }
                        }
                    }
                //}
            }
            ViewState["HTML"] = html;
            if (ds.Tables[0].Rows[0]["id"].ToString() == "A8C9876A-7ECB-495C-836A-EC69143A63DE")
            {
                //;
            }
            else
            {
                if (pNode.NodeID == "f16375f4-9d60-4586-9548-fc3f0b0fefba")
                {
                    mhc.createHtml(Server.MapPath("~/template/masterpage1.html"), Server.MapPath("~/website/" + ds.Tables[0].Rows[0]["webcode"].ToString() + ".html"), html, "");
                }
                else
                { 
                    mhc.createHtml(Server.MapPath("~/template/masterpage.html"), Server.MapPath("~/website/" + ds.Tables[0].Rows[0]["webcode"].ToString() + ".html"), html,"");
                }
            }
            html = "";
            foreach (FineUI.TreeNode cNode in pNode.Nodes)
            {
                if (cNode.Checked == true)
                {
                    SetTreeValue(cNode);
                }
            }

            
        }

        
    }
}