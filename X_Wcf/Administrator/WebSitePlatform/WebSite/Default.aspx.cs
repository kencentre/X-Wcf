using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace X_Wcf.Administrator.WebSitePlatform.WebSite
{
    public partial class Default : BasePage
    {
        E_BLL.WebSite manage = new E_BLL.WebSite();
        E_Model.WebSite model = new E_Model.WebSite();

        E_Model.Template tModel = new E_Model.Template();
        E_BLL.Template mTemplate = new E_BLL.Template();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowSourceCode.GetShowReference("Add.aspx", "添加站点栏目信息", 600, 400);
                btnDelete.OnClientClick = windowSourceCode.GetShowReference("Delete.aspx", "删除站点栏目信息", 600, 500);
                btnConfig.OnClientClick = windowSourceCode.GetShowReference("CreateHtml.aspx","生成站点信息",600,500);
            }

            InitTree();
        }
        private void InitTree()
        {
            tvList.Nodes.Clear();

            InitWebsite("00000000-0000-0000-0000-000000000000", tvList, (FineUI.TreeNode)null, windowSourceCode);
        }

        protected void tvList_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            txtID.Text = e.Node.NodeID;
            Bind(e.Node.NodeID);
            btnEdit.OnClientClick = windowSourceCode.GetShowReference("Modify.aspx?id=" + txtID.Text, "修改站点栏目信息", 600, 400);
        }

        private void Bind(string ID)
        {
            model = new E_Model.WebSite();
            model = manage.GetModel(ID);
            txtChannelName.Text = model.WEBNAME;
            txtParent.Text = model.PARENTID;
            txtDescription.Text = model.DESCRIPTION;

            if (model.STATUS == "0")
            {
                cblStatus.Checked = false;
            }
            if (model.STATUS == "1")
            {
                cblStatus.Checked = true;
            }
            if (model.PARENTID != "00000000-0000-0000-0000-000000000000")
            {
                model = new E_Model.WebSite();
                txtParentID.Text = manage.GetModel(txtParent.Text).WEBNAME;
            }
            if (!string.IsNullOrEmpty(model.TEMPLATEID))
            {
                txtTemplate.Text = mTemplate.GetModel(model.TEMPLATEID).TEMPLATENAME;
            }
        }
    }
}